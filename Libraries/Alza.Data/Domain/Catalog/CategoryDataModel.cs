namespace Alza.Data.Domain.Catalog
{
    /// <summary>
    /// Represents a category
    /// </summary>
    public partial class CategoryDataModel : BaseEntity
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
        /// Gets or sets the parent category identifier
        /// </summary>
        public int? ParentCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the parent category
        /// </summary>
        public virtual CategoryDataModel ParentCategory { get; set; }
    }
}
