using AmarisBlazorLab.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Core.Repositories
{
    public interface IIdentityRoleRepository: IRepository<IdentityRole>
    {
    }
}
