using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Core.DTO
{
    public class ProjectRegistration
    {
        [Required]
        public string Name { get; set; }
        public string OldName { get; set; }
        public string Description { get; set; }
        [Required]
        public ApplicationUser Owner { get; set; }
        public List<ApplicationUser> Contributors { get; set; } = new List<ApplicationUser>();
        
        [MinimumElementsRequired(1)]
        public List<Category> Categories { get; set; } = new List<Category>();

        public ProjectRegistration()
        { }

        public ProjectRegistration(Project project)
        {
            Name = project.Name;
            OldName = project.Name;
            Description = project.Description;
            Owner = project.Owner;

            foreach (var item in project.UserProjects)
            {
                Contributors.Add(item.User);
            }

            foreach (var item in project.ProjectCategories)
            {
                Categories.Add(item.Category);
            }
        }
    }
}
