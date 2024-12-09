using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wajba.Services.ImageService
{
    public interface IImageService
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
