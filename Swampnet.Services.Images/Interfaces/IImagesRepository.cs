using Microsoft.AspNetCore.Http;
using Swampnet.Services.Images.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swampnet.Services.Images.Interfaces
{
    public interface IImagesRepository
    {
		Task<ImageDetails> SaveAsync(IFormFile file);
    }
}
