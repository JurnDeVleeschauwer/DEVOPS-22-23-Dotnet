namespace Shared.Authentication
{
    public static class AuthenticationResponse
    {
        public static class Login
        {
            public class Any { }
            public class Failed : Any
            {
                public Exception? Error { get; set; }
                public string Message { get; set; }
            }

            public class Success : Any
            {
                //idk hoe we dit zien in de les, maar dacht we werkten met 0auth?
                // eventueel hier die 0auth token respond teruggeven, of eventueel de user om die te cachen in front end.

                //public Gebruiker User {get;set;}
            }
        }

        public static class Register
        {
            public class Any { }
            public class Failed : Any
            {
                public Exception? Error { get; set; }
                public string Message { get; set; }

            }
            public class Success : Any
            {
                //idk hoe we dit zien in de les, maar dacht we werkten met 0auth?
                // eventueel hier die 0auth token respond teruggeven, of eventueel de user om die te cachen in front end.

                //public Gebruiker User {get;set;}
            }
        }

    }
}
