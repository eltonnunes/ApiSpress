using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbRecebimentoTEFMap : EntityTypeConfiguration<tbRecebimentoTEF>
    {
        public tbRecebimentoTEFMap()
        {
            // Primary Key
            this.HasKey(t => t.idRecebimentoTEF);

            // Properties
            this.Property(t => t.nrCNPJ)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.cdEmpresaTEF)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.nrPDVTEF)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.nrNSUHost)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.nrNSUTEF)
                .HasMaxLength(20);

            this.Property(t => t.cdAutorizacao)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.nrCartao)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.nmOperadora)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.cdEstabelecimentoHost)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("tbRecebimentoTEF", "card");
            this.Property(t => t.idRecebimentoTEF).HasColumnName("idRecebimentoTEF");
            this.Property(t => t.cdGrupo).HasColumnName("cdGrupo");
            this.Property(t => t.nrCNPJ).HasColumnName("nrCNPJ");
            this.Property(t => t.cdEmpresaTEF).HasColumnName("cdEmpresaTEF");
            this.Property(t => t.nrPDVTEF).HasColumnName("nrPDVTEF");
            this.Property(t => t.nrNSUHost).HasColumnName("nrNSUHost");
            this.Property(t => t.nrNSUTEF).HasColumnName("nrNSUTEF");
            this.Property(t => t.cdAutorizacao).HasColumnName("cdAutorizacao");
            this.Property(t => t.cdSituacaoRedeTEF).HasColumnName("cdSituacaoRedeTEF");
            this.Property(t => t.dtVenda).HasColumnName("dtVenda");
            this.Property(t => t.hrVenda).HasColumnName("hrVenda");
            this.Property(t => t.vlVenda).HasColumnName("vlVenda");
            this.Property(t => t.qtParcelas).HasColumnName("qtParcelas");
            this.Property(t => t.nrCartao).HasColumnName("nrCartao");
            this.Property(t => t.cdBandeira).HasColumnName("cdBandeira");
            this.Property(t => t.nmOperadora).HasColumnName("nmOperadora");
            this.Property(t => t.dthrVenda).HasColumnName("dthrVenda");
            this.Property(t => t.cdEstadoTransacaoTEF).HasColumnName("cdEstadoTransacaoTEF");
            this.Property(t => t.cdTrasacaoTEF).HasColumnName("cdTrasacaoTEF");
            this.Property(t => t.cdModoEntradaTEF).HasColumnName("cdModoEntradaTEF");
            this.Property(t => t.cdRedeTEF).HasColumnName("cdRedeTEF");
            this.Property(t => t.cdProdutoTEF).HasColumnName("cdProdutoTEF");
            this.Property(t => t.cdBandeiraTEF).HasColumnName("cdBandeiraTEF");
            this.Property(t => t.cdEstabelecimentoHost).HasColumnName("cdEstabelecimentoHost");
        }
    }
}
