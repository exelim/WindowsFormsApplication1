﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes.MembershipFunctions
{
    public class GaussFunction : MembershipFunctionBase
    {
        public GaussFunction(double _a, double _b, double _c, double _d)
        {
            a = _a;
            b = _b;
            c = _c;
            d = _d;
        }
        public override double CalculateFunctionValue(double _val_1)
        {
            return Math.Exp(Math.Pow((_val_1 - c), 2) / ( 2 * Math.Pow(b, 2) ) ); // _b is gamma!!
        }
    }
}
