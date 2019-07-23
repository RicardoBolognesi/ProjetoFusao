using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoTeste2.Domains.Entities;

namespace ProjetoTeste2.Infra.Mappings
{
    public class ClienteMapping<TEntity> : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(c => c.Cnpj);

            builder.Property(c => c.Cnpj)
                .HasColumnName("Cnpj")
                .HasColumnType("nvarchar(18)");


            builder.Property(c => c.Razao)
                .HasColumnName("Razao")
                .HasColumnType("nvarchar(200)");


            builder.Property(c => c.Fantasia)
                .HasColumnName("Fantasia")
                .HasColumnType("nvarchar(200)");


            builder.Property(c => c.IE)
                .HasColumnName("IE")
                .HasColumnType("nvarchar(20)");


            builder.Property(c => c.IM)
                .HasColumnName("IM")
                .HasColumnType("nvarchar(20)");

            builder.Property(c => c.Obs)
                .HasColumnName("Obs")
                .HasColumnType("ntext")
                .HasMaxLength(20);
        }
    }
}
