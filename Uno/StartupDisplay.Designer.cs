namespace Uno
{
    partial class StartupDisplay
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
            this.label5 = new System.Windows.Forms.Label();
            this.numberOfPlayers = new System.Windows.Forms.NumericUpDown();
            this.startGameButton = new System.Windows.Forms.Button();
            this.gameOptionsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.startupPlayerView4 = new Uno.StartupPlayerView();
            this.startupPlayerView3 = new Uno.StartupPlayerView();
            this.startupPlayerView2 = new Uno.StartupPlayerView();
            this.startupPlayerView1 = new Uno.StartupPlayerView();
            this.quickDebugGameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Number of Players";
            // 
            // numberOfPlayers
            // 
            this.numberOfPlayers.Location = new System.Drawing.Point(113, 119);
            this.numberOfPlayers.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numberOfPlayers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfPlayers.Name = "numberOfPlayers";
            this.numberOfPlayers.Size = new System.Drawing.Size(52, 20);
            this.numberOfPlayers.TabIndex = 4;
            this.numberOfPlayers.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numberOfPlayers.ValueChanged += new System.EventHandler(this.numberOfPlayers_ValueChanged);
            // 
            // startGameButton
            // 
            this.startGameButton.Location = new System.Drawing.Point(12, 193);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(153, 53);
            this.startGameButton.TabIndex = 6;
            this.startGameButton.Text = "Start Game";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // gameOptionsButton
            // 
            this.gameOptionsButton.Location = new System.Drawing.Point(12, 160);
            this.gameOptionsButton.Name = "gameOptionsButton";
            this.gameOptionsButton.Size = new System.Drawing.Size(153, 27);
            this.gameOptionsButton.TabIndex = 5;
            this.gameOptionsButton.Text = "Game Options...";
            this.gameOptionsButton.UseVisualStyleBackColor = true;
            this.gameOptionsButton.Click += new System.EventHandler(this.gameOptionsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 46);
            this.label1.TabIndex = 6;
            this.label1.Text = "Uno";
            // 
            // startupPlayerView4
            // 
            this.startupPlayerView4.FormName = "";
            this.startupPlayerView4.Location = new System.Drawing.Point(221, 192);
            this.startupPlayerView4.Name = "startupPlayerView4";
            this.startupPlayerView4.Size = new System.Drawing.Size(452, 54);
            this.startupPlayerView4.TabIndex = 3;
            // 
            // startupPlayerView3
            // 
            this.startupPlayerView3.FormName = "";
            this.startupPlayerView3.Location = new System.Drawing.Point(221, 132);
            this.startupPlayerView3.Name = "startupPlayerView3";
            this.startupPlayerView3.Size = new System.Drawing.Size(452, 54);
            this.startupPlayerView3.TabIndex = 2;
            // 
            // startupPlayerView2
            // 
            this.startupPlayerView2.FormName = "";
            this.startupPlayerView2.Location = new System.Drawing.Point(221, 72);
            this.startupPlayerView2.Name = "startupPlayerView2";
            this.startupPlayerView2.Size = new System.Drawing.Size(452, 54);
            this.startupPlayerView2.TabIndex = 1;
            // 
            // startupPlayerView1
            // 
            this.startupPlayerView1.FormName = "";
            this.startupPlayerView1.Location = new System.Drawing.Point(221, 12);
            this.startupPlayerView1.Name = "startupPlayerView1";
            this.startupPlayerView1.Size = new System.Drawing.Size(452, 54);
            this.startupPlayerView1.TabIndex = 0;
            // 
            // quickDebugGameButton
            // 
            this.quickDebugGameButton.Location = new System.Drawing.Point(17, 82);
            this.quickDebugGameButton.Name = "quickDebugGameButton";
            this.quickDebugGameButton.Size = new System.Drawing.Size(148, 23);
            this.quickDebugGameButton.TabIndex = 7;
            this.quickDebugGameButton.Text = "Quick Debug Game";
            this.quickDebugGameButton.UseVisualStyleBackColor = true;
            this.quickDebugGameButton.Click += new System.EventHandler(this.quickDebugGameButton_Click);
            // 
            // StartupDisplay
            // 
            this.AcceptButton = this.startGameButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 262);
            this.Controls.Add(this.quickDebugGameButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startupPlayerView4);
            this.Controls.Add(this.startupPlayerView3);
            this.Controls.Add(this.startupPlayerView2);
            this.Controls.Add(this.startupPlayerView1);
            this.Controls.Add(this.gameOptionsButton);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.numberOfPlayers);
            this.Controls.Add(this.label5);
            this.MaximizeBox = false;
            this.Name = "StartupDisplay";
            this.ShowIcon = false;
            this.Text = "New Uno Game";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numberOfPlayers;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.Button gameOptionsButton;
        private StartupPlayerView startupPlayerView1;
        private StartupPlayerView startupPlayerView2;
        private StartupPlayerView startupPlayerView3;
        private StartupPlayerView startupPlayerView4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button quickDebugGameButton;
    }
}