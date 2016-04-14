using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class webpages_MethodsMap : EntityTypeConfiguration<webpages_Methods>
    {
        public webpages_MethodsMap()
        {
            // Primary Key
            this.HasKey(t => t.id_method);

            // Properties
            this.Property(t => t.ds_method)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.nm_method)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("webpages_Methods");
            this.Property(t => t.id_method).HasColumnName("id_method");
            this.Property(t => t.ds_method).HasColumnName("ds_method");
            this.Property(t => t.nm_method).HasColumnName("nm_method");
            this.Property(t => t.fl_menu).HasColumnName("fl_menu");
            this.Property(t => t.id_controller).HasColumnName("id_controller");

            // Relationships
            this.HasRequired(t => t.webpages_Controllers)
                .WithMany(t => t.webpages_Methods)
                .HasForeignKey(d => d.id_controller);

        }
    }
}
