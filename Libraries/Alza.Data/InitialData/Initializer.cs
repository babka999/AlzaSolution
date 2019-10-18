using System.Threading.Tasks;

namespace Alza.Data.InitialData
{
    public class Initializer
    {
        #region Fields

        private ApplicationDbContext _dbContext;

        #endregion

        #region Ctor
        public Initializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Public methods

        /// <summary>
        /// Set basic data in database at first run.
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {
            //Todo data
        }

        #endregion
    }
}
