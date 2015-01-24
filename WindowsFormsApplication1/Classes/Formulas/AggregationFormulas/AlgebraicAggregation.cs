using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.AggregationFormulas
{
    class AlgebraicAggregation : AggregationFormulaBase
    {
        RelationType m_type;

        public override double CalculateAggregation(Stack<double> st)
        {
            double returnValue = 0.0;
            switch (m_type)
            { 
                case RelationType.OR:
                    double res = 1.0;
                    foreach (var item in st)
	                {
		                res *= item;
	                }
                    returnValue = ( st.Sum() ) - ( res );
                    break;

                case RelationType.AND:
                    double res2 = 1.0;
                    foreach (var item in st)
	                {
		                res2 *= item;
	                }
                    returnValue = res2;
                    break;

                default:
                    returnValue = 0.0; // should be never reached!!!
                    break;
            }

            return returnValue;
        }
    }
}
