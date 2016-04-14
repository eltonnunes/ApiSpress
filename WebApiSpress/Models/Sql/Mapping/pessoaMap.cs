using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class pessoaMap : EntityTypeConfiguration<pessoa>
    {
        public pessoaMap()
        {
            // Primary Key
            this.HasKey(t => t.id_pesssoa);

            // Properties
            this.Property(t => t.nm_pessoa)
                .IsRequired()
                .HasMaxLength(120);

            this.Property(t => t.nu_telefone)
                .HasMaxLength(50);

            this.Property(t => t.nu_ramal)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("pessoa");
            this.Property(t => t.id_pesssoa).HasColumnName("id_pesssoa");
            this.Property(t => t.nm_pessoa).HasColumnName("nm_pessoa");
            this.Property(t => t.dt_nascimento).HasColumnName("dt_nascimento");
            this.Property(t => t.nu_telefone).HasColumnName("nu_telefone");
            this.Property(t => t.nu_ramal).HasColumnName("nu_ramal");
        }
    }
}
