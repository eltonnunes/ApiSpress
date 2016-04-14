using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class recepcao_emailMap : EntityTypeConfiguration<recepcao_email>
    {
        public recepcao_emailMap()
        {
            // Primary Key
            this.HasKey(t => t.id_recepcaoEmail);

            // Properties
            this.Property(t => t.ds_subject)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("recepcao_email");
            this.Property(t => t.id_recepcaoEmail).HasColumnName("id_recepcaoEmail");
            this.Property(t => t.ds_from).HasColumnName("ds_from");
            this.Property(t => t.ds_cc).HasColumnName("ds_cc");
            this.Property(t => t.ds_bcc).HasColumnName("ds_bcc");
            this.Property(t => t.ds_subject).HasColumnName("ds_subject");
            this.Property(t => t.ds_body).HasColumnName("ds_body");
            this.Property(t => t.dt_recepcao).HasColumnName("dt_recepcao");
            this.Property(t => t.dt_resposta).HasColumnName("dt_resposta");
            this.Property(t => t.fl_status).HasColumnName("fl_status");
            this.Property(t => t.id_parametroRecepcao).HasColumnName("id_parametroRecepcao");
        }
    }
}
