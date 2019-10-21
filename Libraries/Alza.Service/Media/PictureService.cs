using Alza.Data;

namespace Alza.Services.Media
{
    /// <summary>
    /// Picture service
    /// </summary>
    public partial class PictureService : CommonService, IPictureService
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Ctor

        public PictureService(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public methods

        #endregion
    }
}
