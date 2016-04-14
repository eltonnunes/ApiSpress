using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class webpages_UsersInRolesMap : EntityTypeConfiguration<webpages_UsersInRoles>
    {
        public webpages_UsersInRolesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserId, t.RoleId });

            // Properties
            this.Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RoleId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("webpages_UsersInRoles");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.RolePrincipal).HasColumnName("RolePrincipal");

            // Relationships
            this.HasRequired(t => t.webpages_Membership)
                .WithMany(t => t.webpages_UsersInRoles)
                .HasForeignKey(d => d.UserId);
            this.HasRequired(t => t.webpages_Roles)
                .WithMany(t => t.webpages_UsersInRoles)
                .HasForeignKey(d => d.RoleId);

        }
    }
}
