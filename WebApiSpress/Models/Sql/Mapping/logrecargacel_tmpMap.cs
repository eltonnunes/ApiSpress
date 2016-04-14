using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class logrecargacel_tmpMap : EntityTypeConfiguration<logrecargacel_tmp>
    {
        public logrecargacel_tmpMap()
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

            this.Property(t => t.numero_logico_pdv)
                .HasMaxLength(3);

            this.Property(t => t.codigo_proc)
                .HasMaxLength(6);

            this.Property(t => t.valor_trn)
                .HasMaxLength(12);

            this.Property(t => t.hora_trn)
                .HasMaxLength(6);

            this.Property(t => t.nsu_host)
                .HasMaxLength(12);

            this.Property(t => t.codigoestabelecimento)
                .HasMaxLength(15);

            this.Property(t => t.codoperadora)
                .HasMaxLength(3);

            this.Property(t => t.codfilial)
                .HasMaxLength(6);

            this.Property(t => t.area)
                .HasMaxLength(3);

            this.Property(t => t.telefone)
                .HasMaxLength(8);

            this.Property(t => t.dv_telefone)
                .HasMaxLength(3);

            this.Property(t => t.codigo_resp)
                .HasMaxLength(2);

            this.Property(t => t.cod_autoriz)
                .HasMaxLength(14);

            this.Property(t => t.nome_operadora)
                .HasMaxLength(20);

            this.Property(t => t.nome_filial)
                .HasMaxLength(20);

            this.Property(t => t.forma_pagamento_1)
                .HasMaxLength(2);

            this.Property(t => t.valor_pagamento_1)
                .HasMaxLength(12);

            this.Property(t => t.data_trn_tef_1)
                .HasMaxLength(8);

            this.Property(t => t.nsu_trn_tef_1)
                .HasMaxLength(9);

            this.Property(t => t.forma_pagamento_2)
                .HasMaxLength(2);

            this.Property(t => t.valor_pagamento_2)
                .HasMaxLength(12);

            this.Property(t => t.data_trn_tef_2)
                .HasMaxLength(8);

            this.Property(t => t.nsu_trn_tef_2)
                .HasMaxLength(9);

            this.Property(t => t.forma_pagamento_3)
                .HasMaxLength(2);

            this.Property(t => t.valor_pagamento_3)
                .HasMaxLength(12);

            this.Property(t => t.data_trn_tef_3)
                .HasMaxLength(8);

            this.Property(t => t.nsu_trn_tef_3)
                .HasMaxLength(9);

            this.Property(t => t.forma_pagamento_4)
                .HasMaxLength(2);

            this.Property(t => t.valor_pagamento_4)
                .HasMaxLength(12);

            this.Property(t => t.data_trn_tef_4)
                .HasMaxLength(8);

            this.Property(t => t.nsu_trn_tef_4)
                .HasMaxLength(9);

            this.Property(t => t.ipsitef)
                .HasMaxLength(15);

            this.Property(t => t.tipo_trn_tef)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.cod_empresa_tef)
                .HasMaxLength(8);

            this.Property(t => t.datapend)
                .HasMaxLength(8);

            this.Property(t => t.horapend)
                .HasMaxLength(6);

            this.Property(t => t.usuariopend)
                .HasMaxLength(20);

            this.Property(t => t.operador)
                .HasMaxLength(20);

            this.Property(t => t.supervisor)
                .HasMaxLength(20);

            this.Property(t => t.datafiscal)
                .HasMaxLength(8);

            this.Property(t => t.horafiscal)
                .HasMaxLength(6);

            this.Property(t => t.cuponfiscal)
                .HasMaxLength(20);

            this.Property(t => t.codcli)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("logrecargacel_tmp");
            this.Property(t => t.cod_sit).HasColumnName("cod_sit");
            this.Property(t => t.data_trn).HasColumnName("data_trn");
            this.Property(t => t.nsu_sitef).HasColumnName("nsu_sitef");
            this.Property(t => t.codlojasitef).HasColumnName("codlojasitef");
            this.Property(t => t.idt_terminal).HasColumnName("idt_terminal");
            this.Property(t => t.numero_logico_pdv).HasColumnName("numero_logico_pdv");
            this.Property(t => t.cod_trnweb).HasColumnName("cod_trnweb");
            this.Property(t => t.codigo_trn).HasColumnName("codigo_trn");
            this.Property(t => t.codigo_subtrn_pdv).HasColumnName("codigo_subtrn_pdv");
            this.Property(t => t.codigo_subtrn_host).HasColumnName("codigo_subtrn_host");
            this.Property(t => t.codigo_proc).HasColumnName("codigo_proc");
            this.Property(t => t.valor_trn).HasColumnName("valor_trn");
            this.Property(t => t.hora_trn).HasColumnName("hora_trn");
            this.Property(t => t.nsu_host).HasColumnName("nsu_host");
            this.Property(t => t.codigoestabelecimento).HasColumnName("codigoestabelecimento");
            this.Property(t => t.codoperadora).HasColumnName("codoperadora");
            this.Property(t => t.codfilial).HasColumnName("codfilial");
            this.Property(t => t.area).HasColumnName("area");
            this.Property(t => t.telefone).HasColumnName("telefone");
            this.Property(t => t.dv_telefone).HasColumnName("dv_telefone");
            this.Property(t => t.versao).HasColumnName("versao");
            this.Property(t => t.estado_trn).HasColumnName("estado_trn");
            this.Property(t => t.nid).HasColumnName("nid");
            this.Property(t => t.codigo_resp).HasColumnName("codigo_resp");
            this.Property(t => t.cod_autoriz).HasColumnName("cod_autoriz");
            this.Property(t => t.nome_operadora).HasColumnName("nome_operadora");
            this.Property(t => t.nome_filial).HasColumnName("nome_filial");
            this.Property(t => t.qtde_forma_pagto).HasColumnName("qtde_forma_pagto");
            this.Property(t => t.forma_pagamento_1).HasColumnName("forma_pagamento_1");
            this.Property(t => t.valor_pagamento_1).HasColumnName("valor_pagamento_1");
            this.Property(t => t.data_trn_tef_1).HasColumnName("data_trn_tef_1");
            this.Property(t => t.nsu_trn_tef_1).HasColumnName("nsu_trn_tef_1");
            this.Property(t => t.codigo_rede_tef_1).HasColumnName("codigo_rede_tef_1");
            this.Property(t => t.forma_pagamento_2).HasColumnName("forma_pagamento_2");
            this.Property(t => t.valor_pagamento_2).HasColumnName("valor_pagamento_2");
            this.Property(t => t.data_trn_tef_2).HasColumnName("data_trn_tef_2");
            this.Property(t => t.nsu_trn_tef_2).HasColumnName("nsu_trn_tef_2");
            this.Property(t => t.codigo_rede_tef_2).HasColumnName("codigo_rede_tef_2");
            this.Property(t => t.forma_pagamento_3).HasColumnName("forma_pagamento_3");
            this.Property(t => t.valor_pagamento_3).HasColumnName("valor_pagamento_3");
            this.Property(t => t.data_trn_tef_3).HasColumnName("data_trn_tef_3");
            this.Property(t => t.nsu_trn_tef_3).HasColumnName("nsu_trn_tef_3");
            this.Property(t => t.codigo_rede_tef_3).HasColumnName("codigo_rede_tef_3");
            this.Property(t => t.forma_pagamento_4).HasColumnName("forma_pagamento_4");
            this.Property(t => t.valor_pagamento_4).HasColumnName("valor_pagamento_4");
            this.Property(t => t.data_trn_tef_4).HasColumnName("data_trn_tef_4");
            this.Property(t => t.nsu_trn_tef_4).HasColumnName("nsu_trn_tef_4");
            this.Property(t => t.codigo_rede_tef_4).HasColumnName("codigo_rede_tef_4");
            this.Property(t => t.ipsitef).HasColumnName("ipsitef");
            this.Property(t => t.tipo_trn_tef).HasColumnName("tipo_trn_tef");
            this.Property(t => t.cod_empresa_tef).HasColumnName("cod_empresa_tef");
            this.Property(t => t.datapend).HasColumnName("datapend");
            this.Property(t => t.horapend).HasColumnName("horapend");
            this.Property(t => t.origemestado).HasColumnName("origemestado");
            this.Property(t => t.usuariopend).HasColumnName("usuariopend");
            this.Property(t => t.operador).HasColumnName("operador");
            this.Property(t => t.supervisor).HasColumnName("supervisor");
            this.Property(t => t.datafiscal).HasColumnName("datafiscal");
            this.Property(t => t.horafiscal).HasColumnName("horafiscal");
            this.Property(t => t.cuponfiscal).HasColumnName("cuponfiscal");
            this.Property(t => t.codcli).HasColumnName("codcli");
            this.Property(t => t.captura).HasColumnName("captura");
        }
    }
}
