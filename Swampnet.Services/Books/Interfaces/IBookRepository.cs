using Swampnet.Services.Books.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swampnet.Services.Books.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDetails>> SearchAsync(string query);
    }
}
