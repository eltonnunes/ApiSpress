using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class webpages_ControllersMap : EntityTypeConfiguration<webpages_Controllers>
    {
        public webpages_ControllersMap()
        {
            // Primary Key
            this.HasKey(t => t.id_controller);

            // Properties
            this.Property(t => t.ds_controller)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.nm_controller)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.nuOrdem)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("webpages_Controllers", "dbo");
            this.Property(t => t.id_controller).HasColumnName("id_controller");
            this.Property(t => t.ds_controller).HasColumnName("ds_controller");
            this.Property(t => t.nm_controller).HasColumnName("nm_controller");
            this.Property(t => t.fl_menu).HasColumnName("fl_menu");
            this.Property(t => t.id_subController).HasColumnName("id_subController");
            this.Property(t => t.nuOrdem).HasColumnName("nuOrdem");

            // Relationships
            this.HasOptional(t => t.webpages_Controllers2)
                .WithMany(t => t.webpages_Controllers1)
                .HasForeignKey(d => d.id_subController);

        }
    }
}
