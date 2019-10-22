using Alza.Data.Domain.Catalog;
using System.Collections.Generic;

namespace Alza.Services.Catalog
{
    /// <summary>
    /// Product service interface
    /// </summary>
    public partial interface IProductService
    {
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
    }
}
