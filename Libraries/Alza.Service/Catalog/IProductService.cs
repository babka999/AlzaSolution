using Alza.Data.Domain.Catalog;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alza.Services.Catalog
{
    /// <summary>
    /// Product service interface
    /// </summary>
    public partial interface IProductService
    {
        #region Public methods

        #region Product

        /// <summary>
        /// Add product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ProductDataModel AddProduct(ProductDataModel model);

        /// <summary>
        /// Has product
        /// </summary>
        /// <returns></returns>
        bool AnyProduct();

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="model"></param>
        void UpdateProduct(ProductDataModel model);

        /// <summary>
        /// All products
        /// </summary>
        /// <returns></returns>
        List<ProductDataModel> AllProducts();

        /// <summary>
        /// Product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductDataModel ProductByKey(int id);

        #endregion

        #region Product category

        /// <summary>
        /// Add product category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ProductCategoryDataModel AddProductCategory(ProductCategoryDataModel model);

        #endregion

        #endregion

        #region Async public methods

        #region Product

        /// <summary>
        /// Add product async
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<EntityEntry<ProductDataModel>> AddProductAsync(ProductDataModel model);

        /// <summary>
        /// Has product async
        /// </summary>
        /// <returns></returns>
        Task<bool> AnyProductAsync();

        /// <summary>
        /// Update product async
        /// </summary>
        /// <param name="model"></param>
        Task UpdateProductAsync(ProductDataModel model);

        /// <summary>
        /// All products async
        /// </summary>
        /// <returns></returns>
        Task<List<ProductDataModel>> AllProductsAsync();

        /// <summary>
        /// Product by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductDataModel> ProductByKeyAsync(int id);

        #endregion

        #region Product category

        /// <summary>
        /// Add product category async
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<EntityEntry<ProductCategoryDataModel>> AddProductCategoryAsync(ProductCategoryDataModel model);

        #endregion

        #endregion
    }
}
