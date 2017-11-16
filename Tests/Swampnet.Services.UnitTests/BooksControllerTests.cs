using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Swampnet.Services.Books.Controllers;
using Swampnet.Services.Books.Entities;
using Swampnet.Services.UnitTests.Mocks;

namespace Swampnet.Services.UnitTests
{
    [TestClass]
    public class BooksControllerTests
    {
        [TestMethod]
        public void BooksController_Get()
        {
            var controller = new BooksController(Mock.Books.BooksRepository());

            var result = controller.Get("0123456789").Result as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            var actual = result.Value as BookDetails;
            Assert.IsNotNull(actual);
        }
    }
}
