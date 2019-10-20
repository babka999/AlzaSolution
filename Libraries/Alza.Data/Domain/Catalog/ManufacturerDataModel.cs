namespace Alza.Data.Domain.Catalog
{
    /// <summary>
    /// Represents a manufacturer
    /// </summary>
    public partial class ManufacturerDataModel : BaseEntity
    { 
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
    }
}
