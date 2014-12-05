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

        // FORMS
        Form addTermsForm;


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

            for (int i = 0; i < LVCountUpDown.Value; i++)
            {
                // creating Label LV number
                Label Numberlabel = new Label();
                Numberlabel.Name = "label_LVNumber_" + (i + 1);
                Numberlabel.Text = "Linguistic var №" + (i + 1) + ":";
                Numberlabel.Width = 95;
                Numberlabel.Location = new Point(LVCountLabel.Location.X, LVCountLabel.Location.Y + ( 25 + 25 * i));
                this.Controls.Add(Numberlabel);

                // creating Label LV ID
                Label IDlabel = new Label();
                IDlabel.Name = "label_LVID_" + (i + 1);
                IDlabel.Text = "Id:";
                IDlabel.Width = 20;
                IDlabel.Location = new Point(Numberlabel.Location.X + Numberlabel.Width, LVCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(IDlabel);

                 //creating TextBox for LV id
                TextBox IDtextBox = new TextBox();
                IDtextBox.Name = "textbox_LVID_" + (i + 1);
                IDtextBox.Width = 50;
                IDtextBox.Location = new Point(IDlabel.Location.X + IDlabel.Width, LVCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(IDtextBox);

                // creating Label LV name
                Label Namelabel = new Label();
                Namelabel.Name = "label_LVName_" + (i + 1);
                Namelabel.Text = "Linguistic var name:";
                Namelabel.Width = 110;
                Namelabel.Location = new Point(IDtextBox.Location.X + IDtextBox.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(Namelabel);

                // creating TextBox for LV name
                TextBox NametextBox = new TextBox();
                NametextBox.Name = "textbox_LVName_" + (i + 1);
                NametextBox.Width = 100;
                NametextBox.Location = new Point(Namelabel.Location.X + Namelabel.Width, LVCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(NametextBox);

                // creating Label LV min range
                Label MinRangelabel = new Label();
                MinRangelabel.Name = "label_LVMinrange_" + (i + 1);
                MinRangelabel.Text = "Range from:";
                MinRangelabel.Width = 65;
                MinRangelabel.Location = new Point(NametextBox.Location.X + NametextBox.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(MinRangelabel);

                // creating UpDown LV min range
                NumericUpDown MinRangeUpDown = new NumericUpDown();
                MinRangeUpDown.Name = "upDown_LVMinrange_" + (i + 1);
                MinRangeUpDown.Width = 36;
                MinRangeUpDown.Location = new Point(MinRangelabel.Location.X + MinRangelabel.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(MinRangeUpDown);

                // creating Label LV max range
                Label MaxRangelabel = new Label();
                MaxRangelabel.Name = "label_LVMaxrange_" + (i + 1);
                MaxRangelabel.Text = "Range to:";
                MaxRangelabel.Width = 60;
                MaxRangelabel.Location = new Point(MinRangeUpDown.Location.X + MinRangeUpDown.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(MaxRangelabel);

                // creating UpDown LV max range
                NumericUpDown MaxRangeUpDown = new NumericUpDown();
                MaxRangeUpDown.Name = "upDown_LVMaxrange_" + (i + 1);
                MaxRangeUpDown.Width = 36;
                MaxRangeUpDown.Location = new Point(MaxRangelabel.Location.X + MaxRangelabel.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(MaxRangeUpDown);

                // creating Label Terms count
                Label TermsCountlabel = new Label();
                TermsCountlabel.Name = "label_LVMaxrange_" + (i + 1);
                TermsCountlabel.Text = "Terms count:";
                TermsCountlabel.Width = 70;
                TermsCountlabel.Location = new Point(MaxRangeUpDown.Location.X + MaxRangeUpDown.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(TermsCountlabel);

                // creating UpDown terms Count
                NumericUpDown TermsCountUpDown = new NumericUpDown();
                TermsCountUpDown.Name = "upDown_TermsCount_" + (i + 1);
                TermsCountUpDown.Width = 36;
                TermsCountUpDown.Location = new Point(TermsCountlabel.Location.X + TermsCountlabel.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(TermsCountUpDown);

                // creating button add terms
                Button AddTerms = new Button();
                AddTerms.Name = "button_AddTerms_" + (i + 1);
                AddTerms.Width = 90;
                AddTerms.Text = "Add terms";
                AddTerms.Location = new Point(TermsCountUpDown.Location.X + TermsCountUpDown.Width + 5, LVCountLabel.Location.Y + (25 + 25 * i));
                AddTerms.Click += AddTermsButton_Clicked;
                this.Controls.Add(AddTerms);
            }

            // creating OK button
            Button LVOKButton = new Button();
            LVOKButton.Name = "LVOKButton";
            LVOKButton.Text = "Accept";
            LVOKButton.Location = new Point(LVCountLabel.Location.X, LVCountLabel.Location.Y + lexicalVariablesCount * 25 + 25);
            this.Controls.Add(LVOKButton);

            // creating Cancel button
            Button LVCancelButton = new Button();
            LVCancelButton.Name = "LVCancelButton";
            LVCancelButton.Text = "Cancel";
            LVCancelButton.Location = new Point(LVCountLabel.Location.X + 100, LVCountLabel.Location.Y + lexicalVariablesCount * 25 + 25);
            this.Controls.Add(LVCancelButton);
        }

        void AddTermsButton_Clicked(object sender, EventArgs e)
        {
            addTermsForm = new AddTermForm();
            addTermsForm.ShowDialog();
        }
    }
}
