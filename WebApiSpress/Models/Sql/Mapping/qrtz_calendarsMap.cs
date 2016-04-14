using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class qrtz_calendarsMap : EntityTypeConfiguration<qrtz_calendars>
    {
        public qrtz_calendarsMap()
        {
            // Primary Key
            this.HasKey(t => t.calendar_name);

            // Properties
            this.Property(t => t.calendar_name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.calendar)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("qrtz_calendars");
            this.Property(t => t.calendar_name).HasColumnName("calendar_name");
            this.Property(t => t.calendar).HasColumnName("calendar");
        }
    }
}
