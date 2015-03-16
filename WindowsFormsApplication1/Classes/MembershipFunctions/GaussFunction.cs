using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.MembershipFunctions
{
    public class GaussFunction : MembershipFunctionBase
    {
        public GaussFunction(double _a, double _b, double _c = 0, double _d = 0)
        {
            a = _a;
            b = _b;
            c = _c;
            d = _d;
        }
        public override double CalculateFunctionValue(double _val_1/*, double _a, double _b, double _c, double _d*/)
        {
            return Math.Exp(Math.Pow((_val_1 - a), 2) / ( 2 * Math.Pow(b, 2) ) ); // _b is gamma && _a is C!!
        }
    }
}
