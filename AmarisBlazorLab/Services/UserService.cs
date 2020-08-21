using AmarisBlazorLab.Core;
using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Core.DTO;
using Microsoft.AspNetCore.Identity;
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

        public ApplicationUser Get(string id)
        {
            return unitOfWork.Users.Get(id);
        }

        public ApplicationUser GetWithProjects(string id)
        {
            return unitOfWork.Users.GetWithProjects(id);
        }

        public User GetWithRole(string id)
        {
            return unitOfWork.Users.GetWithRoles(id);
        }

        public List<ApplicationUser> GetAll()
        {
            return unitOfWork.Users.GetAll().ToList();
        }

        public List<User> GetAllWithRoles()
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

        public async Task<bool> Create(UserRegistration userIn)
        {
            if (string.IsNullOrEmpty(userIn.Email) ||
                string.IsNullOrEmpty(userIn.Password) ||
                string.IsNullOrEmpty(userIn.Role))
            { 
                return false;
            }

            var user = new ApplicationUser
            {
                Email = userIn.Email,
                NormalizedEmail = userIn.Email.ToUpper(),
                UserName = userIn.Email,
                NormalizedUserName = userIn.Email.ToUpper(),
                EmailConfirmed = true
            };
            var password = new PasswordHasher<ApplicationUser>().HashPassword(user, userIn.Password);
            user.PasswordHash = password;
            unitOfWork.Users.Add(user);
            unitOfWork.Complete();

            var roleAdded = await unitOfWork.Users.AssignRoles(user, new List<string> { userIn.Role });
            if (!roleAdded)
            {
                unitOfWork.Users.Remove(user);
                unitOfWork.Complete();
                return false;
            }

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
