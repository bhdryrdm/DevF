using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables.XSS;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.TablesConfiguration.XSS
{
    public class XSS_EditorConfiguration : EntityTypeConfiguration<XSS_Editor>
    {
        public XSS_EditorConfiguration()
        {
            //Tablo ismi
            this.ToTable("XSS_Editor");

            //Primary Key
            this.HasKey<int>(s => s.ID);

            this.Property(x => x.ID)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .IsRequired()
                    .HasColumnName("ID")
                    .HasColumnOrder(1)
                    .HasColumnType("int");

            this.Property(x => x.Content)
                    .IsRequired()
                    .HasColumnName("Content")
                    .HasColumnOrder(2)
                    .HasColumnType("nvarchar");
        }
    }
}
