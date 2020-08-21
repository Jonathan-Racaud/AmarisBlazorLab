using AmarisBlazorLab.Core;
using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Core.Repositories;
using AmarisBlazorLab.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IProjectRepository Projects { get; private set; }

        public IUserRepository Users { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public IMaterialTypeRepository MaterialTypes { get; private set; }

        public IIdentityRoleRepository Roles { get; private set; }
        public IUserProjectRepository UserProjects { get; private set; }
        public IProjectCategoryRepository ProjectCategories { get; private set; }

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            Projects = new ProjectRepository(_context);
            Users = new UserRepository(_context, userManager);
            Categories = new CategoryRepository(_context);
            MaterialTypes = new MaterialTypeRepository(_context);
            Roles = new RoleRepository(_context);
            UserProjects = new UserProjectRepository(_context);
            ProjectCategories = new ProjectCategoryRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
