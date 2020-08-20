using AmarisBlazorLab.Core;
using AmarisBlazorLab.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Services
{
    public class ProjectService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Project Get(int id)
        {
            return unitOfWork.Projects.Get(id);
        }

        public List<Project> GetAll()
        {
            return unitOfWork.Projects.GetAll().ToList();
        }

        public List<Project> GetLatest()
        {
            var projects = unitOfWork.Projects.GetAll().Take(10).ToList();

            return projects;
        }
    }
}
