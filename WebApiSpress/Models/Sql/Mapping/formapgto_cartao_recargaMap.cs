using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class formapgto_cartao_recargaMap : EntityTypeConfiguration<formapgto_cartao_recarga>
    {
        public formapgto_cartao_recargaMap()
        {
            // Primary Key
            this.HasKey(t => t.forma_pagamento);

            // Properties
            this.Property(t => t.forma_pagamento)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.desc_pagamento)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("formapgto_cartao_recarga");
            this.Property(t => t.forma_pagamento).HasColumnName("forma_pagamento");
            this.Property(t => t.desc_pagamento).HasColumnName("desc_pagamento");
        }
    }
}
