using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoTeste2.Domains.Entities;

namespace ProjetoTeste2.Infra.Mappings
{
    public class EnderecoTipoMapping<TEntity> : IEntityTypeConfiguration<EnderecoTipo>
    {
        public void Configure(EntityTypeBuilder<EnderecoTipo> builder)
        {
            builder.ToTable("EnderecoTipo");

            builder.HasKey(ed => ed.EnderecoTipoId);

            builder.Property(ed => ed.DescricaoTipo)
                .HasColumnType("nvarchar(100)")
                .HasColumnName("DescricaoTipo");


        }
    }
}
