using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Web;

namespace QuestionnaireLib
{
    public static class Extensions
    {
        /// <summary>
        /// Extension method for Enum that retrieves the description attribute value of an element.
        /// </summary>
        /// <returns></returns>
        public static string ToDescriptionString(this Enum val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        /// <summary>
        /// Maps boolean values to "0" and "1".
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToBinaryString(this bool val)
        {
            return Convert.ToInt32(val).ToString();
        }

        /// <summary>
        /// Return the table name associated to the authentication (its description attribute).
        /// </summary>
        /// <param name="at"></param>
        /// <returns></returns>
        public static string ToTableName(this AuthenticationType at)
        {
            return at.ToDescriptionString();
        }

        /// <summary>
        /// Tests if two lists of questions match (useful when testing for submitted questions against generated questions).
        /// </summary>
        /// <param name="l"></param>
        /// <param name="targetList">The target list to check.</param>
        /// <returns>True if the lists match, false otherwise.</returns>
        public static bool TestMatch(this List<Question> l, List<Question> targetList)
        {
            if(l.Count == targetList.Count)
            {
                targetList = targetList.OrderBy(q => q.ID).ToList();
                List<Question> lCopy = new List<Question>(l).OrderBy(q => q.ID).ToList();
                for (int i = 0; i < lCopy.Count; i++)
                {
                    if (lCopy[i].ID != targetList[i].ID || lCopy[i].Description != targetList[i].Description || !lCopy[i].Answers.TestMatch(targetList[i].Answers))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Tests if two lists of answers match (useful when testing for submitted answers against generated answers).
        /// </summary>
        /// <param name="l"></param>
        /// <param name="targetList">The target list to check.</param>
        /// <returns>True if the lists match, false otherwise.</returns>
        public static bool TestMatch(this List<Answer> l, List<Answer> targetList)
        {
            targetList = targetList.OrderBy(q => q.ID).ToList();
            List<Answer> lCopy = new List<Answer>(l).OrderBy(q => q.ID).ToList();
            for (int i = 0; i < lCopy.Count; i++)
            {
                if (lCopy[i].ID != targetList[i].ID || lCopy[i].Description != targetList[i].Description || lCopy[i].Correct != targetList[i].Correct || lCopy[i].QuestionID != targetList[i].QuestionID)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Returns a new list by removing the specified target item from the current list.
        /// </summary>
        /// <typeparam name="T">Type of the list.</typeparam>
        /// <param name="l"></param>
        /// <param name="items">The set of items to remove.</param>
        public static List<T> RemoveRange<T>(this List<T> l, List<T> items)
        {
            List<T> newList = new List<T>(l);
            foreach(T item in items)
            {
                newList.Remove(item);
            }
            return newList;
        }

        /// <summary>
        /// Returns the correctly answered questions of the list.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static List<Question> GetCorrectQuestions(this List<Question> l)
        {
            return (from q in l.RemoveRange(l.GetUnansweredQuestions())
                    where q.SelectedAnswer.Correct == true
                    select q).ToList();
        }

        /// <summary>
        /// Returns the wrongly answered questions of the list.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static List<Question> GetWrongQuestions(this List<Question> l)
        {
            return (from q in l.RemoveRange(l.GetUnansweredQuestions())
                    where q.SelectedAnswer.Correct == false
                    select q).ToList();
        }

        /// <summary>
        /// Returns the unanswered questions of the list.
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static List<Question> GetUnansweredQuestions(this List<Question> l)
        {
            return (from q in l
                    where q.SelectedAnswer == null
                    select q).ToList();
        }
    }
}
