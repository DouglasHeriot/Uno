namespace Uno
{
    partial class GameOptionsView
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
            this.animationCheckbox = new System.Windows.Forms.CheckBox();
            this.computerDelayUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cardsPerPlayerUpDown = new System.Windows.Forms.NumericUpDown();
            this.doneButton = new System.Windows.Forms.Button();
            this.highlightPlayableCards = new System.Windows.Forms.CheckBox();
            this.helpButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.allowDraw4 = new System.Windows.Forms.CheckBox();
            this.swapWith0 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.computerDelayUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardsPerPlayerUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // animationCheckbox
            // 
            this.animationCheckbox.AutoSize = true;
            this.animationCheckbox.Checked = true;
            this.animationCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.animationCheckbox.Location = new System.Drawing.Point(12, 80);
            this.animationCheckbox.Name = "animationCheckbox";
            this.animationCheckbox.Size = new System.Drawing.Size(94, 17);
            this.animationCheckbox.TabIndex = 0;
            this.animationCheckbox.Text = "Use Animation";
            this.animationCheckbox.UseVisualStyleBackColor = true;
            // 
            // computerDelayUpDown
            // 
            this.computerDelayUpDown.Location = new System.Drawing.Point(170, 120);
            this.computerDelayUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.computerDelayUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.computerDelayUpDown.Name = "computerDelayUpDown";
            this.computerDelayUpDown.Size = new System.Drawing.Size(64, 20);
            this.computerDelayUpDown.TabIndex = 1;
            this.computerDelayUpDown.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Computer Player Delay (ms)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cards per player";
            // 
            // cardsPerPlayerUpDown
            // 
            this.cardsPerPlayerUpDown.Location = new System.Drawing.Point(117, 12);
            this.cardsPerPlayerUpDown.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.cardsPerPlayerUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cardsPerPlayerUpDown.Name = "cardsPerPlayerUpDown";
            this.cardsPerPlayerUpDown.Size = new System.Drawing.Size(71, 20);
            this.cardsPerPlayerUpDown.TabIndex = 4;
            this.cardsPerPlayerUpDown.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // doneButton
            // 
            this.doneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.doneButton.Location = new System.Drawing.Point(163, 252);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 23);
            this.doneButton.TabIndex = 5;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // highlightPlayableCards
            // 
            this.highlightPlayableCards.AutoSize = true;
            this.highlightPlayableCards.Location = new System.Drawing.Point(12, 57);
            this.highlightPlayableCards.Name = "highlightPlayableCards";
            this.highlightPlayableCards.Size = new System.Drawing.Size(140, 17);
            this.highlightPlayableCards.TabIndex = 0;
            this.highlightPlayableCards.Text = "Highlight Playable Cards";
            this.highlightPlayableCards.UseVisualStyleBackColor = true;
            // 
            // helpButton
            // 
            this.helpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.helpButton.Location = new System.Drawing.Point(82, 252);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(75, 23);
            this.helpButton.TabIndex = 5;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Optional Rules";
            // 
            // allowDraw4
            // 
            this.allowDraw4.AutoSize = true;
            this.allowDraw4.Checked = true;
            this.allowDraw4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowDraw4.Location = new System.Drawing.Point(12, 185);
            this.allowDraw4.Name = "allowDraw4";
            this.allowDraw4.Size = new System.Drawing.Size(196, 17);
            this.allowDraw4.TabIndex = 0;
            this.allowDraw4.Text = "Allow Draw 4s to be played any time";
            this.allowDraw4.UseVisualStyleBackColor = true;
            // 
            // swapWith0
            // 
            this.swapWith0.AutoSize = true;
            this.swapWith0.Location = new System.Drawing.Point(12, 208);
            this.swapWith0.Name = "swapWith0";
            this.swapWith0.Size = new System.Drawing.Size(153, 17);
            this.swapWith0.TabIndex = 7;
            this.swapWith0.Text = "Swap hands with a \'0\' card";
            this.swapWith0.UseVisualStyleBackColor = true;
            // 
            // GameOptionsView
            // 
            this.AcceptButton = this.doneButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 287);
            this.Controls.Add(this.swapWith0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.computerDelayUpDown);
            this.Controls.Add(this.cardsPerPlayerUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.highlightPlayableCards);
            this.Controls.Add(this.allowDraw4);
            this.Controls.Add(this.animationCheckbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameOptionsView";
            this.ShowIcon = false;
            this.Text = "Uno Options";
            ((System.ComponentModel.ISupportInitialize)(this.computerDelayUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardsPerPlayerUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox animationCheckbox;
        private System.Windows.Forms.NumericUpDown computerDelayUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown cardsPerPlayerUpDown;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.CheckBox highlightPlayableCards;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox allowDraw4;
        private System.Windows.Forms.CheckBox swapWith0;
    }
}