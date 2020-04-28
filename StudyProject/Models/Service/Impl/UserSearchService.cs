using Microsoft.SqlServer.Server;
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

        private static readonly string USER_MNG_TBL_COLUMN_USER_ID = "USER_ID";
        private static readonly string USER_MNG_TBL_COLUMN_PASSWORD = "PASSWORD";
        private static readonly string USER_MNG_TBL_COLUMN_USER_NAME = "USER_NAME";
        private static readonly string USER_MNG_TBL_COLUMN_USER_GENDER = "USER_GENDER";
        private static readonly string USER_MNG_TBL_COLUMN_REGISTER_DATE = "REGISTER_DATE";
        private static readonly string USER_MNG_TBL_COLUMN_UPDATE_DATE = "UPDATE_DATE";

        public List<UserDto> SearchUser(SearchForm SearchForm)
        {
            List<UserDto> SearchResultList = new List<UserDto>();
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
                string SelectSql = CreateSelectSql(SearchForm);
                // 実行するSQLの準備
                OracleCommand Command = new OracleCommand(SelectSql, Connection);
                
                // SQL実行
                Command.ExecuteNonQuery();

                // 検索結果の取得
                OracleDataReader DataReader = Command.ExecuteReader();
                // 検索結果をリストに格納
                while (DataReader.Read() == true)
                {
                    SearchResultList.Add(
                        new UserDto()
                        {
                            UserId = DataReader[USER_MNG_TBL_COLUMN_USER_ID] as string,
                            Password = DataReader[USER_MNG_TBL_COLUMN_PASSWORD] as string,
                            UserName = DataReader[USER_MNG_TBL_COLUMN_USER_NAME] as string,
                            UserGender = DataReader[USER_MNG_TBL_COLUMN_USER_GENDER] as string,
                            RegisterDate = DataReader[USER_MNG_TBL_COLUMN_REGISTER_DATE] as string,
                            UpdateDate = DataReader[USER_MNG_TBL_COLUMN_UPDATE_DATE] as string
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
                Connection.Close();
                Connection.Dispose();
            }

            return SearchResultList;
        }

        public UserDto SearchUserWithPrimaryKeyUserId(string UserId)
        {
            UserDto SearchResultUserDto = null;
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
                string SelectSql = "SELECT * FROM USER_MNG_TBL WHERE USER_ID = :USER_ID";
                // 実行するSQLの準備
                OracleCommand Command = new OracleCommand(SelectSql, Connection);
                Command.Parameters.Add(new OracleParameter(":USER_ID", UserId));

                // SQL実行
                Command.ExecuteNonQuery();

                // 検索結果の取得
                OracleDataReader DataReader = Command.ExecuteReader();
                if (DataReader.Read() == true)
                {
                    SearchResultUserDto = new UserDto()
                    {
                        UserId = DataReader[USER_MNG_TBL_COLUMN_USER_ID] as string,
                        Password = DataReader[USER_MNG_TBL_COLUMN_PASSWORD] as string,
                        UserName = DataReader[USER_MNG_TBL_COLUMN_USER_NAME] as string,
                        UserGender = DataReader[USER_MNG_TBL_COLUMN_USER_GENDER] as string,
                        RegisterDate = DataReader[USER_MNG_TBL_COLUMN_REGISTER_DATE] as string,
                        UpdateDate = DataReader[USER_MNG_TBL_COLUMN_UPDATE_DATE] as string
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
                Connection.Close();
                Connection.Dispose();
            }
            return SearchResultUserDto;
        }

        /// <summary>
        /// 検索画面の入力値に応じてSQL文を作成する。
        /// </summary>
        /// <param name="SearchForm">検索Form</param>
        /// <returns>作成後のSQL文</returns>
        private string CreateSelectSql(SearchForm SearchForm)
        {
            // 各検索条件の取得
            Dictionary<string, string> InputParametor = new Dictionary<string, string>
            {
                { USER_MNG_TBL_COLUMN_USER_ID, SearchForm.UserId },
                { USER_MNG_TBL_COLUMN_USER_NAME, SearchForm.UserName },
                { USER_MNG_TBL_COLUMN_USER_GENDER, SearchForm.UserGender }
            };

            if (IsNullAllInputValue(InputParametor))
            {
                // 全ての入力値がNULLの場合、全件検索
                return BASE_SELECT_SQL;
            }

            string CreateSelectSql = BASE_SELECT_SQL + SQL_WHERE;

            bool IsAddConditonFlag = false;

            if (!string.IsNullOrEmpty(InputParametor[USER_MNG_TBL_COLUMN_USER_ID]))
            {
                CreateSelectSql += "USER_ID LIKE '%' || '" + InputParametor[USER_MNG_TBL_COLUMN_USER_ID] + "' || '%' ";
                IsAddConditonFlag = true;
            }

            if (!string.IsNullOrEmpty(InputParametor[USER_MNG_TBL_COLUMN_USER_NAME]))
            {
                if (IsAddConditonFlag)
                {
                    // 既に条件が追加されている場合
                    CreateSelectSql += SQL_AND;
                }
                else
                {
                    // 新規で条件を追加する場合
                    IsAddConditonFlag = true;
                }
                CreateSelectSql += "USER_NAME LIKE '%' || '" + InputParametor[USER_MNG_TBL_COLUMN_USER_NAME] + "' || '%'";
            }

            if (!string.IsNullOrEmpty(InputParametor[USER_MNG_TBL_COLUMN_USER_GENDER]))
            {
                if (IsAddConditonFlag)
                {
                    // 既に条件が追加されている場合
                    CreateSelectSql += SQL_AND;
                }
                CreateSelectSql += "USER_GENDER = '" + InputParametor[USER_MNG_TBL_COLUMN_USER_GENDER] + "'";
            }
            return CreateSelectSql;
        }

        /// <summary>
        /// 全ての入力値がNULLかどうかチェック
        /// </summary>
        /// <param name="InputParametor"></param>
        /// <returns></returns>
        private bool IsNullAllInputValue(Dictionary<string, string> InputParametor)
        {
            foreach (string InputValue in InputParametor.Values)
            {
                if (!string.IsNullOrEmpty(InputValue))
                {
                    return false;
                }
            }
            return true;
        }
    }
}