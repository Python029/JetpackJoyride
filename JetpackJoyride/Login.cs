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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        bool close = true;
        private void btnGuest_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("If you continue as a guest, any scores you accumulate will not be saved.\nIf you want to create an account, click Cancel. Otherwise click Ok", "Are you sure you want to continue?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                close = false;
                this.Close();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason==CloseReason.UserClosing && close)
            {
                Application.Exit();
            }
        }
    }
}
