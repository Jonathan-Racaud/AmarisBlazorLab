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
    }
}
