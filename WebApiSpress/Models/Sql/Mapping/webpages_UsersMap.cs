using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class webpages_UsersMap : EntityTypeConfiguration<webpages_Users>
    {
        public webpages_UsersMap()
        {
            // Primary Key
            this.HasKey(t => t.id_users);

            // Properties
            this.Property(t => t.ds_login)
                .HasMaxLength(255);

            this.Property(t => t.ds_email)
                .HasMaxLength(255);

            this.Property(t => t.nu_cnpjEmpresa)
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.nu_cnpjBaseEmpresa)
                .IsFixedLength()
                .HasMaxLength(8);

            // Table & Column Mappings
            this.ToTable("webpages_Users");
            this.Property(t => t.id_users).HasColumnName("id_users");
            this.Property(t => t.ds_login).HasColumnName("ds_login");
            this.Property(t => t.ds_email).HasColumnName("ds_email");
            this.Property(t => t.id_grupo).HasColumnName("id_grupo");
            this.Property(t => t.nu_cnpjEmpresa).HasColumnName("nu_cnpjEmpresa");
            this.Property(t => t.nu_cnpjBaseEmpresa).HasColumnName("nu_cnpjBaseEmpresa");
            this.Property(t => t.id_pessoa).HasColumnName("id_pessoa");

            // Relationships
            this.HasOptional(t => t.empresa)
                .WithMany(t => t.webpages_Users)
                .HasForeignKey(d => d.nu_cnpjEmpresa);
            this.HasOptional(t => t.grupo_empresa)
                .WithMany(t => t.webpages_Users)
                .HasForeignKey(d => d.id_grupo);
            this.HasOptional(t => t.pessoa)
                .WithMany(t => t.webpages_Users)
                .HasForeignKey(d => d.id_pessoa);

        }
    }
}
