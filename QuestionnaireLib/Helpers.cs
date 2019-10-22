using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireLib
{
    public static class Helpers
    {
        /// <summary>
        /// Checks if a string is valued (i.e. not empty, null or only white spaces).
        /// </summary>
        /// <param name="str">The string whose value is to check.</param>
        /// <returns>True if the string is valued, else false.</returns>
        public static bool IsValuedString(string str)
        {
            return !(String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str));
        }

        /// <summary>
        /// Checks if the given port number is a valid port number.
        /// </summary>
        /// <param name="portNumber">Integer format of the port number.</param>
        /// <returns></returns>
        public static bool IsValidPortNumber(int portNumber)
        {
            return portNumber >= 0 && portNumber <= Math.Pow(2, 16);
        }

        /// <summary>
        /// Checks if the given port number string is a valid port number.
        /// </summary>
        /// <param name="portNumberString">String format of the port number.</param>
        /// <returns></returns>
        public static bool IsValidPortNumber(string portNumberString)
        {
            int portNumber;
            return int.TryParse(portNumberString, out portNumber) && IsValidPortNumber(portNumber);
        }

        /// <summary>
        /// Formats a query string comparison.
        /// </summary>
        /// <param name="fieldName">The db field name.</param>
        /// <param name="fieldValue">The value to compare the field with</param>
        /// <param name="op">Can only be equal, greater than, less than, geq, leq operator.</param>
        /// <returns></returns>
        public static string QueryStringFormat(string fieldName, string op, object fieldValue)
        {
            if(op != "=" && op != ">" && op != "<" && op != ">=" && op != "<=")
            {
                throw new Exception("Unsupported operator: " + op);
            }

            string wrap = "";
            string stringValue = "";
            string query = "";

            if(fieldValue is string)
            {
                wrap = "'";
                stringValue = (string)fieldValue;
            }
            else if (fieldValue is Guid)
            {
                wrap = "";
                stringValue = "{" + ((Guid)fieldValue).ToString() + "}";
            }
            else if(fieldValue is DateTime)
            {
                wrap = "#";
                //Access db date format is MM/dd/yyy
                stringValue = String.Format("{0:MM/dd/yyy}", (DateTime)fieldValue);
            }
            else
            {
                stringValue = fieldValue.ToString();
            }

            query = fieldName + " " + op + wrap + stringValue + wrap;

            return query;
        }

        /// <summary>
        /// Chooses randomly n elements from the parameter list.
        /// </summary>
        /// <typeparam name="T">Type of the List</typeparam>
        /// <param name="list"></param>
        /// <param name="count">Number of elements to choose</param>
        /// <returns>The list of choosed elements</returns>
        public static List<T> ChooseRandomly<T>(List<T> list, int n)
        {
            List<T> ListOutput = new List<T>();
            Random rnd = new Random();
            int i = 0;
            for (i = 0; i <= n - 1; i++)
            {
                int k = rnd.Next(list.Count);
                ListOutput.Add(list[k]);
                list.Remove(list[k]);
            }
            //return list.OrderBy(x => rnd.Next()).Take(n).ToList<T>();
            return ListOutput;
        }

        public static List<T> RimescolaCol<T>(List<T> listInput)
        {
            Random rdm = new Random();

            //List<T> listInput = array;
            List<T> ListOutput = new List<T>();

            while (listInput.Count > 0)
            {
                int k = rdm.Next(0,listInput.Count());
                ListOutput.Add(listInput[k]);

                listInput.RemoveAt(k);
            }

            return ListOutput;
        }



    }
}
