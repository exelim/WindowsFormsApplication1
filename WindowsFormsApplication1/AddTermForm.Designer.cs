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
            this.components = new System.ComponentModel.Container();
            this.MembershipFunctionGraph = new ZedGraph.ZedGraphControl();
            this.ALabel = new System.Windows.Forms.Label();
            this.BLabel = new System.Windows.Forms.Label();
            this.MembershipCombobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AInput = new System.Windows.Forms.TextBox();
            this.BInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MembershipFunctionGraph
            // 
            this.MembershipFunctionGraph.Location = new System.Drawing.Point(160, 35);
            this.MembershipFunctionGraph.Name = "MembershipFunctionGraph";
            this.MembershipFunctionGraph.ScrollGrace = 0D;
            this.MembershipFunctionGraph.ScrollMaxX = 0D;
            this.MembershipFunctionGraph.ScrollMaxY = 0D;
            this.MembershipFunctionGraph.ScrollMaxY2 = 0D;
            this.MembershipFunctionGraph.ScrollMinX = 0D;
            this.MembershipFunctionGraph.ScrollMinY = 0D;
            this.MembershipFunctionGraph.ScrollMinY2 = 0D;
            this.MembershipFunctionGraph.Size = new System.Drawing.Size(496, 292);
            this.MembershipFunctionGraph.TabIndex = 42;
            // 
            // ALabel
            // 
            this.ALabel.AutoSize = true;
            this.ALabel.Location = new System.Drawing.Point(24, 99);
            this.ALabel.Name = "ALabel";
            this.ALabel.Size = new System.Drawing.Size(19, 13);
            this.ALabel.TabIndex = 43;
            this.ALabel.Text = "g :";
            // 
            // BLabel
            // 
            this.BLabel.AutoSize = true;
            this.BLabel.Location = new System.Drawing.Point(92, 99);
            this.BLabel.Name = "BLabel";
            this.BLabel.Size = new System.Drawing.Size(19, 13);
            this.BLabel.TabIndex = 44;
            this.BLabel.Text = "c :";
            // 
            // MembershipCombobox
            // 
            this.MembershipCombobox.FormattingEnabled = true;
            this.MembershipCombobox.Location = new System.Drawing.Point(12, 57);
            this.MembershipCombobox.Name = "MembershipCombobox";
            this.MembershipCombobox.Size = new System.Drawing.Size(121, 21);
            this.MembershipCombobox.TabIndex = 45;
            this.MembershipCombobox.SelectedIndexChanged += new System.EventHandler(this.MembershipCombobox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Membership function :";
            // 
            // AInput
            // 
            this.AInput.Location = new System.Drawing.Point(12, 132);
            this.AInput.Name = "AInput";
            this.AInput.Size = new System.Drawing.Size(49, 20);
            this.AInput.TabIndex = 47;
            this.AInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AInput_KeyPress);
            // 
            // BInput
            // 
            this.BInput.Location = new System.Drawing.Point(84, 132);
            this.BInput.Name = "BInput";
            this.BInput.Size = new System.Drawing.Size(49, 20);
            this.BInput.TabIndex = 48;
            this.BInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BInput_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 50;
            this.button2.Text = "Draw!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddTermForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 356);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BInput);
            this.Controls.Add(this.AInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MembershipCombobox);
            this.Controls.Add(this.BLabel);
            this.Controls.Add(this.ALabel);
            this.Controls.Add(this.MembershipFunctionGraph);
            this.Name = "AddTermForm";
            this.Text = "AddTermForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl MembershipFunctionGraph;
        private System.Windows.Forms.Label ALabel;
        private System.Windows.Forms.Label BLabel;
        private System.Windows.Forms.ComboBox MembershipCombobox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AInput;
        private System.Windows.Forms.TextBox BInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

    }
}