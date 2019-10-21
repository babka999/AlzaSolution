using Alza.Data;

namespace Alza.Services.Catalog
{
    /// <summary>
    /// Manufacturer service
    /// </summary>
    public partial class ManufacturerService : CommonService, IManufacturerService
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Ctor

        public ManufacturerService(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public methods

        #endregion
    }
}
