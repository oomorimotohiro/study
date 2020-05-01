using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Csharp_Study_001
{
    public partial class Main : Form
    {
        private const string ERROR_MESSAGE_INPUT_VAL_EMPTY = "値を入力してください";
        private const string ERROR_MESSAGE_INPUT_VAL_NON_NUM = "数値を入力してください";
        private const string ERROR_MESSAGE_INPUT_VAL_OPE = "演算子を選択してください";
        private const string ERROR_MESSAGE_INVALID_FORMULA = "不正な式です";

        private const string NUM_0 = "0";

        private static string tasu = "＋";
        private static string hiku = "－";
        private static string kake = "×";
        private static string waru = "÷";
            
        public Main()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 計算ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calc_Click(object sender, EventArgs e)
        {
            // 入力値の取得
            string leftNum = left.Text;
            string rigthNum = right.Text;
            string opeSignal = ope.Text;
            //　入力値チェック
            if (!CheckInputValue(leftNum, rigthNum, opeSignal)) 
            {
                // 入力チェックエラーの場合、処理中断
                return;
            }

            // 式の不正チェック
            if (!IsInvalidFormula(rigthNum, opeSignal)) 
            {
                // 不正な式の場合、処理中断
                return;
            }

            CalculationLogicImpl calc = new CalculationLogicImpl();
            string result = null;
            // 計算実施
            if (tasu.Equals(opeSignal))
            {
                // 足し算
                result = calc.calcAddition(leftNum, rigthNum);
            }
            else if (hiku.Equals(opeSignal))
            {
                // 引き算
                result = calc.calcSubtraction(leftNum, rigthNum);
            }
            else if (kake.Equals(opeSignal))
            {
                // 掛け算
                result = calc.calcMultiplication(leftNum, rigthNum);
            }
            else if (waru.Equals(opeSignal))
            {
                // 割り算
                result = calc.calcDivision(leftNum, rigthNum);
            }

            // 計算結果を表示
            ShowInfoMsg(result);
        }

        private bool CheckInputValue(string leftNum, string rigthNum, string opeSignal) 
        {
            // ①Nullチェック
            if (IsEmpty(leftNum) || IsEmpty(rigthNum))
            {
                // エラーメッセージ出力
                ShowErrMsg(ERROR_MESSAGE_INPUT_VAL_EMPTY);
                return false;
            }

            // ②数値チェック
            if (!IsNumber(leftNum) || !IsNumber(rigthNum)) 
            {
                // エラーメッセージ出力
                ShowErrMsg(ERROR_MESSAGE_INPUT_VAL_NON_NUM);
                return false;
            }

            // ③演算子の確認
            if (IsEmpty(opeSignal)) 
            {
                // エラーメッセージ出力
                ShowErrMsg(ERROR_MESSAGE_INPUT_VAL_OPE);
                return false;
            }

            return true;
        }

        private bool IsEmpty(string number) 
        {
            return string.IsNullOrEmpty(number);
        }

        private bool IsNumber(string strNum)
        {
            return Regex.IsMatch(strNum, @"^\d+$");
        }

        private bool IsInvalidFormula(string rigthNum, string opeSignal) 
        {
            // 0除算の式かどうかチェック
            if (NUM_0.Equals(rigthNum) && waru.Equals(opeSignal)) 
            {
                // エラーメッセージ出力
                ShowErrMsg(ERROR_MESSAGE_INVALID_FORMULA); 
                return false;
            }

            return true;
        }


        /// <summary>
        /// 通知ダイアログ表示
        /// </summary>
        /// <param name="message">メッセージ</param>
        private void ShowInfoMsg(string message)
        {
            MessageBox.Show(message,
                            "計算結果",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// エラーダイアログ表示
        /// </summary>
        /// <param name="message">メッセージ</param>
        private static void ShowErrMsg(string message)
        {
            MessageBox.Show(message,
                            "計算失敗",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
        }

        private void ope_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
