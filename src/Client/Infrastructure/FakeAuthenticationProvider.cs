using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Client.Infrastructure
{
    public class FakeAuthenticationProvider : AuthenticationStateProvider
    {
        public static ClaimsPrincipal Anonymous => new(new ClaimsIdentity());
        public static ClaimsPrincipal Guest => new(new ClaimsIdentity(new[] {
            new Claim(ClaimTypes.Name, "Guest"),
            new Claim(ClaimTypes.Role, "Guest")
        }));
        public static ClaimsPrincipal AdminConsultant => new(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "Fake Consultant Admin"),
            new Claim(ClaimTypes.Email, "fake-consultant@gmail.com"),
            new Claim(ClaimTypes.Role, "BeheerderZien"),
        }, "Fake Authentication"));

        public static ClaimsPrincipal AdminBeheer => new(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "Fake Beheer Admin"),
            new Claim(ClaimTypes.Email, "fake-beheer@gmail.com"),
            new Claim(ClaimTypes.Role, "BeheerderBeheren"),
        }, "Fake Authentication"));

        public static ClaimsPrincipal Klant => new(new ClaimsIdentity(new[]
{
            new Claim(ClaimTypes.Name, "Fake Customer"),
            new Claim(ClaimTypes.Email, "fake-customer@gmail.com"),
            new Claim(ClaimTypes.Role, "Klant"),
        }, "Fake Authentication"));


        public static ClaimsPrincipal Admin => new(new ClaimsIdentity(new[]
{
            new Claim(ClaimTypes.Name, "Fake Admin"),
            new Claim(ClaimTypes.Email, "fake-admin@gmail.com"),
            new Claim(ClaimTypes.Role, "Admin"),
        }, "Fake Authentication"));


        public ClaimsPrincipal Current { get; set; } = AdminBeheer;


        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(Current));
        }

        public void ChangeAuthenticationState(ClaimsPrincipal claims)
        {
            Current = claims;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
