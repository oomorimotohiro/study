using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Study_001.Factory
{
    class Operation
    {
        public const string PLUS = "+";
        public const string MINUS = "-";
        public const string DIVIDE = "÷";
        public const string MULTIPLY = "×";

        private decimal left1 = 0;
        private decimal right1 = 0;

        public Operation(string ope, decimal left, decimal right)
        {
            this.ArithmaticOperations = ope;
            this.left = left;
            this.right = right;
        }

        public string ArithmaticOperations { get; set; }
        public decimal left { get => left1; set => left1 = value; }
        public decimal right { get => right1; set => right1 = value; }
    }
}
