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
    public partial class fLoadQuestionnaire : Form
    {
        private Teacher Teacher;
        public QuestionnaireSession QuestionnaireSession;
        public bool ValidatedData;

        public fLoadQuestionnaire(Teacher teacher)
        {
            InitializeComponent();
            Teacher = teacher;
            ValidatedData = false;
            dblwQuestionnaireSessions.DbEntityType = typeof(QuestionnaireSession);
            dblwQuestionnaireSessions.Populate(x => ((QuestionnaireSession)x).Questionnaire.Topic.TeacherID.Equals(Teacher.ID));
        }

        private void cmdConfirm_Click(object sender, EventArgs e)
        {
            if(ValidatedData = dblwQuestionnaireSessions.SelectedItems.Count > 0)
            {
                QuestionnaireSession = (QuestionnaireSession)dblwQuestionnaireSessions.SelectedItems[0].Tag;
                Close();
            }
            else
            {
                MessageBox.Show("Seleziona un questionario precedente prima di procedere.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
