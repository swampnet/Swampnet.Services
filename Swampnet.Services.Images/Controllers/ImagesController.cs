using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swampnet.Services.Images.Entities;
using Swampnet.Services.Images.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Swampnet.Services.Images.Controllers
{
    /*
     * Get image by id
     * Get image history
     * Get specific image version
     * Add image
     * Update image
     * 
     */
    public class ImagesController : Controller
    { 
        private readonly IImagesRepository _images;

        public ImagesController(IImagesRepository images)
        {
            _images = images;
        }


        //https://www.janaks.com.np/file-upload-asp-net-core-web-api/
        [HttpPost("api/images")]
        public async Task<IActionResult> Post(IFormFile file)
        {
            try
            {
                await Task.CompletedTask; // HACK

                using (var stream = file.OpenReadStream())
                {
                    var name = file.FileName;
                }

                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpGet("api/images/{id}")]
        public async Task<IActionResult> Get(string id)
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

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpGet("api/images/{id}/details")]
        public async Task<IActionResult> GetDetails(string id)
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

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
