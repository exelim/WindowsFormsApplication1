using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Structures
{
    public struct ProductionRulesTerm
    {
        public string m_ID;
        string m_name;
        int m_minValue;
        int m_maxValue;

        public ProductionRulesTerm(string _ID, string _name, int _minValue, int _maxValue)
        {
            m_ID = _ID;
            m_name = _name;
            m_minValue = _minValue;
            m_maxValue = _maxValue;
        }
    }
}
