﻿using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Data.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override Project Get(int id)
        {
            var project = Context.Set<Project>()
                .Include(p => p.Owner)
                .Include(p => p.ProjectCategories).ThenInclude(pc => pc.Category)
                .Include(p => p.UserProjects).ThenInclude(up => up.User)
                .Single(p => p.Id == id);

            return project;
        }

        public override IEnumerable<Project> GetAll()
        {
            return Context.Set<Project>()
                .Include(p => p.Owner)
                .Include(p => p.ProjectCategories).ThenInclude(pc => pc.Category)
                .Include(p => p.UserProjects).ThenInclude(up => up.User);
        }

        public IEnumerable<Project> GetCompletedProjects()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetLatest()
        {
            return Context.Set<Project>().Take(10).ToList();
        }

        public IEnumerable<Project> GetProjectsWithUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
