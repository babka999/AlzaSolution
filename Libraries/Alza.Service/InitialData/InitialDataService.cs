using Alza.Data.Domain.Catalog;
using Alza.Data.Domain.Media;
using Alza.Services.Catalog;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading.Tasks;

namespace Alza.Services.InitialData
{
    /// <summary>
    /// Initial data service
    /// </summary>
    public class InitialDataService
    {
        #region Const

        private const int MIN = 100;
        private const int MAX = 30000;

        #endregion

        #region Fields

        private static readonly Random random = new Random();
        private readonly IProductService _productService;

        #endregion

        #region Ctor

        public InitialDataService(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region Properties

        private static decimal RandomDecimal => (decimal)(MIN + (random.NextDouble() * (MAX - MIN)));

        #endregion

        #region Public methods

        /// <summary>
        /// Set async basic data in database at first run.
        /// </summary>
        /// <returns></returns>
        public async Task Seed()
        {
            if (!await _productService.AnyProductAsync())
            {
                for (int i = 1; i <= 5; i++)
                {
                    EntityEntry<ProductDataModel> product = await _productService.AddProductAsync(new ProductDataModel
                    {
                        Name = $"Produkt {i}",
                        Description = $"Popis produktu {i}",
                        Price = RandomDecimal,
                        Manufacturer = new ManufacturerDataModel
                        {
                            Name = $"Výrobce {i}",
                            Description = $"Popis výrobce {i}"
                        },
                        Picture = new PictureDataModel
                        {
                            AltAttribute = $"Obrázek {i}",
                            TitleAttribute = $"Obrázek {i}",
                            MimeType = "image/jpeg",
                            PictureBinary = new PictureBinaryDataModel()
                        }
                    });
                    await _productService.AddProductCategoryAsync(new ProductCategoryDataModel
                    {
                        ProductId = product.Entity.Id,
                        Category = new CategoryDataModel
                        {
                            Name = $"Kategorie {i}",
                            Description = $"Popis ketegorie {i}"
                        }
                    });
                }
            }
        }

        #endregion
    }
}
