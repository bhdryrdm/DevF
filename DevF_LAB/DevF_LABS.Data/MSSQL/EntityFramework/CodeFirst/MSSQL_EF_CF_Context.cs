using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables;
using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables.XSS;
using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.TablesConfiguration.XSS;
using System.Data.Entity;

namespace DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst
{
    public class MSSQL_EF_CF_Context : DbContext
    {
        public MSSQL_EF_CF_Context() : base("name=MSSQL_EF_CF_Context")
        {
            //Tekrar DB oluşumunda gerekli
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MSSQL_EF_CF_Context, MSSQL_EF_CF_Context_Config>("MSSQL_EF_CF_Context")); // Web.Config yada App.Config içerisinde yazan String ifade 
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MsSQL_Context>());
        }

        public DbSet<XSS_User> XSS_User { get; set; }
        public DbSet<XSS_Comment> XSS_Comment { get; set; }
        public DbSet<Settings> Settings { get; set; }

        //Fluent API Configurations
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new XSS_UserConfiguration());
            modelBuilder.Configurations.Add(new XSS_CommentConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
