using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace AmarisBlazorLab.Controllers
{
    [ApiController, Route("api/download")]
    public class DownloadController: ControllerBase
    {
        [HttpGet, Route("{project}/{filename}")]
        [Authorize]
        public async Task<ActionResult> Download(string project, string filename)
        {
            var filePath = Path.Join(Directory.GetCurrentDirectory(), "wwwroot", "materials", project, filename);
            var fstream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            
            var data = new byte[fstream.Length];
            await fstream.ReadAsync(data, 0, data.Length);
            fstream.Dispose();

            var mstream = new MemoryStream(data);

            string contentType;
            new FileExtensionContentTypeProvider().TryGetContentType(filePath, out contentType);
            var result = new FileStreamResult(mstream, contentType);
            result.FileDownloadName = filename;

            return result;
        }
    }
}