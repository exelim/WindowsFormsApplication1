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

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            // Создадим список точек


            for (int i = 0; i < Form1._terms.ElementAt(Form1.number).Count; i++)
            {
                ZedGraph.PointPairList list = new ZedGraph.PointPairList();

                double xmin = Form1._terms.ElementAt(Form1.number).ElementAt(i).m_minValue;
                double xmax = Form1._terms.ElementAt(Form1.number).ElementAt(i).m_maxValue;

                // Заполняем список точек
                for (double x = xmin; x <= xmax; x += 0.01)
                {
                    // добавим в список точку
                    list.Add(x, Form1._terms.ElementAt(Form1.number).ElementAt(i).CalculateValue(x));
                }

                // Создадим кривую с названием "Sinc", 
                // которая будет рисоваться голубым цветом (Color.Blue),
                // Опорные точки выделяться не будут (SymbolType.None)
                ZedGraph.LineItem myCurve;

                myCurve = pane.AddCurve(Form1._terms.ElementAt(Form1.number).ElementAt(i).m_name, list, Color.Red, ZedGraph.SymbolType.None);
                myCurve.MakeUnique();

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
