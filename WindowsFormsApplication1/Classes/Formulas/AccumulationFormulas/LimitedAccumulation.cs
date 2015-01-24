using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.AccumulationFormulas
{
    class LimitedAccumulation : AccumulatiomFormulaBase
    {
        public override double CalculateAccumulation(Stack<double> _st)
        {
            return Math.Min(1, _st.Sum());
        }
    }
}
