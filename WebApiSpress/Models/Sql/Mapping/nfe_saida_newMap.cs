using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class nfe_saida_newMap : EntityTypeConfiguration<nfe_saida_new>
    {
        public nfe_saida_newMap()
        {
            // Primary Key
            this.HasKey(t => new { t.nu_cnpj, t.nu_cnpjCpfCliente, t.nu_chave, t.dt_Emissao, t.nu_baseCnpjCliente });

            // Properties
            this.Property(t => t.nu_cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.nu_cnpjCpfCliente)
                .IsRequired()
                .HasMaxLength(14);

            this.Property(t => t.nu_chave)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(44);

            this.Property(t => t.nm_Destinatario)
                .HasMaxLength(255);

            this.Property(t => t.sg_uf)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.nu_baseCnpjCliente)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8);

            this.Property(t => t.ds_motivoDevolucao)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("nfe_saida_new");
            this.Property(t => t.nu_cnpj).HasColumnName("nu_cnpj");
            this.Property(t => t.nu_cnpjCpfCliente).HasColumnName("nu_cnpjCpfCliente");
            this.Property(t => t.nu_chave).HasColumnName("nu_chave");
            this.Property(t => t.nm_Destinatario).HasColumnName("nm_Destinatario");
            this.Property(t => t.sg_uf).HasColumnName("sg_uf");
            this.Property(t => t.dt_Emissao).HasColumnName("dt_Emissao");
            this.Property(t => t.vl_ICMS).HasColumnName("vl_ICMS");
            this.Property(t => t.vl_Frete).HasColumnName("vl_Frete");
            this.Property(t => t.vl_Desconto).HasColumnName("vl_Desconto");
            this.Property(t => t.vl_II).HasColumnName("vl_II");
            this.Property(t => t.vl_IPI).HasColumnName("vl_IPI");
            this.Property(t => t.vl_PIS).HasColumnName("vl_PIS");
            this.Property(t => t.vl_Cofins).HasColumnName("vl_Cofins");
            this.Property(t => t.vl_Outro).HasColumnName("vl_Outro");
            this.Property(t => t.vl_Total).HasColumnName("vl_Total");
            this.Property(t => t.ds_Conteudo).HasColumnName("ds_Conteudo");
            this.Property(t => t.nu_baseCnpjCliente).HasColumnName("nu_baseCnpjCliente");
            this.Property(t => t.fl_GbCancelada).HasColumnName("fl_GbCancelada");
            this.Property(t => t.dt_cadastro).HasColumnName("dt_cadastro");
            this.Property(t => t.dt_exclusao).HasColumnName("dt_exclusao");
            this.Property(t => t.dt_devolucao).HasColumnName("dt_devolucao");
            this.Property(t => t.ds_motivoDevolucao).HasColumnName("ds_motivoDevolucao");
            this.Property(t => t.fl_erro).HasColumnName("fl_erro");
        }
    }
}
