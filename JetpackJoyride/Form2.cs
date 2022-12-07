using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace JetpackJoyride
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        List<string> username = new List<string>();
        List<int> scores = new List<int>();
        List<string> time = new List<string>();
        string date = "";
        string ScorePath = "J:\\Computer Science Testing\\Silvera_JetpackJoyride\\JetpackJoyrideScores.csv";
        string HomeScorePath = "C:\\Users\\Silve\\OneDrive\\Documents\\JetpackJoyrideScores.csv";
        private void Form2_Load(object sender, EventArgs e)
        {
            ReadCSV();
            Highscores();
            DateTime now = DateTime.Now;
            date = now.ToString();
        }
        private void ReadCSV()
        {
            string[] Leaderboard = File.ReadAllLines(HomeScorePath);
            for (int i = 0; i < Leaderboard.Length; i++)
            {
                string[] rowdata = Leaderboard[i].Split(',');
                username.Add(rowdata[0]);
                scores.Add(Int32.Parse(rowdata[1]));
                time.Add(rowdata[2]);
            }
        }
        private void Highscores()
        {
            dgvLeaderboard.Rows.Clear();
            for(int i = 0; i < username.Count; i++)
            {
                dgvLeaderboard.Rows.Add((i+1).ToString(), username[i], scores[i], time[i]);
            }           
        }
    }
}
