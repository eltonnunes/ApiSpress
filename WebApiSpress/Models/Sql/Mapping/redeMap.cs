using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class redeMap : EntityTypeConfiguration<rede>
    {
        public redeMap()
        {
            // Primary Key
            this.HasKey(t => t.idt_rede);

            // Properties
            this.Property(t => t.idt_rede)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.descr_rede)
                .HasMaxLength(40);

            this.Property(t => t.exibe)
                .HasMaxLength(1);

            this.Property(t => t.disponivel)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("redes");
            this.Property(t => t.idt_rede).HasColumnName("idt_rede");
            this.Property(t => t.descr_rede).HasColumnName("descr_rede");
            this.Property(t => t.exibe).HasColumnName("exibe");
            this.Property(t => t.disponivel).HasColumnName("disponivel");
        }
    }
}
