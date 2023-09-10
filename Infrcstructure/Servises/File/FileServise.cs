namespace Infrcstructure.Servises.File;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


public class FileServise:IFileServise
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileServise(IWebHostEnvironment webHostEnvironment) => _webHostEnvironment = webHostEnvironment;

    public async Task<string> CreateFile(string folder, IFormFile file)
    {
         var fullPath = Path.Combine(_webHostEnvironment.WebRootPath,folder,file.FileName);
        await using var stream = new FileStream(fullPath,FileMode.Create);
        await file.CopyToAsync(stream);
        return file.FileName;
    }

    public Task<bool> DeleteFile(string folder, string fileName)
    {
            var fullPath= Path.Combine(_webHostEnvironment.WebRootPath,folder,fileName);
            System.IO.File.Delete(fullPath);
            return Task.FromResult(true);
    }
}
