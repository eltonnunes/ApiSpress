using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class MercaFornecedorMap : EntityTypeConfiguration<MercaFornecedor>
    {
        public MercaFornecedorMap()
        {
            // Primary Key
            this.HasKey(t => t.IdMercaFornecedor);

            // Properties
            this.Property(t => t.CNPJ)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.Codigo)
                .IsRequired()
                .HasMaxLength(60);

            this.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(120);

            this.Property(t => t.EAN)
                .HasMaxLength(14);

            this.Property(t => t.NCM)
                .HasMaxLength(8);

            // Table & Column Mappings
            this.ToTable("MercaFornecedor", "pedido");
            this.Property(t => t.IdMercaFornecedor).HasColumnName("IdMercaFornecedor");
            this.Property(t => t.CNPJ).HasColumnName("CNPJ");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.EAN).HasColumnName("EAN");
            this.Property(t => t.NCM).HasColumnName("NCM");

            // Relationships
            this.HasRequired(t => t.fornecedor)
                .WithMany(t => t.MercaFornecedors)
                .HasForeignKey(d => d.CNPJ);

        }
    }
}
