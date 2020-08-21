using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Utils
{
    public class MinimumElementsRequiredAttribute : ValidationAttribute
    {
        private readonly int requiredElements;

        public MinimumElementsRequiredAttribute(int requiredElements)
        {
            if (requiredElements < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(requiredElements), "Minimum element count of 1 is required");
            }
        
            this.requiredElements = requiredElements;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is IEnumerable enumerable))
            {
                return new ValidationResult($"The {validationContext.DisplayName} field is required.");
            }

            int elementCount = 0;
            var enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if ((enumerator.Current != null) && (++elementCount >= requiredElements))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult($"At least {requiredElements} elements are required for the {validationContext.DisplayName} field.");
        }
    }
}
