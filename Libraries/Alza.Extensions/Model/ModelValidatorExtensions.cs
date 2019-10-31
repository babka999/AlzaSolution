using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alza.Extensions.Model
{
    public static class ModelValidatorExtensions
    {
        public static bool IsValid(this IValidator model) => model.GetValidationResults().Count == 0;

        public static List<ValidationResult> GetValidationResults(this IValidator model)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, new ValidationContext(model), validationResults, true);
            return validationResults;
        }
    }
}
