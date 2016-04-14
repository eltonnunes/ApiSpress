using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class confrelMap : EntityTypeConfiguration<confrel>
    {
        public confrelMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cod_usuario, t.logrede, t.colunalog });

            // Properties
            this.Property(t => t.cod_usuario)
                .IsRequired()
                .HasMaxLength(32);

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
            this.ToTable("confrel");
            this.Property(t => t.cod_usuario).HasColumnName("cod_usuario");
            this.Property(t => t.logrede).HasColumnName("logrede");
            this.Property(t => t.colunalog).HasColumnName("colunalog");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.ordem).HasColumnName("ordem");
            this.Property(t => t.formato).HasColumnName("formato");
            this.Property(t => t.tamcoluna).HasColumnName("tamcoluna");
        }
    }
}
