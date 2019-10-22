using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace BootstrapAlertServerControl
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")]
    public class ServerControl1 : WebControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null)? "[" + this.ID + "]" : s);
            }
 
            set
            {
                ViewState["Text"] = value;
            }
        }
 
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(Text);
        }

        /// <summary>
        /// Renders bootstrap AlertError control.
        /// </summary>
        /// <param name="title">Strong text of the alert preceding the text.</param>
        /// <param name="text">Text of the alert.</param>
        /// <returns></returns>
        public HtmlGenericControl AlertError(string ID, string title, string text)
        {
            HtmlGenericControl control = new HtmlGenericControl("div");
            HtmlAnchor link = new HtmlAnchor();
            HtmlGenericControl strong = new HtmlGenericControl("strong");

            control.Attributes.Add("id", ID);
            control.Attributes.Add("class", "alert alert-danger center-block");
            link.HRef = "#";
            link.Attributes.Add("class", "close");
            link.Attributes.Add("data-dismiss", "alert");
            link.InnerText = "×";
            strong.InnerText = title + " ";

            control.Controls.Add(link);
            control.Controls.Add(strong);
            control.Controls.Add(new HtmlGenericControl("span") { InnerText = text });
            return control;
        }
    }
}
