using Ardalis.GuardClauses;
using Domain.Common;
using System;

namespace Domain.Users
{
    public class ExterneKlant : Klant
    {

        private string _bedrijfsNaam;
        private BedrijfType _bedrijfType;
        private ContactDetails _contactpersoon;
        private ContactDetails _resContactpersoon;
        public String Bedrijfsnaam { get { return _bedrijfsNaam; } set { _bedrijfsNaam = Guard.Against.NullOrEmpty(value, nameof(_bedrijfsNaam)); } }
        public BedrijfType Type { get { return _bedrijfType; } set { _bedrijfType = Guard.Against.Null(value, nameof(_bedrijfType)); } }
        public ContactDetails Contactpersoon { get { return _contactpersoon; } set { _contactpersoon = value; } }
        public ContactDetails ResContactpersoon { get { return _contactpersoon; } set { _contactpersoon = value; } }


        public ExterneKlant(string name, string firstname, string phoneNumber, string email, string password, string bedrijfsnaam, BedrijfType type, ContactDetails contactpersoon, ContactDetails resContactpersoon) /*: base(name, firstname, phoneNumber, email, password)*/
        {
            this.Bedrijfsnaam = bedrijfsnaam;
            this.Type = type;
            this.Contactpersoon = contactpersoon;
            this.ResContactpersoon = resContactpersoon;
        }



    }
}

