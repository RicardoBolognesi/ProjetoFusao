using Microsoft.AspNetCore.Identity;

namespace ProjetoTeste2.Domain.Entities
{
    public class UserClaim : IdentityUserClaim<long>
    {
        public virtual User User { get; set; }
    }
}
