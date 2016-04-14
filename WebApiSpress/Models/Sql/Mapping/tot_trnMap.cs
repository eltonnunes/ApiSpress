using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tot_trnMap : EntityTypeConfiguration<tot_trn>
    {
        public tot_trnMap()
        {
            // Primary Key
            this.HasKey(t => new { t.data_trn, t.idt_rede, t.codlojasitef });

            // Properties
            this.Property(t => t.data_trn)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.hora_trn)
                .HasMaxLength(4);

            this.Property(t => t.idt_rede)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.codlojasitef)
                .IsRequired()
                .HasMaxLength(17);

            this.Property(t => t.tot_valor_trn)
                .HasMaxLength(12);

            this.Property(t => t.tot_qtd)
                .HasMaxLength(12);

            // Table & Column Mappings
            this.ToTable("tot_trn");
            this.Property(t => t.data_trn).HasColumnName("data_trn");
            this.Property(t => t.hora_trn).HasColumnName("hora_trn");
            this.Property(t => t.idt_rede).HasColumnName("idt_rede");
            this.Property(t => t.codlojasitef).HasColumnName("codlojasitef");
            this.Property(t => t.estado_trn).HasColumnName("estado_trn");
            this.Property(t => t.tot_valor_trn).HasColumnName("tot_valor_trn");
            this.Property(t => t.tot_qtd).HasColumnName("tot_qtd");
        }
    }
}
