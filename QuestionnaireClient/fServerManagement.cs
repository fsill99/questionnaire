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
using Microsoft.Web.Administration;
using System.Security.Permissions;
using System.Net;

namespace QuestionnaireClient
{
    public partial class fServerManagement : Form
    {
        Administrator Administrator;

        public fServerManagement(Administrator administrator)
        {
            InitializeComponent();
            Text += administrator.FullName;
            ControlsUtilities.ApplyAppIcon(this);

            Administrator = administrator;
            ServerManager IISManager = new ServerManager();

            txtSiteName.Text = IISSiteConfiguration.Questionnaire.Name;
            txtAppPoolName.Text = IISSiteConfiguration.Questionnaire.ApplicationPoolConfiguration.Name;
            txtSitePath.Text = IISSiteConfiguration.Questionnaire.PhysicalPath;

            if (IISHelpers.SiteExists(IISSiteConfiguration.Questionnaire.Name))
            {
                IISSiteConfiguration localQuestionnaireConfig = IISSiteConfiguration.FromLocalQuestionnaire();
                //QuestionnaireSite already exist
                if (localQuestionnaireConfig.IsQuestionnaireCompatible())
                {
                    //valid configuration is stored on the local machine
                    txtHostname.Text = localQuestionnaireConfig.BindingConfiguration.Hostname;
                    txtPort.Text = localQuestionnaireConfig.BindingConfiguration.Port;
                    txtIPAddress.Text = localQuestionnaireConfig.BindingConfiguration.IPAddress;
                }
                else
                {
                    //invalid configuration (non-allowed changes have been made from the IIS panel)
                    IISHelpers.ResetSite();
                    MessageBox.Show("La configurazione sito-application pool è stata resettata perché sono state effettuate dal pannell di amministrazione IIS delle modifiche non supportate da questa applicazione.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                //QuestionnaireSite does not already exist
                SetDefaultValues();
                IISHelpers.CreateSite();
                MessageBox.Show("Sito non esistente. Creazione con parametri di default avvenuta con successo.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmdSetDefaultValues_Click(object sender, EventArgs e)
        {
            SetDefaultValues();
        }

        private void cmdCommitChanges_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress;
            if (Helpers.IsValuedString(txtIPAddress.Text) && (IPAddress.TryParse(txtIPAddress.Text, out ipAddress) || txtIPAddress.Text == "*") && Helpers.IsValuedString(txtPort.Text) && Helpers.IsValidPortNumber(txtPort.Text))
            {
                IISHelpers.ModifySite(new IISBindingConfiguration(IISSiteConfiguration.Questionnaire.BindingConfiguration.Protocol, txtIPAddress.Text, txtPort.Text, txtHostname.Text));
            }
            else
            {
                MessageBox.Show("Dati non validi, reinserirli correttamente.", "Erorre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDefaultValues()
        {
            txtHostname.Text = IISSiteConfiguration.Questionnaire.BindingConfiguration.Hostname;
            txtIPAddress.Text = IISSiteConfiguration.Questionnaire.BindingConfiguration.IPAddress;
            txtPort.Text = IISSiteConfiguration.Questionnaire.BindingConfiguration.Port;
        }

        private void tsiInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Questo pannello permettere di visualizzare e gestire rapidamente il sito IIS associato all'applicazione.", "Cos'è questo pannello?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsiModifyMethodInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Accedendo al pannello di amministrazione di IIS. Attenzione, però, non tutti i dati dovrebbero essere modificati per garantire un corretto funzionamento dell'applicazione.", "Come modifico gli altri dati?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsiModifyDataInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tutti i dati che non sono riportati in questo pannello, ad eccezione di quelli di binding.", "Quali dati posso modificare?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsiServerErrors_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Solitamente è un problema di account con privilegi insuficienti associato all'Application Pool e/o al sito.", "Visualizzo errori http quando accedo al sito.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
