namespace WindowsFormsApplication1
{
    partial class MembershipFunctionChoise
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
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MembershipComboBox = new System.Windows.Forms.ComboBox();
            this.AggregationComboBox = new System.Windows.Forms.ComboBox();
            this.ActivisationComboBox = new System.Windows.Forms.ComboBox();
            this.AccumulationComboBox = new System.Windows.Forms.ComboBox();
            this.FuzzificationComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Next >";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(282, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(367, 223);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Membership Function";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Aggregation Function";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Activisation Function";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Accumulation Function";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Fuzzification Function";
            // 
            // MembershipComboBox
            // 
            this.MembershipComboBox.FormattingEnabled = true;
            this.MembershipComboBox.Location = new System.Drawing.Point(126, 53);
            this.MembershipComboBox.Name = "MembershipComboBox";
            this.MembershipComboBox.Size = new System.Drawing.Size(121, 21);
            this.MembershipComboBox.TabIndex = 12;
            this.MembershipComboBox.SelectedIndexChanged += new System.EventHandler(this.MembershipComboBox_SelectedIndexChanged);
            // 
            // AggregationComboBox
            // 
            this.AggregationComboBox.FormattingEnabled = true;
            this.AggregationComboBox.Location = new System.Drawing.Point(126, 97);
            this.AggregationComboBox.Name = "AggregationComboBox";
            this.AggregationComboBox.Size = new System.Drawing.Size(121, 21);
            this.AggregationComboBox.TabIndex = 13;
            // 
            // ActivisationComboBox
            // 
            this.ActivisationComboBox.FormattingEnabled = true;
            this.ActivisationComboBox.Location = new System.Drawing.Point(126, 146);
            this.ActivisationComboBox.Name = "ActivisationComboBox";
            this.ActivisationComboBox.Size = new System.Drawing.Size(121, 21);
            this.ActivisationComboBox.TabIndex = 14;
            // 
            // AccumulationComboBox
            // 
            this.AccumulationComboBox.FormattingEnabled = true;
            this.AccumulationComboBox.Location = new System.Drawing.Point(126, 203);
            this.AccumulationComboBox.Name = "AccumulationComboBox";
            this.AccumulationComboBox.Size = new System.Drawing.Size(121, 21);
            this.AccumulationComboBox.TabIndex = 15;
            // 
            // FuzzificationComboBox
            // 
            this.FuzzificationComboBox.FormattingEnabled = true;
            this.FuzzificationComboBox.Location = new System.Drawing.Point(126, 254);
            this.FuzzificationComboBox.Name = "FuzzificationComboBox";
            this.FuzzificationComboBox.Size = new System.Drawing.Size(121, 21);
            this.FuzzificationComboBox.TabIndex = 16;
            // 
            // MembershipFunctionChoise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 366);
            this.Controls.Add(this.FuzzificationComboBox);
            this.Controls.Add(this.AccumulationComboBox);
            this.Controls.Add(this.ActivisationComboBox);
            this.Controls.Add(this.AggregationComboBox);
            this.Controls.Add(this.MembershipComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Name = "MembershipFunctionChoise";
            this.Text = "MembershipFunctionChoise";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox MembershipComboBox;
        private System.Windows.Forms.ComboBox AggregationComboBox;
        private System.Windows.Forms.ComboBox ActivisationComboBox;
        private System.Windows.Forms.ComboBox AccumulationComboBox;
        private System.Windows.Forms.ComboBox FuzzificationComboBox;
    }
}