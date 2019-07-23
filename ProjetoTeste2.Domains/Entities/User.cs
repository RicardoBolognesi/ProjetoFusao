using Microsoft.AspNetCore.Identity;

namespace ProjetoTeste2.Domains.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }

    }
}
