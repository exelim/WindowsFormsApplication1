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
    public partial class InputVariablesForm : Form
    {
        public static int LVCount;
        public static int[] inputVariables;

        public InputVariablesForm(int _variablesCount)
        {
            InitializeComponent();

            LVCount = _variablesCount;
            inputVariables = new int[LVCount];

            for (int i = 0; i < LVCount; i++)
            {
                // creating Label input var
                Label InputNumberlabel = new Label();
                InputNumberlabel.Name = "label_InputVariableNumber_" + i;
                InputNumberlabel.Text = "Input var №" + ( i + 1 ) + ":";
                InputNumberlabel.Width = 95;
                InputNumberlabel.Location = new Point(InputVariables.Location.X, InputVariables.Location.Y + (25 + 25 * i));
                this.Controls.Add(InputNumberlabel);

                // creating Label input var
                Label InputVariablelabel = new Label();
                InputVariablelabel.Name = "label_InputVariableValue_" + i;
                InputVariablelabel.Text = "Value:";
                InputVariablelabel.Width = 65;
                InputVariablelabel.Location = new Point(InputNumberlabel.Location.X + InputNumberlabel.Width + 5, InputVariables.Location.Y + (25 + 25 * i));
                this.Controls.Add(InputVariablelabel);

                // creating UpDown input var
                NumericUpDown InputVariableUpDown = new NumericUpDown();
                InputVariableUpDown.Name = "upDown_InputVariableValue_" + i;
                InputVariableUpDown.Width = 36;
                InputVariableUpDown.Location = new Point(InputVariablelabel.Location.X + InputVariablelabel.Width + 5, InputVariables.Location.Y + (25 + 25 * i));
                InputVariableUpDown.Value = 1 + 10*i;
                this.Controls.Add(InputVariableUpDown);
            }

            // creating OK button
            Button LVNextButton = new Button();
            LVNextButton.Name = "InpurVariablesOKButton";
            LVNextButton.Text = "Ok";
            LVNextButton.Location = new Point(this.Controls["label_InputVariableNumber_" + (LVCount - 1)].Location.X, this.Controls["label_InputVariableNumber_" + (LVCount - 1)].Location.Y + (25 * LVCount) + 25);
            LVNextButton.Click += OkButton_Clicked;
            this.Controls.Add(LVNextButton);

        }

        void OkButton_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < LVCount; i++)
            {
                inputVariables[i] = Convert.ToInt32(this.Controls["upDown_InputVariableValue_" + i].Text);
            }

            Close();
            ProductionRulesInputForm PRForm = new ProductionRulesInputForm();
            PRForm.ShowDialog();
        }

    }
}
