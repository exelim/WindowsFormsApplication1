using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.AggregationFormulas
{
    class LimitedAggregation : AggregationFormulaBase
    {
        RelationType m_type;

        public override double CalculateAggregation(Stack<double> st, RelationType _type)
        {
            double returnValue = 0.0;
            switch (_type)
            { 
                case RelationType.OR:
                    returnValue = Math.Min(1, st.Sum());
                    break;

                case RelationType.AND:
                    returnValue = Math.Max( 0, st.Sum() - 1 );
                    break;

                default:
                    returnValue = 0.0; // should be never reached!!!
                    break;
            }

            return returnValue;
        }
    }
}
