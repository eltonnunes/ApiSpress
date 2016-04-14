using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class grupo_baseCnpjMap : EntityTypeConfiguration<grupo_baseCnpj>
    {
        public grupo_baseCnpjMap()
        {
            // Primary Key
            this.HasKey(t => t.nu_Cnpj);

            // Properties
            this.Property(t => t.nu_Cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.nu_BaseCnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8);

            this.Property(t => t.nu_SequenciaCnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.nu_DigitoCnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.token)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("grupo_baseCnpj", "cliente");
            this.Property(t => t.nu_Cnpj).HasColumnName("nu_Cnpj");
            this.Property(t => t.nu_BaseCnpj).HasColumnName("nu_BaseCnpj");
            this.Property(t => t.nu_SequenciaCnpj).HasColumnName("nu_SequenciaCnpj");
            this.Property(t => t.nu_DigitoCnpj).HasColumnName("nu_DigitoCnpj");
            this.Property(t => t.token).HasColumnName("token");
            this.Property(t => t.id_grupoEmpresa).HasColumnName("id_grupoEmpresa");

            // Relationships
            this.HasRequired(t => t.grupo_empresa)
                .WithMany(t => t.grupo_baseCnpj)
                .HasForeignKey(d => d.id_grupoEmpresa);

        }
    }
}
