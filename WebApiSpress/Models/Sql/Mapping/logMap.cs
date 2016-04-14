using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class logMap : EntityTypeConfiguration<log>
    {
        public logMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("log");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.log1).HasColumnName("log");
        }
    }
}
