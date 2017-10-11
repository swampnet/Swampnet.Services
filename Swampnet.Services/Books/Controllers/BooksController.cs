using Microsoft.AspNetCore.Mvc;
using Swampnet.Services.Books.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Swampnet.Services.Books.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/books/query")]
        public async Task<IActionResult> Get(string query)
        {
            try
            {
                var books = await _repository.SearchAsync(query);

                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
