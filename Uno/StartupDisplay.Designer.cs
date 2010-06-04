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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupDisplay));
            this.label5 = new System.Windows.Forms.Label();
            this.numberOfPlayers = new System.Windows.Forms.NumericUpDown();
            this.startGameButton = new System.Windows.Forms.Button();
            this.gameOptionsButton = new System.Windows.Forms.Button();
            this.quickDebugGameButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.startupPlayerView4 = new Uno.StartupPlayerView();
            this.startupPlayerView3 = new Uno.StartupPlayerView();
            this.startupPlayerView2 = new Uno.StartupPlayerView();
            this.startupPlayerView1 = new Uno.StartupPlayerView();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(321, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Number of Players:";
            // 
            // numberOfPlayers
            // 
            this.numberOfPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numberOfPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfPlayers.Location = new System.Drawing.Point(441, 33);
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
            this.numberOfPlayers.Size = new System.Drawing.Size(47, 38);
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
            this.startGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startGameButton.BackColor = System.Drawing.Color.Transparent;
            this.startGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startGameButton.Location = new System.Drawing.Point(335, 496);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(153, 60);
            this.startGameButton.TabIndex = 6;
            this.startGameButton.Text = "Start Game";
            this.startGameButton.UseVisualStyleBackColor = false;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // gameOptionsButton
            // 
            this.gameOptionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gameOptionsButton.BackColor = System.Drawing.Color.Transparent;
            this.gameOptionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOptionsButton.Location = new System.Drawing.Point(215, 529);
            this.gameOptionsButton.Name = "gameOptionsButton";
            this.gameOptionsButton.Size = new System.Drawing.Size(114, 27);
            this.gameOptionsButton.TabIndex = 5;
            this.gameOptionsButton.Text = "Game Options...";
            this.gameOptionsButton.UseVisualStyleBackColor = false;
            this.gameOptionsButton.Click += new System.EventHandler(this.gameOptionsButton_Click);
            // 
            // quickDebugGameButton
            // 
            this.quickDebugGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.quickDebugGameButton.BackColor = System.Drawing.Color.Transparent;
            this.quickDebugGameButton.Location = new System.Drawing.Point(12, 529);
            this.quickDebugGameButton.Name = "quickDebugGameButton";
            this.quickDebugGameButton.Size = new System.Drawing.Size(136, 27);
            this.quickDebugGameButton.TabIndex = 7;
            this.quickDebugGameButton.Text = "Quick Debug Game";
            this.quickDebugGameButton.UseVisualStyleBackColor = false;
            this.quickDebugGameButton.Click += new System.EventHandler(this.quickDebugGameButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutButton.BackColor = System.Drawing.Color.Transparent;
            this.aboutButton.Location = new System.Drawing.Point(273, 496);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(56, 27);
            this.aboutButton.TabIndex = 5;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = false;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.helpButton.Location = new System.Drawing.Point(215, 496);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(52, 27);
            this.helpButton.TabIndex = 8;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // startupPlayerView4
            // 
            this.startupPlayerView4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startupPlayerView4.BackColor = System.Drawing.Color.Transparent;
            this.startupPlayerView4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startupPlayerView4.BackgroundImage")));
            this.startupPlayerView4.Location = new System.Drawing.Point(215, 388);
            this.startupPlayerView4.Name = "startupPlayerView4";
            this.startupPlayerView4.Size = new System.Drawing.Size(273, 94);
            this.startupPlayerView4.TabIndex = 3;
            // 
            // startupPlayerView3
            // 
            this.startupPlayerView3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startupPlayerView3.BackColor = System.Drawing.Color.Transparent;
            this.startupPlayerView3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startupPlayerView3.BackgroundImage")));
            this.startupPlayerView3.Location = new System.Drawing.Point(215, 288);
            this.startupPlayerView3.Name = "startupPlayerView3";
            this.startupPlayerView3.Size = new System.Drawing.Size(273, 94);
            this.startupPlayerView3.TabIndex = 2;
            // 
            // startupPlayerView2
            // 
            this.startupPlayerView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startupPlayerView2.BackColor = System.Drawing.Color.Transparent;
            this.startupPlayerView2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startupPlayerView2.BackgroundImage")));
            this.startupPlayerView2.Location = new System.Drawing.Point(215, 188);
            this.startupPlayerView2.Name = "startupPlayerView2";
            this.startupPlayerView2.Size = new System.Drawing.Size(273, 94);
            this.startupPlayerView2.TabIndex = 1;
            // 
            // startupPlayerView1
            // 
            this.startupPlayerView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startupPlayerView1.BackColor = System.Drawing.Color.Transparent;
            this.startupPlayerView1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startupPlayerView1.BackgroundImage")));
            this.startupPlayerView1.Location = new System.Drawing.Point(215, 88);
            this.startupPlayerView1.Name = "startupPlayerView1";
            this.startupPlayerView1.Size = new System.Drawing.Size(273, 94);
            this.startupPlayerView1.TabIndex = 0;
            // 
            // StartupDisplay
            // 
            this.AcceptButton = this.startGameButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 568);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.quickDebugGameButton);
            this.Controls.Add(this.startupPlayerView4);
            this.Controls.Add(this.startupPlayerView3);
            this.Controls.Add(this.startupPlayerView2);
            this.Controls.Add(this.startupPlayerView1);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.gameOptionsButton);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.numberOfPlayers);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartupDisplay";
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
        private System.Windows.Forms.Button quickDebugGameButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button helpButton;
    }
}