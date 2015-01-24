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

namespace WindowsFormsApplication1
{
    public partial class ProductionRulesInputForm : Form
    {
        public static ProductionRule[] prodcutionsRules;

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
                rp.ParseRuleString(lines[i]);
            }
            this.Close();
        }
    }
}
