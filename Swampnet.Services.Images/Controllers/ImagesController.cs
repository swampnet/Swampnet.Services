using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swampnet.Services.Images.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Swampnet.Services.Images.Controllers
{
    public class ImagesController : Controller
    { 
        private readonly IImagesRepository _images;

        public ImagesController(IImagesRepository images)
        {
            _images = images;
        }


        [HttpGet("api/images/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                await Task.CompletedTask; // HACK

                Log.Information("Get: {id}", id);

                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
