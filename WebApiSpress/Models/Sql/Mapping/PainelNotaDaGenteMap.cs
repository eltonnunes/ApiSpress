using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class PainelNotaDaGenteMap : EntityTypeConfiguration<PainelNotaDaGente>
    {
        public PainelNotaDaGenteMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Cnpj, t.DsFantacia, t.Pdv });

            // Properties
            this.Property(t => t.Cnpj)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(14);

            this.Property(t => t.DsFantacia)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Pdv)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("PainelNotaDaGente", "notadagente");
            this.Property(t => t.Cnpj).HasColumnName("Cnpj");
            this.Property(t => t.DsFantacia).HasColumnName("DsFantacia");
            this.Property(t => t.Pdv).HasColumnName("Pdv");
            this.Property(t => t.C1).HasColumnName("1");
            this.Property(t => t.C2).HasColumnName("2");
            this.Property(t => t.C3).HasColumnName("3");
            this.Property(t => t.C4).HasColumnName("4");
            this.Property(t => t.C5).HasColumnName("5");
            this.Property(t => t.C6).HasColumnName("6");
            this.Property(t => t.C7).HasColumnName("7");
            this.Property(t => t.C8).HasColumnName("8");
            this.Property(t => t.C9).HasColumnName("9");
            this.Property(t => t.C10).HasColumnName("10");
            this.Property(t => t.C11).HasColumnName("11");
            this.Property(t => t.C12).HasColumnName("12");
            this.Property(t => t.C13).HasColumnName("13");
            this.Property(t => t.C14).HasColumnName("14");
            this.Property(t => t.C15).HasColumnName("15");
            this.Property(t => t.C16).HasColumnName("16");
            this.Property(t => t.C17).HasColumnName("17");
            this.Property(t => t.C18).HasColumnName("18");
            this.Property(t => t.C19).HasColumnName("19");
            this.Property(t => t.C20).HasColumnName("20");
            this.Property(t => t.C21).HasColumnName("21");
            this.Property(t => t.C22).HasColumnName("22");
            this.Property(t => t.C23).HasColumnName("23");
            this.Property(t => t.C24).HasColumnName("24");
            this.Property(t => t.C25).HasColumnName("25");
            this.Property(t => t.C26).HasColumnName("26");
            this.Property(t => t.C27).HasColumnName("27");
            this.Property(t => t.C28).HasColumnName("28");
            this.Property(t => t.C29).HasColumnName("29");
            this.Property(t => t.C30).HasColumnName("30");
            this.Property(t => t.C31).HasColumnName("31");
        }
    }
}
