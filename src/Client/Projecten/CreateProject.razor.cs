using Domain.VirtualMachines.VirtualMachine;
using Microsoft.AspNetCore.Components;
using Shared.Users;
using Shared.VirtualMachines;
using Domain.Users;
using Shared.Projecten;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Projecten
{
    public partial class CreateProject
    {
        private ProjectenDto.Create model = new();
        [Parameter] public String UserId { get; set; }
        [Inject] public IProjectenService ProjectService { get; set; }
        [Inject] public IUserService userService { get; set; }
        [Inject] NavigationManager NavMan { get; set; }
        [Inject] public AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }


        private async void CreateProjectAsync()
        {
            ProjectenRequest.Create request = new()
            {
                Project = model
            };
            var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
            var user = authstate.User;
            var identity = user.Identities.First();
            if (identity != null)
            {
                request.Project.UserId = identity.Claims.Where(claim => "sub".Equals(claim.Type)).First().Value;
            }




            await ProjectService.CreateAsync(request);


            NavMan.NavigateTo($"projecten/");
        }
    }
}
