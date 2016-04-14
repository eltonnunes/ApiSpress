using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class MSpeer_requestMap : EntityTypeConfiguration<MSpeer_request>
    {
        public MSpeer_requestMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.publication });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.publication)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.description)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("MSpeer_request");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.publication).HasColumnName("publication");
            this.Property(t => t.sent_date).HasColumnName("sent_date");
            this.Property(t => t.description).HasColumnName("description");
        }
    }
}
