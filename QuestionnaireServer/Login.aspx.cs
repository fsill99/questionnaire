using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using QuestionnaireLib;
using BootstrapAlertServerControl;

namespace QuestionnaireServer
{
    public partial class Login : System.Web.UI.Page
    {
        private QuestionnaireSubmissionsCollection Submissions;
        QuestionnaireSubmission StudentSubmission;

        protected void Page_Load(object sender, EventArgs e)
        {
            CacheHandler.Handle(Cache);
            Submissions = CacheHandler.GetSubmissions(Cache);
            if (CookieAuthentication.IsSet(Context.Request.Cookies))
            {
                Response.Redirect("./Questionnaire.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            cmdSubmit.ServerClick += cmdSubmit_Click;
        }

        private async void cmdSubmit_Click(object sender, EventArgs e)
        {
            Student student;
            DateTime birthDate;
            BasicUserProperties properties = new BasicUserProperties();
            
            properties.FirstName = txtFirstName.Value;
            properties.SecondName = txtSecondName.Value;
            if (!DateTime.TryParseExact(calBirthDate.Value , @"yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
            {
                divErrorContainer.Controls.Add(new BootstrapAlert()
                {
                    Text = "Il formato della data specificato non è supportato dall'applicazione. Rilevata modifica della struttura HTML e/o Javascript."
                    , Title = "Errore dati."
                    , ID = "loginAlert"
                });
                Context.ApplicationInstance.CompleteRequest();
                return;
            }
            else
            {
                properties.BirthDate = birthDate;
            }
            
            student = new Student(properties);

            if (await student.AuthenticateAsync() == AuthenticationType.Student)
            {
                //checking if authenticated user is involved in the current questionnaire session
                if ((from s in CacheHandler.GetInvolvedStudents(Cache)
                       where s.ID.Equals(student.ID)
                       select s).FirstOrDefault() != null /*true*/)
                {
                    StudentSubmission = Submissions.Get(student.ID);

                    if (StudentSubmission == null)
                    {
                        if(Submissions.Items.Where(x => x.AssignationIPAddress == Request.UserHostAddress).FirstOrDefault() == null)
                        {
                            divErrorContainer.Controls.Add(new BootstrapAlert()
                            {
                                Text = "ACCESSO NEGATO!",
                                Title = "Errore dati.",
                                ID = "loginAlert"
                            });
                            /*
                            QuestionnaireSession questionnaireSession = CacheHandler.GetQuestionnaireSession(Cache);
                            QuestionnaireLib.Questionnaire assignedQuestionnaire = new QuestionnaireLib.Questionnaire(questionnaireSession.Questionnaire);
                            assignedQuestionnaire.Populate();
                            foreach (Question q in assignedQuestionnaire.Questions)
                            {
                                q.Answers = Helpers.RimescolaCol(q.Answers);
                            }
                            StudentSubmission = new QuestionnaireSubmission(assignedQuestionnaire, student, Request.UserHostAddress, questionnaireSession);
                            Submissions.Items.Add(StudentSubmission);
                            */
                        }
                        else
                        {
                            //ANOMALY HERE
                            //StudentSubmission.Anomalies.Add(new DifferentHostAnomaly(StudentSubmission.AssignationIPAddress, Request.UserHostAddress));
                            divErrorContainer.Controls.Add(new BootstrapAlert()
                            {
                                Text = "Tentativo di accesso ad un altro account dallo stesso host rilevato."
                                ,
                                Title = "Accesso fallito."
                                ,
                                ID = "loginAlert"
                            });
                            return;
                        }
                    }
                    //Preventing same user from logging from different machines
                    if (StudentSubmission.AssignationIPAddress == Request.UserHostAddress)
                    {
                        FormsAuthentication.SetAuthCookie(student.ID.ToString(), false);
                        if (Request.QueryString["ReturnUrl"] == null)
                        {
                            Response.Redirect("./Questionnaire.aspx", false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                        else
                        {
                            Response.Redirect(Request.QueryString["ReturnUrl"], false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                    }
                    else
                    {
                        //ANOMALY HERE
                        StudentSubmission.Anomalies.Add(new DifferentHostAnomaly(StudentSubmission.AssignationIPAddress, Request.UserHostAddress));
                        divErrorContainer.Controls.Add(new BootstrapAlert()
                        {
                            Text = "Tentativo di accesso da un altro host rilevato."
                            ,
                            Title = "Accesso fallito."
                            ,
                            ID = "loginAlert"
                        });
                    }
                }
                else
                {
                    divErrorContainer.Controls.Add(new BootstrapAlert()
                    {
                        Text = "Lo studente che possiede le credenziali specificate non partecipa a questa esaminazione."
                        ,
                        Title = "Accesso fallito."
                        ,
                        ID = "loginAlert"
                    });
                }
            }
            else
            {
                divErrorContainer.Controls.Add(new BootstrapAlert()
                {
                    Text = "Assicurati di aver inserito correttamente i tuoi dati e riprova."
                    , Title = "Accesso fallito."
                    , ID = "loginAlert"
                });
            }
        }
    }
}