using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoTeste2.Domains.Entities;
using ProjetoTeste2.Infra.Mappings;

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
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ClienteMapping<Cliente>());
            builder.ApplyConfiguration(new ClienteContatoMapping<ClienteContato>());
            builder.ApplyConfiguration(new EnderecoMapping<Endereco>());
            builder.ApplyConfiguration(new EnderecoTipoMapping<EnderecoTipo>());

            //builder.ApplyConfiguration(new RoleMapping<Role>());
            //builder.ApplyConfiguration(new UserRoleMapping<UserRole>());
            //builder.ApplyConfiguration(new RoleClaimMapping<RoleClaim>());
            //builder.ApplyConfiguration(new UserClaimMapping<UserClaim>());
            //builder.ApplyConfiguration(new UserLoginMapping<UserLogin>());
            //builder.ApplyConfiguration(new UserTokenMapping<UserToken>());

        }
    }
}
