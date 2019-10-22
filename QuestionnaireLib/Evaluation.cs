using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.Common;
using System.IO;

namespace QuestionnaireLib
{
    [Serializable]
    public sealed class Evaluation : IDBEntity
    {
        public Guid ID { get; set; }
        public DateTime TestDate { get; set; }
        public double Grade { get; set; }
        public Guid TopicID { get; set; }
        public Guid StudentID { get; set; }
        public Guid QuestionnaireSessionID { get; set; }

        /// <summary>
        /// Default constructor. (non-existing record)
        /// </summary>
        /// <param name="testdate"></param>
        /// <param name="grade"></param>
        /// <param name="topicID"></param>
        /// <param name="studentID"></param>
        /// <param name="ID"></param>
        public Evaluation(DateTime testdate, double grade, Guid topicID, Guid studentID, Guid questionnaireSessionID)
        {
            TestDate = testdate;
            Grade = grade;
            TopicID = topicID;
            StudentID = studentID;
            QuestionnaireSessionID = questionnaireSessionID;
        }

        /// <summary>
        /// Default constructor. (existing record)
        /// </summary>
        /// <param name="testdate"></param>
        /// <param name="grade"></param>
        /// <param name="topicID"></param>
        /// <param name="studentID"></param>
        /// <param name="ID"></param>
        public Evaluation(DateTime testdate, double grade, Guid topicID, Guid studentID, Guid ID, Guid questionnaireSessionID)
        {
            this.ID = ID;
            TestDate= testdate;
            Grade = grade;
            TopicID = topicID;
            StudentID = studentID;
            QuestionnaireSessionID = questionnaireSessionID;
        }

        /// <summary>
        /// Retrieves the evaluation corresponding to the passed ID.
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public static Evaluation FromID(Guid evaluationID)
        {
            using (OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using (OleDbCommand command = new OleDbCommand())
            {
                conn.Open();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM [Evaluations] WHERE ID=@EvaluationID";
                command.Parameters.AddWithValue("EvaluationID", evaluationID);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    return new Evaluation(reader.GetDateTime(1), reader.GetDouble(2), reader.GetGuid(3), reader.GetGuid(4), reader.GetGuid(5), reader.GetGuid(0));
                }
            }
        }

        /// <summary>
        /// Saves the object if it already exists in the db, or creates it in the db.
        /// </summary>
        public async void SaveAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            if (ID.Equals(new Guid()))
            {
            
                command = new OleDbCommand("INSERT INTO Evaluations(ID, TestDate, Grade, TOPIC_ID, STUDENT_ID, QUESTIONNAIRESESSION_ID) VALUES (@ID, @TestDate, @Grade, @TopicID, @StudentID, @QuestionnaireSessionID)",
                    conn);
                command.Parameters.AddWithValue("ID", ID = Guid.NewGuid());
                command.Parameters.Add(new OleDbParameter("TestDate", OleDbType.Date) { Value = TestDate });
                command.Parameters.AddWithValue("Grade", Grade);
                command.Parameters.AddWithValue("TopicID", TopicID);
                command.Parameters.AddWithValue("StudentID", StudentID);
                command.Parameters.AddWithValue("QuestionnaireSessionID", QuestionnaireSessionID);
                await command.ExecuteNonQueryAsync();
                
                
            }
            else
            {
               command = new OleDbCommand("UPDATE Evaluations SET TestDate=@TestDate, Grade=@Grade WHERE ID = @ID",
                   conn);
               command.Parameters.AddWithValue("TestDate", TestDate);
               command.Parameters.AddWithValue("Grade", Grade);
               command.Parameters.AddWithValue("ID", ID);
               await command.ExecuteNonQueryAsync();
            }
            conn.Close();
        }

        /// <summary>
        /// Delete the object
        /// </summary>
        public async void DeleteAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("DELETE * FROM Evaluations WHERE Evaluations.ID=@ID",
                conn);
            command.Parameters.AddWithValue("ID", ID);
            await command.ExecuteNonQueryAsync();

            conn.Close();
        }

        /// <summary>
        /// Get all Evaluations
        /// </summary>
        /// <returns></returns>
        public async static Task<List<Evaluation>> GetAllAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            List<Evaluation> evaluations = new List<Evaluation>();

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT * FROM Evaluations",
                conn);
            reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                evaluations.Add(new Evaluation(reader.GetDateTime(1), reader.GetDouble(2), reader.GetGuid(3), reader.GetGuid(4), reader.GetGuid(0), reader.GetGuid(5)));
            }

            reader.Close();
            conn.Close();
            return evaluations;
        }

        /// <summary>
        /// Retrives the student associated with this evaluation.
        /// </summary>
        /// <returns></returns>
        public async Task<Student> GetStudentAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            Guid id = this.ID;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT Students.*, Users.FirstName, Users.SecondName, Users.BirthDate, Users.Password FROM ((Students INNER JOIN Users ON Students.USER_ID=Users.ID) INNER JOIN Evaluations ON Evaluations.STUDENT_ID=Students.ID) WHERE Evaluations.ID = @ID",
                conn);
            command.Parameters.AddWithValue("ID", id);
            DbDataReader reader = await command.ExecuteReaderAsync();

            if (reader.Read())
            {
                BasicUserProperties properties;
                Student student;

                properties = new BasicUserProperties();
                properties.FirstName = reader.GetString(3);
                properties.SecondName = reader.GetString(4);
                properties.BirthDate = reader.GetDateTime(5);
                student = new Student(properties, reader.GetGuid(1), reader.GetGuid(2), reader.GetGuid(0));

                reader.Close();
                conn.Close();
                return student;
            }
            else
            {
                throw new Exception("Query result not correct");
            }
        }

        /// <summary>
        /// Retrives the topic associated with this evaluation.
        /// </summary>
        /// <returns></returns>
        public async Task<Topic> GetTopicAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            Guid id = this.ID;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();
           
            command = new OleDbCommand("SELECT Topics.* FROM Topics INNER JOIN Evaluations ON Evaluations.TOPIC_ID=Topics.ID WHERE Evaluations.ID = @ID",
                conn);
            command.Parameters.AddWithValue("ID", id);
            reader = await command.ExecuteReaderAsync();

            if (reader.Read())
            {
                Topic topic = new Topic(reader.GetString(1), reader.GetGuid(2), reader.GetGuid(0));
                reader.Close();
                return topic;
            }
            else
            {
                throw new Exception("Query result not correct");
            }
        }
    }
}
