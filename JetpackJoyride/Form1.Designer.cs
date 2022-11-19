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
            this.bgstart = new System.Windows.Forms.PictureBox();
            this.bg3 = new System.Windows.Forms.PictureBox();
            this.bg2 = new System.Windows.Forms.PictureBox();
            this.bg1 = new System.Windows.Forms.PictureBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.txtStart = new System.Windows.Forms.Label();
            this.pbBarry = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bgstart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarry)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrAnimate
            // 
            this.tmrAnimate.Interval = 5;
            this.tmrAnimate.Tick += new System.EventHandler(this.tmrAnimate_Tick);
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
            this.bg3.Image = ((System.Drawing.Image)(resources.GetObject("bg3.Image")));
            this.bg3.Location = new System.Drawing.Point(929, 0);
            this.bg3.Name = "bg3";
            this.bg3.Size = new System.Drawing.Size(508, 720);
            this.bg3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bg3.TabIndex = 2;
            this.bg3.TabStop = false;
            // 
            // bg2
            // 
            this.bg2.Image = ((System.Drawing.Image)(resources.GetObject("bg2.Image")));
            this.bg2.Location = new System.Drawing.Point(506, 0);
            this.bg2.Name = "bg2";
            this.bg2.Size = new System.Drawing.Size(508, 720);
            this.bg2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bg2.TabIndex = 1;
            this.bg2.TabStop = false;
            // 
            // bg1
            // 
            this.bg1.Image = global::JetpackJoyride.Properties.Resources.background;
            this.bg1.Location = new System.Drawing.Point(0, 0);
            this.bg1.Name = "bg1";
            this.bg1.Size = new System.Drawing.Size(508, 720);
            this.bg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bg1.TabIndex = 0;
            this.bg1.TabStop = false;
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Image = global::JetpackJoyride.Properties.Resources.JetpackJoyride;
            this.pbLogo.Location = new System.Drawing.Point(170, 118);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(624, 348);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLogo.TabIndex = 4;
            this.pbLogo.TabStop = false;
            // 
            // txtStart
            // 
            this.txtStart.AutoSize = true;
            this.txtStart.BackColor = System.Drawing.Color.Transparent;
            this.txtStart.Font = new System.Drawing.Font("New Athletic M54", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStart.ForeColor = System.Drawing.SystemColors.Control;
            this.txtStart.Location = new System.Drawing.Point(334, 469);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(313, 38);
            this.txtStart.TabIndex = 5;
            this.txtStart.Text = "Press Space to Start";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JetpackJoyride.Properties.Resources.bgstart1;
            this.ClientSize = new System.Drawing.Size(986, 692);
            this.Controls.Add(this.pbBarry);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.bgstart);
            this.Controls.Add(this.bg3);
            this.Controls.Add(this.bg2);
            this.Controls.Add(this.bg1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Jetpack Joyride";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bgstart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarry)).EndInit();
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
        private System.Windows.Forms.Label txtStart;
        private System.Windows.Forms.PictureBox pbBarry;
    }
}

