using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.FuzzificationFormulas
{
    class CenterOfGravityFuzzification : FuzzificationFormulaBase
    {
        public override double CalculateFuzzification(Queue<double> points, double minVal, double maxVal)
        {
            double result, h;

            result = 0;

            h = (maxVal - minVal) / points.Count; //Шаг сетки

            for ( int i = 0; i < points.Count; i++)
            {
                result += points.ElementAt( i ); //Вычисляем в средней точке и добавляем в сумму
            }

            result *= h;

            return result;
        }
    }
}
