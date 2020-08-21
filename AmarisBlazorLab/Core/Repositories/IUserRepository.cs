using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Core.Repositories
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetWithProjects(string id);
        User GetWithRoles(string id);
        Task<bool> AssignRoles(ApplicationUser user, List<string> roles);
    }
}
