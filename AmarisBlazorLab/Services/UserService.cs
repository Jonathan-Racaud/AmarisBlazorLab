using AmarisBlazorLab.Core;
using AmarisBlazorLab.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Services
{
    public class UserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ApplicationUser Get(string id)
        {
            var user = unitOfWork.Users.Get(id);

            return user;
        }

        public List<ApplicationUser> GetAll()
        {
            return unitOfWork.Users.GetAll().ToList();
        }

        public bool Create(ApplicationUser user)
        {
            unitOfWork.Users.Add(user);
            unitOfWork.Complete();
            return true;
        }

        public bool Delete(ApplicationUser user)
        {
            unitOfWork.Users.Remove(user);
            unitOfWork.Complete();
            return true;
        }

        public bool Update(ApplicationUser user, ApplicationUser newUser)
        {
            var oldUser = unitOfWork.Users.Get(user.Id);
            oldUser = newUser;
            unitOfWork.Complete();
            return true;
        }
    }
}
