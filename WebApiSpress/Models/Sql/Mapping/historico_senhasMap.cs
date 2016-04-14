using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class historico_senhasMap : EntityTypeConfiguration<historico_senhas>
    {
        public historico_senhasMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cod_usuario, t.senha, t.contador });

            // Properties
            this.Property(t => t.cod_usuario)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.senha)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.contador)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("historico_senhas");
            this.Property(t => t.cod_usuario).HasColumnName("cod_usuario");
            this.Property(t => t.senha).HasColumnName("senha");
            this.Property(t => t.cadastro).HasColumnName("cadastro");
            this.Property(t => t.contador).HasColumnName("contador");

            // Relationships
            this.HasRequired(t => t.usuario)
                .WithMany(t => t.historico_senhas)
                .HasForeignKey(d => d.cod_usuario);

        }
    }
}
