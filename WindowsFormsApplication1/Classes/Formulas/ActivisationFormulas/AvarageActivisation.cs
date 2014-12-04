using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.ActivisationFormulas
{
    class AvarageActivisation : ActivisationFormulaBase
    {
        public override double CalculateActivisation(double _c, double _val_1)
        {
            return 0.5 * (_c + _val_1);
        }
    }
}
