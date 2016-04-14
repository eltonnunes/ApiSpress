using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class sitefweb_projectsMap : EntityTypeConfiguration<sitefweb_projects>
    {
        public sitefweb_projectsMap()
        {
            // Primary Key
            this.HasKey(t => t.project_version);

            // Properties
            this.Property(t => t.project_version)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.basico)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.conciliacao)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.cb)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.recarga)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.infocard)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.pbm)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.pinpad)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.sav)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.bbbatimento)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.gestao)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.promocao)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.rpc)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.raizen)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.sorteio)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.jamyr)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("sitefweb_projects");
            this.Property(t => t.project_version).HasColumnName("project_version");
            this.Property(t => t.basico).HasColumnName("basico");
            this.Property(t => t.conciliacao).HasColumnName("conciliacao");
            this.Property(t => t.cb).HasColumnName("cb");
            this.Property(t => t.recarga).HasColumnName("recarga");
            this.Property(t => t.infocard).HasColumnName("infocard");
            this.Property(t => t.pbm).HasColumnName("pbm");
            this.Property(t => t.pinpad).HasColumnName("pinpad");
            this.Property(t => t.sav).HasColumnName("sav");
            this.Property(t => t.bbbatimento).HasColumnName("bbbatimento");
            this.Property(t => t.gestao).HasColumnName("gestao");
            this.Property(t => t.promocao).HasColumnName("promocao");
            this.Property(t => t.rpc).HasColumnName("rpc");
            this.Property(t => t.raizen).HasColumnName("raizen");
            this.Property(t => t.sorteio).HasColumnName("sorteio");
            this.Property(t => t.jamyr).HasColumnName("jamyr");
        }
    }
}
