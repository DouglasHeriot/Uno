namespace Uno
{
    partial class GameView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameView));
            this.newGameButton = new System.Windows.Forms.Button();
            this.endGameButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.player2Label = new System.Windows.Forms.Label();
            this.player3Label = new System.Windows.Forms.Label();
            this.player4Label = new System.Windows.Forms.Label();
            this.pickupPileImage = new System.Windows.Forms.PictureBox();
            this.player1Label = new System.Windows.Forms.Label();
            this.player1Status = new System.Windows.Forms.PictureBox();
            this.player2Status = new System.Windows.Forms.PictureBox();
            this.player3Status = new System.Windows.Forms.PictureBox();
            this.player4Status = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pickupPileImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player4Status)).BeginInit();
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(44, 472);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(130, 22);
            this.newGameButton.TabIndex = 0;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            // 
            // endGameButton
            // 
            this.endGameButton.Location = new System.Drawing.Point(44, 503);
            this.endGameButton.Name = "endGameButton";
            this.endGameButton.Size = new System.Drawing.Size(130, 22);
            this.endGameButton.TabIndex = 0;
            this.endGameButton.Text = "End Game";
            this.endGameButton.UseVisualStyleBackColor = true;
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(44, 537);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(59, 22);
            this.helpButton.TabIndex = 0;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(115, 537);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(59, 22);
            this.aboutButton.TabIndex = 0;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = true;
            this.player2Label.BackColor = System.Drawing.Color.Transparent;
            this.player2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2Label.Location = new System.Drawing.Point(251, 187);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(68, 17);
            this.player2Label.TabIndex = 1;
            this.player2Label.Text = "Player 2";
            // 
            // player3Label
            // 
            this.player3Label.AutoSize = true;
            this.player3Label.BackColor = System.Drawing.Color.Transparent;
            this.player3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player3Label.Location = new System.Drawing.Point(251, 324);
            this.player3Label.Name = "player3Label";
            this.player3Label.Size = new System.Drawing.Size(68, 17);
            this.player3Label.TabIndex = 1;
            this.player3Label.Text = "Player 3";
            // 
            // player4Label
            // 
            this.player4Label.AutoSize = true;
            this.player4Label.BackColor = System.Drawing.Color.Transparent;
            this.player4Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player4Label.Location = new System.Drawing.Point(251, 463);
            this.player4Label.Name = "player4Label";
            this.player4Label.Size = new System.Drawing.Size(68, 17);
            this.player4Label.TabIndex = 1;
            this.player4Label.Text = "Player 4";
            // 
            // pickupPileImage
            // 
            this.pickupPileImage.BackColor = System.Drawing.Color.Transparent;
            this.pickupPileImage.Image = global::Uno.Properties.Resources.back;
            this.pickupPileImage.Location = new System.Drawing.Point(75, 182);
            this.pickupPileImage.Name = "pickupPileImage";
            this.pickupPileImage.Size = new System.Drawing.Size(50, 80);
            this.pickupPileImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pickupPileImage.TabIndex = 2;
            this.pickupPileImage.TabStop = false;
            this.pickupPileImage.Click += new System.EventHandler(this.pickupPileImage_Click);
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.BackColor = System.Drawing.Color.Transparent;
            this.player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Label.Location = new System.Drawing.Point(251, 51);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(68, 17);
            this.player1Label.TabIndex = 1;
            this.player1Label.Text = "Player 1";
            // 
            // player1Status
            // 
            this.player1Status.BackColor = System.Drawing.Color.Transparent;
            this.player1Status.Location = new System.Drawing.Point(213, 43);
            this.player1Status.Name = "player1Status";
            this.player1Status.Size = new System.Drawing.Size(33, 123);
            this.player1Status.TabIndex = 3;
            this.player1Status.TabStop = false;
            // 
            // player2Status
            // 
            this.player2Status.BackColor = System.Drawing.Color.Transparent;
            this.player2Status.Location = new System.Drawing.Point(213, 180);
            this.player2Status.Name = "player2Status";
            this.player2Status.Size = new System.Drawing.Size(33, 123);
            this.player2Status.TabIndex = 3;
            this.player2Status.TabStop = false;
            // 
            // player3Status
            // 
            this.player3Status.BackColor = System.Drawing.Color.Transparent;
            this.player3Status.Location = new System.Drawing.Point(213, 317);
            this.player3Status.Name = "player3Status";
            this.player3Status.Size = new System.Drawing.Size(33, 123);
            this.player3Status.TabIndex = 3;
            this.player3Status.TabStop = false;
            // 
            // player4Status
            // 
            this.player4Status.BackColor = System.Drawing.Color.Transparent;
            this.player4Status.Location = new System.Drawing.Point(213, 455);
            this.player4Status.Name = "player4Status";
            this.player4Status.Size = new System.Drawing.Size(33, 123);
            this.player4Status.TabIndex = 3;
            this.player4Status.TabStop = false;
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(950, 621);
            this.Controls.Add(this.player4Status);
            this.Controls.Add(this.player3Status);
            this.Controls.Add(this.player2Status);
            this.Controls.Add(this.player1Status);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.pickupPileImage);
            this.Controls.Add(this.player4Label);
            this.Controls.Add(this.player3Label);
            this.Controls.Add(this.player2Label);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.endGameButton);
            this.Controls.Add(this.newGameButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameView";
            this.ShowIcon = false;
            this.Text = "Uno";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameView_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pickupPileImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player4Status)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button endGameButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Label player2Label;
        private System.Windows.Forms.Label player3Label;
        private System.Windows.Forms.Label player4Label;
        private System.Windows.Forms.PictureBox pickupPileImage;
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.PictureBox player1Status;
        private System.Windows.Forms.PictureBox player2Status;
        private System.Windows.Forms.PictureBox player3Status;
        private System.Windows.Forms.PictureBox player4Status;

    }
}

