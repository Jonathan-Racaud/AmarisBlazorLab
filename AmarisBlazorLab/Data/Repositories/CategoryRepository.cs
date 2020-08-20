using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
