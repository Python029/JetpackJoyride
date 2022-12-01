using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace JetpackJoyride
{
    public partial class Form1 : Form
    {
        public Form1()
        {           
            InitializeComponent();
        }
        List<PictureBox> bgList = new List<PictureBox>();
        List<PictureBox> ZapList = new List<PictureBox>();
        Random rnd = new Random();
        Form2 f2 = new Form2();
        AboutBox1 a1 = new AboutBox1();
        #region Booleans
        bool start = false;
        bool go = false;
        bool grav = false;
        bool ground = true;
        bool alive = true;
        bool deadbounce = false;
        #endregion
        #region Integers/Doubles
        int bgMove = 4;
        int zapMove = 4;
        int barryRun = 0;
        int z_rotation = 0;
        int zapperY1 = 0;
        int zapperY2 = 0;
        int zapperY3 = 0;
        int z_animate = 0;
        int barryMove = 4;
        int fly = 8;
        int slowfly = 0;
        int slowfall = 0;
        int bounce = 0;
        double distance = 0;
        int slide = 0;
        #endregion
        #region Objects
        PictureBox zap1 = new PictureBox();
        PictureBox zap2 = new PictureBox();
        PictureBox zap3 = new PictureBox();
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            bg1.Location = new Point(956, -28);
            bg2.Location = new Point(1460, -28);
            bg3.Location = new Point(1964, -28);
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
            zap1.Size = new Size(97,293);
            zap1.BackColor = Color.Transparent;
            zap1.Image = Properties.Resources.zapper;
            zap1.BackgroundImage=null;
            zap1.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Controls.Add(zap1);
            zap1.Location = new Point(1173, zapperY1);
            zap1.BringToFront();
            zap1.Parent = bg1;
            ZapList.Add(zap1);
            #endregion
            #region Zapepr 2
            zapperY2 = rnd.Next(88, 338);
            zap2.Size = new Size(97, 293);
            zap2.BackColor = Color.Transparent;
            zap2.Image = Properties.Resources.zapper;
            zap2.BackgroundImage = null;            
            zap2.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Controls.Add(zap2);
            zap2.Location = new Point(1681, zapperY2);
            zap2.BringToFront();
            zap2.Parent = bg2;
            ZapList.Add(zap2);
            #endregion
            #region Zapper 3
            zapperY3 = rnd.Next(88, 338);
            zap3.Size = new Size(97, 293);
            zap3.BackColor = Color.Transparent;
            zap3.Image = Properties.Resources.zapper;
            zap3.BackgroundImage = null;        
            zap3.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Controls.Add(zap3);
            zap3.Location = new Point(2189, zapperY3);
            zap3.BringToFront();
            zap3.Parent = bg3;
            ZapList.Add(zap3);
            #endregion
            #endregion
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
            Death();
            //TransparentBG();
        }
        #region Background
        private void BackgroundReset()
        {
            //Hallway Background Reset
            for (int i = 0; i < bgList.Count; i++)
            {
                if (bgList[i].Location.X <= -504) { bgList[i].Location = new Point(1008, -28); }
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
                if (pbBarry.Location.Y > 70)
                { pbBarry.Top -= fly/4; }
                else if (pbBarry.Location.Y <= 70)
                { pbBarry.Location = new Point(pbBarry.Location.X, 70); }
            }
            else if (slowfly >=9 && slowfly<18)
            {
                slowfly++;
                pbBarry.Image = Properties.Resources.rising;
                if (pbBarry.Location.Y > 70)
                { pbBarry.Top -= fly/2; }
                else if (pbBarry.Location.Y <= 70)
                { pbBarry.Location = new Point(pbBarry.Location.X, 70); }
            }
            else if(slowfly>=18)
            {
                if (pbBarry.Location.Y > 70)
                { pbBarry.Top -= fly; }
                else if (pbBarry.Location.Y <= 70)
                { pbBarry.Location = new Point(pbBarry.Location.X, 70); }
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
                    pbBarry.Image = Properties.Resources.falling;
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
        {   if(alive)
            {
                for(int i= 0; i < ZapList.Count; i++)
                {
                    alive = false;
                }
            }
        else if(alive==false)
        {
                if(ground == false && deadbounce == false)
                {
                    Gravity();                    
                }
                else if(ground && deadbounce)
                {
                    bounce++;
                    if(bounce < 10)
                    {
                        pbBarry.Top -= fly/2;
                    }
                    else if(bounce >= 10 && bounce<20)
                    {
                        pbBarry.Top -= fly / 4;
                    }
                    else if (bounce >= 20 && bounce < 30)
                    {
                        pbBarry.Top += fly / 4;
                    }
                    else if (bounce >= 30 && pbBarry.Location.Y<548)
                    {
                        pbBarry.Top += fly / 2;
                    }
                    if(pbBarry.Location.Y>=548)
                    {
                        slide++;
                        if (bounce < 10)
                        {
                            bgMove /= 2;
                            pbBarry.Image = Properties.Resources.slide;
                        }
                        else if (bounce >= 10 && bounce < 20)
                        {
                            bgMove /= 2;
                        }
                        
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
                    lblScore.Text = $"000{Math.Round(distance,0)}M";
                    break;
                case 2:
                    lblScore.Text = $"00{Math.Round(distance, 0)}M";
                    break;
                case 3:
                    lblScore.Text = $"0{Math.Round(distance, 0)}M";
                    break;
                case 4:
                    lblScore.Text = $"{Math.Round(distance, 0)}M";
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
                zapperY1 = rnd.Next(88, 338);              
                zap1.Location = new Point(1225, zapperY1);
                zap1.Parent = bg1;
            }
            else if (bg2.Location.X <= -504)
            {
                zapperY2 = rnd.Next(88, 338);               
                zap2.Location = new Point(1225, zapperY2);
                zap2.Parent = bg2;
            }
            else if (bg3.Location.X <= -504)
            {
                zapperY3 = rnd.Next(88, 338);                
                zap3.Location = new Point(1225, zapperY3);
                zap3.Parent = bg3;
            }
        }
        private void ZapperMovement()
        {
            zap1.Location = new Point(bg1.Location.X + 217, zapperY1);
            zap2.Location = new Point(bg2.Location.X + 217, zapperY2);
            zap3.Location = new Point(bg3.Location.X + 217, zapperY3);
        }
        private void ZapperAnimation()
        {
            z_animate++;
            //Zapper Animation
            for (int i = 0; i < ZapList.Count; i++)
            {
                switch (z_animate)
                {
                    case 5:
                        ZapList[i].Image = Properties.Resources.zapper2;
                        break;
                    case 10:
                        ZapList[i].Image = Properties.Resources.zapper3;
                        break;
                    case 15:
                        ZapList[i].Image = Properties.Resources.zapper4;
                        break;
                    case 20:
                        ZapList[i].Image = Properties.Resources.zapper;
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
            }      
            if(pbBarry.Location.X>260 && go==false && start)
            {
                pbBarry.Location = new Point(260, pbBarry.Location.Y);
                go = true;
                tmrScore.Enabled = true;
            }
            if(pbBarry.Location.Y>=548 && go)
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
        private void pnHigh_MouseClick(object sender, MouseEventArgs e)
        {
            if (start == false && go == false)
            {
                f2.ShowDialog();
            }
        }

        private void pnInfo_Click(object sender, EventArgs e)
        {
            if (start == false && go == false)
            {
                a1.ShowDialog();
            }
        }
    }
}
