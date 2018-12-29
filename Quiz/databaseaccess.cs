﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;


namespace DatabaseConnectionAPI
{
    //klasa do przechowywania odpowiedzi wraz z informacją o ich poprawności
    public class Answers
    {
        public string correct { get; set; }
        public string answer { get; set; }

    }
    public class Database
    {
        public SQLiteConnection quizDbConnection;
        //konstruktor łączy się z bazą
        public Database()
        {
            quizDbConnection = new SQLiteConnection(string.Format("Data Source={0}", Path.Combine(Application.StartupPath, "quiz_db.sqlite3")));

        }
        //otwiera połączeniez bazą
        private void OpenConnection()
        {
            if (quizDbConnection.State != System.Data.ConnectionState.Open)
                quizDbConnection.Open();
        }

        //zamyka połączenie z bazą
        private void CloseConnection()
        {
            if (quizDbConnection.State != System.Data.ConnectionState.Closed)
                quizDbConnection.Close();
        }

        //pobiera losową wartość ID pytania
        public int GetRandomQuestion()
        {
            OpenConnection();
            string countQuestions = "SELECT count(question) as number FROM Questions";
            SQLiteCommand executeCount = new SQLiteCommand(countQuestions, quizDbConnection);
            var max_value = executeCount.ExecuteScalar();
            Random r = new Random();
            int numberOfQuestion = r.Next(1, Convert.ToInt32(max_value));
            CloseConnection();
            return numberOfQuestion;
        }

        //pobiera losowe pytanie z bazy, jako parametr podać GetMaxNumberOfQuestions()
        // var question = GetQuestion(GetMaxNumberOfQuestion());
        // zwraca tablice w której 1 elementem jest treść pytania a 2 jego id
        public string[] GetQuestion(int ID)
        {
            OpenConnection();
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
            CloseConnection();
            return tab;
        }

        //zwraca odpowiedzi na pytania
        public List<Answers> GetAnswers(string question_ID)
        {
            Convert.ToUInt16(question_ID);
            OpenConnection();
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
            CloseConnection();
            return answers_list;
        }

        //wyswietla tablice 10 najlepszych wyników 
        public void DisplayLeaderboard()
        {
            OpenConnection();
            string selectLeaderboard = "select * from Leaderboard ORDER BY Leaderboard.highscore DESC limit 10";
            SQLiteCommand executeLeaderboard = new SQLiteCommand(selectLeaderboard, quizDbConnection);
            SQLiteDataReader leaderboard = executeLeaderboard.ExecuteReader();

            while (leaderboard.Read())
                Console.WriteLine("#{0}. {1} -- {2}", leaderboard["ID"], leaderboard["nick"], leaderboard["highscore"]);
            CloseConnection();
        }


        //dodaje do tabeli wyników
        public void AddToLeaderboard(string nick, int score)
        {
            OpenConnection();
            string insertToLeaderboard = String.Format("insert into Leaderboard (`nick`, `highscore`) VALUES ('{0}', '{1}')", nick, score);
            SQLiteCommand addToLeaderboard = new SQLiteCommand(insertToLeaderboard, quizDbConnection);
            try
            {
                addToLeaderboard.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            CloseConnection();
        }
    }


}