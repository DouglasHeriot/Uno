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
            this.label4 = new System.Windows.Forms.Label();
            this.scoringMethodDropDown = new System.Windows.Forms.ComboBox();
            this.stopAfterFirst = new System.Windows.Forms.CheckBox();
            this.requiredOfficialLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.computerDelayUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardsPerPlayerUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // animationCheckbox
            // 
            this.animationCheckbox.AutoSize = true;
            this.animationCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.animationCheckbox.Checked = true;
            this.animationCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.animationCheckbox.Location = new System.Drawing.Point(149, 82);
            this.animationCheckbox.Name = "animationCheckbox";
            this.animationCheckbox.Size = new System.Drawing.Size(94, 17);
            this.animationCheckbox.TabIndex = 2;
            this.animationCheckbox.Text = "Use Animation";
            this.animationCheckbox.UseVisualStyleBackColor = true;
            // 
            // computerDelayUpDown
            // 
            this.computerDelayUpDown.Location = new System.Drawing.Point(228, 105);
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
            this.computerDelayUpDown.TabIndex = 3;
            this.computerDelayUpDown.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Computer Player Delay (ms)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cards per player";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cardsPerPlayerUpDown
            // 
            this.cardsPerPlayerUpDown.Location = new System.Drawing.Point(228, 33);
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
            this.cardsPerPlayerUpDown.Size = new System.Drawing.Size(64, 20);
            this.cardsPerPlayerUpDown.TabIndex = 0;
            this.cardsPerPlayerUpDown.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // doneButton
            // 
            this.doneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.doneButton.Location = new System.Drawing.Point(355, 307);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 23);
            this.doneButton.TabIndex = 9;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // highlightPlayableCards
            // 
            this.highlightPlayableCards.AutoSize = true;
            this.highlightPlayableCards.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.highlightPlayableCards.Location = new System.Drawing.Point(103, 59);
            this.highlightPlayableCards.Name = "highlightPlayableCards";
            this.highlightPlayableCards.Size = new System.Drawing.Size(140, 17);
            this.highlightPlayableCards.TabIndex = 1;
            this.highlightPlayableCards.Text = "Highlight Playable Cards";
            this.highlightPlayableCards.UseVisualStyleBackColor = true;
            // 
            // helpButton
            // 
            this.helpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.helpButton.Location = new System.Drawing.Point(274, 307);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(75, 23);
            this.helpButton.TabIndex = 8;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(135, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Optional Rules";
            // 
            // allowDraw4
            // 
            this.allowDraw4.AutoSize = true;
            this.allowDraw4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.allowDraw4.Checked = true;
            this.allowDraw4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowDraw4.Location = new System.Drawing.Point(47, 213);
            this.allowDraw4.Name = "allowDraw4";
            this.allowDraw4.Size = new System.Drawing.Size(196, 17);
            this.allowDraw4.TabIndex = 5;
            this.allowDraw4.Text = "Allow Draw 4s to be played any time";
            this.allowDraw4.UseVisualStyleBackColor = true;
            // 
            // swapWith0
            // 
            this.swapWith0.AutoSize = true;
            this.swapWith0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.swapWith0.Location = new System.Drawing.Point(90, 236);
            this.swapWith0.Name = "swapWith0";
            this.swapWith0.Size = new System.Drawing.Size(153, 17);
            this.swapWith0.TabIndex = 6;
            this.swapWith0.Text = "Swap hands with a \'0\' card";
            this.swapWith0.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Scoring Method";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // scoringMethodDropDown
            // 
            this.scoringMethodDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scoringMethodDropDown.FormattingEnabled = true;
            this.scoringMethodDropDown.Items.AddRange(new object[] {
            "Simple Scoring",
            "Card Value Scoring"});
            this.scoringMethodDropDown.Location = new System.Drawing.Point(228, 130);
            this.scoringMethodDropDown.Name = "scoringMethodDropDown";
            this.scoringMethodDropDown.Size = new System.Drawing.Size(121, 21);
            this.scoringMethodDropDown.TabIndex = 4;
            this.scoringMethodDropDown.SelectedIndexChanged += new System.EventHandler(this.scoringMethodDropDown_SelectedIndexChanged);
            // 
            // stopAfterFirst
            // 
            this.stopAfterFirst.AutoSize = true;
            this.stopAfterFirst.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stopAfterFirst.Location = new System.Drawing.Point(82, 259);
            this.stopAfterFirst.Name = "stopAfterFirst";
            this.stopAfterFirst.Size = new System.Drawing.Size(161, 17);
            this.stopAfterFirst.TabIndex = 7;
            this.stopAfterFirst.Text = "Stop playing after first winner";
            this.stopAfterFirst.UseVisualStyleBackColor = true;
            // 
            // requiredOfficialLabel
            // 
            this.requiredOfficialLabel.AutoSize = true;
            this.requiredOfficialLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.requiredOfficialLabel.Location = new System.Drawing.Point(249, 260);
            this.requiredOfficialLabel.Name = "requiredOfficialLabel";
            this.requiredOfficialLabel.Size = new System.Drawing.Size(155, 13);
            this.requiredOfficialLabel.TabIndex = 9;
            this.requiredOfficialLabel.Text = "Required for card value scoring";
            this.requiredOfficialLabel.Visible = false;
            // 
            // GameOptionsView
            // 
            this.AcceptButton = this.doneButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 342);
            this.Controls.Add(this.requiredOfficialLabel);
            this.Controls.Add(this.scoringMethodDropDown);
            this.Controls.Add(this.stopAfterFirst);
            this.Controls.Add(this.swapWith0);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox scoringMethodDropDown;
        private System.Windows.Forms.CheckBox stopAfterFirst;
        private System.Windows.Forms.Label requiredOfficialLabel;
    }
}