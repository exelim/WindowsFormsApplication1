using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.AggregationFormulas
{
    abstract public class AggregationFormulaBase
    {
        public abstract double CalculateAggregation( Stack< double > st );
    }
}
