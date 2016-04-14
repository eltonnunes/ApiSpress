using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class nfe_saidaMap : EntityTypeConfiguration<nfe_saida>
    {
        public nfe_saidaMap()
        {
            // Primary Key
            this.HasKey(t => new { t.nu_cnpjEmpresa, t.nu_cnpjCpfFornecedor, t.nu_chave });

            // Properties
            this.Property(t => t.nu_cnpjEmpresa)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.nu_cnpjCpfFornecedor)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.nu_chave)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.ds_fornecedor)
                .HasMaxLength(255);

            this.Property(t => t.sg_uf)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.ds_protocolo)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("nfe_saida", "nferecepcao");
            this.Property(t => t.nu_cnpjEmpresa).HasColumnName("nu_cnpjEmpresa");
            this.Property(t => t.nu_cnpjCpfFornecedor).HasColumnName("nu_cnpjCpfFornecedor");
            this.Property(t => t.nu_chave).HasColumnName("nu_chave");
            this.Property(t => t.ds_fornecedor).HasColumnName("ds_fornecedor");
            this.Property(t => t.sg_uf).HasColumnName("sg_uf");
            this.Property(t => t.dt_emissao).HasColumnName("dt_emissao");
            this.Property(t => t.vl_icms).HasColumnName("vl_icms");
            this.Property(t => t.vl_frete).HasColumnName("vl_frete");
            this.Property(t => t.vl_desconto).HasColumnName("vl_desconto");
            this.Property(t => t.vl_ii).HasColumnName("vl_ii");
            this.Property(t => t.vl_ipi).HasColumnName("vl_ipi");
            this.Property(t => t.vl_pis).HasColumnName("vl_pis");
            this.Property(t => t.vl_cofins).HasColumnName("vl_cofins");
            this.Property(t => t.vl_outro).HasColumnName("vl_outro");
            this.Property(t => t.vl_total).HasColumnName("vl_total");
            this.Property(t => t.ds_conteudo).HasColumnName("ds_conteudo");
            this.Property(t => t.nu_nf).HasColumnName("nu_nf");
            this.Property(t => t.dt_cadastro).HasColumnName("dt_cadastro");
            this.Property(t => t.dt_exclusao).HasColumnName("dt_exclusao");
            this.Property(t => t.fl_cancelada).HasColumnName("fl_cancelada");
            this.Property(t => t.ds_protocolo).HasColumnName("ds_protocolo");
            this.Property(t => t.fl_statusInportacao).HasColumnName("fl_statusInportacao");
            this.Property(t => t.dt_inportacao).HasColumnName("dt_inportacao");
            this.Property(t => t.fl_status).HasColumnName("fl_status");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.nfe_saida)
                .HasForeignKey(d => d.nu_cnpjEmpresa);
            this.HasRequired(t => t.fornecedor)
                .WithMany(t => t.nfe_saida)
                .HasForeignKey(d => d.nu_cnpjCpfFornecedor);

        }
    }
}
