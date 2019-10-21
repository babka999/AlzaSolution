using Alza.Data.Domain.Media;
using System.Collections.Generic;

namespace Alza.Data.Domain.Catalog
{
    /// <summary>
    /// Represents a product
    /// </summary>
    public partial class ProductDataModel : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Gets or sets the price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the manufacturerId
        /// </summary>
        public int ManufacturerId { get; set; }

        /// <summary>
        /// Gets or sets the PpctureId
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer
        /// </summary>
        public virtual ManufacturerDataModel Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the picture
        /// </summary>
        public virtual PictureDataModel Picture { get; set; }

        /// <summary>
        /// Gets or sets the collection of ProductCategory
        /// </summary>
        public virtual ICollection<ProductCategoryDataModel> ProductCategories { get; set; }
    }
}
