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
            this.AddTermsPanel = new System.Windows.Forms.Panel();
            this.ChooseFunctionsPanel = new System.Windows.Forms.Panel();
            this.ChooseFunctionsBackButton = new System.Windows.Forms.Button();
            this.FuzzificationComboBox = new System.Windows.Forms.ComboBox();
            this.AccumulationComboBox = new System.Windows.Forms.ComboBox();
            this.ActivisationComboBox = new System.Windows.Forms.ComboBox();
            this.AggregationComboBox = new System.Windows.Forms.ComboBox();
            this.MembershipComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ChooseFunctionsNextButton = new System.Windows.Forms.Button();
            this.TermCountLabel = new System.Windows.Forms.Label();
            this.InputVariablesPanel = new System.Windows.Forms.Panel();
            this.InputVariables = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LVCountUpDown)).BeginInit();
            this.AddTermsPanel.SuspendLayout();
            this.ChooseFunctionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.InputVariablesPanel.SuspendLayout();
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
            // AddTermsPanel
            // 
            this.AddTermsPanel.Controls.Add(this.ChooseFunctionsPanel);
            this.AddTermsPanel.Controls.Add(this.TermCountLabel);
            this.AddTermsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddTermsPanel.Location = new System.Drawing.Point(0, 0);
            this.AddTermsPanel.Name = "AddTermsPanel";
            this.AddTermsPanel.Size = new System.Drawing.Size(1024, 448);
            this.AddTermsPanel.TabIndex = 4;
            this.AddTermsPanel.Visible = false;
            // 
            // ChooseFunctionsPanel
            // 
            this.ChooseFunctionsPanel.Controls.Add(this.InputVariablesPanel);
            this.ChooseFunctionsPanel.Controls.Add(this.ChooseFunctionsBackButton);
            this.ChooseFunctionsPanel.Controls.Add(this.FuzzificationComboBox);
            this.ChooseFunctionsPanel.Controls.Add(this.AccumulationComboBox);
            this.ChooseFunctionsPanel.Controls.Add(this.ActivisationComboBox);
            this.ChooseFunctionsPanel.Controls.Add(this.AggregationComboBox);
            this.ChooseFunctionsPanel.Controls.Add(this.MembershipComboBox);
            this.ChooseFunctionsPanel.Controls.Add(this.label5);
            this.ChooseFunctionsPanel.Controls.Add(this.label4);
            this.ChooseFunctionsPanel.Controls.Add(this.label3);
            this.ChooseFunctionsPanel.Controls.Add(this.label2);
            this.ChooseFunctionsPanel.Controls.Add(this.label1);
            this.ChooseFunctionsPanel.Controls.Add(this.pictureBox1);
            this.ChooseFunctionsPanel.Controls.Add(this.ChooseFunctionsNextButton);
            this.ChooseFunctionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseFunctionsPanel.Location = new System.Drawing.Point(0, 0);
            this.ChooseFunctionsPanel.Name = "ChooseFunctionsPanel";
            this.ChooseFunctionsPanel.Size = new System.Drawing.Size(1024, 448);
            this.ChooseFunctionsPanel.TabIndex = 6;
            // 
            // ChooseFunctionsBackButton
            // 
            this.ChooseFunctionsBackButton.Location = new System.Drawing.Point(187, 348);
            this.ChooseFunctionsBackButton.Name = "ChooseFunctionsBackButton";
            this.ChooseFunctionsBackButton.Size = new System.Drawing.Size(75, 23);
            this.ChooseFunctionsBackButton.TabIndex = 29;
            this.ChooseFunctionsBackButton.Text = "< Back";
            this.ChooseFunctionsBackButton.UseVisualStyleBackColor = true;
            this.ChooseFunctionsBackButton.Click += new System.EventHandler(this.ChooseFunctionsBackButton_Click);
            // 
            // FuzzificationComboBox
            // 
            this.FuzzificationComboBox.FormattingEnabled = true;
            this.FuzzificationComboBox.Location = new System.Drawing.Point(308, 284);
            this.FuzzificationComboBox.Name = "FuzzificationComboBox";
            this.FuzzificationComboBox.Size = new System.Drawing.Size(121, 21);
            this.FuzzificationComboBox.TabIndex = 28;
            // 
            // AccumulationComboBox
            // 
            this.AccumulationComboBox.FormattingEnabled = true;
            this.AccumulationComboBox.Location = new System.Drawing.Point(308, 233);
            this.AccumulationComboBox.Name = "AccumulationComboBox";
            this.AccumulationComboBox.Size = new System.Drawing.Size(121, 21);
            this.AccumulationComboBox.TabIndex = 27;
            // 
            // ActivisationComboBox
            // 
            this.ActivisationComboBox.FormattingEnabled = true;
            this.ActivisationComboBox.Location = new System.Drawing.Point(308, 176);
            this.ActivisationComboBox.Name = "ActivisationComboBox";
            this.ActivisationComboBox.Size = new System.Drawing.Size(121, 21);
            this.ActivisationComboBox.TabIndex = 26;
            // 
            // AggregationComboBox
            // 
            this.AggregationComboBox.FormattingEnabled = true;
            this.AggregationComboBox.Location = new System.Drawing.Point(308, 127);
            this.AggregationComboBox.Name = "AggregationComboBox";
            this.AggregationComboBox.Size = new System.Drawing.Size(121, 21);
            this.AggregationComboBox.TabIndex = 25;
            // 
            // MembershipComboBox
            // 
            this.MembershipComboBox.FormattingEnabled = true;
            this.MembershipComboBox.Location = new System.Drawing.Point(308, 83);
            this.MembershipComboBox.Name = "MembershipComboBox";
            this.MembershipComboBox.Size = new System.Drawing.Size(121, 21);
            this.MembershipComboBox.TabIndex = 24;
            this.MembershipComboBox.SelectedIndexChanged += new System.EventHandler(this.MembershipComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Fuzzification Function";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Accumulation Function";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Activisation Function";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Aggregation Function";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Membership Function";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(464, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(367, 223);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // ChooseFunctionsNextButton
            // 
            this.ChooseFunctionsNextButton.Location = new System.Drawing.Point(354, 349);
            this.ChooseFunctionsNextButton.Name = "ChooseFunctionsNextButton";
            this.ChooseFunctionsNextButton.Size = new System.Drawing.Size(75, 23);
            this.ChooseFunctionsNextButton.TabIndex = 17;
            this.ChooseFunctionsNextButton.Text = "Next >";
            this.ChooseFunctionsNextButton.UseVisualStyleBackColor = true;
            this.ChooseFunctionsNextButton.Click += new System.EventHandler(this.ChooseFunctionsNextButton_Click);
            // 
            // TermCountLabel
            // 
            this.TermCountLabel.AutoSize = true;
            this.TermCountLabel.Location = new System.Drawing.Point(21, 28);
            this.TermCountLabel.Name = "TermCountLabel";
            this.TermCountLabel.Size = new System.Drawing.Size(42, 13);
            this.TermCountLabel.TabIndex = 5;
            this.TermCountLabel.Text = "Terms :";
            // 
            // InputVariablesPanel
            // 
            this.InputVariablesPanel.Controls.Add(this.InputVariables);
            this.InputVariablesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputVariablesPanel.Location = new System.Drawing.Point(0, 0);
            this.InputVariablesPanel.Name = "InputVariablesPanel";
            this.InputVariablesPanel.Size = new System.Drawing.Size(1024, 448);
            this.InputVariablesPanel.TabIndex = 30;
            this.InputVariablesPanel.Visible = false;
            // 
            // InputVariables
            // 
            this.InputVariables.AutoSize = true;
            this.InputVariables.Location = new System.Drawing.Point(37, 41);
            this.InputVariables.Name = "InputVariables";
            this.InputVariables.Size = new System.Drawing.Size(79, 13);
            this.InputVariables.TabIndex = 1;
            this.InputVariables.Text = "Input variables:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 448);
            this.Controls.Add(this.AddTermsPanel);
            this.Controls.Add(this.LVCountConfirmButton);
            this.Controls.Add(this.LVCountUpDown);
            this.Controls.Add(this.LVCountLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.LVCountUpDown)).EndInit();
            this.AddTermsPanel.ResumeLayout(false);
            this.AddTermsPanel.PerformLayout();
            this.ChooseFunctionsPanel.ResumeLayout(false);
            this.ChooseFunctionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.InputVariablesPanel.ResumeLayout(false);
            this.InputVariablesPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LVCountLabel;
        private System.Windows.Forms.NumericUpDown LVCountUpDown;
        private System.Windows.Forms.Button LVCountConfirmButton;
        private System.Windows.Forms.Panel ChooseFunctionsPanel;
        private System.Windows.Forms.ComboBox FuzzificationComboBox;
        private System.Windows.Forms.ComboBox AccumulationComboBox;
        private System.Windows.Forms.ComboBox ActivisationComboBox;
        private System.Windows.Forms.ComboBox AggregationComboBox;
        private System.Windows.Forms.ComboBox MembershipComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ChooseFunctionsNextButton;
        private System.Windows.Forms.Button ChooseFunctionsBackButton;
        private System.Windows.Forms.Panel AddTermsPanel;
        private System.Windows.Forms.Label TermCountLabel;
        private System.Windows.Forms.Panel InputVariablesPanel;
        private System.Windows.Forms.Label InputVariables;
    }
}

