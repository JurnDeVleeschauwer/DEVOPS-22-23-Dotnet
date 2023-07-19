using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utility
{
    public class Email : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = value.ToString();
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith(".")) return new ValidationResult("Email is niet correct."); // suggested by @TK-421

            if (!char.IsLetter(email.Last())) return new ValidationResult("Gsmnummer is niet correct.");
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address == trimmedEmail)
                {
                    return ValidationResult.Success;

                }
            }
            catch
            {
                return new ValidationResult("Email is niet correct.");
            }

            return new ValidationResult("Email is niet correct.");


        }
    }
}
