using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables;
using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables.Injection;
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

        #region XSS
        public DbSet<XSS_User> XSS_User { get; set; }
        public DbSet<XSS_Cookie> XSS_Cookie { get; set; }
        public DbSet<XSS_Comment> XSS_Comment { get; set; }
        public DbSet<XSS_Editor> XSS_Editor { get; set; }
        #endregion

        #region Injection
        public DbSet<SQLInjection_User> SQL_User { get; set; }
        #endregion


        public DbSet<Settings> Settings { get; set; }

        //Fluent API Configurations
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new XSS_UserConfiguration());
            modelBuilder.Configurations.Add(new XSS_CommentConfiguration());
            modelBuilder.Configurations.Add(new XSS_CookieConfiguration());
            modelBuilder.Configurations.Add(new XSS_EditorConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
