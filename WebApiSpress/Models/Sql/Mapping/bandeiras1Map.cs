using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class bandeiras1Map : EntityTypeConfiguration<bandeiras1>
    {
        public bandeiras1Map()
        {
            // Primary Key
            this.HasKey(t => t.idt_bandeira);

            // Properties
            this.Property(t => t.idt_bandeira)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.descr_bandeira)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("bandeiras");
            this.Property(t => t.idt_bandeira).HasColumnName("idt_bandeira");
            this.Property(t => t.descr_bandeira).HasColumnName("descr_bandeira");
        }
    }
}
