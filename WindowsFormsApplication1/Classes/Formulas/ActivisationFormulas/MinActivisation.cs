using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.ActivisationFormulas
{
    class MinActivisation : ActivisationFormulaBase
    {
        public override double CalculateActivisation(double _c, double _val_1)
        {
            return Math.Min(_c, _val_1);
        }
    }
}
