using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestionnaireLib;

namespace QuestionnaireServer
{
    public partial class Result : System.Web.UI.Page
    {
        private QuestionnaireSubmissionsCollection Submissions;
        private Guid StudentID;
        private QuestionnaireSubmission CurrentSubmission;

        protected void Page_Load(object sender, EventArgs e)
        {
            Submissions = CacheHandler.GetSubmissions(Cache);
            if (CookieAuthentication.IsSet(Context.Request.Cookies))
            {
                StudentID = CookieAuthentication.GetStudentID(Context.Request.Cookies);
                CurrentSubmission = Submissions.Get(StudentID);
                if (CurrentSubmission.SubmissionIPAddress == null)
                {
                    Response.Redirect("./Questionnaire.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    ccQuestionnaire.AssociatedQuestionnaire = CurrentSubmission.Questionnaire;
                    CookieAuthentication.ExpireAllCookies(Request.Cookies, Response.Cookies);
                }
            }
        }
    }
}