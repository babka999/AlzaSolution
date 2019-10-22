using Alza.Data.Domain.Catalog;
using System.Collections.Generic;

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
    }
}
