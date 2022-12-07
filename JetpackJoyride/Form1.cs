using System;
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
            InitialHS();
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
            }
            else if (username.Count == 0)
            {
                //First Place            
                DateTime now = DateTime.Now;
                string date = now.ToString();
                time.Insert(0, date);
                string score = ($"{Properties.Settings.Default.Username},{distance},{date}\n");
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
                    }
                    else if (zapperY1 > 313)
                    {
                        zap4.Location = new Point(1134, 100);
                    }
                    else
                    {
                        zap4.Location = new Point(1134, 740);
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
                    }
                    else if (zapperY1 > 313)
                    {
                        zap4.Location = new Point(1134, 100);
                    }
                    else
                    {
                        zap4.Location = new Point(1134, 740);
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
                    }
                    else if (zapperY2 > 313)
                    {
                        zap5.Location = new Point(1134, 100);
                    }
                    else
                    {
                        zap5.Location = new Point(1134, 740);
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
                    }
                    else if (zapperY2 > 313)
                    {
                        zap5.Location = new Point(1134, 100);
                    }
                    else
                    {
                        zap5.Location = new Point(1134, 740);
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
                    }
                    else if (zapperY3 > 313)
                    {
                        zap6.Location = new Point(1134, 100);
                    }
                    else
                    {
                        zap6.Location = new Point(1134, 740);
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
                    }
                    else if (zapperY3 > 313)
                    {
                        zap6.Location = new Point(1134, 100);
                    }
                    else
                    {
                        zap6.Location = new Point(1134, 740);
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
        private void TransparentBG()
        {
            if(bgstart.Location.X <= -652)
            {
                pbBarry.Parent = bg1;               
            }
        }
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
            if (start == false && go == false)
            {
                f2.ShowDialog();
            }
        }
    }
}
