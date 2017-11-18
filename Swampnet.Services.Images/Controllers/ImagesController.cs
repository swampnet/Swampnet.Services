using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swampnet.Services;
using Swampnet.Services.Images.Entities;
using Swampnet.Services.Images.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Swampnet.Services.Images.Controllers
{
	/*
     * Get image by id
     * Get image history
     * Get specific image version
     * Add image
     * Update image
     */

	public class ImagesController : Controller
    { 
        private readonly IImagesRepository _images;

		public ImagesController(IImagesRepository images)
        {
            _images = images;
		}


        [HttpPost("api/images")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            try
            {
				var details = await _images.SaveAsync(file);

				return Ok(details);
            }
            catch (Exception ex)
            {
				Log.Error(ex, ex.Message);

				return this.ServerError(ex);
            }
        }


        [HttpGet("api/images/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                await Task.CompletedTask; // HACK

                Log.Information("Get: {id}", id);

                // @TODO: From image repository. Where that gets it from we don't care.
                //        - It should probably return something we can stream back (or does *that* belong here in the web api stuff?)
                return File("~/Images/Logo.png", "image/png");

                //var image = System.IO.File.OpenRead("C:\\test\random_image.jpeg");
                //return File(image, "image/jpeg");
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

				return this.ServerError(ex);
			}
		}


        [HttpGet("api/images/{id}/details")]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            try
            {
                await Task.CompletedTask; // HACK

                Log.Information("GetDetails: {id}", id);

                return Ok(new ImageDetails()
                {
                    Id = id,
                    Name = $"Image {id}"
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

				return this.ServerError(ex);
			}
		}
    }
}
