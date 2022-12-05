using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JetpackJoyride
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        bool close = true;
        List<string> username = new List<string>();
        List<string> password = new List<string>();
        bool u = false;
        bool p = false;
        bool ue=false;
        bool pe = false;
        int ui = 0;
        int pi = 0;
        bool show = false;
        bool theme = true;
        string user = "";
        string pass = "";
        string path = "";
        private void Login_Load(object sender, EventArgs e)
        {
            ShowHide();
        }
        private void btnGuest_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("If you continue as a guest, any scores you accumulate will not be saved.\nIf you want to create an account, click Cancel. Otherwise click Ok", "Are you sure you want to continue?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                close = false;
                this.Close();
            }
        }
        private void ReadCSVFile()
        {
            string[] credentials = File.ReadAllLines(path);
            for (int i = 0; i < credentials.Length; i++)
            {
                string[] rowdata = credentials[i].Split(',');
                username.Add(rowdata[0]);
                password.Add(rowdata[1]);
            }

        }
        private void ShowHide()
        {
            //Login
            if (show == false)
            {
                txtPLogin.PasswordChar = '●';
                show = true;
            }
            else if (show)
            {
                txtPLogin.PasswordChar = '\0';
                show = false;
                
            }
            //Create
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason==CloseReason.UserClosing && close)
            {
                Application.Exit();
            }
        }

       

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }
        private void ckLoginShow_MouseDown(object sender, MouseEventArgs e)
        {
            ShowHide();
        }
    }
}
