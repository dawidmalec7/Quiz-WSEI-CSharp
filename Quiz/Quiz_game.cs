using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseConnectionAPI;


namespace QuizGameAPI
{
    /// <summary>
    /// klasa zawierająca logikę gry
    /// </summary>
    public class QuizGame
    {
        private string Name;
        private int score = 0;
        private int counterQuestions = 1;
        private Database quizDatabase = new Database();
        /// <summary>
        /// pobiera nazwe gracza
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return Name;
        }
        /// <summary>
        /// zapisuje nazwe gracza
        /// </summary>
        /// <param name="Name"></param>
        public void setName(string Name)
        {
            this.Name = Name;
        }
        /// <summary>
        /// 
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
        /// pobiera odpowiedzi i przypisuje je do przycisków
        /// </summary>
        /// <param name="answers">lista z odpowiedziami na pytanie</param>
        /// <param name="AnswerButtons">lista z przyciskami do których zostaną przypisane odpowiedzi</param>
        private void setAnswers(List<Answers> answers, List<Button> AnswerButtons)
        {
            for (int i = 0; i < 4; i++)
            {
                AnswerButtons[i].Text = answers[i].answer;
                AnswerButtons[i].Tag = answers[i].correct;
            }

        }
        /// <summary>
        /// kończy grę i wyświetla komunikat z sumą zdobytych punktów
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
        /// Sprawdza czy wybrana odpowiedź jest poprawna i wyświetla komunikat o jej poprawności
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