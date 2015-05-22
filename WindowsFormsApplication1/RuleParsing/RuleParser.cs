using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.RuleParsing
{
    using WindowsFormsApplication1.Classes;

    class RuleParser
    {
        public ProductionRule ParseRuleString(string _ruleString)
        {
            string[] temp = _ruleString.Split(' '); //size of temp should be termsCount * 3 + 3 /* and/or sumbols */ + 1 /* if symbol*/

            Dictionary<string, string> variables = new Dictionary<string, string>();

            for (int i = 0; i < temp.Length / 6; i++)
            {
                string key, value;

                key = temp[(i * 6) + 2];
                value = temp[(i * 6) + 4];
                variables.Add(key, value);
            }


            int number = ProductionRule.m_number++;
            string relation = temp[4];
            RelationType type = new RelationType();
            switch (relation)
            {
                case "AND":
                    type = RelationType.AND;
                    break;
                case "OR":
                    type = RelationType.OR;
                    break;
            }
            ProductionRule pr = new ProductionRule(temp.Length / 4, type, variables);

            return pr;
        }
    }
}
