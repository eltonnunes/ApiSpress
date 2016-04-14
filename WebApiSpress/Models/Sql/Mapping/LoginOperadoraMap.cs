using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class LoginOperadoraMap : EntityTypeConfiguration<LoginOperadora>
    {
        public LoginOperadoraMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.login)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.senha)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.estabelecimento)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("LoginOperadora", "pos");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.login).HasColumnName("login");
            this.Property(t => t.senha).HasColumnName("senha");
            this.Property(t => t.data_alteracao).HasColumnName("data_alteracao");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.cnpj).HasColumnName("cnpj");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");
            this.Property(t => t.idGrupo).HasColumnName("idGrupo");
            this.Property(t => t.estabelecimento).HasColumnName("estabelecimento");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.LoginOperadoras)
                .HasForeignKey(d => d.cnpj);
            this.HasRequired(t => t.grupo_empresa)
                .WithMany(t => t.LoginOperadoras)
                .HasForeignKey(d => d.idGrupo);
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.LoginOperadoras)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
