using AmarisBlazorLab.Core.Domain;
using Blazorise;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Core.DTO
{
    public class MaterialUpload
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string MaterialRealName { get; set; }
        [Required]
        public Project Project { get; set; }
        [Required]
        public MaterialType Type { get; set; }
        [Required]
        public IFileEntry File { get; set; }
    }
}
