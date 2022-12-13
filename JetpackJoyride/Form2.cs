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
using JetpackJoyride.Properties;
using System.Runtime.InteropServices;
using System.Drawing.Text;

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
        PrivateFontCollection pfc = new PrivateFontCollection();
        string date = "";
        string ScorePath = "J:\\Computer Science Testing\\Silvera_JetpackJoyride\\JetpackJoyrideScores.csv";
        string HomeScorePath = "C:\\Users\\Silve\\OneDrive\\Documents\\JetpackJoyrideScores.csv";
        private void Form2_Load(object sender, EventArgs e)
        {
            CustomFont();
            MessageBox.Show("The leaderboard updates every 5 seconds, so your score may not show up immediately.");         
            username.Clear();
            scores.Clear();
            time.Clear();
            ReadCSV();
            Highscores();
            InitializeDataGridView();
            DateTime now = DateTime.Now;
            date = now.ToString();
        }
        private void CustomFont()
        {
            int fontLength = Resources.New_Athletic_M54.Length;
            byte[] fontdata = Resources.New_Athletic_M54;
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
        }
        private void InitializeDataGridView()
        {
            dgvLeaderboard.Visible = true;
            // Initialize basic DataGridView properties.
            dgvLeaderboard.Dock = DockStyle.Fill;
            dgvLeaderboard.BackgroundColor = Color.LightGray;
            dgvLeaderboard.BorderStyle = BorderStyle.Fixed3D;
            

            // Set property values appropriate for read-only display and 
            // limited interactivity. 
            dgvLeaderboard.AllowUserToAddRows = false;
            dgvLeaderboard.AllowUserToDeleteRows = false;
            dgvLeaderboard.AllowUserToOrderColumns = false;
            dgvLeaderboard.ReadOnly = true;
            dgvLeaderboard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLeaderboard.MultiSelect = false;
            dgvLeaderboard.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvLeaderboard.AllowUserToResizeColumns = false;
            dgvLeaderboard.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLeaderboard.AllowUserToResizeRows = false;
            dgvLeaderboard.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvLeaderboard.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Set the selection background color for all the cells.
            dgvLeaderboard.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvLeaderboard.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
            // value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
            dgvLeaderboard.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;

            // Set the background color for all rows and for alternating rows. 
            // The value for alternating rows overrides the value for all rows. 
            dgvLeaderboard.RowsDefaultCellStyle.BackColor = Color.FromArgb(255, 150, 150);
            dgvLeaderboard.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 72, 72);


            // Set the row and column header styles.
            dgvLeaderboard.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLeaderboard.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dgvLeaderboard.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            

            // Attach a handler to the CellFormatting event.
            //dgvLeaderboard.CellFormatting += new(;
            //DataGridViewCellFormattingEventHandler(dgvLeaderboard_CellFormatting);
        }
        private void ReadCSV()
        {
            try
            {
                string[] Leaderboard = File.ReadAllLines(ScorePath);
                for (int i = 0; i < Leaderboard.Length; i++)
                {
                    string[] rowdata = Leaderboard[i].Split(',');
                    username.Add(rowdata[0]);
                    if (username[0] == "")
                    {
                        username.Clear();
                        File.WriteAllText(ScorePath, string.Empty);
                        break;
                    }
                    else if (username[0] != "")
                    {
                        scores.Add(Int32.Parse(rowdata[1]));
                        time.Add(rowdata[2]);
                    }
                }
            }
            catch
            {
                MessageBox.Show("The file containing all scores cannot be accessed.", "File Inaccessible", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Highscores()
        {
            dgvLeaderboard.Rows.Clear();
            for(int i = 0; i < username.Count; i++)
            {
                dgvLeaderboard.Rows.Add((i+1).ToString(), username[i], $"{scores[i]} m", time[i]);
            }           
        }

        private void tmrUpdateScores_Tick(object sender, EventArgs e)
        {
            username.Clear();
            scores.Clear();
            time.Clear();
            ReadCSV();
            Highscores();
        }
    }
}
