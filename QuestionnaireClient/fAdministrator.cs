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
using System.Data.OleDb;
using System.Data.Common;

namespace QuestionnaireClient
{
    public partial class fAdministrator : Form
    {
        Administrator Administrator;

        public fAdministrator(Administrator administrator)
        {
            InitializeComponent();
            ControlsUtilities.ApplyAppIcon(this);
            Text += administrator.FullName;
            Administrator = administrator;
        }

        private void cmdManagementD_Click(object sender, EventArgs e)
        {
            fDatabaseManagement dbManagementForm = new fDatabaseManagement(Administrator);
            dbManagementForm.ShowDialog();
        }

        private void cmdManagementS_Click(object sender, EventArgs e)
        {
            fServerManagement serverManagementForm = new fServerManagement(Administrator);
            serverManagementForm.ShowDialog();
        }
    }
}
