using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.Common;

namespace QuestionnaireLib
{
    [Serializable]
    public sealed class Question : IDBEntity
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        public Guid TopicID { get; set; }
        public Answer SelectedAnswer { get; set; }
        public List<Answer> Answers { get; set; }

        /// <summary>
        /// Empty constructor, required for serialization.
        /// </summary>
        public Question()
        {
            Description = "";
            TopicID = new Guid();
            SelectedAnswer = null;
            this.Answers = new List<Answer>();
        }

        /// <summary>
        /// Non existing-record
        /// </summary>
        /// <param name="description"></param>
        /// <param name="topicID"></param>
        /// <param name="answers"></param>
        public Question(string description, Guid topicID, List<Answer> answers)
        {
            Description = description;
            TopicID = topicID;
            SelectedAnswer = null;
            this.Answers = answers;
        }

        /// <summary>
        /// Existing record
        /// </summary>
        /// <param name="description"></param>
        /// <param name="topicID"></param>
        /// <param name="answers"></param>
        /// <param name="ID"></param>
        public Question(string description, Guid topicID, Guid ID)
        {
            this.ID = ID;
            Description = description;
            TopicID = topicID;
            SelectedAnswer = null;
            this.Answers = GetAnswers();
        }

        /// <summary>
        /// Retrieves the question corresponding to the passed ID.
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public static Question FromID(Guid questionID)
        {            
            using (OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using (OleDbCommand command = new OleDbCommand())
            {
                conn.Open();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM [Questions] WHERE ID=@QuestionID";
                command.Parameters.AddWithValue("QuestionID", questionID);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    return new Question(reader.GetString(1), reader.GetGuid(2), reader.GetGuid(0));
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
                command = new OleDbCommand("INSERT INTO Questions(ID, Description, TOPIC_ID) VALUES (@ID, @Description, @TopicID)",
                    conn);
                command.Parameters.AddWithValue("ID", ID = Guid.NewGuid());
                command.Parameters.AddWithValue("Description", Description);
                command.Parameters.AddWithValue("TopicID", TopicID);
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                command = new OleDbCommand("UPDATE Questions SET Description=@Description WHERE ID = @ID",
                    conn);
                command.Parameters.AddWithValue("Description", Description);
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

            command = new OleDbCommand("DELETE * FROM Questions WHERE Questions.ID=@ID",
                conn);
            command.Parameters.AddWithValue("ID", ID);
            await command.ExecuteNonQueryAsync();

            conn.Close();
        }

        /// <summary>
        /// Get all Questions
        /// </summary>
        /// <returns></returns>
        public async static Task<List<Question>> GetAllAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            List<Question> questions = new List<Question>();

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT * FROM Questions",
                conn);
            reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                questions.Add(new Question(reader.GetString(1),reader.GetGuid(2), reader.GetGuid(0)));
            }

            reader.Close();
            conn.Close();
            return questions;
        }

        /// <summary>
        /// Can be used to get correct and/or wrong answers of this question.
        /// </summary>
        /// <returns>The list of queried answers.</returns>
        public async Task<List<Answer>> GetAnswersAsync(bool includeCorrect = true, bool includeFalse = true)
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            List<Answer> answers = new List<Answer>();
            Guid id = this.ID;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT Answers.* FROM Answers INNER JOIN Questions ON Answers.QUESTION_ID=Questions.ID WHERE Questions.ID = @ID " + ((includeCorrect && includeFalse) ? "" : (includeCorrect) ? "AND Answers.Correct = -1" : "AND Answers.Correct = 0"),
             conn);

            command.Parameters.AddWithValue("ID", id);
            reader = await command.ExecuteReaderAsync();

            while (reader.Read())
            {
                answers.Add(new Answer(reader.GetString(1), reader.GetBoolean(2), reader.GetGuid(3), reader.GetGuid(0)));
            }

            reader.Close();
            conn.Close();
            return answers;
        }

        /// <summary>
        /// Can be used to get correct and/or wrong answers of this question.
        /// </summary>
        /// <returns>The list of queried answers.</returns>
        public List<Answer> GetAnswers(bool includeCorrect = true, bool includeFalse = true)
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            List<Answer> answers = new List<Answer>();
            Guid id = this.ID;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT Answers.* FROM Answers INNER JOIN Questions ON Answers.QUESTION_ID=Questions.ID WHERE Questions.ID = @ID " + ((includeCorrect && includeFalse) ? "" : (includeCorrect) ? "AND Answers.Correct = -1" : "AND Answers.Correct = 0"),
             conn);

            command.Parameters.AddWithValue("ID", id);
            reader =  command.ExecuteReader();

            while (reader.Read())
            {
                answers.Add(new Answer(reader.GetString(1), reader.GetBoolean(2), reader.GetGuid(3), reader.GetGuid(0)));
            }

            reader.Close();
            conn.Close();
            return answers;
        }

        /// <summary>
        /// Retrives the topic associated with this answer.
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

            command = new OleDbCommand("SELECT Topics.* FROM Questions INNER JOIN Topics ON Questions.TOPIC_ID=Topics.ID WHERE Questions.ID = @ID",
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
