using Domain.VirtualMachines.VirtualMachine;
using Microsoft.AspNetCore.Components;
using Shared.Users;
using Shared.VirtualMachines;
using Domain.Users;
using Shared.Projecten;
using Microsoft.AspNetCore.Components.Authorization;
using Client.Shared;

namespace Client.Projecten
{
    public partial class CreateProject
    {
        private ProjectenDto.Create model = new();
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

            request.Project.UserId = await GetUserId.GetUserIdAsync(GetAuthenticationStateAsync);

            await ProjectService.CreateAsync(request);


            NavMan.NavigateTo($"projecten/");
        }
    }
}
