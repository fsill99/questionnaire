using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestionnaireClient
{
    public static class ControlsUtilities
    {
        /// <summary>
        /// Empties the textboxes contained in the specified groupbox.
        /// </summary>
        /// <param name="container">The GroupBox object.</param>
        public static void CleanTextboxes(GroupBox container)
        {
            foreach (Control c in container.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    c.Text = "";
            }
        }

        /// <summary>
        /// Sets the icon of the specified form to the application icon.
        /// </summary>
        /// <param name="form"></param>
        public static void ApplyAppIcon(Form form)
        {
            form.Icon = Properties.Resources.app_icon;
        }
    }
}
