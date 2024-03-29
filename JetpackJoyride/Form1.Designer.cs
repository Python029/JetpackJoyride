﻿namespace JetpackJoyride
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tmrAnimate = new System.Windows.Forms.Timer(this.components);
            this.lblStart = new System.Windows.Forms.Label();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.Label();
            this.lblHighscore = new System.Windows.Forms.Label();
            this.tmrScore = new System.Windows.Forms.Timer(this.components);
            this.pnHigh = new System.Windows.Forms.Panel();
            this.pnInfo = new System.Windows.Forms.Panel();
            this.pnE1 = new System.Windows.Forms.Panel();
            this.pnE2 = new System.Windows.Forms.Panel();
            this.pbControls = new System.Windows.Forms.PictureBox();
            this.pbScore = new System.Windows.Forms.PictureBox();
            this.pbBarry = new System.Windows.Forms.PictureBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.bgstart = new System.Windows.Forms.PictureBox();
            this.bg3 = new System.Windows.Forms.PictureBox();
            this.bg2 = new System.Windows.Forms.PictureBox();
            this.bg1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgstart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrAnimate
            // 
            this.tmrAnimate.Interval = 5;
            this.tmrAnimate.Tick += new System.EventHandler(this.tmrAnimate_Tick);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.BackColor = System.Drawing.Color.Transparent;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.ForeColor = System.Drawing.SystemColors.Control;
            this.lblStart.Location = new System.Drawing.Point(334, 493);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(312, 44);
            this.lblStart.TabIndex = 5;
            this.lblStart.Text = "Press Space to Start";
            this.lblStart.UseCompatibleTextRendering = true;
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 1;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblScore.Location = new System.Drawing.Point(24, 3);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(129, 50);
            this.lblScore.TabIndex = 8;
            this.lblScore.Text = "0000m";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScore.UseCompatibleTextRendering = true;
            // 
            // lblHighscore
            // 
            this.lblHighscore.AutoSize = true;
            this.lblHighscore.BackColor = System.Drawing.Color.Transparent;
            this.lblHighscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighscore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(69)))), ((int)(((byte)(97)))));
            this.lblHighscore.Location = new System.Drawing.Point(773, 480);
            this.lblHighscore.Name = "lblHighscore";
            this.lblHighscore.Size = new System.Drawing.Size(88, 35);
            this.lblHighscore.TabIndex = 9;
            this.lblHighscore.Text = "0000M";
            this.lblHighscore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblHighscore.UseCompatibleTextRendering = true;
            // 
            // tmrScore
            // 
            this.tmrScore.Tick += new System.EventHandler(this.tmrScore_Tick);
            // 
            // pnHigh
            // 
            this.pnHigh.BackColor = System.Drawing.Color.Transparent;
            this.pnHigh.Location = new System.Drawing.Point(764, 456);
            this.pnHigh.Name = "pnHigh";
            this.pnHigh.Size = new System.Drawing.Size(88, 55);
            this.pnHigh.TabIndex = 10;
            this.pnHigh.Click += new System.EventHandler(this.pnHigh_Click);
            // 
            // pnInfo
            // 
            this.pnInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnInfo.Location = new System.Drawing.Point(379, 108);
            this.pnInfo.Name = "pnInfo";
            this.pnInfo.Size = new System.Drawing.Size(204, 70);
            this.pnInfo.TabIndex = 11;
            this.pnInfo.Click += new System.EventHandler(this.pnInfo_Click);
            // 
            // pnE1
            // 
            this.pnE1.BackColor = System.Drawing.Color.Transparent;
            this.pnE1.Location = new System.Drawing.Point(54, 548);
            this.pnE1.Name = "pnE1";
            this.pnE1.Size = new System.Drawing.Size(69, 42);
            this.pnE1.TabIndex = 12;
            this.pnE1.Click += new System.EventHandler(this.pnE1_Click);
            // 
            // pnE2
            // 
            this.pnE2.BackColor = System.Drawing.Color.Transparent;
            this.pnE2.Location = new System.Drawing.Point(109, 464);
            this.pnE2.Name = "pnE2";
            this.pnE2.Size = new System.Drawing.Size(82, 78);
            this.pnE2.TabIndex = 13;
            this.pnE2.Click += new System.EventHandler(this.pnE2_Click);
            // 
            // pbControls
            // 
            this.pbControls.BackColor = System.Drawing.Color.Transparent;
            this.pbControls.Image = global::JetpackJoyride.Properties.Resources.joystick;
            this.pbControls.Location = new System.Drawing.Point(12, 61);
            this.pbControls.Name = "pbControls";
            this.pbControls.Size = new System.Drawing.Size(80, 74);
            this.pbControls.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbControls.TabIndex = 14;
            this.pbControls.TabStop = false;
            this.pbControls.Click += new System.EventHandler(this.pbControls_Click);
            // 
            // pbScore
            // 
            this.pbScore.BackColor = System.Drawing.Color.Transparent;
            this.pbScore.Image = global::JetpackJoyride.Properties.Resources._227297_jj1;
            this.pbScore.Location = new System.Drawing.Point(0, 0);
            this.pbScore.Name = "pbScore";
            this.pbScore.Size = new System.Drawing.Size(155, 55);
            this.pbScore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbScore.TabIndex = 7;
            this.pbScore.TabStop = false;
            // 
            // pbBarry
            // 
            this.pbBarry.BackColor = System.Drawing.Color.Transparent;
            this.pbBarry.Image = global::JetpackJoyride.Properties.Resources.running1;
            this.pbBarry.Location = new System.Drawing.Point(260, 548);
            this.pbBarry.Name = "pbBarry";
            this.pbBarry.Size = new System.Drawing.Size(48, 56);
            this.pbBarry.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbBarry.TabIndex = 6;
            this.pbBarry.TabStop = false;
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbLogo.Image = global::JetpackJoyride.Properties.Resources.JetpackJoyride;
            this.pbLogo.Location = new System.Drawing.Point(197, 177);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(561, 313);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 4;
            this.pbLogo.TabStop = false;
            // 
            // bgstart
            // 
            this.bgstart.Image = global::JetpackJoyride.Properties.Resources.bgstart1;
            this.bgstart.Location = new System.Drawing.Point(0, 0);
            this.bgstart.Name = "bgstart";
            this.bgstart.Size = new System.Drawing.Size(960, 720);
            this.bgstart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bgstart.TabIndex = 3;
            this.bgstart.TabStop = false;
            // 
            // bg3
            // 
            this.bg3.Image = global::JetpackJoyride.Properties.Resources.background;
            this.bg3.Location = new System.Drawing.Point(929, -12);
            this.bg3.Name = "bg3";
            this.bg3.Size = new System.Drawing.Size(508, 713);
            this.bg3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bg3.TabIndex = 2;
            this.bg3.TabStop = false;
            // 
            // bg2
            // 
            this.bg2.Image = global::JetpackJoyride.Properties.Resources.background;
            this.bg2.Location = new System.Drawing.Point(506, 0);
            this.bg2.Name = "bg2";
            this.bg2.Size = new System.Drawing.Size(508, 713);
            this.bg2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bg2.TabIndex = 1;
            this.bg2.TabStop = false;
            // 
            // bg1
            // 
            this.bg1.Image = global::JetpackJoyride.Properties.Resources.background;
            this.bg1.Location = new System.Drawing.Point(0, 0);
            this.bg1.Name = "bg1";
            this.bg1.Size = new System.Drawing.Size(508, 713);
            this.bg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bg1.TabIndex = 0;
            this.bg1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 692);
            this.Controls.Add(this.pbControls);
            this.Controls.Add(this.pnE2);
            this.Controls.Add(this.pnE1);
            this.Controls.Add(this.pnInfo);
            this.Controls.Add(this.pnHigh);
            this.Controls.Add(this.lblHighscore);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pbScore);
            this.Controls.Add(this.pbBarry);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.bgstart);
            this.Controls.Add(this.bg3);
            this.Controls.Add(this.bg2);
            this.Controls.Add(this.bg1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jetpack Joyride";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgstart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bg1;
        private System.Windows.Forms.PictureBox bg2;
        private System.Windows.Forms.Timer tmrAnimate;
        private System.Windows.Forms.PictureBox bg3;
        private System.Windows.Forms.PictureBox bgstart;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.PictureBox pbBarry;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.PictureBox pbScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblHighscore;
        private System.Windows.Forms.Timer tmrScore;
        private System.Windows.Forms.Panel pnHigh;
        private System.Windows.Forms.Panel pnInfo;
        private System.Windows.Forms.Panel pnE1;
        private System.Windows.Forms.Panel pnE2;
        private System.Windows.Forms.PictureBox pbControls;
    }
}

