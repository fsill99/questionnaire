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
    public partial class fInsertA : Form
    {
        public bool bOk;
        public BasicUserProperties UserProperties;

        /// <summary>
        /// to insert
        /// </summary>
        public fInsertA()
        {
            InitializeComponent();
            bOk = false;
            BasicUserProperties basicproperties = new BasicUserProperties();
        }

        /// <summary>
        /// to modify
        /// </summary>
        /// <param name="properties"></param>
        public fInsertA(BasicUserProperties properties)
        {
            InitializeComponent();
            bOk = false;
            BasicUserProperties basicproperties = properties;
            txtFirstName.Text = properties.FirstName;
            txtSecondName.Text = properties.SecondName;
            if (properties.BirthDate > dtpBirthDate.MinDate)
            {
                dtpBirthDate.Value = properties.BirthDate;
            }
            txtPassword.Text = properties.Password;
        }

        private bool ValidateData()
        {
            return txtFirstName.Text != "" && txtSecondName.Text != "" && txtPassword.Text != "";
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                if (dtpBirthDate.Value.ToShortDateString() == DateTime.Today.ToShortDateString())
                {
                    dtpBirthDate.Value = DateTime.Today;
                }
                UserProperties = new BasicUserProperties(txtFirstName.Text, txtSecondName.Text, dtpBirthDate.Value, txtPassword.Text);
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

        private void fInsert_Load(object sender, EventArgs e)
        {

        }

        private void lblBirthDate_Click(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
