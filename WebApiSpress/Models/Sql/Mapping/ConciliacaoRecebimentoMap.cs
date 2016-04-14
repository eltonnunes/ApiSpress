using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class ConciliacaoRecebimentoMap : EntityTypeConfiguration<ConciliacaoRecebimento>
    {
        public ConciliacaoRecebimentoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.observacao)
                .HasMaxLength(512);

            // Table & Column Mappings
            this.ToTable("ConciliacaoRecebimento", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.id_users).HasColumnName("id_users");
            this.Property(t => t.idGrupo).HasColumnName("idGrupo");
            this.Property(t => t.mes).HasColumnName("mes");
            this.Property(t => t.ano).HasColumnName("ano");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.quantidade).HasColumnName("quantidade");
            this.Property(t => t.valor).HasColumnName("valor");
            this.Property(t => t.observacao).HasColumnName("observacao");
            this.Property(t => t.status).HasColumnName("status");

            // Relationships
            this.HasRequired(t => t.grupo_empresa)
                .WithMany(t => t.ConciliacaoRecebimentoes)
                .HasForeignKey(d => d.idGrupo);
            this.HasOptional(t => t.webpages_Users)
                .WithMany(t => t.ConciliacaoRecebimentoes)
                .HasForeignKey(d => d.id_users);

        }
    }
}
