using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class convtransacoMap : EntityTypeConfiguration<convtransaco>
    {
        public convtransacoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cod_trnsitef, t.cod_sit, t.codigo_proc, t.parcelado, t.cod_subfunc, t.cdmodoentrada, t.operacaotef, t.cod_func });

            // Properties
            this.Property(t => t.cod_trnsitef)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.cod_sit)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.codigo_proc)
                .IsRequired()
                .HasMaxLength(6);

            this.Property(t => t.parcelado)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.cod_subfunc)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.cdmodoentrada)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.operacaotef)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.cod_func)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("convtransacoes");
            this.Property(t => t.cod_trnsitef).HasColumnName("cod_trnsitef");
            this.Property(t => t.cod_sit).HasColumnName("cod_sit");
            this.Property(t => t.codigo_proc).HasColumnName("codigo_proc");
            this.Property(t => t.parcelado).HasColumnName("parcelado");
            this.Property(t => t.cod_subfunc).HasColumnName("cod_subfunc");
            this.Property(t => t.cod_trnweb).HasColumnName("cod_trnweb");
            this.Property(t => t.cdmodoentrada).HasColumnName("cdmodoentrada");
            this.Property(t => t.operacaotef).HasColumnName("operacaotef");
            this.Property(t => t.funcconv).HasColumnName("funcconv");
            this.Property(t => t.cod_func).HasColumnName("cod_func");

            // Relationships
            this.HasRequired(t => t.modoentrada)
                .WithMany(t => t.convtransacoes)
                .HasForeignKey(d => d.cdmodoentrada);
            this.HasRequired(t => t.sitrede)
                .WithMany(t => t.convtransacoes)
                .HasForeignKey(d => d.cod_sit);
            this.HasRequired(t => t.transaco)
                .WithMany(t => t.convtransacoes)
                .HasForeignKey(d => d.cod_trnweb);

        }
    }
}
