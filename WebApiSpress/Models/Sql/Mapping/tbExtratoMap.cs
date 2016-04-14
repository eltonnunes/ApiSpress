using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbExtratoMap : EntityTypeConfiguration<tbExtrato>
    {
        public tbExtratoMap()
        {
            // Primary Key
            this.HasKey(t => t.idExtrato);

            // Properties
            this.Property(t => t.nrDocumento)
                .HasMaxLength(20);
            this.Property(t => t.dsDocumento);
                //.HasMaxLength(50);
            this.Property(t => t.dsTipo)
                .HasMaxLength(30); 

            // Table & Column Mappings
            this.ToTable("tbExtrato", "card");
            this.Property(t => t.idExtrato).HasColumnName("idExtrato");
            this.Property(t => t.cdContaCorrente).HasColumnName("cdContaCorrente");
            this.Property(t => t.nrDocumento).HasColumnName("nrDocumento");
            this.Property(t => t.dtExtrato).HasColumnName("dtExtrato");
            this.Property(t => t.dsDocumento).HasColumnName("dsDocumento");
            this.Property(t => t.vlMovimento).HasColumnName("vlMovimento");
            this.Property(t => t.dsTipo).HasColumnName("dsTipo");
            this.Property(t => t.dsArquivo).HasColumnName("dsArquivo");

            // Relationships
            this.HasRequired(t => t.tbContaCorrente)
                .WithMany(t => t.tbExtratos)
                .HasForeignKey(d => d.cdContaCorrente);
        }
    }
}