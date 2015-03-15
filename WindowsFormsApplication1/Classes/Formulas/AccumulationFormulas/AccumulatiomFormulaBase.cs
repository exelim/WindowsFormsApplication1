using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.AccumulationFormulas
{
    abstract public class AccumulatiomFormulaBase
    {
        public abstract double CalculateAccumulation( Stack<double > _st );
    }
}
