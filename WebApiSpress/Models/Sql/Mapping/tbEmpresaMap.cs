using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbEmpresaMap : EntityTypeConfiguration<tbEmpresa>
    {
        public tbEmpresaMap()
        {
            // Primary Key
            this.HasKey(t => t.nrCNPJBase);

            // Properties
            this.Property(t => t.nrCNPJBase)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8);

            this.Property(t => t.dsCertificadoDigitalSenha)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("tbEmpresa", "admin");
            this.Property(t => t.nrCNPJBase).HasColumnName("nrCNPJBase");
            this.Property(t => t.dsCertificadoDigital).HasColumnName("dsCertificadoDigital");
            this.Property(t => t.dsCertificadoDigitalSenha).HasColumnName("dsCertificadoDigitalSenha");
            this.Property(t => t.cdEmpresaGrupo).HasColumnName("cdEmpresaGrupo");
            this.Property(t => t.dtCadastro).HasColumnName("dtCadastro");
            this.Property(t => t.dtValidade).HasColumnName("dtValidade");
            this.Property(t => t.flSenhaValida).HasColumnName("flSenhaValida");

            // Relationships
            this.HasRequired(t => t.tbEmpresaGrupo)
                .WithMany(t => t.tbEmpresas)
                .HasForeignKey(d => d.cdEmpresaGrupo);

        }
    }
}
