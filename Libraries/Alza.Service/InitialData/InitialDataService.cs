using Alza.Data.Domain.Catalog;
using Alza.Data.Domain.Media;
using Alza.Services.Catalog;
using System;

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
        /// Set basic data in database at first run.
        /// </summary>
        /// <returns></returns>
        public void Seed()
        {
            if (!_productService.AnyProduct())
            {
                for (int i = 1; i <= 5; i++)
                {
                    ProductDataModel product = _productService.AddProduct(new ProductDataModel
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
                    _productService.AddProductCategory(new ProductCategoryDataModel
                    {
                        ProductId = product.Id,
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
