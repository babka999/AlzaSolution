using Alza.Data;

namespace Alza.Services.Catalog
{
    /// <summary>
    /// Product service
    /// </summary>
    public partial class ProductService : CommonService, IProductService
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Ctor

        public ProductService(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public methods

        #endregion
    }
}
