using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Data.Repositories
{
    public class MaterialTypeRepository: Repository<MaterialType>, IMaterialTypeRepository
    {
        public MaterialTypeRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}
