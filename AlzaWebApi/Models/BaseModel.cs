using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlzaWebApi.Models
{
    /// <summary>
    /// Base api model class
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Ověření validních vstupních dat
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true);
            return validationResults.Count == 0;
        }
    }
}
