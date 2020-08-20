using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Core.Repositories
{
    public interface IProjectRepository: IRepository<Project>
    {
        IEnumerable<Project> GetCompletedProjects();
        IEnumerable<Project> GetProjectsWithUser(ApplicationUser user);
        IEnumerable<Project> GetLatest();
    }
}
