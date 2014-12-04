using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Classes
{
    using WindowsFormsApplication1.Structures;

    class LexicalVariable
    {
        private string                  m_id            { get; set; }
        private string                  m_name          { get; set; }
        private int                     m_minValue      { get; set; }
        private int                     m_maxValue      { get; set; }
        private int                     m_termsCount    { get; set; }
        private ProductionRulesTerm[]   m_terms         { get; set; }
        private VariableType            m_type          { get; set; }

        public LexicalVariable(string _id, string _name, int _minValue, int _maxValue, int _temrsCount, VariableType _variableType)
        {
            m_id            = _id;
            m_name          = _name;
            m_minValue      = _minValue;
            m_maxValue      = _maxValue;
            m_termsCount    = _temrsCount;
            m_type          = _variableType;
        }
    }
}
