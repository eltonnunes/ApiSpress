using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class logcb_det_tmpMap : EntityTypeConfiguration<logcb_det_tmp>
    {
        public logcb_det_tmpMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cod_sit, t.data_sitef, t.nsu_sitef, t.codlojasitef, t.seq });

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

            this.Property(t => t.seq)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.cod_originador)
                .HasMaxLength(2);

            this.Property(t => t.formapagto_det)
                .HasMaxLength(3);

            this.Property(t => t.valor)
                .HasMaxLength(17);

            this.Property(t => t.cmc7)
                .HasMaxLength(34);

            this.Property(t => t.host_tef)
                .HasMaxLength(5);

            this.Property(t => t.nsu_host_tef)
                .HasMaxLength(12);

            this.Property(t => t.data_tef)
                .HasMaxLength(8);

            this.Property(t => t.cod_estab_tef)
                .HasMaxLength(15);

            this.Property(t => t.codlojasitef_tef)
                .HasMaxLength(8);

            this.Property(t => t.nro_recibo)
                .HasMaxLength(15);

            this.Property(t => t.digito)
                .HasMaxLength(2);

            this.Property(t => t.nsusiteftef)
                .HasMaxLength(6);

            // Table & Column Mappings
            this.ToTable("logcb_det_tmp");
            this.Property(t => t.cod_sit).HasColumnName("cod_sit");
            this.Property(t => t.data_sitef).HasColumnName("data_sitef");
            this.Property(t => t.nsu_sitef).HasColumnName("nsu_sitef");
            this.Property(t => t.codlojasitef).HasColumnName("codlojasitef");
            this.Property(t => t.seq).HasColumnName("seq");
            this.Property(t => t.origem).HasColumnName("origem");
            this.Property(t => t.cod_originador).HasColumnName("cod_originador");
            this.Property(t => t.formapagto_det).HasColumnName("formapagto_det");
            this.Property(t => t.formapagto).HasColumnName("formapagto");
            this.Property(t => t.valor).HasColumnName("valor");
            this.Property(t => t.modoentradacheque).HasColumnName("modoentradacheque");
            this.Property(t => t.cmc7).HasColumnName("cmc7");
            this.Property(t => t.host_tef).HasColumnName("host_tef");
            this.Property(t => t.nsu_host_tef).HasColumnName("nsu_host_tef");
            this.Property(t => t.data_tef).HasColumnName("data_tef");
            this.Property(t => t.cod_estab_tef).HasColumnName("cod_estab_tef");
            this.Property(t => t.codlojasitef_tef).HasColumnName("codlojasitef_tef");
            this.Property(t => t.nro_recibo).HasColumnName("nro_recibo");
            this.Property(t => t.banco).HasColumnName("banco");
            this.Property(t => t.agencia).HasColumnName("agencia");
            this.Property(t => t.conta).HasColumnName("conta");
            this.Property(t => t.digito).HasColumnName("digito");
            this.Property(t => t.cpf_cnpj).HasColumnName("cpf_cnpj");
            this.Property(t => t.codigo_receita).HasColumnName("codigo_receita");
            this.Property(t => t.codigo_pagto).HasColumnName("codigo_pagto");
            this.Property(t => t.identificardor).HasColumnName("identificardor");
            this.Property(t => t.nsusiteftef).HasColumnName("nsusiteftef");
            this.Property(t => t.codredetef).HasColumnName("codredetef");
            this.Property(t => t.funcaotef).HasColumnName("funcaotef");
        }
    }
}
