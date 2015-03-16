using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.MembershipFunctions
{
    class SingletonFunction : MembershipFunctionBase
    {
        public SingletonFunction(double _a, double _b, double _c, double _d)
        {
            a = _a;
            b = _b;
            c = _c;
            d = _d;
        }
        public override double CalculateFunctionValue(double _val_1/*, double _a, double _c, double _b, double _d = 0*/)
        {
            if (_val_1 == a)
                return 1;
            else
                return 0;
        }
    }
}
