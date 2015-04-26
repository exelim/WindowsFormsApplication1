using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.MembershipFunctions
{
    class SigmoidFunction : MembershipFunctionBase
    {
        public SigmoidFunction(double _a, double _b, double _c, double _d)
        {
            a = _a;
            b = _b;
            c = _c;
            d = _d;
        }
        public override double CalculateFunctionValue(double _val_1/*, double _a, double _b, double _c, double _d = 0*/)
        {
            return 1 / (1 + ( Math.Pow( Math.Exp(1), ( -a * ( _val_1 - c ) ) ) ) );
        }
    }
}
