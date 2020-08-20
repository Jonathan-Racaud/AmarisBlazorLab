using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Core.DTO;
using AmarisBlazorLab.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Data.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
            : base(context)
        {
            this.userManager = userManager;
        }

        public User GetWithRoles(string id)
        {
            var applicationUser = Get(id);

            if (applicationUser == null)
            {
                return null;
            }

            User user = new User(applicationUser);

            var roles = Context.Set<IdentityUserRole<string>>().Where(ur => ur.UserId == applicationUser.Id).ToList();
            foreach (var r in roles)
            {
                var roleName = Context.Set<IdentityRole>().Find(r.RoleId).Name;

                if (!string.IsNullOrEmpty(roleName))
                {
                    user.Roles.Add(roleName);
                }
            }

            return user;
        }

        public async Task<bool> AssignRoles(ApplicationUser user, List<string> roles)
        {
            var result = await userManager.AddToRolesAsync(user, roles);

            return result.Succeeded;
        }
    }
}
