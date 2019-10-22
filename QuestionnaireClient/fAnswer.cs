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
    public partial class fAnswer : Form
    {
        public bool ValidatedData { get; set; }
        public Answer Answer;

        public fAnswer(Guid questionID)
        {
            InitializeComponent();
            Answer = new Answer("", false, questionID);
        }

        public fAnswer(Answer answer) : this(answer.QuestionID)
        {
            //InitializeComponent();
            txtDescription.Text = answer.Description;
            chkCorrect.Checked = answer.Correct;
            Answer = answer;
        }

        public void cmdSave_Click(object sender, EventArgs e)
        {
            if(ValidatedData = ValidateData())
            {
                Answer.Description = txtDescription.Text;
                Answer.Correct = chkCorrect.Checked;
            }
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidateData()
        {
            return Helpers.IsValuedString(txtDescription.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
