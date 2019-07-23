using Microsoft.AspNetCore.Identity;

namespace ProjetoTeste2.Domain.Entities
{
    public class RoleClaim : IdentityRoleClaim<long>
    {
        public virtual Role Role { get; set; }
    }
}
