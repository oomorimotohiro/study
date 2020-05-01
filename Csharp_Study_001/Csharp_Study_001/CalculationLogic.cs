using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Study_001
{
    interface CalculationLogic
    {
        string calcAddition(string leftNum, string rigthNum);

        string calcSubtraction(string leftNum, string rigthNum);

        string calcMultiplication(string leftNum, string rigthNum);

        string calcDivision(string leftNum, string rigthNum);
    }
}
