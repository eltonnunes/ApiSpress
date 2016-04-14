using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class pedidoMap : EntityTypeConfiguration<pedido>
    {
        public pedidoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.nu_cnpjEmpresa, t.id_grupo, t.id_merca, t.nu_qtd, t.tp_embalagem, t.nu_qtdPorEmbalagem, t.dt_dataPedido, t.nu_pedidoInterno });

            // Properties
            this.Property(t => t.nu_cnpjEmpresa)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.id_grupo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_merca)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.nu_qtd)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.tp_embalagem)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.nu_qtdPorEmbalagem)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.nu_pedidoInterno)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("pedido", "pedido");
            this.Property(t => t.nu_cnpjEmpresa).HasColumnName("nu_cnpjEmpresa");
            this.Property(t => t.id_grupo).HasColumnName("id_grupo");
            this.Property(t => t.id_merca).HasColumnName("id_merca");
            this.Property(t => t.nu_qtd).HasColumnName("nu_qtd");
            this.Property(t => t.tx_icms).HasColumnName("tx_icms");
            this.Property(t => t.tx_ipi).HasColumnName("tx_ipi");
            this.Property(t => t.tp_embalagem).HasColumnName("tp_embalagem");
            this.Property(t => t.nu_qtdPorEmbalagem).HasColumnName("nu_qtdPorEmbalagem");
            this.Property(t => t.dt_dataPedido).HasColumnName("dt_dataPedido");
            this.Property(t => t.nu_pedidoInterno).HasColumnName("nu_pedidoInterno");

            // Relationships
            this.HasRequired(t => t.empresa)
                .WithMany(t => t.pedidoes)
                .HasForeignKey(d => d.nu_cnpjEmpresa);
            this.HasRequired(t => t.grupo_empresa)
                .WithMany(t => t.pedidoes)
                .HasForeignKey(d => d.id_grupo);
            this.HasRequired(t => t.merca)
                .WithMany(t => t.pedidoes)
                .HasForeignKey(d => d.id_merca);

        }
    }
}
