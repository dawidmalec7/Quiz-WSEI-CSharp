using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseConnectionAPI;

namespace Quiz
{
    class Quiz
    {
        private string Name;
        private int score = 0;
        private int counterQuestions = 1;
        private Database quizDatabase = new Database();

        public string getName()
        {
            return Name;
        }
        public void setName(string Name)
        {
            this.Name = Name;
        }

        public void Play(GroupBox AllQuestion, Label Question, List<Button> AnswerButtons)
        {
            string[] question = quizDatabase.GetQuestion(quizDatabase.GetRandomQuestion());
            List<Answers> answers = quizDatabase.GetAnswers(question[1]);

            AllQuestion.Text = "Pytanie " + counterQuestions + ":";
            Question.Text = question[0];
            setAnswers(answers, AnswerButtons);

            if (counterQuestions == 6)
                KoniecGry(AllQuestion);
        }

        private void setAnswers(List<Answers> answers, List<Button> AnswerButtons)
        {
            for (int i = 0; i < 4; i++)
            {
                AnswerButtons[i].Text = answers[i].answer;
                AnswerButtons[i].Tag = answers[i].correct;
            }

        }
   
        private void KoniecGry(GroupBox Question)
        {
            Question.Hide();
            MessageBox.Show($"{Name} zdobyłeś {score} punktów", "Koniec Gry", MessageBoxButtons.OK);
            quizDatabase.AddToLeaderboard(Name, Convert.ToString(score));
            counterQuestions = 1;
        }

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
