using Alza.Data.Domain.Catalog;
using Alza.Services.Catalog;
using Alza.Services.Media;
using AlzaWebApi.Models;
using AlzaWebApi.V1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace AlzaWebApi.V1.Controllers
{
    /// <summary>
    /// Product controler v 1.0
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        #region Fields

        private readonly IPictureService _pictureService;
        private readonly IProductService _productService;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor 
        /// </summary>
        public ProductController(IPictureService pictureService,
            IProductService productService)
        {
            _pictureService = pictureService;
            _productService = productService;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// List of available products.
        /// </summary>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductModel>), 200)]
        public ActionResult AllProducts()
            => Ok(_productService.AllProducts().Select(x => new ProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                ImgUri = _pictureService.GetPictureUri(x.Id)
            }));

        /// <summary>
        /// Product by id.
        /// </summary>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(typeof(ProductModel), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Route("{id}")]
        public ActionResult ProductById(int id)
        {
            if (_productService.ProductByKey(id) is ProductDataModel p)
                return Ok(new ProductModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImgUri = _pictureService.GetPictureUri(p.Id)
                });
            return BadRequest(ErrorModel.GetErrorModel("Bad request.", "Id does not exist.", HttpStatusCode.BadRequest));
        }

        /// <summary>
        /// Update product description.
        /// </summary>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [Route("{id}")]
        public ActionResult UpdataProductDescription(int id, UpdateProductModel model)
        {
            if (_productService.ProductByKey(id) is ProductDataModel p)
            {
                p.Description = model.Description;
                _productService.UpdateProduct(p);
                return Ok();
            }  
            return BadRequest(ErrorModel.GetErrorModel("Bad request.", "Id does not exist.",HttpStatusCode.BadRequest));
        }

        #endregion
    }
}