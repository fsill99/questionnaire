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
    [ToolboxData("<{0}:BootstrapAlert runat=server></{0}:BootstrapAlert>")]
    public class BootstrapAlert : WebControl
    {
        [Bindable(false)]
        [Category("Appearance")]
        [Localizable(false)]

        /// <summary>
        /// Text body of the alert.
        /// </summary>
        public string Text
        {
            get
            {
                return ViewState["Text"] == null ? "" : (string)ViewState["Text"];
            }
            set
            {
                ViewState["Text"] = value;
            }
        }

        /// <summary>
        /// Title of the alert.
        /// </summary>
        public string Title
        {
            get
            {
                return ViewState["Title"] == null ? "" : (string)ViewState["Title"];
            }
            set
            {
                ViewState["Title"] = value;
            }
        }

        /// <summary>
        /// Overridden, renders the whole html corresponding to the control.
        /// </summary>
        /// <param name="output"></param>
        protected override void Render(HtmlTextWriter output)
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
            strong.InnerText = Title + " ";

            control.Controls.Add(link);
            control.Controls.Add(strong);
            control.Controls.Add(new HtmlGenericControl("span") { InnerText = Text });

            control.RenderControl(output);
        }
    }
}
