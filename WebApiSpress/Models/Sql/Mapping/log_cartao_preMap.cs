using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class log_cartao_preMap : EntityTypeConfiguration<log_cartao_pre>
    {
        public log_cartao_preMap()
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

            this.Property(t => t.dthr_trn)
                .HasMaxLength(16);

            this.Property(t => t.ident_pdv)
                .HasMaxLength(8);

            this.Property(t => t.numero_logico_pdv)
                .HasMaxLength(3);

            this.Property(t => t.nsu_host)
                .HasMaxLength(12);

            this.Property(t => t.cod_proc)
                .HasMaxLength(6);

            this.Property(t => t.cod_resposta)
                .HasMaxLength(2);

            this.Property(t => t.hora)
                .HasMaxLength(6);

            this.Property(t => t.valor)
                .HasMaxLength(12);

            this.Property(t => t.num_cartao)
                .HasMaxLength(30);

            this.Property(t => t.cod_estabelecimento)
                .HasMaxLength(16);

            this.Property(t => t.cod_autorizacao)
                .HasMaxLength(6);

            this.Property(t => t.data_host)
                .HasMaxLength(8);

            this.Property(t => t.hora_host)
                .HasMaxLength(6);

            this.Property(t => t.data_fiscal)
                .HasMaxLength(8);

            this.Property(t => t.hora_fiscal)
                .HasMaxLength(6);

            this.Property(t => t.cupom_fiscal)
                .HasMaxLength(10);

            this.Property(t => t.cod_operador)
                .HasMaxLength(20);

            this.Property(t => t.cod_supervisor)
                .HasMaxLength(20);

            this.Property(t => t.doc_original)
                .HasMaxLength(30);

            this.Property(t => t.cupom_fiscal_cancel)
                .HasMaxLength(10);

            this.Property(t => t.data_cancel)
                .HasMaxLength(8);

            this.Property(t => t.hora_cancel)
                .HasMaxLength(6);

            this.Property(t => t.nsu_sitef_cancel)
                .HasMaxLength(6);

            this.Property(t => t.cod_produto)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.flag_se_cartao_novo)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.flag_gerou_alerta)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.flag_aprovado_valor_menor)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.range_inicial_lote)
                .HasMaxLength(19);

            this.Property(t => t.range_final_lote)
                .HasMaxLength(19);

            this.Property(t => t.fabricante)
                .HasMaxLength(3);

            this.Property(t => t.data_lote)
                .HasMaxLength(4);

            this.Property(t => t.forma_pagamento_1)
                .HasMaxLength(2);

            this.Property(t => t.valor_pagamento_1)
                .HasMaxLength(9);

            this.Property(t => t.servico_tef_z_1)
                .HasMaxLength(12);

            this.Property(t => t.forma_pagamento_2)
                .HasMaxLength(2);

            this.Property(t => t.valor_pagamento_2)
                .HasMaxLength(9);

            this.Property(t => t.servico_tef_z_2)
                .HasMaxLength(12);

            this.Property(t => t.forma_pagamento_3)
                .HasMaxLength(2);

            this.Property(t => t.valor_pagamento_3)
                .HasMaxLength(9);

            this.Property(t => t.servico_tef_z_3)
                .HasMaxLength(12);

            this.Property(t => t.forma_pagamento_4)
                .HasMaxLength(2);

            this.Property(t => t.valor_pagamento_4)
                .HasMaxLength(9);

            this.Property(t => t.servico_tef_z_4)
                .HasMaxLength(12);

            this.Property(t => t.ipsitef)
                .HasMaxLength(15);

            this.Property(t => t.datapend)
                .HasMaxLength(8);

            this.Property(t => t.horapend)
                .HasMaxLength(6);

            this.Property(t => t.usuariopend)
                .HasMaxLength(20);

            this.Property(t => t.valor_compra)
                .HasMaxLength(12);

            this.Property(t => t.valor_total_bonus)
                .HasMaxLength(12);

            this.Property(t => t.pontos)
                .HasMaxLength(13);

            this.Property(t => t.ipterminal)
                .HasMaxLength(15);

            this.Property(t => t.cod_cliente)
                .HasMaxLength(32);

            this.Property(t => t.nome_produto)
                .HasMaxLength(50);

            this.Property(t => t.frentista)
                .HasMaxLength(20);

            this.Property(t => t.id_fornecedor)
                .HasMaxLength(4);

            this.Property(t => t.nome_fornecedor)
                .HasMaxLength(50);

            this.Property(t => t.nsu_reserva)
                .HasMaxLength(6);

            this.Property(t => t.portador)
                .HasMaxLength(30);

            this.Property(t => t.placa_veiculo)
                .HasMaxLength(7);

            this.Property(t => t.tipo_veiculo)
                .HasMaxLength(1);

            this.Property(t => t.ano_veiculo)
                .HasMaxLength(4);

            // Table & Column Mappings
            this.ToTable("log_cartao_pre");
            this.Property(t => t.cod_sit).HasColumnName("cod_sit");
            this.Property(t => t.data_sitef).HasColumnName("data_sitef");
            this.Property(t => t.nsu_sitef).HasColumnName("nsu_sitef");
            this.Property(t => t.codlojasitef).HasColumnName("codlojasitef");
            this.Property(t => t.dthr_trn).HasColumnName("dthr_trn");
            this.Property(t => t.ident_pdv).HasColumnName("ident_pdv");
            this.Property(t => t.numero_logico_pdv).HasColumnName("numero_logico_pdv");
            this.Property(t => t.nsu_host).HasColumnName("nsu_host");
            this.Property(t => t.estado_trn).HasColumnName("estado_trn");
            this.Property(t => t.cod_trn).HasColumnName("cod_trn");
            this.Property(t => t.cod_proc).HasColumnName("cod_proc");
            this.Property(t => t.cod_resposta).HasColumnName("cod_resposta");
            this.Property(t => t.hora).HasColumnName("hora");
            this.Property(t => t.valor).HasColumnName("valor");
            this.Property(t => t.num_cartao).HasColumnName("num_cartao");
            this.Property(t => t.nid_msg).HasColumnName("nid_msg");
            this.Property(t => t.num_controle).HasColumnName("num_controle");
            this.Property(t => t.versao).HasColumnName("versao");
            this.Property(t => t.cod_estabelecimento).HasColumnName("cod_estabelecimento");
            this.Property(t => t.cod_autorizacao).HasColumnName("cod_autorizacao");
            this.Property(t => t.data_host).HasColumnName("data_host");
            this.Property(t => t.hora_host).HasColumnName("hora_host");
            this.Property(t => t.data_fiscal).HasColumnName("data_fiscal");
            this.Property(t => t.hora_fiscal).HasColumnName("hora_fiscal");
            this.Property(t => t.cupom_fiscal).HasColumnName("cupom_fiscal");
            this.Property(t => t.cod_operador).HasColumnName("cod_operador");
            this.Property(t => t.cod_supervisor).HasColumnName("cod_supervisor");
            this.Property(t => t.doc_original).HasColumnName("doc_original");
            this.Property(t => t.cupom_fiscal_cancel).HasColumnName("cupom_fiscal_cancel");
            this.Property(t => t.data_cancel).HasColumnName("data_cancel");
            this.Property(t => t.hora_cancel).HasColumnName("hora_cancel");
            this.Property(t => t.nsu_sitef_cancel).HasColumnName("nsu_sitef_cancel");
            this.Property(t => t.cod_produto).HasColumnName("cod_produto");
            this.Property(t => t.forma_entrada_cartao).HasColumnName("forma_entrada_cartao");
            this.Property(t => t.flag_se_cartao_novo).HasColumnName("flag_se_cartao_novo");
            this.Property(t => t.flag_gerou_alerta).HasColumnName("flag_gerou_alerta");
            this.Property(t => t.flag_aprovado_valor_menor).HasColumnName("flag_aprovado_valor_menor");
            this.Property(t => t.range_inicial_lote).HasColumnName("range_inicial_lote");
            this.Property(t => t.range_final_lote).HasColumnName("range_final_lote");
            this.Property(t => t.fabricante).HasColumnName("fabricante");
            this.Property(t => t.data_lote).HasColumnName("data_lote");
            this.Property(t => t.qtde_forma_pagto).HasColumnName("qtde_forma_pagto");
            this.Property(t => t.forma_pagamento_1).HasColumnName("forma_pagamento_1");
            this.Property(t => t.valor_pagamento_1).HasColumnName("valor_pagamento_1");
            this.Property(t => t.servico_tef_z_1).HasColumnName("servico_tef_z_1");
            this.Property(t => t.forma_pagamento_2).HasColumnName("forma_pagamento_2");
            this.Property(t => t.valor_pagamento_2).HasColumnName("valor_pagamento_2");
            this.Property(t => t.servico_tef_z_2).HasColumnName("servico_tef_z_2");
            this.Property(t => t.forma_pagamento_3).HasColumnName("forma_pagamento_3");
            this.Property(t => t.valor_pagamento_3).HasColumnName("valor_pagamento_3");
            this.Property(t => t.servico_tef_z_3).HasColumnName("servico_tef_z_3");
            this.Property(t => t.forma_pagamento_4).HasColumnName("forma_pagamento_4");
            this.Property(t => t.valor_pagamento_4).HasColumnName("valor_pagamento_4");
            this.Property(t => t.servico_tef_z_4).HasColumnName("servico_tef_z_4");
            this.Property(t => t.captura).HasColumnName("captura");
            this.Property(t => t.ipsitef).HasColumnName("ipsitef");
            this.Property(t => t.datapend).HasColumnName("datapend");
            this.Property(t => t.horapend).HasColumnName("horapend");
            this.Property(t => t.origemestado).HasColumnName("origemestado");
            this.Property(t => t.usuariopend).HasColumnName("usuariopend");
            this.Property(t => t.temporesprede).HasColumnName("temporesprede");
            this.Property(t => t.temporesppdv).HasColumnName("temporesppdv");
            this.Property(t => t.valor_compra).HasColumnName("valor_compra");
            this.Property(t => t.valor_total_bonus).HasColumnName("valor_total_bonus");
            this.Property(t => t.pontos).HasColumnName("pontos");
            this.Property(t => t.idt_rede).HasColumnName("idt_rede");
            this.Property(t => t.ipterminal).HasColumnName("ipterminal");
            this.Property(t => t.cod_cliente).HasColumnName("cod_cliente");
            this.Property(t => t.se_cliente).HasColumnName("se_cliente");
            this.Property(t => t.nome_produto).HasColumnName("nome_produto");
            this.Property(t => t.frentista).HasColumnName("frentista");
            this.Property(t => t.id_fornecedor).HasColumnName("id_fornecedor");
            this.Property(t => t.nome_fornecedor).HasColumnName("nome_fornecedor");
            this.Property(t => t.nsu_reserva).HasColumnName("nsu_reserva");
            this.Property(t => t.portador).HasColumnName("portador");
            this.Property(t => t.placa_veiculo).HasColumnName("placa_veiculo");
            this.Property(t => t.tipo_veiculo).HasColumnName("tipo_veiculo");
            this.Property(t => t.ano_veiculo).HasColumnName("ano_veiculo");
        }
    }
}
