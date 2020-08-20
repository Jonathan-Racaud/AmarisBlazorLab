using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Data.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
            : base(context)
        {

        }
        public IEnumerable<Project> GetUserProjects()
        {
            throw new NotImplementedException();
        }
    }
}
