using OWASP_DB.MSSQL.EntityFramework.CodeFirst.Tables.XSS;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OWASP_DB.MSSQL.EntityFramework.CodeFirst.TablesConfiguration.XSS
{
    public class XSS_UserConfiguration : EntityTypeConfiguration<XSS_User>
    {
        public XSS_UserConfiguration()
        {
           //Tablo ismi
           this.ToTable("XSS_User");

            //Primary Key
            this.HasKey<int>(s => s.UserID);



            this.Property(x => x.UserID)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasColumnOrder(1)
                    .HasColumnType("int");

            this.Property(x => x.UserName)
                    .IsRequired()
                    .HasColumnName("UserName")
                    .HasColumnOrder(2)
                    .HasColumnType("nvarchar");

            this.Property(x => x.UserSurname)
                   .IsRequired()
                   .HasColumnName("UserSurname")
                   .HasColumnOrder(3)
                   .HasColumnType("nvarchar");

            this.Property(x => x.Email)
                   .IsRequired()
                   .HasColumnName("Email")
                   .HasColumnOrder(4)
                   .HasColumnType("nvarchar");

            this.Property(x => x.Password)
                   .IsRequired()
                   .HasColumnName("Password")
                   .HasColumnOrder(5)
                   .HasColumnType("nvarchar");

            this.Property(x => x.UserRole)
                  .IsRequired()
                  .HasColumnName("UserRole")
                  .HasColumnOrder(6)
                  .HasColumnType("nvarchar");

            this.Property(x => x.CreatedTime)
                 .HasColumnName("CreatedTime")
                 .HasColumnOrder(7)
                 .HasColumnType("datetime");

            this.Property(x => x.UpdatedTime)
                 .IsRequired()
                 .HasColumnName("UpdatedTime")
                 .HasColumnOrder(8)
                 .HasColumnType("datetime");
        }
    }
    
}
