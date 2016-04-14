using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tipo_transacaoMap : EntityTypeConfiguration<tipo_transacao>
    {
        public tipo_transacaoMap()
        {
            // Primary Key
            this.HasKey(t => t.tipo_id);

            // Properties
            this.Property(t => t.tipo_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.descricao)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.exibe)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("tipo_transacao");
            this.Property(t => t.tipo_id).HasColumnName("tipo_id");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.exibe).HasColumnName("exibe");
        }
    }
}
