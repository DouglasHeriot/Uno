namespace Uno
{
    partial class SortedPlayerView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.typeLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.ordinalLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(8, 70);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(52, 13);
            this.typeLabel.TabIndex = 7;
            this.typeLabel.Text = "Computer";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(175, 70);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(53, 13);
            this.scoreLabel.TabIndex = 6;
            this.scoreLabel.Text = "Score: 12";
            // 
            // ordinalLabel
            // 
            this.ordinalLabel.AutoSize = true;
            this.ordinalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ordinalLabel.Location = new System.Drawing.Point(5, 6);
            this.ordinalLabel.Name = "ordinalLabel";
            this.ordinalLabel.Size = new System.Drawing.Size(36, 13);
            this.ordinalLabel.TabIndex = 5;
            this.ordinalLabel.Text = "Forth";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(50, 28);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(121, 31);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Player 4";
            // 
            // SortedPlayerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.ordinalLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "SortedPlayerView";
            this.Size = new System.Drawing.Size(232, 88);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label ordinalLabel;
        private System.Windows.Forms.Label nameLabel;

    }
}
