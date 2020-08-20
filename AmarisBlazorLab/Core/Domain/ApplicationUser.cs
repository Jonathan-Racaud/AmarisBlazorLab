using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AmarisBlazorLab.Core.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public IList<UserProject> UserProjects { get; set; }
    }
}
