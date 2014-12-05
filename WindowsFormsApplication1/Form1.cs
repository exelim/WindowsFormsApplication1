using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsApplication1.Classes;
using WindowsFormsApplication1.Structures;

namespace WindowsFormsApplication1
{
    enum VariableType { IN, OUT };
    enum RelationType { AND, OR };

    public partial class Form1 : Form
    {
        public int lexicalVariablesCount;

        public Form1()
        {
            InitializeComponent();
        }
    }
}
