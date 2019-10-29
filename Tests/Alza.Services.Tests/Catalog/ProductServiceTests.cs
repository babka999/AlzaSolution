using Alza.Services.Catalog;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Alza.Services.Tests.Catalog
{
    [TestFixture]
    public class ProductServiceTests
    {
        private IProductService _productService;

        [SetUp]
        public void Setup()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();
            _productService = new ProductService(config["ConnectionStrings:DefaultConnection"]);
        }

        [Test]
        public void Test1()
        {
            var aaa = _productService.AllProducts();
            Assert.Pass();
        }
    }
}
