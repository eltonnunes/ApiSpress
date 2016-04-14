using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class TerminalLogicoMap : EntityTypeConfiguration<TerminalLogico>
    {
        public TerminalLogicoMap()
        {
            // Primary Key
            this.HasKey(t => t.idTerminalLogico);

            // Properties
            this.Property(t => t.dsTerminalLogico)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TerminalLogico", "pos");
            this.Property(t => t.idTerminalLogico).HasColumnName("idTerminalLogico");
            this.Property(t => t.dsTerminalLogico).HasColumnName("dsTerminalLogico");
            this.Property(t => t.idOperadora).HasColumnName("idOperadora");

            // Relationships
            this.HasRequired(t => t.Operadora)
                .WithMany(t => t.TerminalLogicoes)
                .HasForeignKey(d => d.idOperadora);

        }
    }
}
