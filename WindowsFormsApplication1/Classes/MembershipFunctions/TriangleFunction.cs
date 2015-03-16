using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.MembershipFunctions
{
    class TriangleFunction : MembershipFunctionBase
    {
        public TriangleFunction(double _a, double _b, double _c = 0, double _d = 0)
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
                return 0.0;
            }
            else if (a <= _val_1 && _val_1 <= b)
            {
                return (_val_1 - a) / (b - a);
            }
            else if (b <= _val_1 && _val_1 <= c)
            {
                return (c - _val_1) / (c - b);
            }
            else if (c <= _val_1)
            {
                return 0.0;
            }
            else
                return -1;
        }
    }
}
