using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Data.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public IEnumerable<Material> GetAllFromProject(int id)
        {
            return Context.Set<Material>().Where(m => m.Project.Id == id)
                .Include(m => m.MaterialType)
                .ToList();
        }
    }
}
