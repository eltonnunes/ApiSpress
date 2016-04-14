using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class logpp_consultaMap : EntityTypeConfiguration<logpp_consulta>
    {
        public logpp_consultaMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cod_sit, t.data_trn, t.nsu_sitef, t.codlojasitef });

            // Properties
            this.Property(t => t.cod_sit)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.data_trn)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.nsu_sitef)
                .IsRequired()
                .HasMaxLength(12);

            this.Property(t => t.codlojasitef)
                .IsRequired()
                .HasMaxLength(17);

            this.Property(t => t.idt_terminal)
                .HasMaxLength(8);

            this.Property(t => t.codigo_resp)
                .HasMaxLength(3);

            this.Property(t => t.nsu_host)
                .HasMaxLength(12);

            this.Property(t => t.documento)
                .HasMaxLength(45);

            this.Property(t => t.descricao)
                .HasMaxLength(20);

            this.Property(t => t.terminal_logico)
                .HasMaxLength(8);

            this.Property(t => t.codigo_estab)
                .HasMaxLength(16);

            this.Property(t => t.hora_trn)
                .HasMaxLength(6);

            this.Property(t => t.codigoecupom)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("logpp_consulta");
            this.Property(t => t.cod_sit).HasColumnName("cod_sit");
            this.Property(t => t.data_trn).HasColumnName("data_trn");
            this.Property(t => t.nsu_sitef).HasColumnName("nsu_sitef");
            this.Property(t => t.codlojasitef).HasColumnName("codlojasitef");
            this.Property(t => t.idt_terminal).HasColumnName("idt_terminal");
            this.Property(t => t.cod_trnweb).HasColumnName("cod_trnweb");
            this.Property(t => t.estado_trn).HasColumnName("estado_trn");
            this.Property(t => t.codigo_resp).HasColumnName("codigo_resp");
            this.Property(t => t.nsu_host).HasColumnName("nsu_host");
            this.Property(t => t.documento).HasColumnName("documento");
            this.Property(t => t.descricao).HasColumnName("descricao");
            this.Property(t => t.quantidade).HasColumnName("quantidade");
            this.Property(t => t.terminal_logico).HasColumnName("terminal_logico");
            this.Property(t => t.codigo_estab).HasColumnName("codigo_estab");
            this.Property(t => t.hora_trn).HasColumnName("hora_trn");
            this.Property(t => t.codigoecupom).HasColumnName("codigoecupom");
        }
    }
}
