namespace WindowsFormsApplication1
{
    partial class AddTermForm
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
            this.TermsCountConfirmButton = new System.Windows.Forms.Button();
            this.TermsCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.TermCountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TermsCountUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // TermsCountConfirmButton
            // 
            this.TermsCountConfirmButton.Location = new System.Drawing.Point(136, 20);
            this.TermsCountConfirmButton.Name = "TermsCountConfirmButton";
            this.TermsCountConfirmButton.Size = new System.Drawing.Size(75, 19);
            this.TermsCountConfirmButton.TabIndex = 6;
            this.TermsCountConfirmButton.Text = "Confirm";
            this.TermsCountConfirmButton.UseVisualStyleBackColor = true;
            this.TermsCountConfirmButton.Click += new System.EventHandler(this.TermsCountConfirmButton_Click);
            // 
            // TermsCountUpDown
            // 
            this.TermsCountUpDown.Location = new System.Drawing.Point(93, 20);
            this.TermsCountUpDown.Name = "TermsCountUpDown";
            this.TermsCountUpDown.Size = new System.Drawing.Size(36, 20);
            this.TermsCountUpDown.TabIndex = 5;
            this.TermsCountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TermCountLabel
            // 
            this.TermCountLabel.AutoSize = true;
            this.TermCountLabel.Location = new System.Drawing.Point(21, 20);
            this.TermCountLabel.Name = "TermCountLabel";
            this.TermCountLabel.Size = new System.Drawing.Size(66, 13);
            this.TermCountLabel.TabIndex = 4;
            this.TermCountLabel.Text = "Terms count";
            // 
            // AddTermForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 356);
            this.Controls.Add(this.TermsCountConfirmButton);
            this.Controls.Add(this.TermsCountUpDown);
            this.Controls.Add(this.TermCountLabel);
            this.Name = "AddTermForm";
            this.Text = "AddTermForm";
            ((System.ComponentModel.ISupportInitialize)(this.TermsCountUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TermsCountConfirmButton;
        private System.Windows.Forms.NumericUpDown TermsCountUpDown;
        private System.Windows.Forms.Label TermCountLabel;
    }
}