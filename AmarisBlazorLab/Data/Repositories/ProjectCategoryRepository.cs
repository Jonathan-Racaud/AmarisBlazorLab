using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Data.Repositories
{
    public class ProjectCategoryRepository : Repository<ProjectCategory>, IProjectCategoryRepository
    {
        public ProjectCategoryRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public IEnumerable<ProjectCategory> GetAllFromProject(int id)
        {
            return Context.Set<ProjectCategory>().Where(pc => pc.ProjectId == id).ToList();
        }
    }
}
