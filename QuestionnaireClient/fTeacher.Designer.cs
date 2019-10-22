namespace QuestionnaireClient
{
    partial class fTeacher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTeacher));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabQuestionnaire = new System.Windows.Forms.TabPage();
            this.lblSessionDescription = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dblswQuestions = new DbListviewWinformControl.DbListview();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.cboSchoolYear = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdLoadQuestionnaire = new System.Windows.Forms.Button();
            this.cboTopic = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboAnswersGenerationMethod = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboQuestionsGenerationMethod = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAnswersPerQuestion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuestionsNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaximumGrade = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMinimumGrade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmptyAnswerScore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWrongAnswerScore = new System.Windows.Forms.TextBox();
            this.txtCorrectAnswerScore = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.tabTopics = new System.Windows.Forms.TabPage();
            this.dblwTopics = new DbListviewWinformControl.DbListview();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdInsert = new System.Windows.Forms.Button();
            this.cmdModify = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.tabEvaluations = new System.Windows.Forms.TabPage();
            this.cmdStampa = new System.Windows.Forms.Button();
            this.lsvEvaluations = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label13 = new System.Windows.Forms.Label();
            this.cboQuestionnaireSession = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabQuestionnaire.SuspendLayout();
            this.tabTopics.SuspendLayout();
            this.tabEvaluations.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabQuestionnaire);
            this.tabControl1.Controls.Add(this.tabTopics);
            this.tabControl1.Controls.Add(this.tabEvaluations);
            this.tabControl1.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1178, 673);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabQuestionnaire
            // 
            this.tabQuestionnaire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.tabQuestionnaire.Controls.Add(this.lblSessionDescription);
            this.tabQuestionnaire.Controls.Add(this.label15);
            this.tabQuestionnaire.Controls.Add(this.label14);
            this.tabQuestionnaire.Controls.Add(this.dblswQuestions);
            this.tabQuestionnaire.Controls.Add(this.cboCourse);
            this.tabQuestionnaire.Controls.Add(this.cboSchoolYear);
            this.tabQuestionnaire.Controls.Add(this.label12);
            this.tabQuestionnaire.Controls.Add(this.cmdLoadQuestionnaire);
            this.tabQuestionnaire.Controls.Add(this.cboTopic);
            this.tabQuestionnaire.Controls.Add(this.label11);
            this.tabQuestionnaire.Controls.Add(this.cboAnswersGenerationMethod);
            this.tabQuestionnaire.Controls.Add(this.label10);
            this.tabQuestionnaire.Controls.Add(this.cboQuestionsGenerationMethod);
            this.tabQuestionnaire.Controls.Add(this.label9);
            this.tabQuestionnaire.Controls.Add(this.txtAnswersPerQuestion);
            this.tabQuestionnaire.Controls.Add(this.label8);
            this.tabQuestionnaire.Controls.Add(this.txtQuestionsNumber);
            this.tabQuestionnaire.Controls.Add(this.label7);
            this.tabQuestionnaire.Controls.Add(this.txtMaximumGrade);
            this.tabQuestionnaire.Controls.Add(this.label6);
            this.tabQuestionnaire.Controls.Add(this.txtMinimumGrade);
            this.tabQuestionnaire.Controls.Add(this.label5);
            this.tabQuestionnaire.Controls.Add(this.txtEmptyAnswerScore);
            this.tabQuestionnaire.Controls.Add(this.label4);
            this.tabQuestionnaire.Controls.Add(this.txtWrongAnswerScore);
            this.tabQuestionnaire.Controls.Add(this.txtCorrectAnswerScore);
            this.tabQuestionnaire.Controls.Add(this.label3);
            this.tabQuestionnaire.Controls.Add(this.label2);
            this.tabQuestionnaire.Controls.Add(this.cmdGenerate);
            this.tabQuestionnaire.Location = new System.Drawing.Point(4, 32);
            this.tabQuestionnaire.Name = "tabQuestionnaire";
            this.tabQuestionnaire.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuestionnaire.Size = new System.Drawing.Size(1170, 637);
            this.tabQuestionnaire.TabIndex = 1;
            this.tabQuestionnaire.Text = "Questionario";
            this.tabQuestionnaire.Click += new System.EventHandler(this.tabQuestionnaire_Click);
            // 
            // lblSessionDescription
            // 
            this.lblSessionDescription.AutoSize = true;
            this.lblSessionDescription.BackColor = System.Drawing.Color.White;
            this.lblSessionDescription.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionDescription.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblSessionDescription.Location = new System.Drawing.Point(866, 37);
            this.lblSessionDescription.Name = "lblSessionDescription";
            this.lblSessionDescription.Size = new System.Drawing.Size(0, 17);
            this.lblSessionDescription.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.label15.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(486, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(374, 27);
            this.label15.TabIndex = 27;
            this.label15.Text = "Descrizione dell\'esaminazione:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.label14.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(560, 164);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(358, 24);
            this.label14.TabIndex = 26;
            this.label14.Text = "Seleziona le domande da inserire ";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // dblswQuestions
            // 
            this.dblswQuestions.DbEntityType = typeof(object);
            this.dblswQuestions.DisplayGuids = false;
            this.dblswQuestions.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dblswQuestions.FullRowSelect = true;
            this.dblswQuestions.HideSelection = false;
            this.dblswQuestions.Location = new System.Drawing.Point(564, 201);
            this.dblswQuestions.Name = "dblswQuestions";
            this.dblswQuestions.Properties = new System.Reflection.PropertyInfo[0];
            this.dblswQuestions.Size = new System.Drawing.Size(574, 330);
            this.dblswQuestions.TabIndex = 25;
            this.dblswQuestions.UseCompatibleStateImageBehavior = false;
            this.dblswQuestions.View = System.Windows.Forms.View.Details;
            this.dblswQuestions.SelectedIndexChanged += new System.EventHandler(this.dblswQuestions_SelectedIndexChanged);
            // 
            // cboCourse
            // 
            this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourse.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCourse.FormattingEnabled = true;
            this.cboCourse.Location = new System.Drawing.Point(803, 115);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(321, 30);
            this.cboCourse.TabIndex = 24;
            this.cboCourse.SelectedIndexChanged += new System.EventHandler(this.cboCourse_SelectedIndexChanged);
            // 
            // cboSchoolYear
            // 
            this.cboSchoolYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSchoolYear.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSchoolYear.FormattingEnabled = true;
            this.cboSchoolYear.Location = new System.Drawing.Point(727, 115);
            this.cboSchoolYear.Name = "cboSchoolYear";
            this.cboSchoolYear.Size = new System.Drawing.Size(62, 30);
            this.cboSchoolYear.TabIndex = 23;
            this.cboSchoolYear.SelectedIndexChanged += new System.EventHandler(this.cboSchoolYear_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.label12.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(549, 118);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 27);
            this.label12.TabIndex = 22;
            this.label12.Text = "Classe:";
            // 
            // cmdLoadQuestionnaire
            // 
            this.cmdLoadQuestionnaire.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLoadQuestionnaire.ForeColor = System.Drawing.Color.Maroon;
            this.cmdLoadQuestionnaire.Location = new System.Drawing.Point(22, 30);
            this.cmdLoadQuestionnaire.Name = "cmdLoadQuestionnaire";
            this.cmdLoadQuestionnaire.Size = new System.Drawing.Size(177, 57);
            this.cmdLoadQuestionnaire.TabIndex = 21;
            this.cmdLoadQuestionnaire.Text = "Carica ...";
            this.cmdLoadQuestionnaire.UseVisualStyleBackColor = true;
            this.cmdLoadQuestionnaire.Click += new System.EventHandler(this.cmdLoadQuestionnaire_Click);
            // 
            // cboTopic
            // 
            this.cboTopic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTopic.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTopic.FormattingEnabled = true;
            this.cboTopic.Location = new System.Drawing.Point(727, 73);
            this.cboTopic.Name = "cboTopic";
            this.cboTopic.Size = new System.Drawing.Size(397, 30);
            this.cboTopic.TabIndex = 20;
            this.cboTopic.SelectedIndexChanged += new System.EventHandler(this.cboTopic_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.label11.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(549, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 27);
            this.label11.TabIndex = 19;
            this.label11.Text = "Argomento:";
            // 
            // cboAnswersGenerationMethod
            // 
            this.cboAnswersGenerationMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnswersGenerationMethod.Enabled = false;
            this.cboAnswersGenerationMethod.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAnswersGenerationMethod.FormattingEnabled = true;
            this.cboAnswersGenerationMethod.Location = new System.Drawing.Point(10, 586);
            this.cboAnswersGenerationMethod.Name = "cboAnswersGenerationMethod";
            this.cboAnswersGenerationMethod.Size = new System.Drawing.Size(189, 30);
            this.cboAnswersGenerationMethod.TabIndex = 18;
            this.cboAnswersGenerationMethod.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.label10.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(6, 550);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(471, 27);
            this.label10.TabIndex = 17;
            this.label10.Text = "Modalità di generazione delle risposte:";
            this.label10.Visible = false;
            // 
            // cboQuestionsGenerationMethod
            // 
            this.cboQuestionsGenerationMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuestionsGenerationMethod.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboQuestionsGenerationMethod.FormattingEnabled = true;
            this.cboQuestionsGenerationMethod.Location = new System.Drawing.Point(10, 501);
            this.cboQuestionsGenerationMethod.Name = "cboQuestionsGenerationMethod";
            this.cboQuestionsGenerationMethod.Size = new System.Drawing.Size(189, 30);
            this.cboQuestionsGenerationMethod.TabIndex = 16;
            this.cboQuestionsGenerationMethod.SelectedIndexChanged += new System.EventHandler(this.cboQuestionsGenerationMethod_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.label9.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(6, 461);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(486, 27);
            this.label9.TabIndex = 15;
            this.label9.Text = "Modalità di generazione delle domande:";
            // 
            // txtAnswersPerQuestion
            // 
            this.txtAnswersPerQuestion.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnswersPerQuestion.Location = new System.Drawing.Point(397, 367);
            this.txtAnswersPerQuestion.Name = "txtAnswersPerQuestion";
            this.txtAnswersPerQuestion.Size = new System.Drawing.Size(55, 30);
            this.txtAnswersPerQuestion.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.label8.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 369);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(386, 27);
            this.label8.TabIndex = 13;
            this.label8.Text = "Numero risposte per domanda:";
            // 
            // txtQuestionsNumber
            // 
            this.txtQuestionsNumber.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuestionsNumber.Location = new System.Drawing.Point(397, 340);
            this.txtQuestionsNumber.Name = "txtQuestionsNumber";
            this.txtQuestionsNumber.Size = new System.Drawing.Size(55, 30);
            this.txtQuestionsNumber.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.label7.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(233, 27);
            this.label7.TabIndex = 11;
            this.label7.Text = "Numero domande:";
            // 
            // txtMaximumGrade
            // 
            this.txtMaximumGrade.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaximumGrade.Location = new System.Drawing.Point(197, 254);
            this.txtMaximumGrade.Name = "txtMaximumGrade";
            this.txtMaximumGrade.Size = new System.Drawing.Size(55, 30);
            this.txtMaximumGrade.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.label6.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(6, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 27);
            this.label6.TabIndex = 9;
            this.label6.Text = "Voto massimo:";
            // 
            // txtMinimumGrade
            // 
            this.txtMinimumGrade.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinimumGrade.Location = new System.Drawing.Point(197, 225);
            this.txtMinimumGrade.Name = "txtMinimumGrade";
            this.txtMinimumGrade.Size = new System.Drawing.Size(55, 30);
            this.txtMinimumGrade.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(6, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 27);
            this.label5.TabIndex = 7;
            this.label5.Text = "Voto minimo:";
            // 
            // txtEmptyAnswerScore
            // 
            this.txtEmptyAnswerScore.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmptyAnswerScore.Location = new System.Drawing.Point(367, 161);
            this.txtEmptyAnswerScore.Name = "txtEmptyAnswerScore";
            this.txtEmptyAnswerScore.Size = new System.Drawing.Size(55, 30);
            this.txtEmptyAnswerScore.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(357, 27);
            this.label4.TabIndex = 5;
            this.label4.Text = "Punteggio risposta non data:";
            // 
            // txtWrongAnswerScore
            // 
            this.txtWrongAnswerScore.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWrongAnswerScore.Location = new System.Drawing.Point(367, 131);
            this.txtWrongAnswerScore.Name = "txtWrongAnswerScore";
            this.txtWrongAnswerScore.Size = new System.Drawing.Size(55, 30);
            this.txtWrongAnswerScore.TabIndex = 4;
            // 
            // txtCorrectAnswerScore
            // 
            this.txtCorrectAnswerScore.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorrectAnswerScore.Location = new System.Drawing.Point(367, 103);
            this.txtCorrectAnswerScore.Name = "txtCorrectAnswerScore";
            this.txtCorrectAnswerScore.Size = new System.Drawing.Size(55, 30);
            this.txtCorrectAnswerScore.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Punteggio risposta errata:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(344, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Punteggio risposta corretta:";
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGenerate.Font = new System.Drawing.Font("Rockwell", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGenerate.ForeColor = System.Drawing.Color.DarkCyan;
            this.cmdGenerate.Location = new System.Drawing.Point(564, 537);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(574, 79);
            this.cmdGenerate.TabIndex = 0;
            this.cmdGenerate.Text = "Genera ed avvia esaminazione";
            this.cmdGenerate.UseVisualStyleBackColor = false;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // tabTopics
            // 
            this.tabTopics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.tabTopics.Controls.Add(this.dblwTopics);
            this.tabTopics.Controls.Add(this.label1);
            this.tabTopics.Controls.Add(this.cmdInsert);
            this.tabTopics.Controls.Add(this.cmdModify);
            this.tabTopics.Controls.Add(this.cmdDelete);
            this.tabTopics.Location = new System.Drawing.Point(4, 32);
            this.tabTopics.Name = "tabTopics";
            this.tabTopics.Padding = new System.Windows.Forms.Padding(3);
            this.tabTopics.Size = new System.Drawing.Size(1170, 637);
            this.tabTopics.TabIndex = 2;
            this.tabTopics.Text = "Argomenti, domande e risposte";
            // 
            // dblwTopics
            // 
            this.dblwTopics.DbEntityType = typeof(object);
            this.dblwTopics.DisplayGuids = false;
            this.dblwTopics.Font = new System.Drawing.Font("Lucida Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dblwTopics.FullRowSelect = true;
            this.dblwTopics.Location = new System.Drawing.Point(65, 94);
            this.dblwTopics.Name = "dblwTopics";
            this.dblwTopics.Properties = new System.Reflection.PropertyInfo[0];
            this.dblwTopics.Size = new System.Drawing.Size(687, 484);
            this.dblwTopics.TabIndex = 5;
            this.dblwTopics.UseCompatibleStateImageBehavior = false;
            this.dblwTopics.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkCyan;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(66, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "Argomenti";
            // 
            // cmdInsert
            // 
            this.cmdInsert.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInsert.ForeColor = System.Drawing.Color.DarkCyan;
            this.cmdInsert.Location = new System.Drawing.Point(798, 135);
            this.cmdInsert.Name = "cmdInsert";
            this.cmdInsert.Size = new System.Drawing.Size(201, 91);
            this.cmdInsert.TabIndex = 3;
            this.cmdInsert.Text = "Inserisci";
            this.cmdInsert.UseVisualStyleBackColor = true;
            this.cmdInsert.Click += new System.EventHandler(this.cmdInsert_Click);
            // 
            // cmdModify
            // 
            this.cmdModify.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdModify.ForeColor = System.Drawing.Color.DarkCyan;
            this.cmdModify.Location = new System.Drawing.Point(798, 289);
            this.cmdModify.Name = "cmdModify";
            this.cmdModify.Size = new System.Drawing.Size(201, 91);
            this.cmdModify.TabIndex = 2;
            this.cmdModify.Text = "Modifica";
            this.cmdModify.UseVisualStyleBackColor = true;
            this.cmdModify.Click += new System.EventHandler(this.cmdModify_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Font = new System.Drawing.Font("Book Antiqua", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.ForeColor = System.Drawing.Color.DarkCyan;
            this.cmdDelete.Location = new System.Drawing.Point(798, 451);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(201, 91);
            this.cmdDelete.TabIndex = 1;
            this.cmdDelete.Text = "Elimina";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // tabEvaluations
            // 
            this.tabEvaluations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.tabEvaluations.Controls.Add(this.cmdStampa);
            this.tabEvaluations.Controls.Add(this.lsvEvaluations);
            this.tabEvaluations.Controls.Add(this.label13);
            this.tabEvaluations.Controls.Add(this.cboQuestionnaireSession);
            this.tabEvaluations.Location = new System.Drawing.Point(4, 32);
            this.tabEvaluations.Name = "tabEvaluations";
            this.tabEvaluations.Padding = new System.Windows.Forms.Padding(3);
            this.tabEvaluations.Size = new System.Drawing.Size(1170, 637);
            this.tabEvaluations.TabIndex = 3;
            this.tabEvaluations.Text = "Valutazioni";
            this.tabEvaluations.Click += new System.EventHandler(this.tabEvaluations_Click);
            // 
            // cmdStampa
            // 
            this.cmdStampa.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmdStampa.Font = new System.Drawing.Font("Lucida Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStampa.ForeColor = System.Drawing.Color.DarkCyan;
            this.cmdStampa.Location = new System.Drawing.Point(950, 360);
            this.cmdStampa.Name = "cmdStampa";
            this.cmdStampa.Size = new System.Drawing.Size(198, 74);
            this.cmdStampa.TabIndex = 4;
            this.cmdStampa.Text = "Stampa";
            this.cmdStampa.UseVisualStyleBackColor = false;
            this.cmdStampa.Click += new System.EventHandler(this.cmdStampa_Click);
            // 
            // lsvEvaluations
            // 
            this.lsvEvaluations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvEvaluations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lsvEvaluations.Font = new System.Drawing.Font("Book Antiqua", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvEvaluations.FullRowSelect = true;
            this.lsvEvaluations.GridLines = true;
            this.lsvEvaluations.Location = new System.Drawing.Point(24, 79);
            this.lsvEvaluations.Name = "lsvEvaluations";
            this.lsvEvaluations.Scrollable = false;
            this.lsvEvaluations.Size = new System.Drawing.Size(905, 525);
            this.lsvEvaluations.TabIndex = 3;
            this.lsvEvaluations.UseCompatibleStateImageBehavior = false;
            this.lsvEvaluations.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nome";
            this.columnHeader1.Width = 320;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cognome";
            this.columnHeader2.Width = 374;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Voto";
            this.columnHeader3.Width = 130;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(20, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(441, 27);
            this.label13.TabIndex = 2;
            this.label13.Text = "Seleziona sessione di esaminazione:";
            // 
            // cboQuestionnaireSession
            // 
            this.cboQuestionnaireSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuestionnaireSession.FormattingEnabled = true;
            this.cboQuestionnaireSession.Location = new System.Drawing.Point(481, 23);
            this.cboQuestionnaireSession.Name = "cboQuestionnaireSession";
            this.cboQuestionnaireSession.Size = new System.Drawing.Size(553, 31);
            this.cboQuestionnaireSession.TabIndex = 1;
            this.cboQuestionnaireSession.SelectedIndexChanged += new System.EventHandler(this.cboQuestionnaireSession_SelectedIndexChanged);
            // 
            // fTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(168)))), ((int)(((byte)(19)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1202, 698);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Questionnaire - Insegnante: ";
            this.Load += new System.EventHandler(this.fTeacher_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabQuestionnaire.ResumeLayout(false);
            this.tabQuestionnaire.PerformLayout();
            this.tabTopics.ResumeLayout(false);
            this.tabTopics.PerformLayout();
            this.tabEvaluations.ResumeLayout(false);
            this.tabEvaluations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabQuestionnaire;
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.TabPage tabTopics;
        private System.Windows.Forms.Button cmdInsert;
        private System.Windows.Forms.Button cmdModify;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuestionsNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaximumGrade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMinimumGrade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmptyAnswerScore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWrongAnswerScore;
        private System.Windows.Forms.TextBox txtCorrectAnswerScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAnswersPerQuestion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboQuestionsGenerationMethod;
        private System.Windows.Forms.ComboBox cboAnswersGenerationMethod;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboTopic;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button cmdLoadQuestionnaire;
        private DbListviewWinformControl.DbListview dblwTopics;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.ComboBox cboSchoolYear;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabEvaluations;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboQuestionnaireSession;
        private DbListviewWinformControl.DbListview dblswQuestions;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblSessionDescription;
        private System.Windows.Forms.Button cmdStampa;
        private System.Windows.Forms.ListView lsvEvaluations;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}