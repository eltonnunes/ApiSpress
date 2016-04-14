using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class arquivo_emailMap : EntityTypeConfiguration<arquivo_email>
    {
        public arquivo_emailMap()
        {
            // Primary Key
            this.HasKey(t => t.id_arquivoEmail);

            // Properties
            this.Property(t => t.ds_nomeArquivo)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.ds_extensao)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ds_arquivo)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("arquivo_email");
            this.Property(t => t.id_arquivoEmail).HasColumnName("id_arquivoEmail");
            this.Property(t => t.id_recepcaoEmail).HasColumnName("id_recepcaoEmail");
            this.Property(t => t.ds_nomeArquivo).HasColumnName("ds_nomeArquivo");
            this.Property(t => t.ds_extensao).HasColumnName("ds_extensao");
            this.Property(t => t.ds_arquivo).HasColumnName("ds_arquivo");
            this.Property(t => t.fl_status).HasColumnName("fl_status");

            // Relationships
            this.HasRequired(t => t.recepcao_email)
                .WithMany(t => t.arquivo_email)
                .HasForeignKey(d => d.id_recepcaoEmail);

        }
    }
}
