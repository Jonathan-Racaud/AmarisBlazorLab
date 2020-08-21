using AmarisBlazorLab.Core;
using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Core.DTO;
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

        public bool Create(ProjectRegistration projectIn)
        {
            if (string.IsNullOrEmpty(projectIn.Name) ||
                (projectIn.Owner == null) ||
                (projectIn.Categories.Count < 1))
            {
                return false;
            }

            var project = new Project
            {
                Name = projectIn.Name,
                Description = projectIn.Description,
                Owner = projectIn.Owner
            };

            unitOfWork.Projects.Add(project);
            unitOfWork.Complete();

            if (projectIn.Contributors.Count > 0)
            {
                var userProjects = new List<UserProject>();
                foreach (var user in projectIn.Contributors)
                {
                    var userProject = new UserProject
                    {
                        Project = project,
                        User = user
                    };
                    userProjects.Add(userProject);
                }
                unitOfWork.UserProjects.AddRange(userProjects);
                unitOfWork.Complete();
            }

            var projectCategories = new List<ProjectCategory>();
            foreach (var category in projectIn.Categories)
            {
                var projectCategory = new ProjectCategory
                {
                    Project = project,
                    Category = category
                };
                projectCategories.Add(projectCategory);
            }
            unitOfWork.ProjectCategories.AddRange(projectCategories);
            unitOfWork.Complete();

            return true;
        }
    }
}
