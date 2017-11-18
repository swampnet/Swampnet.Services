using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Swampnet.Services.Images.Entities;
using Swampnet.Services.Images.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Swampnet.Services.Images.Services
{
    class ImagesRepository : IImagesRepository
    {
		private readonly IHostingEnvironment _hostingEnvironment;

		public ImagesRepository(IHostingEnvironment hostingEnvironment)
		{
			_hostingEnvironment = hostingEnvironment;
		}

		//https://www.janaks.com.np/file-upload-asp-net-core-web-api/
		public async Task<ImageDetails> SaveAsync(IFormFile file)
		{
			if(file == null)
			{
				throw new ArgumentNullException("file");
			}

			var imageDetails = new ImageDetails()
			{
				Id = Guid.NewGuid(),
				Name = file.FileName,
				ContentType = file.ContentType
			};

			var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
			var filePath = Path.Combine(uploads, imageDetails.Id.ToString() + " - " + imageDetails.Name);
			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}

			return imageDetails;
		}
	}
}
