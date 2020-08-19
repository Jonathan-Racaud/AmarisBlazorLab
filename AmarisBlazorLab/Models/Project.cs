using System.Collections.Generic;

namespace AmarisBlazorLab.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ApplicationUser Owner { get; set; }
        //public IList<UserProject> UserProjects { get; set; }
        //public IList<ProjectCategory> ProjectCategories { get; set; }
    }
}
