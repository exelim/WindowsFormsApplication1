using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Structures;
using WindowsFormsApplication1.Classes.MembershipFunctions;

namespace WindowsFormsApplication1
{
    public partial class AddTermForm : Form
    {

        int idx;

        public AddTermForm( int _idx )
        {
            InitializeComponent();

            idx = _idx;



            MembershipCombobox.Items.Add("Gauss Function");
            MembershipCombobox.Items.Add("Sigmoid Function");
            MembershipCombobox.Items.Add("Singleton Function");
            MembershipCombobox.Items.Add("Trapezoidal Function");
            MembershipCombobox.Items.Add("Triangle Function");
            MembershipCombobox.Items.Add("\"S\" Function");
            MembershipCombobox.Items.Add("\"Z\" Function");
            MembershipCombobox.SelectedIndex = 0;
            
            // Since default function is Gauss
            AInput.Text = Convert.ToDouble(((Form1._term[_idx].m_maxValue - Form1._term[_idx].m_minValue) + 1) / 4.0).ToString();
            BInput.Text = Convert.ToDouble((Form1._term[_idx].m_maxValue + Form1._term[_idx].m_minValue) / 2.0).ToString();

            Form1._term[idx].m_membershipFinction = new GaussFunction(Convert.ToDouble(AInput.Text), 0, Convert.ToDouble(BInput.Text), 0);
            DrawFunction();

        }

        private void button1_Click(object sender, EventArgs e) // OK Button
        {
            //if (Form1._term[idx].m_membershipFinction == null)
            //{
                double min, max;
                switch (MembershipCombobox.SelectedIndex)
                {
                    case 0: // Gaus
                        if (AInput.Text == "" || BInput.Text == "")
                        {
                            MessageBox.Show("Error! Fields are empty.");
                            break;
                        }
                        Form1._term[idx].m_membershipFinction = new GaussFunction(Convert.ToDouble(AInput.Text), 0, Convert.ToDouble(BInput.Text), 0);
                        break;
                    case 1: // Sigmoid
                        if (AInput.Text == "" || BInput.Text == "")
                        {
                            MessageBox.Show("Error! Fields are empty.");
                            break;
                        }
                        Form1._term[idx].m_membershipFinction = new SigmoidFunction(Convert.ToDouble(AInput.Text), 0, Convert.ToDouble(BInput.Text), 0);
                        break;
                    case 2: // Singleton
                        if (AInput.Text == "")
                        {
                            MessageBox.Show("Error! Fields are empty.");
                            break;
                        }
                        Form1._term[idx].m_membershipFinction = new SingletonFunction(Convert.ToDouble(AInput.Text), 0, 0, 0);
                        break;
                    case 3: // Tpapezoidal
                        min = Form1._term[idx].m_minValue;
                        max = Form1._term[idx].m_maxValue;
                        Form1._term[idx].m_membershipFinction = new TrapezoidalFunction(min, min + (min + max) / 4, max - (min + max) / 4, max);
                        break;
                    case 4: // Triangle  
                        min = Form1._term[idx].m_minValue;
                        max = Form1._term[idx].m_maxValue;
                        Form1._term[idx].m_membershipFinction = new TriangleFunction(min, (min + max) / 2, max, 0);
                        break;
                    case 5: // S  
                        min = Form1._term[idx].m_minValue;
                        max = Form1._term[idx].m_maxValue;
                        Form1._term[idx].m_membershipFinction = new SFunction(Convert.ToDouble(AInput.Text), Convert.ToDouble(BInput.Text), 0, 0);
                        break;
                    case 6: // Z  
                        min = Form1._term[idx].m_minValue;
                        max = Form1._term[idx].m_maxValue;
                        Form1._term[idx].m_membershipFinction = new ZFunction(Convert.ToDouble(AInput.Text), Convert.ToDouble(BInput.Text), 0, 0);
                        break;
               // }
            }
                if (Form1._terms[Form1.number].ContainsKey(idx))
                {
                    Form1._terms[Form1.number].Remove(idx);

                    Form1._terms[Form1.number][idx] = Form1._term[idx];
                }
                else 
                {
                    Form1._terms[Form1.number][idx] = Form1._term[idx];
                }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) // Draw Button
        {
            double min, max;
            switch (MembershipCombobox.SelectedIndex)
            {
                case 0: // Gaus
                    if (AInput.Text == "" || BInput.Text == "")
                    {
                        MessageBox.Show("Error! Fields are empty.");
                        break;
                    }
                    Form1._term[idx].m_membershipFinction = new GaussFunction(Convert.ToDouble(AInput.Text), 0, Convert.ToDouble(BInput.Text), 0);
                    break;
                case 1: // Sigmoid
                    if (AInput.Text == "" || BInput.Text == "")
                    {
                        MessageBox.Show("Error! Fields are empty.");
                        break;
                    }
                    Form1._term[idx].m_membershipFinction = new SigmoidFunction(Convert.ToDouble(AInput.Text), 0, Convert.ToDouble(BInput.Text), 0);
                    break;
                case 2: // Singleton
                    if (AInput.Text == "")
                    {
                        MessageBox.Show("Error! Fields are empty.");
                        break;
                    }
                    Form1._term[idx].m_membershipFinction = new SingletonFunction(Convert.ToDouble(AInput.Text), 0, 0, 0);
                    break;
                case 3: // Tpapezoidal
                    if (AInput.Text == "" || BInput.Text == "")
                    {
                        MessageBox.Show("Error! Fields are empty.");
                        break;
                    }
                    else if (Form1._term[idx].m_minValue >= Convert.ToDouble(AInput.Text) || Convert.ToDouble(AInput.Text) >= Convert.ToDouble(BInput.Text) || Convert.ToDouble(BInput.Text) >= Form1._term[idx].m_maxValue)
                    {
                        MessageBox.Show("Error! Wrong parameters. Correct are: a < b < c < d.");
                        break;
                    }
                    min = Form1._term[idx].m_minValue;
                    max = Form1._term[idx].m_maxValue;
                    Form1._term[idx].m_membershipFinction = new TrapezoidalFunction(min, Convert.ToDouble(AInput.Text), Convert.ToDouble(BInput.Text), max);
                    break;
                case 4: // Triangle
                    if (AInput.Text == "")
                    {
                        MessageBox.Show("Error! Fields are empty.");
                        break;
                    }
                    else if (Form1._term[idx].m_minValue >= Convert.ToDouble(AInput.Text) || Convert.ToDouble(AInput.Text) >= Form1._term[idx].m_maxValue)
                    {
                        MessageBox.Show("Error! Wrong parameters. Correct are: a < b < c.");
                        break;
                    }
                    min = Form1._term[idx].m_minValue;
                    max = Form1._term[idx].m_maxValue;
                    Form1._term[idx].m_membershipFinction = new TriangleFunction(min, Convert.ToDouble(AInput.Text), max, 0);
                    break;
                case 5: // S
                    if (AInput.Text == "" || BInput.Text == "")
                    {
                        MessageBox.Show("Error! Fields are empty.");
                        break;
                    }
                    min = Form1._term[idx].m_minValue;
                    max = Form1._term[idx].m_maxValue;
                    Form1._term[idx].m_membershipFinction = new SFunction(Convert.ToDouble(AInput.Text), Convert.ToDouble(BInput.Text), 0, 0);
                    break;
                case 6: // Z  
                    if (AInput.Text == "" || BInput.Text == "")
                    {
                        MessageBox.Show("Error! Fields are empty.");
                        break;
                    }
                    min = Form1._term[idx].m_minValue;
                    max = Form1._term[idx].m_maxValue;
                    Form1._term[idx].m_membershipFinction = new ZFunction(Convert.ToDouble(AInput.Text), Convert.ToDouble(BInput.Text), 0, 0);
                    break;
            }

            DrawFunction();
        }

        void DrawFunction()
        {
            // Получим панель для рисования
            ZedGraph.GraphPane pane = MembershipFunctionGraph.GraphPane;
            pane.Title.Text = "Membersip function for \"" + Form1._term[idx].m_name + "\"";
            pane.XAxis.Title.Text = "\"" + Form1.currentLVName /*Form1._term[idx].m_name*/ + "\"";
            pane.YAxis.Title.Text = "Membership Grade";

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            pane.Legend.IsVisible = false;

            // Создадим список точек
            ZedGraph.PointPairList list = new ZedGraph.PointPairList();

            double xmin = Form1.currentLVMinValue;
            double xmax = Form1.currentLVMaxValue;

            // Заполняем список точек
            for (double x = xmin; x <= xmax; x += 0.01)
            {
                // добавим в список точку
                double val = Form1._term[idx].CalculateValue(x);
                list.Add(x, val);
            }

            // Создадим кривую с названием "Sinc", 
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            ZedGraph.LineItem myCurve;

            myCurve = pane.AddCurve(Form1._term[idx].m_name, list, Color.Black, ZedGraph.SymbolType.None);

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            MembershipFunctionGraph.AxisChange();

            // Обновляем график
            MembershipFunctionGraph.Invalidate();
        }

        private void MembershipCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            double min, max;
            switch (MembershipCombobox.SelectedIndex)
            {
                case 0: // Gaus
                    ALabel.Text = "g :";
                    ALabel.Visible = true;
                    AInput.Visible = true;
                    BLabel.Visible = true;
                    BInput.Visible = true;
                    AInput.Text = Convert.ToDouble(((Form1._term[idx].m_maxValue - Form1._term[idx].m_minValue) + 1) / 4.0).ToString();
                    BInput.Text = Convert.ToDouble((Form1._term[idx].m_maxValue + Form1._term[idx].m_minValue) / 2.0).ToString();
                    break;
                case 1: // Sigmoid
                    ALabel.Text = "a :";
                    ALabel.Visible = true;
                    AInput.Visible = true;
                    BLabel.Visible = true;
                    BInput.Visible = true;
                    break;
                case 2: // Singleton
                    ALabel.Text = "a :";
                    ALabel.Visible = true;
                    AInput.Visible = true;
                    BLabel.Visible = false;
                    BInput.Visible = false;
                    break;
                case 3: // Tpapezoidal
                    ALabel.Text = "b :";
                    BLabel.Text = "c :";
                    ALabel.Visible = true;
                    AInput.Visible = true;
                    BLabel.Visible = true;
                    BInput.Visible = true;
                    min = Form1._term[idx].m_minValue;
                    max = Form1._term[idx].m_maxValue;
                    AInput.Text = Convert.ToDouble( min + ( max + min ) / 4 ).ToString();
                    BInput.Text = Convert.ToDouble( max - ( max + min ) / 4 ).ToString();
                    break;
                case 4: // Triangle  
                    ALabel.Text = "b :";
                    ALabel.Visible = true;
                    AInput.Visible = true;
                    BLabel.Visible = false;
                    BInput.Visible = false;
                    AInput.Text = Convert.ToDouble((Form1._term[idx].m_maxValue + Form1._term[idx].m_minValue) / 2.0).ToString();
                    break;
                case 5: // S
                    ALabel.Text = "a :";
                    ALabel.Visible = true;
                    AInput.Visible = true;
                    BLabel.Visible = true;
                    BInput.Visible = true;
                    break;
                case 6: // Z
                    ALabel.Text = "a :";
                    ALabel.Visible = true;
                    AInput.Visible = true;
                    BLabel.Visible = true;
                    BInput.Visible = true;
                    break;

            }
        }

        private void AInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != ',') && ((e.KeyChar == '-') && ((sender as TextBox).SelectionStart != 0) && (sender as TextBox).Text.IndexOf('-') != 0)) 
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void BInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != ',') && ((e.KeyChar == '-') && ((sender as TextBox).SelectionStart != 0) && (sender as TextBox).Text.IndexOf('-') != 0)) 
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
