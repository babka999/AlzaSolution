using Alza.Extensions.Model;
using System.ComponentModel.DataAnnotations;

namespace AlzaWebApi.V2.Models
{
    /// <summary>
    /// Update product model
    /// </summary>
    public class UpdateProductModel : IValidator
    {
        /// <summary>
        /// Description
        /// </summary>
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
