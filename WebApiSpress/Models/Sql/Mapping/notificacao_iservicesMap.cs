using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class notificacao_iservicesMap : EntityTypeConfiguration<notificacao_iservices>
    {
        public notificacao_iservicesMap()
        {
            // Primary Key
            this.HasKey(t => t.id_Notificacao);

            // Properties
            this.Property(t => t.nm_Notificacao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.ds_Notificacao)
                .IsRequired();

            this.Property(t => t.ds_protocolo)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("notificacao_iservices");
            this.Property(t => t.id_Notificacao).HasColumnName("id_Notificacao");
            this.Property(t => t.nm_Notificacao).HasColumnName("nm_Notificacao");
            this.Property(t => t.ds_Notificacao).HasColumnName("ds_Notificacao");
            this.Property(t => t.ds_Erro).HasColumnName("ds_Erro");
            this.Property(t => t.ds_CodigoErro).HasColumnName("ds_CodigoErro");
            this.Property(t => t.ds_protocolo).HasColumnName("ds_protocolo");
            this.Property(t => t.dt_Notificacao).HasColumnName("dt_Notificacao");
            this.Property(t => t.tp_Prioridade).HasColumnName("tp_Prioridade");
            this.Property(t => t.tp_Status).HasColumnName("tp_Status");
            this.Property(t => t.id_Servico).HasColumnName("id_Servico");
        }
    }
}
