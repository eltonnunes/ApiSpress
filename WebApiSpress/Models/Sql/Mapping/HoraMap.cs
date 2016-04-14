using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class HoraMap : EntityTypeConfiguration<Hora>
    {
        public HoraMap()
        {
            // Primary Key
            this.HasKey(t => new { t.CodLojaSitef, t.Cod_TrnWeb, t.Idt_Rede });

            // Properties
            this.Property(t => t.CodLojaSitef)
                .IsRequired()
                .HasMaxLength(17);

            this.Property(t => t.Cod_TrnWeb)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Idt_Rede)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Horas");
            this.Property(t => t.CodLojaSitef).HasColumnName("CodLojaSitef");
            this.Property(t => t.Cod_TrnWeb).HasColumnName("Cod_TrnWeb");
            this.Property(t => t.Idt_Rede).HasColumnName("Idt_Rede");
            this.Property(t => t.Hora1).HasColumnName("Hora");
        }
    }
}
