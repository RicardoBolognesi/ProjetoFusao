using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoTeste2.Domains.Entities;
using ProjetoTeste2.Infra.Mappings;
using System.Security.Policy;

namespace ProjetoTeste2.Infra.Context
{
    public class ProjetoTeste2DbContext : IdentityDbContext<
        User
        //IdentityRole<string>,
        //string,
        //IdentityUserClaim<string>,
        //IdentityUserRole<string>,
        //IdentityUserLogin<string>,
        //IdentityRoleClaim<string>,
        //IdentityUserToken<string>
    >
    {
        public ProjetoTeste2DbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteContato> ClienteContatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<EnderecoTipo> EnderecoTipos { get; set; }

        //public DbSet<UserRole> UserRoles { get; set; }
        //public DbSet<RoleClaim> RoleClaims { get; set; }
        //public DbSet<UserClaim> UserClaims { get; set; }
        //public DbSet<UserLogin> UserLogins { get; set; }
        //public DbSet<UserToken> UserTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // any guid
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            // any guid, but nothing is against to use the same one
            const string ROLE_ID = "1bd14693-d749-4586-a748-b2c2e67e44e9";
            var hasher = new PasswordHasher<User>();

            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ClienteMapping<Cliente>());
            builder.ApplyConfiguration(new ClienteContatoMapping<ClienteContato>());
            builder.ApplyConfiguration(new EnderecoMapping<Endereco>());
            builder.ApplyConfiguration(new EnderecoTipoMapping<EnderecoTipo>());

            //Criando Usuário admin e role admin default no banco
            builder.Entity<User>().HasData(new User()
            {
                Id = ADMIN_ID ,
                UserName = "admin",
                NormalizedUserName = "admin",
                FullName = "administrador",
                Email = "admin@admin",
                NormalizedEmail = "admin@admin",
                PasswordHash = hasher.HashPassword(null,"admin123"),
                EmailConfirmed = false,
                SecurityStamp = string.Empty
            });
            builder.Entity<IdentityRole>().HasData( new IdentityRole()
            {
                Id = ROLE_ID,
                Name = "admin",
                NormalizedName = "admin"
            });
            builder.Entity<IdentityUserRole<string>>().HasData( new IdentityUserRole<string>()
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            ////////////////////////////////////

            //builder.ApplyConfiguration(new RoleMapping<Role>());
            //builder.ApplyConfiguration(new UserRoleMapping<UserRole>());
            //builder.ApplyConfiguration(new RoleClaimMapping<RoleClaim>());
            //builder.ApplyConfiguration(new UserClaimMapping<UserClaim>());
            //builder.ApplyConfiguration(new UserLoginMapping<UserLogin>());
            //builder.ApplyConfiguration(new UserTokenMapping<UserToken>());

        }
    }
}
