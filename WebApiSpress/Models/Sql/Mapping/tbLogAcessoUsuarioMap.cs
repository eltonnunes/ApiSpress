using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbLogAcessoUsuarioMap : EntityTypeConfiguration<tbLogAcessoUsuario>
    {
        public tbLogAcessoUsuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.idLogAcessoUsuario);

            // Properties
            this.Property(t => t.dsUrl)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.dsParametros)
                .HasMaxLength(255);

            this.Property(t => t.dsFiltros)
                .HasMaxLength(255);

            this.Property(t => t.dsMethod)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.dsAplicacao)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("tbLogAcessoUsuario", "admin");
            this.Property(t => t.idLogAcessoUsuario).HasColumnName("idLogAcessoUsuario");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.dsUrl).HasColumnName("dsUrl");
            this.Property(t => t.idController).HasColumnName("idController");
            
            this.Property(t => t.dsParametros).HasColumnName("dsParametros");
            this.Property(t => t.dsFiltros).HasColumnName("dsFiltros");
            this.Property(t => t.dtAcesso).HasColumnName("dtAcesso");
            this.Property(t => t.dsAplicacao).HasColumnName("dsAplicacao");
            this.Property(t => t.codResposta).HasColumnName("codResposta");
            this.Property(t => t.msgErro).HasColumnName("msgErro");
            this.Property(t => t.dsJson).HasColumnName("dsJson");
            this.Property(t => t.dsUserAgent).HasColumnName("dsUserAgent");
            this.Property(t => t.dsMethod).HasColumnName("dsMethod");
            // Relationships
            this.HasRequired(t => t.webpages_Users)
                .WithMany(t => t.tbLogAcessoUsuarios)
                .HasForeignKey(d => d.idUser);
            this.HasOptional(t => t.webpages_Controllers)
                .WithMany(t => t.tbLogAcessoUsuarios)
                .HasForeignKey(d => d.idController);


        }
    }
}