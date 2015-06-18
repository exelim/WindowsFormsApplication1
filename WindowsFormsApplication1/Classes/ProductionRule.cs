using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes
{
    public class ProductionRule
    {
        public static int                   m_number = 0;
        public int                          m_termsCount;
        public RelationType                 m_type;
        public Dictionary<string, string>   m_variables;
        public string                       m_asString;

        public ProductionRule(int _termsCount, RelationType _type, Dictionary<string, string> _variables, string _asString)
        {
            m_termsCount    = _termsCount;
            m_type          = _type;
            m_variables     = _variables;
            m_asString      = _asString;
        }
    }
}
