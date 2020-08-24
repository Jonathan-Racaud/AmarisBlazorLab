using AmarisBlazorLab.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Core.Repositories
{
    public interface IProjectCategoryRepository : IRepository<ProjectCategory>
    {
        IEnumerable<ProjectCategory> GetAllFromProject(int id);
    }
}
