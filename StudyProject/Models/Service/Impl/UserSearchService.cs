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
    public class UserSearchService : IUserSearchService
    {
        private static readonly string BASE_SELECT_SQL = "SELECT * FROM USER_MNG_TBL ";
        private static readonly string SQL_WHERE = "WHERE ";
        private static readonly string SQL_AND = "AND ";

        public List<UserDto> SearchUser(SearchForm searchForm)
        {
            List<UserDto> searchResultList = new List<UserDto>();
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
                string SelectSql = CreateSelectSql(searchForm);
                // 実行するSQLの準備
                OracleCommand Command = new OracleCommand(SelectSql, connection);
                
                // SQL実行
                Command.ExecuteNonQuery();

                // 検索結果の取得
                OracleDataReader DataReader = Command.ExecuteReader();
                // 検索結果をリストに格納
                while (DataReader.Read() == true)
                {
                    searchResultList.Add(
                        new UserDto()
                        {
                            UserId = DataReader["USER_ID"] as string,
                            Password = DataReader["PASSWORD"] as string,
                            UserName = DataReader["USER_NAME"] as string,
                            UserGender = DataReader["USER_GENDER"] as string,
                            RegisterDate = DataReader["REGISTER_DATE"] as string,
                            UpdateDate = DataReader["UPDATE_DATE"] as string
                        });
                }
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

            return searchResultList;
        }

        public UserDto SearchUserWithPrimaryKeyUserId(string UserId)
        {
            UserDto SearchResultUserDto = null;
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
                string SelectSql = "SELECT * FROM USER_MNG_TBL WHERE USER_ID = '" + UserId + "'";
                // 実行するSQLの準備
                OracleCommand Command = new OracleCommand(SelectSql, connection);

                // SQL実行
                Command.ExecuteNonQuery();

                // 検索結果の取得
                OracleDataReader DataReader = Command.ExecuteReader();
                if (DataReader.Read() == true)
                {
                    SearchResultUserDto = new UserDto()
                    {
                        UserId = DataReader["USER_ID"] as string,
                        Password = DataReader["PASSWORD"] as string,
                        UserName = DataReader["USER_NAME"] as string,
                        UserGender = DataReader["USER_GENDER"] as string,
                        RegisterDate = DataReader["REGISTER_DATE"] as string,
                        UpdateDate = DataReader["UPDATE_DATE"] as string
                    };
                }
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
            return SearchResultUserDto;
        }

        private string CreateSelectSql(SearchForm SearchForm)
        {
            string BaseSelectSql = "SELECT * FROM USER_MNG_TBL ";

            // 各検索条件の取得
            string UserId = SearchForm.UserId;
            string UserName = SearchForm.UserName;
            string UserGender = SearchForm.UserGender;

            bool isAddCondition = false;

            if (!string.IsNullOrEmpty(UserId))
            {
                // 検索条件.ユーザIDが入力されている場合

                isAddCondition = true;
            }

            if (isAddCondition)
            { 
            }

            return BaseSelectSql;
        }
    }
}