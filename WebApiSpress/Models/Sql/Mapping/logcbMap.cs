using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class logcbMap : EntityTypeConfiguration<logcb>
    {
        public logcbMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cod_sit, t.data_sitef, t.nsu_sitef, t.codlojasitef });

            // Properties
            this.Property(t => t.cod_sit)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.data_sitef)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.nsu_sitef)
                .IsRequired()
                .HasMaxLength(9);

            this.Property(t => t.codlojasitef)
                .IsRequired()
                .HasMaxLength(17);

            this.Property(t => t.ident_pdv)
                .HasMaxLength(8);

            this.Property(t => t.numero_logico_pdv)
                .HasMaxLength(3);

            this.Property(t => t.hora_sitef)
                .HasMaxLength(6);

            this.Property(t => t.codigo_resposta)
                .HasMaxLength(14);

            this.Property(t => t.datahost)
                .HasMaxLength(8);

            this.Property(t => t.horahost)
                .HasMaxLength(6);

            this.Property(t => t.datacontabil)
                .HasMaxLength(8);

            this.Property(t => t.codigobarras)
                .HasMaxLength(48);

            this.Property(t => t.datavencto)
                .HasMaxLength(8);

            this.Property(t => t.nomecedente)
                .HasMaxLength(40);

            this.Property(t => t.nsuhost)
                .HasMaxLength(12);

            this.Property(t => t.valornominal)
                .HasMaxLength(17);

            this.Property(t => t.valortotalpago)
                .HasMaxLength(17);

            this.Property(t => t.valoracrescimo)
                .HasMaxLength(17);

            this.Property(t => t.valordesconto)
                .HasMaxLength(17);

            this.Property(t => t.autenticacao)
                .HasMaxLength(16);

            this.Property(t => t.codigoestabelecimentotef)
                .HasMaxLength(15);

            this.Property(t => t.nsuhosttef)
                .HasMaxLength(12);

            this.Property(t => t.datatef)
                .HasMaxLength(8);

            this.Property(t => t.nsusiteftef)
                .HasMaxLength(6);

            this.Property(t => t.cmc7)
                .HasMaxLength(34);

            this.Property(t => t.docoriginal)
                .HasMaxLength(12);

            this.Property(t => t.nsusiteforiginal)
                .HasMaxLength(6);

            this.Property(t => t.datasiteforiginal)
                .HasMaxLength(8);

            this.Property(t => t.codigoestabelecimento)
                .HasMaxLength(15);

            this.Property(t => t.codigoproc)
                .HasMaxLength(6);

            this.Property(t => t.sequencial)
                .HasMaxLength(2);

            this.Property(t => t.codigoif)
                .HasMaxLength(3);

            this.Property(t => t.codigooperador)
                .HasMaxLength(20);

            this.Property(t => t.autorizacao)
                .HasMaxLength(6);

            this.Property(t => t.codigo_erro)
                .HasMaxLength(3);

            this.Property(t => t.sequencial_erro)
                .HasMaxLength(3);

            this.Property(t => t.ipsitef)
                .HasMaxLength(256);

            this.Property(t => t.datapend)
                .HasMaxLength(8);

            this.Property(t => t.horapend)
                .HasMaxLength(6);

            this.Property(t => t.usuariopend)
                .HasMaxLength(20);

            this.Property(t => t.data_lote)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.hora_lote)
                .IsFixedLength()
                .HasMaxLength(6);

            this.Property(t => t.enviou_lote)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.cuponfiscal)
                .HasMaxLength(20);

            this.Property(t => t.datafiscal)
                .HasMaxLength(8);

            this.Property(t => t.horafiscal)
                .HasMaxLength(6);

            this.Property(t => t.supervisor)
                .HasMaxLength(20);

            this.Property(t => t.ipterminal)
                .HasMaxLength(15);

            this.Property(t => t.msgnegada)
                .HasMaxLength(60);

            this.Property(t => t.area)
                .HasMaxLength(4);

            this.Property(t => t.telefone)
                .HasMaxLength(10);

            this.Property(t => t.cod_concessionaria)
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("logcb");
            this.Property(t => t.cod_sit).HasColumnName("cod_sit");
            this.Property(t => t.data_sitef).HasColumnName("data_sitef");
            this.Property(t => t.nsu_sitef).HasColumnName("nsu_sitef");
            this.Property(t => t.codlojasitef).HasColumnName("codlojasitef");
            this.Property(t => t.ident_pdv).HasColumnName("ident_pdv");
            this.Property(t => t.numero_logico_pdv).HasColumnName("numero_logico_pdv");
            this.Property(t => t.hora_sitef).HasColumnName("hora_sitef");
            this.Property(t => t.cod_trnweb).HasColumnName("cod_trnweb");
            this.Property(t => t.estado_trn).HasColumnName("estado_trn");
            this.Property(t => t.codigo_resposta).HasColumnName("codigo_resposta");
            this.Property(t => t.datahost).HasColumnName("datahost");
            this.Property(t => t.horahost).HasColumnName("horahost");
            this.Property(t => t.datacontabil).HasColumnName("datacontabil");
            this.Property(t => t.tipodoc).HasColumnName("tipodoc");
            this.Property(t => t.modoentrada_cb).HasColumnName("modoentrada_cb");
            this.Property(t => t.modoarmazenamento_cb).HasColumnName("modoarmazenamento_cb");
            this.Property(t => t.codigobarras).HasColumnName("codigobarras");
            this.Property(t => t.datavencto).HasColumnName("datavencto");
            this.Property(t => t.nomecedente).HasColumnName("nomecedente");
            this.Property(t => t.nsuhost).HasColumnName("nsuhost");
            this.Property(t => t.valornominal).HasColumnName("valornominal");
            this.Property(t => t.valortotalpago).HasColumnName("valortotalpago");
            this.Property(t => t.valoracrescimo).HasColumnName("valoracrescimo");
            this.Property(t => t.valordesconto).HasColumnName("valordesconto");
            this.Property(t => t.autenticacao).HasColumnName("autenticacao");
            this.Property(t => t.formapagto).HasColumnName("formapagto");
            this.Property(t => t.codigoestabelecimentotef).HasColumnName("codigoestabelecimentotef");
            this.Property(t => t.nsuhosttef).HasColumnName("nsuhosttef");
            this.Property(t => t.datatef).HasColumnName("datatef");
            this.Property(t => t.nsusiteftef).HasColumnName("nsusiteftef");
            this.Property(t => t.codredetef).HasColumnName("codredetef");
            this.Property(t => t.funcaotef).HasColumnName("funcaotef");
            this.Property(t => t.modoentradacheque).HasColumnName("modoentradacheque");
            this.Property(t => t.cmc7).HasColumnName("cmc7");
            this.Property(t => t.docoriginal).HasColumnName("docoriginal");
            this.Property(t => t.nsusiteforiginal).HasColumnName("nsusiteforiginal");
            this.Property(t => t.datasiteforiginal).HasColumnName("datasiteforiginal");
            this.Property(t => t.codigotrn).HasColumnName("codigotrn");
            this.Property(t => t.codigogrupo).HasColumnName("codigogrupo");
            this.Property(t => t.codigosubfuncao).HasColumnName("codigosubfuncao");
            this.Property(t => t.codigoestabelecimento).HasColumnName("codigoestabelecimento");
            this.Property(t => t.codigoproc).HasColumnName("codigoproc");
            this.Property(t => t.sequencial).HasColumnName("sequencial");
            this.Property(t => t.versao).HasColumnName("versao");
            this.Property(t => t.nid).HasColumnName("nid");
            this.Property(t => t.codigoif).HasColumnName("codigoif");
            this.Property(t => t.codigooperador).HasColumnName("codigooperador");
            this.Property(t => t.autorizacao).HasColumnName("autorizacao");
            this.Property(t => t.origem_erro).HasColumnName("origem_erro");
            this.Property(t => t.codigo_erro).HasColumnName("codigo_erro");
            this.Property(t => t.sequencial_erro).HasColumnName("sequencial_erro");
            this.Property(t => t.ipsitef).HasColumnName("ipsitef");
            this.Property(t => t.datapend).HasColumnName("datapend");
            this.Property(t => t.horapend).HasColumnName("horapend");
            this.Property(t => t.origemestado).HasColumnName("origemestado");
            this.Property(t => t.usuariopend).HasColumnName("usuariopend");
            this.Property(t => t.num_lote).HasColumnName("num_lote");
            this.Property(t => t.data_lote).HasColumnName("data_lote");
            this.Property(t => t.hora_lote).HasColumnName("hora_lote");
            this.Property(t => t.enviou_lote).HasColumnName("enviou_lote");
            this.Property(t => t.tipodoc_fininvest).HasColumnName("tipodoc_fininvest");
            this.Property(t => t.cuponfiscal).HasColumnName("cuponfiscal");
            this.Property(t => t.datafiscal).HasColumnName("datafiscal");
            this.Property(t => t.horafiscal).HasColumnName("horafiscal");
            this.Property(t => t.supervisor).HasColumnName("supervisor");
            this.Property(t => t.ipterminal).HasColumnName("ipterminal");
            this.Property(t => t.msgnegada).HasColumnName("msgnegada");
            this.Property(t => t.area).HasColumnName("area");
            this.Property(t => t.telefone).HasColumnName("telefone");
            this.Property(t => t.cod_concessionaria).HasColumnName("cod_concessionaria");
            this.Property(t => t.se_cliente).HasColumnName("se_cliente");

            // Relationships
            this.HasRequired(t => t.transaco)
                .WithMany(t => t.logcbs)
                .HasForeignKey(d => d.cod_trnweb);
            this.HasOptional(t => t.tab_formapagto_cb)
                .WithMany(t => t.logcbs)
                .HasForeignKey(d => d.formapagto);
            this.HasOptional(t => t.tab_tipodoc_cb)
                .WithMany(t => t.logcbs)
                .HasForeignKey(d => d.tipodoc);

        }
    }
}
