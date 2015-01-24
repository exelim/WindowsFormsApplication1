using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.AccumulationFormulas
{
    abstract class AccumulatiomFormulaBase
    {
        public abstract double CalculateAccumulation( Stack<double > _st );
    }
}
