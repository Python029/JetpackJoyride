﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using JetpackJoyride.Properties;
using System.Runtime.InteropServices;
using System.Drawing.Text;

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
        PrivateFontCollection pfc = new PrivateFontCollection();
        bool u = false;
        bool p = false;
        bool ue=false;
        bool pe = false;
        int ui = 0;
        int pi = 0;
        bool Lshow = false;
        bool Cshow=false;
        string user = "";
        string pass = "";
        string LoginPath = "J:\\CS\\Silvera_JetpackJoyride\\JetpackJoyrideLogin.csv";
        string HomeLoginPath = "C:\\Users\\Silve\\OneDrive\\Documents\\JetpackJoyrideLogin.csv";
        private void Login_Load(object sender, EventArgs e)
        {
            CustomFont();
            ReadCSVFile();
            ShowHideLogin();
            ShowHideCreate();
        }
        private void btnGuest_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("If you continue as a guest, any scores you accumulate will not be saved.\nIf you want to create an account, click Cancel. Otherwise click Ok", "Are you sure you want to continue?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                Properties.Settings.Default.Guest = true;
                Properties.Settings.Default.Save();
                close = false;
                this.Close();
            }
        }
        private void CustomFont()
        {
            int fontLength = Resources.GeometricSans.Length;
            byte[] fontdata = Resources.GeometricSans;
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
            lblLogin.Font = new Font(pfc.Families[0], lblLogin.Font.Size);
            lblCreate.Font = new Font(pfc.Families[0], lblCreate.Font.Size);
            label1.Font = new Font(pfc.Families[0], label1.Font.Size);
            label2.Font = new Font(pfc.Families[0], label2.Font.Size);
            label3.Font = new Font(pfc.Families[0], label3.Font.Size);
            label4.Font = new Font(pfc.Families[0], label4.Font.Size);
            ckLoginShow.Font = new Font(pfc.Families[0], ckLoginShow.Font.Size);
            ckCreateShow.Font = new Font(pfc.Families[0], ckCreateShow.Font.Size);
            btnLogin.Font = new Font(pfc.Families[0], btnLogin.Font.Size);
            btnLoginHelp.Font = new Font(pfc.Families[0], btnLoginHelp.Font.Size);
            btnCreate.Font = new Font(pfc.Families[0], btnCreate.Font.Size);
            btnCreateHelp.Font = new Font(pfc.Families[0], btnCreateHelp.Font.Size);
            btnGuest.Font = new Font(pfc.Families[0], btnGuest.Font.Size);
        }
        private void ReadCSVFile()
        {
            try
            {
                string[] credentials = File.ReadAllLines(LoginPath);
                for (int i = 0; i < credentials.Length; i++)
                {
                    string[] rowdata = credentials[i].Split(',');
                    username.Add(rowdata[0]);
                    if (username[0] == "")
                    {
                        username.Clear();
                        File.WriteAllText(LoginPath, string.Empty);
                        break;
                    }
                    else if (username[0] != "")
                    {
                        password.Add(rowdata[1]);
                    }
                }
            }
            catch
            {
                MessageBox.Show("The file containing all login credentials cannot be accessed.","File Inaccessible", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ShowHideLogin()
        {
            if (Lshow == false)
            {
                txtPLogin.PasswordChar = '*';
                Lshow = true;
            }
            else if (Lshow)
            {
                txtPLogin.PasswordChar = '\0';
                Lshow = false;            
            }
        }
        private void ShowHideCreate()
        {
            if (Cshow == false)
            {
                txtPCreate.PasswordChar = '*';
                Cshow = true;
            }
            else if (Cshow)
            {
                txtPCreate.PasswordChar = '\0';
                Cshow = false;
            }
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
            if(username.Count== 0)
            {
                MessageBox.Show("There are no existing accounts. Please create one instead.","Login Database Empty",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if(username.Count>0)
            {
                if (txtULogin.Text.Length > 0 && txtPLogin.Text.Length > 0)
                {
                    for (int i = 0; i < username.Count; i++)
                    {
                        if (txtULogin.Text == username[i])
                        {
                            u = true;
                            ui = i;
                        }
                        else if (u == false)
                        {
                            u = false;
                        }
                    }
                    for (int i = 0; i < password.Count; i++)
                    {
                        if (txtPLogin.Text == password[i])
                        {
                            p = true;
                            pi = i;
                        }
                        else if (p == false)
                        {
                            p = false;
                        }
                    }
                    if (u && p && ui == pi)
                    {
                        txtULogin.BackColor = Color.ForestGreen;
                        txtPLogin.BackColor = Color.ForestGreen;
                        Properties.Settings.Default.Username = txtULogin.Text;
                        Properties.Settings.Default.Guest = false;
                        Properties.Settings.Default.Save();
                        MessageBox.Show($"Welcome Back, {Properties.Settings.Default.Username}.", "Login Sucessful");
                        close = false;
                        this.Close();
                    }
                    else if (u && p && ui != pi)
                    {
                        txtULogin.BackColor = Color.Gold;
                        txtPLogin.BackColor = Color.Gold;
                    }
                    else if (u && p == false)
                    {
                        txtULogin.BackColor = Color.ForestGreen;
                        txtPLogin.BackColor = Color.FromArgb(194, 41, 46);
                    }
                    else if (u == false && p)
                    {
                        txtULogin.BackColor = Color.FromArgb(194, 41, 46);
                        txtPLogin.BackColor = Color.ForestGreen;
                    }
                    else if (u == false && p == false)
                    {
                        txtULogin.BackColor = Color.FromArgb(194, 41, 46);
                        txtPLogin.BackColor = Color.FromArgb(194, 41, 46);
                    }
                }
            }
           
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtUCreate.Text.Length > 0 && txtPCreate.Text.Length > 0)
            {
                user = txtUCreate.Text;
                pass = txtPCreate.Text;
                for (int i = 0; i < username.Count; i++)
                {
                    if (txtUCreate.Text.ToLower() == username[i].ToLower())
                    {
                        ue = true;
                    }
                    else if (ue == false)
                    {
                        ue = false;
                    }
                }
                for (int i = 0; i < password.Count; i++)
                {
                    if (txtPCreate.Text.ToLower() == password[i].ToLower())
                    {
                        pe = true;
                    }
                    else if (pe == false)
                    {
                        pe = false;
                    }
                }
                if (ue && pe)
                {
                    txtUCreate.BackColor = Color.FromArgb(194, 41, 46);
                    txtPCreate.BackColor = Color.FromArgb(194, 41, 46);
                }
                if (pe && ue == false)
                {
                    txtUCreate.BackColor = Color.ForestGreen;
                    txtPCreate.BackColor = Color.FromArgb(194, 41, 46);
                }
                else if (ue && pe == false)
                {
                    txtUCreate.BackColor = Color.FromArgb(194, 41, 46);
                    txtPCreate.BackColor = Color.ForestGreen;
                }
                else if (ue == false && pe == false)
                {
                    txtUCreate.BackColor = Color.ForestGreen;
                    txtPCreate.BackColor = Color.ForestGreen;
                    Properties.Settings.Default.Username = txtUCreate.Text;
                    Properties.Settings.Default.Guest = false;
                    Properties.Settings.Default.Save();
                    MessageBox.Show($"Welcome, {Properties.Settings.Default.Username}.", "Account Sucessfully Created");
                    username.Add(user);
                    password.Add(pass);
                    string newuser = ($"{user},{pass}\n");
                    File.AppendAllText(LoginPath, newuser);
                    close = false;
                    this.Close();
                }
            }
        }
        private void ckLoginShow_MouseDown(object sender, MouseEventArgs e)
        {
            ShowHideLogin();
        }
        private void btnLoginHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("●If the username box turns red and the password box is green, the username is not correct, but the password is.\n\n●If the password box turns red and the username box is green, the password is not correct, but the username is.\n\n●If both turn red, then the account does not exist and should be created.\n\n●If both boxes turn yellow, then there is a mismatch between an existing username and password.\n\n●Username and Password must each include at least 1 letter each.\n\n●Max Length for a username is 11 characters.\n●Max Length for a password is 8 characters.", "Login Help",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void btnCreateHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("●If the username box turns red and the password box is green, the username already exists, but the password can be used.\n\n●If the password box turns red and the username box is green, the password already exists, but the username can be used.\n\n●If both turn red, then you may login with the credentials you used.\n\n●Username and Password must each include at least 1 letter each.\n\n●Max Length for a username is 11 characters.\n●Max Length for a password is 8 characters.", "Login Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ckCreateShow_MouseDown(object sender, MouseEventArgs e)
        {
            ShowHideCreate();
        }       
        private void txtPLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                btnLogin.Focus();
                SendKeys.Send("{ENTER}");
            }
        }
        private void txtPCreate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCreate.Focus();
                SendKeys.Send("{ENTER}");
            }
        }
        #region Reset Match Booleans
        private void txtULogin_TextChanged(object sender, EventArgs e)
        {
            u = false;
        }
        private void txtPLogin_TextChanged(object sender, EventArgs e)
        {
            p = false;
        }
        private void txtUCreate_TextChanged(object sender, EventArgs e)
        {
            ue = false;
        }
        private void txtPCreate_TextChanged(object sender, EventArgs e)
        {
            pe = false;
        }
        #endregion
    }
}
