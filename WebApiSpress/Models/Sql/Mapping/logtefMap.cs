using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class logtefMap : EntityTypeConfiguration<WebApiSpress.Models.Sql.logtef>
    {
        public logtefMap()
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
                .HasMaxLength(9);

            this.Property(t => t.codlojasitef)
                .IsRequired()
                .HasMaxLength(17);

            this.Property(t => t.idt_terminal)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.hora_trn)
                .HasMaxLength(6);

            this.Property(t => t.dthr_trn)
                .HasMaxLength(16);

            this.Property(t => t.valor_trn)
                .HasMaxLength(12);

            this.Property(t => t.documento)
                .HasMaxLength(45);

            this.Property(t => t.data_venc)
                .HasMaxLength(4);

            this.Property(t => t.nsu_host)
                .HasMaxLength(15);

            this.Property(t => t.codigo_resp)
                .HasMaxLength(3);

            this.Property(t => t.num_parcelas)
                .HasMaxLength(2);

            this.Property(t => t.data_lanc)
                .HasMaxLength(8);

            this.Property(t => t.codigo_proc)
                .HasMaxLength(6);

            this.Property(t => t.codigo_estab)
                .HasMaxLength(16);

            this.Property(t => t.cod_autoriz)
                .HasMaxLength(20);

            this.Property(t => t.codmoeda)
                .HasMaxLength(3);

            this.Property(t => t.operador)
                .HasMaxLength(20);

            this.Property(t => t.supervisor)
                .HasMaxLength(20);

            this.Property(t => t.datapend)
                .HasMaxLength(8);

            this.Property(t => t.horapend)
                .HasMaxLength(6);

            this.Property(t => t.datasonda)
                .HasMaxLength(8);

            this.Property(t => t.horasonda)
                .HasMaxLength(6);

            this.Property(t => t.cdrespsonda)
                .HasMaxLength(2);

            this.Property(t => t.nsucanchost)
                .HasMaxLength(15);

            this.Property(t => t.nsudesfsitef)
                .HasMaxLength(6);

            this.Property(t => t.usuariopend)
                .HasMaxLength(20);

            this.Property(t => t.ipterminal)
                .HasMaxLength(15);

            this.Property(t => t.datafiscal)
                .HasMaxLength(8);

            this.Property(t => t.horafiscal)
                .HasMaxLength(6);

            this.Property(t => t.cuponfiscal)
                .HasMaxLength(20);

            this.Property(t => t.ipsitef)
                .HasMaxLength(256);

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

            this.Property(t => t.trnaprovadapp)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.valordescontopp)
                .HasMaxLength(6);

            this.Property(t => t.valor_estorno_parcial)
                .HasMaxLength(12);

            this.Property(t => t.codigoissuer)
                .HasMaxLength(11);

            this.Property(t => t.frentista)
                .HasMaxLength(2);

            this.Property(t => t.cpf)
                .HasMaxLength(11);

            this.Property(t => t.lote_fechado)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.codigo_plano)
                .HasMaxLength(4);

            this.Property(t => t.valorservico)
                .HasMaxLength(12);

            this.Property(t => t.valorprincipal)
                .HasMaxLength(12);

            this.Property(t => t.pagto_carne)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.documento_sec)
                .HasMaxLength(11);

            this.Property(t => t.moeda)
                .HasMaxLength(3);

            this.Property(t => t.tipo_oper)
                .HasMaxLength(2);

            this.Property(t => t.taxa_cobrada)
                .HasMaxLength(12);

            this.Property(t => t.id_sitef)
                .HasMaxLength(20);

            this.Property(t => t.cep)
                .HasMaxLength(9);

            this.Property(t => t.celular)
                .HasMaxLength(11);

            // Table & Column Mappings
            this.ToTable("logtef");
            this.Property(t => t.cod_sit).HasColumnName("cod_sit");
            this.Property(t => t.data_trn).HasColumnName("data_trn");
            this.Property(t => t.nsu_sitef).HasColumnName("nsu_sitef");
            this.Property(t => t.codlojasitef).HasColumnName("codlojasitef");
            this.Property(t => t.idt_terminal).HasColumnName("idt_terminal");
            this.Property(t => t.hora_trn).HasColumnName("hora_trn");
            this.Property(t => t.dthr_trn).HasColumnName("dthr_trn");
            this.Property(t => t.cod_trnweb).HasColumnName("cod_trnweb");
            this.Property(t => t.cdmodoentrada).HasColumnName("cdmodoentrada");
            this.Property(t => t.valor_trn).HasColumnName("valor_trn");
            this.Property(t => t.documento).HasColumnName("documento");
            this.Property(t => t.data_venc).HasColumnName("data_venc");
            this.Property(t => t.idt_rede).HasColumnName("idt_rede");
            this.Property(t => t.idt_produto).HasColumnName("idt_produto");
            this.Property(t => t.estado_trn).HasColumnName("estado_trn");
            this.Property(t => t.nsu_host).HasColumnName("nsu_host");
            this.Property(t => t.codigo_resp).HasColumnName("codigo_resp");
            this.Property(t => t.temporesprede).HasColumnName("temporesprede");
            this.Property(t => t.temporesppdv).HasColumnName("temporesppdv");
            this.Property(t => t.idt_bandeira).HasColumnName("idt_bandeira");
            this.Property(t => t.num_parcelas).HasColumnName("num_parcelas");
            this.Property(t => t.data_lanc).HasColumnName("data_lanc");
            this.Property(t => t.codigo_proc).HasColumnName("codigo_proc");
            this.Property(t => t.codigo_estab).HasColumnName("codigo_estab");
            this.Property(t => t.cod_autoriz).HasColumnName("cod_autoriz");
            this.Property(t => t.codmoeda).HasColumnName("codmoeda");
            this.Property(t => t.operador).HasColumnName("operador");
            this.Property(t => t.supervisor).HasColumnName("supervisor");
            this.Property(t => t.datapend).HasColumnName("datapend");
            this.Property(t => t.horapend).HasColumnName("horapend");
            this.Property(t => t.datasonda).HasColumnName("datasonda");
            this.Property(t => t.horasonda).HasColumnName("horasonda");
            this.Property(t => t.cdrespsonda).HasColumnName("cdrespsonda");
            this.Property(t => t.nsucanchost).HasColumnName("nsucanchost");
            this.Property(t => t.nsudesfsitef).HasColumnName("nsudesfsitef");
            this.Property(t => t.origemestado).HasColumnName("origemestado");
            this.Property(t => t.usuariopend).HasColumnName("usuariopend");
            this.Property(t => t.ipterminal).HasColumnName("ipterminal");
            this.Property(t => t.datafiscal).HasColumnName("datafiscal");
            this.Property(t => t.horafiscal).HasColumnName("horafiscal");
            this.Property(t => t.cuponfiscal).HasColumnName("cuponfiscal");
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
            this.Property(t => t.trnaprovadapp).HasColumnName("trnaprovadapp");
            this.Property(t => t.valordescontopp).HasColumnName("valordescontopp");
            this.Property(t => t.valor_estorno_parcial).HasColumnName("valor_estorno_parcial");
            this.Property(t => t.codigoissuer).HasColumnName("codigoissuer");
            this.Property(t => t.frentista).HasColumnName("frentista");
            this.Property(t => t.cpf).HasColumnName("cpf");
            this.Property(t => t.se_cliente).HasColumnName("se_cliente");
            this.Property(t => t.lote_fechado).HasColumnName("lote_fechado");
            this.Property(t => t.codigo_plano).HasColumnName("codigo_plano");
            this.Property(t => t.valorservico).HasColumnName("valorservico");
            this.Property(t => t.valorprincipal).HasColumnName("valorprincipal");
            this.Property(t => t.pagto_carne).HasColumnName("pagto_carne");
            this.Property(t => t.documento_sec).HasColumnName("documento_sec");
            this.Property(t => t.moeda).HasColumnName("moeda");
            this.Property(t => t.tipo_oper).HasColumnName("tipo_oper");
            this.Property(t => t.taxa_cobrada).HasColumnName("taxa_cobrada");
            this.Property(t => t.id_sitef).HasColumnName("id_sitef");
            this.Property(t => t.cep).HasColumnName("cep");
            this.Property(t => t.celular).HasColumnName("celular");
            this.Property(t => t.dtImportacao).HasColumnName("dtImportacao");

            // Relationships
            this.HasOptional(t => t.modoentrada)
                .WithMany(t => t.logtefs)
                .HasForeignKey(d => d.cdmodoentrada);
            this.HasRequired(t => t.sitrede)
                .WithMany(t => t.logtefs)
                .HasForeignKey(d => d.cod_sit);
            this.HasRequired(t => t.transaco)
                .WithMany(t => t.logtefs)
                .HasForeignKey(d => d.cod_trnweb);
            this.HasRequired(t => t.rede)
                .WithMany(t => t.logtefs)
                .HasForeignKey(d => d.idt_rede);

        }
    }
}
