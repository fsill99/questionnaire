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
    public partial class fTopic : Form
    {
        public Topic Topic { get; set; }
        public bool ValidatedData { get; set; }

        public fTopic(Teacher teacher)
        {
            InitializeComponent();
            ValidatedData = false;
            Topic = new Topic("", teacher.ID);

            dblswQuestions.DbEntityType = typeof(Question);
            dblwAnswerAss.DbEntityType = typeof(Answer);
        }

        public fTopic(Teacher teacher, Topic topic) : this(teacher)
        {
            txtTopicDescription.Text = topic.Description;
            Topic = topic;

            Populate();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (ValidatedData = ValidateData())
            {
                Topic.Description = txtTopicDescription.Text;
            }
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (dblswQuestions.SelectedItems.Count > 0)
            {
                Question question = (Question)dblswQuestions.SelectedItems[0].Tag;
                question.DeleteAsync();
                Populate();
            }
            else
            {
                MessageBox.Show("Nessuna domanda selezionata", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdModify_Click(object sender, EventArgs e)
        {
            if (dblswQuestions.SelectedItems.Count > 0)
            {
                Question question = (Question)dblswQuestions.SelectedItems[0].Tag;
                fQuestion form = new fQuestion(question);
                form.ShowDialog();
                if (form.ValidatedData)
                {
                    form.Question.SaveAsync();
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
                Topic.Description = txtTopicDescription.Text;
                Topic.SaveAsync();
                fQuestion form = new fQuestion(Topic.ID);
                form.ShowDialog();
                if (form.ValidatedData)
                {
                    form.Question.SaveAsync();
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
            return Helpers.IsValuedString(txtTopicDescription.Text);
        }

        private void Populate()
        {
            dblswQuestions.Populate(x => ((Question)x).TopicID.Equals(Topic.ID));
        }

        private void dblswQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dblswQuestions.SelectedItems.Count>0)
            {
                Question question = (Question)dblswQuestions.SelectedItems[0].Tag;
                dblwAnswerAss.Populate(x => ((Answer)x).QuestionID.Equals(question.ID));
            }
        }

        private void txtTopicDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
