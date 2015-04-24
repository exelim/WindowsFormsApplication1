using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MembershipFunctionChoise : Form
    {
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
    }
}
