using Oracle.ManagedDataAccess.Client;
using StudyProject.Controllers.Form;
using StudyProject.Models.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace StudyProject.Models.Service.Impl
{
    public class UserRegisterService : IUserRegisterService
    {
        public void RegisterUser(RegisterForm RegisterForm)
        {
            // 既に登録済みのデータか確認
            UserSearchService SeatchService = new UserSearchService();
            UserDto UserInfoDto = SeatchService.SearchUserWithPrimaryKeyUserId(RegisterForm.UserId);

            if (UserInfoDto != null)
            {
                // ユーザ情報が存在する場合
                return;
            }

            OracleConnection connection = null;
            try
            {                
                // 接続文字列の取得(Web.configから取得)
                string connectionString = ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;
                // DB接続の準備
                connection = new OracleConnection(connectionString);
                // DB接続開始
                connection.Open();

                // SQL生成
                string RegisterSql = "INSERT ";
                // 実行するSQLの準備
                OracleCommand Command = new OracleCommand(RegisterSql, connection);

                // SQL実行
                Command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                // DB接続終了
                connection.Close();
                connection.Dispose();
            }


        }
    }
}