using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.FuzzificationFormulas
{
    class CenterSquareFuzzification : FuzzificationFormulaBase
    {
        public override double CalculateFuzzification(Queue<double> points, double minVal, double maxVal)
        {
            return 0.0;
        }
    }
}
