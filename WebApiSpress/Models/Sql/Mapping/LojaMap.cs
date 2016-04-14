using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class LojaMap : EntityTypeConfiguration<Loja>
    {
        public LojaMap()
        {
            // Primary Key
            this.HasKey(t => t.CodLojaSitef);

            // Properties
            this.Property(t => t.CodLojaSitef)
                .IsRequired()
                .HasMaxLength(17);

            this.Property(t => t.Descr_Loja)
                .HasMaxLength(40);

            this.Property(t => t.cdestasodex)
                .HasMaxLength(15);

            this.Property(t => t.cnpj)
                .HasMaxLength(14);

            this.Property(t => t.cod_uf)
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("Loja");
            this.Property(t => t.CodLojaSitef).HasColumnName("CodLojaSitef");
            this.Property(t => t.Descr_Loja).HasColumnName("Descr_Loja");
            this.Property(t => t.cdestasodex).HasColumnName("cdestasodex");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.cod_uf).HasColumnName("cod_uf");
            this.Property(t => t.last_update).HasColumnName("last_update");
            this.Property(t => t.se_cliente).HasColumnName("se_cliente");

            // Relationships
            this.HasOptional(t => t.uf)
                .WithMany(t => t.Lojas)
                .HasForeignKey(d => d.cod_uf);

        }
    }
}
