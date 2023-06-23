namespace Shared.Authentication
{
    public interface IAuthenticationService
    {
        public Task<AuthenticationResponse.Login.Any> Login(AuthenticationRequest.Login request);
        public Task<AuthenticationResponse.Register.Any> Register(AuthenticationRequest.Register request);
    }
}
