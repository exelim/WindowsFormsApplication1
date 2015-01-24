using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.AggregationFormulas
{
    class MaxMinAggregation : AggregationFormulaBase
    {
        RelationType m_type;

        public override double CalculateAggregation(Stack<double> st)
        {
            double returnValue = 0.0;
            switch (m_type)
            { 
                case RelationType.OR:
                    returnValue = st.Max();
                    break;

                case RelationType.AND:
                    returnValue = st.Min();
                    break;

                default:
                    returnValue = 0.0; // should be never reached!!!
                    break;
            }

            return returnValue;
        }
    }
}
