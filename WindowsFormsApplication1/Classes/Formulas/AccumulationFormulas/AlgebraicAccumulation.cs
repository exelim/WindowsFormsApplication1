using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.AccumulationFormulas
{
    class AlgebraicAccumulation : AccumulatiomFormulaBase
    {
        public override double CalculateAccumulation(Stack<double> _st)
        {
            double res = 1.0;
            foreach (var item in _st)
            {
                res *= item;
            }
            return (_st.Sum()) - (res);
        }
    }
}
