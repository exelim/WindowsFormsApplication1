using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.MembershipFunctions
{
    class TrapezoidalFunction : MembershipFunctionBase
    {
        public TrapezoidalFunction(double _a, double _b, double _c, double _d)
        {
            a = _a;
            b = _b;
            c = _c;
            d = _d;
        }

        public override double CalculateFunctionValue(double _val_1/*, double _a, double _b, double _c, double _d*/)
        {
            if (_val_1 <= a)
            {
                return 0;
            }
            else if (a <= _val_1 && _val_1 <= b)
            {
                return (_val_1 - a) / (_val_1 - a);
            }
            else if (b <= _val_1 && _val_1 <= c)
            {
                return 1;
            }
            else if (c <= _val_1 && _val_1 <= d)
            {
                return (d - _val_1) / (d - c);
            }
            else if (d <= _val_1)
            {
                return 0;
            }
            else
                return -1;
        }
    }
}
