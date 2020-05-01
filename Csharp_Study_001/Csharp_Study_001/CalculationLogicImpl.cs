using Csharp_Study_001.Factory;
using Csharp_Study_001.work;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp_Study_001
{
    class CalculationLogicImpl : ICalculationLogic
    {
        Hashtable Calculators = new Hashtable
        {
            [Operation.PLUS]        = Type.GetType("AddClass"),
            [Operation.MINUS]       = Type.GetType("AddClass"),
            [Operation.DIVIDE]      = Type.GetType("AddClass"),
            [Operation.MULTIPLY]    = Type.GetType("AddClass")
        };


        string ICalculationLogic.Calculate(Operation ope)
        {
            ICalc icalc = Calculators[ope.ArithmaticOperations];

            throw new NotImplementedException();
        }
    }


    class AddClass : ICalc
    {
        private decimal left;
        private decimal right;
        public AddClass(Operation ope)
        {
            this.left = ope.left;
            this.right = ope.right;
        }
        public string Calculate()
        {
            return decimal.Add(left, right).ToString();
        }
    }
}
