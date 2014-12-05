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
    enum VariableType { IN, OUT };
    enum RelationType { AND, OR };

    public partial class Form1 : Form
    {
        public int lexicalVariablesCount;

        public Form1()
        {
            InitializeComponent();
        }

        private void LVCountConfirmButton_Click(object sender, EventArgs e)
        {
            if (lexicalVariablesCount > Convert.ToInt32(LVCountUpDown.Value))
            {
                for (int i = 0; i <= lexicalVariablesCount; i++)
                {
                    this.Controls.RemoveByKey( "LiguisticVariable_" + (i + 1) );
                }
            }

            lexicalVariablesCount = Convert.ToInt32(LVCountUpDown.Value);

            for (int i = 0; i <= LVCountUpDown.Value; i++)
            {
                // creating Label name LV number
                Label label = new Label();
                label.Name = "LiguisticVariable_" + (i + 1);
                label.Text = "Linguistic variable №" + (i + 1) + ":";
                label.Location = new Point(LVCountLabel.Location.X, LVCountLabel.Location.Y + (25 * i));
                this.Controls.Add(label);

                // creating TextBox for LV id
                TextBox textBox = new TextBox();
                textBox.Name = "LVId_" + (i + 1);
                textBox.Location = 

            }
        }
    }
}
