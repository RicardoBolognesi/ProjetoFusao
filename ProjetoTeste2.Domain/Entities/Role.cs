using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ProjetoTeste2.Domain.Entities
{
    public class Role : IdentityRole<long>
    {
        public string Description { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
