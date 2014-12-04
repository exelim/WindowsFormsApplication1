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
        public ProductionRule ParseRule(string _ruleString)
        {
            string[] temp = _ruleString.Split(' '); //size of temp should be termsCount * 3 + 3 /* and/or sumbols */ + 1 /* if symbol*/
            
            for( int i = 0; i < temp.Length; i++ )
            {
                string key, value;

                if( i == 1 || ( i % 4 ) == 1 )
                {
                    key = temp[i];    
                }
                else if( i == 3 || ( i % 3 ) == 1 )
            }


            int number = ProductionRule.m_number++;
            RelationType type = 
            ProductionRule pr = new ProductionRule();

            return pr;
        }
    }
}
