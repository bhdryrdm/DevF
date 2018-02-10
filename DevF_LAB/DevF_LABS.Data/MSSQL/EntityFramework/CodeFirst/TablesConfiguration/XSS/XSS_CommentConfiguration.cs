using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables.XSS;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.TablesConfiguration.XSS
{
    public class XSS_CommentConfiguration : EntityTypeConfiguration<XSS_Comment>
    {
        public XSS_CommentConfiguration()
        {
            //Tablo ismi
            this.ToTable("XSS_Comment");

            //Primary Key
            this.HasKey<int>(s => s.ID);

            this.Property(x => x.ID)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .IsRequired()
                    .HasColumnName("ID")
                    .HasColumnOrder(1)
                    .HasColumnType("int");

            this.Property(x => x.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasColumnOrder(2)
                    .HasColumnType("nvarchar");

            this.Property(x => x.Email)
                   .IsRequired()
                   .HasColumnName("Email")
                   .HasColumnOrder(3)
                   .HasColumnType("nvarchar");

            this.Property(x => x.Comment)
                   .IsRequired()
                   .HasMaxLength(1500)
                   .HasColumnName("Comment")
                   .HasColumnOrder(4)
                   .HasColumnType("nvarchar");

            this.Property(x => x.CreatedTime)
                 .HasColumnName("CreatedTime")
                 .HasColumnOrder(5)
                 .HasColumnType("datetime");
        }
    }
}
