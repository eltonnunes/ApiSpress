using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class fornecedorMap : EntityTypeConfiguration<fornecedor>
    {
        public fornecedorMap()
        {
            // Primary Key
            this.HasKey(t => t.nu_cnpjCpf);

            // Properties
            this.Property(t => t.nu_cnpjCpf)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.ds_fantasia)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.ds_razaoSocial)
                .HasMaxLength(255);

            this.Property(t => t.ds_endereco)
                .HasMaxLength(255);

            this.Property(t => t.sg_uf)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.nu_cep)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.nu_telefone)
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.nm_bairro)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("fornecedor", "nferecepcao");
            this.Property(t => t.nu_cnpjCpf).HasColumnName("nu_cnpjCpf");
            this.Property(t => t.ds_fantasia).HasColumnName("ds_fantasia");
            this.Property(t => t.ds_razaoSocial).HasColumnName("ds_razaoSocial");
            this.Property(t => t.ds_endereco).HasColumnName("ds_endereco");
            this.Property(t => t.sg_uf).HasColumnName("sg_uf");
            this.Property(t => t.nu_cep).HasColumnName("nu_cep");
            this.Property(t => t.nu_telefone).HasColumnName("nu_telefone");
            this.Property(t => t.nm_bairro).HasColumnName("nm_bairro");
            this.Property(t => t.dt_cadastro).HasColumnName("dt_cadastro");
        }
    }
}
