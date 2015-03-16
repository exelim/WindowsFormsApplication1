using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes
{
    using WindowsFormsApplication1.Structures;

    public class LexicalVariable
    {
        public string                   m_id;          //  { get { return m_id; } set { m_id = value; } }
        public string                   m_name;        //  { get { return m_name; } set { m_name = value; } }
        public int                      m_minValue;    //  { get { return m_minValue; } set { m_minValue = value; } }
        public int                      m_maxValue;     // { get { return m_maxValue; } set { m_maxValue = value; } }
        public int                      m_termsCount;  // { get { return m_termsCount; } set { m_termsCount = value; } }
        public ProductionRulesTerm[]    m_terms;       //  { get { return m_terms; } set { m_terms = value; } }
        public VariableType             m_type;        //  { get { return m_type; } set { m_type = value; } }

        public LexicalVariable(string _id, string _name, int _minValue, int _maxValue, int _temrsCount, ProductionRulesTerm[] _terms, VariableType _variableType)
        {
            m_id            = _id;
            m_name          = _name;
            m_minValue      = _minValue;
            m_maxValue      = _maxValue;
            m_termsCount    = _temrsCount;
            m_type          = _variableType;
            m_terms         = new ProductionRulesTerm[m_termsCount];
            m_terms         = _terms;

        }
    }
}
