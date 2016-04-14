using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class mercaMap : EntityTypeConfiguration<merca>
    {
        public mercaMap()
        {
            // Primary Key
            this.HasKey(t => t.id_Merca);

            // Properties
            this.Property(t => t.id_Merca)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ds_produto)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cd_codigoInterno)
                .IsFixedLength()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("merca", "pedido");
            this.Property(t => t.id_Merca).HasColumnName("id_Merca");
            this.Property(t => t.id_grupo).HasColumnName("id_grupo");
            this.Property(t => t.ds_produto).HasColumnName("ds_produto");
            this.Property(t => t.cd_codigoInterno).HasColumnName("cd_codigoInterno");

            // Relationships
            this.HasRequired(t => t.grupo_empresa)
                .WithMany(t => t.mercas)
                .HasForeignKey(d => d.id_grupo);

        }
    }
}
