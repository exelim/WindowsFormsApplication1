using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.ActivisationFormulas
{
    abstract class ActivisationFormulaBase
    {
        public abstract double CalculateActivisation( double _c, double _val_1 );
    }
}
