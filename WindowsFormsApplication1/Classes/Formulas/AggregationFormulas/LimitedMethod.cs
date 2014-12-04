using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.Formulas.AggregationFormulas
{
    class LimitedMethod : AggregationFormulaBase
    {
        RelationType m_type;

        public override double CalculateAggregation(double _val_1, double _val_2)
        {
            double returnValue = 0.0;
            switch (m_type)
            { 
                case RelationType.OR:
                    returnValue = Math.Min(1, _val_1 + _val_2);
                    break;

                case RelationType.AND:
                    returnValue = Math.Max( 0, _val_1 + _val_2 - 1 );
                    break;

                default:
                    returnValue = 0.0; // should be never reached!!!
                    break;
            }

            return returnValue;
        }
    }
}
