using System;
using Microsoft.AspNetCore.Identity;
using ProjetoTeste2.Domains.Entities;

namespace ProjetoTeste2.Infra.Context
{
    public static class MyIdentityDataInitializer
    {
        public static UserManager<User> UserManager { get; set; }
        public static RoleManager<IdentityRole> RoleManager { get; set; }

        public static void SeedData()
        {
            

            SeedRoles(RoleManager);
            SeedUsers(UserManager);
        }

        public static void SeedUsers
            (UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync
                    ("admin").Result == null)
            {
                User user = new User();
                user.UserName = "admin";
                user.Email = "admin@admin";
                user.FullName = "administrator";
                IdentityResult result = userManager.CreateAsync(user, "admin123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                        "Administrator").Wait();
                }
            }
        }

        public static void SeedRoles
            (RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync
                ("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

        }
    }
}
