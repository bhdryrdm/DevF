using Dapper;
using System;

namespace DevF_LABS.Test.DBConnection
{
    public class RunQuery : BaseConnection
    {
        public override void ConnectionDB(string sql_Query, string connectionString)
        {
            var DBConnectingString = ConnectionStringSingletonDP.Instance(connectionString);
            try
            {
                using (var sqlConnection = DBConnectingString)
                {
                    sqlConnection.Query(sql_Query);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"İşlem sırasında hata meydana geldi {ex.Message}");
            }
        }
    }
}
