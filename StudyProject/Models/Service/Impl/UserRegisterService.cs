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
            UserSearchService SearchService = new UserSearchService();
            UserDto UserInfoDto = SearchService.SearchUserWithPrimaryKeyUserId(RegisterForm.UserId);

            if (UserInfoDto != null)
            {
                // ユーザ情報が存在する場合
                return;
            }

            OracleConnection Connection = null;
            try
            {                
                // 接続文字列の取得(Web.configから取得)
                string ConnectionString = ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;
                // DB接続の準備
                Connection = new OracleConnection(ConnectionString);
                // DB接続開始
                Connection.Open();

                // SQL生成
                string RegisterSql = "INSERT INTO USER_MNG.USER_MNG_TBL(USER_ID, PASSWORD, USER_NAME, USER_GENDER, REGISTER_PROG_ID, REGISTER_USER_ID, REGISTER_DATE, UPDATE_PROG_ID, UPDATE_USER_ID, UPDATE_DATE) "
                                   + "VALUES (:USER_ID, :PASSWORD, :USER_NAME, :USER_GENDER, :REGISTER_PROG_ID, :REGISTER_USER_ID, :REGISTER_DATE, :UPDATE_PROG_ID, :UPDATE_USER_ID, :UPDATE_DATE)";
                // 実行するSQLの準備
                OracleCommand Command = new OracleCommand(RegisterSql, Connection);
                Command.Parameters.Add(new OracleParameter(":USER_ID", RegisterForm.UserId));
                Command.Parameters.Add(new OracleParameter(":PASSWORD", RegisterForm.Password));
                Command.Parameters.Add(new OracleParameter(":USER_NAME", RegisterForm.UserName));
                Command.Parameters.Add(new OracleParameter(":USER_GENDER", RegisterForm.UserGender));
                Command.Parameters.Add(new OracleParameter(":REGISTER_PROG_ID", "REGISTER"));
                Command.Parameters.Add(new OracleParameter(":REGISTER_USER_ID", RegisterForm.UserId));
                Command.Parameters.Add(new OracleParameter(":REGISTER_DATE", DateTime.Now));
                Command.Parameters.Add(new OracleParameter(":UPDATE_PROG_ID", "REGISTER"));
                Command.Parameters.Add(new OracleParameter(":UPDATE_USER_ID", RegisterForm.UserId));
                Command.Parameters.Add(new OracleParameter(":UPDATE_DATE", DateTime.Now));

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
                Connection.Close();
                Connection.Dispose();
            }
        }
    }
}