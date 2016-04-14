using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class CodigoEstabelecimentoMap : EntityTypeConfiguration<CodigoEstabelecimento>
    {
        public CodigoEstabelecimentoMap()
        {
            // Primary Key
            this.HasKey(t => t.cod_Empresa);

            // Properties
            this.Property(t => t.cod_Empresa)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("CodigoEstabelecimento");
            this.Property(t => t.cod_Empresa).HasColumnName("cod_Empresa");
            this.Property(t => t.cod_RedeCard).HasColumnName("cod_RedeCard");
            this.Property(t => t.cod_Visanet).HasColumnName("cod_Visanet");
            this.Property(t => t.cod_TecBan).HasColumnName("cod_TecBan");
            this.Property(t => t.cod_Amex).HasColumnName("cod_Amex");
            this.Property(t => t.cod_Banese).HasColumnName("cod_Banese");
            this.Property(t => t.cod_Nutricash).HasColumnName("cod_Nutricash");
            this.Property(t => t.cod_RedeBase).HasColumnName("cod_RedeBase");
            this.Property(t => t.cod_Ecapture).HasColumnName("cod_Ecapture");
            this.Property(t => t.cod_Sodexo).HasColumnName("cod_Sodexo");
            this.Property(t => t.cod_VRSmart).HasColumnName("cod_VRSmart");
            this.Property(t => t.cod_Ticket).HasColumnName("cod_Ticket");
        }
    }
}
