using Client.Infrastructure;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Shared.VirtualMachines;
using Domain.VirtualMachines.BackUp;
using Shared.Projecten;

namespace Client.VirtualMachines
{
    public partial class CreateVM
    {
        private VirtualMachineDto.Create virtualMachine = new();

        private ProjectenResponse.GetIndex projectenResponse = new();
        [Parameter] public String UserId { get; set; }
        [Inject] public IVirtualMachineService VirtualMachineService { get; set; }
        [Inject] public IProjectenService ProjectService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            virtualMachine.Backup = new Backup(BackUpType.MONTHLY, DateTime.Now);
            virtualMachine.OperatingSystem = Domain.VirtualMachines.VirtualMachine.OperatingSystemEnum.WINDOWS_10;
            virtualMachine.Hardware = new Domain.Common.Hardware(4, 64, 1);

            virtualMachine.Start = DateTime.Now;
            virtualMachine.End = DateTime.Now;

            virtualMachine.ProjectId = null;

            ProjectenRequest.GetIndexForUser request = new();


            request.UserId = UserId;

            projectenResponse = await ProjectService.GetIndexAsync(request);
        }

        private async Task CreateVirtualMachineAsync()
        {
            VirtualMachineRequest.Create request = new()
            {
                CustomerId = UserId,
                VirtualMachine = virtualMachine
            };

            var response = await VirtualMachineService.CreateAsync(request);

            NavigationManager.NavigateTo($"virtualMachine/{response.VirtualMachineId}");
        }

    }
}
