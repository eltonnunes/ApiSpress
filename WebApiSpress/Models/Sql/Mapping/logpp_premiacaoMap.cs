using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class logpp_premiacaoMap : EntityTypeConfiguration<logpp_premiacao>
    {
        public logpp_premiacaoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.codlojasitef, t.codigoecupom });

            // Properties
            this.Property(t => t.codlojasitef)
                .IsRequired()
                .HasMaxLength(17);

            this.Property(t => t.codigoecupom)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.data_trn)
                .HasMaxLength(8);

            this.Property(t => t.hora_trn)
                .HasMaxLength(6);

            this.Property(t => t.terminal_logico)
                .HasMaxLength(8);

            this.Property(t => t.descricao)
                .HasMaxLength(20);

            this.Property(t => t.versao)
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("logpp_premiacao");
            this.Property(t => t.codlojasitef).HasColumnName("codlojasitef");
            this.Property(t => t.codigoecupom).HasColumnName("codigoecupom");
            this.Property(t => t.data_trn).HasColumnName("data_trn");
            this.Property(t => t.hora_trn).HasColumnName("hora_trn");
            this.Property(t => t.terminal_logico).HasColumnName("terminal_logico");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.quantidade).HasColumnName("quantidade");
            this.Property(t => t.versao).HasColumnName("versao");
        }
    }
}
