using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class sitredeMap : EntityTypeConfiguration<sitrede>
    {
        public sitredeMap()
        {
            // Primary Key
            this.HasKey(t => t.cod_sit);

            // Properties
            this.Property(t => t.cod_sit)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.descr_sit)
                .HasMaxLength(40);

            this.Property(t => t.logsit)
                .HasMaxLength(16);

            // Table & Column Mappings
            this.ToTable("sitrede");
            this.Property(t => t.cod_sit).HasColumnName("cod_sit");
            this.Property(t => t.idt_rede).HasColumnName("idt_rede");
            this.Property(t => t.descr_sit).HasColumnName("descr_sit");
            this.Property(t => t.tiposit).HasColumnName("tiposit");
            this.Property(t => t.logsit).HasColumnName("logsit");

            // Relationships
            this.HasRequired(t => t.rede)
                .WithMany(t => t.sitredes)
                .HasForeignKey(d => d.idt_rede);

        }
    }
}
