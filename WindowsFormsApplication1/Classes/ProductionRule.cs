using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes
{
    class ProductionRule
    {
        public static int           m_number = 0;
        int                         m_termsCount;
        RelationType                m_type;
        Dictionary<string, string>  m_variables;

        public ProductionRule(int _termsCount, RelationType _type, Dictionary<string, string> _variables)
        {
            m_termsCount    = _termsCount;
            m_type          = _type;
            m_variables     = _variables;
        }
    }
}
