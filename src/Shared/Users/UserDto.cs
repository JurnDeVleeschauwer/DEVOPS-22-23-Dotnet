using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Users;
using Domain.Utility;
using FluentValidation;
using Shared.Projecten;

namespace Shared.Users
{
    public static class UserDto
    {
        public class Index
        {
            public String Id { get; set; }
            public string FirstName { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public Role Role { get; set; }
        }

        public class Detail : Index
        {
            public string? Bedrijf { get; set; }
            public Course? Course { get; set; }
            public List<ProjectenDto.Index> Projects { get; set; }
            //public ContactDetails? contactPersoon { get; set; }
        }

        public class Mutate
        {
            [Required(ErrorMessage = "Je moet een voornaam ingeven.")]
            [StringLength(20, ErrorMessage = "Naam is te lang")]
            public string FirstName { get; set; }
            [Required(ErrorMessage = "Je moet een naam ingeven.")]
            public string Name { get; set; }
            /*[Required(ErrorMessage = "Je moet een gsm-nummer ingeven.")]
            [BelgianPhoneNumber] // TODO “The phone number was not valid. Please make sure the number is correct, including country code, and “+” prefix”
            public string PhoneNumber { get; set; }*/
            [Required(ErrorMessage = "Je moet een email ingeven.")]
            [Email]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            public Course? Course { get; set; }
            public string? Bedrijf { get; set; }
            //public ContactDetails? Contactpersoon { get; set; }

            /*public class Validator : AbstractValidator<Mutate>
            {
                public Validator()
                {
                    RuleFor(x => x.FirstName).NotNull().NotEmpty().Length(1, 250).Matches("^[a-z ,.'éèëàçù-]+$");
                    RuleFor(x => x.Name).NotNull().NotEmpty().Length(1, 250);
                    RuleFor(x => PropertyValidator.IsValidEmail(x.Email));
                    RuleFor(x => PropertyValidator.IsPhoneNumberValid(x.PhoneNumber));
                    //RuleFor(x => x.Course).NotEmpty();
                    //RuleFor(x => x.Bedrijf).NotEmpty();
                }
            }*/
        }
        public class Create : Mutate
        {
            [Required(ErrorMessage = "Je moet een wachtwoord ingeven.")]
            [Wachtwoord]
            public string Password { get; set; }

            /*public new class Validator : AbstractValidator<Create>
            {
                public Validator()
                {
                    RuleFor(x => x.FirstName).NotNull().NotEmpty().Length(1, 250).Matches("^[a-z ,.'éèëàçù-]+$");
                    RuleFor(x => x.Name).NotNull().NotEmpty().Length(1, 250).Matches("^[a-z ,.'éèëàçù-]+$");
                    RuleFor(x => PropertyValidator.IsValidEmail(x.Email));
                    RuleFor(x => PropertyValidator.IsPhoneNumberValid(x.PhoneNumber));
                    //RuleFor(x => x.Course).NotEmpty();
                    //RuleFor(x => x.Bedrijf).NotEmpty();
                    RuleFor(x => x.Password).Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$");
                }
            }*/


        }

    }
}