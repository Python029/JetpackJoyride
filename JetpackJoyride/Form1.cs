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
        private void Form1_Load(object sender, EventArgs e)
        {

            bg3.Location = new Point(1012, 0);
            for(int i = 1; i<4;i++)
            {
                PictureBox pb = (PictureBox)this.Controls["bg" + i.ToString()];
                bgList.Add(pb);
            }
        }

        private void tmrAnimate_Tick(object sender, EventArgs e)
        {
            Background();
        }
        private void Background()
        {
            for(int i = 0; i<bgList.Count;i++)
            {
                if (bgList[i].Location.X<-500) { bgList[i].Location = new Point(1012,0); }
                bgList[i].Left -= 2;
            }
        }
    }
}
