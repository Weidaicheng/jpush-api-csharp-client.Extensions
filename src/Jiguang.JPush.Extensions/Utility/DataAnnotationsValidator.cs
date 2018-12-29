using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jiguang.JPush.DependencyInjection.Utility
{
    /// <summary>
    /// Data validation
    /// </summary>
    public class DataAnnotationsValidator
    {
        /// <summary>
        /// Try to validate
        /// </summary>
        /// <param name="@object">The object that you want to validate</param>
        /// <param name="results">Validation result</param>
        /// <returns>Is it passed the validation or not</returns>
        public static bool TryValidate(object @object, out ICollection<ValidationResult> results)
        {
            var context = new ValidationContext(@object, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(
                @object, context, results,
                validateAllProperties: true
            );
        }
    }
}