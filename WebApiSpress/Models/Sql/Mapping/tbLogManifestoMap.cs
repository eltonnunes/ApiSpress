using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbLogManifestoMap : EntityTypeConfiguration<tbLogManifesto>
    {
        public tbLogManifestoMap()
        {
            // Primary Key
            this.HasKey(t => t.idLog);

            // Properties
            this.Property(t => t.dsXmlEntrada)
                .IsRequired();

            this.Property(t => t.dsRetorno)
                .HasMaxLength(50);

            this.Property(t => t.dsMetodo)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("tbLogManifesto", "admin");
            this.Property(t => t.idLog).HasColumnName("idLog");
            this.Property(t => t.dtLogInicio).HasColumnName("dtLogInicio");
            this.Property(t => t.dsXmlEntrada).HasColumnName("dsXmlEntrada");
            this.Property(t => t.cdRetorno).HasColumnName("cdRetorno");
            this.Property(t => t.dsRetorno).HasColumnName("dsRetorno");
            this.Property(t => t.dsMetodo).HasColumnName("dsMetodo");
            this.Property(t => t.dsXmlRetorno).HasColumnName("dsXmlRetorno");
            this.Property(t => t.dtLogFim).HasColumnName("dtLogFim");
        }
    }
}
