namespace JetpackJoyride
{
    partial class Form2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.dgvLeaderboard = new System.Windows.Forms.DataGridView();
            this.Ranks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usernames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.When = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaderboard)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLeaderboard
            // 
            this.dgvLeaderboard.AllowUserToAddRows = false;
            this.dgvLeaderboard.AllowUserToDeleteRows = false;
            this.dgvLeaderboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeaderboard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ranks,
            this.Usernames,
            this.Score,
            this.When});
            this.dgvLeaderboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLeaderboard.Location = new System.Drawing.Point(0, 0);
            this.dgvLeaderboard.Name = "dgvLeaderboard";
            this.dgvLeaderboard.ReadOnly = true;
            this.dgvLeaderboard.Size = new System.Drawing.Size(443, 254);
            this.dgvLeaderboard.TabIndex = 0;
            // 
            // Ranks
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("New Athletic M54", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.Ranks.DefaultCellStyle = dataGridViewCellStyle1;
            this.Ranks.DividerWidth = 5;
            this.Ranks.HeaderText = "Ranks";
            this.Ranks.Name = "Ranks";
            this.Ranks.ReadOnly = true;
            // 
            // Usernames
            // 
            this.Usernames.DividerWidth = 5;
            this.Usernames.HeaderText = "Username";
            this.Usernames.Name = "Usernames";
            this.Usernames.ReadOnly = true;
            // 
            // Score
            // 
            this.Score.DividerWidth = 5;
            this.Score.HeaderText = "Distance";
            this.Score.MaxInputLength = 7;
            this.Score.Name = "Score";
            this.Score.ReadOnly = true;
            // 
            // When
            // 
            this.When.HeaderText = "Date";
            this.When.Name = "When";
            this.When.ReadOnly = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 254);
            this.Controls.Add(this.dgvLeaderboard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leaderboard";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaderboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLeaderboard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ranks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usernames;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn When;
    }
}