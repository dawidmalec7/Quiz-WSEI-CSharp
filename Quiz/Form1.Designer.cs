namespace Quiz
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Button_Start_Game = new System.Windows.Forms.Button();
            this.Button_Ranking = new System.Windows.Forms.Button();
            this.Button_Quit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupBox_Question = new System.Windows.Forms.GroupBox();
            this.Button_Question4 = new System.Windows.Forms.Button();
            this.Button_Question3 = new System.Windows.Forms.Button();
            this.Button_Question2 = new System.Windows.Forms.Button();
            this.Button_Question1 = new System.Windows.Forms.Button();
            this.Label_Question = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.GroupBox_Name = new System.Windows.Forms.GroupBox();
            this.GroupBox_Question.SuspendLayout();
            this.GroupBox_Name.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_Start_Game
            // 
            this.Button_Start_Game.Enabled = false;
            this.Button_Start_Game.Location = new System.Drawing.Point(60, 49);
            this.Button_Start_Game.Name = "Button_Start_Game";
            this.Button_Start_Game.Size = new System.Drawing.Size(425, 50);
            this.Button_Start_Game.TabIndex = 0;
            this.Button_Start_Game.Text = "Zacznij grę!";
            this.Button_Start_Game.UseVisualStyleBackColor = true;
            this.Button_Start_Game.Click += new System.EventHandler(this.Button_Start_Game_Click);
            // 
            // Button_Ranking
            // 
            this.Button_Ranking.Enabled = false;
            this.Button_Ranking.Location = new System.Drawing.Point(60, 139);
            this.Button_Ranking.Name = "Button_Ranking";
            this.Button_Ranking.Size = new System.Drawing.Size(425, 53);
            this.Button_Ranking.TabIndex = 2;
            this.Button_Ranking.Text = "Ranking";
            this.Button_Ranking.UseVisualStyleBackColor = true;
            this.Button_Ranking.Click += new System.EventHandler(this.Button_Ranking_Click);
            // 
            // Button_Quit
            // 
            this.Button_Quit.Enabled = false;
            this.Button_Quit.Location = new System.Drawing.Point(60, 233);
            this.Button_Quit.Name = "Button_Quit";
            this.Button_Quit.Size = new System.Drawing.Size(425, 50);
            this.Button_Quit.TabIndex = 3;
            this.Button_Quit.Text = "Wyjdź z gry";
            this.Button_Quit.UseVisualStyleBackColor = true;
            this.Button_Quit.Click += new System.EventHandler(this.Button_Quit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "SUPER EXTRA QUIZ";
            // 
            // GroupBox_Question
            // 
            this.GroupBox_Question.Controls.Add(this.Button_Question4);
            this.GroupBox_Question.Controls.Add(this.Button_Question3);
            this.GroupBox_Question.Controls.Add(this.Button_Question2);
            this.GroupBox_Question.Controls.Add(this.Button_Question1);
            this.GroupBox_Question.Controls.Add(this.Label_Question);
            this.GroupBox_Question.Location = new System.Drawing.Point(12, 12);
            this.GroupBox_Question.Name = "GroupBox_Question";
            this.GroupBox_Question.Size = new System.Drawing.Size(519, 324);
            this.GroupBox_Question.TabIndex = 6;
            this.GroupBox_Question.TabStop = false;
            this.GroupBox_Question.Text = "Pytanie";
            this.GroupBox_Question.Visible = false;
            // 
            // Button_Question4
            // 
            this.Button_Question4.Location = new System.Drawing.Point(305, 207);
            this.Button_Question4.Name = "Button_Question4";
            this.Button_Question4.Size = new System.Drawing.Size(168, 47);
            this.Button_Question4.TabIndex = 4;
            this.Button_Question4.Text = "button1";
            this.Button_Question4.UseVisualStyleBackColor = true;
            this.Button_Question4.Click += new System.EventHandler(this.Button_Question_Click);
            // 
            // Button_Question3
            // 
            this.Button_Question3.Location = new System.Drawing.Point(25, 207);
            this.Button_Question3.Name = "Button_Question3";
            this.Button_Question3.Size = new System.Drawing.Size(168, 47);
            this.Button_Question3.TabIndex = 3;
            this.Button_Question3.Text = "button1";
            this.Button_Question3.UseVisualStyleBackColor = true;
            this.Button_Question3.Click += new System.EventHandler(this.Button_Question_Click);
            // 
            // Button_Question2
            // 
            this.Button_Question2.Location = new System.Drawing.Point(305, 74);
            this.Button_Question2.Name = "Button_Question2";
            this.Button_Question2.Size = new System.Drawing.Size(168, 47);
            this.Button_Question2.TabIndex = 2;
            this.Button_Question2.Text = "button1";
            this.Button_Question2.UseVisualStyleBackColor = true;
            this.Button_Question2.Click += new System.EventHandler(this.Button_Question_Click);
            // 
            // Button_Question1
            // 
            this.Button_Question1.Location = new System.Drawing.Point(25, 74);
            this.Button_Question1.Name = "Button_Question1";
            this.Button_Question1.Size = new System.Drawing.Size(168, 47);
            this.Button_Question1.TabIndex = 1;
            this.Button_Question1.Text = "button1";
            this.Button_Question1.UseVisualStyleBackColor = true;
            this.Button_Question1.Click += new System.EventHandler(this.Button_Question_Click);
            // 
            // Label_Question
            // 
            this.Label_Question.AutoSize = true;
            this.Label_Question.Location = new System.Drawing.Point(48, 37);
            this.Label_Question.Name = "Label_Question";
            this.Label_Question.Size = new System.Drawing.Size(0, 13);
            this.Label_Question.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Imię:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(41, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(226, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(192, 61);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "Zapisz!";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // GroupBox_Name
            // 
            this.GroupBox_Name.Controls.Add(this.button5);
            this.GroupBox_Name.Controls.Add(this.textBox1);
            this.GroupBox_Name.Controls.Add(this.label1);
            this.GroupBox_Name.Location = new System.Drawing.Point(106, 124);
            this.GroupBox_Name.Name = "GroupBox_Name";
            this.GroupBox_Name.Size = new System.Drawing.Size(287, 103);
            this.GroupBox_Name.TabIndex = 4;
            this.GroupBox_Name.TabStop = false;
            this.GroupBox_Name.Text = "Podaj imię";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 348);
            this.Controls.Add(this.GroupBox_Question);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GroupBox_Name);
            this.Controls.Add(this.Button_Quit);
            this.Controls.Add(this.Button_Ranking);
            this.Controls.Add(this.Button_Start_Game);
            this.Name = "Form1";
            this.Text = "Form1";
            this.GroupBox_Question.ResumeLayout(false);
            this.GroupBox_Question.PerformLayout();
            this.GroupBox_Name.ResumeLayout(false);
            this.GroupBox_Name.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Start_Game;
        private System.Windows.Forms.Button Button_Ranking;
        private System.Windows.Forms.Button Button_Quit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GroupBox_Question;
        private System.Windows.Forms.Label Label_Question;
        private System.Windows.Forms.Button Button_Question4;
        private System.Windows.Forms.Button Button_Question3;
        private System.Windows.Forms.Button Button_Question2;
        private System.Windows.Forms.Button Button_Question1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox GroupBox_Name;
    }
}

