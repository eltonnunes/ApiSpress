using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class empresaMap : EntityTypeConfiguration<empresa>
    {
        public empresaMap()
        {
            // Primary Key
            this.HasKey(t => t.nu_cnpj);

            // Properties
            this.Property(t => t.nu_cnpj)
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

            this.Property(t => t.ds_fantasia)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.ds_razaoSocial)
                .HasMaxLength(255);

            this.Property(t => t.ds_endereco)
                .HasMaxLength(255);

            this.Property(t => t.ds_cidade)
                .HasMaxLength(255);

            this.Property(t => t.sg_uf)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.nu_cep)
                .HasMaxLength(20);

            this.Property(t => t.nu_telefone)
                .HasMaxLength(20);

            this.Property(t => t.ds_bairro)
                .HasMaxLength(255);

            this.Property(t => t.ds_email)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.token)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.filial)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("empresa", "cliente");
            this.Property(t => t.nu_cnpj).HasColumnName("nu_cnpj");
            this.Property(t => t.nu_BaseCnpj).HasColumnName("nu_BaseCnpj");
            this.Property(t => t.nu_SequenciaCnpj).HasColumnName("nu_SequenciaCnpj");
            this.Property(t => t.nu_DigitoCnpj).HasColumnName("nu_DigitoCnpj");
            this.Property(t => t.ds_fantasia).HasColumnName("ds_fantasia");
            this.Property(t => t.ds_razaoSocial).HasColumnName("ds_razaoSocial");
            this.Property(t => t.ds_endereco).HasColumnName("ds_endereco");
            this.Property(t => t.ds_cidade).HasColumnName("ds_cidade");
            this.Property(t => t.sg_uf).HasColumnName("sg_uf");
            this.Property(t => t.nu_cep).HasColumnName("nu_cep");
            this.Property(t => t.nu_telefone).HasColumnName("nu_telefone");
            this.Property(t => t.ds_bairro).HasColumnName("ds_bairro");
            this.Property(t => t.ds_email).HasColumnName("ds_email");
            this.Property(t => t.dt_cadastro).HasColumnName("dt_cadastro");
            this.Property(t => t.fl_ativo).HasColumnName("fl_ativo");
            this.Property(t => t.token).HasColumnName("token");
            this.Property(t => t.id_grupo).HasColumnName("id_grupo");
            this.Property(t => t.filial).HasColumnName("filial");
            this.Property(t => t.nu_inscEstadual).HasColumnName("nu_inscEstadual");

            // Relationships
            this.HasRequired(t => t.grupo_empresa)
                .WithMany(t => t.empresas)
                .HasForeignKey(d => d.id_grupo);

        }
    }
}
