using AlzaWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace AlzaWebApi.V1.Models
{
    /// <summary>
    /// Update product model
    /// </summary>
    public class UpdateProductModel : BaseModel
    {
        /// <summary>
        /// Description
        /// </summary>
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
