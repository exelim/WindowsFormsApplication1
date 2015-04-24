using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Classes.Formulas.AggregationFormulas;
using WindowsFormsApplication1.Classes.Formulas.ActivisationFormulas;
using WindowsFormsApplication1.Classes.Formulas.AccumulationFormulas;
using WindowsFormsApplication1.Classes.MembershipFunctions;
using WindowsFormsApplication1.Classes.Formulas.FuzzificationFormulas;

namespace WindowsFormsApplication1
{
    public partial class MembershipFunctionChoise : Form
    {
        public static MembershipFunctionBase membeship_function;
        public static AggregationFormulaBase aggregation_function;
        public static ActivisationFormulaBase activization_function;
        public static AccumulatiomFormulaBase accumulation_function;
        public static FuzzificationFormulaBase fuzzification_function;

        public MembershipFunctionChoise()
        {
            InitializeComponent();

            MembershipComboBox.Items.Add("Gauss Function");
            MembershipComboBox.Items.Add("Sigmoid Function");
            MembershipComboBox.Items.Add("Singleton Function");
            MembershipComboBox.Items.Add("Trapezoidal Function");
            MembershipComboBox.Items.Add("Triangle Function");
            MembershipComboBox.SelectedIndex = 0;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = new Bitmap(Application.StartupPath + @"\Desert.jpg");

            AggregationComboBox.Items.Add("Max Function");
            AggregationComboBox.Items.Add("Min Function");
            AggregationComboBox.Items.Add("Product Function");
            AggregationComboBox.SelectedIndex = 0;

            ActivisationComboBox.Items.Add("Min Function");
            ActivisationComboBox.Items.Add("Prod Function");
            ActivisationComboBox.Items.Add("Avarage Function");
            ActivisationComboBox.SelectedIndex = 0;

            AccumulationComboBox.Items.Add("Min Function");
            AccumulationComboBox.Items.Add("Max Function");
            AccumulationComboBox.Items.Add("Product Function");
            AccumulationComboBox.SelectedIndex = 0;

            FuzzificationComboBox.Items.Add("One Function");
            FuzzificationComboBox.Items.Add("Two Function");
            FuzzificationComboBox.Items.Add("Three Function");
            FuzzificationComboBox.SelectedIndex = 0;
        }

        private void MembershipComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (MembershipComboBox.SelectedIndex)
            { 
                case 0:
                    pictureBox1.Image = new Bitmap(Application.StartupPath + @"\Desert.jpg");
                    break;
                case 1:
                    pictureBox1.Image = new Bitmap(Application.StartupPath + @"\Penguins.jpg");
                    break;
                case 2:
                    pictureBox1.Image = new Bitmap(Application.StartupPath + @"\Koala.jpg");
                    break;
                case 3:
                    pictureBox1.Image = new Bitmap(Application.StartupPath + @"\Lighthouse.jpg");
                    break;
                case 4:
                    pictureBox1.Image = new Bitmap(Application.StartupPath + @"\Jellyfish.jpg");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
