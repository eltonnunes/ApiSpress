using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbNewsMap : EntityTypeConfiguration<tbNews>
    {
        public tbNewsMap()
        {
            // Primary Key
            this.HasKey(t => t.idNews);

            // Properties
            this.Property(t => t.idNews)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dsNews)
                .IsRequired();

            this.Property(t => t.cdReporter)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("tbNews", "admin");
            this.Property(t => t.idNews).HasColumnName("idNews");
            this.Property(t => t.dsNews).HasColumnName("dsNews");
            this.Property(t => t.dtNews).HasColumnName("dtNews");
            this.Property(t => t.cdEmpresaGrupo).HasColumnName("cdEmpresaGrupo");
            this.Property(t => t.cdCatalogo).HasColumnName("cdCatalogo");
            this.Property(t => t.cdCanal).HasColumnName("cdCanal");
            this.Property(t => t.cdReporter).HasColumnName("cdReporter");
            this.Property(t => t.dtEnvio).HasColumnName("dtEnvio");

            // Relationships
            this.HasRequired(t => t.tbCanal)
                .WithMany(t => t.tbNews)
                .HasForeignKey(d => d.cdCanal);
            this.HasRequired(t => t.tbCatalogo)
                .WithMany(t => t.tbNews)
                .HasForeignKey(d => d.cdCatalogo);

        }
    }
}