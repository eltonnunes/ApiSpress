using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class TabMeiosPagMap : EntityTypeConfiguration<TabMeiosPag>
    {
        public TabMeiosPagMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Data_Tot, t.CodLojaSitef, t.Idt_Terminal });

            // Properties
            this.Property(t => t.Data_Tot)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.CodLojaSitef)
                .IsRequired()
                .HasMaxLength(17);

            this.Property(t => t.Idt_Terminal)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.Hora_Tot)
                .HasMaxLength(6);

            this.Property(t => t.GT)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora1)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora2)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora3)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora4)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora5)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora6)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora7)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora8)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora9)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora10)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora11)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora12)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora13)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora14)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora15)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora16)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora17)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora18)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora19)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora20)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora21)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora22)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora23)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora24)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora25)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora26)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora27)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora28)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora29)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora30)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora31)
                .HasMaxLength(15);

            this.Property(t => t.Finalizadora32)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("TabMeiosPag");
            this.Property(t => t.Data_Tot).HasColumnName("Data_Tot");
            this.Property(t => t.CodLojaSitef).HasColumnName("CodLojaSitef");
            this.Property(t => t.Idt_Terminal).HasColumnName("Idt_Terminal");
            this.Property(t => t.Hora_Tot).HasColumnName("Hora_Tot");
            this.Property(t => t.GT).HasColumnName("GT");
            this.Property(t => t.Finalizadora1).HasColumnName("Finalizadora1");
            this.Property(t => t.Finalizadora2).HasColumnName("Finalizadora2");
            this.Property(t => t.Finalizadora3).HasColumnName("Finalizadora3");
            this.Property(t => t.Finalizadora4).HasColumnName("Finalizadora4");
            this.Property(t => t.Finalizadora5).HasColumnName("Finalizadora5");
            this.Property(t => t.Finalizadora6).HasColumnName("Finalizadora6");
            this.Property(t => t.Finalizadora7).HasColumnName("Finalizadora7");
            this.Property(t => t.Finalizadora8).HasColumnName("Finalizadora8");
            this.Property(t => t.Finalizadora9).HasColumnName("Finalizadora9");
            this.Property(t => t.Finalizadora10).HasColumnName("Finalizadora10");
            this.Property(t => t.Finalizadora11).HasColumnName("Finalizadora11");
            this.Property(t => t.Finalizadora12).HasColumnName("Finalizadora12");
            this.Property(t => t.Finalizadora13).HasColumnName("Finalizadora13");
            this.Property(t => t.Finalizadora14).HasColumnName("Finalizadora14");
            this.Property(t => t.Finalizadora15).HasColumnName("Finalizadora15");
            this.Property(t => t.Finalizadora16).HasColumnName("Finalizadora16");
            this.Property(t => t.Finalizadora17).HasColumnName("Finalizadora17");
            this.Property(t => t.Finalizadora18).HasColumnName("Finalizadora18");
            this.Property(t => t.Finalizadora19).HasColumnName("Finalizadora19");
            this.Property(t => t.Finalizadora20).HasColumnName("Finalizadora20");
            this.Property(t => t.Finalizadora21).HasColumnName("Finalizadora21");
            this.Property(t => t.Finalizadora22).HasColumnName("Finalizadora22");
            this.Property(t => t.Finalizadora23).HasColumnName("Finalizadora23");
            this.Property(t => t.Finalizadora24).HasColumnName("Finalizadora24");
            this.Property(t => t.Finalizadora25).HasColumnName("Finalizadora25");
            this.Property(t => t.Finalizadora26).HasColumnName("Finalizadora26");
            this.Property(t => t.Finalizadora27).HasColumnName("Finalizadora27");
            this.Property(t => t.Finalizadora28).HasColumnName("Finalizadora28");
            this.Property(t => t.Finalizadora29).HasColumnName("Finalizadora29");
            this.Property(t => t.Finalizadora30).HasColumnName("Finalizadora30");
            this.Property(t => t.Finalizadora31).HasColumnName("Finalizadora31");
            this.Property(t => t.Finalizadora32).HasColumnName("Finalizadora32");
        }
    }
}
