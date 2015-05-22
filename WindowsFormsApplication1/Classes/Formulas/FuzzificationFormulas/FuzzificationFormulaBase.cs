using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.FuzzificationFormulas
{
    public abstract class FuzzificationFormulaBase
    {
        public abstract double CalculateFuzzification(Queue<double> points, double minVal, double maxVal);
    }
}
