global using Microsoft.AspNetCore.Http;

namespace Wajba.Services.ImageService;

public interface IImageService
{
    Task<string> UploadAsync(IFormFile file);
}
