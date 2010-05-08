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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cardsPerPlayerUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.computerDelayUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardsPerPlayerUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // animationCheckbox
            // 
            this.animationCheckbox.AutoSize = true;
            this.animationCheckbox.Checked = true;
            this.animationCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.animationCheckbox.Location = new System.Drawing.Point(12, 12);
            this.animationCheckbox.Name = "animationCheckbox";
            this.animationCheckbox.Size = new System.Drawing.Size(94, 17);
            this.animationCheckbox.TabIndex = 0;
            this.animationCheckbox.Text = "Use Animation";
            this.animationCheckbox.UseVisualStyleBackColor = true;
            
            // 
            // computerDelayUpDown
            // 
            this.computerDelayUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.computerDelayUpDown.Location = new System.Drawing.Point(116, 19);
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
            this.computerDelayUpDown.Size = new System.Drawing.Size(149, 20);
            this.computerDelayUpDown.TabIndex = 1;
            this.computerDelayUpDown.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.computerDelayUpDown);
            this.groupBox1.Location = new System.Drawing.Point(12, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 58);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Advanced Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Computer Delay (ms)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cards per player";
            // 
            // cardsPerPlayerUpDown
            // 
            this.cardsPerPlayerUpDown.Location = new System.Drawing.Point(98, 50);
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
            this.cardsPerPlayerUpDown.Size = new System.Drawing.Size(79, 20);
            this.cardsPerPlayerUpDown.TabIndex = 4;
            this.cardsPerPlayerUpDown.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            
            // 
            // GameOptionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 423);
            this.Controls.Add(this.cardsPerPlayerUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.animationCheckbox);
            this.MaximizeBox = false;
            this.Name = "GameOptionsView";
            this.ShowIcon = false;
            this.Text = "Uno Options";
            ((System.ComponentModel.ISupportInitialize)(this.computerDelayUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardsPerPlayerUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox animationCheckbox;
        private System.Windows.Forms.NumericUpDown computerDelayUpDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown cardsPerPlayerUpDown;
    }
}