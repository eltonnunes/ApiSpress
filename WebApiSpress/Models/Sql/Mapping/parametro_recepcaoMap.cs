using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class parametro_recepcaoMap : EntityTypeConfiguration<parametro_recepcao>
    {
        public parametro_recepcaoMap()
        {
            // Primary Key
            this.HasKey(t => t.id_parametroRecepcao);

            // Properties
            this.Property(t => t.ds_email)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.ds_user)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.ds_pass)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.ds_host)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("parametro_recepcao");
            this.Property(t => t.id_parametroRecepcao).HasColumnName("id_parametroRecepcao");
            this.Property(t => t.id_grupoEmpresa).HasColumnName("id_grupoEmpresa");
            this.Property(t => t.ds_email).HasColumnName("ds_email");
            this.Property(t => t.ds_user).HasColumnName("ds_user");
            this.Property(t => t.ds_pass).HasColumnName("ds_pass");
            this.Property(t => t.qt_emailsRecepcionar).HasColumnName("qt_emailsRecepcionar");
            this.Property(t => t.qt_emailsRecepcionados).HasColumnName("qt_emailsRecepcionados");
            this.Property(t => t.tp_statusRecepcao).HasColumnName("tp_statusRecepcao");
            this.Property(t => t.dt_inicioRecepcao).HasColumnName("dt_inicioRecepcao");
            this.Property(t => t.dt_atualizacaoRecepcao).HasColumnName("dt_atualizacaoRecepcao");
            this.Property(t => t.dt_fimRecepcao).HasColumnName("dt_fimRecepcao");
            this.Property(t => t.qt_emailsProcessar).HasColumnName("qt_emailsProcessar");
            this.Property(t => t.qt_emailsProcessados).HasColumnName("qt_emailsProcessados");
            this.Property(t => t.tp_statusProcessamento).HasColumnName("tp_statusProcessamento");
            this.Property(t => t.dt_inicioProcessamento).HasColumnName("dt_inicioProcessamento");
            this.Property(t => t.dt_atualizacaoProcessamento).HasColumnName("dt_atualizacaoProcessamento");
            this.Property(t => t.dt_fimProcessamento).HasColumnName("dt_fimProcessamento");
            this.Property(t => t.tp_ssl).HasColumnName("tp_ssl");
            this.Property(t => t.ds_host).HasColumnName("ds_host");
            this.Property(t => t.nu_port).HasColumnName("nu_port");
        }
    }
}
