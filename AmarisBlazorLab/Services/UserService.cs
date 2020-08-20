using AmarisBlazorLab.Core;
using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Core.DTO;
using Microsoft.Extensions.Hosting.Internal;
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

        public User Get(string id)
        {
            var user = unitOfWork.Users.Get(id) as User;

            return user;
        }

        public List<User> GetAll()
        {
            var applicationUsers = unitOfWork.Users.GetAll();

            if (applicationUsers == null)
            {
                Console.WriteLine("applicationUsers is null");
                return null;
            }

            List<User> users = new List<User>();

            foreach (var appUser in applicationUsers)
            {
                var user = unitOfWork.Users.GetWithRoles(appUser.Id);

                if (user != null)
                {
                    users.Add(user);
                }
            }

            return users;
        }

        public bool Create(User user)
        {
            unitOfWork.Users.Add(user);
            unitOfWork.Complete();
            return true;
        }

        public bool Delete(User user)
        {
            unitOfWork.Users.Remove(user);
            unitOfWork.Complete();
            return true;
        }

        public bool Update(User user, User newUser)
        {
            var oldUser = unitOfWork.Users.Get(user.Id);
            oldUser = newUser;
            unitOfWork.Complete();
            return true;
        }
    }
}
