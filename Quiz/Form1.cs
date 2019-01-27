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
        private List<Button> AnswerButtons = new List<Button>();
        private Quiz QuizGame = new Quiz();
        Form2 secondForm = new Form2(); // RANKING
        

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
            QuizGame.Play(GroupBox_Question, Label_Question, AnswerButtons);

        }


        private void Button_Ranking_Click(object sender, EventArgs e)
        {
            secondForm.ShowDialog();
            if (secondForm.IsDisposed)
                secondForm.Dispose();
        }

        private void Button_Quit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            QuizGame.setName(textBox1.Text);
            MessageBox.Show("Witaj " + QuizGame.getName() + "!");
            //WYSYŁANIE DO BAZY IMIENIA
            GroupBox_Name.Hide();
            Button_Start_Game.Enabled = true;
            Button_Ranking.Enabled = true;
            Button_Quit.Enabled = true;
        }

    
        private void Button_Question_Click(object sender, EventArgs e)
        {
            QuizGame.CheckAnswer((sender as Button).Tag, GroupBox_Question, Label_Question, AnswerButtons);
        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
        }
    }
}
