
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class tbBancoParametroMap : EntityTypeConfiguration<tbBancoParametro>
    {
        public tbBancoParametroMap()
        {
            // Primary Key
            this.HasKey(t => new { t.cdBanco, t.dsMemo });

            // Properties
            this.Property(t => t.dsMemo)
                .IsRequired();

            this.Property(t => t.cdBanco)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.dsTipo)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.nrCnpj)
                .IsFixedLength()
                .HasMaxLength(14);


            // Table & Column Mappings
            this.ToTable("tbBancoParametro", "card");
            this.Property(t => t.cdBanco).HasColumnName("cdBanco");
            this.Property(t => t.dsMemo).HasColumnName("dsMemo");
            this.Property(t => t.cdAdquirente).HasColumnName("cdAdquirente");
            this.Property(t => t.dsTipo).HasColumnName("dsTipo");
            this.Property(t => t.flVisivel).HasColumnName("flVisivel");
            this.Property(t => t.nrCnpj).HasColumnName("nrCnpj");

            // Relationships
            /*this.HasOptional(t => t.tbAdquirente)
                .WithMany(t => t.tbBancoParametros)
                .HasForeignKey(d => d.cdAdquirente);*/
            this.HasOptional(t => t.empresa)
                .WithMany(t => t.tbBancoParametros)
                .HasForeignKey(d => d.nrCnpj);

        }
    }
}
