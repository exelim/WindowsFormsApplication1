using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.FuzzificationFormulas
{
    abstract class FuzzificationFormulaBase
    {
        public abstract double CalculateFuzzification(double _val_1, double _val_2);
    }
}
