namespace JetpackJoyride
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lbLogin = new System.Windows.Forms.Label();
            this.lbCreate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnGuest = new System.Windows.Forms.Button();
            this.txtUCreate = new System.Windows.Forms.TextBox();
            this.txtULogin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPLogin = new System.Windows.Forms.TextBox();
            this.txtPCreate = new System.Windows.Forms.TextBox();
            this.ckLoginShow = new System.Windows.Forms.CheckBox();
            this.ckCreateShow = new System.Windows.Forms.CheckBox();
            this.btnLoginHelp = new System.Windows.Forms.Button();
            this.btnCreateHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.BackColor = System.Drawing.Color.Transparent;
            this.lbLogin.Font = new System.Drawing.Font("Hurme Geometric Sans 1", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogin.ForeColor = System.Drawing.Color.White;
            this.lbLogin.Image = global::JetpackJoyride.Properties.Resources.LoginTextbg;
            this.lbLogin.Location = new System.Drawing.Point(146, 30);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(110, 45);
            this.lbLogin.TabIndex = 0;
            this.lbLogin.Text = "Login";
            // 
            // lbCreate
            // 
            this.lbCreate.AutoSize = true;
            this.lbCreate.BackColor = System.Drawing.Color.Transparent;
            this.lbCreate.Font = new System.Drawing.Font("Hurme Geometric Sans 1", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreate.ForeColor = System.Drawing.Color.White;
            this.lbCreate.Image = global::JetpackJoyride.Properties.Resources.LoginCreatebg;
            this.lbCreate.Location = new System.Drawing.Point(448, 30);
            this.lbCreate.Name = "lbCreate";
            this.lbCreate.Size = new System.Drawing.Size(333, 45);
            this.lbCreate.TabIndex = 1;
            this.lbCreate.Text = "Create an Account";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::JetpackJoyride.Properties.Resources.LoginPanelbg;
            this.panel1.Location = new System.Drawing.Point(403, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 338);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Hurme Geometric Sans 1", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::JetpackJoyride.Properties.Resources.LoginPassbg2;
            this.label1.Location = new System.Drawing.Point(441, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Hurme Geometric Sans 1", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Image = global::JetpackJoyride.Properties.Resources.LoginUserbg2;
            this.label2.Location = new System.Drawing.Point(433, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username:";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Hurme Geometric Sans 1", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(123, 264);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(145, 69);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Hurme Geometric Sans 1", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(517, 260);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(190, 73);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "Create Account";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnGuest
            // 
            this.btnGuest.Font = new System.Drawing.Font("Hurme Geometric Sans 1", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuest.Location = new System.Drawing.Point(331, 356);
            this.btnGuest.Name = "btnGuest";
            this.btnGuest.Size = new System.Drawing.Size(154, 73);
            this.btnGuest.TabIndex = 10;
            this.btnGuest.Text = "Continue as Guest";
            this.btnGuest.UseVisualStyleBackColor = true;
            this.btnGuest.Click += new System.EventHandler(this.btnGuest_Click);
            // 
            // txtUCreate
            // 
            this.txtUCreate.Font = new System.Drawing.Font("Hurme Geometric Sans 1", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUCreate.Location = new System.Drawing.Point(589, 112);
            this.txtUCreate.Multiline = true;
            this.txtUCreate.Name = "txtUCreate";
            this.txtUCreate.Size = new System.Drawing.Size(184, 41);
            this.txtUCreate.TabIndex = 13;
            this.txtUCreate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtULogin
            // 
            this.txtULogin.BackColor = System.Drawing.SystemColors.Window;
            this.txtULogin.Font = new System.Drawing.Font("Hurme Geometric Sans 1", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtULogin.Location = new System.Drawing.Point(179, 112);
            this.txtULogin.Multiline = true;
            this.txtULogin.Name = "txtULogin";
            this.txtULogin.Size = new System.Drawing.Size(184, 41);
            this.txtULogin.TabIndex = 17;
            this.txtULogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Hurme Geometric Sans 1", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Image = global::JetpackJoyride.Properties.Resources.LoginUserbg;
            this.label3.Location = new System.Drawing.Point(23, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 35);
            this.label3.TabIndex = 16;
            this.label3.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Hurme Geometric Sans 1", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Image = global::JetpackJoyride.Properties.Resources.LoginPassbg;
            this.label4.Location = new System.Drawing.Point(31, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 35);
            this.label4.TabIndex = 15;
            this.label4.Text = "Password:";
            // 
            // txtPLogin
            // 
            this.txtPLogin.Font = new System.Drawing.Font("Hurme Geometric Sans 1", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPLogin.Location = new System.Drawing.Point(179, 185);
            this.txtPLogin.MaxLength = 8;
            this.txtPLogin.Multiline = true;
            this.txtPLogin.Name = "txtPLogin";
            this.txtPLogin.PasswordChar = '●';
            this.txtPLogin.Size = new System.Drawing.Size(184, 41);
            this.txtPLogin.TabIndex = 19;
            this.txtPLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPCreate
            // 
            this.txtPCreate.Font = new System.Drawing.Font("Hurme Geometric Sans 1", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPCreate.Location = new System.Drawing.Point(589, 185);
            this.txtPCreate.MaxLength = 8;
            this.txtPCreate.Multiline = true;
            this.txtPCreate.Name = "txtPCreate";
            this.txtPCreate.Size = new System.Drawing.Size(184, 41);
            this.txtPCreate.TabIndex = 20;
            this.txtPCreate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ckLoginShow
            // 
            this.ckLoginShow.AutoSize = true;
            this.ckLoginShow.Location = new System.Drawing.Point(215, 232);
            this.ckLoginShow.Name = "ckLoginShow";
            this.ckLoginShow.Size = new System.Drawing.Size(102, 17);
            this.ckLoginShow.TabIndex = 21;
            this.ckLoginShow.Text = "Show Password";
            this.ckLoginShow.UseVisualStyleBackColor = true;
            this.ckLoginShow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ckLoginShow_MouseDown);
            // 
            // ckCreateShow
            // 
            this.ckCreateShow.AutoSize = true;
            this.ckCreateShow.Location = new System.Drawing.Point(625, 232);
            this.ckCreateShow.Name = "ckCreateShow";
            this.ckCreateShow.Size = new System.Drawing.Size(102, 17);
            this.ckCreateShow.TabIndex = 22;
            this.ckCreateShow.Text = "Show Password";
            this.ckCreateShow.UseVisualStyleBackColor = true;
            // 
            // btnLoginHelp
            // 
            this.btnLoginHelp.Font = new System.Drawing.Font("Hurme Geometric Sans 1", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginHelp.Location = new System.Drawing.Point(123, 339);
            this.btnLoginHelp.Name = "btnLoginHelp";
            this.btnLoginHelp.Size = new System.Drawing.Size(145, 40);
            this.btnLoginHelp.TabIndex = 23;
            this.btnLoginHelp.Text = "Help";
            this.btnLoginHelp.UseVisualStyleBackColor = true;
            this.btnLoginHelp.Click += new System.EventHandler(this.btnLoginHelp_Click);
            // 
            // btnCreateHelp
            // 
            this.btnCreateHelp.Font = new System.Drawing.Font("Hurme Geometric Sans 1", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateHelp.Location = new System.Drawing.Point(517, 339);
            this.btnCreateHelp.Name = "btnCreateHelp";
            this.btnCreateHelp.Size = new System.Drawing.Size(190, 40);
            this.btnCreateHelp.TabIndex = 24;
            this.btnCreateHelp.Text = "Help";
            this.btnCreateHelp.UseVisualStyleBackColor = true;
            this.btnCreateHelp.Click += new System.EventHandler(this.btnCreateHelp_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JetpackJoyride.Properties.Resources.wp3804050;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 441);
            this.Controls.Add(this.btnCreateHelp);
            this.Controls.Add(this.btnLoginHelp);
            this.Controls.Add(this.ckCreateShow);
            this.Controls.Add(this.ckLoginShow);
            this.Controls.Add(this.txtPCreate);
            this.Controls.Add(this.txtPLogin);
            this.Controls.Add(this.txtULogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUCreate);
            this.Controls.Add(this.btnGuest);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbCreate);
            this.Controls.Add(this.lbLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.Label lbCreate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnGuest;
        private System.Windows.Forms.TextBox txtUCreate;
        private System.Windows.Forms.TextBox txtULogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPLogin;
        private System.Windows.Forms.TextBox txtPCreate;
        private System.Windows.Forms.CheckBox ckLoginShow;
        private System.Windows.Forms.CheckBox ckCreateShow;
        private System.Windows.Forms.Button btnLoginHelp;
        private System.Windows.Forms.Button btnCreateHelp;
    }
}