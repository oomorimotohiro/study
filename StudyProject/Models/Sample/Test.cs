using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudyProject.Models.Service.Impl
{
    public class Test
    {
        public static void TestConnection() {
            // DB接続テスト
            string SelectSql = "select * from USER_MNG_TBL";


            // 接続情報の取得
            string connectionString = ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;
            // DB接続の準備
            OracleConnection connection = new OracleConnection(connectionString);
            // DB接続開始
            connection.Open();

            Console.WriteLine("DB接続成功");

            OracleCommand command = new OracleCommand(SelectSql, connection);
            // SQL実行
            command.ExecuteNonQuery();
            // 取得結果の確認
            OracleDataReader oracleDataReader = command.ExecuteReader();
            while (oracleDataReader.Read() == true)
            {
                Console.WriteLine(oracleDataReader["USER_ID"] as string);
            }


            // DB接続終了
            connection.Close();
            connection.Dispose();
            Console.WriteLine("DB接続終了");
        }
    }
}