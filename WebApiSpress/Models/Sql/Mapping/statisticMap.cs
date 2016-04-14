using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class statisticMap : EntityTypeConfiguration<statistic>
    {
        public statisticMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("statistics", "newsletter");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.idNewsletter).HasColumnName("idNewsletter");
            this.Property(t => t.idEmails).HasColumnName("idEmails");
            this.Property(t => t.idLinks).HasColumnName("idLinks");

            // Relationships
            this.HasRequired(t => t.email)
                .WithMany(t => t.statistics)
                .HasForeignKey(d => d.idEmails);
            this.HasOptional(t => t.link)
                .WithMany(t => t.statistics)
                .HasForeignKey(d => d.idLinks);
            this.HasRequired(t => t.newsletter)
                .WithMany(t => t.statistics)
                .HasForeignKey(d => d.idNewsletter);

        }
    }
}
