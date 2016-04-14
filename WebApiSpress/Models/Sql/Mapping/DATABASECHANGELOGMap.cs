using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class DATABASECHANGELOGMap : EntityTypeConfiguration<DATABASECHANGELOG>
    {
        public DATABASECHANGELOGMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.AUTHOR, t.FILENAME });

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(63);

            this.Property(t => t.AUTHOR)
                .IsRequired()
                .HasMaxLength(63);

            this.Property(t => t.FILENAME)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.MD5SUM)
                .HasMaxLength(32);

            this.Property(t => t.DESCRIPTION)
                .HasMaxLength(255);

            this.Property(t => t.COMMENTS)
                .HasMaxLength(255);

            this.Property(t => t.TAG)
                .HasMaxLength(255);

            this.Property(t => t.LIQUIBASE)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("DATABASECHANGELOG");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.AUTHOR).HasColumnName("AUTHOR");
            this.Property(t => t.FILENAME).HasColumnName("FILENAME");
            this.Property(t => t.DATEEXECUTED).HasColumnName("DATEEXECUTED");
            this.Property(t => t.MD5SUM).HasColumnName("MD5SUM");
            this.Property(t => t.DESCRIPTION).HasColumnName("DESCRIPTION");
            this.Property(t => t.COMMENTS).HasColumnName("COMMENTS");
            this.Property(t => t.TAG).HasColumnName("TAG");
            this.Property(t => t.LIQUIBASE).HasColumnName("LIQUIBASE");
        }
    }
}
