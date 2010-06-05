namespace Uno
{
    partial class Help
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
            this.tabView = new System.Windows.Forms.TabControl();
            this.tabNewGame = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabGameOptions = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabPlayingAGame = new System.Windows.Forms.TabPage();
            this.tabView.SuspendLayout();
            this.tabNewGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabGameOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabView
            // 
            this.tabView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabView.Controls.Add(this.tabNewGame);
            this.tabView.Controls.Add(this.tabGameOptions);
            this.tabView.Controls.Add(this.tabPlayingAGame);
            this.tabView.Location = new System.Drawing.Point(12, 12);
            this.tabView.Name = "tabView";
            this.tabView.SelectedIndex = 0;
            this.tabView.Size = new System.Drawing.Size(648, 465);
            this.tabView.TabIndex = 0;
            // 
            // tabNewGame
            // 
            this.tabNewGame.AutoScroll = true;
            this.tabNewGame.Controls.Add(this.pictureBox1);
            this.tabNewGame.Location = new System.Drawing.Point(4, 22);
            this.tabNewGame.Name = "tabNewGame";
            this.tabNewGame.Padding = new System.Windows.Forms.Padding(3);
            this.tabNewGame.Size = new System.Drawing.Size(640, 439);
            this.tabNewGame.TabIndex = 0;
            this.tabNewGame.Text = "New Game";
            this.tabNewGame.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Uno.Properties.Resources.Help_NewGame;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(617, 607);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabGameOptions
            // 
            this.tabGameOptions.AutoScroll = true;
            this.tabGameOptions.Controls.Add(this.pictureBox2);
            this.tabGameOptions.Location = new System.Drawing.Point(4, 22);
            this.tabGameOptions.Name = "tabGameOptions";
            this.tabGameOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabGameOptions.Size = new System.Drawing.Size(634, 439);
            this.tabGameOptions.TabIndex = 1;
            this.tabGameOptions.Text = "Game Options";
            this.tabGameOptions.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::Uno.Properties.Resources.Help_GameOptions;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(611, 1351);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // tabPlayingAGame
            // 
            this.tabPlayingAGame.AutoScroll = true;
            this.tabPlayingAGame.Location = new System.Drawing.Point(4, 22);
            this.tabPlayingAGame.Name = "tabPlayingAGame";
            this.tabPlayingAGame.Size = new System.Drawing.Size(634, 439);
            this.tabPlayingAGame.TabIndex = 2;
            this.tabPlayingAGame.Text = "Playing a Game";
            this.tabPlayingAGame.UseVisualStyleBackColor = true;
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 489);
            this.Controls.Add(this.tabView);
            this.MinimumSize = new System.Drawing.Size(680, 200);
            this.Name = "Help";
            this.ShowIcon = false;
            this.Text = "Uno Help";
            this.tabView.ResumeLayout(false);
            this.tabNewGame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabGameOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabView;
        private System.Windows.Forms.TabPage tabNewGame;
        private System.Windows.Forms.TabPage tabGameOptions;
        private System.Windows.Forms.TabPage tabPlayingAGame;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}