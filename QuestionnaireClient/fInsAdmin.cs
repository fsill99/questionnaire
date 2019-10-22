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
    public partial class fInsAdmin : Form
    {

        public bool bOk;
        public BasicUserProperties UserProperties;

        /// <summary>
        /// to insert
        /// </summary>
        public fInsAdmin()
        {
            InitializeComponent();
            bOk = false;
            BasicUserProperties basicproperties = new BasicUserProperties();
        }

        /// <summary>
        /// to modify
        /// </summary>
        /// <param name="properties"></param>
        public fInsAdmin(BasicUserProperties properties)
        {
            InitializeComponent();
            bOk = false;
            BasicUserProperties basicproperties = properties;
        }

        private bool ValidateData()
        {
            return txtFirstName.Text != "" && txtSecondName.Text != "" && txtPassword.Text != "";
        }
        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (ValidateData() == true)
            {
                UserProperties = new BasicUserProperties();
                UserProperties.FirstName = txtFirstName.Text;
                UserProperties.SecondName = txtSecondName.Text;
                UserProperties.BirthDate = dtpBirthDate.Value;
                UserProperties.Password = txtPassword.Text;
                bOk = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Dati non validi");
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
