using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class TabExpMap : EntityTypeConfiguration<TabExp>
    {
        public TabExpMap()
        {
            // Primary Key
            this.HasKey(t => t.IdCliente);

            // Properties
            this.Property(t => t.IdCliente)
                .IsRequired()
                .HasMaxLength(21);

            this.Property(t => t.UltimoArq)
                .HasMaxLength(40);

            this.Property(t => t.Offset)
                .HasMaxLength(15);

            this.Property(t => t.dth_ult_trn)
                .HasMaxLength(14);

            // Table & Column Mappings
            this.ToTable("TabExp");
            this.Property(t => t.IdCliente).HasColumnName("IdCliente");
            this.Property(t => t.UltimoArq).HasColumnName("UltimoArq");
            this.Property(t => t.Offset).HasColumnName("Offset");
            this.Property(t => t.dth_ultimaat).HasColumnName("dth_ultimaat");
            this.Property(t => t.dth_ult_trn).HasColumnName("dth_ult_trn");
        }
    }
}
