using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsApplication1.Classes;
using WindowsFormsApplication1.Structures;

namespace WindowsFormsApplication1
{
    public enum VariableType { IN, OUT };
    public enum RelationType { AND, OR };

    public partial class Form1 : Form
    {
        public static int lexicalVariablesCount;
        public static int termsCount;
        public static int fullTermsCount;
        public static ProductionRulesTerm[,] _terms;
        public static LexicalVariable[] lexicalVariables;

        // FORMS
        Form addTermsForm;
        Form inputVariablesForm;


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

                _terms = new ProductionRulesTerm[lexicalVariablesCount + 1, lexicalVariablesCount + 1];

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
            fullTermsCount += termsCount;
            if (termsCount <= 0)
            {
                MessageBox.Show("Terms count should be greater than 0.");
            }
            else
            {
                addTermsForm = new AddTermForm(Convert.ToInt32(button.Name.Substring(button.Name.Length - 1, 1)));
                addTermsForm.ShowDialog();
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


                ProductionRulesTerm[] rules = new ProductionRulesTerm[termsCount];
                if (termsCount <= 0)
                {
                    MessageBox.Show("Error! Linguistic's variable №" + ( i + 1 ) + " terms count should be greater than 0!");
                    return;
                }
                else
                {
                    for (int j = 0; j < termsCount; j++)
                    {
                        if (_terms[i, j].m_ID == null)
                        {
                            MessageBox.Show("Error! You should first add terms for all linguistic variables!");
                            return;
                        }

                        rules[j] = _terms[i, j];
                    }
                    lexicalVariables[i] = new LexicalVariable(ID, LVName, LVMinValue, LVMaxValue, termsCount, rules, type);
                }
            }

            inputVariablesForm = new InputVariablesForm(lexicalVariablesCount);
            //Close();
            inputVariablesForm.ShowDialog();

        }

    }
}
