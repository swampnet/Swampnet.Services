using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Swampnet.Services.Files.Entities;
using Swampnet.Services.Files.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Swampnet.Services.Files.Services
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
				ContentType = file.ContentType,
				Hash = GetHash(file)
			};

			// @TODO: Check db for existing hash and just return a reference to that file if we have one
			//		  Not sure if we should still generate a new 'id' and just link back to the same file
			//		  or literally just return the existing files Id

			var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
			var filePath = Path.Combine(uploads, imageDetails.Id.ToString() + " - " + imageDetails.Name);
			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}

			return imageDetails;
		}


		private string GetHash(IFormFile file)
		{
			// Figure out hash
			using (var md5 = MD5.Create())
			{
				using (var stream = file.OpenReadStream())
				{
					var hash = md5.ComputeHash(stream);
					return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
				}
			}
		}
	}
}
