using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class LogAcesso1Map : EntityTypeConfiguration<LogAcesso1>
    {
        public LogAcesso1Map()
        {
            // Primary Key
            this.HasKey(t => t.dtAcesso);

            // Properties
            // Table & Column Mappings
            this.ToTable("LogAcesso", "log");
            this.Property(t => t.idUsers).HasColumnName("idUsers");
            this.Property(t => t.idController).HasColumnName("idController");
            this.Property(t => t.idMethod).HasColumnName("idMethod");
            this.Property(t => t.dtAcesso).HasColumnName("dtAcesso");
            this.Property(t => t.flMobile).HasColumnName("flMobile");
            this.Property(t => t.dsUserAgent).HasColumnName("dsUserAgent");

            // Relationships
            this.HasOptional(t => t.webpages_Controllers)
                .WithMany(t => t.LogAcesso1)
                .HasForeignKey(d => d.idController);
            this.HasOptional(t => t.webpages_Methods)
                .WithMany(t => t.LogAcesso1)
                .HasForeignKey(d => d.idMethod);
            this.HasOptional(t => t.webpages_Users)
                .WithMany(t => t.LogAcesso1)
                .HasForeignKey(d => d.idUsers);

        }
    }
}
