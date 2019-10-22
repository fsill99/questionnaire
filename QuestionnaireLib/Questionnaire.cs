using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuestionnaireLib
{
    [Serializable]
    public sealed class Questionnaire
    {
        public QuestionnaireOptions Options { get; set; }
        public List<Question> Questions { get; set; }
        public Topic Topic { get; set; }

        private Action _questionsPopulator;
        private Action<Question> _answersPopulator;

        /// <summary>
        /// Returns an empty questionnaire, useful for postback child controls creation.
        /// </summary>
        /// <returns></returns>
        public static Questionnaire Default()
        {
            return new Questionnaire(new Topic("", new Guid()), new QuestionnaireOptions());
        }

        /// <summary>
        /// Constructor used to copy an object (different object reference).
        /// </summary>
        /// <param name="questionnaire"></param>
        public Questionnaire(Questionnaire questionnaire)
            : this(questionnaire.Questions, questionnaire.Topic, questionnaire.Options)
        {
        }

        /// <summary>
        /// Constructor with questions. 
        /// </summary>
        /// <param name="questions"></param>
        /// <param name="topic"></param>
        /// <param name="options"></param>
        public Questionnaire(List<Question> questions, Topic topic, QuestionnaireOptions options)
        {
            Questions = questions;
            Topic = topic;
            Options = options;
        }

        /// <summary>
        /// Constructor without questions.
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="options"></param>
        public Questionnaire(Topic topic, QuestionnaireOptions options)
        {
            Questions = new List<Question>();
            Topic = topic;
            Options = options;
        }

        /// <summary>
        /// Initializes populators functions from Options
        /// </summary>
        private void _initializePopulators()
        {
            
            switch (Options.AnswersGenerationMethod)
            {
                case QElementGenerationMethod.FIXED:
                /*case QElementGenerationMethod.RANDOMSELECTED:
                    //these 2 options are not currently supported for answers, assigning empty function
                    _answersPopulator = (Question q) => { };
                    break;*/
                case QElementGenerationMethod.RANDOM:
                    _answersPopulator = async (Question q) =>
                    {
                        
                        List<Answer> wrongAns = await q.GetAnswersAsync(false, true);
                        List<Answer> correctAns = await q.GetAnswersAsync(true, false);

                        List<Answer> totAns = new List<Answer>();
                        Random rnd = new Random();
                        int i = rnd.Next(correctAns.Count);

                        int k = 0;

                        for (k = 0; k <= Options.AnswersPerQuestion - 2; k++)
                        {
                            i = rnd.Next(wrongAns.Count);

                            totAns.Add(wrongAns[i]);

                            wrongAns.Remove(wrongAns[i]);
                        }

                        i = rnd.Next(correctAns.Count);

                        totAns.Add(correctAns[i]);

                        //totAns = new List<Answer>(Helpers.ChooseRandomly(correctAns, 1).Concat(Helpers.ChooseRandomly(wrongAns, Options.AnswersPerQuestion - 1)));
                        //q.Answers.OrderBy(x => rnd.Next());
                        //totAns = Helpers.ChooseRandomly(wrongAns, Options.AnswersPerQuestion - 1);
                        //correctAns = (Helpers.ChooseRandomly(correctAns, 1));
                        //totAns.Add(correctAns[0]);
                        //totAns = Helpers.RimescolaCol(totAns);
                        q.Answers = Helpers.RimescolaCol(totAns ); 
                    };
                    break;
            }

            switch (Options.QuestionsGenerationMethod)
            {
                case QElementGenerationMethod.FIXED:
                    _questionsPopulator = () => { };
                    break;
                case QElementGenerationMethod.RANDOM:
                    _questionsPopulator = async () =>
                    {
                        List<Question> q = await Topic.GetQuestionsAsync();
                        Questions = Helpers.ChooseRandomly(q, Options.QuestionsNumber);
                    };
                    break;
                /*case QElementGenerationMethod.RANDOMSELECTED:
                    _questionsPopulator = () =>
                    {
                        Questions = Helpers.ChooseRandomly(Questions, Options.QuestionsNumber);
                    };
                    break;*/
            }
        }

        /// <summary>
        /// Populates the questionnaire with questions and answers, uses Options
        /// </summary>
        public void Populate()
        {
            _initializePopulators();
            _questionsPopulator();
            foreach(Question q in Questions)
            {
                _answersPopulator(q);
            }
        }

        /// <summary>
        /// Evaluates the questionnaire and returns the grade.
        /// </summary>
        /// <returns>The grade of the questionnaire</returns>
        public double Evaluate()
        {
            double grade = 0;
            foreach(Question q in Questions)
            {
                if(q.SelectedAnswer == null)
                {
                    //empty answer
                    grade += Options.EmptyAnswerScore;
                }
                else
                {
                    if(q.SelectedAnswer.Correct)
                    {
                        //correct answer
                        grade += Options.CorrectAnswerScore;
                    }
                    else
                    {
                        //wrong answer
                        grade += Options.WrongAnswerScore;
                    }
                }
            }
            return Math.Max(Options.MinimumGrade, Math.Min(Options.MaximumGrade, grade));
        }
    }
}
