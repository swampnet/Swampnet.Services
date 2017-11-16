using Swampnet.Services.Books.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swampnet.Services.UnitTests.Mocks.Books
{
    internal class BookMocks
    {
        public BookDetails BookDetails()
        {
            return new BookDetails()
            {
                Title = "To kill a Mocked up Bird",
                Author = "Mocky Mac Mockface",
                Isbn10 = "0123456789",
                Isbn13 = "ABC0123456789"
            };
        }


        public MockedBookRepository BooksRepository()
        {
            return new MockedBookRepository();
        }
    }
}
