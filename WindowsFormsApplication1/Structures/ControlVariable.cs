using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Structures
{
    struct ControlVariable
    {
        string          m_id;
        int             m_value;
        VariableType    m_type;

        public ControlVariable(string _id, int _value, VariableType _variableType)
        {
            m_id = _id;
            m_value = _value;
            m_type = _variableType;
        }
    }
}
