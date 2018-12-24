using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{

    //ZMIENNA DO SPRAWDZENIA CZY UZYTKOWNIK PODAL JUZ IMIE // ?
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        string[,] tab = new string[1, 6];
        string Name = "";

        public Form1()
        {
            InitializeComponent();
            tab[0, 0] = "Jaki to typ danych: uint?";
            tab[0, 1] = "1.dodatne liczby";
            tab[0, 2] = "2.liczby zmienno-przecinkowe";
            tab[0, 3] = "3.liczby dodatnie i ujemne";
            tab[0, 4] = "4.liczby ujemne";
            tab[0, 5] = "1";
     
        }

        private void Button_Start_Game_Click(object sender, EventArgs e)
        {
            GroupBox_Question.Show();
            Graj(tab, rnd);

        }

        private void Button_Questions_Click(object sender, EventArgs e)
        {

        }

        private void Button_Ranking_Click(object sender, EventArgs e)
        {

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
            Button_Questions.Enabled = true;
            Button_Quit.Enabled = true;
        }

        public void Graj(string[,] tab, Random rnd)
        {
            int counterQuestions = 1;
            GroupBox_Question.Text = "Pytanie " + counterQuestions + ":";
            //POBRAC PYTANIA Z BAZY I JE WYSWIETLIC W PETLI
            Label_Question.Text = tab[0, 0];
            Button_Question1.Text = tab[0, 1];
            Button_Question1.Tag = tab[0, 5];
            Button_Question2.Text = tab[0, 2];
            Button_Question3.Text = tab[0, 3];
            Button_Question4.Text = tab[0, 4];

        }

        private void Button_Question1_Click(object sender, EventArgs e)
        {
            if(Button_Question1.Tag.ToString() == "1")
            {
                MessageBox.Show("NICE!");
            }
        }

        private void Button_Question2_Click(object sender, EventArgs e)
        {

        }
    }
}
