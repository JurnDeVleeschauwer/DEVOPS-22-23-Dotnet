using Domain;

namespace Shared.Authentication
{
    public static class AuthenticationRequest
    {
        public class Login
        {
            public string UserName { get; set; }
            public string Password { get; set; }

        }
        public class Register
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }

            //we moeten nog een pagina voorzien om profile te editten met contactpersonen.
            //zonder contactpersonen is het niet mogelijk om VM's te maken toch?

        }

    }
}
