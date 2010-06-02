namespace Uno
{
    partial class SortedPlayersView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SortedPlayersView));
            this.newGameButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.moreDetailCheckBox = new System.Windows.Forms.CheckBox();
            this.scoringMethodLabel = new System.Windows.Forms.Label();
            this.sortedPlayerView4 = new Uno.SortedPlayerView();
            this.sortedPlayerView3 = new Uno.SortedPlayerView();
            this.sortedPlayerView2 = new Uno.SortedPlayerView();
            this.sortedPlayerView1 = new Uno.SortedPlayerView();
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newGameButton.Location = new System.Drawing.Point(167, 433);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(92, 44);
            this.newGameButton.TabIndex = 2;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitButton.Location = new System.Drawing.Point(27, 433);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(92, 44);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // moreDetailCheckBox
            // 
            this.moreDetailCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moreDetailCheckBox.AutoSize = true;
            this.moreDetailCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.moreDetailCheckBox.ForeColor = System.Drawing.Color.Black;
            this.moreDetailCheckBox.Location = new System.Drawing.Point(179, 401);
            this.moreDetailCheckBox.Name = "moreDetailCheckBox";
            this.moreDetailCheckBox.Size = new System.Drawing.Size(80, 17);
            this.moreDetailCheckBox.TabIndex = 0;
            this.moreDetailCheckBox.Text = "More Detail";
            this.moreDetailCheckBox.UseVisualStyleBackColor = false;
            this.moreDetailCheckBox.CheckedChanged += new System.EventHandler(this.moreDetailCheckBox_CheckedChanged);
            // 
            // scoringMethodLabel
            // 
            this.scoringMethodLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.scoringMethodLabel.AutoSize = true;
            this.scoringMethodLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoringMethodLabel.Location = new System.Drawing.Point(24, 402);
            this.scoringMethodLabel.Name = "scoringMethodLabel";
            this.scoringMethodLabel.Size = new System.Drawing.Size(80, 13);
            this.scoringMethodLabel.TabIndex = 7;
            this.scoringMethodLabel.Text = "Scoring System";
            // 
            // sortedPlayerView4
            // 
            this.sortedPlayerView4.BackColor = System.Drawing.Color.White;
            this.sortedPlayerView4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sortedPlayerView4.BackgroundImage")));
            this.sortedPlayerView4.Location = new System.Drawing.Point(27, 294);
            this.sortedPlayerView4.Name = "sortedPlayerView4";
            this.sortedPlayerView4.Size = new System.Drawing.Size(232, 88);
            this.sortedPlayerView4.TabIndex = 6;
            // 
            // sortedPlayerView3
            // 
            this.sortedPlayerView3.BackColor = System.Drawing.Color.White;
            this.sortedPlayerView3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sortedPlayerView3.BackgroundImage")));
            this.sortedPlayerView3.Location = new System.Drawing.Point(27, 200);
            this.sortedPlayerView3.Name = "sortedPlayerView3";
            this.sortedPlayerView3.Size = new System.Drawing.Size(232, 88);
            this.sortedPlayerView3.TabIndex = 5;
            // 
            // sortedPlayerView2
            // 
            this.sortedPlayerView2.BackColor = System.Drawing.Color.White;
            this.sortedPlayerView2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sortedPlayerView2.BackgroundImage")));
            this.sortedPlayerView2.Location = new System.Drawing.Point(27, 106);
            this.sortedPlayerView2.Name = "sortedPlayerView2";
            this.sortedPlayerView2.Size = new System.Drawing.Size(232, 88);
            this.sortedPlayerView2.TabIndex = 4;
            // 
            // sortedPlayerView1
            // 
            this.sortedPlayerView1.BackColor = System.Drawing.Color.White;
            this.sortedPlayerView1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sortedPlayerView1.BackgroundImage")));
            this.sortedPlayerView1.Location = new System.Drawing.Point(27, 12);
            this.sortedPlayerView1.Name = "sortedPlayerView1";
            this.sortedPlayerView1.Size = new System.Drawing.Size(232, 88);
            this.sortedPlayerView1.TabIndex = 3;
            // 
            // SortedPlayersView
            // 
            this.AcceptButton = this.newGameButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(290, 489);
            this.Controls.Add(this.scoringMethodLabel);
            this.Controls.Add(this.moreDetailCheckBox);
            this.Controls.Add(this.sortedPlayerView4);
            this.Controls.Add(this.sortedPlayerView3);
            this.Controls.Add(this.sortedPlayerView2);
            this.Controls.Add(this.sortedPlayerView1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.newGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SortedPlayersView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Final Uno Scores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button exitButton;
        private SortedPlayerView sortedPlayerView1;
        private SortedPlayerView sortedPlayerView2;
        private SortedPlayerView sortedPlayerView3;
        private SortedPlayerView sortedPlayerView4;
        private System.Windows.Forms.CheckBox moreDetailCheckBox;
        private System.Windows.Forms.Label scoringMethodLabel;
    }
}