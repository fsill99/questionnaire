using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace QuestionnaireLib
{
    /// <summary>
    /// Specifies the fields required to authenticate with a certain AuthenticationType.
    /// </summary>
    public static class AuthenticationRequiredFields
    {
        /// <summary>
        /// Required fields for STUDENT.
        /// </summary>
        private static List<string> Student = new List<string>() {"FirstName", "SecondName", "BirthDate"};
        /// <summary>
        /// Required fields for TEACHER.
        /// </summary>
        private static List<string> Teacher = new List<string>() { "FirstName", "SecondName", "Password" };
        /// <summary>
        /// Required fields for ADMINISTRATOR.
        /// </summary>
        private static List<string> Administrator = new List<string>() { "FirstName", "SecondName", "Password" };
        /// <summary>
        /// Required fields for UNREGISTERED, must be undefined because this property shouldn't be accessed.
        /// </summary>
        private static List<string> Unregistered;
        
        //ADD HERE NEW PROPERTIES (The property name must conform to the string value in AuthenticationType of the corresponding auth, and the list must contain at least 1 requried field)

        /// <summary>
        /// Returns the fields required to authenticate with a certain AuthenticationType.
        /// </summary>
        /// <param name="auth"></param>
        /// <returns>The list of required fields.</returns>
        public static List<string> Get(AuthenticationType auth)
        {
            return (List<string>)typeof(AuthenticationRequiredFields).GetField(auth.ToString(), BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
        }

        /// <summary>
        /// Used to know if a certain field is required for a certain AuthenticationType.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="auth"></param>
        /// <returns>True if the field is required, false otherwise.</returns>
        public static bool RequiredFor(string field, AuthenticationType auth)
        {
            return ((List<string>)typeof(AuthenticationRequiredFields).GetField(auth.ToString()).GetValue(null)).Contains(field);
        }
    }
}
