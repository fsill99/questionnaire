using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace QuestionnaireServerControl
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Adds a set of controls to the ControlCollection.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="controls">The controls to add.</param>
        public static void AddRange(this ControlCollection collection, params Control[] controls)
        {
            foreach (Control c in controls)
                collection.Add(c);
        }
    }
}
