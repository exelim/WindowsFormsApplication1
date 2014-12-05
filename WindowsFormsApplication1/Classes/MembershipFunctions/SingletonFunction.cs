using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.MembershipFunctions
{
    class SingletonFunction : MembershipFunctionBase
    {
        public override double CalculateFunctionValue(double _val_1, double _a, double _c, double _b, double _d = 0)
        {
            if (_val_1 == _a)
                return 1;
            else
                return 0;
        }
    }
}
