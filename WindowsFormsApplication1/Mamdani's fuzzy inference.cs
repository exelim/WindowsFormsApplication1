using System;
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
        static public Dictionary<int, ProductionRulesTerm>[] _terms;
        public static Array arr;
        public static LexicalVariable[] lexicalVariables;
        static public ProductionRulesTerm[] _term;

        public static double[] inputVariables;

        public static int number;
        bool choseFunctionFormInitialized = false;
        int lastLExicalVariableTermsCount = 0;

        public static int currentLVMinValue;
        public static int currentLVMaxValue;
        public static string currentLVName;
        public static int currentLVIdx;

        public static ProductionRule[] prodcutionsRules;
        public static Tuple<string, string, double>[] fuzzification_1_Values;   //  < input variable id, output lexical variable id, fuzzification value>
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
                        this.Controls.RemoveByKey("label_LVType_" + i);
                        this.Controls.RemoveByKey("List_LVType_" + i);
                        this.Controls.RemoveByKey("label_LVTermsCount_" + i);
                    }
                }

                lexicalVariablesCount = Convert.ToInt32(LVCountUpDown.Value);
                lexicalVariables = new LexicalVariable[lexicalVariablesCount];

                _terms = new Dictionary<int, ProductionRulesTerm>[lexicalVariablesCount];

                for (int i = 0; i < lexicalVariablesCount; i++)
                {
                    _terms[i] = new Dictionary<int, ProductionRulesTerm>();
                }

                for (int i = 0; i < lexicalVariablesCount; i++)
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
                    IDlabel.Text = "ID:";
                    IDlabel.Width = 20;
                    IDlabel.Location = new Point(Numberlabel.Location.X + Numberlabel.Width, LVCountLabel.Location.Y + (25 + 25 * i));
                    this.Controls.Add(IDlabel);

                    var toolTip1 = new System.Windows.Forms.ToolTip();

                    toolTip1.AutoPopDelay = 5000;
                    toolTip1.InitialDelay = 500;
                    toolTip1.ReshowDelay = 500;
                    toolTip1.ShowAlways = true;
                    toolTip1.IsBalloon = true;
                    toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
                    toolTip1.ToolTipTitle = "ID:";

                    //creating TextBox for LV id
                    TextBox IDtextBox = new TextBox();
                    IDtextBox.Name = "textbox_LVID_" + i;
                    IDtextBox.Width = 50;
                    IDtextBox.Location = new Point(IDlabel.Location.X + IDlabel.Width, LVCountLabel.Location.Y + (25 + 25 * i));
                    IDtextBox.MouseHover += ChangeTip;

                    toolTip1.SetToolTip(IDtextBox, IDtextBox.Text);
                    //Form1.Children.Add(host);  //a container for windowsForm textBox 

                   /* IDtextBox.Text = "lvid_" + i; // DEBUG

                    // Debug start
                    if (i == 0)
                    {
                        IDtextBox.Text = "s"; // DEBUG
                    }
                    else if (i == 1) // DEBUG
                    {
                        IDtextBox.Text = "f"; // DEBUG
                    }
                    else if (i == 2)
                    {
                        IDtextBox.Text = "t"; // DEBUG
                    }
                    // Debug end
                    */
                    this.Controls.Add(IDtextBox);

                    // creating Label LV name
                    Label Namelabel = new Label();
                    Namelabel.Name = "label_LVName_" + i;
                    Namelabel.Text = "Name:";
                    Namelabel.Width = 35;
                    Namelabel.Location = new Point(IDtextBox.Location.X + IDtextBox.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                    this.Controls.Add(Namelabel);

                    // creating TextBox for LV name
                    TextBox NametextBox = new TextBox();
                    NametextBox.Name = "textbox_LVName_" + i;
                    NametextBox.Width = 100;
                    NametextBox.Location = new Point(Namelabel.Location.X + 50, LVCountLabel.Location.Y + (25 + 25 * i));
                    NametextBox.MouseHover += ChangeTip;
                   // NametextBox.Text = "lvname_" + i; // DEBUG
                    this.Controls.Add(NametextBox);

                    // creating Label LV type
                    Label Typelabel = new Label();
                    Typelabel.Name = "label_LVType_" + i;
                    Typelabel.Text = "Type:";
                    Typelabel.Width = 40;
                    Typelabel.Location = new Point(NametextBox.Location.X + NametextBox.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                    this.Controls.Add(Typelabel);

                    // creating UpDown LV type
                    ComboBox TypeList = new ComboBox();
                    TypeList.Name = "List_LVType_" + i;
                    TypeList.Width = 45;
                    TypeList.Items.Add("IN");
                    TypeList.Items.Add("OUT");
                    if (i == lexicalVariablesCount - 1)
                        TypeList.SelectedIndex = 1;
                    else
                        TypeList.SelectedIndex = 0;
                    TypeList.Location = new Point(Typelabel.Location.X + Typelabel.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                    this.Controls.Add(TypeList);

                    // creating Label LV min range
                    Label MinRangelabel = new Label();
                    MinRangelabel.Name = "label_LVMinrange_" + i;
                    MinRangelabel.Text = "Range from:";
                    MinRangelabel.Width = 65;
                    MinRangelabel.Location = new Point(TypeList.Location.X + TypeList.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
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
                    MaxRangelabel.Text = "to:";
                    MaxRangelabel.Width = 20;
                    MaxRangelabel.Location = new Point(MinRangeUpDown.Location.X + MinRangeUpDown.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                    this.Controls.Add(MaxRangelabel);

                    // creating UpDown LV max range
                    NumericUpDown MaxRangeUpDown = new NumericUpDown();
                    MaxRangeUpDown.Name = "upDown_LVMaxrange_" + i;
                    MaxRangeUpDown.Width = 36;
                    MaxRangeUpDown.Location = new Point(MaxRangelabel.Location.X + MaxRangelabel.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                   /* MaxRangeUpDown.Value = 1 + (10 * i);  // DEBUG
                    // Debug start
                    if (i == 0)
                    {
                        MaxRangeUpDown.Value = 10;  // DEBUG
                    }
                    else if (i == 1) // DEBUG
                    {
                        MaxRangeUpDown.Value = 10;  // DEBUG
                    }
                    else if (i == 2)
                    {
                        MaxRangeUpDown.Value = 30;  // DEBUG
                    }
                    // Debug en
                    */
                    this.Controls.Add(MaxRangeUpDown);

                  /*  if (i == 2) // DEBUG
                    {
                        TypeList.SelectedIndex = 1; // DEBUG
                    }*/
                    // creating Label Terms count
                    Label TermsCountlabel = new Label();
                    TermsCountlabel.Name = "label_LVTermsCount_" + i;
                    TermsCountlabel.Text = "Number of terms:";
                    TermsCountlabel.Width = 90;
                    TermsCountlabel.Location = new Point(MaxRangeUpDown.Location.X + MaxRangeUpDown.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
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
                    AddTerms.Text = "Edit terms";
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

        void ChangeTip(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.Show(((TextBox)sender).Text, (TextBox)sender, 0, 23, 1000);
        }

        void AddTermsButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            termsCount = Convert.ToInt32(this.Controls["upDown_TermsCount_" + button.Name.Substring(button.Name.Length - 1, 1)].Text);

            if (termsCount <= 0)
            {
                MessageBox.Show("Terms count should be greater than 0.");
            }
            else
            {
                //addTermsForm = new AddTermForm(Convert.ToInt32(button.Name.Substring(button.Name.Length - 1, 1)));
                //addTermsForm.ShowDialog();
                number = Convert.ToInt32(button.Name.Substring(button.Name.Length - 1, 1));

                bool isOk = checkLinguisticVariable(number);

                if (!isOk)
                    return;

                termsCount = Convert.ToInt32(this.Controls["upDown_TermsCount_" + button.Name.Substring(button.Name.Length - 1, 1)].Text);

                if (termsCount <= 0)
                {
                    MessageBox.Show("Terms count should be greater than 0.");
                    return;
                }

                currentLVName = (this.Controls.Find("textbox_LVName_" + number, false).FirstOrDefault() as TextBox).Text;//

                NumericUpDown cntrl = this.Controls.Find("upDown_LVMinrange_" + number, false).FirstOrDefault() as NumericUpDown;
                currentLVMinValue = Convert.ToInt32(cntrl.Value);
                cntrl = this.Controls.Find("upDown_LVMaxrange_" + number, false).FirstOrDefault() as NumericUpDown;
                currentLVMaxValue = Convert.ToInt32(cntrl.Value);

                AddTermsPanel.Visible = true;
                ChooseFunctionsPanel.Visible = false;
                FillAddTermsForm();
            }
        }

        void NextButton_Clicked(object sender, EventArgs e)
        {

            fullTermsCount = 0;
            int outVariablesCount = 0;

            for (int i = 0; i < lexicalVariablesCount; i++)
            {
                bool isOk = checkLinguisticVariable(i);
                if (!isOk)
                    return;

                string ID = this.Controls["textbox_LVID_" + i].Text;
                string LVName = this.Controls["textbox_LVName_" + i].Text;
                int LVMinValue = Convert.ToInt32(this.Controls["upDown_LVMinrange_" + i].Text);
                int LVMaxValue = Convert.ToInt32(this.Controls["upDown_LVMaxrange_" + i].Text);

                int termsCount = Convert.ToInt32(this.Controls["upDown_TermsCount_" + i].Text);
                VariableType type = VariableType.IN;
                switch (this.Controls["List_LVType_" + i].Text)
                {
                    case "IN":
                        type = VariableType.IN;
                        break;
                    case "OUT":
                        type = VariableType.OUT;
                        outVariablesCount++;
                        break;
                }

                if (outVariablesCount > 1)
                {
                    MessageBox.Show("Error! Single OUT variable should be present in the lexical variables list and it should be the last one. There are: " + outVariablesCount + " now.");
                    return;
                }


                ProductionRulesTerm[] terms = new ProductionRulesTerm[termsCount];
                if (termsCount <= 0)
                {
                    MessageBox.Show("Error! Linguistic's variable №" + (i + 1) + " terms count should be greater than 0!");
                    return;
                }
                else
                {
                    fullTermsCount += termsCount;
                    for (int j = 0; j < termsCount; j++)
                    {
                        if (_terms[i].Count == 0 || _terms[i][j].m_ID == null)
                        {
                            MessageBox.Show("Error! You should first add terms for all linguistic variables!");
                            return;
                        }

                        terms[j] = _terms[i][j];
                    }
                    lexicalVariables[i] = new LexicalVariable(ID, LVName, LVMinValue, LVMaxValue, termsCount, terms, type);
                }
            }

            if (lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_type != VariableType.OUT)
            {
                MessageBox.Show("Error! The last variable in the list on lexical variables should be an OUT variable and it should be the only one.");
                return;
            }

            AddTermsPanel.Visible = true;
            ChooseFunctionsPanel.Visible = true;
            FillChooseFunctionForm();
            //Close();

            // MembershipFunctionChoise  choiseFunctionForm = new MembershipFunctionChoise();
            //choiseFunctionForm.ShowDialog();
            //AddTermsPanel.Visible = true;

        }

        bool checkLinguisticVariable(int idx)
        {
            string ID = this.Controls["textbox_LVID_" + idx].Text;
            if (ID == "")
            {
                MessageBox.Show("Error! Linguistic's variable №" + (idx + 1) + " ID is empty!");
                return false;
            }
            string LVName = this.Controls["textbox_LVName_" + idx].Text;
            if (LVName == "")
            {
                MessageBox.Show("Error! Linguistic's variable №" + (idx + 1) + " name is empty!");
                return false;
            }
            int LVMinValue = Convert.ToInt32(this.Controls["upDown_LVMinrange_" + idx].Text);
            int LVMaxValue = Convert.ToInt32(this.Controls["upDown_LVMaxrange_" + idx].Text);
            if (LVMinValue >= LVMaxValue)
            {
                MessageBox.Show("Error! Linguistic's variable №" + (idx + 1) + " minimal value is equal greater than maximal!");
                return false;

            }
            return true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////   ADD TERMS FORM     ////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void FillAddTermsForm()
        {
            _term = new ProductionRulesTerm[termsCount];

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
                AddTermsPanel.Controls.RemoveByKey("AddmembershipFunctionButton_" + i);

            }

            AddTermsPanel.Controls.RemoveByKey("TermOKButton");
            AddTermsPanel.Controls.RemoveByKey("TermCancelButton");
            AddTermsPanel.Controls.RemoveByKey("DrawAllButton");

            TermCountLabel.Text = "Terms of lexical variable " + currentLVName + " :";

            int idx = -1;

          /*  for (int i = 0; i < lexicalVariables.Length; i++)
            {
                if (lexicalVariables.ElementAt(i) != null && lexicalVariables.ElementAt(i).m_name == currentLVName)
                    idx = i;
            }*/

            //if ( idx != -1 && lexicalVariables.ElementAt(idx).m_termsCount == termsCount)
           // {
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
                    IDlabel.Text = "ID:";
                    IDlabel.Width = 20;
                    IDlabel.Location = new Point(Numberlabel.Location.X + Numberlabel.Width, TermCountLabel.Location.Y + (25 + 25 * i));
                    AddTermsPanel.Controls.Add(IDlabel);

                    //creating TextBox for Terms ID
                    TextBox IDtextBox = new TextBox();
                    IDtextBox.Name = "textbox_TermID_" + i;
                    IDtextBox.Width = 50;
                    IDtextBox.Location = new Point(IDlabel.Location.X + IDlabel.Width, TermCountLabel.Location.Y + (25 + 25 * i));
                    if (idx != -1)
                        IDtextBox.Text = lexicalVariables.ElementAt(idx).m_terms.ElementAt(i).m_ID;
                    /* // Debug start
                     if (termsCount == 3)
                     {
                         if (i == 0)
                         {
                             IDtextBox.Text = "p";  // DEBUG
                         }
                         else if (i == 1) // DEBUG
                         {
                             IDtextBox.Text = "g";  // DEBUG
                         }
                         else if (i == 2)
                         {
                             IDtextBox.Text = "e";  // DEBUG
                         }
                     }
                     else
                     {
                         if (i == 0)
                         {
                             IDtextBox.Text = "b";  // DEBUG
                         }
                         else if (i == 1) // DEBUG
                         {
                             IDtextBox.Text = "g";  // DEBUG
                         }
                     }
                     // Debug en*/
                    IDtextBox.MouseHover += ChangeTip;
                    AddTermsPanel.Controls.Add(IDtextBox);

                    // creating Label Term name
                    Label Namelabel = new Label();
                    Namelabel.Name = "label_TermsName_" + i;
                    Namelabel.Text = "Name:";
                    Namelabel.Width = 35;
                    Namelabel.Location = new Point(IDtextBox.Location.X + IDtextBox.Width + 5, TermCountLabel.Location.Y + (25 + 25 * i));
                    AddTermsPanel.Controls.Add(Namelabel);

                    // creating TextBox for Term name
                    TextBox NametextBox = new TextBox();
                    NametextBox.Name = "textbox_TermName_" + i;
                    NametextBox.Width = 100;
                    NametextBox.Location = new Point(Namelabel.Location.X + Namelabel.Width, TermCountLabel.Location.Y + (25 + 25 * i));
                    // NametextBox.Text = "tmname_" + i;  // DEBUG
                    if (idx != -1)
                        NametextBox.Text = lexicalVariables.ElementAt(idx).m_terms.ElementAt(i).m_name;

                    IDtextBox.MouseHover += ChangeTip;
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
                    if (idx != -1)
                        MinRangeUpDown.Value = lexicalVariables.ElementAt(idx).m_terms.ElementAt(i).m_minValue;
                    /* // Debug start
                     if (termsCount == 3)
                     {
                         if (i == 0)
                         {
                             MinRangeUpDown.Value = 0;  // DEBUG
                         }
                         else if (i == 1) // DEBUG
                         {
                             MinRangeUpDown.Value = 3;  // DEBUG
                         }
                         else if (i == 2)
                         {
                             MinRangeUpDown.Value = 4;  // DEBUG
                         }
                     }
                     else
                     {
                         if (i == 0)
                         {
                             MinRangeUpDown.Value = 0;  // DEBUG
                         }
                         else if (i == 1) // DEBUG
                         {
                             MinRangeUpDown.Value = 2;  // DEBUG
                         }
                     }
                     // Debug en*/
                    AddTermsPanel.Controls.Add(MinRangeUpDown);

                    // creating Label Term max range
                    Label MaxRangelabel = new Label();
                    MaxRangelabel.Name = "label_TermMaxrange_" + i;
                    MaxRangelabel.Text = "to:";
                    MaxRangelabel.Width = 20;
                    MaxRangelabel.Location = new Point(MinRangeUpDown.Location.X + MinRangeUpDown.Width + 5, TermCountLabel.Location.Y + (25 + 25 * i));
                    AddTermsPanel.Controls.Add(MaxRangelabel);

                    // creating UpDown Term max range
                    NumericUpDown MaxRangeUpDown = new NumericUpDown();
                    MaxRangeUpDown.Name = "upDown_TermMaxrange_" + i;
                    MaxRangeUpDown.Width = 36;
                    MaxRangeUpDown.Location = new Point(MaxRangelabel.Location.X + MaxRangelabel.Width + 5, TermCountLabel.Location.Y + (25 + 25 * i));
                    if (idx != -1)
                        MaxRangeUpDown.Value = lexicalVariables.ElementAt(idx).m_terms.ElementAt(i).m_maxValue;
                    /* // Debug start
                     if (termsCount == 3)
                     {
                         if (i == 0)
                         {
                             MaxRangeUpDown.Value = 6;  // DEBUG
                         }
                         else if (i == 1) // DEBUG
                         {
                             MaxRangeUpDown.Value = 8;  // DEBUG
                         }
                         else if (i == 2)
                         {
                             MaxRangeUpDown.Value = 10;  // DEBUG
                         }
                     }
                     else
                     {
                         if (i == 0)
                         {
                             MaxRangeUpDown.Value = 8;  // DEBUG
                         }
                         else if (i == 1) // DEBUG
                         {
                             MaxRangeUpDown.Value = 10;  // DEBUG
                         }
                     }
                     // Debug en*/
                    AddTermsPanel.Controls.Add(MaxRangeUpDown);

                    // creating add membership button
                    Button AddmembershipFunctionButton = new Button();
                    AddmembershipFunctionButton.Name = "AddmembershipFunctionButton_" + i;
                    AddmembershipFunctionButton.Text = "Edit membership function";
                    AddmembershipFunctionButton.Width = 150;
                    AddmembershipFunctionButton.Location = new Point(MaxRangeUpDown.Location.X + MaxRangeUpDown.Width + 5, TermCountLabel.Location.Y + (25 + 25 * i));
                    AddTermsPanel.Controls.Add(AddmembershipFunctionButton);
                    AddmembershipFunctionButton.Click += AddmembershipFunctionButton_Clicked;

                }
           // }

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
            termsCancelButton.Text = "Back";
            termsCancelButton.Location = new Point(TermCountLabel.Location.X + 100, TermCountLabel.Location.Y + termsCount * 25 + 25);
            AddTermsPanel.Controls.Add(termsCancelButton);
            termsCancelButton.Click += CancelButton_Clicked;

            // Draw all
            Button DrawAllButton = new Button();
            DrawAllButton.Name = "DrawAllButton";
            DrawAllButton.Text = "Draw all!";
            DrawAllButton.Location = new Point(TermCountLabel.Location.X + 200, TermCountLabel.Location.Y + termsCount * 25 + 25);
            AddTermsPanel.Controls.Add(DrawAllButton);
            DrawAllButton.Click += DrawAll_Clicked;

            lastLExicalVariableTermsCount = termsCount;
        }

        void DrawAll_Clicked(object sender, EventArgs e)
        {
            DrawAll drawAll = new DrawAll();
            drawAll.ShowDialog();
        }

        void AddmembershipFunctionButton_Clicked(object sender, EventArgs e)
        {
            int idx = Convert.ToInt32(((Button)sender).Name[((Button)sender).Name.Length - 1].ToString());

            if (idx > _terms.ElementAt(number).Count)
            {
                MessageBox.Show("Error! Please add membership functions for all terms above.");
                return;
            }

            string ID = AddTermsPanel.Controls["textbox_TermID_" + idx].Text;
            if (ID == "")
            {
                MessageBox.Show("Error! Term's №" + (idx + 1) + " ID is empty!");
                return;
            }

            string termName = AddTermsPanel.Controls["textbox_TermName_" + idx].Text;
            if (termName == "")
            {
                MessageBox.Show("Error! Term's №" + (idx + 1) + " name is empty!");
                return;
            }

            int termMinRange = Convert.ToInt32(AddTermsPanel.Controls["upDown_TermMinrange_" + idx].Text);
            int termMaxRange = Convert.ToInt32(AddTermsPanel.Controls["upDown_TermMaxrange_" + idx].Text);
            if (termMinRange >= termMaxRange)
            {
                MessageBox.Show("Error! Term's №" + (idx + 1) + " minimum ragne is equal or greater than maximum range!");
                return;
            }
            else if (termMinRange < currentLVMinValue)
            {
                MessageBox.Show("Error! Term's №" + (idx + 1) + " minimum ragne is less than lexical's variable min value!");
                return;
            }
            else if (termMaxRange > currentLVMaxValue)
            {
                MessageBox.Show("Error! Term's №" + (idx + 1) + " minimum ragne is greater than lexical's variable max value!");
                return;
            }

            _term[idx] = new ProductionRulesTerm(ID, termName, termMinRange, termMaxRange);
            //if ( !_terms.ElementAt(number).Contains( _term[idx] ) )
            // {
            AddTermForm addForm = new AddTermForm(idx);
            addForm.ShowDialog();
            //}

        }

        void OKButton_Clicked(object sender, EventArgs e)
        {
            bool shouldClose = true;
            for (int i = 0; i < termsCount; i++)
            {
                if (_terms.ElementAt(number).Count < termsCount || _terms[number][i].m_membershipFinction == null)
                {
                    MessageBox.Show("Error! Please add memebership functions for all terms.");
                    shouldClose = false;
                    break;
                }
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
            this.Width = 500;
            if (!choseFunctionFormInitialized)
            {
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

        private void ChooseFunctionsNextButton_Click(object sender, EventArgs e)
        {
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
            ProductionRulesInputPanel.Visible = true;
            ShowHelpMessage();
            this.Width = 1024;
            //InputVariablesPanel.Visible = true;
            //FillInputVariablesForm();
        }

        private void ChooseFunctionsBackButton_Click(object sender, EventArgs e)
        {
            AddTermsPanel.Visible = false;
            ChooseFunctionsPanel.Visible = false;
            this.Width = 1024;
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////   INPUT VARTIABLE FORM     /////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        void FillInputVariablesForm()
        {
            this.Width = 500;
            inputVariables = new double[lexicalVariablesCount - 1];

            for (int i = 0; i < lexicalVariablesCount - 1 /*Since last is the outout value*/; i++)
            {
                // creating Label input var
                Label InputNumberlabel = new Label();
                InputNumberlabel.Name = "label_InputVariableNumber_" + i;
                InputNumberlabel.Text = lexicalVariables.ElementAt(i).m_name + " :";
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
            InputVariablesPanel.Visible = true;
            ProductionRulesInputPanel.Visible = true;
            this.Width = 1024;
        }

        void OkButton_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < lexicalVariablesCount - 1 /*Since 1 is the output*/; i++)
            {
                double val = Convert.ToDouble(InputVariablesPanel.Controls["upDown_InputVariableValue_" + i].Text);
                if (val < lexicalVariables.ElementAt(i).m_minValue)
                {
                    MessageBox.Show("Error! Value of input variable" + i + " is less than corresponding lexicals variable's min value");
                    return;
                }
                else if (val > lexicalVariables.ElementAt(i).m_maxValue)
                {
                    MessageBox.Show("Error! Value of input variable" + i + " is greater than corresponding lexicals variable's max value");
                    return;
                }
                else
                {
                    inputVariables[i] = Convert.ToDouble(InputVariablesPanel.Controls["upDown_InputVariableValue_" + i].Text);
                }
            }

            Fuzzification_1();
            this.Width = 1024;
            //ProductionRulesInputPanel.Visible = true;
            //ShowHelpMessage();

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

            // MessageBox.Show(careMessage);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////   CALCULATE VALUE     ////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void button2_Click(object sender, EventArgs e) // Back BUtton
        {
            ProductionRulesInputPanel.Visible = false;
            InputVariablesPanel.Visible = false;
            ChooseFunctionsPanel.Visible = true;
            this.Width = 500;
        }

        private void button1_Click_1(object sender, EventArgs e) // Calculate button
        {
            var lines = prodRulesTB.Text.Split('\n');
            prodcutionsRules = new ProductionRule[lines.Length];
            RuleParser rp = new RuleParser();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                    prodcutionsRules[i] = rp.ParseRuleString(lines[i]);
            }


            int termIdx = 0, lvIdx = 0, eleIdx = 0, line = 0;
            bool hasTerms = false, hasLex = false;
            for (int i = 0; i < prodcutionsRules.Length; i++)
            {
                line++;
                for (int j = 0; j < prodcutionsRules.ElementAt(i).m_variables.Count; j++)
                {
                    hasTerms = false;
                    hasLex = false;
                    for (int k = 0; k < lexicalVariables.Length; k++)
                    {
                        if (prodcutionsRules.ElementAt(i).m_variables.ElementAt(j).Key == lexicalVariables.ElementAt(k).m_id)
                        {
                            hasLex = true;
                            hasTerms = false;
                            for (int l = 0; l < lexicalVariables.ElementAt(k).m_termsCount; l++)
                            {
                                termIdx = l;
                                if (prodcutionsRules.ElementAt(i).m_variables.ElementAt(j).Value == lexicalVariables.ElementAt(k).m_terms.ElementAt(l).m_ID)
                                {
                                    hasTerms = true;
                                    break;
                                }
                                else
                                {
                                    lvIdx = k;
                                    eleIdx = j;
                                }
                            }
                        }
                    }
                    if (!hasLex)
                    {
                        MessageBox.Show("Error! Line " + line + ":" + " there is no lexical variable with ID \"" + prodcutionsRules.ElementAt(i).m_variables.ElementAt(j).Key + "\"");
                        return;
                    }
                    if (!hasTerms)
                    {
                        MessageBox.Show("Error! Line " + line + ":" + " there is no terms with ID: \"" + prodcutionsRules.ElementAt(i).m_variables.ElementAt(eleIdx).Value + "\" in lexical variable with ID: \"" + lexicalVariables.ElementAt(lvIdx).m_id + "\"");
                        return;
                    }
                }
            }

            ProductionRulesInputPanel.Visible = false;
            InputVariablesPanel.Visible = true;
            FillInputVariablesForm();
        }

        public void validateRules()
        { 
            
        }

        public void Fuzzification_1()
        {
            fuzzification_1_Values = new Tuple<string, string, double>[fullTermsCount - lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_termsCount  /* 1 of temrs is OUT*/]; // < input variable id, output lexical variable id, fuzzification value>

            FuzzificationValues(fuzzification_1_Values);


            Aggregation();
        }

        public void FuzzificationValues(Tuple<string, string, double>[] _tp)
        {
            for (int i = 0; i < inputVariables.Length; i++)
            {
                for (int j = 0; j < lexicalVariables.ElementAt(i).m_termsCount; j++)
                {
                    _tp[(i * lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_termsCount) + j] = Tuple.Create(lexicalVariables.ElementAt(i).m_id, lexicalVariables.ElementAt(i).m_terms.ElementAt(j).m_ID, //lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_terms.ElementAt(j).m_ID, 
                        lexicalVariables.ElementAt(i).m_terms.ElementAt(j).CalculateValue(inputVariables.ElementAt(i)));
                }
            }
        }

        public void Aggregation()
        {
            activisationValues = new Dictionary<String, Stack<double>[]>();

            aggregationValues = new Dictionary<String, Stack<double>>();

            Stack<double> values = new Stack<double>();

            RelationType type;
            foreach (var item in prodcutionsRules)
            {
                String agrValueKey;
                type = item.m_type;
                foreach (var pair in item.m_variables)
                {
                    foreach (var fuz in fuzzification_1_Values)
                    {
                        if (fuz.Item1.Equals(pair.Key) && fuz.Item2.Equals(pair.Value) /*item.m_variables.ElementAt(item.m_variables.Values.Count - 1).Value.Equals( fuz.Item2 ) /*&& fuz.Item3 > 0.0*/)
                        {
                            values.Push(fuz.Item3);
                        }
                    }
                }
                agrValueKey = item.m_variables.ElementAt(item.m_variables.Values.Count - 1).Key + "#" + item.m_variables.ElementAt(item.m_variables.Values.Count - 1).Value;
                if (!aggregationValues.ContainsKey(agrValueKey))
                {
                    if (values.Count > 0)
                    {
                        double val = AggregationValues(aggregation_function, values, type);
                        aggregationValues.Add(agrValueKey, new Stack<double>());
                        aggregationValues[agrValueKey].Push(val);
                    }
                }
                else
                {
                    if (values.Count > 0)
                    {
                        double val = AggregationValues(aggregation_function, values, type);
                        aggregationValues[agrValueKey].Push(val);
                    }
                }
                values.Clear();
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
                                        for (double j = lv.m_terms.ElementAt(i).m_minValue; j <= lv.m_terms.ElementAt(i).m_maxValue; j += drawStep, k++)
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
            Stack<double> pointsToDraw = new Stack<double>();

            Queue<double> points = new Queue<double>();

            foreach (var actVal in activisationValues)
            {
                foreach (var val in actVal.Value)
                {
                    if (val != null)
                        // pointsToDraw.Push(AccumulationValues(val));
                        points.Enqueue(AccumulationValues(val));
                }
            }

            ProductionRulesInputPanel.Visible = true;
            ResultPanel.Visible = true;

            // Получим панель для рисования
            ZedGraph.GraphPane pane = FinalGraph.GraphPane;
            pane.Title.Text = "Result value of " + lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_name;
            pane.XAxis.Title.Text = lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_name;
            pane.YAxis.Title.Text = "Membership Grade";

            pane.Legend.IsVisible = false;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            // Создадим список точек
            ZedGraph.PointPairList list = new ZedGraph.PointPairList();
            ZedGraph.PointPairList list2 = new ZedGraph.PointPairList();

            // Заполняем список точек
            double x = 0;
            double sum1 = 0.0;
            double sum2 = 0.0;
            pointsToDraw.Reverse();
            double max_value = 0.0;
            foreach (var item in points)
            {
                list.Add(x, item);
                sum1 += x * item;
                sum2 += item;
                if( item > max_value)
                    max_value = item;

                x += drawStep;
            }

            double deFuzz_result = fuzzification_function.CalculateFuzzification(points, lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_minValue, lexicalVariables.ElementAt(lexicalVariables.Length - 1).m_maxValue);

            ResultDescriptionLabel.Text = "For input variables :\n";

            for (int i = 0; i < lexicalVariables.Length; i++)
            {
                LexicalVariable tmp = lexicalVariables.ElementAt(i);
                if (tmp.m_type == VariableType.IN)
                {
                    ResultDescriptionLabel.Text += (i + 1).ToString() + ". " + tmp.m_name + "( " + tmp.m_id + " )" + "  = " + inputVariables.ElementAt(i) + "\n";
                }
                else
                {
                    ResultDescriptionLabel.Text += "\nOutput value is :\n\n";
                    ResultDescriptionLabel.Text += tmp.m_name + "( " + tmp.m_id + " )" + " = " + (sum1 / sum2).ToString() + "\n";
                }
            }

            
            list2.Add((sum1 / sum2), 0);
            list2.Add((sum1 / sum2), max_value);

            // Создадим кривую с названием "Sinc", 
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            ZedGraph.LineItem myCurve;
            ZedGraph.LineItem myCurve2;

            myCurve2 = pane.AddCurve("Result", list2, Color.Red, ZedGraph.SymbolType.None);

            myCurve = pane.AddCurve("Result", list, Color.Blue, ZedGraph.SymbolType.None);
            myCurve.Line.Fill = new ZedGraph.Fill(Color.White, Color.Blue, 45F); ;


            

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            FinalGraph.AxisChange();

            // Обновляем график
            FinalGraph.Invalidate();
        }

        public double AggregationValues(AggregationFormulaBase _af, Stack<double> _st, RelationType _type)
        {
            return _af.CalculateAggregation(_st, _type);
        }

        public double ActivisationValues(ActivisationFormulaBase _af, double _c, double _val1)
        {
            return _af.CalculateActivisation(_c, _val1);
        }

        public double AccumulationValues(Stack<double> _st)
        {
            return accumulation_function.CalculateAccumulation(_st);
        }

        private void ResultBackButton_Click(object sender, EventArgs e)
        {
            ResultPanel.Visible = false;
            ProductionRulesInputPanel.Visible = false;
            InputVariablesPanel.Visible = true;
            this.Width = 500;
        }

        private void prodRulesTB_TextChanged(object sender, EventArgs e)
        {
            var lines = prodRulesTB.Text.Split('\n');
            TotalRulesNumberLabel.Text = "Total number of prudoction rules: " + (lines.Length).ToString();
        }

        private void prodRulesTB_SelectionChanged(object sender, EventArgs e)
        {
            int index = prodRulesTB.SelectionStart;
            int line = prodRulesTB.GetLineFromCharIndex(index);
            CurrentRuleNumberLabel.Text = "Current rule: " + (line + 1).ToString();
        }
    }
}
