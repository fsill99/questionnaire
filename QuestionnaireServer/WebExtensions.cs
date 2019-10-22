using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace QuestionnaireServer
{
    public static class WebExtensions
    {
        /// <summary>
        /// Renders the server control to its html string representation.
        /// </summary>
        /// <param name="control"></param>
        /// <returns>The html string.</returns>
        public static string Render(this Control control)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            control.RenderControl(writer);
            return sb.ToString();
        }

        /// <summary>
        /// Renders the control inside the specified generic html container.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="container">The container to render in.</param>
        /// /// <param name="overwriteContent">Specifies if you want to overwrite the content of the container.</param>
        public static void Render(this Control control, HtmlGenericControl container, bool overwriteContent)
        {
            container.InnerHtml = ((overwriteContent) ? "" : container.InnerHtml) + control.Render();
        }
    }
}