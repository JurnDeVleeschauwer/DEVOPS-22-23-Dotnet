using Ardalis.GuardClauses;

namespace Domain.Users
{
    public class Administrator : Gebruiker
    {
        private AdminRole _role;
        public AdminRole Role { get { return _role; } set { _role = Guard.Against.Null(value, nameof(_role)); } }
        public Administrator(string name, string firstname, string phoneNumber, string email, string password, AdminRole role) : base(name, firstname, phoneNumber, email, password)
        {
            this.Role = role;
        }
    }
}

