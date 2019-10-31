using Alza.Data;
using Alza.Data.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alza.Services.Catalog
{
    /// <summary>
    /// Product service
    /// </summary>
    public partial class ProductService : IProductService
    {
        #region Fields

        private readonly ICommonService _commonService;

        #endregion

        #region Ctor

        public ProductService(ICommonService commonService)
        {
            _commonService = commonService;
        }

        public ProductService(string connectionString)
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(connectionString);
            _commonService = new CommonService(new ApplicationDbContext(optionsBuilder.Options));
        }

        #endregion

        #region Public methods

        #region Product

        /// <summary>
        /// Add product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual ProductDataModel AddProduct(ProductDataModel model) => _commonService.Add(model);

        /// <summary>
        /// Has product
        /// </summary>
        /// <returns></returns>
        public virtual bool AnyProduct() => _commonService.Any<ProductDataModel>();

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="model"></param>
        public virtual void UpdateProduct(ProductDataModel model) => _commonService.Update(model);

        /// <summary>
        /// All products
        /// </summary>
        /// <returns></returns>
        public virtual List<ProductDataModel> AllProducts() => _commonService.GetAll<ProductDataModel>();

        /// <summary>
        /// Product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual ProductDataModel ProductByKey(int id) => _commonService.GetByKey<ProductDataModel>(typeof(ProductDataModel), id);

        #endregion

        #region Product category

        /// <summary>
        /// Add product category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual ProductCategoryDataModel AddProductCategory(ProductCategoryDataModel model) => _commonService.Add(model);

        #endregion

        #endregion

        #region Async public methods

        #region Product

        /// <summary>
        /// Add product async
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async virtual Task<EntityEntry<ProductDataModel>> AddProductAsync(ProductDataModel model) => await _commonService.AddAsync(model);

        /// <summary>
        /// Has product async
        /// </summary>
        /// <returns></returns>
        public async virtual Task<bool> AnyProductAsync() => await _commonService.AnyAsync<ProductDataModel>();

        /// <summary>
        /// Update product async
        /// </summary>
        /// <param name="model"></param>
        public async virtual Task UpdateProductAsync(ProductDataModel model) => await _commonService.UpdateAsync(model);

        /// <summary>
        /// All products async
        /// </summary>
        /// <returns></returns>
        public async virtual Task<List<ProductDataModel>> AllProductsAsync() => await _commonService.GetAllAsync<ProductDataModel>();

        /// <summary>
        /// Product by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async virtual Task<ProductDataModel> ProductByKeyAsync(int id) => await _commonService.GetByKeyAsync<ProductDataModel>(typeof(ProductDataModel), id);

        #endregion

        #region Product category

        /// <summary>
        /// Add product category async
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async virtual Task<EntityEntry<ProductCategoryDataModel>> AddProductCategoryAsync(ProductCategoryDataModel model) => await _commonService.AddAsync(model);

        #endregion

        #endregion
    }
}
