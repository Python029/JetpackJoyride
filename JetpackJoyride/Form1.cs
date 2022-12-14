using System;
using System.IO;
using System.Drawing;
using System.Drawing.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using JetpackJoyride.Properties;
using System.Runtime.InteropServices;
using System.Media;

namespace JetpackJoyride
{
    public partial class Form1 : Form
    {
        public Form1()
        {           
            InitializeComponent();
        }
        #region Other Stuff
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
        PrivateFontCollection pfc = new PrivateFontCollection();
        SoundPlayer player = new SoundPlayer(Resources.JJStartingTheme);
        SoundPlayer Song = new SoundPlayer(Resources.JetpackJoyrideMainTheme);
        #endregion
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
            if(Settings.Default.Again==false) {lg.ShowDialog();}
            SoundPlayer player = new SoundPlayer(Resources.JJStartingTheme);
            player.PlayLooping();
            CustomFont();
            ReadCSV();            
            if (username.Count>0)
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
            lblStart.Parent = bgstart;
            //pbBarry.Parent = bgstart;
            lblScore.Parent = pbScore;
            lblHighscore.Parent = bgstart;
            pnHigh.Parent = bgstart;
            pnInfo.Parent = bgstart;
            pnE1.Parent = bgstart;
            pnE2.Parent = bgstart;
            lblScore.ForeColor= Color.White;
            for (int i = 1; i<4;i++)
            {
                PictureBox pb = (PictureBox)this.Controls["bg" + i.ToString()];
                bgList.Add(pb);
            }
            #region Initial Zappers
            #region Zapper 1
            zapperY1 = rnd.Next(125, 339);
            zap1.BackColor = Color.Transparent;
            zap1.Image = Resources.zapperV1;
            zap1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(zap1);
            TransparentBG1();
            zap1.Location = new Point(1173, zapperY1);
            zap1.BringToFront();
            ZapListV.Add(zap1);
            #endregion
            #region Zapper 2
            zapperY2 = rnd.Next(125, 339);
            zap2.BackColor = Color.Transparent;
            zap2.Image = Resources.zapperV1;         
            zap2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(zap2);
            TransparentBG2();
            zap2.Location = new Point(1681, zapperY2);
            zap2.BringToFront();
            ZapListV.Add(zap2);
            #endregion
            #region Zapper 3
            zapperY3 = rnd.Next(125, 339);
            zap3.BackColor = Color.Transparent;
            zap3.Image = Resources.zapperV1;
            zap3.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(zap3);
            TransparentBG3();
            zap3.Location = new Point(2189, zapperY3);
            zap3.BringToFront();
            ZapListV.Add(zap3);
            #endregion
            #region Zapper 4
            zap4.BackColor = Color.Transparent;
            zap4.Image = Resources.zapperH1;
            zap4.BackgroundImage = null;
            zap4.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(zap4);
            zap4.Location = new Point(zap1.Location.X-91, 740);
            zap4.BringToFront();
            ZapListH.Add(zap4);
            #endregion
            #region Zapper 5
            zap5.BackColor = Color.Transparent;
            zap5.Image = Resources.zapperH1;
            zap5.BackgroundImage = null;
            zap5.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(zap5);
            zap5.Location = new Point(zap2.Location.X - 91, 740);
            zap5.BringToFront();
            ZapListH.Add(zap5);
            #endregion
            #region Zapper 6
            zap6.BackColor = Color.Transparent;
            zap6.Image = Resources.zapperH1;
            zap6.BackgroundImage = null;
            zap6.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(zap6);
            zap6.Location = new Point(zap3.Location.X - 91, 740);
            zap6.BringToFront();
            ZapListH.Add(zap6);
            #endregion
            #endregion
            pbBarry.BringToFront();
        }
        private void CustomFont()
        {
            int fontLength = Resources.New_Athletic_M54.Length;
            byte[] fontdata = Resources.New_Athletic_M54;
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
            lblHighscore.Font = new Font(pfc.Families[0], lblHighscore.Font.Size);
            lblScore.Font = new Font(pfc.Families[0], lblScore.Font.Size);
            lblStart.Font = new Font(pfc.Families[0], lblStart.Font.Size);
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
                        break;
                    }
                    scores.Add(Int32.Parse(rowdata[1]));
                    time.Add(rowdata[2]);
                }
            }
            catch
            {
                MessageBox.Show("The file containing all scores cannot be accessed.", "File Inaccessible", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                pbBarry.Image = Resources.slowing_rise;
                slowfly++;
                if (pbBarry.Location.Y > 107)
                { pbBarry.Top -= fly/4; }
                else if (pbBarry.Location.Y <= 107)
                { pbBarry.Location = new Point(pbBarry.Location.X, 107); }
            }
            else if (slowfly >=9 && slowfly<18)
            {
                slowfly++;
                pbBarry.Image = Resources.rising;
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
                    if (alive) { pbBarry.Image = Resources.falling; }               
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
                
                pbBarry.Image = Resources.slide;
            }
            if (ground == false && deadbounce == false && deadslide == false)
            {
                Gravity();
            }
            else if (ground && deadbounce && deadslide==false)
            {
                pbBarry.Image = Resources.slide;
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
                    pbBarry.Image = Resources.death;
                    pbBarry.Location = new Point(pbBarry.Location.X, 570);
                    bgMove = 0;
                    tmrAnimate.Enabled = false;
                    tmrScore.Enabled = false;
                    tmrUpdate.Enabled = false;
                    Song.Stop();
                    if (Settings.Default.Guest == false)
                    {
                        Highscore();
                    }
                    else if(Settings.Default.Guest)
                    {
                        DialogResult dialogResult = MessageBox.Show("You did not create an account, so your score was not saved.\n\nWould you like to play again?\nIf you would like to create an account and play again, click Yes. If not, click No.","Play Again?", MessageBoxButtons.YesNo);
                        if(dialogResult== DialogResult.Yes) { Application.Restart(); Settings.Default.Reset(); Settings.Default.Save(); }
                        else if (dialogResult == DialogResult.No) { Application.Exit(); Settings.Default.Reset(); Settings.Default.Save(); }
                    }
                }
            }
        }
        private void Highscore()
        {
            if(username.Count>=5)
            {
                //First Place
                if (distance >= scores[0])
                {
                    scores.Insert(0, distance);
                    username.Insert(0, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(0, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved a new high score.\nWould you like to view the leaderboard?", "New Highscore", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
                //Second Place
                else if (distance >= scores[1] && distance < scores[0])
                {
                    scores.Insert(1, distance);
                    username.Insert(1, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(1, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved the second highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
                //Third Place
                else if (distance >= scores[2] && distance < scores[1])
                {
                    scores.Insert(2, distance);
                    username.Insert(2, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(2, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved the third highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
                //Fourth Place
                else if (distance >= scores[3] && distance < scores[2])
                {
                    scores.Insert(3, distance);
                    username.Insert(3, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(3, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved the fourth highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
                //Fifth Place
                else if (distance >= scores[4] && distance < scores[3])
                {
                    scores.Insert(4, distance);
                    username.Insert(4, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(4, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved the fifth highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
                //Other
                else if (distance < scores[4])
                {
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you made it a distance of {distance} meters. However, you did not make the top 5.\n(You must make the top 5 in order to be added to the leaderboard)\n\nWould you still like to view the leaderboard?", "Game Over", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
            }
            else if(username.Count == 4)
            {
                //First Place
                if (distance >= scores[0])
                {
                    scores.Insert(0, distance);
                    username.Insert(0, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(0, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved a new high score.\nWould you like to view the leaderboard?", "New Highscore", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
                //Second Place
                else if (distance >= scores[1] && distance < scores[0])
                {
                    scores.Insert(1, distance);
                    username.Insert(1, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(1, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved the second highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
                //Third Place
                else if (distance >= scores[2] && distance < scores[1])
                {
                    scores.Insert(2, distance);
                    username.Insert(2, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(2, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved the third highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
                //Fourth Place
                else if (distance >= scores[3] && distance < scores[2])
                {
                    scores.Insert(3, distance);
                    username.Insert(3, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(3, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved the fourth highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
                //Fifth Place
                else if (distance < scores[3])
                {
                    scores.Insert(4, distance);
                    username.Insert(4, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(4, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved the fifth highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
            }
            else if (username.Count == 3)
            {
                //First Place
                if (distance >= scores[0])
                {
                    scores.Insert(0, distance);
                    username.Insert(0, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(0, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved a new high score.\nWould you like to view the leaderboard?", "New Highscore", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
                //Second Place
                else if (distance >= scores[1] && distance < scores[0])
                {
                    scores.Insert(1, distance);
                    username.Insert(1, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(1, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved the second highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
                //Third Place
                else if (distance >= scores[2] && distance < scores[1])
                {
                    scores.Insert(2, distance);
                    username.Insert(2, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(2, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved the third highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
                //Fourth Place
                else if (distance < scores[2])
                {
                    scores.Insert(3, distance);
                    username.Insert(3, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(3, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved the fourth highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
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
                    username.Insert(0, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(0, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved a new high score.\nWould you like to view the leaderboard?", "New Highscore", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
                //Second Place
                else if (distance >= scores[1] && distance < scores[0])
                {
                    scores.Insert(1, distance);
                    username.Insert(1, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(1, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved the second highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
                //Third Place
                else if (distance < scores[1])
                {
                    scores.Insert(2, distance);
                    username.Insert(2, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(2, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved the third highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
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
                    username.Insert(0, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(0, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved a new high score.\nWould you like to view the leaderboard?", "New Highscore", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                }
                //Second Place
                else if (distance < scores[0])
                {
                    scores.Insert(1, distance);
                    username.Insert(1, Settings.Default.Username);
                    DateTime now = DateTime.Now;
                    string date = now.ToString();
                    time.Insert(1, date);
                    File.WriteAllText(ScorePath, string.Empty);
                    for (int i = 0; i < username.Count; i++)
                    {
                        string score = ($"{username[i]},{scores[i]},{time[i]}\n");
                        File.AppendAllText(ScorePath, score);
                    }
                    DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved the second highest score.\nWould you like to view the leaderboard?", "New Score", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        f2.ShowDialog();
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            Application.Restart();
                            Settings.Default.Again = true; Settings.Default.Save();
                        }
                        else if (dialogResult2 == DialogResult.No)
                        {
                            Application.Exit();
                            Settings.Default.Reset(); Settings.Default.Save();
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
                string score = ($"{Settings.Default.Username},{distance},{date}\n");
                File.WriteAllText(ScorePath, string.Empty);
                File.AppendAllText(ScorePath, score);
                DialogResult dialogResult = MessageBox.Show($"Congrats, {Settings.Default.Username}, you achieved a new high score.\nWould you like to view the leaderboard?", "New Highscore", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    f2.ShowDialog();
                    DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                    if (dialogResult2 == DialogResult.Yes)
                    {
                        Application.Restart();
                        Settings.Default.Again = true; Settings.Default.Save();
                    }
                    else if (dialogResult2 == DialogResult.No)
                    {
                        Application.Exit();
                        Settings.Default.Reset(); Settings.Default.Save();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    DialogResult dialogResult2 = MessageBox.Show($"Would you like to play again?", "Play Again?", MessageBoxButtons.YesNo);
                    if (dialogResult2 == DialogResult.Yes)
                    {
                        Application.Restart();
                        Settings.Default.Again = true; Settings.Default.Save();
                    }
                    else if (dialogResult2 == DialogResult.No)
                    {
                        Application.Exit();
                        Settings.Default.Reset(); Settings.Default.Save();
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
                    case 7:
                        pbBarry.Image = Resources.running2;
                        break;
                    case 14:
                        pbBarry.Image = Resources.running1;
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
                    zap1.BackgroundImage = Resources.Zap125;
                    break;
                case 126:
                    zap1.BackgroundImage = Resources.Zap126;
                    break;
                case 127:
                    zap1.BackgroundImage = Resources.Zap127;
                    break;
                case 128:
                    zap1.BackgroundImage = Resources.Zap128;
                    break;
                case 129:
                    zap1.BackgroundImage = Resources.Zap129;
                    break;
                case 130:
                    zap1.BackgroundImage = Resources.Zap130;
                    break;
                case 131:
                    zap1.BackgroundImage = Resources.Zap131;
                    break;
                case 132:
                    zap1.BackgroundImage = Resources.Zap132;
                    break;
                case 133:
                    zap1.BackgroundImage = Resources.Zap133;
                    break;
                case 134:
                    zap1.BackgroundImage = Resources.Zap134;
                    break;
                case 135:
                    zap1.BackgroundImage = Resources.Zap135;
                    break;
                case 136:
                    zap1.BackgroundImage = Resources.Zap136;
                    break;
                case 137:
                    zap1.BackgroundImage = Resources.Zap137;
                    break;
                case 138:
                    zap1.BackgroundImage = Resources.Zap138;
                    break;
                case 139:
                    zap1.BackgroundImage = Resources.Zap139;
                    break;
                case 140:
                    zap1.BackgroundImage = Resources.Zap140;
                    break;
                case 141:
                    zap1.BackgroundImage = Resources.Zap141;
                    break;
                case 142:
                    zap1.BackgroundImage = Resources.Zap142;
                    break;
                case 143:
                    zap1.BackgroundImage = Resources.Zap143;
                    break;
                case 144:
                    zap1.BackgroundImage = Resources.Zap144;
                    break;
                case 145:
                    zap1.BackgroundImage = Resources.Zap145;
                    break;
                case 146:
                    zap1.BackgroundImage = Resources.Zap146;
                    break;
                case 147:
                    zap1.BackgroundImage = Resources.Zap147;
                    break;
                case 148:
                    zap1.BackgroundImage = Resources.Zap148;
                    break;
                case 149:
                    zap1.BackgroundImage = Resources.Zap149;
                    break;
                case 150:
                    zap1.BackgroundImage = Resources.Zap150;
                    break;
                case 151:
                    zap1.BackgroundImage = Resources.Zap151;
                    break;
                case 152:
                    zap1.BackgroundImage = Resources.Zap152;
                    break;
                case 153:
                    zap1.BackgroundImage = Resources.Zap153;
                    break;
                case 154:
                    zap1.BackgroundImage = Resources.Zap154;
                    break;
                case 155:
                    zap1.BackgroundImage = Resources.Zap155;
                    break;
                case 156:
                    zap1.BackgroundImage = Resources.Zap156;
                    break;
                case 157:
                    zap1.BackgroundImage = Resources.Zap157;
                    break;
                case 158:
                    zap1.BackgroundImage = Resources.Zap158;
                    break;
                case 159:
                    zap1.BackgroundImage = Resources.Zap159;
                    break;
                case 160:
                    zap1.BackgroundImage = Resources.Zap160;
                    break;
                case 161:
                    zap1.BackgroundImage = Resources.Zap161;
                    break;
                case 162:
                    zap1.BackgroundImage = Resources.Zap162;
                    break;
                case 163:
                    zap1.BackgroundImage = Resources.Zap163;
                    break;
                case 164:
                    zap1.BackgroundImage = Resources.Zap164;
                    break;
                case 165:
                    zap1.BackgroundImage = Resources.Zap165;
                    break;
                case 166:
                    zap1.BackgroundImage = Resources.Zap166;
                    break;
                case 167:
                    zap1.BackgroundImage = Resources.Zap167;
                    break;
                case 168:
                    zap1.BackgroundImage = Resources.Zap168;
                    break;
                case 169:
                    zap1.BackgroundImage = Resources.Zap169;
                    break;
                case 170:
                    zap1.BackgroundImage = Resources.Zap170;
                    break;
                case 171:
                    zap1.BackgroundImage = Resources.Zap171;
                    break;
                case 172:
                    zap1.BackgroundImage = Resources.Zap172;
                    break;
                case 173:
                    zap1.BackgroundImage = Resources.Zap173;
                    break;
                case 174:
                    zap1.BackgroundImage = Resources.Zap174;
                    break;
                case 175:
                    zap1.BackgroundImage = Resources.Zap175;
                    break;
                case 176:
                    zap1.BackgroundImage = Resources.Zap176;
                    break;
                case 177:
                    zap1.BackgroundImage = Resources.Zap177;
                    break;
                case 178:
                    zap1.BackgroundImage = Resources.Zap178;
                    break;
                case 179:
                    zap1.BackgroundImage = Resources.Zap179;
                    break;
                case 180:
                    zap1.BackgroundImage = Resources.Zap180;
                    break;
                case 181:
                    zap1.BackgroundImage = Resources.Zap181;
                    break;
                case 182:
                    zap1.BackgroundImage = Resources.Zap182;
                    break;
                case 183:
                    zap1.BackgroundImage = Resources.Zap183;
                    break;
                case 184:
                    zap1.BackgroundImage = Resources.Zap184;
                    break;
                case 185:
                    zap1.BackgroundImage = Resources.Zap185;
                    break;
                case 186:
                    zap1.BackgroundImage = Resources.Zap186;
                    break;
                case 187:
                    zap1.BackgroundImage = Resources.Zap187;
                    break;
                case 188:
                    zap1.BackgroundImage = Resources.Zap188;
                    break;
                case 189:
                    zap1.BackgroundImage = Resources.Zap189;
                    break;
                case 190:
                    zap1.BackgroundImage = Resources.Zap190;
                    break;
                case 191:
                    zap1.BackgroundImage = Resources.Zap191;
                    break;
                case 192:
                    zap1.BackgroundImage = Resources.Zap192;
                    break;
                case 193:
                    zap1.BackgroundImage = Resources.Zap193;
                    break;
                case 194:
                    zap1.BackgroundImage = Resources.Zap194;
                    break;
                case 195:
                    zap1.BackgroundImage = Resources.Zap195;
                    break;
                case 196:
                    zap1.BackgroundImage = Resources.Zap196;
                    break;
                case 197:
                    zap1.BackgroundImage = Resources.Zap197;
                    break;
                case 198:
                    zap1.BackgroundImage = Resources.Zap198;
                    break;
                case 199:
                    zap1.BackgroundImage = Resources.Zap199;
                    break;
                case 200:
                    zap1.BackgroundImage = Resources.Zap200;
                    break;
                case 201:
                    zap1.BackgroundImage = Resources.Zap200;
                    break;
                case 202:
                    zap1.BackgroundImage = Resources.Zap200;
                    break;
                case 203:
                    zap1.BackgroundImage = Resources.Zap200;
                    break;
                case 204:
                    zap1.BackgroundImage = Resources.Zap200;
                    break;
                case 205:
                    zap1.BackgroundImage = Resources.Zap200;
                    break;
                case 206:
                    zap1.BackgroundImage = Resources.Zap206;
                    break;
                case 207:
                    zap1.BackgroundImage = Resources.Zap207;
                    break;
                case 208:
                    zap1.BackgroundImage = Resources.Zap208;
                    break;
                case 209:
                    zap1.BackgroundImage = Resources.Zap209;
                    break;
                case 210:
                    zap1.BackgroundImage = Resources.Zap210;
                    break;
                case 211:
                    zap1.BackgroundImage = Resources.Zap211;
                    break;
                case 212:
                    zap1.BackgroundImage = Resources.Zap212;
                    break;
                case 213:
                    zap1.BackgroundImage = Resources.Zap213;
                    break;
                case 214:
                    zap1.BackgroundImage = Resources.Zap214;
                    break;
                case 215:
                    zap1.BackgroundImage = Resources.Zap215;
                    break;
                case 216:
                    zap1.BackgroundImage = Resources.Zap216;
                    break;
                case 217:
                    zap1.BackgroundImage = Resources.Zap217;
                    break;
                case 218:
                    zap1.BackgroundImage = Resources.Zap218;
                    break;
                case 219:
                    zap1.BackgroundImage = Resources.Zap219;
                    break;
                case 220:
                    zap1.BackgroundImage = Resources.Zap220;
                    break;
                case 221:
                    zap1.BackgroundImage = Resources.Zap221;
                    break;
                case 222:
                    zap1.BackgroundImage = Resources.Zap222;
                    break;
                case 223:
                    zap1.BackgroundImage = Resources.Zap223;
                    break;
                case 224:
                    zap1.BackgroundImage = Resources.Zap224;
                    break;
                case 225:
                    zap1.BackgroundImage = Resources.Zap225;
                    break;
                case 226:
                    zap1.BackgroundImage = Resources.Zap226;
                    break;
                case 227:
                    zap1.BackgroundImage = Resources.Zap227;
                    break;
                case 228:
                    zap1.BackgroundImage = Resources.Zap228;
                    break;
                case 229:
                    zap1.BackgroundImage = Resources.Zap229;
                    break;
                case 230:
                    zap1.BackgroundImage = Resources.Zap230;
                    break;
                case 231:
                    zap1.BackgroundImage = Resources.Zap231;
                    break;
                case 232:
                    zap1.BackgroundImage = Resources.Zap232;
                    break;
                case 233:
                    zap1.BackgroundImage = Resources.Zap233;
                    break;
                case 234:
                    zap1.BackgroundImage = Resources.Zap234;
                    break;
                case 235:
                    zap1.BackgroundImage = Resources.Zap235;
                    break;
                case 236:
                    zap1.BackgroundImage = Resources.Zap236;
                    break;
                case 237:
                    zap1.BackgroundImage = Resources.Zap237;
                    break;
                case 238:
                    zap1.BackgroundImage = Resources.Zap238;
                    break;
                case 239:
                    zap1.BackgroundImage = Resources.Zap239;
                    break;
                case 240:
                    zap1.BackgroundImage = Resources.Zap240;
                    break;
                case 241:
                    zap1.BackgroundImage = Resources.Zap241;
                    break;
                case 242:
                    zap1.BackgroundImage = Resources.Zap242;
                    break;
                case 243:
                    zap1.BackgroundImage = Resources.Zap243;
                    break;
                case 244:
                    zap1.BackgroundImage = Resources.Zap244;
                    break;
                case 245:
                    zap1.BackgroundImage = Resources.Zap245;
                    break;
                case 246:
                    zap1.BackgroundImage = Resources.Zap246;
                    break;
                case 247:
                    zap1.BackgroundImage = Resources.Zap247;
                    break;
                case 248:
                    zap1.BackgroundImage = Resources.Zap248;
                    break;
                case 249:
                    zap1.BackgroundImage = Resources.Zap249;
                    break;
                case 250:
                    zap1.BackgroundImage = Resources.Zap250;
                    break;
                case 251:
                    zap1.BackgroundImage = Resources.Zap251;
                    break;
                case 252:
                    zap1.BackgroundImage = Resources.Zap252;
                    break;
                case 253:
                    zap1.BackgroundImage = Resources.Zap253;
                    break;
                case 254:
                    zap1.BackgroundImage = Resources.Zap254;
                    break;
                case 255:
                    zap1.BackgroundImage = Resources.Zap255;
                    break;
                case 256:
                    zap1.BackgroundImage = Resources.Zap256;
                    break;
                case 257:
                    zap1.BackgroundImage = Resources.Zap257;
                    break;
                case 258:
                    zap1.BackgroundImage = Resources.Zap258;
                    break;
                case 259:
                    zap1.BackgroundImage = Resources.Zap259;
                    break;
                case 260:
                    zap1.BackgroundImage = Resources.Zap260;
                    break;
                case 261:
                    zap1.BackgroundImage = Resources.Zap261;
                    break;
                case 262:
                    zap1.BackgroundImage = Resources.Zap262;
                    break;
                case 263:
                    zap1.BackgroundImage = Resources.Zap263;
                    break;
                case 264:
                    zap1.BackgroundImage = Resources.Zap264;
                    break;
                case 265:
                    zap1.BackgroundImage = Resources.Zap265;
                    break;
                case 266:
                    zap1.BackgroundImage = Resources.Zap266;
                    break;
                case 267:
                    zap1.BackgroundImage = Resources.Zap267;
                    break;
                case 268:
                    zap1.BackgroundImage = Resources.Zap268;
                    break;
                case 269:
                    zap1.BackgroundImage = Resources.Zap269;
                    break;
                case 270:
                    zap1.BackgroundImage = Resources.Zap270;
                    break;
                case 271:
                    zap1.BackgroundImage = Resources.Zap271;
                    break;
                case 272:
                    zap1.BackgroundImage = Resources.Zap272;
                    break;
                case 273:
                    zap1.BackgroundImage = Resources.Zap273;
                    break;
                case 274:
                    zap1.BackgroundImage = Resources.Zap274;
                    break;
                case 275:
                    zap1.BackgroundImage = Resources.Zap275;
                    break;
                case 276:
                    zap1.BackgroundImage = Resources.Zap276;
                    break;
                case 277:
                    zap1.BackgroundImage = Resources.Zap277;
                    break;
                case 278:
                    zap1.BackgroundImage = Resources.Zap278;
                    break;
                case 279:
                    zap1.BackgroundImage = Resources.Zap279;
                    break;
                case 280:
                    zap1.BackgroundImage = Resources.Zap280;
                    break;
                case 281:
                    zap1.BackgroundImage = Resources.Zap281;
                    break;
                case 282:
                    zap1.BackgroundImage = Resources.Zap282;
                    break;
                case 283:
                    zap1.BackgroundImage = Resources.Zap283;
                    break;
                case 284:
                    zap1.BackgroundImage = Resources.Zap284;
                    break;
                case 285:
                    zap1.BackgroundImage = Resources.Zap285;
                    break;
                case 286:
                    zap1.BackgroundImage = Resources.Zap286;
                    break;
                case 287:
                    zap1.BackgroundImage = Resources.Zap287;
                    break;
                case 288:
                    zap1.BackgroundImage = Resources.Zap288;
                    break;
                case 289:
                    zap1.BackgroundImage = Resources.Zap289;
                    break;
                case 290:
                    zap1.BackgroundImage = Resources.Zap290;
                    break;
                case 291:
                    zap1.BackgroundImage = Resources.Zap291;
                    break;
                case 292:
                    zap1.BackgroundImage = Resources.Zap292;
                    break;
                case 293:
                    zap1.BackgroundImage = Resources.Zap293;
                    break;
                case 294:
                    zap1.BackgroundImage = Resources.Zap294;
                    break;
                case 295:
                    zap1.BackgroundImage = Resources.Zap295;
                    break;
                case 296:
                    zap1.BackgroundImage = Resources.Zap296;
                    break;
                case 297:
                    zap1.BackgroundImage = Resources.Zap297;
                    break;
                case 298:
                    zap1.BackgroundImage = Resources.Zap298;
                    break;
                case 299:
                    zap1.BackgroundImage = Resources.Zap299;
                    break;
                case 300:
                    zap1.BackgroundImage = Resources.Zap300;
                    break;
                case 301:
                    zap1.BackgroundImage = Resources.Zap301;
                    break;
                case 302:
                    zap1.BackgroundImage = Resources.Zap302;
                    break;
                case 303:
                    zap1.BackgroundImage = Resources.Zap303;
                    break;
                case 304:
                    zap1.BackgroundImage = Resources.Zap304;
                    break;
                case 305:
                    zap1.BackgroundImage = Resources.Zap305;
                    break;
                case 306:
                    zap1.BackgroundImage = Resources.Zap306;
                    break;
                case 307:
                    zap1.BackgroundImage = Resources.Zap307;
                    break;
                case 308:
                    zap1.BackgroundImage = Resources.Zap308;
                    break;
                case 309:
                    zap1.BackgroundImage = Resources.Zap309;
                    break;
                case 310:
                    zap1.BackgroundImage = Resources.Zap310;
                    break;
                case 311:
                    zap1.BackgroundImage = Resources.Zap311;
                    break;
                case 312:
                    zap1.BackgroundImage = Resources.Zap312;
                    break;
                case 313:
                    zap1.BackgroundImage = Resources.Zap313;
                    break;
                case 314:
                    zap1.BackgroundImage = Resources.Zap314;
                    break;
                case 315:
                    zap1.BackgroundImage = Resources.Zap315;
                    break;
                case 316:
                    zap1.BackgroundImage = Resources.Zap316;
                    break;
                case 317:
                    zap1.BackgroundImage = Resources.Zap317;
                    break;
                case 318:
                    zap1.BackgroundImage = Resources.Zap318;
                    break;
                case 319:
                    zap1.BackgroundImage = Resources.Zap319;
                    break;
                case 320:
                    zap1.BackgroundImage = Resources.Zap320;
                    break;
                case 321:
                    zap1.BackgroundImage = Resources.Zap321;
                    break;
                case 322:
                    zap1.BackgroundImage = Resources.Zap322;
                    break;
                case 323:
                    zap1.BackgroundImage = Resources.Zap323;
                    break;
                case 324:
                    zap1.BackgroundImage = Resources.Zap324;
                    break;
                case 325:
                    zap1.BackgroundImage = Resources.Zap325;
                    break;
                case 326:
                    zap1.BackgroundImage = Resources.Zap326;
                    break;
                case 327:
                    zap1.BackgroundImage = Resources.Zap327;
                    break;
                case 328:
                    zap1.BackgroundImage = Resources.Zap328;
                    break;
                case 329:
                    zap1.BackgroundImage = Resources.Zap329;
                    break;
                case 330:
                    zap1.BackgroundImage = Resources.Zap330;
                    break;
                case 331:
                    zap1.BackgroundImage = Resources.Zap331;
                    break;
                case 332:
                    zap1.BackgroundImage = Resources.Zap332;
                    break;
                case 333:
                    zap1.BackgroundImage = Resources.Zap333;
                    break;
                case 334:
                    zap1.BackgroundImage = Resources.Zap334;
                    break;
                case 335:
                    zap1.BackgroundImage = Resources.Zap335;
                    break;
                case 336:
                    zap1.BackgroundImage = Resources.Zap336;
                    break;
                case 337:
                    zap1.BackgroundImage = Resources.Zap337;
                    break;
                case 338:
                    zap1.BackgroundImage = Resources.Zap338;
                    break;
            
            }
        }
        private void TransparentBG2()
        {
            switch (zapperY2)
            {
                case 125:
                    zap2.BackgroundImage = Resources.Zap125;
                    break;
                case 126:
                    zap2.BackgroundImage = Resources.Zap126;
                    break;
                case 127:
                    zap2.BackgroundImage = Resources.Zap127;
                    break;
                case 128:
                    zap2.BackgroundImage = Resources.Zap128;
                    break;
                case 129:
                    zap2.BackgroundImage = Resources.Zap129;
                    break;
                case 130:
                    zap2.BackgroundImage = Resources.Zap130;
                    break;
                case 131:
                    zap2.BackgroundImage = Resources.Zap131;
                    break;
                case 132:
                    zap2.BackgroundImage = Resources.Zap132;
                    break;
                case 133:
                    zap2.BackgroundImage = Resources.Zap133;
                    break;
                case 134:
                    zap2.BackgroundImage = Resources.Zap134;
                    break;
                case 135:
                    zap2.BackgroundImage = Resources.Zap135;
                    break;
                case 136:
                    zap2.BackgroundImage = Resources.Zap136;
                    break;
                case 137:
                    zap2.BackgroundImage = Resources.Zap137;
                    break;
                case 138:
                    zap2.BackgroundImage = Resources.Zap138;
                    break;
                case 139:
                    zap2.BackgroundImage = Resources.Zap139;
                    break;
                case 140:
                    zap2.BackgroundImage = Resources.Zap140;
                    break;
                case 141:
                    zap2.BackgroundImage = Resources.Zap141;
                    break;
                case 142:
                    zap2.BackgroundImage = Resources.Zap142;
                    break;
                case 143:
                    zap2.BackgroundImage = Resources.Zap143;
                    break;
                case 144:
                    zap2.BackgroundImage = Resources.Zap144;
                    break;
                case 145:
                    zap2.BackgroundImage = Resources.Zap145;
                    break;
                case 146:
                    zap2.BackgroundImage = Resources.Zap146;
                    break;
                case 147:
                    zap2.BackgroundImage = Resources.Zap147;
                    break;
                case 148:
                    zap2.BackgroundImage = Resources.Zap148;
                    break;
                case 149:
                    zap2.BackgroundImage = Resources.Zap149;
                    break;
                case 150:
                    zap2.BackgroundImage = Resources.Zap150;
                    break;
                case 151:
                    zap2.BackgroundImage = Resources.Zap151;
                    break;
                case 152:
                    zap2.BackgroundImage = Resources.Zap152;
                    break;
                case 153:
                    zap2.BackgroundImage = Resources.Zap153;
                    break;
                case 154:
                    zap2.BackgroundImage = Resources.Zap154;
                    break;
                case 155:
                    zap2.BackgroundImage = Resources.Zap155;
                    break;
                case 156:
                    zap2.BackgroundImage = Resources.Zap156;
                    break;
                case 157:
                    zap2.BackgroundImage = Resources.Zap157;
                    break;
                case 158:
                    zap2.BackgroundImage = Resources.Zap158;
                    break;
                case 159:
                    zap2.BackgroundImage = Resources.Zap159;
                    break;
                case 160:
                    zap2.BackgroundImage = Resources.Zap160;
                    break;
                case 161:
                    zap2.BackgroundImage = Resources.Zap161;
                    break;
                case 162:
                    zap2.BackgroundImage = Resources.Zap162;
                    break;
                case 163:
                    zap2.BackgroundImage = Resources.Zap163;
                    break;
                case 164:
                    zap2.BackgroundImage = Resources.Zap164;
                    break;
                case 165:
                    zap2.BackgroundImage = Resources.Zap165;
                    break;
                case 166:
                    zap2.BackgroundImage = Resources.Zap166;
                    break;
                case 167:
                    zap2.BackgroundImage = Resources.Zap167;
                    break;
                case 168:
                    zap2.BackgroundImage = Resources.Zap168;
                    break;
                case 169:
                    zap2.BackgroundImage = Resources.Zap169;
                    break;
                case 170:
                    zap2.BackgroundImage = Resources.Zap170;
                    break;
                case 171:
                    zap2.BackgroundImage = Resources.Zap171;
                    break;
                case 172:
                    zap2.BackgroundImage = Resources.Zap172;
                    break;
                case 173:
                    zap2.BackgroundImage = Resources.Zap173;
                    break;
                case 174:
                    zap2.BackgroundImage = Resources.Zap174;
                    break;
                case 175:
                    zap2.BackgroundImage = Resources.Zap175;
                    break;
                case 176:
                    zap2.BackgroundImage = Resources.Zap176;
                    break;
                case 177:
                    zap2.BackgroundImage = Resources.Zap177;
                    break;
                case 178:
                    zap2.BackgroundImage = Resources.Zap178;
                    break;
                case 179:
                    zap2.BackgroundImage = Resources.Zap179;
                    break;
                case 180:
                    zap2.BackgroundImage = Resources.Zap180;
                    break;
                case 181:
                    zap2.BackgroundImage = Resources.Zap181;
                    break;
                case 182:
                    zap2.BackgroundImage = Resources.Zap182;
                    break;
                case 183:
                    zap2.BackgroundImage = Resources.Zap183;
                    break;
                case 184:
                    zap2.BackgroundImage = Resources.Zap184;
                    break;
                case 185:
                    zap2.BackgroundImage = Resources.Zap185;
                    break;
                case 186:
                    zap2.BackgroundImage = Resources.Zap186;
                    break;
                case 187:
                    zap2.BackgroundImage = Resources.Zap187;
                    break;
                case 188:
                    zap2.BackgroundImage = Resources.Zap188;
                    break;
                case 189:
                    zap2.BackgroundImage = Resources.Zap189;
                    break;
                case 190:
                    zap2.BackgroundImage = Resources.Zap190;
                    break;
                case 191:
                    zap2.BackgroundImage = Resources.Zap191;
                    break;
                case 192:
                    zap2.BackgroundImage = Resources.Zap192;
                    break;
                case 193:
                    zap2.BackgroundImage = Resources.Zap193;
                    break;
                case 194:
                    zap2.BackgroundImage = Resources.Zap194;
                    break;
                case 195:
                    zap2.BackgroundImage = Resources.Zap195;
                    break;
                case 196:
                    zap2.BackgroundImage = Resources.Zap196;
                    break;
                case 197:
                    zap2.BackgroundImage = Resources.Zap197;
                    break;
                case 198:
                    zap2.BackgroundImage = Resources.Zap198;
                    break;
                case 199:
                    zap2.BackgroundImage = Resources.Zap199;
                    break;
                case 200:
                    zap2.BackgroundImage = Resources.Zap200;
                    break;
                case 201:
                    zap2.BackgroundImage = Resources.Zap200;
                    break;
                case 202:
                    zap2.BackgroundImage = Resources.Zap200;
                    break;
                case 203:
                    zap2.BackgroundImage = Resources.Zap200;
                    break;
                case 204:
                    zap2.BackgroundImage = Resources.Zap200;
                    break;
                case 205:
                    zap2.BackgroundImage = Resources.Zap200;
                    break;
                case 206:
                    zap2.BackgroundImage = Resources.Zap206;
                    break;
                case 207:
                    zap2.BackgroundImage = Resources.Zap207;
                    break;
                case 208:
                    zap2.BackgroundImage = Resources.Zap208;
                    break;
                case 209:
                    zap2.BackgroundImage = Resources.Zap209;
                    break;
                case 210:
                    zap2.BackgroundImage = Resources.Zap210;
                    break;
                case 211:
                    zap2.BackgroundImage = Resources.Zap211;
                    break;
                case 212:
                    zap2.BackgroundImage = Resources.Zap212;
                    break;
                case 213:
                    zap2.BackgroundImage = Resources.Zap213;
                    break;
                case 214:
                    zap2.BackgroundImage = Resources.Zap214;
                    break;
                case 215:
                    zap2.BackgroundImage = Resources.Zap215;
                    break;
                case 216:
                    zap2.BackgroundImage = Resources.Zap216;
                    break;
                case 217:
                    zap2.BackgroundImage = Resources.Zap217;
                    break;
                case 218:
                    zap2.BackgroundImage = Resources.Zap218;
                    break;
                case 219:
                    zap2.BackgroundImage = Resources.Zap219;
                    break;
                case 220:
                    zap2.BackgroundImage = Resources.Zap220;
                    break;
                case 221:
                    zap2.BackgroundImage = Resources.Zap221;
                    break;
                case 222:
                    zap2.BackgroundImage = Resources.Zap222;
                    break;
                case 223:
                    zap2.BackgroundImage = Resources.Zap223;
                    break;
                case 224:
                    zap2.BackgroundImage = Resources.Zap224;
                    break;
                case 225:
                    zap2.BackgroundImage = Resources.Zap225;
                    break;
                case 226:
                    zap2.BackgroundImage = Resources.Zap226;
                    break;
                case 227:
                    zap2.BackgroundImage = Resources.Zap227;
                    break;
                case 228:
                    zap2.BackgroundImage = Resources.Zap228;
                    break;
                case 229:
                    zap2.BackgroundImage = Resources.Zap229;
                    break;
                case 230:
                    zap2.BackgroundImage = Resources.Zap230;
                    break;
                case 231:
                    zap2.BackgroundImage = Resources.Zap231;
                    break;
                case 232:
                    zap2.BackgroundImage = Resources.Zap232;
                    break;
                case 233:
                    zap2.BackgroundImage = Resources.Zap233;
                    break;
                case 234:
                    zap2.BackgroundImage = Resources.Zap234;
                    break;
                case 235:
                    zap2.BackgroundImage = Resources.Zap235;
                    break;
                case 236:
                    zap2.BackgroundImage = Resources.Zap236;
                    break;
                case 237:
                    zap2.BackgroundImage = Resources.Zap237;
                    break;
                case 238:
                    zap2.BackgroundImage = Resources.Zap238;
                    break;
                case 239:
                    zap2.BackgroundImage = Resources.Zap239;
                    break;
                case 240:
                    zap2.BackgroundImage = Resources.Zap240;
                    break;
                case 241:
                    zap2.BackgroundImage = Resources.Zap241;
                    break;
                case 242:
                    zap2.BackgroundImage = Resources.Zap242;
                    break;
                case 243:
                    zap2.BackgroundImage = Resources.Zap243;
                    break;
                case 244:
                    zap2.BackgroundImage = Resources.Zap244;
                    break;
                case 245:
                    zap2.BackgroundImage = Resources.Zap245;
                    break;
                case 246:
                    zap2.BackgroundImage = Resources.Zap246;
                    break;
                case 247:
                    zap2.BackgroundImage = Resources.Zap247;
                    break;
                case 248:
                    zap2.BackgroundImage = Resources.Zap248;
                    break;
                case 249:
                    zap2.BackgroundImage = Resources.Zap249;
                    break;
                case 250:
                    zap2.BackgroundImage = Resources.Zap250;
                    break;
                case 251:
                    zap2.BackgroundImage = Resources.Zap251;
                    break;
                case 252:
                    zap2.BackgroundImage = Resources.Zap252;
                    break;
                case 253:
                    zap2.BackgroundImage = Resources.Zap253;
                    break;
                case 254:
                    zap2.BackgroundImage = Resources.Zap254;
                    break;
                case 255:
                    zap2.BackgroundImage = Resources.Zap255;
                    break;
                case 256:
                    zap2.BackgroundImage = Resources.Zap256;
                    break;
                case 257:
                    zap2.BackgroundImage = Resources.Zap257;
                    break;
                case 258:
                    zap2.BackgroundImage = Resources.Zap258;
                    break;
                case 259:
                    zap2.BackgroundImage = Resources.Zap259;
                    break;
                case 260:
                    zap2.BackgroundImage = Resources.Zap260;
                    break;
                case 261:
                    zap2.BackgroundImage = Resources.Zap261;
                    break;
                case 262:
                    zap2.BackgroundImage = Resources.Zap262;
                    break;
                case 263:
                    zap2.BackgroundImage = Resources.Zap263;
                    break;
                case 264:
                    zap2.BackgroundImage = Resources.Zap264;
                    break;
                case 265:
                    zap2.BackgroundImage = Resources.Zap265;
                    break;
                case 266:
                    zap2.BackgroundImage = Resources.Zap266;
                    break;
                case 267:
                    zap2.BackgroundImage = Resources.Zap267;
                    break;
                case 268:
                    zap2.BackgroundImage = Resources.Zap268;
                    break;
                case 269:
                    zap2.BackgroundImage = Resources.Zap269;
                    break;
                case 270:
                    zap2.BackgroundImage = Resources.Zap270;
                    break;
                case 271:
                    zap2.BackgroundImage = Resources.Zap271;
                    break;
                case 272:
                    zap2.BackgroundImage = Resources.Zap272;
                    break;
                case 273:
                    zap2.BackgroundImage = Resources.Zap273;
                    break;
                case 274:
                    zap2.BackgroundImage = Resources.Zap274;
                    break;
                case 275:
                    zap2.BackgroundImage = Resources.Zap275;
                    break;
                case 276:
                    zap2.BackgroundImage = Resources.Zap276;
                    break;
                case 277:
                    zap2.BackgroundImage = Resources.Zap277;
                    break;
                case 278:
                    zap2.BackgroundImage = Resources.Zap278;
                    break;
                case 279:
                    zap2.BackgroundImage = Resources.Zap279;
                    break;
                case 280:
                    zap2.BackgroundImage = Resources.Zap280;
                    break;
                case 281:
                    zap2.BackgroundImage = Resources.Zap281;
                    break;
                case 282:
                    zap2.BackgroundImage = Resources.Zap282;
                    break;
                case 283:
                    zap2.BackgroundImage = Resources.Zap283;
                    break;
                case 284:
                    zap2.BackgroundImage = Resources.Zap284;
                    break;
                case 285:
                    zap2.BackgroundImage = Resources.Zap285;
                    break;
                case 286:
                    zap2.BackgroundImage = Resources.Zap286;
                    break;
                case 287:
                    zap2.BackgroundImage = Resources.Zap287;
                    break;
                case 288:
                    zap2.BackgroundImage = Resources.Zap288;
                    break;
                case 289:
                    zap2.BackgroundImage = Resources.Zap289;
                    break;
                case 290:
                    zap2.BackgroundImage = Resources.Zap290;
                    break;
                case 291:
                    zap2.BackgroundImage = Resources.Zap291;
                    break;
                case 292:
                    zap2.BackgroundImage = Resources.Zap292;
                    break;
                case 293:
                    zap2.BackgroundImage = Resources.Zap293;
                    break;
                case 294:
                    zap2.BackgroundImage = Resources.Zap294;
                    break;
                case 295:
                    zap2.BackgroundImage = Resources.Zap295;
                    break;
                case 296:
                    zap2.BackgroundImage = Resources.Zap296;
                    break;
                case 297:
                    zap2.BackgroundImage = Resources.Zap297;
                    break;
                case 298:
                    zap2.BackgroundImage = Resources.Zap298;
                    break;
                case 299:
                    zap2.BackgroundImage = Resources.Zap299;
                    break;
                case 300:
                    zap2.BackgroundImage = Resources.Zap300;
                    break;
                case 301:
                    zap2.BackgroundImage = Resources.Zap301;
                    break;
                case 302:
                    zap2.BackgroundImage = Resources.Zap302;
                    break;
                case 303:
                    zap2.BackgroundImage = Resources.Zap303;
                    break;
                case 304:
                    zap2.BackgroundImage = Resources.Zap304;
                    break;
                case 305:
                    zap2.BackgroundImage = Resources.Zap305;
                    break;
                case 306:
                    zap2.BackgroundImage = Resources.Zap306;
                    break;
                case 307:
                    zap2.BackgroundImage = Resources.Zap307;
                    break;
                case 308:
                    zap2.BackgroundImage = Resources.Zap308;
                    break;
                case 309:
                    zap2.BackgroundImage = Resources.Zap309;
                    break;
                case 310:
                    zap2.BackgroundImage = Resources.Zap310;
                    break;
                case 311:
                    zap2.BackgroundImage = Resources.Zap311;
                    break;
                case 312:
                    zap2.BackgroundImage = Resources.Zap312;
                    break;
                case 313:
                    zap2.BackgroundImage = Resources.Zap313;
                    break;
                case 314:
                    zap2.BackgroundImage = Resources.Zap314;
                    break;
                case 315:
                    zap2.BackgroundImage = Resources.Zap315;
                    break;
                case 316:
                    zap2.BackgroundImage = Resources.Zap316;
                    break;
                case 317:
                    zap2.BackgroundImage = Resources.Zap317;
                    break;
                case 318:
                    zap2.BackgroundImage = Resources.Zap318;
                    break;
                case 319:
                    zap2.BackgroundImage = Resources.Zap319;
                    break;
                case 320:
                    zap2.BackgroundImage = Resources.Zap320;
                    break;
                case 321:
                    zap2.BackgroundImage = Resources.Zap321;
                    break;
                case 322:
                    zap2.BackgroundImage = Resources.Zap322;
                    break;
                case 323:
                    zap2.BackgroundImage = Resources.Zap323;
                    break;
                case 324:
                    zap2.BackgroundImage = Resources.Zap324;
                    break;
                case 325:
                    zap2.BackgroundImage = Resources.Zap325;
                    break;
                case 326:
                    zap2.BackgroundImage = Resources.Zap326;
                    break;
                case 327:
                    zap2.BackgroundImage = Resources.Zap327;
                    break;
                case 328:
                    zap2.BackgroundImage = Resources.Zap328;
                    break;
                case 329:
                    zap2.BackgroundImage = Resources.Zap329;
                    break;
                case 330:
                    zap2.BackgroundImage = Resources.Zap330;
                    break;
                case 331:
                    zap2.BackgroundImage = Resources.Zap331;
                    break;
                case 332:
                    zap2.BackgroundImage = Resources.Zap332;
                    break;
                case 333:
                    zap2.BackgroundImage = Resources.Zap333;
                    break;
                case 334:
                    zap2.BackgroundImage = Resources.Zap334;
                    break;
                case 335:
                    zap2.BackgroundImage = Resources.Zap335;
                    break;
                case 336:
                    zap2.BackgroundImage = Resources.Zap336;
                    break;
                case 337:
                    zap2.BackgroundImage = Resources.Zap337;
                    break;
                case 338:
                    zap2.BackgroundImage = Resources.Zap338;
                    break;

            }
        }
        private void TransparentBG3()
        {
            switch (zapperY3)
            {
                case 125:
                    zap3.BackgroundImage = Resources.Zap125;
                    break;
                case 126:
                    zap3.BackgroundImage = Resources.Zap126;
                    break;
                case 127:
                    zap3.BackgroundImage = Resources.Zap127;
                    break;
                case 128:
                    zap3.BackgroundImage = Resources.Zap128;
                    break;
                case 129:
                    zap3.BackgroundImage = Resources.Zap129;
                    break;
                case 130:
                    zap3.BackgroundImage = Resources.Zap130;
                    break;
                case 131:
                    zap3.BackgroundImage = Resources.Zap131;
                    break;
                case 132:
                    zap3.BackgroundImage = Resources.Zap132;
                    break;
                case 133:
                    zap3.BackgroundImage = Resources.Zap133;
                    break;
                case 134:
                    zap3.BackgroundImage = Resources.Zap134;
                    break;
                case 135:
                    zap3.BackgroundImage = Resources.Zap135;
                    break;
                case 136:
                    zap3.BackgroundImage = Resources.Zap136;
                    break;
                case 137:
                    zap3.BackgroundImage = Resources.Zap137;
                    break;
                case 138:
                    zap3.BackgroundImage = Resources.Zap138;
                    break;
                case 139:
                    zap3.BackgroundImage = Resources.Zap139;
                    break;
                case 140:
                    zap3.BackgroundImage = Resources.Zap140;
                    break;
                case 141:
                    zap3.BackgroundImage = Resources.Zap141;
                    break;
                case 142:
                    zap3.BackgroundImage = Resources.Zap142;
                    break;
                case 143:
                    zap3.BackgroundImage = Resources.Zap143;
                    break;
                case 144:
                    zap3.BackgroundImage = Resources.Zap144;
                    break;
                case 145:
                    zap3.BackgroundImage = Resources.Zap145;
                    break;
                case 146:
                    zap3.BackgroundImage = Resources.Zap146;
                    break;
                case 147:
                    zap3.BackgroundImage = Resources.Zap147;
                    break;
                case 148:
                    zap3.BackgroundImage = Resources.Zap148;
                    break;
                case 149:
                    zap3.BackgroundImage = Resources.Zap149;
                    break;
                case 150:
                    zap3.BackgroundImage = Resources.Zap150;
                    break;
                case 151:
                    zap3.BackgroundImage = Resources.Zap151;
                    break;
                case 152:
                    zap3.BackgroundImage = Resources.Zap152;
                    break;
                case 153:
                    zap3.BackgroundImage = Resources.Zap153;
                    break;
                case 154:
                    zap3.BackgroundImage = Resources.Zap154;
                    break;
                case 155:
                    zap3.BackgroundImage = Resources.Zap155;
                    break;
                case 156:
                    zap3.BackgroundImage = Resources.Zap156;
                    break;
                case 157:
                    zap3.BackgroundImage = Resources.Zap157;
                    break;
                case 158:
                    zap3.BackgroundImage = Resources.Zap158;
                    break;
                case 159:
                    zap3.BackgroundImage = Resources.Zap159;
                    break;
                case 160:
                    zap3.BackgroundImage = Resources.Zap160;
                    break;
                case 161:
                    zap3.BackgroundImage = Resources.Zap161;
                    break;
                case 162:
                    zap3.BackgroundImage = Resources.Zap162;
                    break;
                case 163:
                    zap3.BackgroundImage = Resources.Zap163;
                    break;
                case 164:
                    zap3.BackgroundImage = Resources.Zap164;
                    break;
                case 165:
                    zap3.BackgroundImage = Resources.Zap165;
                    break;
                case 166:
                    zap3.BackgroundImage = Resources.Zap166;
                    break;
                case 167:
                    zap3.BackgroundImage = Resources.Zap167;
                    break;
                case 168:
                    zap3.BackgroundImage = Resources.Zap168;
                    break;
                case 169:
                    zap3.BackgroundImage = Resources.Zap169;
                    break;
                case 170:
                    zap3.BackgroundImage = Resources.Zap170;
                    break;
                case 171:
                    zap3.BackgroundImage = Resources.Zap171;
                    break;
                case 172:
                    zap3.BackgroundImage = Resources.Zap172;
                    break;
                case 173:
                    zap3.BackgroundImage = Resources.Zap173;
                    break;
                case 174:
                    zap3.BackgroundImage = Resources.Zap174;
                    break;
                case 175:
                    zap3.BackgroundImage = Resources.Zap175;
                    break;
                case 176:
                    zap3.BackgroundImage = Resources.Zap176;
                    break;
                case 177:
                    zap3.BackgroundImage = Resources.Zap177;
                    break;
                case 178:
                    zap3.BackgroundImage = Resources.Zap178;
                    break;
                case 179:
                    zap3.BackgroundImage = Resources.Zap179;
                    break;
                case 180:
                    zap3.BackgroundImage = Resources.Zap180;
                    break;
                case 181:
                    zap3.BackgroundImage = Resources.Zap181;
                    break;
                case 182:
                    zap3.BackgroundImage = Resources.Zap182;
                    break;
                case 183:
                    zap3.BackgroundImage = Resources.Zap183;
                    break;
                case 184:
                    zap3.BackgroundImage = Resources.Zap184;
                    break;
                case 185:
                    zap3.BackgroundImage = Resources.Zap185;
                    break;
                case 186:
                    zap3.BackgroundImage = Resources.Zap186;
                    break;
                case 187:
                    zap3.BackgroundImage = Resources.Zap187;
                    break;
                case 188:
                    zap3.BackgroundImage = Resources.Zap188;
                    break;
                case 189:
                    zap3.BackgroundImage = Resources.Zap189;
                    break;
                case 190:
                    zap3.BackgroundImage = Resources.Zap190;
                    break;
                case 191:
                    zap3.BackgroundImage = Resources.Zap191;
                    break;
                case 192:
                    zap3.BackgroundImage = Resources.Zap192;
                    break;
                case 193:
                    zap3.BackgroundImage = Resources.Zap193;
                    break;
                case 194:
                    zap3.BackgroundImage = Resources.Zap194;
                    break;
                case 195:
                    zap3.BackgroundImage = Resources.Zap195;
                    break;
                case 196:
                    zap3.BackgroundImage = Resources.Zap196;
                    break;
                case 197:
                    zap3.BackgroundImage = Resources.Zap197;
                    break;
                case 198:
                    zap3.BackgroundImage = Resources.Zap198;
                    break;
                case 199:
                    zap3.BackgroundImage = Resources.Zap199;
                    break;
                case 200:
                    zap3.BackgroundImage = Resources.Zap200;
                    break;
                case 201:
                    zap3.BackgroundImage = Resources.Zap200;
                    break;
                case 202:
                    zap3.BackgroundImage = Resources.Zap200;
                    break;
                case 203:
                    zap3.BackgroundImage = Resources.Zap200;
                    break;
                case 204:
                    zap3.BackgroundImage = Resources.Zap200;
                    break;
                case 205:
                    zap3.BackgroundImage = Resources.Zap200;
                    break;
                case 206:
                    zap3.BackgroundImage = Resources.Zap206;
                    break;
                case 207:
                    zap3.BackgroundImage = Resources.Zap207;
                    break;
                case 208:
                    zap3.BackgroundImage = Resources.Zap208;
                    break;
                case 209:
                    zap3.BackgroundImage = Resources.Zap209;
                    break;
                case 210:
                    zap3.BackgroundImage = Resources.Zap210;
                    break;
                case 211:
                    zap3.BackgroundImage = Resources.Zap211;
                    break;
                case 212:
                    zap3.BackgroundImage = Resources.Zap212;
                    break;
                case 213:
                    zap3.BackgroundImage = Resources.Zap213;
                    break;
                case 214:
                    zap3.BackgroundImage = Resources.Zap214;
                    break;
                case 215:
                    zap3.BackgroundImage = Resources.Zap215;
                    break;
                case 216:
                    zap3.BackgroundImage = Resources.Zap216;
                    break;
                case 217:
                    zap3.BackgroundImage = Resources.Zap217;
                    break;
                case 218:
                    zap3.BackgroundImage = Resources.Zap218;
                    break;
                case 219:
                    zap3.BackgroundImage = Resources.Zap219;
                    break;
                case 220:
                    zap3.BackgroundImage = Resources.Zap220;
                    break;
                case 221:
                    zap3.BackgroundImage = Resources.Zap221;
                    break;
                case 222:
                    zap3.BackgroundImage = Resources.Zap222;
                    break;
                case 223:
                    zap3.BackgroundImage = Resources.Zap223;
                    break;
                case 224:
                    zap3.BackgroundImage = Resources.Zap224;
                    break;
                case 225:
                    zap3.BackgroundImage = Resources.Zap225;
                    break;
                case 226:
                    zap3.BackgroundImage = Resources.Zap226;
                    break;
                case 227:
                    zap3.BackgroundImage = Resources.Zap227;
                    break;
                case 228:
                    zap3.BackgroundImage = Resources.Zap228;
                    break;
                case 229:
                    zap3.BackgroundImage = Resources.Zap229;
                    break;
                case 230:
                    zap3.BackgroundImage = Resources.Zap230;
                    break;
                case 231:
                    zap3.BackgroundImage = Resources.Zap231;
                    break;
                case 232:
                    zap3.BackgroundImage = Resources.Zap232;
                    break;
                case 233:
                    zap3.BackgroundImage = Resources.Zap233;
                    break;
                case 234:
                    zap3.BackgroundImage = Resources.Zap234;
                    break;
                case 235:
                    zap3.BackgroundImage = Resources.Zap235;
                    break;
                case 236:
                    zap3.BackgroundImage = Resources.Zap236;
                    break;
                case 237:
                    zap3.BackgroundImage = Resources.Zap237;
                    break;
                case 238:
                    zap3.BackgroundImage = Resources.Zap238;
                    break;
                case 239:
                    zap3.BackgroundImage = Resources.Zap239;
                    break;
                case 240:
                    zap3.BackgroundImage = Resources.Zap240;
                    break;
                case 241:
                    zap3.BackgroundImage = Resources.Zap241;
                    break;
                case 242:
                    zap3.BackgroundImage = Resources.Zap242;
                    break;
                case 243:
                    zap3.BackgroundImage = Resources.Zap243;
                    break;
                case 244:
                    zap3.BackgroundImage = Resources.Zap244;
                    break;
                case 245:
                    zap3.BackgroundImage = Resources.Zap245;
                    break;
                case 246:
                    zap3.BackgroundImage = Resources.Zap246;
                    break;
                case 247:
                    zap3.BackgroundImage = Resources.Zap247;
                    break;
                case 248:
                    zap3.BackgroundImage = Resources.Zap248;
                    break;
                case 249:
                    zap3.BackgroundImage = Resources.Zap249;
                    break;
                case 250:
                    zap3.BackgroundImage = Resources.Zap250;
                    break;
                case 251:
                    zap3.BackgroundImage = Resources.Zap251;
                    break;
                case 252:
                    zap3.BackgroundImage = Resources.Zap252;
                    break;
                case 253:
                    zap3.BackgroundImage = Resources.Zap253;
                    break;
                case 254:
                    zap3.BackgroundImage = Resources.Zap254;
                    break;
                case 255:
                    zap3.BackgroundImage = Resources.Zap255;
                    break;
                case 256:
                    zap3.BackgroundImage = Resources.Zap256;
                    break;
                case 257:
                    zap3.BackgroundImage = Resources.Zap257;
                    break;
                case 258:
                    zap3.BackgroundImage = Resources.Zap258;
                    break;
                case 259:
                    zap3.BackgroundImage = Resources.Zap259;
                    break;
                case 260:
                    zap3.BackgroundImage = Resources.Zap260;
                    break;
                case 261:
                    zap3.BackgroundImage = Resources.Zap261;
                    break;
                case 262:
                    zap3.BackgroundImage = Resources.Zap262;
                    break;
                case 263:
                    zap3.BackgroundImage = Resources.Zap263;
                    break;
                case 264:
                    zap3.BackgroundImage = Resources.Zap264;
                    break;
                case 265:
                    zap3.BackgroundImage = Resources.Zap265;
                    break;
                case 266:
                    zap3.BackgroundImage = Resources.Zap266;
                    break;
                case 267:
                    zap3.BackgroundImage = Resources.Zap267;
                    break;
                case 268:
                    zap3.BackgroundImage = Resources.Zap268;
                    break;
                case 269:
                    zap3.BackgroundImage = Resources.Zap269;
                    break;
                case 270:
                    zap3.BackgroundImage = Resources.Zap270;
                    break;
                case 271:
                    zap3.BackgroundImage = Resources.Zap271;
                    break;
                case 272:
                    zap3.BackgroundImage = Resources.Zap272;
                    break;
                case 273:
                    zap3.BackgroundImage = Resources.Zap273;
                    break;
                case 274:
                    zap3.BackgroundImage = Resources.Zap274;
                    break;
                case 275:
                    zap3.BackgroundImage = Resources.Zap275;
                    break;
                case 276:
                    zap3.BackgroundImage = Resources.Zap276;
                    break;
                case 277:
                    zap3.BackgroundImage = Resources.Zap277;
                    break;
                case 278:
                    zap3.BackgroundImage = Resources.Zap278;
                    break;
                case 279:
                    zap3.BackgroundImage = Resources.Zap279;
                    break;
                case 280:
                    zap3.BackgroundImage = Resources.Zap280;
                    break;
                case 281:
                    zap3.BackgroundImage = Resources.Zap281;
                    break;
                case 282:
                    zap3.BackgroundImage = Resources.Zap282;
                    break;
                case 283:
                    zap3.BackgroundImage = Resources.Zap283;
                    break;
                case 284:
                    zap3.BackgroundImage = Resources.Zap284;
                    break;
                case 285:
                    zap3.BackgroundImage = Resources.Zap285;
                    break;
                case 286:
                    zap3.BackgroundImage = Resources.Zap286;
                    break;
                case 287:
                    zap3.BackgroundImage = Resources.Zap287;
                    break;
                case 288:
                    zap3.BackgroundImage = Resources.Zap288;
                    break;
                case 289:
                    zap3.BackgroundImage = Resources.Zap289;
                    break;
                case 290:
                    zap3.BackgroundImage = Resources.Zap290;
                    break;
                case 291:
                    zap3.BackgroundImage = Resources.Zap291;
                    break;
                case 292:
                    zap3.BackgroundImage = Resources.Zap292;
                    break;
                case 293:
                    zap3.BackgroundImage = Resources.Zap293;
                    break;
                case 294:
                    zap3.BackgroundImage = Resources.Zap294;
                    break;
                case 295:
                    zap3.BackgroundImage = Resources.Zap295;
                    break;
                case 296:
                    zap3.BackgroundImage = Resources.Zap296;
                    break;
                case 297:
                    zap3.BackgroundImage = Resources.Zap297;
                    break;
                case 298:
                    zap3.BackgroundImage = Resources.Zap298;
                    break;
                case 299:
                    zap3.BackgroundImage = Resources.Zap299;
                    break;
                case 300:
                    zap3.BackgroundImage = Resources.Zap300;
                    break;
                case 301:
                    zap3.BackgroundImage = Resources.Zap301;
                    break;
                case 302:
                    zap3.BackgroundImage = Resources.Zap302;
                    break;
                case 303:
                    zap3.BackgroundImage = Resources.Zap303;
                    break;
                case 304:
                    zap3.BackgroundImage = Resources.Zap304;
                    break;
                case 305:
                    zap3.BackgroundImage = Resources.Zap305;
                    break;
                case 306:
                    zap3.BackgroundImage = Resources.Zap306;
                    break;
                case 307:
                    zap3.BackgroundImage = Resources.Zap307;
                    break;
                case 308:
                    zap3.BackgroundImage = Resources.Zap308;
                    break;
                case 309:
                    zap3.BackgroundImage = Resources.Zap309;
                    break;
                case 310:
                    zap3.BackgroundImage = Resources.Zap310;
                    break;
                case 311:
                    zap3.BackgroundImage = Resources.Zap311;
                    break;
                case 312:
                    zap3.BackgroundImage = Resources.Zap312;
                    break;
                case 313:
                    zap3.BackgroundImage = Resources.Zap313;
                    break;
                case 314:
                    zap3.BackgroundImage = Resources.Zap314;
                    break;
                case 315:
                    zap3.BackgroundImage = Resources.Zap315;
                    break;
                case 316:
                    zap3.BackgroundImage = Resources.Zap316;
                    break;
                case 317:
                    zap3.BackgroundImage = Resources.Zap317;
                    break;
                case 318:
                    zap3.BackgroundImage = Resources.Zap318;
                    break;
                case 319:
                    zap3.BackgroundImage = Resources.Zap319;
                    break;
                case 320:
                    zap3.BackgroundImage = Resources.Zap320;
                    break;
                case 321:
                    zap3.BackgroundImage = Resources.Zap321;
                    break;
                case 322:
                    zap3.BackgroundImage = Resources.Zap322;
                    break;
                case 323:
                    zap3.BackgroundImage = Resources.Zap323;
                    break;
                case 324:
                    zap3.BackgroundImage = Resources.Zap324;
                    break;
                case 325:
                    zap3.BackgroundImage = Resources.Zap325;
                    break;
                case 326:
                    zap3.BackgroundImage = Resources.Zap326;
                    break;
                case 327:
                    zap3.BackgroundImage = Resources.Zap327;
                    break;
                case 328:
                    zap3.BackgroundImage = Resources.Zap328;
                    break;
                case 329:
                    zap3.BackgroundImage = Resources.Zap329;
                    break;
                case 330:
                    zap3.BackgroundImage = Resources.Zap330;
                    break;
                case 331:
                    zap3.BackgroundImage = Resources.Zap331;
                    break;
                case 332:
                    zap3.BackgroundImage = Resources.Zap332;
                    break;
                case 333:
                    zap3.BackgroundImage = Resources.Zap333;
                    break;
                case 334:
                    zap3.BackgroundImage = Resources.Zap334;
                    break;
                case 335:
                    zap3.BackgroundImage = Resources.Zap335;
                    break;
                case 336:
                    zap3.BackgroundImage = Resources.Zap336;
                    break;
                case 337:
                    zap3.BackgroundImage = Resources.Zap337;
                    break;
                case 338:
                    zap3.BackgroundImage = Resources.Zap338;
                    break;

            }
        }
        private void ResetZappers()
        {        
            if (bg1.Location.X<=-504)
            {
                zapperY1 = rnd.Next(125, 339);
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
                        zap4.BackgroundImage = Resources.ZapHBottom;
                    }
                    else if (zapperY1 > 313)
                    {
                        zap4.Location = new Point(1134, 100);
                        zap4.BackgroundImage = Resources.ZapHTop;
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
                        zapperY1 = rnd.Next(125, 339);
                    }
                    //Horizontal Zappers
                    if (zapperY1 < 150)
                    {
                        zap4.Location = new Point(1134, 510);
                        zap4.BackgroundImage = Resources.ZapHBottom;
                    }
                    else if (zapperY1 > 313)
                    {
                        zap4.Location = new Point(1134, 100);
                        zap4.BackgroundImage = Resources.ZapHTop;
                    }
                    else
                    {
                        zap4.Location = new Point(1134, 740);
                        zap4.BackgroundImage = null;
                    }
                }
                zap1.Location = new Point(1225, zapperY1);
                TransparentBG1();

            }
            else if (bg2.Location.X <= -504)
            {
                zapperY2 = rnd.Next(125, 339);
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
                        zap5.BackgroundImage = Resources.ZapHBottom;
                    }
                    else if (zapperY2 > 313)
                    {
                        zap5.Location = new Point(1134, 100);
                        zap5.BackgroundImage = Resources.ZapHTop;
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
                        zapperY2 = rnd.Next(125, 339); 
                    }
                    //Horizontal Zappers
                    if (zapperY2 < 150)
                    {
                        zap5.Location = new Point(1134, 510);
                        zap5.BackgroundImage = Resources.ZapHBottom;
                    }
                    else if (zapperY2 > 313)
                    {
                        zap5.Location = new Point(1134, 100);
                        zap5.BackgroundImage = Resources.ZapHTop;
                    }
                    else
                    {
                        zap5.Location = new Point(1134, 740);
                        zap5.BackgroundImage = null;
                    }
                }
                zap2.Location = new Point(1225, zapperY2);
                TransparentBG2();
            }
            else if (bg3.Location.X <= -504)
            {
                zapperY3 = rnd.Next(125, 339);
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
                        zap6.BackgroundImage = Resources.ZapHBottom;
                    }
                    else if (zapperY3 > 313)
                    {
                        zap6.Location = new Point(1134, 100);
                        zap6.BackgroundImage = Resources.ZapHTop;
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
                        zapperY3 = rnd.Next(125, 339);
                    }
                    //Horizontal Zappers
                    if (zapperY3 < 150)
                    {
                        zap6.Location = new Point(1134, 510);
                        zap6.BackgroundImage = Resources.ZapHBottom;
                    }
                    else if (zapperY3 > 313)
                    {
                        zap6.Location = new Point(1134, 100);
                        zap6.BackgroundImage = Resources.ZapHTop;
                    }
                    else
                    {
                        zap6.Location = new Point(1134, 740);
                        zap6.BackgroundImage = null;
                    }
                }
                zap3.Location = new Point(1225, zapperY3);
                TransparentBG3();
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
                        pbBarry.Image = Resources.hitzap;
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
                        ZapListV[i].Image = Resources.zapperV2;
                        if (ZapListH[i].Location.Y<740)
                        {
                            ZapListH[i].Image = Resources.zapperH2;
                        }
                        break;
                    case 10:
                        ZapListV[i].Image = Resources.zapperV3;
                        if (ZapListH[i].Location.Y < 740)
                        {
                            ZapListH[i].Image = Resources.zapperH3;
                        }
                        break;
                    case 15:
                        ZapListV[i].Image = Resources.zapperV4;
                        if (ZapListH[i].Location.Y < 740)
                        {
                            ZapListH[i].Image = Resources.zapperH4;
                        }
                        break;
                    case 20:
                        ZapListV[i].Image = Resources.zapperV1;
                        if (ZapListH[i].Location.Y < 740)
                        {
                            ZapListH[i].Image = Resources.zapperH1;
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
                lblStart.Parent = null;
                this.Controls.Remove(pbLogo);
                this.Controls.Remove(lblStart);
                bgstart.Image = Resources.bgstart2;
                start = true;
                player.Stop();
                Song.PlayLooping();
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
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(start ==false || go == false)
            {
                Settings.Default.Reset();
                Settings.Default.Save();
            }  
        }
        private void pnE1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
        private void pnE2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }
    }
}
