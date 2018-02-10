using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables.XSS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.TablesConfiguration.XSS
{
    public class XSS_CookieConfiguration : EntityTypeConfiguration<XSS_Cookie>
    {
        public XSS_CookieConfiguration()
        {
            //Tablo ismi
            this.ToTable("XSS_Cookie");

            //Primary Key
            this.HasKey<int>(s => s.ID);

            this.Property(x => x.ID)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .IsRequired()
                    .HasColumnName("ID")
                    .HasColumnOrder(1)
                    .HasColumnType("int");

            this.Property(x => x.CookieName)
                    .IsRequired()
                    .HasColumnName("CookieName")
                    .HasColumnOrder(2)
                    .HasColumnType("nvarchar");

            this.Property(x => x.CookieValue)
                   .IsRequired()
                   .HasColumnName("CookieValue")
                   .HasColumnOrder(3)
                   .HasColumnType("nvarchar");

            this.Property(x => x.SessionID)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("SessionID")
                   .HasColumnOrder(4)
                   .HasColumnType("nvarchar");

        }
    }
}
