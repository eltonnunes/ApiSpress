using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class logservcelMap : EntityTypeConfiguration<logservcel>
    {
        public logservcelMap()
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

            this.Property(t => t.ident_pdv)
                .HasMaxLength(8);

            this.Property(t => t.numero_logico_pdv)
                .HasMaxLength(3);

            this.Property(t => t.nsu_host)
                .HasMaxLength(9);

            this.Property(t => t.codigo_proc)
                .HasMaxLength(6);

            this.Property(t => t.codigo_resp)
                .HasMaxLength(2);

            this.Property(t => t.cod_concessionaria)
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.area)
                .HasMaxLength(2);

            this.Property(t => t.telefone)
                .HasMaxLength(8);

            this.Property(t => t.dv_telefone)
                .HasMaxLength(2);

            this.Property(t => t.hora_trn)
                .HasMaxLength(6);

            this.Property(t => t.valor_trn)
                .HasMaxLength(12);

            this.Property(t => t.codigo_if)
                .HasMaxLength(11);

            this.Property(t => t.codigo_empresa_original)
                .HasMaxLength(8);

            this.Property(t => t.codigo_empresa_filial)
                .HasMaxLength(8);

            this.Property(t => t.codigo_estab_filial)
                .HasMaxLength(15);

            this.Property(t => t.bit22)
                .HasMaxLength(3);

            this.Property(t => t.numcartao)
                .HasMaxLength(19);

            this.Property(t => t.autorizacao)
                .HasMaxLength(6);

            this.Property(t => t.h_codigo_resp)
                .HasMaxLength(2);

            this.Property(t => t.h_data)
                .HasMaxLength(4);

            this.Property(t => t.h_hora)
                .HasMaxLength(6);

            this.Property(t => t.h_nsu_host)
                .HasMaxLength(9);

            this.Property(t => t.h_codigo_estab_filial)
                .HasMaxLength(15);

            this.Property(t => t.h_autorizacao)
                .HasMaxLength(6);

            this.Property(t => t.h_doc_cancel)
                .HasMaxLength(9);

            this.Property(t => t.h_data_cancel)
                .HasMaxLength(4);

            this.Property(t => t.h_hora_cancel)
                .HasMaxLength(6);

            this.Property(t => t.h_rede_autoriz)
                .HasMaxLength(16);

            this.Property(t => t.h_nsu_sitef)
                .HasMaxLength(9);

            this.Property(t => t.data_trn_tef)
                .HasMaxLength(8);

            this.Property(t => t.cep)
                .HasMaxLength(5);

            this.Property(t => t.autorizacao_concessionaria)
                .HasMaxLength(14);

            this.Property(t => t.ipsitef)
                .HasMaxLength(15);

            this.Property(t => t.datapend)
                .HasMaxLength(8);

            this.Property(t => t.horapend)
                .HasMaxLength(6);

            this.Property(t => t.usuariopend)
                .HasMaxLength(20);

            this.Property(t => t.cod_operadora)
                .HasMaxLength(3);

            this.Property(t => t.nome_operadora)
                .HasMaxLength(20);

            this.Property(t => t.nome_filial)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("logservcel");
            this.Property(t => t.cod_sit).HasColumnName("cod_sit");
            this.Property(t => t.data_trn).HasColumnName("data_trn");
            this.Property(t => t.nsu_sitef).HasColumnName("nsu_sitef");
            this.Property(t => t.codlojasitef).HasColumnName("codlojasitef");
            this.Property(t => t.ident_pdv).HasColumnName("ident_pdv");
            this.Property(t => t.numero_logico_pdv).HasColumnName("numero_logico_pdv");
            this.Property(t => t.nsu_host).HasColumnName("nsu_host");
            this.Property(t => t.estado_trn).HasColumnName("estado_trn");
            this.Property(t => t.cod_trnweb).HasColumnName("cod_trnweb");
            this.Property(t => t.codigo_proc).HasColumnName("codigo_proc");
            this.Property(t => t.codigo_resp).HasColumnName("codigo_resp");
            this.Property(t => t.concessionaria).HasColumnName("concessionaria");
            this.Property(t => t.cod_concessionaria).HasColumnName("cod_concessionaria");
            this.Property(t => t.area).HasColumnName("area");
            this.Property(t => t.telefone).HasColumnName("telefone");
            this.Property(t => t.dv_telefone).HasColumnName("dv_telefone");
            this.Property(t => t.hora_trn).HasColumnName("hora_trn");
            this.Property(t => t.valor_trn).HasColumnName("valor_trn");
            this.Property(t => t.nid).HasColumnName("nid");
            this.Property(t => t.versao).HasColumnName("versao");
            this.Property(t => t.codigo_if).HasColumnName("codigo_if");
            this.Property(t => t.codigo_empresa_original).HasColumnName("codigo_empresa_original");
            this.Property(t => t.codigo_empresa_filial).HasColumnName("codigo_empresa_filial");
            this.Property(t => t.codigo_estab_filial).HasColumnName("codigo_estab_filial");
            this.Property(t => t.bit22).HasColumnName("bit22");
            this.Property(t => t.numcartao).HasColumnName("numcartao");
            this.Property(t => t.autorizacao).HasColumnName("autorizacao");
            this.Property(t => t.h_codigo_resp).HasColumnName("h_codigo_resp");
            this.Property(t => t.h_data).HasColumnName("h_data");
            this.Property(t => t.h_hora).HasColumnName("h_hora");
            this.Property(t => t.h_nsu_host).HasColumnName("h_nsu_host");
            this.Property(t => t.h_codigo_estab_filial).HasColumnName("h_codigo_estab_filial");
            this.Property(t => t.h_autorizacao).HasColumnName("h_autorizacao");
            this.Property(t => t.h_doc_cancel).HasColumnName("h_doc_cancel");
            this.Property(t => t.h_data_cancel).HasColumnName("h_data_cancel");
            this.Property(t => t.h_hora_cancel).HasColumnName("h_hora_cancel");
            this.Property(t => t.h_rede_autoriz).HasColumnName("h_rede_autoriz");
            this.Property(t => t.h_nsu_sitef).HasColumnName("h_nsu_sitef");
            this.Property(t => t.h_codigo_sit).HasColumnName("h_codigo_sit");
            this.Property(t => t.cod_trn_tef).HasColumnName("cod_trn_tef");
            this.Property(t => t.data_trn_tef).HasColumnName("data_trn_tef");
            this.Property(t => t.cep).HasColumnName("cep");
            this.Property(t => t.autorizacao_concessionaria).HasColumnName("autorizacao_concessionaria");
            this.Property(t => t.ipsitef).HasColumnName("ipsitef");
            this.Property(t => t.datapend).HasColumnName("datapend");
            this.Property(t => t.horapend).HasColumnName("horapend");
            this.Property(t => t.origemestado).HasColumnName("origemestado");
            this.Property(t => t.usuariopend).HasColumnName("usuariopend");
            this.Property(t => t.cod_operadora).HasColumnName("cod_operadora");
            this.Property(t => t.nome_operadora).HasColumnName("nome_operadora");
            this.Property(t => t.nome_filial).HasColumnName("nome_filial");
            this.Property(t => t.codigo_trn).HasColumnName("codigo_trn");
            this.Property(t => t.codigo_subtrn_pdv).HasColumnName("codigo_subtrn_pdv");
            this.Property(t => t.codigo_subtrn_host).HasColumnName("codigo_subtrn_host");
        }
    }
}
