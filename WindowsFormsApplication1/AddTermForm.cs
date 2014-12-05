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
    public partial class AddTermForm : Form
    {
        public int termsCount;

        public AddTermForm()
        {
            InitializeComponent();
        }

        private void TermsCountConfirmButton_Click(object sender, EventArgs e)
        {
            if (termsCount > Convert.ToInt32(TermsCountUpDown.Value))
            {
                for (int i = 0; i <= termsCount; i++)
                {
                    this.Controls.RemoveByKey("LiguisticVariable_" + (i + 1));
                }
            }

            termsCount = Convert.ToInt32(TermsCountUpDown.Value);

            for (int i = 0; i < TermsCountUpDown.Value; i++)
            {
                // creating Label LV number
                Label Numberlabel = new Label();
                Numberlabel.Name = "label_LVNumber_" + (i + 1);
                Numberlabel.Text = "Linguistic var №" + (i + 1) + ":";
                Numberlabel.Width = 95;
                Numberlabel.Location = new Point(termsCountLabel.Location.X, termsCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(Numberlabel);

                // creating Label LV ID
                Label IDlabel = new Label();
                IDlabel.Name = "label_LVID_" + (i + 1);
                IDlabel.Text = "Id:";
                IDlabel.Width = 20;
                IDlabel.Location = new Point(Numberlabel.Location.X + Numberlabel.Width, termsCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(IDlabel);

                //creating TextBox for LV id
                TextBox IDtextBox = new TextBox();
                IDtextBox.Name = "textbox_LVID_" + (i + 1);
                IDtextBox.Width = 50;
                IDtextBox.Location = new Point(IDlabel.Location.X + IDlabel.Width, termsCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(IDtextBox);

                // creating Label LV name
                Label Namelabel = new Label();
                Namelabel.Name = "label_LVName_" + (i + 1);
                Namelabel.Text = "Linguistic var name:";
                Namelabel.Width = 110;
                Namelabel.Location = new Point(IDtextBox.Location.X + IDtextBox.Width + 5, termsCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(Namelabel);

                // creating TextBox for LV name
                TextBox NametextBox = new TextBox();
                NametextBox.Name = "textbox_LVName_" + (i + 1);
                NametextBox.Width = 100;
                NametextBox.Location = new Point(Namelabel.Location.X + Namelabel.Width, termsCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(NametextBox);

                // creating Label LV min range
                Label MinRangelabel = new Label();
                MinRangelabel.Name = "label_LVMinrange_" + (i + 1);
                MinRangelabel.Text = "Range from:";
                MinRangelabel.Width = 65;
                MinRangelabel.Location = new Point(NametextBox.Location.X + NametextBox.Width + 5, termsCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(MinRangelabel);

                // creating UpDown LV min range
                NumericUpDown MinRangeUpDown = new NumericUpDown();
                MinRangeUpDown.Name = "upDown_LVMinrange_" + (i + 1);
                MinRangeUpDown.Width = 36;
                MinRangeUpDown.Location = new Point(MinRangelabel.Location.X + MinRangelabel.Width + 5, termsCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(MinRangeUpDown);

                // creating Label LV max range
                Label MaxRangelabel = new Label();
                MaxRangelabel.Name = "label_LVMaxrange_" + (i + 1);
                MaxRangelabel.Text = "Range to:";
                MaxRangelabel.Width = 60;
                MaxRangelabel.Location = new Point(MinRangeUpDown.Location.X + MinRangeUpDown.Width + 5, termsCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(MaxRangelabel);

                // creating UpDown LV max range
                NumericUpDown MaxRangeUpDown = new NumericUpDown();
                MaxRangeUpDown.Name = "upDown_LVMaxrange_" + (i + 1);
                MaxRangeUpDown.Width = 36;
                MaxRangeUpDown.Location = new Point(MaxRangelabel.Location.X + MaxRangelabel.Width + 5, termsCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(MaxRangeUpDown);

                // creating Label Terms count
                Label TermsCountlabel = new Label();
                TermsCountlabel.Name = "label_LVMaxrange_" + (i + 1);
                TermsCountlabel.Text = "Terms count:";
                TermsCountlabel.Width = 70;
                TermsCountlabel.Location = new Point(MaxRangeUpDown.Location.X + MaxRangeUpDown.Width + 5, termsCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(TermsCountlabel);
            }
        }


    }
}
