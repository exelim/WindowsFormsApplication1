﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Structures
{
    public struct ProductionRulesTerm
    {
        public string m_ID;
        public string m_name;
        public int m_minValue;
        public int m_maxValue;

        public ProductionRulesTerm(string _ID, string _name, int _minValue, int _maxValue)
        {
            m_ID = _ID;
            m_name = _name;
            m_minValue = _minValue;
            m_maxValue = _maxValue;
        }
    }
}
