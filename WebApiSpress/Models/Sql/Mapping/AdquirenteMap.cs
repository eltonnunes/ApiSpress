using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class AdquirenteMap : EntityTypeConfiguration<Adquirente>
    {
        public AdquirenteMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.nome)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.descricao)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Adquirente", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.hraExecucao).HasColumnName("hraExecucao");

            // Relationships
            this.HasMany(t => t.Bandeiras)
                .WithMany(t => t.Adquirentes)
                .Map(m =>
                    {
                        m.ToTable("AdquirenteBandeira", "pos");
                        m.MapLeftKey("idAdquirente");
                        m.MapRightKey("idBandeira");
                    });


        }
    }
}
