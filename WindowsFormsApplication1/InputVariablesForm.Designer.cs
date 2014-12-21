namespace WindowsFormsApplication1
{
    partial class InputVariablesForm
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
            this.InputVariables = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InputVariables
            // 
            this.InputVariables.AutoSize = true;
            this.InputVariables.Location = new System.Drawing.Point(12, 9);
            this.InputVariables.Name = "InputVariables";
            this.InputVariables.Size = new System.Drawing.Size(79, 13);
            this.InputVariables.TabIndex = 0;
            this.InputVariables.Text = "Input variables:";
            // 
            // InputVariablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.InputVariables);
            this.Name = "InputVariablesForm";
            this.Text = "InputVariablesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InputVariables;
    }
}