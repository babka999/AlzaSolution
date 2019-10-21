using Alza.Data;
using Alza.Data.Domain.Catalog;

namespace Alza.Services.Catalog
{
    /// <summary>
    /// Category service
    /// </summary>
    public partial class CategoryService : ICategoryService
    {
        #region Fields

        private readonly ICommonService _commonService;

        #endregion

        #region Ctor

        public CategoryService(ICommonService commonService)
        {
            _commonService = commonService;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Add category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual CategoryDataModel Add(CategoryDataModel model) => _commonService.Add(model);

        /// <summary>
        /// Has any record
        /// </summary>
        /// <returns></returns>
        public virtual bool Any() => _commonService.Any<CategoryDataModel>();

        #endregion
    }
}
