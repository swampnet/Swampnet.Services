using Microsoft.AspNetCore.Http;
using Swampnet.Services.Files.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swampnet.Services.Files.Interfaces
{
    public interface IImagesRepository
    {
		Task<ImageDetails> SaveAsync(IFormFile file);
    }
}
