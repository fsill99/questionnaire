using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SqlClient;

namespace QuestionnaireLib
{
    [Serializable]
    public sealed class Topic : IDBEntity
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        public Guid TeacherID { get; set; }

        /// <summary>
        /// Empty constructor, required for serialization.
        /// </summary>
        private Topic()
        { }

        /// <summary>
        /// Default constructor. (non-existing record)
        /// </summary>
        /// <param name="description"></param>
        /// <param name="teacherID"></param>
        public Topic(string description, Guid teacherID)
        {
            Description = description;
            TeacherID = teacherID;
        }

        /// <summary>
        /// Default constructor. (existing record)
        /// </summary>
        /// <param name="description"></param>
        /// <param name="teacherID"></param>
        /// <param name="ID"></param>
        public Topic(string description, Guid teacherID, Guid ID)
        {
            Description = description;
            TeacherID = teacherID;
            this.ID = ID;
        }

        /// <summary>
        /// Retrieves the topic corresponding to the passed ID.
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public static Topic FromID(Guid topicID)
        {
            using (OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using (OleDbCommand command = new OleDbCommand())
            {
                conn.Open();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM [Topics] WHERE ID=@TopicID";
                command.Parameters.AddWithValue("TopicID", topicID);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    return new Topic(reader.GetString(1), reader.GetGuid(2), reader.GetGuid(0));
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
                command = new OleDbCommand("INSERT INTO Topics(ID, Description, TEACHER_ID) VALUES(@ID, @Description, @TeacherID)",
                    conn);
                command.Parameters.AddWithValue("ID", Guid.NewGuid());
                command.Parameters.AddWithValue("Description", Description);
                command.Parameters.AddWithValue("TeacherID", TeacherID);
                ID = (Guid)(command.Parameters["ID"].Value);
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                command = new OleDbCommand("UPDATE Topics SET Description=@Description WHERE ID = @ID",
                    conn);
                command.Parameters.AddWithValue("Description", Description);
                command.Parameters.AddWithValue("ID", ID);
                await command.ExecuteNonQueryAsync();
            }
            conn.Close();
        }

        /// <summary>
        /// Get all topics
        /// </summary>
        /// <returns></returns>
        public async static Task<List<Topic>> GetAllAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            List<Topic> topics = new List<Topic>();

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT * FROM Topics",
                conn);
            reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                topics.Add(new Topic(reader.GetString(1), reader.GetGuid(2), reader.GetGuid(0)));
            }

            reader.Close();
            conn.Close();
            return topics;
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

            command = new OleDbCommand("DELETE * FROM Topics WHERE Topics.ID=@ID",
                conn);
            command.Parameters.AddWithValue("ID", ID);
            await command.ExecuteNonQueryAsync();

            conn.Close();
        }

        /// <summary>
        /// Can be used to get a teacher of this topic.
        /// </summary>
        /// <returns></returns>
        public async Task<Teacher> GetTeacherAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            Guid id = this.ID;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT Teachers.*, Users.FirstName, Users.SecondName, Users.BirthDate, Users.Password FROM ((Teachers INNER JOIN Topics ON Topics.TEACHER_ID=Teachers.ID) INNER JOIN Users ON Teachers.USER_ID=Users.ID) WHERE Topics.ID=@ID'",
                conn);
            command.Parameters.AddWithValue("ID", ID);
            reader = await command.ExecuteReaderAsync();

            if (reader.Read())
            {    
                BasicUserProperties properties;
                Teacher teacher;

                properties = new BasicUserProperties();
                properties.FirstName = reader.GetString(2);
                properties.SecondName = reader.GetString(3);
                properties.Password = reader.GetString(4);
                teacher = new Teacher(properties, reader.GetGuid(1), reader.GetGuid(0));

                reader.Close();
                conn.Close();
                return teacher;
            }
            else
            {
                throw new Exception("Query result not correct");
            }
        }

        /// <summary>
        /// Can be used to get a question of this topic.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Question>> GetQuestionsAsync()
        {
            using(OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using(OleDbCommand command = new OleDbCommand())
            {
                conn.Open();
                command.Connection = conn;

                command.CommandText = "SELECT Questions.* FROM Questions INNER JOIN Topics ON Questions.TOPIC_ID=Topics.ID WHERE Topics.ID = @ID";
                command.Parameters.AddWithValue("ID", ID);

                using(DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    List<Question> questions = new List<Question>();
                    while (reader.Read())
                    {
                        questions.Add(new Question(reader.GetString(1), reader.GetGuid(2), reader.GetGuid(0)));
                    }
                    return questions;
                }
            }
        }

        /// <summary>
        /// Can be used to get a evaluation of this topic.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Evaluation>> GetEvaluationsAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            List<Evaluation> evaluation = new List<Evaluation>();
            Guid id = this.ID;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();
            command = new OleDbCommand("SELECT Evaluations.* FROM Evaluations INNER JOIN Topics ON Evaluations.TOPIC_ID=Topics.ID WHERE Topics.ID = @ID",
                conn);
            command.Parameters.AddWithValue("ID", id);
            reader = await command.ExecuteReaderAsync();

            while (reader.Read() == true)
            {
                evaluation.Add(new Evaluation(reader.GetDateTime(1), reader.GetDouble(2), reader.GetGuid(3), reader.GetGuid(4), reader.GetGuid(0)));
            }

            reader.Close();
            conn.Close();
            return evaluation;
        }
    }
}
