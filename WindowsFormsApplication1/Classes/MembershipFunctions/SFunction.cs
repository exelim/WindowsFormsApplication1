using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.MembershipFunctions
{
    class SFunction : MembershipFunctionBase
    {
        public SFunction(double _a, double _b, double _c, double _d)
        {
            a = _a;
            b = _b;
            c = _c;
            d = _d;
        }
        public override double CalculateFunctionValue(double _val_1/*, double _a, double _b, double _c, double _d = 0*/)
        {
            if (_val_1 < a)
            {
                return 0.0;
            }
            else if (a <= _val_1 && _val_1 <= b)
            {
                return (1.0 / 2.0) + (1.0 / 2.0) * Math.Cos(((_val_1 - b) / (b - a)) * Math.PI);
            }
            else if (_val_1 > b)
            {
                return 1.0;
            }
            else
                return -1;
        }
    }
}
