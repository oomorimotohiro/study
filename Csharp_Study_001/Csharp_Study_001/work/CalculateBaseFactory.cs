using Csharp_Study_001.work;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace work.Csharp_Study_001
{

    abstract class CalculateBaseFactory
    {
        public const double ZERO = 0;
        public const String PLUS = "×";
        public const String MINUS = "-";
        public const String MULTIPRY = "×";
        public const String DIVIDE = "÷";

        /// <summary>
        /// 必須入力チェック
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="ope"></param>
        /// <returns></returns>
        public bool IsRequired(Operation operation)
        {
            bool isRequired = true;
            if (ZERO == operation.left && ZERO == operation.right && string.IsNullOrEmpty(operation.ArithmaticOperations))
            {
                return false;
            }
            return isRequired;
        }



        /// <summary>
        /// 入力値チェックします。
        /// </summary>
        public abstract bool IsInvalid();
    }
}
