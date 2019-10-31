using Alza.Data.Domain.Catalog;
using Alza.Extensions.Model;
using Alza.Services.Catalog;
using Alza.Services.Media;
using AlzaWebApi.Models;
using AlzaWebApi.V2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AlzaWebApi.V2.Controllers
{
    /// <summary>
    /// Product controler v 2.0
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
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
        [MapToApiVersion("2.0")]
        [HttpGet]
        [ProducesResponseType(typeof(HashSet<ProductModel>), 200)]
        public async Task<ActionResult> AllProducts()
            => Ok((await _productService.AllProductsAsync()).Select(x => new ProductModel
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
        /// <param name="id">Product id</param>
        /// <returns></returns>
        [MapToApiVersion("2.0")]
        [HttpGet]
        [ProducesResponseType(typeof(ProductModel), 200)]
        [ProducesResponseType(typeof(ErrorModel), 404)]
        [Route("{id}")]
        public async Task<ActionResult> ProductById(int id)
        {
            if (await _productService.ProductByKeyAsync(id) is ProductDataModel p)
                return Ok(new ProductModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImgUri = _pictureService.GetPictureUri(p.Id)
                });
            return NotFound(ErrorModel.GetErrorModel("Not found.", "Id", "Id does not exist.", HttpStatusCode.NotFound));
        }

        /// <summary>
        /// Update product description.
        /// </summary>
        /// <param name="id">Product id</param>
        /// <param name="model">Update model</param>
        /// <returns></returns>
        [MapToApiVersion("2.0")]
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(typeof(ErrorModel), 404)]
        [Route("{id}")]
        public async Task<ActionResult> UpdataProductDescription(int id, UpdateProductModel model)
        {
            if (!model.IsValid())
                return BadRequest(ErrorModel.GetErrorModel(model.GetValidationResults()));
            if (await _productService.ProductByKeyAsync(id) is ProductDataModel p)
            {
                p.Description = model.Description;
                await _productService.UpdateProductAsync(p);
                return Ok();
            }
            return NotFound(ErrorModel.GetErrorModel("Not found.", "Id", "Id does not exist.", HttpStatusCode.NotFound));
        }

        #endregion
    }
}
