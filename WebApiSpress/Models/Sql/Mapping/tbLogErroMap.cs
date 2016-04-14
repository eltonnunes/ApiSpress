using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbLogErroMap : EntityTypeConfiguration<tbLogErro>
    {
        public tbLogErroMap()
        {
            // Primary Key
            this.HasKey(t => t.idLogErro);

            // Properties
            this.Property(t => t.dsAplicacao)
                .HasMaxLength(255);

            this.Property(t => t.dsVersao)
                .HasMaxLength(255);

            this.Property(t => t.dsNomeComputador)
                .HasMaxLength(255);

            this.Property(t => t.dsNomeUsuario)
                .HasMaxLength(255);

            this.Property(t => t.dsVersaoSO)
                .HasMaxLength(255);

            this.Property(t => t.dsCultura)
                .HasMaxLength(255);

            this.Property(t => t.dsMensagem)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("tbLogErro", "admin");
            this.Property(t => t.idLogErro).HasColumnName("idLogErro");
            this.Property(t => t.dsAplicacao).HasColumnName("dsAplicacao");
            this.Property(t => t.dsVersao).HasColumnName("dsVersao");
            this.Property(t => t.dtErro).HasColumnName("dtErro");
            this.Property(t => t.dsNomeComputador).HasColumnName("dsNomeComputador");
            this.Property(t => t.dsNomeUsuario).HasColumnName("dsNomeUsuario");
            this.Property(t => t.dsVersaoSO).HasColumnName("dsVersaoSO");
            this.Property(t => t.dsCultura).HasColumnName("dsCultura");
            this.Property(t => t.dsMensagem).HasColumnName("dsMensagem");
            this.Property(t => t.dsStackTrace).HasColumnName("dsStackTrace");
            this.Property(t => t.dsXmlEntrada).HasColumnName("dsXmlEntrada");

        }
    }
}
