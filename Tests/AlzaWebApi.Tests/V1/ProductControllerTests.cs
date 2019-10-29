using Alza.Services.Catalog;
using Alza.Services.InitialData;
using Alza.Services.Media;
using Alza.Test.Extensions;
using AlzaWebApi.V1.Controllers;
using AlzaWebApi.V1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Linq;
using System.Net;

namespace AlzaWebApi.Tests.V1
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
        public void Setup()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();
            _productService = new ProductService(config["ConnectionStrings:DefaultConnection"]);
            _productController = new ProductController(new PictureService(), _productService);
            new InitialDataService(_productService).Seed();
        }

        #endregion

        #region Test methods

        [Test]
        public void Return_all_products() 
            => (((ObjectResult)_productController.AllProducts()).StatusCode ?? (int)HttpStatusCode.InternalServerError).ShouldEqual((int)HttpStatusCode.OK);

        [Test]
        public void Return_product_by_id()
        {
            int productId = _productService.AllProducts().FirstOrDefault().Id;
            (((ObjectResult)_productController.ProductById(productId)).StatusCode ?? (int)HttpStatusCode.InternalServerError).ShouldEqual((int)HttpStatusCode.OK);
        }

        [Test]
        public void Product_not_found() 
            => (((ObjectResult) _productController.ProductById(int.MinValue)).StatusCode ?? (int) HttpStatusCode.InternalServerError).ShouldEqual((int) HttpStatusCode.NotFound);

        [Test]
        public void Updated_product()
        {
            int productId = _productService.AllProducts().FirstOrDefault().Id;
            ((OkResult)_productController.UpdataProductDescription(productId,new UpdateProductModel { Description = "Test - update description" })).StatusCode.ShouldEqual((int)HttpStatusCode.OK);
        }

        [Test]
        public void Updated_product_not_found() 
            => (((ObjectResult)_productController.UpdataProductDescription(int.MinValue, new UpdateProductModel { Description = "Test - update description" })).StatusCode ?? (int)HttpStatusCode.InternalServerError).ShouldEqual((int)HttpStatusCode.NotFound);

        [Test]
        public void Updated_product_bad_request()
        {
            int productId = _productService.AllProducts().FirstOrDefault().Id;
            (((ObjectResult)_productController.UpdataProductDescription(productId, new UpdateProductModel
            {
                Description = @"Test max length is 500.
                                Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante. In sem justo, commodo ut, suscipit at, pharetra vitae, orci. Sed ac dolor sit amet purus malesuada congue. Praesent vitae arcu tempor neque lacinia pretium. Mauris dictum facilisis augue. Aliquam erat volutpat. Cras elementum. Etiam commodo dui eget wisi. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Phasellus rhoncus. Morbi imperdiet, mauris ac auctor dictum, nisl ligula egestas nulla, et sollicitudin sem purus in lacus. Aliquam ornare wisi eu metus."
            })).StatusCode ?? (int)HttpStatusCode.InternalServerError).ShouldEqual((int)HttpStatusCode.BadRequest);
        }

        #endregion
    }
}
