using Ardalis.GuardClauses;
using Bogus.DataSets;
using Domain.Common;
using Domain.Utility;
using System;


namespace Domain
{
    public abstract class Gebruiker : Entity
    {

        private string _name;
        private string _first_name;
        private string _phoneNr;
        private string _email;
        private string _password;

        public int Id { get; set; }

        public String UserId { get; set; }
        public String Name { get { return _name; } set { _name = Guard.Against.NullOrEmpty(value, nameof(_name)); } }
        public String FirstName { get { return _first_name; } set { _first_name = Guard.Against.NullOrEmpty(value, nameof(_first_name)); } }
        public String PhoneNumber { get { return _phoneNr; } set { if (PropertyValidator.IsPhoneNumberValid(value)) _phoneNr = value; } }
        public String Email { get { return _email; } set { if (PropertyValidator.IsValidEmail(value)) _email = value; } }
        public String Password { get { return _password; } set { _password = Guard.Against.InvalidFormat(value, nameof(_password), @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,}$"); } }


        /*
         * Password validation: 
             *  Min length: 6
             *  Max Length: ? 
             *  1 Uppercase letter
             *  1 Lowercase letter
             *  1 Digit
         */


        public Gebruiker(string name, string firstname, string phoneNumber, string email, string password)
        {
            this.Name = name;
            this.FirstName = firstname;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Password = password;
        }



        public Gebruiker()
        {
        }
    }
}