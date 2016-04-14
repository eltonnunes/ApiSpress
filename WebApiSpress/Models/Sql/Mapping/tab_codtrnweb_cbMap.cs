using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tab_codtrnweb_cbMap : EntityTypeConfiguration<tab_codtrnweb_cb>
    {
        public tab_codtrnweb_cbMap()
        {
            // Primary Key
            this.HasKey(t => t.cod_trnweb);

            // Properties
            this.Property(t => t.cod_trnweb)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("tab_codtrnweb_cb");
            this.Property(t => t.cod_trnweb).HasColumnName("cod_trnweb");

            // Relationships
            this.HasRequired(t => t.transaco)
                .WithOptional(t => t.tab_codtrnweb_cb);

        }
    }
}
