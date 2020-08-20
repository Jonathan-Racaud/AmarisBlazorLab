using AmarisBlazorLab.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Services
{
    public class RoleService
    {
        private readonly IUnitOfWork unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<IdentityRole> GetAll()
        {
            return unitOfWork.Roles.GetAll().ToList();
        }
    }
}
