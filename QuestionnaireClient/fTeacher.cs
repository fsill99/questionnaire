using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuestionnaireLib;
using System.Data.Common;
using System.Data.OleDb;

namespace QuestionnaireClient
{
    public partial class fTeacher : Form
    {
        bool toUpdate = false;
        private Teacher Teacher;
        private QuestionnaireSession QuestionnaireSession;
        public QuestionnaireSession LastQuestionnaireSession;
        private fCurrentQuestionnaireSession currentSessionForm;
        private DateTime SystemDate;
       
        
        public fTeacher(Teacher teacher)
        {
            InitializeComponent();
            ControlsUtilities.ApplyAppIcon(this);
            Teacher = teacher;
            Text += teacher.FullName;
            SystemDate = new DateTime();
            SystemDate = DateTime.Today;
        
        }

        private async void cmdGenerate_Click(object sender, EventArgs e)
        {
            if(await TryParseQuestionnaireSessionDataAsync())
            {
                //Topic t = new Topic("Reti", Teacher.ID, new Guid("3FD943CE-9C4E-4FB7-8E95-457E63A05D67"));
                //QuestionnaireOptions o = new QuestionnaireOptions() { QuestionsNumber = 5 };
                //Questionnaire q = new Questionnaire(t, o);
                //QuestionnaireSession qSession = new QuestionnaireSession(q, new List<Student>() { new Student(new BasicUserProperties("Michele", "Bitetti", new DateTime(1996, 4, 2), ""), new Guid("11D96790-0F98-41D8-A72E-30188978C1FE"), new Guid("7A2E1569-6FD2-4998-A74E-F3ED69E9DF68"), new Guid("E6487E82-8F16-4917-95FB-ADC6056B1D87")) }, "Test questionnaire session");
                //qSession.SaveAsync();
                //qSession.CurrentServerSessionSerializitazion();
                //qSession.SaveSerialization();
                //QuestionnaireSession qSession2 = QuestionnaireSession.BinaryDeserialize(AppConfiguration.questionnaireSessionFilePath);

                QuestionnaireSession.SaveAsync();
                QuestionnaireSession.CurrentServerSessionSerializitazion();
                QuestionnaireSession.SaveSerialization();

                /*
                if(true) //IIS required
                {
                    if (!(IISHelpers.SiteExists() && IISSiteConfiguration.FromLocalQuestionnaire().IsQuestionnaireCompatible()))
                        IISHelpers.CreateSite();
                    
                }*/
                IISHelpers.StartSite();

                currentSessionForm = new fCurrentQuestionnaireSession(QuestionnaireSession, Teacher);

                toUpdate = true;
                currentSessionForm.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Dati non validi", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> TryParseQuestionnaireSessionDataAsync()
        {
            QuestionnaireOptions options = new QuestionnaireOptions();
            options.QuestionsGenerationMethod = (QElementGenerationMethod)cboQuestionsGenerationMethod.SelectedItem;
            int answersPerQuestion = 0;
            double correctAnswerScore = 0;
            double emptyAnswerScore = 0;
            double maxmiumGrade = 0;
            double minimumGrade = 0;
            int questionsNumber = 0;
            double wrongAnswerScore = 0;

            Topic topic = (Topic)cboTopic.SelectedItem;

            Questionnaire questionnaire = new Questionnaire(topic, options);
            if(options.QuestionsGenerationMethod != QElementGenerationMethod.RANDOM)
            {
                if(dblswQuestions.SelectedItems.Count > 0)
                {
                    foreach(ListViewItem item in dblswQuestions.Items)
                    {
                        questionnaire.Questions.Add((Question)item.Tag);
                    }
                }
                else
                {
                    return false;
                }
            }

            bool notNull = Helpers.IsValuedString(txtAnswersPerQuestion.Text) &&
                Helpers.IsValuedString(txtCorrectAnswerScore.Text) &&
                Helpers.IsValuedString(txtEmptyAnswerScore.Text) &&
                Helpers.IsValuedString(txtMaximumGrade.Text) &&
                Helpers.IsValuedString(txtMinimumGrade.Text) &&
                Helpers.IsValuedString(txtQuestionsNumber.Text) &&
                Helpers.IsValuedString(txtWrongAnswerScore.Text) &&
                Helpers.IsValuedString(lblSessionDescription.Text);

            if(notNull)
            {
                bool validNumbers = int.TryParse(txtAnswersPerQuestion.Text, out answersPerQuestion) &&
                double.TryParse(txtCorrectAnswerScore.Text, out correctAnswerScore) &&
                double.TryParse(txtEmptyAnswerScore.Text, out emptyAnswerScore) &&
                double.TryParse(txtMaximumGrade.Text, out maxmiumGrade) &&
                double.TryParse(txtMinimumGrade.Text, out minimumGrade) &&
                int.TryParse(txtQuestionsNumber.Text, out questionsNumber) &&
                double.TryParse(txtWrongAnswerScore.Text, out wrongAnswerScore);

                if(validNumbers)
                {
                    bool validSigns = answersPerQuestion > 0 &&
                        correctAnswerScore > 0 &&
                        emptyAnswerScore <= 0 &&
                        maxmiumGrade >= 0 &&
                        questionsNumber > 0 &&
                        wrongAnswerScore < 0;

                    if(validSigns)
                    {
                        List<Student> involvedStudents = await Class.FromData(cboSchoolYear.Text, cboCourse.Text).GetStudentsAsync();
                        options.MaximumGrade = maxmiumGrade;
                        options.AnswersPerQuestion = answersPerQuestion;
                        options.CorrectAnswerScore = correctAnswerScore;
                        /**/
                        options.WrongAnswerScore = wrongAnswerScore;
                        /**/
                        options.EmptyAnswerScore = emptyAnswerScore;
                        options.MinimumGrade = minimumGrade;
                        options.QuestionsNumber = questionsNumber;

                        bool enoughAnswers = questionnaire.Questions.Where(x => x.Answers.Count < answersPerQuestion).Count() == 0;
                        bool enoughQuestions = options.QuestionsGenerationMethod != QElementGenerationMethod.RANDOM ? questionnaire.Questions.Count >= options.QuestionsNumber
                            : (await questionnaire.Topic.GetQuestionsAsync()).Count >= options.QuestionsNumber;
                        bool enoughStudents = involvedStudents.Count > 0;
                        bool validConfiguration = enoughAnswers && enoughQuestions && enoughStudents;

                        if (validConfiguration)
                        {
                            QuestionnaireSession = new QuestionnaireSession(questionnaire, involvedStudents, lblSessionDescription.Text);
                            return true;
                        }   
                    }
                }
            }

            return false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (dblwTopics.SelectedItems.Count > 0)
            {
                Topic topic = (Topic)dblwTopics.SelectedItems[0].Tag;
                topic.DeleteAsync();
                PopulateTopics();
            }
            else
            {
                MessageBox.Show("Nessun argomento selezionato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdModify_Click(object sender, EventArgs e)
        {
            if (dblwTopics.SelectedItems.Count > 0)
            {
                Topic topic = (Topic)dblwTopics.SelectedItems[0].Tag;
                fTopic form = new fTopic(Teacher, topic);
                form.ShowDialog();
                if (form.ValidatedData)
                {
                    form.Topic.SaveAsync();
                    PopulateTopics();
                }
            }
            else
            {
                MessageBox.Show("Nessun argomento selezionato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            fTopic form = new fTopic(Teacher);
            form.ShowDialog();
            if (form.ValidatedData)
            {
                form.Topic.SaveAsync();
                PopulateTopics();
            }
        }

        private async void fTeacher_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 6; i++)
            {
                cboSchoolYear.Items.Add(i);
            }
            cboSchoolYear.SelectedItem = cboSchoolYear.Items[0];
           
            
            #region Database management
            dblwTopics.DbEntityType = typeof(Topic);
            PopulateTopics();

            dblswQuestions.DbEntityType = typeof(Question);

            //dblwEvaluations.DbEntityType = typeof(Evaluation);
            //cboQuestionnaireSession.DataSource = await Teacher.GetQuestionnaireSessionsAsync();
            //cboQuestionnaireSession.DisplayMember = "SessionDate";
            using (OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using (OleDbCommand command = new OleDbCommand())
            {
                conn.Open();
                command.Connection = conn;
                command.CommandText = @"SELECT QuestionnaireSessions.ID, QuestionnaireSessions.Description
                                        FROM (Topics
                                        INNER JOIN Evaluations ON Topics.ID=Evaluations.TOPIC_ID)
                                        INNER JOIN QuestionnaireSessions ON Evaluations.QUESTIONNAIRESESSION_ID=QuestionnaireSessions.ID
                                        WHERE Topics.TEACHER_ID=@TeacherID";
                command.Parameters.AddWithValue("TeacherID", Teacher.ID);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cboQuestionnaireSession.Items.Add(reader.GetString(1));
                    }

                }
            }
            #endregion

            #region Questionnaire configuration
            cboQuestionsGenerationMethod.DataSource = cboAnswersGenerationMethod.DataSource = Enum.GetValues(typeof(QElementGenerationMethod));
            cboAnswersGenerationMethod.SelectedItem = QElementGenerationMethod.RANDOM;
            cboTopic.DataSource = await Teacher.GetTopicsAsync();
            cboTopic.DisplayMember = "Description";
            #endregion
        }

        private void cmdLoadQuestionnaire_Click(object sender, EventArgs e)
        {
            fLoadQuestionnaire loadForm = new fLoadQuestionnaire(Teacher);
            loadForm.ShowDialog();
            if(loadForm.ValidatedData)
            {
                QuestionnaireSession = loadForm.QuestionnaireSession;
                ShowQuestionnaireData();
            }
        }

        private void ShowQuestionnaireData()
        {
            txtAnswersPerQuestion.Text = QuestionnaireSession.Questionnaire.Options.AnswersPerQuestion.ToString();
            txtCorrectAnswerScore.Text = QuestionnaireSession.Questionnaire.Options.CorrectAnswerScore.ToString();
            txtEmptyAnswerScore.Text = QuestionnaireSession.Questionnaire.Options.EmptyAnswerScore.ToString();
            txtMaximumGrade.Text = QuestionnaireSession.Questionnaire.Options.MaximumGrade.ToString();
            txtMinimumGrade.Text = QuestionnaireSession.Questionnaire.Options.MinimumGrade.ToString();
            txtQuestionsNumber.Text = QuestionnaireSession.Questionnaire.Options.QuestionsNumber.ToString();
            txtWrongAnswerScore.Text = QuestionnaireSession.Questionnaire.Options.WrongAnswerScore.ToString();
            cboAnswersGenerationMethod.SelectedItem = QuestionnaireSession.Questionnaire.Options.AnswersGenerationMethod;
            cboQuestionsGenerationMethod.SelectedItem = QuestionnaireSession.Questionnaire.Options.QuestionsGenerationMethod;
            cboTopic.SelectedItem = QuestionnaireSession.Questionnaire.Topic;

            dblswQuestions.Populate(QuestionnaireSession.Questionnaire.Questions);

            cboSchoolYear.SelectedIndex = cboSchoolYear.FindStringExact(QuestionnaireSession.InvolvedClasses[0].SchoolYear);
            cboCourse.SelectedIndex = cboCourse.FindStringExact(QuestionnaireSession.InvolvedClasses[0].Course);
        }

        private void PopulateTopics()
        {
            dblwTopics.Populate(x => ((Topic)x).TeacherID == Teacher.ID);
        }

        public void PopulateEvaluations(string questionnaireSessionDescription)
        {
            //lsvEvaluations.Populate(x => ((Evaluation)x).QuestionnaireSessionID == questionnaireSessionID);
            ListViewItem row;
            ListViewItem.ListViewSubItem elem;
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            string query;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            lsvEvaluations.Items.Clear();

            query = "SELECT Users.FirstName, Users.SecondName, Evaluations.Grade FROM ((Evaluations INNER JOIN QuestionnaireSessions ON Evaluations.QUESTIONNAIRESESSION_ID=QuestionnaireSessions.ID) INNER JOIN Students ON Evaluations.STUDENT_ID=Students.ID) INNER JOIN Users ON Students.USER_ID=Users.ID WHERE QuestionnaireSessions.Description='" + questionnaireSessionDescription + "'";
            command = new OleDbCommand(query, conn);
            reader = command.ExecuteReader();

            while (reader.Read() == true)
            {
                //Teacher teacher;
                //BasicUserProperties properties = new BasicUserProperties();

                //create a new row
                row = new ListViewItem();

                //create,set first cell
                row.Text = reader.GetString(0);

                //create subitem ,i set it and i add it at row
                elem = new ListViewItem.ListViewSubItem();
                elem.Text = reader.GetString(1);
                row.SubItems.Add(elem);

                //create the third subitem ,i set it and i add it at row
                elem = new ListViewItem.ListViewSubItem();
                elem.Text =reader.GetDouble(2).ToString();
                row.SubItems.Add(elem);

                //add row at listview
                lsvEvaluations.Items.Add(row);

                //teacher = new Teacher(properties, reader.GetGuid(5), reader.GetGuid(4));
                //set the reference at the object
                //row.Tag = teacher;
            }
            conn.Close();
        }

        private void PopulateQuestions(Guid topicID)
        {
            dblswQuestions.Populate(x => ((Question)x).TopicID == topicID);
        }

        private void cboSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCourse.Items.Clear();
            cboCourse.Text = "";
            using (OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using (OleDbCommand command = new OleDbCommand())
            {
                conn.Open();
                command.Connection = conn;
                command.CommandText = "SELECT Course FROM [Classes] WHERE SchoolYear=@SchoolYear";
                command.Parameters.AddWithValue("SchoolYear", cboSchoolYear.SelectedItem);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cboCourse.Items.Add(reader.GetString(0));
                    }
                }
            }
            if (cboCourse.Items.Count > 0)
                cboCourse.SelectedItem = cboCourse.Items[0];

            if (cboTopic.Text != "" && cboCourse.Text != "")
            {
                lblSessionDescription.Text = cboTopic.Text + cboSchoolYear.Text + cboCourse.Text + SystemDate.ToShortDateString().ToString();
            }
        }

        private void cboQuestionnaireSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateEvaluations(cboQuestionnaireSession.Text);
        }

        private void cboTopic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((QElementGenerationMethod)cboQuestionsGenerationMethod.SelectedItem != QElementGenerationMethod.RANDOM)
            {
                if (cboTopic.SelectedItem != null)
                    PopulateQuestions(((Topic)cboTopic.SelectedItem).ID);
            }

            if (cboSchoolYear.Text != "" && cboCourse.Text != "")
            {
                lblSessionDescription.Text = cboTopic.Text + cboSchoolYear.Text + cboCourse.Text + SystemDate.ToShortDateString().ToString();
            }
        }

        private void cboQuestionsGenerationMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((QElementGenerationMethod)cboQuestionsGenerationMethod.SelectedItem != QElementGenerationMethod.RANDOM)
            {
                dblswQuestions.Enabled = true;
                dblswQuestions.Visible = true;
                label14.Visible = true;
                if (cboTopic.SelectedItem != null)
                    PopulateQuestions(((Topic)cboTopic.SelectedItem).ID);
            }
            else
            {
                dblswQuestions.Enabled = false;
                dblswQuestions.Visible = false;
                label14.Visible = false;
            }
        }

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSchoolYear.Text != "" && cboTopic.Text != "")
            {
                lblSessionDescription.Text = cboTopic.Text + cboSchoolYear.Text + cboCourse.Text + SystemDate.ToShortDateString().ToString();
            }
        }

        private void cmdStampa_Click(object sender, EventArgs e)
        {
            QuestionnaireSession.Stampa("valutazioni.rtf",cboQuestionnaireSession.Text);
            System.Diagnostics.Process.Start("valutazioni.rtf");
        }

        private void tabQuestionnaire_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dblswQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
           
            if (toUpdate == true)
            {
                cboQuestionnaireSession.Items.Add(currentSessionForm.QuestionnaireSession.Description);
                cboQuestionnaireSession.Text = currentSessionForm.QuestionnaireSession.Description;
                LoadLastQuestionnaire(currentSessionForm.QuestionnaireSession.Description);
                toUpdate = false;                     
            }
            
        }

        private void cmdAggiorna_Click(object sender, EventArgs e)
        {
           
        }

        private void tabEvaluations_Click(object sender, EventArgs e)
        {

        }

        public void LoadLastQuestionnaire(string lastQuestionnaireDescription)
        {
            //lsvEvaluations.Populate(x => ((Evaluation)x).QuestionnaireSessionID == questionnaireSessionID);
            ListViewItem row;
            ListViewItem.ListViewSubItem elem;
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            string query;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();


            lsvEvaluations.Items.Clear();

            query = "SELECT Users.FirstName, Users.SecondName, Evaluations.Grade FROM ((Evaluations INNER JOIN QuestionnaireSessions ON Evaluations.QUESTIONNAIRESESSION_ID=QuestionnaireSessions.ID) INNER JOIN Students ON Evaluations.STUDENT_ID=Students.ID) INNER JOIN Users ON Students.USER_ID=Users.ID  WHERE QuestionnaireSessions.Description = '" + lastQuestionnaireDescription + "'";
            command = new OleDbCommand(query, conn);
            reader = command.ExecuteReader();

            while (reader.Read() == true)
            {
                //Teacher teacher;
                //BasicUserProperties properties = new BasicUserProperties();

                //create a new row
                row = new ListViewItem();

                //create,set first cell
                row.Text = reader.GetString(0);

                //create subitem ,i set it and i add it at row
                elem = new ListViewItem.ListViewSubItem();
                elem.Text = reader.GetString(1);
                row.SubItems.Add(elem);

                //create the third subitem ,i set it and i add it at row
                elem = new ListViewItem.ListViewSubItem();
                elem.Text = reader.GetDouble(2).ToString();
                row.SubItems.Add(elem);

                //add row at listview
                lsvEvaluations.Items.Add(row);

                //teacher = new Teacher(properties, reader.GetGuid(5), reader.GetGuid(4));
                //set the reference at the object
                //row.Tag = teacher;
            }
            conn.Close();
        }



    }
}
