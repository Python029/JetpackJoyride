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
        #region Booleans
        bool start = false;
        #endregion
        #region Integers/Doubles
        int bgMove = 4;
        int barryRun = 0;
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            bg1.Location = new Point(959, -28);
            bg2.Location = new Point(1465, -28);
            bg3.Location = new Point(1971, -28);
            pbBarry.BackgroundImageLayout = ImageLayout.None;
            this.BackgroundImageLayout = ImageLayout.None;
            for (int i = 1; i<4;i++)
            {
                PictureBox pb = (PictureBox)this.Controls["bg" + i.ToString()];
                bgList.Add(pb);
            }
        }

        private void tmrAnimate_Tick(object sender, EventArgs e)
        {
            Background();
            Barry();
        }
        private void Background()
        {
            for(int i = 0; i<bgList.Count;i++)
            {
                if (bgList[i].Location.X<-500) { bgList[i].Location = new Point(1012,-28); }
                bgList[i].Left -= bgMove;
            }
            if(bgstart.Location.X>-965)
            {
                bgstart.Left -= bgMove;
            }
            else if(bgstart.Location.X < -965)
            {
                this.Controls.Remove(bgstart);
            }
        }
        private void Barry()
        {
            barryRun++;
            if(barryRun==8)
            {
                pbBarry.Image = Properties.Resources.running2;
            }
            if (barryRun == 16)
            {
                pbBarry.Image = Properties.Resources.running1;
                barryRun = 0;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                tmrAnimate.Enabled = true;
                this.BackgroundImage = null;
                this.Controls.Remove(pbLogo);
                this.Controls.Remove(txtStart);
                bgstart.Image = Properties.Resources.bgstart2;
            }
        }
    }
}
