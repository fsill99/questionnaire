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

namespace QuestionnaireClient
{
    public partial class fQuestion : Form
    {
        public Question Question;
        public bool ValidatedData;

        public fQuestion(Guid topicID)
        {
            InitializeComponent();
            Question = new Question("", topicID, new List<Answer>());

            dblwAnswers.DbEntityType = typeof(Answer);
        }

        public fQuestion(Question question) : this(question.TopicID)
        {
            Question = question;
            txtDescription.Text = Question.Description;

            Populate();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            ValidatedData = ValidateData();
            Question.Description = txtDescription.Text;
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (dblwAnswers.SelectedItems.Count > 0)
            {
                Answer answer = (Answer)dblwAnswers.SelectedItems[0].Tag;
                answer.DeleteAsync();
                Populate();
            }
            else
            {
                MessageBox.Show("Nessuna domanda selezionata", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdModify_Click(object sender, EventArgs e)
        {
            if (dblwAnswers.SelectedItems.Count > 0)
            {
                Answer answer = (Answer)dblwAnswers.SelectedItems[0].Tag;
                fAnswer form = new fAnswer(answer);
                form.ShowDialog();
                if (form.ValidatedData)
                {
                    form.Answer.SaveAsync();
                    //form.cmdSave_Click(this, new EventArgs());
                    Populate();
                }
            }
            else
            {
                MessageBox.Show("Nessuna domanda selezionata", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            if(ValidatedData = ValidateData())
            {
                Question.Description = txtDescription.Text;
                Question.SaveAsync();
                fAnswer form = new fAnswer(Question.ID);
                form.ShowDialog();
                if (form.ValidatedData)
                {
                    form.Answer.SaveAsync();
                    Populate();
                }
            }
            else
            {
                MessageBox.Show("Dati non validi per questo argomento", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateData()
        {
            return Helpers.IsValuedString(txtDescription.Text);
        }

        private void Populate()
        {
            //Populates the listview with all the questions in the database
            dblwAnswers.Populate(x => ((Answer)x).QuestionID.Equals(Question.ID));
        }

        private void fQuestion_Load(object sender, EventArgs e)
        {

        }
    }
}
