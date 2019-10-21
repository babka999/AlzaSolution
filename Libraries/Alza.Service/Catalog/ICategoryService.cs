using Alza.Data.Domain.Catalog;

namespace Alza.Services.Catalog
{
    /// <summary>
    /// Category service interface
    /// </summary>
    public partial interface ICategoryService
    {
        /// <summary>
        /// Add category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        CategoryDataModel Add(CategoryDataModel model);

        /// <summary>
        /// Has any record
        /// </summary>
        /// <returns></returns>
        bool Any();
    }
}
