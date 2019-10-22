using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QuestionnaireLib;
using System.Data.Common;
using System.Data.OleDb;

namespace QuestionnaireClient
{
    public partial class fCurrentQuestionnaireSession : Form
    {
        private TimeSpan ElapsedTime;
        private fTeacher form;
        private Teacher Teacher;
        public QuestionnaireSession QuestionnaireSession;
        private BindingList<QuestionnaireSubmission> Submissions;
        FileSystemWatcher Watcher;
        private bool IsActiveSession;

        public fCurrentQuestionnaireSession(QuestionnaireSession qSession, Teacher teacher)
        {
            InitializeComponent();
            ControlsUtilities.ApplyAppIcon(this);
            Text += teacher.FullName;

            ElapsedTime = TimeSpan.FromSeconds(0);
            QuestionnaireSession = qSession;
            Teacher = teacher;
            Submissions = new BindingList<QuestionnaireSubmission>();
            IsActiveSession = true;

            dgwSubmissions.DataSource = Submissions;

            Watcher = new FileSystemWatcher();
            Watcher.SynchronizingObject = this;
            Watcher.Path = Path.Combine(AppConfiguration.questionnaireSessionsFolderPath, QuestionnaireSession.FilesystemDirectoryName);
            Watcher.NotifyFilter = NotifyFilters.LastWrite;
            Watcher.Filter = "*.*";
            Watcher.Changed += new FileSystemEventHandler(FileAddedHandler);
            Watcher.EnableRaisingEvents = true;
        }

        private void FileAddedHandler(object sender, FileSystemEventArgs e)
        {
            Submissions.Add(QuestionnaireSubmission.BinaryDeserialize(e.FullPath));
        }

        private void tmrElaspedTime_Tick(object sender, EventArgs e)
        {
            ElapsedTime = ElapsedTime.Add(TimeSpan.FromSeconds(1));
            lblElapsedTime.Text = ElapsedTime.ToString(@"hh\:mm\:ss");
        }

        private void cmdEndSession_Click(object sender, EventArgs e)
        {
            DialogResult scelta;
            

            if (IsActiveSession)
            {
                scelta = MessageBox.Show("Sei sicuro di voler terminare la sessione?", "termina sessione", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (scelta == DialogResult.Yes)
                {
                    tmrElaspedTime.Stop();
                    IsActiveSession = false;
                    cmdEndSession.Text = "Fatto";
                    IISHelpers.StopSite();
                }
            }
            else
            {
               
                Close();
                
                //QuestionnaireSession.Stampa("valutazioni.rtf");

                //System.Diagnostics.Process.Start("valutazioni.rtf");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void fCurrentQuestionnaireSession_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
      
    }
}
