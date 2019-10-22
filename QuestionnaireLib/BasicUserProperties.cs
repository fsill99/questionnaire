using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireLib
{
    /// <summary>
    /// Represents the basic properties of every user of the application.
    /// </summary>
    public class BasicUserProperties
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BasicUserProperties()
        {
            this.FirstName = "";
            this.SecondName = "";
            this.BirthDate = new DateTime();
            this.Password = "";
        }

        /// <summary>
        /// Default constructor method (all fields).
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="birthDate"></param>
        /// <param name="password"></param>
        public BasicUserProperties(string firstName, string secondName, DateTime birthDate, string password)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.BirthDate = birthDate;
            this.Password = password;
        }
    }
}
