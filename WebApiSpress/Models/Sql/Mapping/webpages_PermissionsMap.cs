using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class webpages_PermissionsMap : EntityTypeConfiguration<webpages_Permissions>
    {
        public webpages_PermissionsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id_roles, t.id_method });

            // Properties
            this.Property(t => t.id_roles)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_method)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("webpages_Permissions");
            this.Property(t => t.id_roles).HasColumnName("id_roles");
            this.Property(t => t.id_method).HasColumnName("id_method");
            this.Property(t => t.fl_principal).HasColumnName("fl_principal");

            // Relationships
            this.HasRequired(t => t.webpages_Methods)
                .WithMany(t => t.webpages_Permissions)
                .HasForeignKey(d => d.id_method);
            this.HasRequired(t => t.webpages_Roles)
                .WithMany(t => t.webpages_Permissions)
                .HasForeignKey(d => d.id_roles);

        }
    }
}
