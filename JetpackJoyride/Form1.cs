using System;
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
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }
        List<PictureBox> bgList = new List<PictureBox>();
        List<PictureBox> ZapList = new List<PictureBox>();
        Random rnd = new Random();
        #region Booleans
        bool start = false;
        bool go = false;
        bool grav = false;
        bool slowup = false;
        bool speedup=false;
        bool slowdown = false;
        bool speeddown = false;
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
        #endregion
        #region Objects
        PictureBox zap1 = new PictureBox();
        PictureBox zap2 = new PictureBox();
        PictureBox zap3 = new PictureBox();
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            bg1.Location = new Point(956, -28);
            bg2.Location = new Point(1460, -28);
            bg3.Location = new Point(1964, -28);
            pbBarry.Location = new Point(-80,pbBarry.Location.Y);
            z_animate = rnd.Next(0, 19);
            ZapperAnimation();
            pbLogo.Parent = bgstart;
            txtStart.Parent = bgstart;
            //pbBarry.Parent = bgstart;
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
            zap1.Location = new Point(1173, zapperY1);
            zap1.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Controls.Add(zap1);
            zap1.BringToFront();
            //zap1.Parent = bg1;
            ZapList.Add(zap1);
            #endregion
            #region Zapepr 2
            zapperY2 = rnd.Next(88, 338);
            zap2.Size = new Size(97, 293);
            zap2.BackColor = Color.Transparent;
            zap2.Image = Properties.Resources.zapper;
            zap2.BackgroundImage = null;
            zap2.Location = new Point(1681, zapperY2);
            zap2.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Controls.Add(zap2);
            zap2.BringToFront();
            //zap2.Parent = bg2;
            ZapList.Add(zap2);
            #endregion
            #region Zapper 3
            zapperY3 = rnd.Next(88, 338);
            zap3.Size = new Size(97, 293);
            zap3.BackColor = Color.Transparent;
            zap3.Image = Properties.Resources.zapper;
            zap3.BackgroundImage = null;
            zap3.Location = new Point(2189, zapperY3);
            zap3.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Controls.Add(zap3);
            zap3.BringToFront();
            //zap3.Parent = bg3;
            ZapList.Add(zap3);
            #endregion
            #endregion
        }

        private void tmrAnimate_Tick(object sender, EventArgs e)
        {
            Barry();
            if(go)
            {
                BackgroundMove();           
                ZapperMovement();
                ZapperAnimation();
                if(grav)
                {
                    FlyUp();
                }
                else if(grav==false)
                {
                    Gravity();
                }
            }         
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
            slowfall = 0;
            if (slowfly < 9)
            {
                slowfly++;
                if (pbBarry.Location.Y > 70)
                { pbBarry.Top -= fly/4; }
                else if (pbBarry.Location.Y <= 70)
                { pbBarry.Location = new Point(pbBarry.Location.X, 70); }
            }
            else if (slowfly >=9 && slowfly<18)
            {
                slowfly++;
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
                { pbBarry.Top += fly/4; }
                else if (pbBarry.Location.Y >= 548)
                { pbBarry.Location = new Point(pbBarry.Location.X, 548); }
            }
            else if (slowfall>=9 && slowfall < 18)
            {
                slowfall++;
                if (pbBarry.Location.Y < 548)
                { pbBarry.Top += fly/2; }
                else if (pbBarry.Location.Y >= 548)
                { pbBarry.Location = new Point(pbBarry.Location.X, 548); }
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
        private void Barry()
        {
            barryRun++;
            if(go==false)
            {
                pbBarry.Left += barryMove;
            }           
            //Sprite Animation
            switch(barryRun)
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
        #region Zappers
        private void ResetZappers()
        {
            
            if (bg1.Location.X<=-504)
            {
                zapperY1 = rnd.Next(88, 338);              
                zap1.Location = new Point(1225, zapperY1);
                ZapperOrientation();
            }
            else if (bg2.Location.X <= -504)
            {
                zapperY2 = rnd.Next(88, 338);               
                zap2.Location = new Point(1225, zapperY2);
                ZapperOrientation();
            }
            else if (bg3.Location.X <= -504)
            {
                zapperY3 = rnd.Next(88, 338);                
                zap3.Location = new Point(1225, zapperY2);
                ZapperOrientation();
            }
                
        }
        private void ZapperOrientation()
        {
            z_rotation = rnd.Next(1,4);
            if (bg1.Location.X <= -504)
            {
                
            }
            else if (bg2.Location.X <= -504)
            {

            }
            else if (bg2.Location.X <= -504)
            {

            }
        }
        private void ZapperMovement()
        {
            for (int i = 0; i < ZapList.Count; i++)
            {
                ZapList[i].Left -= zapMove;
            }
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
            }
            if(e.KeyCode == Keys.Space ||e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                grav=true;
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
            }      
            if(pbBarry.Location.X>260 && go==false)
            {
                pbBarry.Location = new Point(260, pbBarry.Location.Y);
                go = true;
            }
        }

        
    }
}
