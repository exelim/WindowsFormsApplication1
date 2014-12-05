using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.MembershipFunctions
{
    class GaussFunction : MembershipFunctionBase
    {
        public override double CalculateFunctionValue(double _val_1, double _a, double _b, double _c, double _d = 0)
        {
            return Math.Exp(Math.Pow((_val_1 - _c), 2) / ( 2 * Math.Pow(_b, 2) ) ); // _b is gamma!!
        }
    }
}
