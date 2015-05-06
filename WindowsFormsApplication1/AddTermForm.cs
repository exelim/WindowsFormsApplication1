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
            MembershipCombobox.SelectedIndex = 0;
            
            // Since default function is Gauss
            AInput.Text = Convert.ToDouble(((Form1._term[_idx].m_maxValue - Form1._term[_idx].m_minValue) + 1) / 6.0).ToString();
            BInput.Text = Convert.ToDouble((Form1._term[_idx].m_maxValue + Form1._term[_idx].m_minValue) / 2.0).ToString();

        }

        private void button1_Click(object sender, EventArgs e) // OK Button
        {
            if (Form1._term[idx].m_membershipFinction == null)
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
                        min = Form1._term[idx].m_minValue;
                        max = Form1._term[idx].m_maxValue;
                        Form1._term[idx].m_membershipFinction = new TrapezoidalFunction(min, min + (min + max) / 4, max - (min + max) / 4, max);
                        break;
                    case 4: // Triangle  
                        min = Form1._term[idx].m_minValue;
                        max = Form1._term[idx].m_maxValue;
                        Form1._term[idx].m_membershipFinction = new TriangleFunction(min, (min + max) / 2, max, 0);
                        break;
                }
            }
            Form1._terms.ElementAt(Form1.number).Push(Form1._term[idx]);
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
                    min = Form1._term[idx].m_minValue;
                    max = Form1._term[idx].m_maxValue;
                    Form1._term[idx].m_membershipFinction = new TriangleFunction(min, Convert.ToDouble(AInput.Text), max, 0);
                    break;
            }

            // Получим панель для рисования
            ZedGraph.GraphPane pane = MembershipFunctionGraph.GraphPane;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            // Создадим список точек

            ZedGraph.PointPairList list = new ZedGraph.PointPairList();

            double xmin = Form1._term[idx].m_minValue;
            double xmax = Form1._term[idx].m_maxValue;

            // Заполняем список точек
            for (double x = xmin; x <= xmax; x += 0.01)
            {
                // добавим в список точку
                list.Add(x, Form1._term[idx].CalculateValue(x));
            }

            // Создадим кривую с названием "Sinc", 
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            ZedGraph.LineItem myCurve;

            myCurve = pane.AddCurve(Form1._term[idx].m_name, list, Color.Red, ZedGraph.SymbolType.None);
            myCurve.MakeUnique();

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
                    AInput.Text = Convert.ToDouble(((Form1._term[idx].m_maxValue - Form1._term[idx].m_minValue) + 1) / 6.0).ToString();
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
                    AInput.Text = Convert.ToDouble((Form1._term[idx].m_maxValue - Form1._term[idx].m_minValue) / 2.0).ToString();
                    break;
            }
        }
    }
}
