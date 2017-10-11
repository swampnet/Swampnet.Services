using Microsoft.Extensions.DependencyInjection;
using Swampnet.Services.Books.Interfaces;
using Swampnet.Services.Books.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swampnet.Services
{
    static class BooksStartup
    {
        public static void AddBooksApi(this IServiceCollection services)
        {
            services.AddSingleton<IBookRepository, BookRepository>();
        }
    }
}
