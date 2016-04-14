using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class grupo_empresaMap : EntityTypeConfiguration<grupo_empresa>
    {
        public grupo_empresaMap()
        {
            // Primary Key
            this.HasKey(t => t.id_grupo);

            // Properties
            this.Property(t => t.ds_nome)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.token)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("grupo_empresa", "cliente");
            this.Property(t => t.id_grupo).HasColumnName("id_grupo");
            this.Property(t => t.ds_nome).HasColumnName("ds_nome");
            this.Property(t => t.dt_cadastro).HasColumnName("dt_cadastro");
            this.Property(t => t.token).HasColumnName("token");
            this.Property(t => t.fl_cardservices).HasColumnName("fl_cardservices");
            this.Property(t => t.fl_taxservices).HasColumnName("fl_taxservices");
            this.Property(t => t.fl_proinfo).HasColumnName("fl_proinfo");
            this.Property(t => t.id_vendedor).HasColumnName("id_vendedor");
            this.Property(t => t.fl_ativo).HasColumnName("fl_ativo");


            // Relationships
            this.HasOptional(t => t.Vendedor)
                .WithMany(t => t.grupo_empresa_vendedor)
                .HasForeignKey(d => d.id_vendedor);
        }
    }
}
