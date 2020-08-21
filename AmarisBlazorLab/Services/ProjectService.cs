using AmarisBlazorLab.Core;
using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

            UpdateProjectContributors(project, projectIn);
            UpdateProjectCategories(project, projectIn);
            return true;
        }

        public bool Update(ProjectRegistration projectIn)
        {
            if (string.IsNullOrEmpty(projectIn.Name) ||
                (projectIn.Owner == null) ||
                (projectIn.Categories.Count < 1))
            {
                return false;
            }

            var project = unitOfWork.Projects.Find(p => p.Name == projectIn.Name).Single();

            project.Name = projectIn.Name;
            project.Owner = projectIn.Owner;
            project.Description = projectIn.Description;
            unitOfWork.Complete();

            UpdateProjectContributors(project, projectIn);
            UpdateProjectCategories(project, projectIn);

            return true;
        }

        public bool AssignContributor(Project project, ApplicationUser user)
        {
            var userProject = new UserProject
            {
                Project = project,
                User = user
            };

            try
            {
                unitOfWork.UserProjects.Add(userProject);
                unitOfWork.Complete();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Error: Couldn't join project: {e.Message}");
                return false;
            }

            return true;
        }

        public bool RemoveContributor(Project project, ApplicationUser user)
        {
            try
            {
                var userProject = unitOfWork.UserProjects.GetAll().Single(up => ((up.ProjectId == project.Id) && (up.UserId == user.Id)));
                unitOfWork.UserProjects.Remove(userProject);
                unitOfWork.Complete();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: Couldn't remove contributor: {e.Message}");
                return false;
            }

            return true;
        }

        private void UpdateProjectContributors(Project project, ProjectRegistration projectIn)
        {
            var userProjects = new List<UserProject>();
            if (!project.UserProjects.Any(up => up.UserId == projectIn.Owner.Id))
            {
                userProjects.Add(new UserProject
                {
                    Project = project,
                    User = project.Owner
                });
            }

            if (projectIn.Contributors.Count > 0)
            {
                foreach (var user in projectIn.Contributors)
                {
                    if (!project.UserProjects.Any(up => up.UserId == user.Id))
                    {
                        var userProject = new UserProject
                        {
                            Project = project,
                            User = user
                        };
                        userProjects.Add(userProject);
                    }
                }
            }

            if (userProjects.Count > 0)
            {
                unitOfWork.UserProjects.AddRange(userProjects);
            }
            unitOfWork.Complete();
        }

        private void UpdateProjectCategories(Project project, ProjectRegistration projectIn)
        {
            var projectCategories = new List<ProjectCategory>();
            foreach (var category in projectIn.Categories)
            {
                if (!project.ProjectCategories.Any(pc => pc.CategoryId == category.Id))
                {
                    var projectCategory = new ProjectCategory
                    {
                        Project = project,
                        Category = category
                    };
                    projectCategories.Add(projectCategory);
                }
            }
            unitOfWork.ProjectCategories.AddRange(projectCategories);
            unitOfWork.Complete();
        }
    }
}
