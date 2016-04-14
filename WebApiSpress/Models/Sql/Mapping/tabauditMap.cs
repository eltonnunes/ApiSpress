using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tabauditMap : EntityTypeConfiguration<tabaudit>
    {
        public tabauditMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cod_usuario, t.data, t.hora, t.modulo, t.codacao, t.dadoacao });

            // Properties
            this.Property(t => t.cod_usuario)
                .IsRequired()
                .HasMaxLength(19);

            this.Property(t => t.data)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.hora)
                .IsRequired()
                .HasMaxLength(6);

            this.Property(t => t.modulo)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.codacao)
                .IsRequired()
                .HasMaxLength(3);

            this.Property(t => t.dadoacao)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("tabaudit");
            this.Property(t => t.cod_usuario).HasColumnName("cod_usuario");
            this.Property(t => t.data).HasColumnName("data");
            this.Property(t => t.hora).HasColumnName("hora");
            this.Property(t => t.modulo).HasColumnName("modulo");
            this.Property(t => t.codacao).HasColumnName("codacao");
            this.Property(t => t.dadoacao).HasColumnName("dadoacao");
        }
    }
}
