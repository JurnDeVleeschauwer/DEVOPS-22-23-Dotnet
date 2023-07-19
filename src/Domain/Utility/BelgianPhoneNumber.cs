using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utility
{
    public class BelgianPhoneNumber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string phoneNumber = value.ToString();

            if (!phoneNumber.StartsWith("+32")) return new ValidationResult("Gsmnummer is niet correct.");
            if (!phoneNumber.StartsWith("+32") && phoneNumber.Length == 12) return new ValidationResult("Vaste lijn is niet correct.");

            return ValidationResult.Success;
        }
    }
}
