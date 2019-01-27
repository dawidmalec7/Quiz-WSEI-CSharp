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
    public partial class Form2 : Form
    {
        Database leaderboard = new Database();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<Leaderboard> tableOfResults = leaderboard.DisplayLeaderboard();

            for(int i = 0, position = 1; i<tableOfResults.Count; i++, position++)
            {   
                string[] row = { position.ToString(), tableOfResults[i].nick, tableOfResults[i].points };
                var ListViewItem = new ListViewItem(row);
                listView1.Items.Add(ListViewItem);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
