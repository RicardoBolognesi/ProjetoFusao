using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoTeste2.Domains.Entities;

namespace ProjetoTeste2.Infra.Mappings
{
    class EnderecoMapping<TEntity> : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(e => e.EnderecoId);

            builder.Property(e => e.Logradouro)
                .HasColumnType("nvarchar(250)")
                .HasColumnName("Logradouro");


            builder.Property(e => e.Numero)
                .HasColumnType("bigint")
                .HasColumnName("Numero");

            builder.Property(e => e.Compl)
                .HasColumnType("nvarchar(250)")
                .HasColumnName("Compl");

            builder.Property(e => e.Cep)
                .HasColumnType("nvarchar(9)")
                .HasColumnName("Cep");


            builder.Property(e => e.Bairro)
                .HasColumnType("nvarchar(80)")
                .HasColumnName("Bairro");


            builder.Property(e => e.Municipio)
                .HasColumnType("nvarchar(180)")
                .HasColumnName("Municipio");

            builder.Property(e => e.Uf)
                .HasColumnType("nvarchar(2)")
                .HasColumnName("Uf");

            builder.Property(e => e.Cnpj)
                .HasColumnName("Cnpj")
                .HasColumnType("nvarchar(18)");

            builder.HasOne(e => e.Cliente)
                .WithMany(e=> e.Enderecos)
                .HasForeignKey(e => e.Cnpj)
                .IsRequired();

        }
    }
}
