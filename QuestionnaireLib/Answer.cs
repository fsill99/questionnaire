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
    public sealed class Answer : IDBEntity
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        public bool Correct { get; set; }
        public Guid QuestionID { get; set; }

        /// <summary>
        /// Empty constructor, required for serialization.
        /// </summary>
        private Answer()
        { }

        /// <summary>
        /// Default constructor. (non-existing record)
        /// </summary>
        /// <param name="description"></param>
        /// <param name="correct"></param>
        /// <param name="questionID"></param>
        /// <param name="ID"></param>
        public Answer(string description, bool correct, Guid questionID)
        {
            this.Description = description;
            this.Correct = correct;
            this.QuestionID = questionID;
        }

        /// <summary>
        /// Default constructor. (existing record)
        /// </summary>
        /// <param name="description"></param>
        /// <param name="correct"></param>
        /// <param name="questionID"></param>
        /// <param name="ID"></param>
        public Answer(string description, bool correct, Guid questionID, Guid ID)
        {
            this.ID = ID;
            this.Description = description;
            this.Correct = correct;
            this.QuestionID = questionID;
        }

        /// <summary>
        /// Retrieves the answer corresponding to the passed ID.
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public static Answer FromID(Guid answerID)
        {
            using (OleDbConnection conn = new OleDbConnection(AppConfiguration.connectionString))
            using (OleDbCommand command = new OleDbCommand())
            {
                conn.Open();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM [Answers] WHERE ID=@AnswerID";
                command.Parameters.AddWithValue("AnswerID", answerID);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    return new Answer(reader.GetString(1), reader.GetBoolean(2), reader.GetGuid(3), reader.GetGuid(0));
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
                //new record, insert it into db and update the ID property of the current object
                command = new OleDbCommand("INSERT INTO Answers (ID, Description, Correct, QUESTION_ID)  VALUES (@ID, @Description, @Correct, @QuestionID)",
                    conn);
                command.Parameters.AddWithValue("ID", ID = Guid.NewGuid());
                command.Parameters.AddWithValue("Description", Description);
                command.Parameters.AddWithValue("Correct", Correct);
                command.Parameters.AddWithValue("QuestionID", QuestionID); 
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                //existing record, update it
                //EXPLAIN: boolean to integer conversion
                //EXPLAIN: unchangeable fields (QUESTION ID)
                command = new OleDbCommand("UPDATE Answers SET Description=@Description, Correct=@Correct WHERE ID = @ID", conn);
                command.Parameters.AddWithValue("Description", Description);
                command.Parameters.AddWithValue("Correct", Correct);
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

            command = new OleDbCommand("DELETE * FROM Answers WHERE Answers.ID=@ID",
                conn);
            command.Parameters.AddWithValue("ID", ID);
            await command.ExecuteNonQueryAsync();

            conn.Close();
        }

        /// <summary>
        /// Get all Answers
        /// </summary>
        /// <returns></returns>
        public async static Task<List<Answer>> GetAllAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;
            List<Answer> answers = new List<Answer>();

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT * FROM Answers", conn);
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
        /// Retrieves the question associated with this answer.
        /// </summary>
        /// <returns></returns>
        public async Task<Question> GetQuestionAsync()
        {
            OleDbConnection conn;
            OleDbCommand command;
            DbDataReader reader;

            conn = new OleDbConnection(AppConfiguration.connectionString);
            conn.Open();

            command = new OleDbCommand("SELECT Questions.* FROM Answers INNER JOIN Questions ON Answers.QUESTION_ID=Questions.ID WHERE Answers.ID=@ID",
                conn);
            command.Parameters.AddWithValue("ID", ID);
            reader = await command.ExecuteReaderAsync();

            if (reader.Read())
            {
                Question question = new Question(reader.GetString(1), reader.GetGuid(2), reader.GetGuid(0));
                reader.Close();
                return question;
            }
            else
            {
                throw new Exception("Query result not correct");
            }
        }
    }
}
