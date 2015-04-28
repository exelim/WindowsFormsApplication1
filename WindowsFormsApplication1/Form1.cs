﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;

using WindowsFormsApplication1.Classes;
using WindowsFormsApplication1.Structures;

using WindowsFormsApplication1.Classes.Formulas.AggregationFormulas;
using WindowsFormsApplication1.Classes.Formulas.ActivisationFormulas;
using WindowsFormsApplication1.Classes.Formulas.AccumulationFormulas;
using WindowsFormsApplication1.Classes.MembershipFunctions;
using WindowsFormsApplication1.Classes.Formulas.FuzzificationFormulas;

using WindowsFormsApplication1.RuleParsing;

namespace WindowsFormsApplication1
{
    public enum VariableType { IN, OUT };
    public enum RelationType { AND, OR };

    public partial class Form1 : Form
    {

/// <summary>
/// Global variable declaration 
/// </summary>
/// 
        public static int lexicalVariablesCount;
        public static int termsCount;
        public static int fullTermsCount;
        public static Stack< ProductionRulesTerm >[] _terms;
        public static Array arr; 
        public static LexicalVariable[] lexicalVariables;
        static public ProductionRulesTerm[] _term;

        public static double[] inputVariables;

        int number;
        bool choseFunctionFormInitialized = false;
        int lastLExicalVariableTermsCount = 0;

        public static ProductionRule[] prodcutionsRules;
        public static Tuple<string, string, double>[] fuzzification_1_Values;   //  < output lexical variable id, input variable id, term id, fuzzification value>
        public static Dictionary<String, Stack<double>> aggregationValues;
        public static Dictionary<String, Stack<double>[]> activisationValues;
        public static Dictionary<String, Stack<double>> accumulationValues;


        const double drawStep = 0.1;

/// <summary>
/// Functoins declaration
/// </summary>
/// 
        public static AggregationFormulaBase aggregation_function;
        public static ActivisationFormulaBase activization_function;
        public static AccumulatiomFormulaBase accumulation_function;
        public static FuzzificationFormulaBase fuzzification_function;


        

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////   MAIN FORM     ////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Form1()
        {
            InitializeComponent();
        }

        private void LVCountConfirmButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(LVCountUpDown.Value) <= 0)
            {
                MessageBox.Show("Linguistic variables count should be greater than 0.");
            }

            else
            {
                if (lexicalVariablesCount != Convert.ToInt32(LVCountUpDown.Value))
                {
                    for (int i = 0; i <= lexicalVariablesCount; i++)
                    {
                        this.Controls.RemoveByKey("label_LVNumber_" + i);
                        this.Controls.RemoveByKey("label_LVID_" + i);
                        this.Controls.RemoveByKey("textbox_LVID_" + i);
                        this.Controls.RemoveByKey("label_LVName_" + i);
                        this.Controls.RemoveByKey("textbox_LVName_" + i);
                        this.Controls.RemoveByKey("label_LVMinrange_" + i);
                        this.Controls.RemoveByKey("upDown_LVMinrange_" + i);
                        this.Controls.RemoveByKey("label_LVMaxrange_" + i);
                        this.Controls.RemoveByKey("upDown_LVMaxrange_" + i);
                        this.Controls.RemoveByKey("upDown_TermsCount_" + i);
                        this.Controls.RemoveByKey("button_AddTerms_" + i);
                        this.Controls.RemoveByKey("LVOKButton");
                    }
                }

                lexicalVariablesCount = Convert.ToInt32(LVCountUpDown.Value);
                lexicalVariables = new LexicalVariable[lexicalVariablesCount];

                _terms = new Stack< ProductionRulesTerm >[lexicalVariablesCount];

                for( int i = 0; i < lexicalVariablesCount; i ++)
                {
                    _terms[i] = new Stack<ProductionRulesTerm>();
                }

                    for (int i = 0; i < LVCountUpDown.Value; i++)
                    {
                        // creating Label LV number
                        Label Numberlabel = new Label();
                        Numberlabel.Name = "label_LVNumber_" + i;
                        Numberlabel.Text = "Linguistic var №" + (i + 1) + ":";
                        Numberlabel.Width = 95;
                        Numberlabel.Location = new Point(LVCountLabel.Location.X, LVCountLabel.Location.Y + (25 + 25 * i));
                        this.Controls.Add(Numberlabel);

                        // creating Label LV ID
                        Label IDlabel = new Label();
                        IDlabel.Name = "label_LVID_" + i;
                        IDlabel.Text = "Id:";
                        IDlabel.Width = 20;
                        IDlabel.Location = new Point(Numberlabel.Location.X + Numberlabel.Width, LVCountLabel.Location.Y + (25 + 25 * i));
                        this.Controls.Add(IDlabel);

                        //creating TextBox for LV id
                        TextBox IDtextBox = new TextBox();
                        IDtextBox.Name = "textbox_LVID_" + i;
                        IDtextBox.Width = 50;
                        IDtextBox.Location = new Point(IDlabel.Location.X + IDlabel.Width, LVCountLabel.Location.Y + (25 + 25 * i));
                        IDtextBox.Text = "lvid_" + i; // DEBUG
                        if (i == 1) // DEBUG
                        {
                            IDtextBox.Text = "lvout"; // DEBUG
                        }
                        this.Controls.Add(IDtextBox);

                        // creating Label LV name
                        Label Namelabel = new Label();
                        Namelabel.Name = "label_LVName_" + i;
                        Namelabel.Text = "Linguistic var name:";
                        Namelabel.Width = 110;
                        Namelabel.Location = new Point(IDtextBox.Location.X + IDtextBox.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                        this.Controls.Add(Namelabel);

                        // creating TextBox for LV name
                        TextBox NametextBox = new TextBox();
                        NametextBox.Name = "textbox_LVName_" + i;
                        NametextBox.Width = 100;
                        NametextBox.Location = new Point(Namelabel.Location.X + Namelabel.Width, LVCountLabel.Location.Y + (25 + 25 * i));
                        NametextBox.Text = "lvname_" + i; // DEBUG
                        this.Controls.Add(NametextBox);

                        // creating Label LV min range
                        Label MinRangelabel = new Label();
                        MinRangelabel.Name = "label_LVMinrange_" + i;
                        MinRangelabel.Text = "Range from:";
                        MinRangelabel.Width = 65;
                        MinRangelabel.Location = new Point(NametextBox.Location.X + NametextBox.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                        this.Controls.Add(MinRangelabel);

                        // creating UpDown LV min range
                        NumericUpDown MinRangeUpDown = new NumericUpDown();
                        MinRangeUpDown.Name = "upDown_LVMinrange_" + i;
                        MinRangeUpDown.Width = 36;
                        MinRangeUpDown.Location = new Point(MinRangelabel.Location.X + MinRangelabel.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                        this.Controls.Add(MinRangeUpDown);

                        // creating Label LV max range
                        Label MaxRangelabel = new Label();
                        MaxRangelabel.Name = "label_LVMaxrange_" + i;
                        MaxRangelabel.Text = "Range to:";
                        MaxRangelabel.Width = 60;
                        MaxRangelabel.Location = new Point(MinRangeUpDown.Location.X + MinRangeUpDown.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                        this.Controls.Add(MaxRangelabel);

                        // creating UpDown LV max range
                        NumericUpDown MaxRangeUpDown = new NumericUpDown();
                        MaxRangeUpDown.Name = "upDown_LVMaxrange_" + i;
                        MaxRangeUpDown.Width = 36;
                        MaxRangeUpDown.Location = new Point(MaxRangelabel.Location.X + MaxRangelabel.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                        MaxRangeUpDown.Value = 1 + (10 * i);  // DEBUG
                        this.Controls.Add(MaxRangeUpDown);

                        // creating Label LV type
                        Label Typelabel = new Label();
                        Typelabel.Name = "label_LVType_" + i;
                        Typelabel.Text = "Type:";
                        Typelabel.Width = 40;
                        Typelabel.Location = new Point(MaxRangeUpDown.Location.X + MaxRangeUpDown.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                        this.Controls.Add(Typelabel);

                        // creating UpDown LV type
                        ComboBox TypeList = new ComboBox();
                        TypeList.Name = "List_LVType_" + i;
                        TypeList.Width = 45;
                        TypeList.Items.Add("IN");
                        TypeList.Items.Add("OUT");
                        TypeList.SelectedIndex = 0;
                        TypeList.Location = new Point(Typelabel.Location.X + Typelabel.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                        this.Controls.Add(TypeList);
                        if (i == 1) // DEBUG
                        {
                            TypeList.SelectedIndex = 1; // DEBUG
                        }

                        // creating Label Terms count
                        Label TermsCountlabel = new Label();
                        TermsCountlabel.Name = "label_LVTermsCount_" + i;
                        TermsCountlabel.Text = "Terms count:";
                        TermsCountlabel.Width = 70;
                        TermsCountlabel.Location = new Point(TypeList.Location.X + TypeList.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                        this.Controls.Add(TermsCountlabel);

                        // creating UpDown terms Count
                        NumericUpDown TermsCountUpDown = new NumericUpDown();
                        TermsCountUpDown.Name = "upDown_TermsCount_" + i;
                        TermsCountUpDown.Width = 36;
                        TermsCountUpDown.Location = new Point(TermsCountlabel.Location.X + TermsCountlabel.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                        TermsCountUpDown.Value = 1;
                        this.Controls.Add(TermsCountUpDown);

                        // creating button add terms
                        Button AddTerms = new Button();
                        AddTerms.Name = "button_AddTerms_" + i;
                        AddTerms.Width = 90;
                        AddTerms.Text = "Add terms";
                        AddTerms.Location = new Point(TermsCountUpDown.Location.X + TermsCountUpDown.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                        AddTerms.Click += AddTermsButton_Clicked;
                        this.Controls.Add(AddTerms);
                    }

                // creating OK button
                Button LVNextButton = new Button();
                LVNextButton.Name = "LVOKButton";
                LVNextButton.Text = "Next >";
                LVNextButton.Location = new Point(LVCountLabel.Location.X, LVCountLabel.Location.Y + lexicalVariablesCount * 25 + 25);
                LVNextButton.Click += NextButton_Clicked;
                this.Controls.Add(LVNextButton);
            }
        }

        void AddTermsButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            termsCount = Convert.ToInt32(this.Controls["upDown_TermsCount_" + button.Name.Substring(button.Name.Length-1, 1)].Text);
            
            if (termsCount <= 0)
            {
                MessageBox.Show("Terms count should be greater than 0.");
            }
            else
            {
                //addTermsForm = new AddTermForm(Convert.ToInt32(button.Name.Substring(button.Name.Length - 1, 1)));
                //addTermsForm.ShowDialog();
                number = Convert.ToInt32(button.Name.Substring(button.Name.Length - 1, 1));
                AddTermsPanel.Visible = true;
                ChooseFunctionsPanel.Visible = false;
                FillAddTermsForm();
            }
        }

        void NextButton_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < lexicalVariablesCount; i++)
            {
                string ID = this.Controls["textbox_LVID_" + i].Text;
                if (ID == "")
                {
                    MessageBox.Show("Error! Linguistic's variable №" + (i + 1) + " ID is empty!");
                    return;
                }
                string LVName = this.Controls["textbox_LVName_" + i].Text;
                if (LVName == "")
                {
                    MessageBox.Show("Error! Linguistic's variable №" + ( i + 1 ) + " name is empty!");
                    return;
                }
                int LVMinValue = Convert.ToInt32(this.Controls["upDown_LVMinrange_" + i].Text);
                int LVMaxValue = Convert.ToInt32(this.Controls["upDown_LVMaxrange_" + i].Text);
                if (LVMinValue >= LVMaxValue)
                {
                    MessageBox.Show("Error! Linguistic's variable №" + ( i + 1 ) + " minimal value is equal greater than maximal!");
                    return;
                }
                int termsCount = Convert.ToInt32(this.Controls["upDown_TermsCount_" + i].Text);
                VariableType type = VariableType.IN;
                switch (this.Controls["List_LVType_" + i].Text)
                { 
                    case "IN":
                        type = VariableType.IN;
                        break;
                    case "OUT":
                        type = VariableType.OUT;
                        break;
                }


                ProductionRulesTerm[] terms = new ProductionRulesTerm[termsCount];
                if (termsCount <= 0)
                {
                    MessageBox.Show("Error! Linguistic's variable №" + ( i + 1 ) + " terms count should be greater than 0!");
                    return;
                }
                else
                {
                    fullTermsCount += termsCount;
                    for (int j = 0; j < termsCount; j++)
                    {
                        if (_terms.ElementAt( i ).ElementAt( j ).m_ID == null)
                        {
                            MessageBox.Show("Error! You should first add terms for all linguistic variables!");
                            return;
                        }

                        terms[j] = _terms.ElementAt(i).ElementAt(j);
                    }
                    lexicalVariables[i] = new LexicalVariable(ID, LVName, LVMinValue, LVMaxValue, termsCount, terms, type);
                }
            }

            //inputVariablesForm = new InputVariablesForm(lexicalVariablesCount);
            AddTermsPanel.Visible = true;
            ChooseFunctionsPanel.Visible = true;
            FillChooseFunctionForm();
            //Close();
            //inputVariablesForm.ShowDialog();
           // MembershipFunctionChoise  choiseFunctionForm = new MembershipFunctionChoise();
            //choiseFunctionForm.ShowDialog();
            //AddTermsPanel.Visible = true;

        }

 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////   ADD TERMS FORM     ////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void FillAddTermsForm()
        {
            for (int i = 0; i <= lastLExicalVariableTermsCount; i++)
            {
                AddTermsPanel.Controls.RemoveByKey("label_TermsCount_" + i);
                AddTermsPanel.Controls.RemoveByKey("label_TermID_" + i);
                AddTermsPanel.Controls.RemoveByKey("textbox_TermID_" + i);
                AddTermsPanel.Controls.RemoveByKey("label_TermsName_" + i);
                AddTermsPanel.Controls.RemoveByKey("textbox_TermName_" + i);
                AddTermsPanel.Controls.RemoveByKey("label_TermMinrange_" + i);
                AddTermsPanel.Controls.RemoveByKey("upDown_TermMinrange_" + i);
                AddTermsPanel.Controls.RemoveByKey("label_TermMaxrange_" + i);
                AddTermsPanel.Controls.RemoveByKey("upDown_TermMaxrange_" + i);
            }

            AddTermsPanel.Controls.RemoveByKey("TermOKButton");
            AddTermsPanel.Controls.RemoveByKey("TermCancelButton");

            for (int i = 0; i < termsCount; i++)
            {
                // creating Label Terms count
                Label Numberlabel = new Label();
                Numberlabel.Name = "label_TermsCount_" + i;
                Numberlabel.Text = "Term №" + (i + 1) + ":";
                Numberlabel.Width = 60;
                Numberlabel.Location = new Point(TermCountLabel.Location.X, TermCountLabel.Location.Y + (25 + 25 * i));
                AddTermsPanel.Controls.Add(Numberlabel);

                // creating Label Term ID
                Label IDlabel = new Label();
                IDlabel.Name = "label_TermID_" + i;
                IDlabel.Text = "Id:";
                IDlabel.Width = 20;
                IDlabel.Location = new Point(Numberlabel.Location.X + Numberlabel.Width, TermCountLabel.Location.Y + (25 + 25 * i));
                AddTermsPanel.Controls.Add(IDlabel);

                //creating TextBox for Terms ID
                TextBox IDtextBox = new TextBox();
                IDtextBox.Name = "textbox_TermID_" + i;
                IDtextBox.Width = 50;
                IDtextBox.Location = new Point(IDlabel.Location.X + IDlabel.Width, TermCountLabel.Location.Y + (25 + 25 * i));
                IDtextBox.Text = "tmid_" + i;  // DEBUG
                AddTermsPanel.Controls.Add(IDtextBox);

                // creating Label Term name
                Label Namelabel = new Label();
                Namelabel.Name = "label_TermsName_" + i;
                Namelabel.Text = "Terms name:";
                Namelabel.Width = 70;
                Namelabel.Location = new Point(IDtextBox.Location.X + IDtextBox.Width + 5, TermCountLabel.Location.Y + (25 + 25 * i));
                AddTermsPanel.Controls.Add(Namelabel);

                // creating TextBox for Term name
                TextBox NametextBox = new TextBox();
                NametextBox.Name = "textbox_TermName_" + i;
                NametextBox.Width = 100;
                NametextBox.Location = new Point(Namelabel.Location.X + Namelabel.Width, TermCountLabel.Location.Y + (25 + 25 * i));
                NametextBox.Text = "tmname_" + i;  // DEBUG
                AddTermsPanel.Controls.Add(NametextBox);

                // creating Label Term min range
                Label MinRangelabel = new Label();
                MinRangelabel.Name = "label_TermMinrange_" + i;
                MinRangelabel.Text = "Range from:";
                MinRangelabel.Width = 65;
                MinRangelabel.Location = new Point(NametextBox.Location.X + NametextBox.Width + 5, TermCountLabel.Location.Y + (25 + 25 * i));
                AddTermsPanel.Controls.Add(MinRangelabel);

                // creating UpDown Term min range
                NumericUpDown MinRangeUpDown = new NumericUpDown();
                MinRangeUpDown.Name = "upDown_TermMinrange_" + i;
                MinRangeUpDown.Width = 36;
                MinRangeUpDown.Location = new Point(MinRangelabel.Location.X + MinRangelabel.Width + 5, TermCountLabel.Location.Y + (25 + 25 * i));
                AddTermsPanel.Controls.Add(MinRangeUpDown);

                // creating Label Term max range
                Label MaxRangelabel = new Label();
                MaxRangelabel.Name = "label_TermMaxrange_" + i;
                MaxRangelabel.Text = "Range to:";
                MaxRangelabel.Width = 60;
                MaxRangelabel.Location = new Point(MinRangeUpDown.Location.X + MinRangeUpDown.Width + 5, TermCountLabel.Location.Y + (25 + 25 * i));
                AddTermsPanel.Controls.Add(MaxRangelabel);

                // creating UpDown Term max range
                NumericUpDown MaxRangeUpDown = new NumericUpDown();
                MaxRangeUpDown.Name = "upDown_TermMaxrange_" + i;
                MaxRangeUpDown.Width = 36;
                MaxRangeUpDown.Location = new Point(MaxRangelabel.Location.X + MaxRangelabel.Width + 5, TermCountLabel.Location.Y + (25 + 25 * i));
                MaxRangeUpDown.Value = 1 + 10 * i; // DEBUG
                AddTermsPanel.Controls.Add(MaxRangeUpDown);
            }

            // creating OK button
            Button TermsOKButton = new Button();
            TermsOKButton.Name = "TermOKButton";
            TermsOKButton.Text = "Accept";
            TermsOKButton.Location = new Point(TermCountLabel.Location.X, TermCountLabel.Location.Y + termsCount * 25 + 25);
            AddTermsPanel.Controls.Add(TermsOKButton);
            TermsOKButton.Click += OKButton_Clicked;

            // creating Cancel button
            Button termsCancelButton = new Button();
            termsCancelButton.Name = "TermCancelButton";
            termsCancelButton.Text = "Cancel";
            termsCancelButton.Location = new Point(TermCountLabel.Location.X + 100, TermCountLabel.Location.Y + termsCount * 25 + 25);
            AddTermsPanel.Controls.Add(termsCancelButton);
            termsCancelButton.Click += CancelButton_Clicked;

            lastLExicalVariableTermsCount = termsCount;
        }

        void OKButton_Clicked(object sender, EventArgs e )
        {
            _term = new ProductionRulesTerm[termsCount];
            bool shouldClose = false;
            for (int i = 0; i < termsCount; i++)
            {
                string ID = AddTermsPanel.Controls["textbox_TermID_" + i].Text;
                if (ID == "")
                {
                    MessageBox.Show("Error! Term's №" + (i + 1) + " ID is empty!");
                    shouldClose = false;
                    break;
                }

                string termName = AddTermsPanel.Controls["textbox_TermName_" + i].Text;
                if (termName == "")
                {
                    MessageBox.Show("Error! Term's №" + (i + 1) + " name is empty!");
                    shouldClose = false;
                    break;
                }

                int termMinRange = Convert.ToInt32(AddTermsPanel.Controls["upDown_TermMinrange_" + i].Text);
                int termMaxRange = Convert.ToInt32(AddTermsPanel.Controls["upDown_TermMaxrange_" + i].Text);
                if (termMinRange >= termMaxRange)
                {
                    MessageBox.Show("Error! Term's №" + (i + 1) + " minimum ragne is equal or greater than maximum range!");
                    shouldClose = false;
                    break;
                }

                shouldClose = true;
                _term[i] = new ProductionRulesTerm(ID, termName, termMinRange, termMaxRange);
                _terms.ElementAt(number).Push( _term[i] );
            }
            if (shouldClose)
            {
                AddTermsPanel.Visible = false;
            }
        }

        void CancelButton_Clicked(object sender, EventArgs e)
        {
            AddTermsPanel.Visible = false;
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////      CHOOSE FUNCTION FORM     //////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void FillChooseFunctionForm()
        {
            if (!choseFunctionFormInitialized)
            {
                MembershipComboBox.Items.Add("Gauss Function");
                MembershipComboBox.Items.Add("Sigmoid Function");
                MembershipComboBox.Items.Add("Singleton Function");
                MembershipComboBox.Items.Add("Trapezoidal Function");
                MembershipComboBox.Items.Add("Triangle Function");
                MembershipComboBox.SelectedIndex = 0;

                AggregationComboBox.Items.Add("Limited Function");
                AggregationComboBox.Items.Add("Algebraic Function");
                AggregationComboBox.Items.Add("MaxMin Function");
                AggregationComboBox.SelectedIndex = 0;

                ActivisationComboBox.Items.Add("Min Function");
                ActivisationComboBox.Items.Add("Prod Function");
                ActivisationComboBox.Items.Add("Avarage Function");
                ActivisationComboBox.SelectedIndex = 0;

                AccumulationComboBox.Items.Add("Limited Function");
                AccumulationComboBox.Items.Add("Algebraic Function");
                AccumulationComboBox.Items.Add("MaxMin Function");
                AccumulationComboBox.SelectedIndex = 0;

                FuzzificationComboBox.Items.Add("Center of gravity Function");
                FuzzificationComboBox.Items.Add("Center of gravity point sets Function");
                FuzzificationComboBox.Items.Add("Center square Function");
                FuzzificationComboBox.Items.Add("Left module value Function");
                FuzzificationComboBox.SelectedIndex = 0;

                choseFunctionFormInitialized = true;
            }
        }

        private void MembershipComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (MembershipComboBox.SelectedIndex)
            {
                case 0: // Gaus
                    ALabel.Text = "g :";
                    BLabel.Visible = false;
                    CLabel.Visible = true;
                    DLabel.Visible = false;
                    BLabelInput.Visible = false;
                    CLabelInput.Visible = true;
                    DLabelInput.Visible = false;
                    break;
                case 1: // Sigmoid
                    ALabel.Text = "a :";
                    BLabel.Visible = false;
                    CLabel.Visible = true;
                    DLabel.Visible = false;
                    BLabelInput.Visible = false;
                    CLabelInput.Visible = true;
                    DLabelInput.Visible = false;
                    break;
                case 2: // Singleton
                    ALabel.Text = "a :";
                    BLabel.Visible = false;
                    CLabel.Visible = false;
                    DLabel.Visible = false;
                    BLabelInput.Visible = false;
                    CLabelInput.Visible = false;
                    DLabelInput.Visible = false;
                    break;
                case 3: // Tpapezoidal
                    ALabel.Text = "a :";
                    BLabel.Visible = true;
                    CLabel.Visible = true;
                    DLabel.Visible = true;
                    BLabelInput.Visible = true;
                    CLabelInput.Visible = true;
                    DLabelInput.Visible = true;
                    break;
                case 4: // Triangle  
                    ALabel.Text = "a :";
                    BLabel.Visible = true;
                    CLabel.Visible = true;
                    DLabel.Visible = false;
                    BLabelInput.Visible = true;
                    CLabelInput.Visible = true;
                    DLabelInput.Visible = false;
                    break;
            }
        }

        private void ChooseFunctionsNextButton_Click(object sender, EventArgs e)
        {
            switch (MembershipComboBox.SelectedIndex)
            {
                case 0: // Gaus
                    for (int i = 0; i < lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_termsCount; i++)
                    {
                        lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_membershipFinction = new GaussFunction(Convert.ToInt32(ALabelInput.Text), 0, Convert.ToInt32(CLabelInput.Text), 0);
                    }
                    break;
                case 1: // sigmoid
                    for (int i = 0; i < lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_termsCount; i++)
                    {
                        lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_membershipFinction = new SigmoidFunction(Convert.ToInt32(ALabelInput.Text), 0, Convert.ToInt32(CLabelInput.Text), 0);
                    }
                    break;
                case 2: // Singleton 
                    for (int i = 0; i < lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_termsCount; i++)
                    {
                        lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_membershipFinction = new SingletonFunction(Convert.ToInt32(ALabelInput.Text), 0, 0, 0);
                    }
                    break;
                case 3: // Tpapezoidal
                    for (int i = 0; i < lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_termsCount; i++)
                    {
                        double min = lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_minValue;
                        double max = lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_maxValue;
                        lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_membershipFinction = new TrapezoidalFunction(min, min + (min + max) / 4, max - (min + max) / 4, max);
                    }
                    break;
                case 4: // Triangle
                    for (int i = 0; i < lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_termsCount; i++)
                    {
                        double min = lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_minValue;
                        double max = lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_maxValue;
                        lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_membershipFinction = new TriangleFunction(min, (min + max) / 2, max, 0);
                    }
                    break;
            }

            switch (AggregationComboBox.SelectedIndex)
            {
                case 0:
                    aggregation_function = new LimitedAggregation();
                    break;
                case 1:
                    aggregation_function = new AlgebraicAggregation();
                    break;
                case 2:
                    aggregation_function = new MaxMinAggregation();
                    break;
            }

            switch (ActivisationComboBox.SelectedIndex)
            {
                case 0:
                    activization_function = new MinActivisation();
                    break;
                case 1:
                    activization_function = new ProdActivisation();
                    break;
                case 2:
                    activization_function = new AvarageActivisation();
                    break;
            }

            switch (AccumulationComboBox.SelectedIndex)
            {
                case 0:
                    accumulation_function = new LimitedAccumulation();
                    break;
                case 1:
                    accumulation_function = new AlgebraicAccumulation();
                    break;
                case 2:
                    accumulation_function = new MaxMinAccumulation();
                    break;
            }

            switch (FuzzificationComboBox.SelectedIndex)
            {
                case 0:
                    fuzzification_function = new CenterOfGravityFuzzification();
                    break;
                case 1:
                    fuzzification_function = new CenterOfGravityPointSetsFuzzification();
                    break;
                case 2:
                    fuzzification_function = new CenterSquareFuzzification();
                    break;
                case 3:
                    fuzzification_function = new LeftModelValuesFuzzification();
                    break;
            }

           
            InputVariablesPanel.Visible = true;
            FillInputVariablesForm();
        }

        private void ChooseFunctionsBackButton_Click(object sender, EventArgs e)
        {
            AddTermsPanel.Visible = false;
            ChooseFunctionsPanel.Visible = false;
        }

        private void DrawGraph_Click(object sender, EventArgs e)
        {
            switch (MembershipComboBox.SelectedIndex)
            {
                case 0: // Gaus
                    for (int i = 0; i < lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_termsCount; i++)
                    {
                        lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_membershipFinction = new GaussFunction(Convert.ToInt32(ALabelInput.Text), 0, Convert.ToInt32(CLabelInput.Text), 0);
                    }
                    break;
                case 1: // sigmoid
                    for (int i = 0; i < lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_termsCount; i++)
                    {
                        lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_membershipFinction = new SigmoidFunction(Convert.ToInt32(ALabelInput.Text), 0, Convert.ToInt32(CLabelInput.Text), 0);
                    }
                    break;
                case 2: // Singleton 
                    for (int i = 0; i < lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_termsCount; i++)
                    {
                        lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_membershipFinction = new SingletonFunction(Convert.ToInt32(ALabelInput.Text), 0, 0, 0);
                    }
                    break;
                case 3: // Tpapezoidal
                    for (int i = 0; i < lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_termsCount; i++)
                    {
                        double min = lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_minValue;
                        double max = lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_maxValue;
                        lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_membershipFinction = new TrapezoidalFunction(min, min + (min + max) / 4, max - (min + max) / 4, max);
                    }
                    break;
                case 4: // Triangle
                    for (int i = 0; i < lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_termsCount; i++)
                    {
                        double min = lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_minValue;
                        double max = lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_maxValue;
                        lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[i].m_membershipFinction = new TriangleFunction(min, (min + max) / 2, max, 0);
                    }
                    break;
            }

            // Получим панель для рисования
            ZedGraph.GraphPane pane = zedGraph.GraphPane;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            // Создадим список точек
            

            for (int i = 0; i < lexicalVariables.ElementAt(lexicalVariablesCount - 1).m_terms.Length; i++)
            {
                ZedGraph.PointPairList list = new ZedGraph.PointPairList();

                double xmin = lexicalVariables.ElementAt(lexicalVariablesCount - 1).m_terms.ElementAt(i).m_minValue;
                double xmax = lexicalVariables.ElementAt(lexicalVariablesCount - 1).m_terms.ElementAt(i).m_maxValue;

                // Заполняем список точек
                for (double x = xmin; x <= xmax; x += 0.01)
                {
                    // добавим в список точку
                    list.Add(x, lexicalVariables.ElementAt(lexicalVariablesCount - 1).m_terms[i].CalculateValue(x));
                }

                // Создадим кривую с названием "Sinc", 
                // которая будет рисоваться голубым цветом (Color.Blue),
                // Опорные точки выделяться не будут (SymbolType.None)
                ZedGraph.LineItem myCurve;

                myCurve = pane.AddCurve(lexicalVariables.ElementAt(lexicalVariablesCount - 1).m_name, list, Color.Red, ZedGraph.SymbolType.None);
                myCurve.MakeUnique();

                // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
                // В противном случае на рисунке будет показана только часть графика, 
                // которая умещается в интервалы по осям, установленные по умолчанию
                zedGraph.AxisChange();

                
            }

            // Обновляем график
            zedGraph.Invalidate();
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////   INPUT VARTIABLE FORM     /////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        void FillInputVariablesForm()
        {
            inputVariables = new double[lexicalVariablesCount - 1];

            for (int i = 0; i < lexicalVariablesCount -1 /*Since last is the outout value*/; i++)
            {
                // creating Label input var
                Label InputNumberlabel = new Label();
                InputNumberlabel.Name = "label_InputVariableNumber_" + i;
                InputNumberlabel.Text = "Input var №" + (i + 1) + ":";
                InputNumberlabel.Width = 95;
                InputNumberlabel.Location = new Point(InputVariables.Location.X, InputVariables.Location.Y + (25 + 25 * i));
                InputVariablesPanel.Controls.Add(InputNumberlabel);

                // creating Label input var
                Label InputVariablelabel = new Label();
                InputVariablelabel.Name = "label_InputVariableValue_" + i;
                InputVariablelabel.Text = "Value:";
                InputVariablelabel.Width = 65;
                InputVariablelabel.Location = new Point(InputNumberlabel.Location.X + InputNumberlabel.Width + 5, InputVariables.Location.Y + (25 + 25 * i));
                InputVariablesPanel.Controls.Add(InputVariablelabel);

                // creating UpDown input var
                NumericUpDown InputVariableUpDown = new NumericUpDown();
                InputVariableUpDown.Name = "upDown_InputVariableValue_" + i;
                InputVariableUpDown.Width = 36;
                InputVariableUpDown.Location = new Point(InputVariablelabel.Location.X + InputVariablelabel.Width + 5, InputVariables.Location.Y + (25 + 25 * i));
                InputVariableUpDown.Value = 2 + 10 * i;
                InputVariablesPanel.Controls.Add(InputVariableUpDown);
            }

            // creating OK button
            Button LVNextButton = new Button();
            LVNextButton.Name = "InpurVariablesOKButton";
            LVNextButton.Text = "Next >";
            LVNextButton.Location = new Point(InputVariablesPanel.Controls["label_InputVariableNumber_" + (lexicalVariablesCount - 2)].Location.X + 100, InputVariablesPanel.Controls["label_InputVariableNumber_" + (lexicalVariablesCount - 2)].Location.Y + (25 * lexicalVariablesCount) + 25);
            LVNextButton.Click += OkButton_Clicked;
            InputVariablesPanel.Controls.Add(LVNextButton);

            // creating Back button
            Button LVBackButton = new Button();
            LVBackButton.Name = "InpurVariablesBackButton";
            LVBackButton.Text = "< Back";
            LVBackButton.Location = new Point(InputVariablesPanel.Controls["label_InputVariableNumber_" + (lexicalVariablesCount - 2)].Location.X, InputVariablesPanel.Controls["label_InputVariableNumber_" + (lexicalVariablesCount - 2)].Location.Y + (25 * lexicalVariablesCount) + 25);
            LVBackButton.Click += BackButton_Clicked;
            InputVariablesPanel.Controls.Add(LVBackButton);

        }

        void BackButton_Clicked(object sender, EventArgs e)
        {
            ChooseFunctionsPanel.Visible = true;
            InputVariablesPanel.Visible = false;
        }

        void OkButton_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < lexicalVariablesCount - 1 /*Since 1 is the output*/; i++)
            {
                inputVariables[i] = Convert.ToDouble(InputVariablesPanel.Controls["upDown_InputVariableValue_" + i].Text);
            }

            ProductionRulesInputPanel.Visible = true;
            ShowHelpMessage();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////   PRODUCTION RULES INTPUT FORM     /////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void ShowHelpMessage()
        {
            string careMessage;
            careMessage = "Please, be carefull entering production rules!!! You should use template as the example below:";
            careMessage += "\n\n                                         If X1 is 10 and X2 is 30 THEN Y is 23" + " etc.\n\n";
            careMessage += "Where:\n";
            careMessage += "    X1,X2       - input variables ID;\n";
            careMessage += "    Y              - input variable ID;\n";
            careMessage += "    10,30,23   - variables value;\n\n";
            careMessage += "Please note that the ID value should be the same as you set to linguistic variables before!";

            MessageBox.Show(careMessage);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////   CALCULATE VALUE     ////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button2_Click(object sender, EventArgs e) // Back BUtton
        {
            ProductionRulesInputPanel.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e) // Calculate button
        {
            var lines = prodRulesTB.Text.Split('\n');
            prodcutionsRules = new ProductionRule[lines.Length];
            RuleParser rp = new RuleParser();
            for (int i = 0; i < lines.Length; i++)
            {
                prodcutionsRules[i] = rp.ParseRuleString(lines[i]);
            }
            Fuzzification_1();
        }

        public void Fuzzification_1()
        {

            // TODO: DO NOT FORGET TO UNCOMMENT THIS -1 !!!!!!!!!!!!!!!!!!!! 

            fuzzification_1_Values = new Tuple<string, string, double>[lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_termsCount * inputVariables.Length /* 1 of temrs is OUT*/]; // < output lexical variable id, input variable id, fuzzification value>

            FuzzificationValues(fuzzification_1_Values);


            Aggregation();
        }

        public void FuzzificationValues(Tuple<string, string, double>[] _tp)
        {
            for (int i = 0; i < inputVariables.Length; i++ )
            {
                for (int j = 0; j < lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_termsCount; j++)
                {
                    _tp[(i * inputVariables.Length) + j] = Tuple.Create(lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_id, lexicalVariables.ElementAt(i).m_id, lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms[j].CalculateValue(inputVariables.ElementAt(i)));
                }
            }
        }

        public void Aggregation()
        {
            activisationValues = new Dictionary<String, Stack<double>[]>();

            aggregationValues = new Dictionary<string, Stack<double>>();

            Stack<double> values = new Stack<double>();

            int i = 0;

            foreach (var item in prodcutionsRules)
            {
                String agrValueKey;
                foreach (var pair in item.m_variables)
                {
                    foreach (var fuz in fuzzification_1_Values)
                    {
                        if (fuz.Item2.Equals(pair.Key) && fuz.Item3 > 0.0)
                        {
                            values.Push(fuz.Item3);
                        }
                    }
                }
                agrValueKey = item.m_variables.ElementAt(item.m_variables.Values.Count - 1).Key + "#" + item.m_variables.ElementAt(item.m_variables.Values.Count - 1).Value;
                if (!aggregationValues.ContainsKey(agrValueKey))
                {
                    aggregationValues.Add(agrValueKey, new Stack<double>());
                    aggregationValues[agrValueKey].Push(AggregationValues(aggregation_function, values));
                }
                else
                {
                    aggregationValues[agrValueKey].Push(AggregationValues(aggregation_function, values));
                }
            }

            ActivisationPhase();
        }

        public void ActivisationPhase()
        {

            foreach (var item in aggregationValues)
            {
                foreach (var val in item.Value)
                {
                    if (val > 0)
                    {
                        foreach (var lv in Form1.lexicalVariables)
                        {
                            string[] temp = item.Key.Split('#');
                            if (lv.m_type == VariableType.OUT && lv.m_id == temp[0])
                            {
                                for (int i = 0; i < lv.m_termsCount; i++)
                                {
                                    if (lv.m_terms.ElementAt(i).m_ID == temp[1])
                                    {
                                        int k = 0;
                                        for (double j = lv.m_terms.ElementAt(i).m_minValue; j <= lv.m_terms.ElementAt(i).m_maxValue; j += drawStep)
                                        {
                                            double _funcVal = lv.m_terms.ElementAt(i).CalculateValue(j);
                                            if (!activisationValues.ContainsKey(temp[1]))
                                            {
                                                activisationValues.Add(temp[1], new Stack<double>[Convert.ToInt32((lv.m_terms.ElementAt(i).m_maxValue - lv.m_terms.ElementAt(i).m_minValue) / drawStep) + 1]);
                                                if (activisationValues[temp[1]][k] == null)
                                                {
                                                    activisationValues[temp[1]][k] = new Stack<double>();
                                                    activisationValues[temp[1]][k].Push(ActivisationValues(activization_function, _funcVal, val));
                                                }
                                                else
                                                {
                                                    activisationValues[temp[1]][k].Push(ActivisationValues(activization_function, _funcVal, val));
                                                }
                                            }
                                            else
                                            {
                                                if (activisationValues[temp[1]][k] == null)
                                                {
                                                    activisationValues[temp[1]][k] = new Stack<double>();
                                                    activisationValues[temp[1]][k].Push(ActivisationValues(activization_function, _funcVal, val));
                                                }
                                                else 
                                                {
                                                    activisationValues[temp[1]][k].Push(ActivisationValues(activization_function, _funcVal, val));
                                                }
                                            }
                                            k++;
                                        }
                                    }
                                }
                            }
                        }  
                    }
                }
            }

            AccumulationPhase();

        }

        public void AccumulationPhase()
        {
            Stack< double > pointsToDraw = new Stack< double >();

            //Stack<ZedGraph.PointD>[] pointsToDraw = new Stack<ZedGraph.PointD>[lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_termsCount];

            /*for (int i = 0; i < lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_termsCount; i++)
            {
                pointsToDraw[i] = new Stack<double>();
            }*/

            int j = 0;

            foreach (var actVal in activisationValues)
            {
                foreach (var val in actVal.Value)
                {
                    pointsToDraw.Push(AccumulationValues(val));
                }
                j++;
            }

            ResultPanel.Visible = true;

            // Получим панель для рисования
            ZedGraph.GraphPane pane = FinalGraph.GraphPane;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            // Создадим список точек
            ZedGraph.PointPairList list = new ZedGraph.PointPairList();

            // Заполняем список точек
            double x = 0;
            foreach (var item in pointsToDraw)
            {
                list.Add(x, item);
                x += drawStep;
            }

            // Создадим кривую с названием "Sinc", 
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            ZedGraph.LineItem myCurve;

            myCurve = pane.AddCurve("Result", list, Color.Red, ZedGraph.SymbolType.None);
            myCurve.Line.Fill = new ZedGraph.Fill(Color.White, Color.Blue, 45F); ;

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();



        }

        public double AggregationValues(AggregationFormulaBase _af, Stack<double> _st)
        {
            return _af.CalculateAggregation(_st);
        }

        public double ActivisationValues(ActivisationFormulaBase _af, double _c, double _val1)
        {
            return _af.CalculateActivisation(_c, _val1);
        }

        public double AccumulationValues( Stack<double> _st)
        {
            return accumulation_function.CalculateAccumulation(_st);
        }

        

    }
}
