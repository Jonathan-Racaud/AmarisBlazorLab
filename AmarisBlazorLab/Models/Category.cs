using System.Collections.Generic;

namespace AmarisBlazorLab.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ProjectCategory> ProjectCategories { get; set; }
    }
}
