using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class SuporteLojaMap : EntityTypeConfiguration<SuporteLoja>
    {
        public SuporteLojaMap()
        {
            // Primary Key
            this.HasKey(t => t.CodLojaSitef);

            // Properties
            this.Property(t => t.descr_rede)
                .HasMaxLength(40);

            this.Property(t => t.descr_trn)
                .HasMaxLength(40);

            this.Property(t => t.CodLojaSitef)
                .IsRequired()
                .HasMaxLength(17);

            this.Property(t => t.Maior_Inativo)
                .HasMaxLength(30);

            this.Property(t => t.Maior_Ativo)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("SuporteLoja");
            this.Property(t => t.descr_rede).HasColumnName("descr_rede");
            this.Property(t => t.descr_trn).HasColumnName("descr_trn");
            this.Property(t => t.CodLojaSitef).HasColumnName("CodLojaSitef");
            this.Property(t => t.Maior_Inativo).HasColumnName("Maior Inativo");
            this.Property(t => t.Maior_Ativo).HasColumnName("Maior Ativo");
        }
    }
}
