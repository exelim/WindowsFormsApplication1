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
            if (termsCount != Convert.ToInt32(TermsCountUpDown.Value))
            {
                for (int i = 0; i <= termsCount; i++)
                {
                    this.Controls.RemoveByKey("label_TermsCount_" + (i + 1));
                    this.Controls.RemoveByKey("label_TermID_" + (i + 1));
                    this.Controls.RemoveByKey("textbox_TermID_" + (i + 1));
                    this.Controls.RemoveByKey("label_TermsName_" + (i + 1));
                    this.Controls.RemoveByKey("textbox_TermName_" + (i + 1));
                    this.Controls.RemoveByKey("label_TermMinrange_" + (i + 1));
                    this.Controls.RemoveByKey("upDown_TermMinrange_" + (i + 1));
                    this.Controls.RemoveByKey("label_TermMaxrange_" + (i + 1));
                    this.Controls.RemoveByKey("upDown_TermMaxrange_" + (i + 1));
                    this.Controls.RemoveByKey("TermOKButton");
                    this.Controls.RemoveByKey("TermCancelButton");
                }
            }

            termsCount = Convert.ToInt32(TermsCountUpDown.Value);

            for (int i = 0; i < TermsCountUpDown.Value; i++)
            {
                // creating Label Terms count
                Label Numberlabel = new Label();
                Numberlabel.Name = "label_TermsCount_" + (i + 1);
                Numberlabel.Text = "Term №" + (i + 1) + ":";
                Numberlabel.Width = 60;
                Numberlabel.Location = new Point(TermCountLabel.Location.X, TermCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(Numberlabel);

                // creating Label Term ID
                Label IDlabel = new Label();
                IDlabel.Name = "label_TermID_" + (i + 1);
                IDlabel.Text = "Id:";
                IDlabel.Width = 20;
                IDlabel.Location = new Point(Numberlabel.Location.X + Numberlabel.Width, TermCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(IDlabel);

                //creating TextBox for Terms ID
                TextBox IDtextBox = new TextBox();
                IDtextBox.Name = "textbox_TermID_" + (i + 1);
                IDtextBox.Width = 50;
                IDtextBox.Location = new Point(IDlabel.Location.X + IDlabel.Width, TermCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(IDtextBox);

                // creating Label Term name
                Label Namelabel = new Label();
                Namelabel.Name = "label_TermsName_" + (i + 1);
                Namelabel.Text = "Terms name:";
                Namelabel.Width = 70;
                Namelabel.Location = new Point(IDtextBox.Location.X + IDtextBox.Width + 5, TermCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(Namelabel);

                // creating TextBox for Term name
                TextBox NametextBox = new TextBox();
                NametextBox.Name = "textbox_TermName_" + (i + 1);
                NametextBox.Width = 100;
                NametextBox.Location = new Point(Namelabel.Location.X + Namelabel.Width, TermCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(NametextBox);

                // creating Label Term min range
                Label MinRangelabel = new Label();
                MinRangelabel.Name = "label_TermMinrange_" + (i + 1);
                MinRangelabel.Text = "Range from:";
                MinRangelabel.Width = 65;
                MinRangelabel.Location = new Point(NametextBox.Location.X + NametextBox.Width + 5, TermCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(MinRangelabel);

                // creating UpDown Term min range
                NumericUpDown MinRangeUpDown = new NumericUpDown();
                MinRangeUpDown.Name = "upDown_TermMinrange_" + (i + 1);
                MinRangeUpDown.Width = 36;
                MinRangeUpDown.Location = new Point(MinRangelabel.Location.X + MinRangelabel.Width + 5, TermCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(MinRangeUpDown);

                // creating Label Term max range
                Label MaxRangelabel = new Label();
                MaxRangelabel.Name = "label_TermMaxrange_" + (i + 1);
                MaxRangelabel.Text = "Range to:";
                MaxRangelabel.Width = 60;
                MaxRangelabel.Location = new Point(MinRangeUpDown.Location.X + MinRangeUpDown.Width + 5, TermCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(MaxRangelabel);

                // creating UpDown Term max range
                NumericUpDown MaxRangeUpDown = new NumericUpDown();
                MaxRangeUpDown.Name = "upDown_TermMaxrange_" + (i + 1);
                MaxRangeUpDown.Width = 36;
                MaxRangeUpDown.Location = new Point(MaxRangelabel.Location.X + MaxRangelabel.Width + 5, TermCountLabel.Location.Y + (25 + 25 * i));
                this.Controls.Add(MaxRangeUpDown);
            }

            // creating OK button
            Button TermsOKButton = new Button();
            TermsOKButton.Name = "TermOKButton";
            TermsOKButton.Text = "Accept";
            TermsOKButton.Location = new Point(TermCountLabel.Location.X, TermCountLabel.Location.Y + termsCount*25 + 25);
            this.Controls.Add(TermsOKButton);

            // creating Cancel button
            Button termsCancelButton = new Button();
            termsCancelButton.Name = "TermCancelButton";
            termsCancelButton.Text = "Cancel";
            termsCancelButton.Location = new Point(TermCountLabel.Location.X + 100, TermCountLabel.Location.Y + termsCount*25 + 25);
            this.Controls.Add(termsCancelButton);

        }

        void OKButton_Clicked(object sender, EventArgs e)
        { 
            
        }

        void CancelButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}
