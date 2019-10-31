using Alza.Services.Catalog;
using Alza.Services.InitialData;
using Alza.Services.Media;
using Alza.Test.Extensions;
using AlzaWebApi.V2.Controllers;
using AlzaWebApi.V2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AlzaWebApi.Tests.V2
{
    [TestFixture]
    public class ProductControllerTests
    {
        #region Fields

        private ProductController _productController;
        private IProductService _productService;

        #endregion

        #region SetUp

        [SetUp]
        public async Task Setup()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();
            _productService = new ProductService(config["ConnectionStrings:DefaultConnection"]);
            _productController = new ProductController(new PictureService(), _productService);
            await new InitialDataService(_productService).Seed();
        }

        #endregion

        #region Test methods

        [Test]
        public async Task Return_all_products()
            => (((ObjectResult) await _productController.AllProducts()).StatusCode ?? (int)HttpStatusCode.InternalServerError).ShouldEqual((int)HttpStatusCode.OK);

        [Test]
        public async Task Return_product_by_id()
        {
            int productId = (await _productService.AllProductsAsync()).FirstOrDefault().Id;
            (((ObjectResult) await _productController.ProductById(productId)).StatusCode ?? (int)HttpStatusCode.InternalServerError).ShouldEqual((int)HttpStatusCode.OK);
        }

        [Test]
        public async Task Product_not_found()
            => (((ObjectResult) await _productController.ProductById(int.MinValue)).StatusCode ?? (int)HttpStatusCode.InternalServerError).ShouldEqual((int)HttpStatusCode.NotFound);

        [Test]
        public async Task Updated_product()
        {
            int productId = (await _productService.AllProductsAsync()).FirstOrDefault().Id;
            ((OkResult) await _productController.UpdataProductDescription(productId, new UpdateProductModel { Description = "Test - update description" })).StatusCode.ShouldEqual((int)HttpStatusCode.OK);
        }

        [Test]
        public async Task Updated_product_not_found()
            => (((ObjectResult) await _productController.UpdataProductDescription(int.MinValue, new UpdateProductModel { Description = "Test - update description" })).StatusCode ?? (int)HttpStatusCode.InternalServerError).ShouldEqual((int)HttpStatusCode.NotFound);

        [Test]
        public async Task Updated_product_bad_request()
        {
            int productId = (await _productService.AllProductsAsync()).FirstOrDefault().Id;
            (((ObjectResult) await _productController.UpdataProductDescription(productId, new UpdateProductModel
            {
                Description = @"Test max length is 500.
                                Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante. In sem justo, commodo ut, suscipit at, pharetra vitae, orci. Sed ac dolor sit amet purus malesuada congue. Praesent vitae arcu tempor neque lacinia pretium. Mauris dictum facilisis augue. Aliquam erat volutpat. Cras elementum. Etiam commodo dui eget wisi. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Phasellus rhoncus. Morbi imperdiet, mauris ac auctor dictum, nisl ligula egestas nulla, et sollicitudin sem purus in lacus. Aliquam ornare wisi eu metus."
            })).StatusCode ?? (int)HttpStatusCode.InternalServerError).ShouldEqual((int)HttpStatusCode.BadRequest);
        }

        #endregion
    }
}
