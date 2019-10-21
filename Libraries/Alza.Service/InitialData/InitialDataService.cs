using Alza.Data.Domain.Catalog;
using Alza.Services.Catalog;
using Alza.Services.Media;
using System.Threading.Tasks;

namespace Alza.Services.InitialData
{
    /// <summary>
    /// Initial data service
    /// </summary>
    public class InitialDataService
    {
        #region Fields

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IPictureService _pictureService;

        #endregion

        #region Ctor

        public InitialDataService(IProductService productService,
            ICategoryService categoryService,
            IManufacturerService manufacturerService,
            IPictureService pictureService)
        {
            _categoryService = categoryService;
            _manufacturerService = manufacturerService;
            _pictureService = pictureService;
            _productService = productService;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Set basic data in database at first run.
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {
            var aaa = 1;
            var bum = _categoryService.Any();
            var bbb = 1;
        }

        #endregion
    }
}
