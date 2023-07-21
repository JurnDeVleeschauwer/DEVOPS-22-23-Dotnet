using Domain.VirtualMachines.VirtualMachine;
using Microsoft.AspNetCore.Components;
using Shared.Users;
using Shared.VirtualMachines;
using Domain.Users;
using Shared.Projecten;

namespace Client.Projecten
{
    public partial class CreateProject
    {
        private ProjectenDto.Create model = new();
        [Parameter] public String UserId { get; set; }
        [Inject] public IProjectenService ProjectService { get; set; }
        [Inject] public IUserService userService { get; set; }
        [Inject] NavigationManager NavMan { get; set; }


        private async void CreateProjectAsync()
        {
            ProjectenRequest.Create request = new()
            {
                Project = model
            };
            request.Project.UserId = "auth0|6390964a894d42544f733938";



            await ProjectService.CreateAsync(request);


            NavMan.NavigateTo($"projecten/");
        }
    }
}
