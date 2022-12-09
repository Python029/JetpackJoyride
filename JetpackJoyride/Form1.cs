﻿using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace JetpackJoyride
{
    public partial class Form1 : Form
    {
        public Form1()
        {           
            InitializeComponent();
        }
        List<PictureBox> bgList = new List<PictureBox>();
        List<PictureBox> ZapListV = new List<PictureBox>();
        List<PictureBox> ZapListH = new List<PictureBox>();
        List<string> username = new List<string>();
        List<int> scores = new List<int>();
        List<string> time = new List<string>();
        Random rnd = new Random();
        Form2 f2 = new Form2();
        Login lg = new Login();
        AboutBox1 a1 = new AboutBox1();
        #region Booleans
        bool start = false;
        bool go = false;
        bool grav = false;
        bool ground = true;
        bool alive = true;
        bool deadbounce = false;
        bool deadslide=false;
        #endregion
        #region Integers/Doubles
        int bgMove = 4;
        int barryRun = 0;
        int zapperY1 = 0;
        int zapperY2 = 0;
        int zapperY3 = 0;
        int z_animate = 0;
        int barryMove = 4;
        int fly = 8;
        int slowfly = 0;
        int slowfall = 0;
        int bounce = 0;
        int zap_tb = 0;
        int distance = 0;
        int slide = 0;
        #endregion
        #region Strings
        string ScorePath = "J:\\Computer Science Testing\\Silvera_JetpackJoyride\\JetpackJoyrideScores.csv";
        string HomeScorePath = "C:\\Users\\Silve\\OneDrive\\Documents\\JetpackJoyrideScores.csv";
        #endregion
        #region Objects
        PictureBox zap1 = new PictureBox();
        PictureBox zap2 = new PictureBox();
        PictureBox zap3 = new PictureBox();
        PictureBox zap4 = new PictureBox();
        PictureBox zap5 = new PictureBox();
        PictureBox zap6 = new PictureBox();
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            lg.ShowDialog();
            ReadCSV();
            if(username.Count>0)
            {
                InitialHS();
                
            }          
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            bg1.Location = new Point(956, -12);
            bg2.Location = new Point(1460, -12);
            bg3.Location = new Point(1964, -12);
            pbBarry.Location = new Point(-80,pbBarry.Location.Y);
            z_animate = rnd.Next(0, 19);
            ZapperAnimation();
            pbLogo.Parent = bgstart;
            txtStart.Parent = bgstart;
            //pbBarry.Parent = bgstart;
            lblScore.Parent = pbScore;
            lblHighscore.Parent = bgstart;
            pnHigh.Parent = bgstart;
            pnInfo.Parent = bgstart;
            lblScore.ForeColor= Color.White;
            for (int i = 1; i<4;i++)
            {
                PictureBox pb = (PictureBox)this.Controls["bg" + i.ToString()];
                bgList.Add(pb);
            }
            #region Initial Zappers
            #region Zapper 1
            zapperY1 = rnd.Next(88, 338);
            zap1.BackColor = Color.Transparent;
            zap1.Image = Properties.Resources.zapperV1;
            zap1.BackgroundImage=null;
            zap1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(zap1);
            zap1.Location = new Point(1173, zapperY1);
            zap1.BringToFront();
            //zap1.Parent = bg1;
            ZapListV.Add(zap1);
            #endregion
            #region Zapper 2
            zapperY2 = rnd.Next(88, 338);
            zap2.BackColor = Color.Transparent;
            zap2.Image = Properties.Resources.zapperV1;
            zap2.BackgroundImage = null;            
            zap2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(zap2);
            zap2.Location = new Point(1681, zapperY2);
            zap2.BringToFront();
            //zap2.Parent = bg2;
            ZapListV.Add(zap2);
            #endregion
            #region Zapper 3
            zapperY3 = rnd.Next(88, 338);
            zap3.BackColor = Color.Transparent;
            zap3.Image = Properties.Resources.zapperV1;
            zap3.BackgroundImage = null;        
            zap3.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(zap3);
            zap3.Location = new Point(2189, zapperY3);
            zap3.BringToFront();
            //zap3.Parent = bg3;
            ZapListV.Add(zap3);
            #endregion
            #region Zapper 4
            zap4.BackColor = Color.Transparent;
            zap4.Image = Properties.Resources.zapperH1;
            zap4.BackgroundImage = null;
            zap4.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(zap4);
            zap4.Location = new Point(zap1.Location.X-91, 740);
            zap4.BringToFront();
            //zap4.Parent = bg1;
            ZapListH.Add(zap4);
            #endregion
            #region Zapper 5
            zap5.BackColor = Color.Transparent;
            zap5.Image = Properties.Resources.zapperH1;
            zap5.BackgroundImage = null;
            zap5.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(zap5);
            zap5.Location = new Point(zap2.Location.X - 91, 740);
            zap5.BringToFront();
            //zap4.Parent = bg1;
            ZapListH.Add(zap5);
            #endregion
            #region Zapper 6
            zap6.BackColor = Color.Transparent;
            zap6.Image = Properties.Resources.zapperH1;
            zap6.BackgroundImage = null;
            zap6.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(zap6);
            zap6.Location = new Point(zap3.Location.X - 91, 740);
            zap6.BringToFront();
            //zap4.Parent = bg1;
            ZapListH.Add(zap6);
            #endregion
            #endregion
            pbBarry.BringToFront();
        }
        private void ReadCSV()
        {
            string[] Leaderboard = File.ReadAllLines(HomeScorePath);
            for (int i = 0; i < Leaderboard.Length; i++)
            {
                string[] rowdata = Leaderboard[i].Split(',');
                username.Add(rowdata[0]);
                if (username[0] == "")
                {
                    username.Clear();
                    break;
                }
                scores.Add(Int32.Parse(rowdata[1]));
                time.Add(rowdata[2]);
            }
        }
        private void tmrAnimate_Tick(object sender, EventArgs e)
        {
            if(alive)
            {
                Barry();
                if (go)
                {
                    BackgroundMove();
                    ZapperAnimation();
                    if (grav)
                    {
                        FlyUp();
                    }
                    else if (grav == false && ground == false)
                    {
                        Gravity();
                    }
                }
            }
            if(alive==false)
            {
                Death();
            }
            //TransparentBG();
        }
        #region Background
        private void BackgroundReset()
        {
            //Hallway Background Reset
            for (int i = 0; i < bgList.Count; i++)
            {
                if (bgList[i].Location.X <= -504) { bgList[i].Location = new Point(1008, -12); }
                bgList[i].Left -= bgMove;
            }
        }
        private void BackgroundMove()
        {
            //Move Starting BG Image
            if(bgstart.Location.X>-965)
            {
                bgstart.Left -= bgMove;
            }
            else if(bgstart.Location.X < -965)
            {
                this.Controls.Remove(bgstart);
            }
        }
        #endregion
        #region Flight Mechanics
        private void FlyUp()
        {
            ground = false;
            slowfall = 0;
            if (slowfly < 9)
            {
                pbBarry.Image = Properties.Resources.slowing_rise;
                slowfly++;
                if (pbBarry.Location.Y > 107)
                { pbBarry.Top -= fly/4; }
                else if (pbBarry.Location.Y <= 107)
                { pbBarry.Location = new Point(pbBarry.Location.X, 107); }
            }
            else if (slowfly >=9 && slowfly<18)
            {
                slowfly++;
                pbBarry.Image = Properties.Resources.rising;
                if (pbBarry.Location.Y > 107)
                { pbBarry.Top -= fly/2; }
                else if (pbBarry.Location.Y <= 107)
                { pbBarry.Location = new Point(pbBarry.Location.X, 107); }
            }
            else if(slowfly>=18)
            {
                if (pbBarry.Location.Y > 107)
                { pbBarry.Top -= fly; }
                else if (pbBarry.Location.Y <= 107)
                { pbBarry.Location = new Point(pbBarry.Location.X, 107); }
            }
        }
        private void Gravity()
        {
            slowfly= 0;
            if(slowfall<9)
            {
                slowfall++;
                if (pbBarry.Location.Y < 548)
                { 
                    pbBarry.Top += fly/4;
                    if (alive) { pbBarry.Image = Properties.Resources.falling; }               
                }
                else if (pbBarry.Location.Y >= 548)
                { 
                    pbBarry.Location = new Point(pbBarry.Location.X, 548);}
            }
            else if (slowfall>=9 && slowfall < 18)
            {
                slowfall++;
                if (pbBarry.Location.Y < 548)
                { pbBarry.Top += fly/2; }
                else if (pbBarry.Location.Y >= 548)
                { pbBarry.Location = new Point(pbBarry.Location.X, 548);}
            }
            if (slowfall >= 18)
            {
                slowfall++;
                if (pbBarry.Location.Y < 548)
                { pbBarry.Top += fly; }
                else if (pbBarry.Location.Y >= 548)
                { pbBarry.Location = new Point(pbBarry.Location.X, 548); }
            }
        }
        #endregion
        private void Death()
        {
            if (pbBarry.Location.Y >= 548 && deadbounce==false)
            {
                deadslide = true;
                
                pbBarry.Image = Properties.Resources.slide;
            }
            if (ground == false && deadbounce == false && deadslide == false)
            {
                Gravity();
            }
            else if (ground && deadbounce && deadslide==false)
            {
                pbBarry.Image = Properties.Resources.slide;
                bounce++;
                if (bounce < 15)
                {
                    pbBarry.Top -= fly / 2;
                }
                else if (bounce >= 15 && bounce < 30)
                {
                    pbBarry.Top -= fly / 4;
                }
                else if (bounce >= 30 && bounce < 45)
                {
                    pbBarry.Top += fly / 4;
                }
                else if (bounce >= 45 && pbBarry.Location.Y < 548)
                {
                    pbBarry.Top += fly / 2;
                }
                if (pbBarry.Location.Y >= 548 && deadslide == false)
                {
                    deadslide = true;
                    pbBarry.Location = new Point(pbBarry.Location.X, 555);
                    
                    deadbounce = false;
                }

            }
            if (deadslide)
            {
                slide++;
                if (slide < 20)
                {
                    tmrScore.Interval = 375;
                    bgMove = 2;

                }
                else if (slide >= 20 && slide < 30)
                {
                    tmrScore.Interval = 500;
                    bgMove = 1;
                }
                else if (slide >= 30)
                {
                    pbBarry.Image = Properties.Resources.death;
                    pbBarry.Location = new Point(pbBarry.Location.X, 570);
                    bgMove = 0;
                    tmrAnimate.Enabled = false;
                    tmrScore.Enabled = false;
                    tmrUpdate.Enabled = false;
                    if (Properties.Settings.Default.Guest == false)
                    {
                        Highscore();
                    }
                    else if(Properties.Settings.Default.Guest)
                    {
                        DialogResult dialogResult = MessageBox.Show("You did not create an account, so your score was not saved.\n\nWould you like to play again?\nIf you would like to create an account and play again, click yes. If not, click No.","Play Again?", MessageBoxButtons.YesNo);
                        if(dialogResult== DialogResult.Yes) { Application.Restart(); }
                        else if (dialogResult == DialogResult.No) { Application.Exit(); }
                    }
                }
            }
        }
        private void Highscore()
        {
            if (username.Count >= 3)
            {
                //First Place
                if (distance >= scores[0])
                {
                    scores.Insert(0, distance);
                    username.Insert(0, Properties.Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(0, date);
                    File.WriteAllText(HomeScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(HomeScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Properties.Settings.Default.Username}, you achieved a new high score.\nWould you like to view the leaderboard?", "New Highscore", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    }
                }
                //Second Place
                else if (distance >= scores[1] && distance < scores[0])
                {
                    scores.Insert(1, distance);
                    username.Insert(1, Properties.Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(1, date);
                    File.WriteAllText(HomeScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(HomeScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Properties.Settings.Default.Username}, you achieved the second highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    }
                }
                //Third Place
                else if (distance >= scores[2] && distance < scores[1])
                {
                    scores.Insert(2, distance);
                    username.Insert(2, Properties.Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(2, date);
                    File.WriteAllText(HomeScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(HomeScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Properties.Settings.Default.Username}, you achieved the third highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    }
                }
            }
            else if (username.Count == 2)
            {
                //First Place
                if (distance >= scores[0])
                {
                    scores.Insert(0, distance);
                    username.Insert(0, Properties.Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(0, date);
                    File.WriteAllText(HomeScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(HomeScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Properties.Settings.Default.Username}, you achieved a new high score.\nWould you like to view the leaderboard?", "New Highscore", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    }
                }
                //Second Place
                else if (distance >= scores[1] && distance < scores[0])
                {
                    scores.Insert(1, distance);
                    username.Insert(1, Properties.Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(1, date);
                    File.WriteAllText(HomeScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(HomeScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Properties.Settings.Default.Username}, you achieved the second highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    }
                }
                //Third Place
                else if (distance < scores[1])
                {
                    scores.Insert(2, distance);
                    username.Insert(2, Properties.Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(2, date);
                    File.WriteAllText(HomeScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(HomeScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Properties.Settings.Default.Username}, you achieved the third highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    }
                }
            }
            else if (username.Count == 1)
            {
                //First Place
                if (distance >= scores[0])
                {
                    scores.Insert(0, distance);
                    username.Insert(0, Properties.Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(0, date);
                    File.WriteAllText(HomeScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(HomeScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Properties.Settings.Default.Username}, you achieved a new high score.\nWould you like to view the leaderboard?", "New Highscore", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    }
                }
                //Second Place
                else if (distance < scores[0])
                {
                    scores.Insert(1, distance);
                    username.Insert(1, Properties.Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(1, date);
                    File.WriteAllText(HomeScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(HomeScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Properties.Settings.Default.Username}, you achieved the second highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                        }
                    }
                }
            }
            else if (username.Count==0)
            {
                //First Place            
                DateTime now = DateTime.Now;
                string date = now.ToString();
                time.Insert(0, date);
                string score = ($"{Properties.Settings.Default.Username},{distance},{date}\n");
                File.WriteAllText(HomeScorePath, string.Empty);
                File.AppendAllText(HomeScorePath, score);
                DialogResult dialogResult = MessageBox.Show($"Congrats, {Properties.Settings.Default.Username}, you achieved a new high score.\nWould you like to view the leaderboard?", "New Highscore", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    f2.ShowDialog();
                }
                else if (dialogResult == DialogResult.No)
                {
                    DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                    if (dialogResult2 == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    else if (dialogResult2 == DialogResult.No)
                    {
                        Application.Exit();
                    }
                }
            }
        }
        private void Score()
        {
            distance++;
            switch(distance.ToString().Length)
            {
                case 1:
                    lblScore.Text = $"000{distance}M";
                    break;
                case 2:
                    lblScore.Text = $"00{distance}M";
                    break;
                case 3:
                    lblScore.Text = $"0{distance}M";
                    break;
                case 4:
                    lblScore.Text = $"{distance}M";
                    break;
            }
        }
        private void InitialHS()
        {
            if (username.Count != 0)
            {
                switch (scores[0].ToString().Length)
                {
                    case 1:
                        lblHighscore.Text = $"000{scores[0]}M";
                        break;
                    case 2:
                        lblHighscore.Text = $"00{scores[0]}M";
                        break;
                    case 3:
                        lblHighscore.Text = $"0{scores[0]}M";
                        break;
                    case 4:
                        lblHighscore.Text = $"{scores[0]}M";
                        break;
                }
            }
            else if (username.Count==0)
            {
                lblHighscore.Text = "0000M";
            }
        }
        private void Barry()
        {
            if(go==false)
            {
                pbBarry.Left += barryMove;
            }
            //Sprite Animation
            if (ground)
            {
                barryRun++;
                switch (barryRun)
                {
                    case 8:
                        pbBarry.Image = Properties.Resources.running2;
                        break;
                    case 16:
                        pbBarry.Image = Properties.Resources.running1;
                        barryRun = 0;
                        break;
                }
            }
        }
        #region Zappers
        private void TransparentBG1()
        {
            switch(zapperY1)
            {
                case 125:

                    break;
                case 126:

                    break;
                case 127:

                    break;
                case 128:

                  break;
                case 129:

                    break;
                case 130:

                  break;
                case 131:

                    break;
                case 132:

                    break;
                case 133:

                    break;
                case 134:

                    break;
                case 135:

                    break;
                case 136:

                    break;
                case 137:

                    break;
                case 138:

                    break;
                case 139:

                    break;
                case 140:

                    break;
                case 141:

                    break;
                case 142:

                    break;
                case 143:

                    break;
                case 144:

                    break;
                case 145:

                    break;
                case 146:

                    break;
                case 147:

                    break;
                case 148:

                    break;
                case 149:

                    break;
                case 150:

                    break;
                case 151:

                    break;
                case 152:

                    break;
                case 153:

                    break;
                case 154:

                    break;
                case 155:

                    break;
                case 156:

                    break;
                case 157:

                    break;
                case 158:

                    break;
                case 159:

                    break;
                case 160:

                    break;
                case 161:

                    break;
                case 162:

                    break;
                case 163:

                    break;
                case 164:

                    break;
                case 165:

                    break;
                case 166:

                    break;
                case 167:

                    break;
                case 168:

                    break;
                case 169:

                    break;
                case 170:

                    break;
                case 172:

                    break;
                case 173:

                    break;
                case 174:

                    break;
                case 175:

                    break;
                case 176:

                    break;
                case 177:

                    break;
                case 178:

                    break;
                case 179:

                    break;
                case 180:

                    break;
                case 181:

                    break;
                case 182:

                    break;
                case 183:

                    break;
                case 184:

                    break;
                case 185:

                    break;
                case 186:

                    break;
                case 187:

                    break;
                case 188:

                    break;
                case 189:

                    break;
                case 190:

                    break;
                case 191:

                    break;
                case 192:

                    break;
                case 193:

                    break;
                case 194:

                    break;
                case 195:

                    break;
                case 196:

                    break;
                case 197:

                    break;
                case 198:

                    break;
                case 199:

                    break;
                case 200:

                    break;
                case 201:

                    break;
                case 202:

                    break;
                case 203:

                    break;
                case 204:

                    break;
                case 205:

                    break;
                case 206:

                    break;
                case 207:

                    break;
                case 208:

                    break;
                case 209:

                    break;
                case 210:

                    break;
                case 211:

                    break;
                case 212:

                    break;
                case 213:

                    break;
                case 214:

                    break;
                case 215:

                    break;
                case 216:

                    break;
                case 217:

                    break;
                case 218:

                    break;
                case 219:

                    break;
                case 220:

                    break;
                case 221:

                    break;
                case 222:

                    break;
                case 223:

                    break;
                case 224:

                    break;
                case 225:

                    break;
                case 226:

                    break;
                case 227:

                    break;
                case 228:

                    break;
                case 229:

                    break;
                case 230:

                    break;
                case 231:

                    break;
                case 232:

                    break;
                case 233:

                    break;
                case 234:

                    break;
                case 235:

                    break;
                case 236:

                    break;
                case 237:

                    break;
                case 238:

                    break;
                case 239:

                    break;
                case 240:

                    break;
                case 241:

                    break;
                case 242:

                    break;
                case 243:

                    break;
                case 244:

                    break;
                case 245:

                    break;
                case 246:

                    break;
                case 247:

                    break;
                case 248:

                    break;
                case 249:

                    break;
                case 250:

                    break;
                case 251:

                    break;
                case 252:

                    break;
                case 253:

                    break;
                case 254:

                    break;
                case 255:

                    break;
                case 256:

                    break;
                case 257:

                    break;
                case 258:

                    break;
                case 259:

                    break;
                case 260:

                    break;
                case 261:

                    break;
                case 262:

                    break;
                case 263:

                    break;
                case 264:

                    break;
                case 265:

                    break;
                case 266:

                    break;
                case 267:

                    break;
                case 268:

                    break;
                case 269:

                    break;
                case 270:

                    break;
                case 271:

                    break;
                case 272:

                    break;
                case 273:

                    break;
                case 274:

                    break;
                case 275:

                    break;
                case 276:

                    break;
                case 277:

                    break;
                case 278:

                    break;
                case 279:

                    break;
                case 280:

                    break;
                case 281:

                    break;
                case 282:

                    break;
                case 283:

                    break;
                case 284:

                    break;
                case 285:

                    break;
                case 286:

                    break;
                case 287:

                    break;
                case 288:

                    break;
                case 289:

                    break;
                case 290:

                    break;
                case 291:

                    break;
                case 292:

                    break;
                case 293:

                    break;
                case 294:

                    break;
                case 295:

                    break;
                case 296:

                    break;
                case 297:

                    break;
                case 298:

                    break;
                case 299:

                    break;
                case 300:

                    break;
                case 301:

                    break;
                case 302:

                    break;
                case 303:

                    break;
                case 304:

                    break;
                case 305:

                    break;
                case 306:

                    break;
                case 307:

                    break;
                case 308:

                    break;
                case 309:

                    break;
                case 310:

                    break;
                case 311:

                    break;
                case 312:

                    break;
                case 313:

                    break;
                case 314:

                    break;
                case 315:

                    break;
                case 316:

                    break;
                case 317:

                    break;
                case 318:

                    break;
                case 319:

                    break;
                case 320:

                    break;
                case 321:

                    break;
                case 322:

                    break;
                case 323:

                    break;
                case 324:

                    break;
                case 325:

                    break;
                case 326:

                    break;
                case 327:

                    break;
                case 328:

                    break;
                case 329:

                    break;
                case 330:

                    break;
                case 331:

                    break;
                case 332:

                    break;
                case 333:

                    break;
                case 334:

                    break;
                case 335:

                    break;
                case 336:

                    break;
                case 337:

                    break;
                case 338:

                    break;

            }
        }
        private void TransparentBG2()
        {

        }
        private void TransparentBG3()
        {

        }
        private void ResetZappers()
        {        
            if (bg1.Location.X<=-504)
            {
                zapperY1 = rnd.Next(125, 338);
                if (zap_tb<2)
                {
                    
                    if (zapperY1 > 173 && zapperY1 < 290)
                    {
                        zap_tb++;
                    }
                    //Horizontal Zappers
                    if (zapperY1 < 150)
                    {
                        zap4.Location = new Point(1134, 510);
                        zap4.BackgroundImage = Properties.Resources.ZapHBottom;
                    }
                    else if (zapperY1 > 313)
                    {
                        zap4.Location = new Point(1134, 100);
                        zap4.BackgroundImage = Properties.Resources.ZapHTop;
                    }
                    else
                    {
                        zap4.Location = new Point(1134, 740);
                        zap4.BackgroundImage = null;
                    }
                }
                else if(zap_tb>=2)
                {
                    while(zapperY1 > 173 && zapperY1 < 290)
                    {
                        zapperY1 = rnd.Next(125, 338);
                    }
                    //Horizontal Zappers
                    if (zapperY1 < 150)
                    {
                        zap4.Location = new Point(1134, 510);
                        zap4.BackgroundImage = Properties.Resources.ZapHBottom;
                    }
                    else if (zapperY1 > 313)
                    {
                        zap4.Location = new Point(1134, 100);
                        zap4.BackgroundImage = Properties.Resources.ZapHTop;
                    }
                    else
                    {
                        zap4.Location = new Point(1134, 740);
                        zap4.BackgroundImage = null;
                    }
                }
                zap1.Location = new Point(1225, zapperY1);

            }
            else if (bg2.Location.X <= -504)
            {
                zapperY2 = rnd.Next(125, 338);
                if (zap_tb < 2)
                {
                    if (zapperY2 > 173 && zapperY2 < 290)
                    {
                        zap_tb++;
                    }
                    //Horizontal Zappers
                    if (zapperY2 < 150)
                    {
                        zap5.Location = new Point(1134, 510);
                        zap5.BackgroundImage = Properties.Resources.ZapHBottom;
                    }
                    else if (zapperY2 > 313)
                    {
                        zap5.Location = new Point(1134, 100);
                        zap5.BackgroundImage = Properties.Resources.ZapHTop;
                    }
                    else
                    {
                        zap5.Location = new Point(1134, 740);
                        zap5.BackgroundImage = null;
                    }
                }
                else if (zap_tb >= 2)
                {
                    while (zapperY2 > 173 && zapperY2 < 290)
                    {
                        zapperY2 = rnd.Next(125, 338); 
                    }
                    //Horizontal Zappers
                    if (zapperY2 < 150)
                    {
                        zap5.Location = new Point(1134, 510);
                        zap5.BackgroundImage = Properties.Resources.ZapHBottom;
                    }
                    else if (zapperY2 > 313)
                    {
                        zap5.Location = new Point(1134, 100);
                        zap5.BackgroundImage = Properties.Resources.ZapHTop;
                    }
                    else
                    {
                        zap5.Location = new Point(1134, 740);
                        zap5.BackgroundImage = null;
                    }
                }
                zap2.Location = new Point(1225, zapperY2);
            }
            else if (bg3.Location.X <= -504)
            {
                zapperY3 = rnd.Next(125, 338);
                if (zap_tb < 2)
                {
                    if (zapperY3 > 173 && zapperY3 < 290)
                    {
                        zap_tb++;
                    }
                    //Horizontal Zappers
                    if (zapperY3 < 150)
                    {
                        zap6.Location = new Point(1134, 510);
                        zap6.BackgroundImage = Properties.Resources.ZapHBottom;
                    }
                    else if (zapperY3 > 313)
                    {
                        zap6.Location = new Point(1134, 100);
                        zap6.BackgroundImage = Properties.Resources.ZapHTop;
                    }
                    else
                    {
                        zap6.Location = new Point(1134, 740);
                        zap6.BackgroundImage = null;
                    }
                }
                else if (zap_tb >= 2)
                {
                    while (zapperY3 > 173 && zapperY3 < 290)
                    {
                        zapperY3 = rnd.Next(125, 338);
                    }
                    //Horizontal Zappers
                    if (zapperY3 < 150)
                    {
                        zap6.Location = new Point(1134, 510);
                        zap6.BackgroundImage = Properties.Resources.ZapHBottom;
                    }
                    else if (zapperY3 > 313)
                    {
                        zap6.Location = new Point(1134, 100);
                        zap6.BackgroundImage = Properties.Resources.ZapHTop;
                    }
                    else
                    {
                        zap6.Location = new Point(1134, 740);
                        zap6.BackgroundImage = null;
                    }
                }
                zap3.Location = new Point(1225, zapperY3);
            }
        }
        private void ZapperCollision()
        {
            if (alive)
            {
                for (int i = 0; i < ZapListV.Count; i++)
                {
                    if (ZapListV[i].Bounds.IntersectsWith(pbBarry.Bounds) || ZapListH[i].Bounds.IntersectsWith(pbBarry.Bounds))
                    {
                        pbBarry.Image = Properties.Resources.hitzap;
                        alive = false;
                        //For Testing Zapper Collision
                        /*ZapListV[i].BackColor= Color.White;
                        tmrAnimate.Enabled = false;
                        tmrUpdate.Enabled = false;*/
                    }
                }
            }
        }
        private void ZapperMovement()
        {
            for(int i=0;i<ZapListV.Count;i++)
            {
                ZapListV[i].Left -= bgMove;
                ZapListH[i].Left -= bgMove;
            }
        }
        private void ZapperAnimation()
        {
            z_animate++;
            //Zapper Animation
            for (int i = 0; i < ZapListV.Count; i++)
            {
                switch (z_animate)
                {
                    case 5:
                        ZapListV[i].Image = Properties.Resources.zapperV2;
                        if (ZapListH[i].Location.Y<740)
                        {
                            ZapListH[i].Image = Properties.Resources.zapperH2;
                        }
                        break;
                    case 10:
                        ZapListV[i].Image = Properties.Resources.zapperV3;
                        if (ZapListH[i].Location.Y < 740)
                        {
                            ZapListH[i].Image = Properties.Resources.zapperH3;
                        }
                        break;
                    case 15:
                        ZapListV[i].Image = Properties.Resources.zapperV4;
                        if (ZapListH[i].Location.Y < 740)
                        {
                            ZapListH[i].Image = Properties.Resources.zapperH4;
                        }
                        break;
                    case 20:
                        ZapListV[i].Image = Properties.Resources.zapperV1;
                        if (ZapListH[i].Location.Y < 740)
                        {
                            ZapListH[i].Image = Properties.Resources.zapperH1;
                        }
                        z_animate = 0;
                        break;
                }
            }
        }
        #endregion 
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space && start==false)
            {
                tmrAnimate.Enabled = true;
                tmrUpdate.Enabled = true;
                pbLogo.Parent = null;
                txtStart.Parent = null;
                this.Controls.Remove(pbLogo);
                this.Controls.Remove(txtStart);
                bgstart.Image = Properties.Resources.bgstart2;
                start = true;
            }
            if(e.KeyCode == Keys.Space ||e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                grav=true;
            }
            if(e.KeyCode ==Keys.Escape)
            {
                tmrAnimate.Enabled=false;
                tmrScore.Enabled = false;
                tmrUpdate.Enabled = false;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
               grav = false;
            }
        }
        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if (go)
            {
                BackgroundReset();
                ResetZappers();
                ZapperMovement();
                ZapperCollision();
            }      
            if(pbBarry.Location.X>260 && go==false && start)
            {
                pbBarry.Location = new Point(260, pbBarry.Location.Y);
                go = true;
                tmrScore.Enabled = true;
            }
            if(pbBarry.Location.Y>=548 && go && deadslide ==false)
            {
                pbBarry.Location = new Point(pbBarry.Location.X, 548); ground = true;
                if(alive==false)
                {
                    deadbounce = true;
                }
            }
        }
        private void tmrScore_Tick(object sender, EventArgs e)
        {
            Score();
        }   
        private void pnInfo_Click(object sender, EventArgs e)
        {
            if (start == false && go == false)
            {
                a1.ShowDialog();
            }
        }
        private void pnHigh_Click(object sender, EventArgs e)
        {
            if(username.Count==0)
            {
                MessageBox.Show("No Data To Display", "Scores Unvailable",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if(username.Count>0) 
            {
                if (start == false && go == false)
                {
                    f2.ShowDialog();
                }
            }
            
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
