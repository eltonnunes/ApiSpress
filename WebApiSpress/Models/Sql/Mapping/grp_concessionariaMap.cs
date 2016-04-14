using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class grp_concessionariaMap : EntityTypeConfiguration<grp_concessionaria>
    {
        public grp_concessionariaMap()
        {
            // Primary Key
            this.HasKey(t => t.cod_grp_concessionaria);

            // Properties
            this.Property(t => t.cod_grp_concessionaria)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.descr_grp_concessionaria)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("grp_concessionaria");
            this.Property(t => t.cod_grp_concessionaria).HasColumnName("cod_grp_concessionaria");
            this.Property(t => t.descr_grp_concessionaria).HasColumnName("descr_grp_concessionaria");
        }
    }
}
