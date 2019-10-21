namespace Alza.Data.Domain.Catalog
{
    /// <summary>
    /// Represents a product category mapping
    /// </summary>
    public partial class ProductCategoryDataModel : BaseEntity
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the category identifier
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets the category
        /// </summary>
        public virtual CategoryDataModel Category { get; set; }

        /// <summary>
        /// Gets the product
        /// </summary>
        public virtual ProductDataModel Product { get; set; }
    }
}
