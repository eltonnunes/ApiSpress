using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class logconsultaMap : EntityTypeConfiguration<logconsulta>
    {
        public logconsultaMap()
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

            this.Property(t => t.hora_trn)
                .HasMaxLength(6);

            this.Property(t => t.codigo_resposta)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.tipo_pessoa)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.cgc_cpf)
                .HasMaxLength(14);

            this.Property(t => t.num_banco)
                .HasMaxLength(4);

            this.Property(t => t.num_agencia)
                .HasMaxLength(4);

            this.Property(t => t.numerocheque)
                .HasMaxLength(12);

            this.Property(t => t.valor)
                .HasMaxLength(12);

            this.Property(t => t.nsu_host)
                .HasMaxLength(12);

            this.Property(t => t.codigo_estab)
                .HasMaxLength(15);

            this.Property(t => t.usuariopend)
                .HasMaxLength(20);

            this.Property(t => t.datapend)
                .HasMaxLength(8);

            this.Property(t => t.horapend)
                .HasMaxLength(6);

            this.Property(t => t.ipsitef)
                .HasMaxLength(15);

            this.Property(t => t.data_cheque)
                .HasMaxLength(8);

            this.Property(t => t.tipo_entrada)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.cmc7_inicial)
                .HasMaxLength(34);

            this.Property(t => t.cmc7_final)
                .HasMaxLength(34);

            this.Property(t => t.qtde_cheques)
                .HasMaxLength(2);

            this.Property(t => t.numerochequefinal)
                .HasMaxLength(12);

            this.Property(t => t.telefone_ddd)
                .HasMaxLength(4);

            this.Property(t => t.telefone)
                .HasMaxLength(10);

            this.Property(t => t.msg_resp)
                .HasMaxLength(50);

            this.Property(t => t.cod_erro)
                .HasMaxLength(3);

            this.Property(t => t.codigo_consulta)
                .HasMaxLength(8);

            this.Property(t => t.servico)
                .HasMaxLength(3);

            this.Property(t => t.usuario)
                .HasMaxLength(8);

            this.Property(t => t.motivo_exclusao)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.num_conta)
                .HasMaxLength(16);

            // Table & Column Mappings
            this.ToTable("logconsulta");
            this.Property(t => t.cod_sit).HasColumnName("cod_sit");
            this.Property(t => t.data_trn).HasColumnName("data_trn");
            this.Property(t => t.nsu_sitef).HasColumnName("nsu_sitef");
            this.Property(t => t.codlojasitef).HasColumnName("codlojasitef");
            this.Property(t => t.ident_pdv).HasColumnName("ident_pdv");
            this.Property(t => t.numero_logico_pdv).HasColumnName("numero_logico_pdv");
            this.Property(t => t.hora_trn).HasColumnName("hora_trn");
            this.Property(t => t.idt_produto).HasColumnName("idt_produto");
            this.Property(t => t.cod_trnweb).HasColumnName("cod_trnweb");
            this.Property(t => t.estado_trn).HasColumnName("estado_trn");
            this.Property(t => t.codigo_resposta).HasColumnName("codigo_resposta");
            this.Property(t => t.tipo_pessoa).HasColumnName("tipo_pessoa");
            this.Property(t => t.cgc_cpf).HasColumnName("cgc_cpf");
            this.Property(t => t.num_banco).HasColumnName("num_banco");
            this.Property(t => t.num_agencia).HasColumnName("num_agencia");
            this.Property(t => t.numerocheque).HasColumnName("numerocheque");
            this.Property(t => t.valor).HasColumnName("valor");
            this.Property(t => t.nsu_host).HasColumnName("nsu_host");
            this.Property(t => t.codigo_estab).HasColumnName("codigo_estab");
            this.Property(t => t.origemestado).HasColumnName("origemestado");
            this.Property(t => t.usuariopend).HasColumnName("usuariopend");
            this.Property(t => t.datapend).HasColumnName("datapend");
            this.Property(t => t.horapend).HasColumnName("horapend");
            this.Property(t => t.ipsitef).HasColumnName("ipsitef");
            this.Property(t => t.data_cheque).HasColumnName("data_cheque");
            this.Property(t => t.tipo_entrada).HasColumnName("tipo_entrada");
            this.Property(t => t.cmc7_inicial).HasColumnName("cmc7_inicial");
            this.Property(t => t.cmc7_final).HasColumnName("cmc7_final");
            this.Property(t => t.qtde_cheques).HasColumnName("qtde_cheques");
            this.Property(t => t.numerochequefinal).HasColumnName("numerochequefinal");
            this.Property(t => t.telefone_ddd).HasColumnName("telefone_ddd");
            this.Property(t => t.telefone).HasColumnName("telefone");
            this.Property(t => t.msg_resp).HasColumnName("msg_resp");
            this.Property(t => t.cod_erro).HasColumnName("cod_erro");
            this.Property(t => t.codigo_consulta).HasColumnName("codigo_consulta");
            this.Property(t => t.servico).HasColumnName("servico");
            this.Property(t => t.usuario).HasColumnName("usuario");
            this.Property(t => t.motivo_exclusao).HasColumnName("motivo_exclusao");
            this.Property(t => t.num_conta).HasColumnName("num_conta");
        }
    }
}
