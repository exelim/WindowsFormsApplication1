using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.AccumulationFormulas
{
    class MaxMinAccumulation :AccumulatiomFormulaBase
    {
        public override double CalculateAccumulation(double _val_1, double _val_2)
        {
            return Math.Max(_val_1, _val_2);
        }
    }
}
