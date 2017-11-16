using System;
using System.Collections.Generic;
using System.Text;

namespace Swampnet.Services.UnitTests.Mocks
{
    static class Mock
    {
        public static Books.BookMocks Books { get; } = new Books.BookMocks();
    }
}
