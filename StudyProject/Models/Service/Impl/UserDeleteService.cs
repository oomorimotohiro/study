using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudyProject.Models.Service.Impl
{
    public class UserDeleteService : IUserDeleteService
    {
        public void DeleteUserWithPrimaryKeyUserId(string DelteUserId)
        {
            OracleConnection Connection = null;
            try
            {
                // 接続文字列の取得(Web.configから取得)
                string ConnectionString = ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;
                // DB接続の準備
                Connection = new OracleConnection(ConnectionString);
                // DB接続開始
                Connection.Open();
                // トランザクション開始
                OracleTransaction Transaction = Connection.BeginTransaction();

                // SQL生成
                string DeleteSql = "DELETE FROM USER_MNG.USER_MNG_TBL WHERE USER_ID = :USER_ID";
                // 実行するSQLの準備
                OracleCommand Command = new OracleCommand(DeleteSql, Connection);
                // パラメータ値の設定
                Command.Parameters.Add(new OracleParameter(":USER_ID", DelteUserId));

                // SQL実行
                Command.ExecuteNonQuery();

                Transaction.Commit();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                // DB接続終了
                Connection.Close();
                Connection.Dispose();
            }
        }
    }
}