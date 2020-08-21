using AmarisBlazorLab.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepository Projects { get; }
        IUserRepository Users { get; }
        ICategoryRepository Categories { get; }
        IMaterialTypeRepository MaterialTypes { get; }
        IIdentityRoleRepository Roles { get; }
        IUserProjectRepository UserProjects { get; }
        IProjectCategoryRepository ProjectCategories { get; }
        int Complete();
    }
}
