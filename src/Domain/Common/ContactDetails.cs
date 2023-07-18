using Ardalis.GuardClauses;
using Domain.Utility;
using System;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class ContactDetails : Entity
    {

        private string _phoneNumber;
        private string _email;
        private string _fName;
        private string _lName;

        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }


        public ContactDetails() { }

        public ContactDetails(string phone, string email, string fName, string lName)
        {
            this.PhoneNumber = phone;
            this.Email = email;
            this.FirstName = fName;
            this.LastName = lName;

        }

    }
}
