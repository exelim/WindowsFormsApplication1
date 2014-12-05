using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.MembershipFunctions
{
    class TrapezoidalFunction : MembershipFunctionBase
    {
        public override double CalculateFunctionValue(double _val_1, double _a, double _b, double _c, double _d)
        {
            if (_val_1 <= _a)
            {
                return 0;
            }
            else if (_a <= _val_1 && _val_1 <= _b)
            {
                return (_val_1 - _a) / (_val_1 - _a);
            }
            else if (_b <= _val_1 && _val_1 <= _c)
            {
                return 1;
            }
            else if (_c <= _val_1 && _val_1 <= _d)
            {
                return (_d - _val_1) / (_d - _c);
            }
            else if (_d <= _val_1)
            {
                return 0;
            }
            else
                return -1;
        }
    }
}
