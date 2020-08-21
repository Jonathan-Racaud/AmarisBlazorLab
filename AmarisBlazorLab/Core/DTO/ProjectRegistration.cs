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
        public string Description { get; set; }
        [Required]
        public ApplicationUser Owner { get; set; }
        public List<ApplicationUser> Contributors { get; set; } = new List<ApplicationUser>();
        
        [MinimumElementsRequired(1)]
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
