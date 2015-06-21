using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.FuzzificationFormulas
{
    class CenterOfGravityPointSetsFuzzification : FuzzificationFormulaBase
    {
        public override double CalculateFuzzification(Queue<double> points, double minVal, double maxVal)
        {
            double sum1 = 0.0, sum2 = 0.0, x = 0.0;
            foreach (var item in points)
            {
                sum1 += x * item;
                sum2 += item;

                x += ( maxVal - minVal ) / points.Count;
            }
            return sum1 / sum2;
        }
    }
}
