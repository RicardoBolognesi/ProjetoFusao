using Microsoft.AspNetCore.Identity;

namespace ProjetoTeste2.Domain.Entities
{
    public class UserToken : IdentityUserToken<long>
    {
        public virtual User User { get; set; }
    }
}
