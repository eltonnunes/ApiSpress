using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class MSpeer_responseMap : EntityTypeConfiguration<MSpeer_response>
    {
        public MSpeer_responseMap()
        {
            // Primary Key
            this.HasKey(t => new { t.peer, t.peer_db });

            // Properties
            this.Property(t => t.peer)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.peer_db)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("MSpeer_response");
            this.Property(t => t.request_id).HasColumnName("request_id");
            this.Property(t => t.peer).HasColumnName("peer");
            this.Property(t => t.peer_db).HasColumnName("peer_db");
            this.Property(t => t.received_date).HasColumnName("received_date");
        }
    }
}
