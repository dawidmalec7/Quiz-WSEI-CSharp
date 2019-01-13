using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseConnectionAPI;



namespace Quiz
{

    public partial class Form1 : Form
    {
        Form2 secondForm = new Form2(); // RANKING
        private List<Button> AnswerButtons = new List<Button>(); 

        string[,] tab = new string[1, 6];
        private new string Name = "";
        int score = 0;
        Database quizDatabase = new Database();
        int counterQuestions = 1;

        public Form1()
        {
            InitializeComponent();
            AnswerButtons.Add(Button_Question1);
            AnswerButtons.Add(Button_Question2);
            AnswerButtons.Add(Button_Question3);
            AnswerButtons.Add(Button_Question4);
        }

        private void Button_Start_Game_Click(object sender, EventArgs e)
        {
            GroupBox_Question.Show();
            Graj(counterQuestions);

        }


        private void Button_Ranking_Click(object sender, EventArgs e)
        {
            secondForm.Show();
        }

        private void Button_Quit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Name = textBox1.Text;
            MessageBox.Show("Witaj " + Name + "!");
            //WYSYŁANIE DO BAZY IMIENIA
            GroupBox_Name.Hide();
            Button_Start_Game.Enabled = true;
            Button_Ranking.Enabled = true;
            Button_Quit.Enabled = true;
        }

        public void KoniecGry()
        {
            GroupBox_Question.Hide();
            MessageBox.Show($"{Name} zdobyłeś {score} punktów", "Koniec Gry", MessageBoxButtons.OK);
            quizDatabase.OpenConnection();
            quizDatabase.AddToLeaderboard(Name, Convert.ToString(score));
            quizDatabase.CloseConnection();
            counterQuestions = 1;
        }

        public void Graj(int counterQuestions)
        {
            string[] question = quizDatabase.GetQuestion(quizDatabase.GetRandomQuestion());
            List<Answers> answers = quizDatabase.GetAnswers(question[1]);

            GroupBox_Question.Text = "Pytanie " + counterQuestions + ":";
            Label_Question.Text = question[0];

            for(int i = 0; i < 4; i++)
            {
                AnswerButtons[i].Text = answers[i].answer;
                AnswerButtons[i].Tag = answers[i].correct;
            }
   
            if (counterQuestions == 6)
                KoniecGry();

        }

        public void CheckAnswer(object value)
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
            Graj(++counterQuestions);
        }

        private void Button_Question1_Click(object sender, EventArgs e)
        {
            CheckAnswer(Button_Question1.Tag);
        }

        private void Button_Question2_Click(object sender, EventArgs e)
        {
            CheckAnswer(Button_Question2.Tag);
        }
        private void Button_Question3_Click(object sender, EventArgs e)
        {
            CheckAnswer(Button_Question3.Tag);
        }

        private void Button_Question4_Click(object sender, EventArgs e)
        {
            CheckAnswer(Button_Question4.Tag);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
