using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class LoginAutenticacaoMap : EntityTypeConfiguration<WebApiSpress.Models.Sql.LoginAutenticacao>
    {
        public LoginAutenticacaoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idUsers, t.token });

            // Properties
            this.Property(t => t.idUsers)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.token)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("LoginAutenticacao", "moblie");
            this.Property(t => t.idUsers).HasColumnName("idUsers");
            this.Property(t => t.token).HasColumnName("token");
            this.Property(t => t.dtValidade).HasColumnName("dtValidade");

            // Relationships
            this.HasRequired(t => t.webpages_Users)
                .WithMany(t => t.LoginAutenticacaos)
                .HasForeignKey(d => d.idUsers);

        }
    }
}
