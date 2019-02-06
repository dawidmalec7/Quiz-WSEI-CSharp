using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DatabaseConnectionAPI;


namespace QuizGameAPI
{
    /// <summary>
    /// Klasa zawierająca logikę gry
    /// </summary>
    public class QuizGame
    {
        private string Name;
        private int score = 0;
        private int counterQuestions = 1;
        private Database quizDatabase = new Database();
        /// <summary>
        /// Zwraca nazwęgracza
        /// </summary>
        /// <returns>string</returns>
        public string getName()
        {
            return Name;
        }
        /// <summary>
        /// pobiera nazwę gracza
        /// </summary>
        /// <param name="Name"></param>
        public void setName(string Name)
        {
            this.Name = Name;
        }
        /// <summary>
        /// Pobiera z bazy pytanie, jeśli metoda wyświetlila 5 pytań wywołuje metodę kończącą grę
        /// </summary>
        /// <param name="AllQuestion"></param>
        /// <param name="Question"></param>
        /// <param name="AnswerButtons"></param>
        public void Play(GroupBox AllQuestion, Label Question, List<Button> AnswerButtons)
        {
            quizDatabase.OpenConnection();
            string[] question = quizDatabase.GetQuestion(quizDatabase.GetRandomQuestion());
            List<Answers> answers = quizDatabase.GetAnswers(question[1]);

            AllQuestion.Text = "Pytanie " + counterQuestions + ":";
            Question.Text = question[0];
            setAnswers(answers, AnswerButtons);

            if (counterQuestions == 6)
            {

                KoniecGry(AllQuestion);
            }
        }
        /// <summary>
        /// Przypisuje pytaia do odpowiednich elementów formularza
        /// </summary>
        /// <param name="answers"></param>
        /// <param name="AnswerButtons"></param>
        private void setAnswers(List<Answers> answers, List<Button> AnswerButtons)
        {
            for (int i = 0; i < 4; i++)
            {
                AnswerButtons[i].Text = answers[i].answer;
                AnswerButtons[i].Tag = answers[i].correct;
            }

        }
        /// <summary>
        /// Kończy grę i dodaje wynik do bazy danych
        /// </summary>
        /// <param name="Question"></param>
        private void KoniecGry(GroupBox Question)
        {
            Question.Hide();
            MessageBox.Show($"{Name} zdobyłeś {score} punktów", "Koniec Gry", MessageBoxButtons.OK);
            quizDatabase.AddToLeaderboard(this.Name, this.score.ToString());
            counterQuestions = 1;
        }
        /// <summary>
        /// sprawdza czy odpowiedz jest poprawna oraz przypisuje punkty lub nie
        /// </summary>
        /// <param name="value"></param>
        /// <param name="AllQuestion"></param>
        /// <param name="Question"></param>
        /// <param name="AnswerButtons"></param>
        public void CheckAnswer(object value, GroupBox AllQuestion, Label Question, List<Button> AnswerButtons)
        {
            if (Convert.ToString(value) == "1")
            {
                MessageBox.Show("+100 punktów", "Poprawna odpowiedz", MessageBoxButtons.OK);
                score += 100;
            }
            else
            {
                MessageBox.Show("tym razem nie dostaniesz punktów", "Błędna odpowiedź", MessageBoxButtons.OK);
            }
            ++counterQuestions;
            Play(AllQuestion, Question, AnswerButtons);
        }
    }
}