using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utility
{
    public class Wachtwoord : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var wachtwoord = value.ToString();


            if (!(wachtwoord.Length >= 8)) return new ValidationResult("To Short needs to be 8 long");
            if (!wachtwoord.Any(x => char.IsUpper(x))) return new ValidationResult("Must contain Upper Case");
            if (!wachtwoord.Any(x => char.IsLower(x))) return new ValidationResult("Must contain Lower Case");
            if (!wachtwoord.Any(x => char.IsDigit(x))) return new ValidationResult("Must contain Number");
            if (!wachtwoord.Any(x => !char.IsLetterOrDigit(x))) return new ValidationResult("Must contain Special characters like !@#$%^&*");

            return ValidationResult.Success;

        }
    }
}
