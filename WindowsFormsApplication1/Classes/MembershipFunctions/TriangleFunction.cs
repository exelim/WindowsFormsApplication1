using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.MembershipFunctions
{
    class TriangleFunction : MembershipFunctionBase
    {
        public override double CalculateFunctionValue(double _val_1, double _a, double _c, double _b)
        {
            if (_val_1 <= _a)
            {
                return 0.0;
            }
            else if (_a <= _val_1 && _val_1  <= _b)
            {
                return (_val_1 - _a) / (_b - _a);
            }
            else if ( 
        }
    }
}
