using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class logvendaofflineMap : EntityTypeConfiguration<logvendaoffline>
    {
        public logvendaofflineMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cod_sit, t.cod_empresa, t.data_trn, t.hora_trn });

            // Properties
            this.Property(t => t.cod_sit)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.cod_empresa)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.data_trn)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.hora_trn)
                .IsRequired()
                .HasMaxLength(6);

            this.Property(t => t.dataz)
                .HasMaxLength(8);

            this.Property(t => t.cartao)
                .HasMaxLength(19);

            this.Property(t => t.vencimento)
                .HasMaxLength(4);

            this.Property(t => t.terminal)
                .HasMaxLength(8);

            this.Property(t => t.valor_compra)
                .HasMaxLength(12);

            this.Property(t => t.data_fiscal)
                .HasMaxLength(8);

            this.Property(t => t.hora_fiscal)
                .HasMaxLength(6);

            this.Property(t => t.cupon_fiscal)
                .HasMaxLength(20);

            this.Property(t => t.id_voo)
                .HasMaxLength(8);

            this.Property(t => t.mensagem)
                .HasMaxLength(32);

            this.Property(t => t.cod_resposta)
                .HasMaxLength(2);

            this.Property(t => t.nsu_host)
                .HasMaxLength(9);

            this.Property(t => t.cod_estab)
                .HasMaxLength(15);

            this.Property(t => t.cod_autoriz)
                .HasMaxLength(6);

            this.Property(t => t.doc_cancel)
                .HasMaxLength(9);

            this.Property(t => t.data_cancel)
                .HasMaxLength(8);

            this.Property(t => t.hora_cancel)
                .HasMaxLength(6);

            this.Property(t => t.rede_autz)
                .HasMaxLength(16);

            this.Property(t => t.nsu_sitef)
                .HasMaxLength(6);

            this.Property(t => t.cod_rede)
                .HasMaxLength(2);

            this.Property(t => t.data_evento)
                .HasMaxLength(8);

            this.Property(t => t.hora_evento)
                .HasMaxLength(6);

            // Table & Column Mappings
            this.ToTable("logvendaoffline");
            this.Property(t => t.cod_sit).HasColumnName("cod_sit");
            this.Property(t => t.cod_empresa).HasColumnName("cod_empresa");
            this.Property(t => t.data_trn).HasColumnName("data_trn");
            this.Property(t => t.hora_trn).HasColumnName("hora_trn");
            this.Property(t => t.dataz).HasColumnName("dataz");
            this.Property(t => t.cartao).HasColumnName("cartao");
            this.Property(t => t.vencimento).HasColumnName("vencimento");
            this.Property(t => t.terminal).HasColumnName("terminal");
            this.Property(t => t.valor_compra).HasColumnName("valor_compra");
            this.Property(t => t.data_fiscal).HasColumnName("data_fiscal");
            this.Property(t => t.hora_fiscal).HasColumnName("hora_fiscal");
            this.Property(t => t.cupon_fiscal).HasColumnName("cupon_fiscal");
            this.Property(t => t.id_voo).HasColumnName("id_voo");
            this.Property(t => t.rede_dest).HasColumnName("rede_dest");
            this.Property(t => t.cod_resp_hdr).HasColumnName("cod_resp_hdr");
            this.Property(t => t.mensagem).HasColumnName("mensagem");
            this.Property(t => t.cod_resposta).HasColumnName("cod_resposta");
            this.Property(t => t.nsu_host).HasColumnName("nsu_host");
            this.Property(t => t.cod_estab).HasColumnName("cod_estab");
            this.Property(t => t.cod_autoriz).HasColumnName("cod_autoriz");
            this.Property(t => t.doc_cancel).HasColumnName("doc_cancel");
            this.Property(t => t.data_cancel).HasColumnName("data_cancel");
            this.Property(t => t.hora_cancel).HasColumnName("hora_cancel");
            this.Property(t => t.rede_autz).HasColumnName("rede_autz");
            this.Property(t => t.nsu_sitef).HasColumnName("nsu_sitef");
            this.Property(t => t.cod_rede).HasColumnName("cod_rede");
            this.Property(t => t.data_evento).HasColumnName("data_evento");
            this.Property(t => t.hora_evento).HasColumnName("hora_evento");
        }
    }
}
