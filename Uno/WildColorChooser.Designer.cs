namespace Uno
{
    partial class WildColorChooser
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
            this.label1 = new System.Windows.Forms.Label();
            this.red = new System.Windows.Forms.Button();
            this.yellow = new System.Windows.Forms.Button();
            this.green = new System.Windows.Forms.Button();
            this.blue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose a colour for your wild card";
            // 
            // red
            // 
            this.red.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(65)))), ((int)(((byte)(49)))));
            this.red.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.red.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.red.ForeColor = System.Drawing.Color.White;
            this.red.Location = new System.Drawing.Point(12, 51);
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(80, 80);
            this.red.TabIndex = 0;
            this.red.Text = "Red";
            this.red.UseVisualStyleBackColor = false;
            this.red.Click += new System.EventHandler(this.red_Click);
            // 
            // yellow
            // 
            this.yellow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(3)))));
            this.yellow.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.yellow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yellow.ForeColor = System.Drawing.Color.Black;
            this.yellow.Location = new System.Drawing.Point(98, 51);
            this.yellow.Name = "yellow";
            this.yellow.Size = new System.Drawing.Size(80, 80);
            this.yellow.TabIndex = 1;
            this.yellow.Text = "Yellow";
            this.yellow.UseVisualStyleBackColor = false;
            this.yellow.Click += new System.EventHandler(this.yellow_Click);
            // 
            // green
            // 
            this.green.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(235)))), ((int)(((byte)(19)))));
            this.green.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.green.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.green.ForeColor = System.Drawing.Color.Black;
            this.green.Location = new System.Drawing.Point(184, 51);
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(80, 80);
            this.green.TabIndex = 2;
            this.green.Text = "Green";
            this.green.UseVisualStyleBackColor = false;
            this.green.Click += new System.EventHandler(this.green_Click);
            // 
            // blue
            // 
            this.blue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(182)))), ((int)(((byte)(251)))));
            this.blue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.blue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blue.ForeColor = System.Drawing.Color.White;
            this.blue.Location = new System.Drawing.Point(270, 51);
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(80, 80);
            this.blue.TabIndex = 3;
            this.blue.Text = "Blue";
            this.blue.UseVisualStyleBackColor = false;
            this.blue.Click += new System.EventHandler(this.blue_Click);
            // 
            // WildColorChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 155);
            this.Controls.Add(this.blue);
            this.Controls.Add(this.green);
            this.Controls.Add(this.yellow);
            this.Controls.Add(this.red);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WildColorChooser";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose Colour";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button red;
        private System.Windows.Forms.Button yellow;
        private System.Windows.Forms.Button green;
        private System.Windows.Forms.Button blue;
    }
}