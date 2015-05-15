﻿namespace WindowsFormsApplication1
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
            this.components = new System.ComponentModel.Container();
            this.LVCountLabel = new System.Windows.Forms.Label();
            this.LVCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.LVCountConfirmButton = new System.Windows.Forms.Button();
            this.AddTermsPanel = new System.Windows.Forms.Panel();
            this.ChooseFunctionsPanel = new System.Windows.Forms.Panel();
            this.InputVariablesPanel = new System.Windows.Forms.Panel();
            this.ProductionRulesInputPanel = new System.Windows.Forms.Panel();
            this.ResultPanel = new System.Windows.Forms.Panel();
            this.ResultDescriptionLabel = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.ResultBackButton = new System.Windows.Forms.Button();
            this.FinalGraph = new ZedGraph.ZedGraphControl();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.prodRulesTB = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.InputVariables = new System.Windows.Forms.Label();
            this.ChooseFunctionsBackButton = new System.Windows.Forms.Button();
            this.FuzzificationComboBox = new System.Windows.Forms.ComboBox();
            this.AccumulationComboBox = new System.Windows.Forms.ComboBox();
            this.ActivisationComboBox = new System.Windows.Forms.ComboBox();
            this.AggregationComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ChooseFunctionsNextButton = new System.Windows.Forms.Button();
            this.TermCountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LVCountUpDown)).BeginInit();
            this.AddTermsPanel.SuspendLayout();
            this.ChooseFunctionsPanel.SuspendLayout();
            this.InputVariablesPanel.SuspendLayout();
            this.ProductionRulesInputPanel.SuspendLayout();
            this.ResultPanel.SuspendLayout();
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
            this.ChooseFunctionsPanel.Controls.Add(this.label5);
            this.ChooseFunctionsPanel.Controls.Add(this.label4);
            this.ChooseFunctionsPanel.Controls.Add(this.label3);
            this.ChooseFunctionsPanel.Controls.Add(this.label2);
            this.ChooseFunctionsPanel.Controls.Add(this.label1);
            this.ChooseFunctionsPanel.Controls.Add(this.ChooseFunctionsNextButton);
            this.ChooseFunctionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChooseFunctionsPanel.Location = new System.Drawing.Point(0, 0);
            this.ChooseFunctionsPanel.Name = "ChooseFunctionsPanel";
            this.ChooseFunctionsPanel.Size = new System.Drawing.Size(1024, 448);
            this.ChooseFunctionsPanel.TabIndex = 6;
            // 
            // InputVariablesPanel
            // 
            this.InputVariablesPanel.Controls.Add(this.ProductionRulesInputPanel);
            this.InputVariablesPanel.Controls.Add(this.InputVariables);
            this.InputVariablesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputVariablesPanel.Location = new System.Drawing.Point(0, 0);
            this.InputVariablesPanel.Name = "InputVariablesPanel";
            this.InputVariablesPanel.Size = new System.Drawing.Size(1024, 448);
            this.InputVariablesPanel.TabIndex = 31;
            this.InputVariablesPanel.Visible = false;
            // 
            // ProductionRulesInputPanel
            // 
            this.ProductionRulesInputPanel.Controls.Add(this.ResultPanel);
            this.ProductionRulesInputPanel.Controls.Add(this.button2);
            this.ProductionRulesInputPanel.Controls.Add(this.button1);
            this.ProductionRulesInputPanel.Controls.Add(this.label7);
            this.ProductionRulesInputPanel.Controls.Add(this.prodRulesTB);
            this.ProductionRulesInputPanel.Controls.Add(this.label13);
            this.ProductionRulesInputPanel.Controls.Add(this.label12);
            this.ProductionRulesInputPanel.Controls.Add(this.label11);
            this.ProductionRulesInputPanel.Controls.Add(this.label10);
            this.ProductionRulesInputPanel.Controls.Add(this.label9);
            this.ProductionRulesInputPanel.Controls.Add(this.label8);
            this.ProductionRulesInputPanel.Controls.Add(this.label6);
            this.ProductionRulesInputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductionRulesInputPanel.Location = new System.Drawing.Point(0, 0);
            this.ProductionRulesInputPanel.Name = "ProductionRulesInputPanel";
            this.ProductionRulesInputPanel.Size = new System.Drawing.Size(1024, 448);
            this.ProductionRulesInputPanel.TabIndex = 2;
            this.ProductionRulesInputPanel.Visible = false;
            // 
            // ResultPanel
            // 
            this.ResultPanel.Controls.Add(this.ResultDescriptionLabel);
            this.ResultPanel.Controls.Add(this.ResultLabel);
            this.ResultPanel.Controls.Add(this.ResultBackButton);
            this.ResultPanel.Controls.Add(this.FinalGraph);
            this.ResultPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultPanel.Location = new System.Drawing.Point(0, 0);
            this.ResultPanel.Name = "ResultPanel";
            this.ResultPanel.Size = new System.Drawing.Size(1024, 448);
            this.ResultPanel.TabIndex = 8;
            this.ResultPanel.Visible = false;
            // 
            // ResultDescriptionLabel
            // 
            this.ResultDescriptionLabel.AutoSize = true;
            this.ResultDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultDescriptionLabel.Location = new System.Drawing.Point(657, 99);
            this.ResultDescriptionLabel.Name = "ResultDescriptionLabel";
            this.ResultDescriptionLabel.Size = new System.Drawing.Size(75, 25);
            this.ResultDescriptionLabel.TabIndex = 45;
            this.ResultDescriptionLabel.Text = "label14";
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultLabel.Location = new System.Drawing.Point(685, 41);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(204, 25);
            this.ResultLabel.TabIndex = 43;
            this.ResultLabel.Text = "Computation result :";
            // 
            // ResultBackButton
            // 
            this.ResultBackButton.Location = new System.Drawing.Point(24, 413);
            this.ResultBackButton.Name = "ResultBackButton";
            this.ResultBackButton.Size = new System.Drawing.Size(75, 23);
            this.ResultBackButton.TabIndex = 42;
            this.ResultBackButton.Text = "< Back";
            this.ResultBackButton.UseVisualStyleBackColor = true;
            this.ResultBackButton.Click += new System.EventHandler(this.ResultBackButton_Click);
            // 
            // FinalGraph
            // 
            this.FinalGraph.Location = new System.Drawing.Point(24, 21);
            this.FinalGraph.Name = "FinalGraph";
            this.FinalGraph.ScrollGrace = 0D;
            this.FinalGraph.ScrollMaxX = 0D;
            this.FinalGraph.ScrollMaxY = 0D;
            this.FinalGraph.ScrollMaxY2 = 0D;
            this.FinalGraph.ScrollMinX = 0D;
            this.FinalGraph.ScrollMinY = 0D;
            this.FinalGraph.ScrollMinY2 = 0D;
            this.FinalGraph.Size = new System.Drawing.Size(574, 359);
            this.FinalGraph.TabIndex = 41;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(118, 339);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "< Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Next >";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(14, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(274, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Enter productions rules in form below:";
            // 
            // prodRulesTB
            // 
            this.prodRulesTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prodRulesTB.Location = new System.Drawing.Point(18, 57);
            this.prodRulesTB.Name = "prodRulesTB";
            this.prodRulesTB.Size = new System.Drawing.Size(543, 259);
            this.prodRulesTB.TabIndex = 4;
            this.prodRulesTB.Text = "if s is p OR f is b then t is c\nif s is g OR f is b then t is a\nif s is e OR f is" +
    " g then t is g";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(625, 275);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(250, 25);
            this.label13.TabIndex = 15;
            this.label13.Text = "- OV - output variable value";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(625, 245);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(205, 25);
            this.label12.TabIndex = 14;
            this.label12.Text = "- Y - output variable ID";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(625, 216);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(298, 25);
            this.label11.TabIndex = 13;
            this.label11.Text = "- IV1, IV2 - input variables values";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(625, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(264, 25);
            this.label10.TabIndex = 12;
            this.label10.Text = "- X1, X2 - input variables ID\'s";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(603, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 25);
            this.label9.TabIndex = 11;
            this.label9.Text = "Where :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(603, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(397, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "if X1 is IV1 [ANR/OR X2 is IV2] then Y is OV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(745, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Example :";
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
            // ChooseFunctionsBackButton
            // 
            this.ChooseFunctionsBackButton.Location = new System.Drawing.Point(77, 318);
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
            this.FuzzificationComboBox.Location = new System.Drawing.Point(198, 254);
            this.FuzzificationComboBox.Name = "FuzzificationComboBox";
            this.FuzzificationComboBox.Size = new System.Drawing.Size(121, 21);
            this.FuzzificationComboBox.TabIndex = 28;
            // 
            // AccumulationComboBox
            // 
            this.AccumulationComboBox.FormattingEnabled = true;
            this.AccumulationComboBox.Location = new System.Drawing.Point(198, 203);
            this.AccumulationComboBox.Name = "AccumulationComboBox";
            this.AccumulationComboBox.Size = new System.Drawing.Size(121, 21);
            this.AccumulationComboBox.TabIndex = 27;
            // 
            // ActivisationComboBox
            // 
            this.ActivisationComboBox.FormattingEnabled = true;
            this.ActivisationComboBox.Location = new System.Drawing.Point(198, 146);
            this.ActivisationComboBox.Name = "ActivisationComboBox";
            this.ActivisationComboBox.Size = new System.Drawing.Size(121, 21);
            this.ActivisationComboBox.TabIndex = 26;
            // 
            // AggregationComboBox
            // 
            this.AggregationComboBox.FormattingEnabled = true;
            this.AggregationComboBox.Location = new System.Drawing.Point(198, 97);
            this.AggregationComboBox.Name = "AggregationComboBox";
            this.AggregationComboBox.Size = new System.Drawing.Size(121, 21);
            this.AggregationComboBox.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Fuzzification Function";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Accumulation Function";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Activisation Function";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Aggregation Function";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Enter calculation functions :";
            // 
            // ChooseFunctionsNextButton
            // 
            this.ChooseFunctionsNextButton.Location = new System.Drawing.Point(244, 319);
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
            this.InputVariablesPanel.ResumeLayout(false);
            this.InputVariablesPanel.PerformLayout();
            this.ProductionRulesInputPanel.ResumeLayout(false);
            this.ProductionRulesInputPanel.PerformLayout();
            this.ResultPanel.ResumeLayout(false);
            this.ResultPanel.PerformLayout();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ChooseFunctionsNextButton;
        private System.Windows.Forms.Button ChooseFunctionsBackButton;
        private System.Windows.Forms.Panel AddTermsPanel;
        private System.Windows.Forms.Label TermCountLabel;
        private System.Windows.Forms.Panel InputVariablesPanel;
        private System.Windows.Forms.Label InputVariables;
        private System.Windows.Forms.Panel ProductionRulesInputPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox prodRulesTB;
        private System.Windows.Forms.Panel ResultPanel;
        private ZedGraph.ZedGraphControl FinalGraph;
        private System.Windows.Forms.Button ResultBackButton;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label ResultDescriptionLabel;
    }
}

