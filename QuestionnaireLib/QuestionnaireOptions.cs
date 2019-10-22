using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireLib
{
    [Serializable]
    public sealed class QuestionnaireOptions
    {
        public double CorrectAnswerScore { get; set; }
        public double WrongAnswerScore { get; set; }
        public double EmptyAnswerScore { get; set; }
        public double MinimumGrade { get; set; }
        public double MaximumGrade { get; set; }
        public int QuestionsNumber { get; set; }
        public int AnswersPerQuestion { get; set; }
        public readonly QElementGenerationMethod AnswersGenerationMethod = QElementGenerationMethod.RANDOM;
        public QElementGenerationMethod QuestionsGenerationMethod { get; set; }

        /// <summary>
        /// Default object initialization.
        /// </summary>
        public QuestionnaireOptions()
        {
            CorrectAnswerScore = 1;
            WrongAnswerScore = -0.5;
            EmptyAnswerScore = 0;
            MinimumGrade = 0;
            MaximumGrade = 10;
            QuestionsNumber = 0;
            AnswersPerQuestion = 4;
            QuestionsGenerationMethod = QElementGenerationMethod.RANDOM;
        }
    }
}
