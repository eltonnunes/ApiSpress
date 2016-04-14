using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class ConnectionStringMap : EntityTypeConfiguration<ConnectionString>
    {
        public ConnectionStringMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ConnectionStrings)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Rede)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("ConnectionStrings", "admin");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ConnectionStrings).HasColumnName("ConnectionStrings");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Rede).HasColumnName("Rede");
            this.Property(t => t.Id_Grupo).HasColumnName("Id_Grupo");

            // Relationships
            this.HasRequired(t => t.grupo_empresa)
                .WithMany(t => t.ConnectionStrings)
                .HasForeignKey(d => d.Id_Grupo);

        }
    }
}
