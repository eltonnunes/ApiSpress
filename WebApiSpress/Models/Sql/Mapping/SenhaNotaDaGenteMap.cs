using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class SenhaNotaDaGenteMap : EntityTypeConfiguration<SenhaNotaDaGente>
    {
        public SenhaNotaDaGenteMap()
        {
            // Primary Key
            this.HasKey(t => t.id_SenhaNotaDaGente);

            // Properties
            this.Property(t => t.ds_password)
                .IsRequired()
                .HasMaxLength(120);

            this.Property(t => t.nu_cnpj)
                .IsFixedLength()
                .HasMaxLength(14);

            // Table & Column Mappings
            this.ToTable("SenhaNotaDaGente", "notadagente");
            this.Property(t => t.id_SenhaNotaDaGente).HasColumnName("id_SenhaNotaDaGente");
            this.Property(t => t.ds_password).HasColumnName("ds_password");
            this.Property(t => t.dt_alteracao).HasColumnName("dt_alteracao");
            this.Property(t => t.dt_situacao).HasColumnName("dt_situacao");
            this.Property(t => t.fl_status).HasColumnName("fl_status");
            this.Property(t => t.nu_cnpj).HasColumnName("nu_cnpj");
        }
    }
}
