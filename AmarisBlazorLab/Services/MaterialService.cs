using AmarisBlazorLab.Core;
using AmarisBlazorLab.Core.Domain;
using AmarisBlazorLab.Core.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Services
{
    public class MaterialService
    {
        private readonly IUnitOfWork unitOfWork;

        public MaterialService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Material> GetAllFromProject(Project project)
        {
            return unitOfWork.Materials.GetAllFromProject(project.Id).ToList();
        }

        public async Task<bool> Upload(MaterialUpload materialIn)
        {
            if (string.IsNullOrEmpty(materialIn.Name) ||
                string.IsNullOrEmpty(materialIn.MaterialRealName) ||
                (materialIn.Project == null) ||
                (materialIn.Type == null))
            {
                Console.Error.WriteLine("Invalid parameters for uploading material");
                Console.Error.WriteLine($"Name: {materialIn.Name}, Real Name: {materialIn.MaterialRealName}");
                Console.Error.WriteLine($"Project: {materialIn.Project}, Type: {materialIn.Type}");
                return false;
            }

            var source = string.Empty;
            if (materialIn.Type.Name != "Url")
            {
                var folderName = Path.Combine(Directory.GetCurrentDirectory(), "Data", "materials", materialIn.Project.Name);

                try
                {
                    Directory.CreateDirectory(folderName);
                }
                catch (IOException e)
                {
                    Console.Error.WriteLine($"Error: Couldn't create directory: {folderName}. Reason: {e.Message}");
                    return false;
                }

                source = Path.Combine(folderName, materialIn.MaterialRealName);

                try
                {
                    using (var st = new FileStream(source, FileMode.OpenOrCreate))
                    {
                        await materialIn.File.WriteToStreamAsync(st);
                    }
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine($"Error: Couldn't write file: {materialIn.Name}. Reason: {e.Message}");
                    return false;
                }
            }
            else
            {
                source = materialIn.Name;
            }

            var material = new Material
            {
                Name = materialIn.Name,
                Source = source,
                Project = materialIn.Project,
                MaterialType = materialIn.Type
            };

            unitOfWork.Materials.Add(material);
            unitOfWork.Complete();

            return true;
        }

        public List<MaterialType> GetAllTypes()
        {
            return unitOfWork.MaterialTypes.GetAll().ToList();
        }
    }
}
