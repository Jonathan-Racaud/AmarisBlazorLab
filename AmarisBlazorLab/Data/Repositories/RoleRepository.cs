using AmarisBlazorLab.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Data.Repositories
{
    public class RoleRepository : Repository<IdentityRole>, IIdentityRoleRepository
    {
        public RoleRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
