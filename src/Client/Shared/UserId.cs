using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Shared
{
    public static class UserId
    {
        [Inject] public static AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }

        public static async Task<string> GetUserIdAsync()
        {
            //Get user ID from claim
            var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
            var user = authstate.User;
            var identity = user.Identities.First();
            if (identity != null)
            {
                return identity.Claims.Where(claim => "sub".Equals(claim.Type)).First().Value;
            }
            return null;
        }
    }
}