using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using QuestionnaireLib;

namespace QuestionnaireClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if(AdministratorPrivileges())
            {
                if(IISHelpers.IISInstalled())
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new fMain());
                }
                else
                {
                    MessageBox.Show("Provvedere all'installazione di IIS 7 su questa macchina prima di procedere all'utilizzo dell'applicazione.", "IIS 7 non installato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Richieste credenziali di amministratore per utilizzare l'applicazione.", "Errore di autorizzazione", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool AdministratorPrivileges()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
