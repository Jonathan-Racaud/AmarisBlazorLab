﻿using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Core.DTO;
using AmarisBlazorLab.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public ApplicationUser GetFromIdentityName(string name)
        {
            return Context.Set<ApplicationUser>().SingleOrDefault(u => u.Email == name);
        }

        public ApplicationUser GetWithProjects(string id)
        {
            return Context.Set<ApplicationUser>()
                .Include(u => u.UserProjects).ThenInclude(up => up.Project).ThenInclude(p => p.Owner)
                .Single(u => u.Id == id);
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
