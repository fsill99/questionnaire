using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using EasterEggLib;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuestionnaireLib;
using System.Data.OleDb;
using System.Resources;

namespace QuestionnaireClient
{
    public partial class fMain : Form
    {
        public fMain()
        {
            //
            InitializeComponent();
            #region Components Setters (auto-generated code)
            List<Keys> combo = new List<Keys>() { Keys.N, Keys.U, Keys.Z, Keys.Z, Keys.O, Keys.L, Keys.E };
            Form chick = new Form();
            #region Chick form settings
            chick.Width = 500;
            ControlsUtilities.ApplyAppIcon(chick);
            chick.MaximizeBox = false;
            chick.ShowInTaskbar = false;
            chick.ShowIcon = false;
            chick.Text = "Pannello di amministrazione segreto di Federico Silletti";
            Button b1 = new Button() { Text = "Verifica professione", Width = 190 };
            b1.Click += new EventHandler((object o, EventArgs e) => { MessageBox.Show("SISTEMISTA", "Professione", MessageBoxButtons.OK, MessageBoxIcon.Information); });
            chick.Controls.Add(b1);
            Button b2 = new Button() { Text = "Ottieni username segreto", Width = 190 };
            b2.Top = b1.Top + b1.Height + 5;
            b2.Click += new EventHandler((object o, EventArgs e) => { MessageBox.Show("PieTroSmUSi", "Username segreto", MessageBoxButtons.OK, MessageBoxIcon.Information); });
            chick.Controls.Add(b2);
            Button b3 = new Button() { Text = "E stiamoci", Width = 190 };
            b3.Top = b2.Top + b2.Height + 5;
            b3.Click += new EventHandler((object o, EventArgs e) => { while (true) { } });
            chick.Controls.Add(b3);
            #endregion
            EasterEggLib.EasterEgg bity = new EasterEggLib.EasterEgg(combo, this, chick);
            bity.Deploy();
            #endregion
            ControlsUtilities.ApplyAppIcon(this);
        }

        private async void cmdLogin_Click(object sender, EventArgs e)
        {
            //crea l'oggetto per le proprietà dell' utente e le assegna
            BasicUserProperties userProperties = new BasicUserProperties();
            userProperties.FirstName = txtFirstName.Text;
            userProperties.SecondName = txtSecondName.Text;
            userProperties.Password = txtPassword.Text;

            //crea l'oggetto utente 
            User user = new User(userProperties);

            Application.UseWaitCursor = true;
            List<AuthenticationType> auths = await user.AuthenticateAsync(new List<AuthenticationType>() {AuthenticationType.Administrator, AuthenticationType.Teacher});
            Application.UseWaitCursor = false;
           // ControlsUtilities.CleanTextboxes(gbLogin);
            txtPassword.Text = "";

            if(auths.Count == 2)
            {
                DialogResult dResult = MessageBox.Show("Accedere come amministratore?", "Login", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dResult == DialogResult.Yes)
                {
                    ShowAdministratorForm(user);
                }
                else
                {
                    ShowTeacherForm(user);
                }
            }
            else if(auths[0] == AuthenticationType.Administrator)
            {
                ShowAdministratorForm(user);
            }
            else if (auths[0] == AuthenticationType.Teacher)
            {
                ShowTeacherForm(user);
            }
            else
            {
                MessageBox.Show("Credenziali errate, riprovare il login.", "Login fallito", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ShowAdministratorForm(User user)
        {
            fDatabaseManagement fAdmin = new fDatabaseManagement(new Administrator(user));
            fAdmin.Show();
        }

        private void ShowTeacherForm(User user)
        {
            fTeacher fTcr = new fTeacher(new Teacher(user));
            fTcr.Show();
        }

        //login rapido
        private void fMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                cmdLogin_Click(this, e);
        }
    }
}
