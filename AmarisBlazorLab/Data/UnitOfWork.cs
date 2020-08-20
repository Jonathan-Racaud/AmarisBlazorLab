using AmarisBlazorLab.Core;
using AmarisBlazorLab.Core.Repositories;
using AmarisBlazorLab.Data.Repositories;
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

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Projects = new ProjectRepository(_context);
            Users = new UserRepository(_context);
            Categories = new CategoryRepository(_context);
            MaterialTypes = new MaterialTypeRepository(_context);
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
