using System;
using System.Data;
using System.Data.Common;

namespace DevF_LABS.Test.DBConnection
{
    public abstract class BaseConnection
    {
        public abstract void ConnectionDB(string sqlQuery, string connectionString);
    }
    public class ConnectionStringSingletonDP
    {
        private static IDbConnection dbConnectionString;
        private static Object objectLockControl = new Object();

        private ConnectionStringSingletonDP()
        {

        }

        #region I.Veritabanı yada genel olarak kullanım için gerekli olan kod bloğu
        //Burada direkt (SqlConnection) döndüm çünkü bana bu gerekli sadece (String) ConnectingString yeterli olmayabilir 
        public static IDbConnection Instance(string connectionString)
        {
            if (dbConnectionString == null)
            {
                lock (objectLockControl)
                {
                    if (dbConnectionString == null)
                    {
                        DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                        DbConnection connection = factory.CreateConnection();
                        connection.ConnectionString = connectionString;
                        connection.Open();
                        return connection;
                    }
                }
            }
            return dbConnectionString;
        }
        #endregion
    }
}
