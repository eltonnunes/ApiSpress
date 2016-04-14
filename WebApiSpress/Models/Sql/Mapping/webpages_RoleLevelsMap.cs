using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class webpages_RoleLevelsMap : EntityTypeConfiguration<webpages_RoleLevels>
    {
        public webpages_RoleLevelsMap()
        {
            // Primary Key
            this.HasKey(t => t.LevelId);

            // Properties
            this.Property(t => t.LevelId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LevelName)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("webpages_RoleLevels");
            this.Property(t => t.LevelId).HasColumnName("LevelId");
            this.Property(t => t.LevelName).HasColumnName("LevelName");
        }
    }
}