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
using WindowsFormsApplication1.Classes.Formulas.FuzzificationFormulas;

namespace WindowsFormsApplication1
{
    public partial class ProductionRulesInputForm : Form
    {
        public static ProductionRule[] prodcutionsRules;
        public static Tuple<string, string, double>[] fuzzification_1_Values;   //  < linguistick variable id, term id, fuzzification value>
        public static Dictionary<String, Stack<double>> aggregationValues;
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
            Fuzzification_1();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Fuzzification_1()
        { 
            fuzzification_1_Values = new Tuple<string,string,double>[Form1.fullTermsCount - 1 /* 1 of temrs is OUT*/]; // < linguistick variable id, term id, fuzzification value>
            MembershipFunctionBase mf = new TriangleFunction(0.5, 2, 3); // TODO: use real membership function

            FuzzificationValues( mf, fuzzification_1_Values);


            Aggregation();
        }

        public void FuzzificationValues(MembershipFunctionBase _mf, Tuple< string, string, double >[] _tp)
        {
            for( int j = 0; j < Form1.lexicalVariables.Length; j++)
            {
                for( int k = 0; k < Form1.lexicalVariables[j].m_termsCount; k++ )
                {
                    if (Form1.lexicalVariables[j].m_type != VariableType.OUT)
                    {
                       // _tp[j] = Tuple.Create(Form1.lexicalVariables[j].m_id, Form1.lexicalVariables[j].m_terms[k].m_ID, _mf.CalculateFunctionValue(InputVariablesForm.inputVariables[j]));
                    }
                }
            }
        }

        public void Aggregation()
        {
            AggregationFormulaBase aggrBase = new MaxMinAggregation(); // TODO: use real agregation function

            activisationValues = new Stack<double>();

            aggregationValues = new Dictionary<string, Stack<double>>();
                 
            Stack< double > values = new Stack<double>();

            int i = 0;

            foreach (var item in prodcutionsRules)
            {
                String agrValueKey;
                foreach (var pair in item.m_variables)
                {
                    foreach (var fuz in fuzzification_1_Values)
                    {
                        if (fuz.Item1.Equals(pair.Key) && fuz.Item3 > 0.0)
                        {
                            values.Push(fuz.Item3);
                            agrValueKey = item.m_variables.ElementAt(item.m_variables.Values.Count - 1).Key;
                            if (!aggregationValues.ContainsKey(agrValueKey))
                            {
                                aggregationValues.Add(agrValueKey, new Stack<double>());
                                aggregationValues[agrValueKey].Push( AggregationValues(aggrBase, values));
                            }
                            else 
                            {
                                aggregationValues[agrValueKey].Push(AggregationValues(aggrBase, values));
                            }
                        }
                    }
                }
            }

            ActivisationPhase();
        }

        public void ActivisationPhase()
        {
            ActivisationFormulaBase actBase = new MinActivisation(); // TODO: use real activisation function

            foreach (var item in aggregationValues)
            {
                foreach (var val in item.Value)
                {
                    if (val > 0)
                    {
                        double minValue = 0, maxValue = 0;
                        foreach (var lv in Form1.lexicalVariables)
                        {
                            if (lv.m_type == VariableType.OUT && lv.m_id == item.Key)
                            {
                                minValue = lv.m_minValue;
                                maxValue = lv.m_maxValue;
                            }
                        }
                        MembershipFunctionBase _mf = new TriangleFunction(minValue, (minValue + maxValue) / 2, maxValue); // TODO: use real membership function
                      //  double _funcVal = _mf.CalculateFunctionValue(val);
                      //  activisationValues.Push(ActivisationValues(actBase, _funcVal, val));
                    }
                }
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
