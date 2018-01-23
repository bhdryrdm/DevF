using System.Data.Entity.Migrations;

namespace DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst
{
    public class MSSQL_EF_CF_Context_Config : DbMigrationsConfiguration<MSSQL_EF_CF_Context>
    {
        public MSSQL_EF_CF_Context_Config()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst";
        }
    }
}
