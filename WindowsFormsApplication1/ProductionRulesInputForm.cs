using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.RuleParsing;
using WindowsFormsApplication1.Classes;
using WindowsFormsApplication1.Classes.Formulas.AggregationFormulas;
using WindowsFormsApplication1.Classes.Formulas.ActivisationFormulas;
using WindowsFormsApplication1.Classes.Formulas.AccumulationFormulas;
using WindowsFormsApplication1.Classes.MembershipFunctions;

namespace WindowsFormsApplication1
{
    public partial class ProductionRulesInputForm : Form
    {
        public static ProductionRule[] prodcutionsRules;
        public static Tuple<string, string, double>[] fuzzification_1_Values;
        public static double[] aggregationValues;
        public static Stack<double> activisationValues;

        public ProductionRulesInputForm()
        {
            InitializeComponent();
            string careMessage;
            careMessage = "Please, be carefull entering production rules!!! You should use template as the example below:";
            careMessage += "\n\n                                         If X1 is 10 and X2 is 30 THEN Y is 23" + " etc.\n\n";
            careMessage += "Where:\n";
            careMessage += "    X1,X2       - input variables ID;\n";
            careMessage += "    Y              - input variable ID;\n";
            careMessage += "    10,30,23   - variables value;\n\n";
            careMessage += "Please note that the ID value should be the same as you set to linguistic variables before!";

            MessageBox.Show( careMessage );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lines = prodRulesTB.Text.Split('\n');
            prodcutionsRules = new ProductionRule[lines.Length];
            RuleParser rp = new RuleParser();
            for (int i = 0; i < lines.Length; i++)
            {
                prodcutionsRules[i] = rp.ParseRuleString(lines[i]);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Fuzzification_1()
        { 
            fuzzification_1_Values = new Tuple<string,string,double>[Form1.fullTermsCount];
            /*
             TODO: Fill it!!!  
            */
            Aggregation();
        }

        public void Aggregation()
        {
            AggregationFormulaBase aggrBase = new MaxMinAggregation(); 
            
            MembershipFunctionBase memBase = new TriangleFunction();

            aggregationValues = new double[Form1.fullTermsCount];
            activisationValues = new Stack<double>();
                 
            Stack< double > values = new Stack<double>();

            int i = 0;

            foreach (var item in prodcutionsRules)
            {
                foreach (var pair in item.m_variables)
                {
                    foreach (var fuz in fuzzification_1_Values)
                    {
                        if (fuz.Item1.Equals(pair.Key) && fuz.Item2.Equals(pair.Value))
                            values.Push( fuz.Item3 );
                    }
                }
                i++;
                aggregationValues[i] = AggregationValues(aggrBase, values);
            }

            ActivisationPhase();
        }

        public void ActivisationPhase()
        {
            ActivisationFormulaBase actBase = new MinActivisation();

            foreach (var item in aggregationValues)
            {
                if (item > 0)
                    activisationValues.Push(ActivisationValues(actBase, 1.0, item)); // 1.0 ?????????????????????
            }
        }

        public void AccumulationPhase()
        {
            AccumulatiomFormulaBase accBase = new MaxMinAccumulation();

            double res = AccumulationValues(accBase, activisationValues);

        }

        public double AggregationValues(AggregationFormulaBase _af, Stack<double> _st)
        {
            return _af.CalculateAggregation(_st);
        }

        public double ActivisationValues(ActivisationFormulaBase _af, double _c, double _val1)
        {
            return _af.CalculateActivisation(_c, _val1);
        }

        public double AccumulationValues(AccumulatiomFormulaBase _af, Stack<double> _st)
        {
            return _af.CalculateAccumulation(_st);
        }
    }
}
