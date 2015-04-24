//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Drawing;
//using System.Windows.Forms;

//namespace WindowsFormsApplication1
//{
//    class Class1
//    {
//        public void fill(Form1 form1)
//        {
//            for (int i = 0; i < Form1.termsCount; i++)
//            {
//                // creating Label Terms count
//                Label Numberlabel = new Label();
//                Numberlabel.Name = "label_TermsCount_" + i;
//                Numberlabel.Text = "Term №" + (i + 1) + ":";
//                Numberlabel.Width = 60;
//                Numberlabel.Location = new Point(form1.TermCountLabel.Location.X, form1.TermCountLabel.Location.Y + (25 + 25 * i));
//                form1.AddTermsPanel.Controls.Add(Numberlabel);
//                // creating Label Term ID
//                Label IDlabel = new Label();
//                IDlabel.Name = "label_TermID_" + i;
//                IDlabel.Text = "Id:";
//                IDlabel.Width = 20;
//                IDlabel.Location = new Point(Numberlabel.Location.X + Numberlabel.Width, form1.TermCountLabel.Location.Y + (25 + 25 * i));
//                form1.AddTermsPanel.Controls.Add(IDlabel);

//                //creating TextBox for Terms ID
//                TextBox IDtextBox = new TextBox();
//                IDtextBox.Name = "textbox_TermID_" + i;
//                IDtextBox.Width = 50;
//                IDtextBox.Location = new Point(IDlabel.Location.X + IDlabel.Width, form1.TermCountLabel.Location.Y + (25 + 25 * i));
//                IDtextBox.Text = "tmid_" + i;  // DEBUG
//                form1.AddTermsPanel.Controls.Add(IDtextBox);

//                // creating Label Term name
//                Label Namelabel = new Label();
//                Namelabel.Name = "label_TermsName_" + i;
//                Namelabel.Text = "Terms name:";
//                Namelabel.Width = 70;
//                Namelabel.Location = new Point(IDtextBox.Location.X + IDtextBox.Width + 5, form1.TermCountLabel.Location.Y + (25 + 25 * i));
//                form1.AddTermsPanel.Controls.Add(Namelabel);

//                // creating TextBox for Term name
//                TextBox NametextBox = new TextBox();
//                NametextBox.Name = "textbox_TermName_" + i;
//                NametextBox.Width = 100;
//                NametextBox.Location = new Point(Namelabel.Location.X + Namelabel.Width, form1.TermCountLabel.Location.Y + (25 + 25 * i));
//                NametextBox.Text = "tmname_" + i;  // DEBUG
//                form1.AddTermsPanel.Controls.Add(NametextBox);

//                // creating Label Term min range
//                Label MinRangelabel = new Label();
//                MinRangelabel.Name = "label_TermMinrange_" + i;
//                MinRangelabel.Text = "Range from:";
//                MinRangelabel.Width = 65;
//                MinRangelabel.Location = new Point(NametextBox.Location.X + NametextBox.Width + 5, form1.TermCountLabel.Location.Y + (25 + 25 * i));
//                form1.AddTermsPanel.Controls.Add(MinRangelabel);

//                // creating UpDown Term min range
//                NumericUpDown MinRangeUpDown = new NumericUpDown();
//                MinRangeUpDown.Name = "upDown_TermMinrange_" + i;
//                MinRangeUpDown.Width = 36;
//                MinRangeUpDown.Location = new Point(MinRangelabel.Location.X + MinRangelabel.Width + 5, form1.TermCountLabel.Location.Y + (25 + 25 * i));
//                form1.AddTermsPanel.Controls.Add(MinRangeUpDown);

//                // creating Label Term max range
//                Label MaxRangelabel = new Label();
//                MaxRangelabel.Name = "label_TermMaxrange_" + i;
//                MaxRangelabel.Text = "Range to:";
//                MaxRangelabel.Width = 60;
//                MaxRangelabel.Location = new Point(MinRangeUpDown.Location.X + MinRangeUpDown.Width + 5, form1.TermCountLabel.Location.Y + (25 + 25 * i));
//                form1.AddTermsPanel.Controls.Add(MaxRangelabel);

//                // creating UpDown Term max range
//                NumericUpDown MaxRangeUpDown = new NumericUpDown();
//                MaxRangeUpDown.Name = "upDown_TermMaxrange_" + i;
//                MaxRangeUpDown.Width = 36;
//                MaxRangeUpDown.Location = new Point(MaxRangelabel.Location.X + MaxRangelabel.Width + 5, form1.TermCountLabel.Location.Y + (25 + 25 * i));
//                MaxRangeUpDown.Value = 1 + 10 * i; // DEBUG
//                form1.AddTermsPanel.Controls.Add(MaxRangeUpDown);
//            }

//            // creating OK button
//            Button TermsOKButton = new Button();
//            TermsOKButton.Name = "TermOKButton";
//            TermsOKButton.Text = "Accept";
//            TermsOKButton.Location = new Point(form1.TermCountLabel.Location.X, form1.TermCountLabel.Location.Y + form1.termsCount * 25 + 25);
//            form1.AddTermsPanel.Controls.Add(TermsOKButton);
//            TermsOKButton.Click += OKButton_Clicked;

//            // creating Cancel button
//            Button termsCancelButton = new Button();
//            termsCancelButton.Name = "TermCancelButton";
//            termsCancelButton.Text = "Cancel";
//            termsCancelButton.Location = new Point(form1.TermCountLabel.Location.X + 100, form1.TermCountLabel.Location.Y + form1.termsCount * 25 + 25);
//            form1.AddTermsPanel.Controls.Add(termsCancelButton);
//            termsCancelButton.Click += CancelButton_Clicked;
//        }

//        void OKButton_Clicked(object sender, EventArgs e)
//        {
//            form1._term = new ProductionRulesTerm[termsCount];
//            bool shouldClose = false;
//            for (int i = 0; i < termsCount; i++)
//            {
//                string ID = AddTermsPanel.Controls["textbox_TermID_" + i].Text;
//                if (ID == "")
//                {
//                    MessageBox.Show("Error! Term's №" + (i + 1) + " ID is empty!");
//                    shouldClose = false;
//                    break;
//                }

//                string termName = AddTermsPanel.Controls["textbox_TermName_" + i].Text;
//                if (termName == "")
//                {
//                    MessageBox.Show("Error! Term's №" + (i + 1) + " name is empty!");
//                    shouldClose = false;
//                    break;
//                }

//                int termMinRange = Convert.ToInt32(AddTermsPanel.Controls["upDown_TermMinrange_" + i].Text);
//                int termMaxRange = Convert.ToInt32(AddTermsPanel.Controls["upDown_TermMaxrange_" + i].Text);
//                if (termMinRange >= termMaxRange)
//                {
//                    MessageBox.Show("Error! Term's №" + (i + 1) + " minimum ragne is equal or greater than maximum range!");
//                    shouldClose = false;
//                    break;
//                }

//                shouldClose = true;
//                _term[i] = new ProductionRulesTerm(ID, termName, termMinRange, termMaxRange);
//                _terms[number, i] = _term[i];
//            }
//            if (shouldClose)
//            {
//                AddTermsPanel.Visible = false;
//            }
//        }

//        void CancelButton_Clicked(object sender, EventArgs e)
//        {
//            AddTermsPanel.Visible = false;
//        }
//    }
//}
