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
        User GetWithRoles(string id);
        IEnumerable<Project> GetUserProjects();
    }
}
