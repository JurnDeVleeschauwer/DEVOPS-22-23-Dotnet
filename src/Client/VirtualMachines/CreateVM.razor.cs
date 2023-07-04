using Client.Infrastructure;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Shared.VirtualMachines;
using Domain.VirtualMachines.BackUp;

namespace Client.VirtualMachines
{
    public partial class CreateVM
    {
        private VirtualMachineDto.Create virtualMachine = new();
        [Inject] public IVirtualMachineService VirtualMachineService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            virtualMachine.Backup = new Backup(BackUpType.MONTHLY, DateTime.Now);
            virtualMachine.OperatingSystem = new Domain.VirtualMachines.VirtualMachine.OperatingSystemEnum();
            virtualMachine.Hardware = new Domain.Common.Hardware();
        }

        private async Task CreateVirtualMachineAsync()
        {
            VirtualMachineRequest.Create request = new()
            {
                VirtualMachine = virtualMachine
            };

            var response = await VirtualMachineService.CreateAsync(request);

            NavigationManager.NavigateTo($"virtualMachine/{response.VirtualMachineId}");
        }

    }
}
