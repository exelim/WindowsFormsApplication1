using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.ActivisationFormulas
{
    class ProdActivisation : ActivisationFormulaBase
    {
        public override double CalculateActivisation(double _c, double _val_1)
        {
            return _c * _val_1;
        }
    }
}
