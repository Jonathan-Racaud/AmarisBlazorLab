using AmarisBlazorLab.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Core.DTO
{
    public class UserRegistration
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public List<string> Roles { get; set; }

        public List<Project> Projects { get; set; }
    }
}
