using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class ctl_expMap : EntityTypeConfiguration<ctl_exp>
    {
        public ctl_expMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id_cliente, t.id_rede });

            // Properties
            this.Property(t => t.id_cliente)
                .IsRequired()
                .HasMaxLength(21);

            this.Property(t => t.id_rede)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.data_mvto)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.dth_ult_trn)
                .IsRequired()
                .HasMaxLength(14);

            this.Property(t => t.hora_corte)
                .HasMaxLength(6);

            this.Property(t => t.ind_corte)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.ind_data)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("ctl_exp");
            this.Property(t => t.id_cliente).HasColumnName("id_cliente");
            this.Property(t => t.id_rede).HasColumnName("id_rede");
            this.Property(t => t.data_mvto).HasColumnName("data_mvto");
            this.Property(t => t.dth_ult_trn).HasColumnName("dth_ult_trn");
            this.Property(t => t.hora_corte).HasColumnName("hora_corte");
            this.Property(t => t.ind_corte).HasColumnName("ind_corte");
            this.Property(t => t.ind_data).HasColumnName("ind_data");
            this.Property(t => t.se_cliente).HasColumnName("se_cliente");
        }
    }
}
