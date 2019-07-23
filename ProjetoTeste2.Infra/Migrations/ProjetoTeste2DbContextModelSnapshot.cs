﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoTeste2.Infra.Context;

namespace ProjetoTeste2.Infra.Migrations
{
    [DbContext(typeof(ProjetoTeste2DbContext))]
    partial class ProjetoTeste2DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProjetoTeste2.Domains.Entities.Cliente", b =>
                {
                    b.Property<string>("Cnpj")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Cnpj")
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Fantasia")
                        .HasColumnName("Fantasia")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("IE")
                        .HasColumnName("IE")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("IM")
                        .HasColumnName("IM")
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Obs")
                        .HasColumnName("Obs")
                        .HasColumnType("ntext")
                        .HasMaxLength(20);

                    b.Property<string>("Razao")
                        .HasColumnName("Razao")
                        .HasColumnType("nvarchar(200)");

                    b.Property<byte[]>("RecordTimeStamp");

                    b.HasKey("Cnpj");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ProjetoTeste2.Domains.Entities.ClienteContato", b =>
                {
                    b.Property<long>("ClienteContatoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnName("Cnpj")
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("EmailContato")
                        .HasColumnName("EmailContato")
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("NomeContato")
                        .HasColumnName("NomeContato")
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("RecordTimeStamp");

                    b.Property<string>("TelefoneContato")
                        .HasColumnName("TelefoneContato")
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("ClienteContatoId");

                    b.HasIndex("Cnpj");

                    b.ToTable("ClienteContato");
                });

            modelBuilder.Entity("ProjetoTeste2.Domains.Entities.Endereco", b =>
                {
                    b.Property<long>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnName("Bairro")
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Cep")
                        .HasColumnName("Cep")
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnName("Cnpj")
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("Compl")
                        .HasColumnName("Compl")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long?>("EnderecoTipoId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Logradouro")
                        .HasColumnName("Logradouro")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Municipio")
                        .HasColumnName("Municipio")
                        .HasColumnType("nvarchar(180)");

                    b.Property<long>("Numero")
                        .HasColumnName("Numero")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("RecordTimeStamp");

                    b.Property<string>("Uf")
                        .HasColumnName("Uf")
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("EnderecoId");

                    b.HasIndex("Cnpj");

                    b.HasIndex("EnderecoTipoId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("ProjetoTeste2.Domains.Entities.EnderecoTipo", b =>
                {
                    b.Property<long>("EnderecoTipoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DescricaoTipo")
                        .HasColumnName("DescricaoTipo")
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<byte[]>("RecordTimeStamp");

                    b.HasKey("EnderecoTipoId");

                    b.ToTable("EnderecoTipo");
                });

            modelBuilder.Entity("ProjetoTeste2.Domains.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProjetoTeste2.Domains.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProjetoTeste2.Domains.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetoTeste2.Domains.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProjetoTeste2.Domains.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoTeste2.Domains.Entities.ClienteContato", b =>
                {
                    b.HasOne("ProjetoTeste2.Domains.Entities.Cliente", "Cliente")
                        .WithMany("ClienteContatos")
                        .HasForeignKey("Cnpj")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoTeste2.Domains.Entities.Endereco", b =>
                {
                    b.HasOne("ProjetoTeste2.Domains.Entities.Cliente", "Cliente")
                        .WithMany("Enderecos")
                        .HasForeignKey("Cnpj")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetoTeste2.Domains.Entities.EnderecoTipo")
                        .WithMany("Enderecos")
                        .HasForeignKey("EnderecoTipoId");
                });
#pragma warning restore 612, 618
        }
    }
}
