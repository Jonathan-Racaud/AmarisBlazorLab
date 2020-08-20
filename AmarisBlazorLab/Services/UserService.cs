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

        public ApplicationUser GetUser(string id)
        {
            var user = unitOfWork.Users.Get(id);

            return user;
        }
        public bool CreateUser(ApplicationUser user)
        {
            unitOfWork.Users.Add(user);
            unitOfWork.Complete();
            return true;
        }

        public bool DeleteUser(ApplicationUser user)
        {
            unitOfWork.Users.Remove(user);
            unitOfWork.Complete();
            return true;
        }

        public bool UpdateUser(ApplicationUser user, ApplicationUser newUser)
        {
            var oldUser = unitOfWork.Users.Get(user.Id);
            oldUser = newUser;
            unitOfWork.Complete();
            return true;
        }
    }
}
