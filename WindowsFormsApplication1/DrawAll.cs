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
    public partial class DrawAll : Form
    {

        public DrawAll()
        {
            InitializeComponent();
            // Получим панель для рисования
            ZedGraph.GraphPane pane = AllTermsGraph.GraphPane;
            pane.Title.Text = "Membership functions for \"" + Form1.currentLVName + "\"";
            pane.XAxis.Title.Text = "\"" + Form1.currentLVName + "\"";
            pane.YAxis.Title.Text = "Membership Grade";

            pane.Legend.IsVisible = false;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            for (int i = 0; i < Form1._terms.ElementAt(Form1.number).Count; i++)
            {
                ZedGraph.PointPairList list = new ZedGraph.PointPairList();

                double xmin = Form1.currentLVMinValue;
                double xmax = Form1.currentLVMaxValue;

                ZedGraph.PointPair maxPoint = new ZedGraph.PointPair();
                // Заполняем список точек
                for (double x = xmin; x <= xmax; x += 0.01)
                {
                    // добавим в список точку
                    double val = Form1._terms[Form1.number][i].CalculateValue(x);
                    list.Add(x, val);
                    if( val > maxPoint.Y )
                    {
                        maxPoint.X = x;
                        maxPoint.Y = val;
                    }
                }

                // Создадим кривую с названием "Sinc", 
                // которая будет рисоваться голубым цветом (Color.Blue),
                // Опорные точки выделяться не будут (SymbolType.None)
                ZedGraph.LineItem myCurve;

                myCurve = pane.AddCurve(Form1._terms[Form1.number][i].m_name, list, Color.Black, ZedGraph.SymbolType.None);

                // Create a text label from the Y data value
                ZedGraph.TextObj text = new ZedGraph.TextObj(Form1._terms[Form1.number][i].m_name, maxPoint.X, maxPoint.Y + 0.1,
                ZedGraph.CoordType.AxisXYScale, ZedGraph.AlignH.Left, ZedGraph.AlignV.Center);
                text.ZOrder = ZedGraph.ZOrder.A_InFront;
                // Hide the border and the fill
                text.FontSpec.Border.IsVisible = false;
                text.FontSpec.Fill.IsVisible = false;
                pane.GraphObjList.Add(text);

                // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
                // В противном случае на рисунке будет показана только часть графика, 
                // которая умещается в интервалы по осям, установленные по умолчанию
                AllTermsGraph.AxisChange();

                // Обновляем график
                AllTermsGraph.Invalidate();
            }
        }
    }
}
