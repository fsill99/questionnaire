using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace QuestionnaireLib
{
    public static class AppConfiguration
    {
        /// <summary>
        /// Current folder of the application (has to adapt to server \bin folder)
        /// </summary>
        public static string currentFolder = @"C:\inetpub\wwwroot\QuestionnaireServer";
        //public static string currentFolder = "C:\\Users\\Lia\\Desktop\\Questionnaire\\Questionnaire\\Questionnaire\\Release";



        /// <summary>
        /// Database connection string.
        /// </summary>
        public static string connectionString
        {
            get 
            { 
            return @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\inetpub\wwwroot\QuestionnaireServer\App_Data\QuestionnaireDB.accdb"; 
            
            }
        }

        /// <summary>
        /// Path of the Questionnaires folder.
        /// </summary>
        public static string questionnaireSessionsFolderPath
        {
            get { return @"C:\inetpub\wwwroot\QuestionnaireServer\App_Data\Questionnaires"; }
        }

        /// <summary>
        /// Path of the questionnaire that has to be assigned in the current run of the server.
        /// </summary>
        public static string questionnaireSessionFilePath
        {
            get { return @"C:\inetpub\wwwroot\QuestionnaireServer\App_Data\Questionnaires\Current\QuestionnaireSession.dat"; }
        }
    }
}
