using AmarisBlazorLab.Data.Migrations;
using AmarisBlazorLab.Core.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            var adminRole = "Admin";
            var regularRole = "Regular";

            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            if (await roleManager.FindByNameAsync(regularRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(regularRole));
            }

            var email = "admin@test.com";
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = email,
                    NormalizedUserName = email.ToUpper(),
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                var result = await userManager.CreateAsync(admin);

                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(admin, "Admin#1");
                    await userManager.AddToRoleAsync(admin, adminRole);
                }
            }
        }
    }
}
