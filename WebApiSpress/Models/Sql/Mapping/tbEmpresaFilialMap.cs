using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbEmpresaFilialMap : EntityTypeConfiguration<tbEmpresaFilial>
    {
        public tbEmpresaFilialMap()
        {
            // Primary Key
            this.HasKey(t => t.nrCNPJ);

            // Properties
            this.Property(t => t.nrCNPJ)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.nrCNPJBase)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8);

            this.Property(t => t.nrCNPJSequencia)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.nrCNPJDigito)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.nmFantasia)
                .IsRequired()
                .HasMaxLength(60);

            this.Property(t => t.nmRazaoSocial)
                .HasMaxLength(60);

            this.Property(t => t.dsEndereco)
                .HasMaxLength(255);

            this.Property(t => t.dsCidade)
                .HasMaxLength(50);

            this.Property(t => t.sgUF)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.nrCEP)
                .HasMaxLength(20);

            this.Property(t => t.nrTelefone)
                .HasMaxLength(20);

            this.Property(t => t.dsBairro)
                .HasMaxLength(50);

            this.Property(t => t.dsEmail)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.nrFilial)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.nrInscEstadual)
                .HasMaxLength(50);

            this.Property(t => t.token)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("tbEmpresaFilial", "admin");
            this.Property(t => t.nrCNPJ).HasColumnName("nrCNPJ");
            this.Property(t => t.nrCNPJBase).HasColumnName("nrCNPJBase");
            this.Property(t => t.nrCNPJSequencia).HasColumnName("nrCNPJSequencia");
            this.Property(t => t.nrCNPJDigito).HasColumnName("nrCNPJDigito");
            this.Property(t => t.nmFantasia).HasColumnName("nmFantasia");
            this.Property(t => t.nmRazaoSocial).HasColumnName("nmRazaoSocial");
            this.Property(t => t.dsEndereco).HasColumnName("dsEndereco");
            this.Property(t => t.dsCidade).HasColumnName("dsCidade");
            this.Property(t => t.sgUF).HasColumnName("sgUF");
            this.Property(t => t.nrCEP).HasColumnName("nrCEP");
            this.Property(t => t.nrTelefone).HasColumnName("nrTelefone");
            this.Property(t => t.dsBairro).HasColumnName("dsBairro");
            this.Property(t => t.dsEmail).HasColumnName("dsEmail");
            this.Property(t => t.dtCadastro).HasColumnName("dtCadastro");
            this.Property(t => t.flAtivo).HasColumnName("flAtivo");
            this.Property(t => t.cdEmpresaGrupo).HasColumnName("cdEmpresaGrupo");
            this.Property(t => t.nrFilial).HasColumnName("nrFilial");
            this.Property(t => t.nrInscEstadual).HasColumnName("nrInscEstadual");
            this.Property(t => t.token).HasColumnName("token");

            // Relationships
            this.HasRequired(t => t.tbEmpresaGrupo)
                .WithMany(t => t.tbEmpresaFiliais)
                .HasForeignKey(d => d.cdEmpresaGrupo);

        }
    }
}
