using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class merca_deParaMap : EntityTypeConfiguration<merca_dePara>
    {
        public merca_deParaMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id_grupo, t.cnpjFornecedor, t.cd_xProd });

            // Properties
            this.Property(t => t.id_grupo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.cnpjFornecedor)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.cd_xProd)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ds_xProd)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cd_Ean13)
                .IsFixedLength()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("merca_dePara", "pedido");
            this.Property(t => t.id_grupo).HasColumnName("id_grupo");
            this.Property(t => t.cnpjFornecedor).HasColumnName("cnpjFornecedor");
            this.Property(t => t.cd_xProd).HasColumnName("cd_xProd");
            this.Property(t => t.ds_xProd).HasColumnName("ds_xProd");
            this.Property(t => t.id_Merca).HasColumnName("id_Merca");
            this.Property(t => t.cd_Ean13).HasColumnName("cd_Ean13");

            // Relationships
            this.HasRequired(t => t.grupo_empresa)
                .WithMany(t => t.merca_dePara)
                .HasForeignKey(d => d.id_grupo);
            this.HasRequired(t => t.fornecedor)
                .WithMany(t => t.merca_dePara)
                .HasForeignKey(d => d.cnpjFornecedor);

        }
    }
}
