using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class logtef_tmpMap : EntityTypeConfiguration<logtef_tmp>
    {
        public logtef_tmpMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Cod_Sit, t.Data_Trn, t.Nsu_Sitef, t.CodLojaSitef });

            // Properties
            this.Property(t => t.Cod_Sit)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Data_Trn)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.Nsu_Sitef)
                .IsRequired()
                .HasMaxLength(9);

            this.Property(t => t.CodLojaSitef)
                .IsRequired()
                .HasMaxLength(17);

            this.Property(t => t.Idt_Terminal)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.Hora_Trn)
                .HasMaxLength(6);

            this.Property(t => t.DtHr_Trn)
                .HasMaxLength(16);

            this.Property(t => t.Valor_Trn)
                .HasMaxLength(12);

            this.Property(t => t.Documento)
                .HasMaxLength(45);

            this.Property(t => t.Data_Venc)
                .HasMaxLength(4);

            this.Property(t => t.Nsu_Host)
                .HasMaxLength(12);

            this.Property(t => t.Codigo_Resp)
                .HasMaxLength(3);

            this.Property(t => t.Num_Parcelas)
                .HasMaxLength(2);

            this.Property(t => t.Data_Lanc)
                .HasMaxLength(8);

            this.Property(t => t.Codigo_Proc)
                .HasMaxLength(6);

            this.Property(t => t.Codigo_Estab)
                .HasMaxLength(16);

            this.Property(t => t.Cod_Autoriz)
                .HasMaxLength(20);

            this.Property(t => t.CodMoeda)
                .HasMaxLength(3);

            this.Property(t => t.Operador)
                .HasMaxLength(20);

            this.Property(t => t.Supervisor)
                .HasMaxLength(20);

            this.Property(t => t.DataPend)
                .HasMaxLength(8);

            this.Property(t => t.HoraPend)
                .HasMaxLength(6);

            this.Property(t => t.DataSonda)
                .HasMaxLength(8);

            this.Property(t => t.HoraSonda)
                .HasMaxLength(6);

            this.Property(t => t.CdRespSonda)
                .HasMaxLength(2);

            this.Property(t => t.NsuCancHost)
                .HasMaxLength(9);

            this.Property(t => t.NsuDesfSitef)
                .HasMaxLength(6);

            this.Property(t => t.UsuarioPend)
                .HasMaxLength(20);

            this.Property(t => t.IpTerminal)
                .HasMaxLength(15);

            this.Property(t => t.DataFiscal)
                .HasMaxLength(8);

            this.Property(t => t.HoraFiscal)
                .HasMaxLength(6);

            this.Property(t => t.CuponFiscal)
                .HasMaxLength(20);

            this.Property(t => t.ipsitef)
                .HasMaxLength(15);

            this.Property(t => t.codcli)
                .HasMaxLength(32);

            this.Property(t => t.taxa_embarque)
                .HasMaxLength(12);

            this.Property(t => t.terminal_logico)
                .HasMaxLength(8);

            this.Property(t => t.valor_saque)
                .HasMaxLength(12);

            this.Property(t => t.nome_operadora)
                .HasMaxLength(20);

            this.Property(t => t.cod_prod_valegas)
                .HasMaxLength(7);

            this.Property(t => t.cod_oper_valegas)
                .HasMaxLength(5);

            this.Property(t => t.tipocartao)
                .HasMaxLength(6);

            this.Property(t => t.cod_bandeira)
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("logtef_tmp");
            this.Property(t => t.Cod_Sit).HasColumnName("Cod_Sit");
            this.Property(t => t.Data_Trn).HasColumnName("Data_Trn");
            this.Property(t => t.Nsu_Sitef).HasColumnName("Nsu_Sitef");
            this.Property(t => t.CodLojaSitef).HasColumnName("CodLojaSitef");
            this.Property(t => t.Idt_Terminal).HasColumnName("Idt_Terminal");
            this.Property(t => t.Hora_Trn).HasColumnName("Hora_Trn");
            this.Property(t => t.DtHr_Trn).HasColumnName("DtHr_Trn");
            this.Property(t => t.Cod_TrnWeb).HasColumnName("Cod_TrnWeb");
            this.Property(t => t.CdModoEntrada).HasColumnName("CdModoEntrada");
            this.Property(t => t.Valor_Trn).HasColumnName("Valor_Trn");
            this.Property(t => t.Documento).HasColumnName("Documento");
            this.Property(t => t.Data_Venc).HasColumnName("Data_Venc");
            this.Property(t => t.Idt_Rede).HasColumnName("Idt_Rede");
            this.Property(t => t.Idt_Produto).HasColumnName("Idt_Produto");
            this.Property(t => t.Estado_Trn).HasColumnName("Estado_Trn");
            this.Property(t => t.Nsu_Host).HasColumnName("Nsu_Host");
            this.Property(t => t.Codigo_Resp).HasColumnName("Codigo_Resp");
            this.Property(t => t.TempoRespRede).HasColumnName("TempoRespRede");
            this.Property(t => t.TempoRespPDV).HasColumnName("TempoRespPDV");
            this.Property(t => t.Idt_Bandeira).HasColumnName("Idt_Bandeira");
            this.Property(t => t.Num_Parcelas).HasColumnName("Num_Parcelas");
            this.Property(t => t.Data_Lanc).HasColumnName("Data_Lanc");
            this.Property(t => t.Codigo_Proc).HasColumnName("Codigo_Proc");
            this.Property(t => t.Codigo_Estab).HasColumnName("Codigo_Estab");
            this.Property(t => t.Cod_Autoriz).HasColumnName("Cod_Autoriz");
            this.Property(t => t.CodMoeda).HasColumnName("CodMoeda");
            this.Property(t => t.Operador).HasColumnName("Operador");
            this.Property(t => t.Supervisor).HasColumnName("Supervisor");
            this.Property(t => t.DataPend).HasColumnName("DataPend");
            this.Property(t => t.HoraPend).HasColumnName("HoraPend");
            this.Property(t => t.DataSonda).HasColumnName("DataSonda");
            this.Property(t => t.HoraSonda).HasColumnName("HoraSonda");
            this.Property(t => t.CdRespSonda).HasColumnName("CdRespSonda");
            this.Property(t => t.NsuCancHost).HasColumnName("NsuCancHost");
            this.Property(t => t.NsuDesfSitef).HasColumnName("NsuDesfSitef");
            this.Property(t => t.OrigemEstado).HasColumnName("OrigemEstado");
            this.Property(t => t.UsuarioPend).HasColumnName("UsuarioPend");
            this.Property(t => t.IpTerminal).HasColumnName("IpTerminal");
            this.Property(t => t.DataFiscal).HasColumnName("DataFiscal");
            this.Property(t => t.HoraFiscal).HasColumnName("HoraFiscal");
            this.Property(t => t.CuponFiscal).HasColumnName("CuponFiscal");
            this.Property(t => t.ipsitef).HasColumnName("ipsitef");
            this.Property(t => t.codcli).HasColumnName("codcli");
            this.Property(t => t.captura).HasColumnName("captura");
            this.Property(t => t.taxa_embarque).HasColumnName("taxa_embarque");
            this.Property(t => t.terminal_logico).HasColumnName("terminal_logico");
            this.Property(t => t.valor_saque).HasColumnName("valor_saque");
            this.Property(t => t.origem_trn).HasColumnName("origem_trn");
            this.Property(t => t.nome_operadora).HasColumnName("nome_operadora");
            this.Property(t => t.cod_prod_valegas).HasColumnName("cod_prod_valegas");
            this.Property(t => t.cod_oper_valegas).HasColumnName("cod_oper_valegas");
            this.Property(t => t.tipocartao).HasColumnName("tipocartao");
            this.Property(t => t.trnecommerce).HasColumnName("trnecommerce");
            this.Property(t => t.cod_bandeira).HasColumnName("cod_bandeira");
        }
    }
}
