using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.MembershipFunctions
{
    abstract class MembershipFunctionBase
    {
        public abstract double CalculateFunctionValue( double _val_1, double _a, double _c, double _b );
    }
}
