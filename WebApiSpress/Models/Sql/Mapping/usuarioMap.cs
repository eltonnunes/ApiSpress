using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace WebApiSpress.Models.Sql.Mapping
{
    public class usuarioMap : EntityTypeConfiguration<usuario>
    {
        public usuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.cod_usuario);

            // Properties
            this.Property(t => t.cod_usuario)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.codlojasitef)
                .HasMaxLength(17);

            this.Property(t => t.cod_grupo)
                .HasMaxLength(17);

            this.Property(t => t.senha)
                .HasMaxLength(32);

            this.Property(t => t.codaut)
                .HasMaxLength(16);

            this.Property(t => t.ultimoacesso)
                .HasMaxLength(14);

            this.Property(t => t.per_gera_arq)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.per_conciliacao)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.cod_estado)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.cod_regional)
                .HasMaxLength(17);

            this.Property(t => t.per_valores)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.per_confrel)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.per_gercancelamento)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.per_pesquisatrn)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.per_relgerencial)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.nome)
                .HasMaxLength(40);

            this.Property(t => t.console_config)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.console_cleaner)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.conciliacao_pos)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("usuarios");
            this.Property(t => t.cod_usuario).HasColumnName("cod_usuario");
            this.Property(t => t.nivel_usuario).HasColumnName("nivel_usuario");
            this.Property(t => t.codlojasitef).HasColumnName("codlojasitef");
            this.Property(t => t.cod_grupo).HasColumnName("cod_grupo");
            this.Property(t => t.senha).HasColumnName("senha");
            this.Property(t => t.codaut).HasColumnName("codaut");
            this.Property(t => t.ultimoacesso).HasColumnName("ultimoacesso");
            this.Property(t => t.per_gera_arq).HasColumnName("per_gera_arq");
            this.Property(t => t.per_conciliacao).HasColumnName("per_conciliacao");
            this.Property(t => t.totalacessos).HasColumnName("totalacessos");
            this.Property(t => t.num_tentativas).HasColumnName("num_tentativas");
            this.Property(t => t.cod_estado).HasColumnName("cod_estado");
            this.Property(t => t.cod_regional).HasColumnName("cod_regional");
            this.Property(t => t.per_valores).HasColumnName("per_valores");
            this.Property(t => t.per_confrel).HasColumnName("per_confrel");
            this.Property(t => t.per_gercancelamento).HasColumnName("per_gercancelamento");
            this.Property(t => t.per_pesquisatrn).HasColumnName("per_pesquisatrn");
            this.Property(t => t.per_relgerencial).HasColumnName("per_relgerencial");
            this.Property(t => t.cpf).HasColumnName("cpf");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.console_config).HasColumnName("console_config");
            this.Property(t => t.console_cleaner).HasColumnName("console_cleaner");
            this.Property(t => t.access_type).HasColumnName("access_type");
            this.Property(t => t.devealterarsenha).HasColumnName("devealterarsenha");
            this.Property(t => t.conciliacao_pos).HasColumnName("conciliacao_pos");
            this.Property(t => t.nivel_alerta).HasColumnName("nivel_alerta");

            // Relationships
            this.HasRequired(t => t.estado_usuario)
                .WithMany(t => t.usuarios)
                .HasForeignKey(d => d.cod_estado);
            this.HasOptional(t => t.Grupo)
                .WithMany(t => t.usuarios)
                .HasForeignKey(d => d.cod_grupo);
            this.HasOptional(t => t.Loja)
                .WithMany(t => t.usuarios)
                .HasForeignKey(d => d.codlojasitef);
            this.HasRequired(t => t.nivel_usuarios)
                .WithMany(t => t.usuarios)
                .HasForeignKey(d => d.nivel_usuario);
            this.HasOptional(t => t.regional)
                .WithMany(t => t.usuarios)
                .HasForeignKey(d => d.cod_regional);

        }
    }
}
