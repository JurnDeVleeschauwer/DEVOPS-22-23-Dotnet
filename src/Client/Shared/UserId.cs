using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Shared
{
    public static class GetUserId
    {
        public static async Task<string> GetUserIdAsync(AuthenticationStateProvider GetAuthenticationStateAsync)
        {
            //Get user ID from claim
            var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
            var user = authstate.User;
            var identity = user.Identities.First();
            return identity.Claims.Where(claim => "sub".Equals(claim.Type)).First().Value;
        }
    }
}