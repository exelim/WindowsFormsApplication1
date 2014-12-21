namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.LVCountLabel = new System.Windows.Forms.Label();
            this.LVCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.LVCountConfirmButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LVCountUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // LVCountLabel
            // 
            this.LVCountLabel.AutoSize = true;
            this.LVCountLabel.Location = new System.Drawing.Point(12, 23);
            this.LVCountLabel.Name = "LVCountLabel";
            this.LVCountLabel.Size = new System.Drawing.Size(126, 13);
            this.LVCountLabel.TabIndex = 0;
            this.LVCountLabel.Text = "Linguistic variables count";
            // 
            // LVCountUpDown
            // 
            this.LVCountUpDown.Location = new System.Drawing.Point(144, 21);
            this.LVCountUpDown.Name = "LVCountUpDown";
            this.LVCountUpDown.Size = new System.Drawing.Size(36, 20);
            this.LVCountUpDown.TabIndex = 2;
            this.LVCountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LVCountConfirmButton
            // 
            this.LVCountConfirmButton.Location = new System.Drawing.Point(187, 21);
            this.LVCountConfirmButton.Name = "LVCountConfirmButton";
            this.LVCountConfirmButton.Size = new System.Drawing.Size(75, 19);
            this.LVCountConfirmButton.TabIndex = 3;
            this.LVCountConfirmButton.Text = "Confirm";
            this.LVCountConfirmButton.UseVisualStyleBackColor = true;
            this.LVCountConfirmButton.Click += new System.EventHandler(this.LVCountConfirmButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 448);
            this.Controls.Add(this.LVCountConfirmButton);
            this.Controls.Add(this.LVCountUpDown);
            this.Controls.Add(this.LVCountLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.LVCountUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LVCountLabel;
        private System.Windows.Forms.NumericUpDown LVCountUpDown;
        private System.Windows.Forms.Button LVCountConfirmButton;
    }
}

