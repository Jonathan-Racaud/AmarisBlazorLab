using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Data.Repositories
{
    public class UserProjectRepository : Repository<UserProject>, IUserProjectRepository
    {
        public UserProjectRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public IEnumerable<UserProject> GetAllFromProject(int id)
        {
            return Context.Set<UserProject>().Where(pc => pc.ProjectId == id).ToList();
        }
    }
}
