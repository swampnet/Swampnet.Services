using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swampnet.Services.Books.Entities
{
    static class Convert
    {
        public static BookDetails ToBookDetails(ISBNDBBookDetails source)
        {
            return new BookDetails()
            {
                Isbn10 = source.isbn10,
                Isbn13 = source.isbn13,
                Title = source.title,
                Author = ToAuthor(source.author_data)
            };
        }

        private static string ToAuthor(IEnumerable<ISBNDBAuthor> source)
        {
            return string.Join(" / ", source.Select(a => a.name));
        }
    }
}
