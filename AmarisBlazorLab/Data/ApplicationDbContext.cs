using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmarisBlazorLab.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AmarisBlazorLab.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Material> Materials { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserProject>().HasKey(up => new { up.UserId, up.ProjectId });
            builder.Entity<ProjectCategory>().HasKey(pc => new { pc.ProjectId, pc.CategoryId });
        }
    }
}
