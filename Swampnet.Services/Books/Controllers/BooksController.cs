using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swampnet.Services.Books.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Swampnet.Evl;

namespace Swampnet.Services.Books.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/books/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var book = await _repository.GetAsync(id);

                if(book == null)
                {
                    return NotFound();
                }

				Log.Information("Get: {id}", id);

				return Ok(book);
            }
            catch (Exception ex)
            {
				Log.Error(ex, ex.Message);

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
