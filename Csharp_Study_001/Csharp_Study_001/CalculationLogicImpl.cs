using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Study_001
{
    class CalculationLogicImpl : CalculationLogic
    {
        public string calcAddition(string leftNum, string rigthNum)
        {
            // 数値をDecimal型に変換
            decimal decLeftNum = decimal.Parse(leftNum);
            decimal decRigthNum = decimal.Parse(rigthNum);
            // 足し算実施
            decimal result = decimal.Add(decLeftNum, decRigthNum);
            return result.ToString();
        }

        public string calcSubtraction(string leftNum, string rigthNum)
        {
            // 数値をDecimal型に変換
            decimal decLeftNum = decimal.Parse(leftNum);
            decimal decRigthNum = decimal.Parse(rigthNum);
            // 引き算実施
            decimal result = decimal.Subtract(decLeftNum, decRigthNum);
            return result.ToString();
        }

        public string calcMultiplication(string leftNum, string rigthNum)
        {
            // 数値をDecimal型に変換
            decimal decLeftNum = decimal.Parse(leftNum);
            decimal decRigthNum = decimal.Parse(rigthNum);
            // 掛け算実施
            decimal result = decimal.Multiply(decLeftNum, decRigthNum);
            return result.ToString();
        }

        public string calcDivision(string leftNum, string rigthNum)
        {
            // 数値をDecimal型に変換
            decimal decLeftNum = decimal.Parse(leftNum);
            decimal decRigthNum = decimal.Parse(rigthNum);
            // 割り算実施
            decimal result = decimal.Divide(decLeftNum, decRigthNum);
            return result.ToString();
        }
    }
}
