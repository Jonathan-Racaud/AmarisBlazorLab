using AmarisBlazorLab.Core.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace AmarisBlazorLab.Core.DTO
{
    public class User : ApplicationUser
    {
        public User(ApplicationUser baseObject)
        {
            var properties = baseObject.GetType().GetProperties();

            properties.ToList().ForEach(property =>
            {
                if ((this.GetType().GetProperty(property.Name) != null) && property.CanWrite)
                {
                    var value = baseObject.GetType().GetProperty(property.Name).GetValue(baseObject, null);
                    this.GetType().GetProperty(property.Name).SetValue(this, value);
                }
            });
        }
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
