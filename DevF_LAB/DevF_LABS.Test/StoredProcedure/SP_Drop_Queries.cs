using DevF_LABS.Test.DBConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.Test.StoredProcedure
{
    public class SP_Drop_Queries : RunQuery
    {
        private readonly string _connectionString;
        public SP_Drop_Queries(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Generic Stored Procedure Dropper 
        /// </summary>
        /// <param name="spName">Stored Procedure İsmi</param>
        /// <param name="spSchemaName">Stored Procedure Şema İsmi Default olarak dbo </param>
        public void DropSP(string spName, string spSchemaName)
        {
            //Interpolated Strings içerisinde IF / ELSE kullanımı 
            var sqlQuery = $"DROP PROCEDURE {(!String.IsNullOrEmpty(spSchemaName) ? $"{spSchemaName}{"."}" : "dbo.")}{spName}";

            ConnectionDB(sqlQuery, _connectionString);
        }

        /// <summary>
        /// Generic Stored Procedure Dropper 
        /// </summary>
        /// <param name="triggerName">Trigger İsmi</param>
        /// <param name="triggerSchemaName">Trigger Şema İsmi Default olarak dbo </param>
        public void DropTrigger(string triggerName, string triggerSchemaName)
        {
            //Interpolated Strings içerisinde IF / ELSE kullanımı 
            var sqlQuery = $"DROP TRIGGER {(!String.IsNullOrEmpty(triggerSchemaName) ? $"{triggerSchemaName}{"."}" : "dbo.")}{triggerName}";

            ConnectionDB(sqlQuery, _connectionString);
        }
    }
}
