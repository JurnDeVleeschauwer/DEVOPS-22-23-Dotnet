using Microsoft.AspNetCore.Components;
using Shared.VirtualMachines;
using Client.VirtualMachines.Components;
using Domain.VirtualMachines.VirtualMachine;
using Client.Shared;

namespace Client.VirtualMachines;

public partial class Detail
{
    public VirtualMachineDto.Detail Virtualmachine { get; set; }
    [Inject] public IVirtualMachineService vmService { get; set; }
    [Inject] NavigationManager NavMan { get; set; }
    [Parameter] public int Id { get; set; }

    public bool Initialized { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        var request = new VirtualMachineRequest.GetDetail();
        request.VirtualMachineId = Id;
        var response = await vmService.GetDetailAsync(request);
        Virtualmachine = response.VirtualMachine;
        Initialized = true;
    }

    private void NavigateToUser()
    {
        NavMan.NavigateTo($"/User/{Virtualmachine.Contract.CustomerId}");
    }

    public void NavigateToReport()
    {
        NavMan.NavigateTo($"virtualmachine/rapport/{Virtualmachine.Id}");
    }
}
