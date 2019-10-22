using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using QuestionnaireLib;
using QuestionnaireServerControl;
using BootstrapAlertServerControl;

namespace QuestionnaireServer
{
    public partial class Questionnaire : System.Web.UI.Page
    {
        private QuestionnaireSubmissionsCollection Submissions;
        private Guid StudentID;
        private QuestionnaireSubmission CurrentSubmission;

        protected async void Page_Load(object sender, EventArgs e)
        {
            Submissions = CacheHandler.GetSubmissions(Cache);
            if (CookieAuthentication.IsSet(Context.Request.Cookies))
            {
                StudentID = CookieAuthentication.GetStudentID(Context.Request.Cookies);
                CurrentSubmission = Submissions.Get(StudentID);
                if (CurrentSubmission.SubmissionIPAddress != null)
                {
                    Response.Redirect("./Result.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    cmdConfirm.ServerClick += new EventHandler(cmdConfirm_Click);

                    if (!IsPostBack)
                    {
                        ccQuestionnaire.AssociatedQuestionnaire = CurrentSubmission.Questionnaire;
                    }
                        
                }
            }
        }

        /// <summary>
        /// Function called on questionnaire submission.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void cmdConfirm_Click(object sender, EventArgs e)
        {
            if(ccQuestionnaire.ValidatedData)
            {
                List<Question> submittedQuestions = ccQuestionnaire.AssociatedQuestionnaire.Questions;
                if (CurrentSubmission.Questionnaire.Questions.TestMatch(submittedQuestions))
                {
                    //lecit data
                    CurrentSubmission.Questionnaire.Questions = submittedQuestions;
                    CurrentSubmission.SubmissionIPAddress = Request.UserHostAddress;
                    CurrentSubmission.Grade();
                    CurrentSubmission.BinarySerialize(CacheHandler.GetQuestionnaireSessionFolderPath(Cache));

                    Response.Redirect("./Result.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    //tampered data (high detail)
                    CurrentSubmission.Anomalies.Add(new TamperedDataAnomaly(CurrentSubmission.Questionnaire.Questions, submittedQuestions));
                    _handleAnomalyOccurrence();
                }
            }
            else
            {
                //tampered data (low detail)
                CurrentSubmission.Anomalies.Add(new TamperedDataAnomaly());
                _handleAnomalyOccurrence();
            }
        }

        private void _showAnomalyAlert()
        {
            divContainer.Attributes["class"] += " first-top";
            divErrorContainer.Controls.Add(new BootstrapAlert()
            {
                Text = "Il formato dei dati ricevuti non è conforme a quello dei dati forniti. Rilevata modifica della struttura HTML e/o Javascript."
                , Title = "Errore dati."
                , ID = "loginAlert"
            });
        }

        private void _handleAnomalyOccurrence()
        {
            //instant redirection is preferred to alert display, little fraudsters won't be aware that their actions are being recorded
            Response.Redirect("./Questionnaire.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}