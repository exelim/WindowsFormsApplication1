using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.AccumulationFormulas
{
    class MaxMinAccumulation :AccumulatiomFormulaBase
    {
        public override double CalculateAccumulation(Stack<double> _st)
        {
            return _st.Max();
        }
    }
}
