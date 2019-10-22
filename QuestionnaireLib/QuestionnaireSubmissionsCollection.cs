using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireLib
{
    public class QuestionnaireSubmissionsCollection
    {
        private List<QuestionnaireSubmission> _submissions;

        /// <summary>
        /// Submissions of the collection.
        /// </summary>
        public List<QuestionnaireSubmission> Items {
            get { return _submissions;  }
            set { _submissions = value; }
        }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public QuestionnaireSubmissionsCollection()
        {
            _submissions = new List<QuestionnaireSubmission>();
        }

        /// <summary>
        /// Constructor from list.
        /// </summary>
        /// <param name="submissions"></param>
        public QuestionnaireSubmissionsCollection(List<QuestionnaireSubmission> submissions)
        {
            _submissions = submissions;
        }

        /// <summary>
        /// Retrieves the submission associated to the student's ID passed as parameter.
        /// </summary>
        /// <param name="studentID"></param>
        /// <returns></returns>
        public QuestionnaireSubmission Get(Guid studentID)
        {
            List<QuestionnaireSubmission> submissions = (from submission in _submissions
                    where submission.Submitter.ID.Equals(studentID)
                    select submission).ToList<QuestionnaireSubmission>();
            if(submissions.Count == 0)
            {
                return null;
            }
            else
            {
                return submissions.First();
            }
        }
    }
}
