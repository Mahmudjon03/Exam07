using Microsoft.AspNetCore.Http;

namespace Infrcstructure.Servises.File;

public interface IFileServise
{
    Task<string> CreateFile(string folder, IFormFile file);
     Task<bool> DeleteFile(string folder, string fileName);
}

