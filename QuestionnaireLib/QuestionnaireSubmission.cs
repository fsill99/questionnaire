using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace QuestionnaireLib
{
    [Serializable]
    public class QuestionnaireSubmission
    {
        public string AssignationIPAddress { get; set; }
        public string SubmissionIPAddress { get; set; }
        public Student Submitter { get; set; }
        public Questionnaire Questionnaire { get; set; }
        public Evaluation Evaluation { get; set; }
        public QuestionnaireSession QuestionnaireSession { get; set; }
        public List<SubmissionAnomaly> Anomalies { get; set; }

        public string FilesystemFileName
        {
            get
            {
                return this.Submitter.ID.ToString() + ".dat";
            }
        }

        /// <summary>
        /// Default constructor, to be used when a questionnaire is assigned to a student.
        /// </summary>
        /// <param name="assignedQuestionnaire"></param>
        /// <param name="submitter"></param>
        /// <param name="assignationIPAddress"></param>
        public QuestionnaireSubmission(Questionnaire questionnaire, Student submitter, string assignationIPAddress, QuestionnaireSession questionnaireSession)
        {
            Questionnaire = questionnaire;
            Submitter = submitter;
            AssignationIPAddress = assignationIPAddress;
            Anomalies = new List<SubmissionAnomaly>();
            QuestionnaireSession = questionnaireSession;
        }

        /// <summary>
        /// Deserializes a QuestionnaireSubmission object from a binary formatted file.
        /// </summary>
        /// <param name="path">Binary formatted file path.</param>
        /// <returns></returns>
        public static QuestionnaireSubmission BinaryDeserialize(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = File.Open(path, FileMode.Open);
            object obj = formatter.Deserialize(fs);
            fs.Flush();
            fs.Close();
            fs.Dispose();
            return (QuestionnaireSubmission)obj;
        }

        /// <summary>
        /// Serializes the current QuestionnaireSubmission object to the specified binary formatted file path.
        /// </summary>
        /// <param name="path">The path of the current questionnaire session folder that will contain the serialized file.</param>
        public void BinarySerialize(string path)
        {
            FileStream writeStream = new FileStream(Path.Combine(path, FilesystemFileName), FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(writeStream, this);
            writeStream.Close();
        }

        /// <summary>
        /// Grades the submitted questionnaire and saves the evaluation to database, throws NullReferenceException if the student hasn't already submitted a questionnaire.
        /// </summary>
        public void Grade()
        {
            Evaluation = new Evaluation(DateTime.Now, Questionnaire.Evaluate(), Questionnaire.Topic.ID, Submitter.ID, QuestionnaireSession.ID);
            Evaluation.SaveAsync();
        }
    }
}
