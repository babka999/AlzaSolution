using Alza.Data.Domain.Catalog;
using System.Collections.Generic;

namespace Alza.Data.Domain.Media
{
    /// <summary>
    /// Represents a picture
    /// </summary>
    public partial class PictureDataModel : BaseEntity
    {
        /// <summary>
        /// Gets or sets the picture mime type
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or sets the "alt" attribute for "img" HTML element. If empty, then a default rule will be used (e.g. product name)
        /// </summary>
        public string AltAttribute { get; set; }

        /// <summary>
        /// Gets or sets the "title" attribute for "img" HTML element. If empty, then a default rule will be used (e.g. product name)
        /// </summary>
        public string TitleAttribute { get; set; }

        /// <summary>
        /// Gets or sets the picture binary
        /// </summary>
        public virtual PictureBinaryDataModel PictureBinary { get; set; }

        /// <summary>
        /// Gets or sets the products
        /// </summary>
        public virtual ICollection<ProductDataModel> Products { get; set; }
    }
}
