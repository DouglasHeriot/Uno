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
            Uno.Player player1 = new Uno.Player();
            Uno.Player player2 = new Uno.Player();
            Uno.Player player3 = new Uno.Player();
            Uno.Player player4 = new Uno.Player();
            this.newGameButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.sortedPlayerView4 = new Uno.SortedPlayerView();
            this.sortedPlayerView3 = new Uno.SortedPlayerView();
            this.sortedPlayerView2 = new Uno.SortedPlayerView();
            this.sortedPlayerView1 = new Uno.SortedPlayerView();
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(167, 420);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(92, 44);
            this.newGameButton.TabIndex = 2;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(27, 420);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(92, 44);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // sortedPlayerView4
            // 
            this.sortedPlayerView4.BackColor = System.Drawing.Color.Transparent;
            this.sortedPlayerView4.Location = new System.Drawing.Point(27, 294);
            this.sortedPlayerView4.Name = "sortedPlayerView4";
            player1.Name = null;
            player1.Score = 0;
            player1.Type = Uno.Player.PlayerType.Human;
            this.sortedPlayerView4.Player = player1;
            this.sortedPlayerView4.Size = new System.Drawing.Size(232, 88);
            this.sortedPlayerView4.TabIndex = 6;
            // 
            // sortedPlayerView3
            // 
            this.sortedPlayerView3.BackColor = System.Drawing.Color.Transparent;
            this.sortedPlayerView3.Location = new System.Drawing.Point(27, 200);
            this.sortedPlayerView3.Name = "sortedPlayerView3";
            player2.Name = null;
            player2.Score = 0;
            player2.Type = Uno.Player.PlayerType.Human;
            this.sortedPlayerView3.Player = player2;
            this.sortedPlayerView3.Size = new System.Drawing.Size(232, 88);
            this.sortedPlayerView3.TabIndex = 5;
            // 
            // sortedPlayerView2
            // 
            this.sortedPlayerView2.BackColor = System.Drawing.Color.Transparent;
            this.sortedPlayerView2.Location = new System.Drawing.Point(27, 106);
            this.sortedPlayerView2.Name = "sortedPlayerView2";
            player3.Name = null;
            player3.Score = 0;
            player3.Type = Uno.Player.PlayerType.Human;
            this.sortedPlayerView2.Player = player3;
            this.sortedPlayerView2.Size = new System.Drawing.Size(232, 88);
            this.sortedPlayerView2.TabIndex = 4;
            // 
            // sortedPlayerView1
            // 
            this.sortedPlayerView1.BackColor = System.Drawing.Color.Transparent;
            this.sortedPlayerView1.Location = new System.Drawing.Point(27, 12);
            this.sortedPlayerView1.Name = "sortedPlayerView1";
            player4.Name = null;
            player4.Score = 0;
            player4.Type = Uno.Player.PlayerType.Human;
            this.sortedPlayerView1.Player = player4;
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
            this.Controls.Add(this.sortedPlayerView4);
            this.Controls.Add(this.sortedPlayerView3);
            this.Controls.Add(this.sortedPlayerView2);
            this.Controls.Add(this.sortedPlayerView1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.newGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SortedPlayersView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Final Scores";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button exitButton;
        private SortedPlayerView sortedPlayerView1;
        private SortedPlayerView sortedPlayerView2;
        private SortedPlayerView sortedPlayerView3;
        private SortedPlayerView sortedPlayerView4;
    }
}