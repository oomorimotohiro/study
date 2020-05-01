using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work.Csharp_Study_001;

namespace Csharp_Study_001.work
{
    /// <summary>
    /// 計算元クラス
    /// </summary>
    public class Operation
    {
        private double left1 = CalculateBaseFactory.ZERO;
        private double right1 = CalculateBaseFactory.ZERO;

        public Operation(string ope, double left, double right)
        {
            this.ArithmaticOperations = ope;
            this.left = left;
            this.right = right;
        }

        public string ArithmaticOperations { get; set; }
        public double left { get => left1; set => left1 = value; }
        public double right { get => right1; set => right1 = value; }
    }
}
