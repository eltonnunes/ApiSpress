using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbAdquirenteMap : EntityTypeConfiguration<tbAdquirente>
    {
        public tbAdquirenteMap()
        {
            // Primary Key
            this.HasKey(t => t.cdAdquirente);

            // Properties
            this.Property(t => t.nmAdquirente)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.dsAdquirente)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.stAdquirente)
                .IsRequired();

            this.Property(t => t.hrExecucao)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("tbAdquirente", "card");
            this.Property(t => t.cdAdquirente).HasColumnName("cdAdquirente");
            this.Property(t => t.nmAdquirente).HasColumnName("nmAdquirente");
            this.Property(t => t.dsAdquirente).HasColumnName("dsAdquirente");
            this.Property(t => t.stAdquirente).HasColumnName("stAdquirente");
            this.Property(t => t.hrExecucao).HasColumnName("hrExecucao");

        }
    }
}