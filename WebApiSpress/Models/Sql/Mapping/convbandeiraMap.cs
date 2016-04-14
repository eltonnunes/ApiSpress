using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class convbandeiraMap : EntityTypeConfiguration<convbandeira>
    {
        public convbandeiraMap()
        {
            // Primary Key
            this.HasKey(t => new { t.operacaotef, t.mascara_bin, t.tam_cartao });

            // Properties
            this.Property(t => t.operacaotef)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.mascara_bin)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.tam_cartao)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("convbandeira");
            this.Property(t => t.operacaotef).HasColumnName("operacaotef");
            this.Property(t => t.mascara_bin).HasColumnName("mascara_bin");
            this.Property(t => t.tam_cartao).HasColumnName("tam_cartao");
            this.Property(t => t.idt_bandeira).HasColumnName("idt_bandeira");

            // Relationships
            this.HasOptional(t => t.bandeiras1)
                .WithMany(t => t.convbandeiras)
                .HasForeignKey(d => d.idt_bandeira);

        }
    }
}
