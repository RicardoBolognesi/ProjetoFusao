using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ProjetoTeste2.Domain.Entities
{
    public class User : IdentityUser<long>
    {
        public string FullName { get; set; }

        public virtual ICollection<UserClaim> Claims { get; set; }
        public virtual ICollection<UserLogin> Logins { get; set; }
        public virtual ICollection<UserToken> Tokens { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
