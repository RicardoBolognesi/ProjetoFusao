using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoTeste2.Domains.Entities;

namespace ProjetoTeste2.Infra.Mappings
{
    public class ClienteContatoMapping<TEntity> : IEntityTypeConfiguration<ClienteContato>
    {
        public void Configure(EntityTypeBuilder<ClienteContato> builder)
        {
            builder.ToTable("ClienteContato");

            builder.HasKey(cc => cc.ClienteContatoId);

            builder.Property(cc => cc.NomeContato)
                .HasColumnType("nvarchar(50)")
                .HasColumnName("NomeContato");


            builder.Property(cc => cc.EmailContato)
                .HasColumnType("nvarchar(200)")
                .HasColumnName("EmailContato");


            builder.Property(cc => cc.TelefoneContato)
                .HasColumnType("nvarchar(14)")
                .HasColumnName("TelefoneContato");


            builder.Property(cc => cc.Cnpj)
                .HasColumnType("nvarchar(18)")
                .HasColumnName("Cnpj");


            builder.HasOne(cc => cc.Cliente)
                .WithMany(cc => cc.ClienteContatos)
                .HasForeignKey(cc => cc.Cnpj)
                .IsRequired();

        }
    }
}
