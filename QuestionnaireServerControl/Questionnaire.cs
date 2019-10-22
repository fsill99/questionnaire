using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using QuestionnaireLib;

namespace QuestionnaireServerControl
{
    public enum DisplayMode
    {
        TEST,
        CORRECTION
    }

    public enum ItemDisplayStyle
    {
        CORRECT,
        WRONG,
        UNANSWERED,
        DEFAULT
    }

    [DefaultProperty("Questions")]
    [ToolboxData("<{0}:Questionnaire runat=server></{0}:Questionnaire>")]
    public class Questionnaire: WebControl, INamingContainer, IPostBackDataHandler
    {
        [Bindable(false)]
        [Category("Input")]

        /// <summary>
        /// First character separator for badge controls.
        /// </summary>
        private const string _badgeSeparator = " ";

        /// <summary>
        /// List of question styles associated with a question
        /// </summary>
        private Dictionary<ItemDisplayStyle, string> _questionCssClasses = new Dictionary<ItemDisplayStyle, string>() {
            {ItemDisplayStyle.CORRECT, "question-correct"}
            , {ItemDisplayStyle.WRONG, "question-wrong"}
            , {ItemDisplayStyle.UNANSWERED, "question-unanswered"}
            , {ItemDisplayStyle.DEFAULT, ""}
        };

        /// <summary>
        /// List of answer styles associated with a question
        /// </summary>
        private Dictionary<ItemDisplayStyle, string> _answerCssClasses = new Dictionary<ItemDisplayStyle, string>() {
            {ItemDisplayStyle.CORRECT, "answer-correct"}
            , {ItemDisplayStyle.WRONG, "answer-wrong"}
            , {ItemDisplayStyle.UNANSWERED, "answer-unanswered"}
            , {ItemDisplayStyle.DEFAULT, ""}
        };

        /// <summary>
        /// The questionnaire associate to this control.
        /// </summary>
        public QuestionnaireLib.Questionnaire AssociatedQuestionnaire
        {
            get
            {
                return ViewState["QUESTIONNAIRE"] == null ? QuestionnaireLib.Questionnaire.Default() : (QuestionnaireLib.Questionnaire)ViewState["QUESTIONNAIRE"];
            }
            set
            {
                ViewState["QUESTIONNAIRE"] = value;
            }
        }

        /// <summary>
        /// Manages the display mode of the questionnaire, default value is DisplayMode.TEST.
        /// </summary>
        public DisplayMode DisplayMode
        {
            get
            {
                return ViewState["DISPLAYMODE"] == null ? DisplayMode.TEST : (DisplayMode)ViewState["DISPLAYMODE"];
            }
            set
            {
                ViewState["DISPLAYMODE"] = value;
            }
        }

        /// <summary>
        /// Specifies if the data provided by the control is validated. If that is not the case, data has been tampered.
        /// </summary>
        public bool ValidatedData
        {
            get
            {
                return ViewState["VALIDATED"] == null ? true : (bool)ViewState["VALIDATED"];
            }
            set
            {
                ViewState["VALIDATED"] = value;
            }
        }

        protected override void CreateChildControls()
        {
            //ensuring js
            HtmlGenericControl jsControl = new HtmlGenericControl("script");
            jsControl.Attributes.Add("src", Page.ClientScript.GetWebResourceUrl(this.GetType(), DisplayMode == DisplayMode.TEST ? "QuestionnaireServerControl.Scripts.uncheckableRadios.js" : "QuestionnaireServerControl.Scripts.correction.js"));
            jsControl.Attributes.Add("type", "text/javascript");
            Page.Header.Controls.Add(jsControl);

            //ensuring css
            string cssUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "QuestionnaireServerControl.Style.questionnaire.css");
            HtmlLink cssLink = new HtmlLink();
            cssLink.Href = cssUrl;
            cssLink.Attributes.Add("rel", "stylesheet");
            cssLink.Attributes.Add("type", "text/css");
            Page.Header.Controls.Add(cssLink);

            Controls.Clear();
            if (DisplayMode == QuestionnaireServerControl.DisplayMode.CORRECTION)
            {
                HtmlGenericControl summary = _summary();
                HtmlGenericControl panelGroup = _collapsablePanelGroup();
                HtmlGenericControl correctionPanelBody = _collapsablePanelBody("correction", true);
                HtmlGenericControl correctionPanel;
                correctionPanelBody.Controls[0].Controls.Add(_collapsableQuestionsPanelGroup());
                correctionPanel = _collapsablePanel(_collapsbalePanelHeading("Correzione", "correction", true), correctionPanelBody);
                summary.Controls.Add(correctionPanel);
                panelGroup.Controls.Add(summary);
                Controls.Add(panelGroup);
            }
            else
            {
                Controls.Add(_collapsableQuestionsPanelGroup());
            }  
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresPostBack(this);
        }

        /// <summary>
        /// Function called on postback data submission.
        /// </summary>
        /// <param name="postDataKey">Key of the control.</param>
        /// <param name="postCollection">Collection of keys and values of changed data.</param>
        /// <returns></returns>
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            AssociatedQuestionnaire.Questions.ForEach((q) => q.SelectedAnswer = null);
            IEnumerable<Answer> allAnswers = AssociatedQuestionnaire.Questions.SelectMany(q => q.Answers);

            foreach (string key in postCollection.AllKeys.Where(k => Regex.IsMatch(k, @"^collapse[0-9]+_[0-9]+$")))
            {
                Guid submittedID;
                try
                {
                    submittedID = new Guid(postCollection[key]);
                }
                catch
                {
                    ValidatedData = false;
                    return true;
                }

                Answer answer = (from a in allAnswers
                                 where a.ID.Equals(submittedID)
                                    select a).FirstOrDefault();
                if (answer == null)
                {
                    //tampered data
                    ValidatedData = false;
                }
                else
                {
                    ValidatedData = true;
                    (from q in AssociatedQuestionnaire.Questions
                        where answer.QuestionID.Equals(q.ID)
                        select q).FirstOrDefault().SelectedAnswer = answer;
                }
            }
            return true;
        }

        /// <summary>
        /// Required for IPostBackDataHandler interface, is an empty function.
        /// </summary>
        public virtual void RaisePostDataChangedEvent()
        {
            
        }

        /// <summary>
        /// Returns the summary panel for the CORRECTION display mode.
        /// </summary>
        /// <returns></returns>
        private HtmlGenericControl _summary()
        {
            HtmlGenericControl heading = _collapsbalePanelHeading("Sommario", "summary", false);
            HtmlGenericControl body = _collapsablePanelBody("summary", false);
            HtmlGenericControl listGroup = _badgedListGroup(
            _badgedListGroupItem(_badgeSeparator + "Risposte corrette", AssociatedQuestionnaire.Questions.GetCorrectQuestions().Count.ToString() + "/" + AssociatedQuestionnaire.Questions.Count.ToString(), "ok")
            , _badgedListGroupItem(_badgeSeparator + "Risposte errate", AssociatedQuestionnaire.Questions.GetWrongQuestions().Count.ToString() + "/" + AssociatedQuestionnaire.Questions.Count.ToString(), "remove")
            , _badgedListGroupItem(_badgeSeparator + "Risposte non date", AssociatedQuestionnaire.Questions.GetUnansweredQuestions().Count.ToString() + "/" + AssociatedQuestionnaire.Questions.Count.ToString(), "search")
            , _badgedListGroupItem(_badgeSeparator + "Valutazione", AssociatedQuestionnaire.Evaluate().ToString(), "stats", "evaluation")   
            );
            body.Controls[0].Controls.Add(listGroup);
            return _collapsablePanel(heading, body);
        }

        /// <summary>
        /// Returns a list group populated with the passed items.
        /// </summary>
        /// <param name="items">Items of list group.</param>
        /// <returns></returns>
        private HtmlGenericControl _badgedListGroup(params HtmlAnchor[] items)
        {
            HtmlGenericControl control = new HtmlGenericControl("div");
            control.Attributes.Add("class", "list-group");
            control.Controls.AddRange(items);
            return control;
        }

        /// <summary>
        /// Renders a badged list group item with the specified glyphicon.
        /// </summary>
        /// <param name="id">Id of the item.</param>
        /// <param name="text">Text of the item.</param>
        /// <param name="glyphiconName">Name of the bootstrap glyphicon.</param>
        /// <param name="badgeText">Text of the badge.</param>
        /// <returns></returns>
        private HtmlAnchor _badgedListGroupItem(string text, string badgeText, string glyphiconName, string id = "")
        {
            HtmlAnchor control = new HtmlAnchor();
            HtmlGenericControl icon = new HtmlGenericControl("span");
            HtmlGenericControl textControl = new HtmlGenericControl("span");
            HtmlGenericControl badge = new HtmlGenericControl("span");

            control.HRef = "#";
            control.Attributes.Add("class", "list-group-item");
            if (id != "")
                control.Attributes.Add("id", id);
            icon.Attributes.Add("class", "glyphicon glyphicon-" + glyphiconName);
            textControl.InnerText = text;
            badge.Attributes.Add("class", "badge");
            badge.InnerText = badgeText;

            control.Controls.AddRange(icon, textControl, badge);
            return control;
        }

        /// <summary>
        /// Returns an empty collapsable panel group.
        /// </summary>
        /// <returns></returns>
        private HtmlGenericControl _collapsablePanelGroup()
        {
            HtmlGenericControl control = new HtmlGenericControl("div");
            control.Attributes.Add("class", "panel-group");
            control.Attributes.Add("id", "accordion");
            return control;
        }

        /// <summary>
        /// Raturns a collapsable panel group for a list of questions.
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        private HtmlGenericControl _collapsableQuestionsPanelGroup()
        {
            HtmlGenericControl control = _collapsablePanelGroup();
            HtmlGenericControl heading;
            HtmlGenericControl radioGroup;
            HtmlGenericControl radioPanel = new HtmlGenericControl();
            ItemDisplayStyle style = ItemDisplayStyle.DEFAULT;
            string strScore = "";
            string id = "";
            for (int i = 0; i < AssociatedQuestionnaire.Questions.Count; i++ )
            {
                if (DisplayMode == DisplayMode.CORRECTION)
                {
                    if (AssociatedQuestionnaire.Questions[i].SelectedAnswer == null)
                    {
                        style = ItemDisplayStyle.UNANSWERED;
                        strScore = AssociatedQuestionnaire.Options.EmptyAnswerScore.ToString();
                    }
                    else if (AssociatedQuestionnaire.Questions[i].SelectedAnswer.Correct)
                    {
                        style = ItemDisplayStyle.CORRECT;
                        strScore = "+" + AssociatedQuestionnaire.Options.CorrectAnswerScore.ToString();
                    }
                    else
                    {
                        style = ItemDisplayStyle.WRONG;
                        strScore = AssociatedQuestionnaire.Options.WrongAnswerScore.ToString();
                    }

                }
                id = "collapse" + i.ToString();

                heading = _collapsbalePanelHeading(AssociatedQuestionnaire.Questions[i].Description, id, Convert.ToBoolean((int)DisplayMode), style, strScore);
                //ricontrolla qui, forse dovrai aggiungere un populate()
                radioGroup = _collapsableRadioGroup(AssociatedQuestionnaire.Questions[i], id);
                if (i == 0)
                {
                    radioPanel = _collapsablePanel(heading, radioGroup, style);
                    control.Controls.Add(radioPanel);
                }
                else
                {
                    HtmlGenericControl newRadioPanel = _collapsablePanel(heading, radioGroup, style);
                    radioPanel.Controls.Add(newRadioPanel);
                    radioPanel = newRadioPanel;
                }
            }
            return control;
        }

        /// <summary>
        /// Raturns a panel heading.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        private HtmlGenericControl _collapsbalePanelHeading(string title, string ID, bool collapsed, ItemDisplayStyle style = ItemDisplayStyle.DEFAULT, string optionalStyleText = "")
        {
            HtmlGenericControl control = new HtmlGenericControl("div");
            HtmlGenericControl titleControl = new HtmlGenericControl("h4");
            HtmlAnchor linkControl = new HtmlAnchor();

            control.Attributes.Add("class", "panel-heading");
            titleControl.Attributes.Add("class", "panel-title");
            linkControl.Attributes.Add("data-toggle", "collapse");
            linkControl.Attributes.Add("data-target", "#" + ID);
            if (collapsed)
                linkControl.Attributes.Add("class", "collapsed");
            linkControl.HRef = "#" + ID;
            linkControl.InnerText = title;
            titleControl.Controls.Add(linkControl);
            if(style != ItemDisplayStyle.DEFAULT)
            {
                HtmlGenericControl span = new HtmlGenericControl("span");
                span.InnerText = " " + optionalStyleText;
                span.Attributes.Add("class", _answerCssClasses[style]);
                titleControl.Controls.Add(span);
            }
            control.Controls.Add(titleControl);
            return control;
        }

        /// <summary>
        /// Returns a collapsable panel body.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private HtmlGenericControl _collapsablePanelBody(string ID, bool collapsed)
        {
            HtmlGenericControl control = new HtmlGenericControl("div");
            HtmlGenericControl body = new HtmlGenericControl("div");

            control.Attributes.Add("id", ID);
            control.Attributes.Add("class", "panel-collapse collapse");
            if (!collapsed)
                control.Attributes["class"] += " in";
            body.Attributes.Add("class", "panel-body");

            control.Controls.Add(body);

            return control;
        }

        /// <summary>
        /// Returns a collapsable radio buttons group.
        /// </summary>
        /// <param name="answers"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        private HtmlGenericControl _collapsableRadioGroup(Question question, string ID)
        {
            HtmlGenericControl control = _collapsablePanelBody(ID, Convert.ToBoolean((int)DisplayMode));
            RadioButtonList rbList = new RadioButtonList();
            //mescola le rispote
            rbList.CssClass = "radio";
            rbList.RepeatLayout = RepeatLayout.Flow;
            rbList.RepeatDirection = RepeatDirection.Vertical;
            rbList.ClientIDMode = System.Web.UI.ClientIDMode.Static;

            for (int i = 0; i < question.Answers.Count; i++)
            {
                ListItem item = new ListItem(question.Answers[i].Description, question.Answers[i].ID.ToString());
                if(DisplayMode == DisplayMode.CORRECTION)
                {
                    //when the item is disabled, asp.net overrides the class attribute, making it unusable
                    //item.Enabled = false;
                    if (question.Answers[i].Correct)
                    {
                        item.Attributes["class"] = _answerCssClasses[ItemDisplayStyle.CORRECT];
                    }
                    if (question.SelectedAnswer == question.Answers[i])
                    {
                        item.Selected = true;
                        if(!question.Answers[i].Correct)
                        {
                            item.Attributes["class"] = _answerCssClasses[ItemDisplayStyle.WRONG];
                        }
                    }  
                }
                item.Attributes["id"] = ID + "_" + i.ToString();
                rbList.Items.Add(item);
            }

            control.Controls[0].Controls.Add(rbList);
            return control;
        }

        /// <summary>
        /// Returns a collapsable radio panel from an heading and a radioGroup.
        /// </summary>
        /// <param name="heading"></param>
        /// <param name="radioGroup"></param>
        /// <returns></returns>
        private HtmlGenericControl _collapsablePanel(HtmlGenericControl heading, HtmlGenericControl body, ItemDisplayStyle style = ItemDisplayStyle.DEFAULT)
        {
            HtmlGenericControl control = new HtmlGenericControl("div");
            control.Attributes.Add("class", "panel panel-default " + _questionCssClasses[style]);
            control.Controls.Add(heading);
            control.Controls.Add(body);
            return control;
        }

        /// <summary>
        /// Renders all the html of the control, overridden from base class.
        /// </summary>
        /// <param name="output"></param>
        protected override void Render(HtmlTextWriter output)
        {
            Controls[0].RenderControl(output);
        }
    }
}
