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
            this.playerStatus = new System.Windows.Forms.PictureBox();
            this.endHighlight = new System.Windows.Forms.PictureBox();
            this.player1ComputerBadge = new System.Windows.Forms.PictureBox();
            this.player2ComputerBadge = new System.Windows.Forms.PictureBox();
            this.player3ComputerBadge = new System.Windows.Forms.PictureBox();
            this.player4ComputerBadge = new System.Windows.Forms.PictureBox();
            this.gameInfoMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pickupPileImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endHighlight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1ComputerBadge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2ComputerBadge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3ComputerBadge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player4ComputerBadge)).BeginInit();
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(44, 503);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(130, 22);
            this.newGameButton.TabIndex = 0;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // endGameButton
            // 
            this.endGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endGameButton.Location = new System.Drawing.Point(44, 443);
            this.endGameButton.Name = "endGameButton";
            this.endGameButton.Size = new System.Drawing.Size(130, 50);
            this.endGameButton.TabIndex = 0;
            this.endGameButton.Text = "End Game";
            this.endGameButton.UseVisualStyleBackColor = true;
            this.endGameButton.Click += new System.EventHandler(this.endGameButton_Click);
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
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
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
            // playerStatus
            // 
            this.playerStatus.BackColor = System.Drawing.Color.Transparent;
            this.playerStatus.Location = new System.Drawing.Point(213, 43);
            this.playerStatus.Name = "playerStatus";
            this.playerStatus.Size = new System.Drawing.Size(33, 123);
            this.playerStatus.TabIndex = 3;
            this.playerStatus.TabStop = false;
            // 
            // endHighlight
            // 
            this.endHighlight.BackColor = System.Drawing.Color.Transparent;
            this.endHighlight.Image = global::Uno.Properties.Resources.highlight;
            this.endHighlight.InitialImage = null;
            this.endHighlight.Location = new System.Drawing.Point(34, 431);
            this.endHighlight.Name = "endHighlight";
            this.endHighlight.Size = new System.Drawing.Size(150, 75);
            this.endHighlight.TabIndex = 4;
            this.endHighlight.TabStop = false;
            this.endHighlight.Visible = false;
            // 
            // player1ComputerBadge
            // 
            this.player1ComputerBadge.BackColor = System.Drawing.Color.Transparent;
            this.player1ComputerBadge.Image = global::Uno.Properties.Resources.computer;
            this.player1ComputerBadge.Location = new System.Drawing.Point(825, 44);
            this.player1ComputerBadge.Name = "player1ComputerBadge";
            this.player1ComputerBadge.Size = new System.Drawing.Size(100, 30);
            this.player1ComputerBadge.TabIndex = 5;
            this.player1ComputerBadge.TabStop = false;
            // 
            // player2ComputerBadge
            // 
            this.player2ComputerBadge.BackColor = System.Drawing.Color.Transparent;
            this.player2ComputerBadge.Image = global::Uno.Properties.Resources.computer;
            this.player2ComputerBadge.Location = new System.Drawing.Point(825, 181);
            this.player2ComputerBadge.Name = "player2ComputerBadge";
            this.player2ComputerBadge.Size = new System.Drawing.Size(100, 30);
            this.player2ComputerBadge.TabIndex = 5;
            this.player2ComputerBadge.TabStop = false;
            // 
            // player3ComputerBadge
            // 
            this.player3ComputerBadge.BackColor = System.Drawing.Color.Transparent;
            this.player3ComputerBadge.Image = global::Uno.Properties.Resources.computer;
            this.player3ComputerBadge.Location = new System.Drawing.Point(825, 319);
            this.player3ComputerBadge.Name = "player3ComputerBadge";
            this.player3ComputerBadge.Size = new System.Drawing.Size(100, 30);
            this.player3ComputerBadge.TabIndex = 5;
            this.player3ComputerBadge.TabStop = false;
            // 
            // player4ComputerBadge
            // 
            this.player4ComputerBadge.BackColor = System.Drawing.Color.Transparent;
            this.player4ComputerBadge.Image = global::Uno.Properties.Resources.computer;
            this.player4ComputerBadge.Location = new System.Drawing.Point(825, 456);
            this.player4ComputerBadge.Name = "player4ComputerBadge";
            this.player4ComputerBadge.Size = new System.Drawing.Size(100, 30);
            this.player4ComputerBadge.TabIndex = 5;
            this.player4ComputerBadge.TabStop = false;
            // 
            // gameInfoMessage
            // 
            this.gameInfoMessage.BackColor = System.Drawing.Color.Transparent;
            this.gameInfoMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfoMessage.Location = new System.Drawing.Point(44, 312);
            this.gameInfoMessage.Name = "gameInfoMessage";
            this.gameInfoMessage.Size = new System.Drawing.Size(130, 51);
            this.gameInfoMessage.TabIndex = 6;
            this.gameInfoMessage.Text = "Simple Scoring";
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(950, 621);
            this.Controls.Add(this.gameInfoMessage);
            this.Controls.Add(this.player4ComputerBadge);
            this.Controls.Add(this.player3ComputerBadge);
            this.Controls.Add(this.player2ComputerBadge);
            this.Controls.Add(this.player1ComputerBadge);
            this.Controls.Add(this.playerStatus);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.pickupPileImage);
            this.Controls.Add(this.player4Label);
            this.Controls.Add(this.player3Label);
            this.Controls.Add(this.player2Label);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.endGameButton);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.endHighlight);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameView";
            this.Text = "Uno";
            ((System.ComponentModel.ISupportInitialize)(this.pickupPileImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endHighlight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1ComputerBadge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2ComputerBadge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3ComputerBadge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player4ComputerBadge)).EndInit();
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
        private System.Windows.Forms.PictureBox playerStatus;
        private System.Windows.Forms.PictureBox endHighlight;
        private System.Windows.Forms.PictureBox player1ComputerBadge;
        private System.Windows.Forms.PictureBox player2ComputerBadge;
        private System.Windows.Forms.PictureBox player3ComputerBadge;
        private System.Windows.Forms.PictureBox player4ComputerBadge;
        private System.Windows.Forms.Label gameInfoMessage;

    }
}

