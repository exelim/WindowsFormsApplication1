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
        public static int outputVariable;


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
                this.Controls.Add(InputVariableUpDown);
            }

            // creating Label output variable
            Label OutputNumberlabel = new Label();
            OutputNumberlabel.Name = "label_OutputVariableNumber_";
            OutputNumberlabel.Text = "Output variables:";
            OutputNumberlabel.Width = 95;
            OutputNumberlabel.Location = new Point(InputVariables.Location.X, InputVariables.Location.Y + (25 * LVCount + 25));
            this.Controls.Add(OutputNumberlabel);

            // creating Label output variable
            Label OutputNumberlabel2 = new Label();
            OutputNumberlabel2.Name = "label_OutputVariableNumber_";
            OutputNumberlabel2.Text = "Output variable:";
            OutputNumberlabel2.Width = 95;
            OutputNumberlabel2.Location = new Point(OutputNumberlabel.Location.X, InputVariables.Location.Y + (25 * LVCount + 50));
            this.Controls.Add(OutputNumberlabel2);

            // creating Label output value
            Label Outputlabel = new Label();
            Outputlabel.Name = "label_OutputVariableValue_";
            Outputlabel.Text = "Value:";
            Outputlabel.Width = 65;
            Outputlabel.Location = new Point(OutputNumberlabel2.Location.X + OutputNumberlabel2.Width + 5, InputVariables.Location.Y + (25 * LVCount + 50));
            this.Controls.Add(Outputlabel);

            // creating UpDown Output value
            NumericUpDown OutputUpDown = new NumericUpDown();
            OutputUpDown.Name = "upDown_OutputVariableValue_";
            OutputUpDown.Width = 36;
            OutputUpDown.Location = new Point(Outputlabel.Location.X + Outputlabel.Width + 5, InputVariables.Location.Y + (25 * LVCount + 50));
            this.Controls.Add(OutputUpDown);

            // creating OK button
            Button LVNextButton = new Button();
            LVNextButton.Name = "InpurVariablesOKButton";
            LVNextButton.Text = "Ok";
            LVNextButton.Location = new Point(OutputNumberlabel2.Location.X, OutputUpDown.Location.Y + (25 * LVCount) + 25);
            LVNextButton.Click += OkButton_Clicked;
            this.Controls.Add(LVNextButton);

        }

        void OkButton_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < LVCount; i++)
            {
                inputVariables[i] = Convert.ToInt32(this.Controls["upDown_InputVariableValue_" + i].Text);
            }

            outputVariable = Convert.ToInt32(this.Controls["upDown_OutputVariableValue_"].Text);
        }

    }
}
