using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class colreltrnMap : EntityTypeConfiguration<colreltrn>
    {
        public colreltrnMap()
        {
            // Primary Key
            this.HasKey(t => new { t.logrede, t.colunalog });

            // Properties
            this.Property(t => t.logrede)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.colunalog)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.descricao)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("colreltrn");
            this.Property(t => t.logrede).HasColumnName("logrede");
            this.Property(t => t.colunalog).HasColumnName("colunalog");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.formato).HasColumnName("formato");
            this.Property(t => t.tamcoluna).HasColumnName("tamcoluna");
        }
    }
}
