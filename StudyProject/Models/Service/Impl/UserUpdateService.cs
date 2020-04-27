using Oracle.ManagedDataAccess.Client;
using StudyProject.Controllers.Form;
using StudyProject.Models.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudyProject.Models.Service.Impl
{
    public class UserUpdateService : IUserUpdateService
    {
        /// <summary>
        /// ユーザ情報更新
        /// </summary>
        /// <param name="EditForm"></param>
        public void UpdateUserWithPrimaryKey(EditForm EditForm)
        {
            // ユーザ情報が存在することを確認
            UserSearchService SearchService = new UserSearchService();
            UserDto UserInfoDto = SearchService.SearchUserWithPrimaryKeyUserId(EditForm.UserId);

            if (UserInfoDto == null)
            {
                // ユーザ情報が存在しない場合
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
                // トランザクション開始
                OracleTransaction Transaction = Connection.BeginTransaction();

                // SQL生成
                string UpdateSql = "UPDATE USER_MNG.USER_MNG_TBL SET USER_NAME = :USER_NAME, USER_GENDER = :USER_GENDER, UPDATE_PROG_ID = :UPDATE_PROG_ID, UPDATE_USER_ID = :UPDATE_USER_ID, UPDATE_DATE = :UPDATE_DATE "
                                   + "WHERE USER_ID = :USER_ID";
                // 実行するSQLの準備
                OracleCommand Command = new OracleCommand(UpdateSql, Connection);
                // パラメータ値の設定
                Command.Parameters.Add(new OracleParameter(":USER_NAME", EditForm.UserName));
                Command.Parameters.Add(new OracleParameter(":USER_GENDER", EditForm.UserGender));
                Command.Parameters.Add(new OracleParameter(":UPDATE_PROG_ID", "UPDATE"));
                Command.Parameters.Add(new OracleParameter(":UPDATE_USER_ID", EditForm.UserId));
                Command.Parameters.Add(new OracleParameter(":UPDATE_DATE", DateTime.Now));
                Command.Parameters.Add(new OracleParameter(":USER_ID", EditForm.UserId));
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