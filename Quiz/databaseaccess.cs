using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;


namespace DatabaseConnectionAPI
{
    ///<summary>
    ///klasa do przechowywania odpowiedzi wraz z informacją o ich poprawności
    ///</summary>
    public class Answers
    {
        public string correct { get; set; }
        public string answer { get; set; }

    }
    /// <summary>
    /// klasa do przechowywania tablicy wyników
    /// </summary>

    public class Leaderboard
    {
        public string ID { get; set; }
        public string nick { get; set; }
        public string points { get; set; }
    }
    public class Database
    {
        public SQLiteConnection quizDbConnection;
        /// <summary>
        /// konstruktor łączy się z bazą
        /// </summary>

        public Database()
        { 
            quizDbConnection = new SQLiteConnection(string.Format("Data Source={0}", Path.Combine(Application.StartupPath, "quiz_db.sqlite3")));
            quizDbConnection.Open();
        }
        /// <summary>
        /// otwiera połączeniez bazą
        /// </summary>

        public void OpenConnection()
        {
            if (quizDbConnection.State != System.Data.ConnectionState.Open)
                quizDbConnection.Open();
        }
        /// <summary>
        /// zamyka połączenie z bazą
        /// </summary>

        public void CloseConnection()
        {
            if (quizDbConnection.State != System.Data.ConnectionState.Closed)
                quizDbConnection.Close();
        }
        /// <summary>
        /// pobiera losową wartość ID pytania
        /// </summary>
        /// <returns></returns>

        public int GetRandomQuestion()
        {
            string countQuestions = "SELECT count(question) as number FROM Questions";
            SQLiteCommand executeCount = new SQLiteCommand(countQuestions, quizDbConnection);
            var max_value = executeCount.ExecuteScalar();
            Random r = new Random();
            int numberOfQuestion = r.Next(1, Convert.ToInt32(max_value));
            return numberOfQuestion;
        }
        /// <summary>
        /// pobiera losowe pytanie z bazy, jako parametr podać GetMaxNumberOfQuestions()
        /// zwraca tablice w której 1 elementem jest treść pytania a 2 jego id
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>string[]</returns>

        public string[] GetQuestion(int ID)
        {
            string selectQuestion = String.Format("select Questions.question, ID from Questions where ID ={0} ", ID);
            SQLiteCommand executeQuestion = new SQLiteCommand(selectQuestion, quizDbConnection);
            var question = executeQuestion.ExecuteReader();
            while (question.Read())
            {
                break;
            }
            string[] tab = new string[2];
            tab[0] = Convert.ToString(question["question"]);
            tab[1] = Convert.ToString(question["ID"]);
            return tab;
        }
        /// <summary>
        /// zwraca odpowiedzi na pytania
        /// </summary>
        /// <param name="question_ID"></param>
        /// <returns>List</returns>
        public List<Answers> GetAnswers(string question_ID)
        {
            Convert.ToUInt16(question_ID);
            string selectAnswer = String.Format("select Answers.answer, Answers.correct from Answers where question_ID ={0} ", question_ID);
            SQLiteCommand executeAnswer = new SQLiteCommand(selectAnswer, quizDbConnection);
            SQLiteDataReader answers = executeAnswer.ExecuteReader();
            var answers_list = new List<Answers>();
            while (answers.Read())
            {
                var answer = new Answers
                {
                    answer = Convert.ToString(answers["answer"]),
                    correct = Convert.ToString(answers["correct"])
                };
                answers_list.Add(answer);
            }
            return answers_list;
        }
        /// <summary>
        /// wyswietla tablice 10 najlepszych wyników 
        /// </summary>
        /// <returns>List</returns>
        public List<Leaderboard> DisplayLeaderboard()
        {
            string selectLeaderboard = "select * from Leaderboard where Leaderboard.highscore >100 ORDER BY Leaderboard.highscore DESC limit 10";
            SQLiteCommand executeLeaderboard = new SQLiteCommand(selectLeaderboard, quizDbConnection);
            SQLiteDataReader leaderboard = executeLeaderboard.ExecuteReader();
            List<Leaderboard> results = new List<Leaderboard>();
            while (leaderboard.Read())
            {
                Leaderboard table = new Leaderboard
                {
                    ID = Convert.ToString(leaderboard["ID"]),
                    nick = Convert.ToString(leaderboard["nick"]),
                    points = Convert.ToString(leaderboard["highscore"])
                };
                results.Add(table);
            }
            return results;
        }

        /// <summary>
        /// dodaje do tabeli wyników
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="score"></param>
        public void AddToLeaderboard(string nick, string score)
        {
            SQLiteCommand cmd = new SQLiteCommand($"INSERT INTO Leaderboard(nick, highscore) VALUES('{nick}', '{score}')", quizDbConnection);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException sqle)
            {
                MessageBox.Show("Database error: " + sqle.Message);

            }
            catch (Exception e)
            {
                MessageBox.Show("Database error: " + e.Message);
            }
            finally
            {
              CloseConnection();
            }
        }
    }
}
