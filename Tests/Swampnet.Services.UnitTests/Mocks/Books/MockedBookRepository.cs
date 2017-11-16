using Swampnet.Services.Books.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Swampnet.Services.Books.Entities;
using System.Threading.Tasks;

namespace Swampnet.Services.UnitTests.Mocks.Books
{
    class MockedBookRepository : IBookRepository
    {
        public Task<BookDetails> GetAsync(string id)
        {
            return Task.FromResult(Mock.Books.BookDetails());
        }
    }
}
