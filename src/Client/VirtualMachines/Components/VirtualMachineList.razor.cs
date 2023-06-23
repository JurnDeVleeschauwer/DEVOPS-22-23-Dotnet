using Domain.Common;
using Microsoft.AspNetCore.Components;
using Domain.VirtualMachines.BackUp;
using Domain.VirtualMachines.VirtualMachine;
using Microsoft.AspNetCore.Components.QuickGrid;
using Shared.VirtualMachines;
using Shared.Projecten;

namespace Client.VirtualMachines.Components;

public partial class VirtualMachineList
{
    [Parameter] public int ProjectId { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    [Inject] public IProjectenService ProjectService { get; set; }
    private List<VirtualMachine> virtualmachinesOfProject = new();
    private VirtualMachineDto.Index vm;
    private ProjectenDto.Detail virtualMachines;
    private IQueryable<VirtualMachine> virtualmachinesQuery;
    private int _total;
    /*record VirtualMachine(string Name, string User, string Os, string Hardware, DateOnly BackUp);*/
    /*IQueryable<VirtualMachine> vms = new[]
    {
        new VirtualMachine("KaliLinux_4gb_4vCpu", "Dellaware","KALI_LINUX", "100gb, 4gb, 4 cores" , new DateOnly(2022, 6,25)),
        new VirtualMachine("Fedora36_4gb_4vCpu", "EerstejaarsHoGent","FEDORA_36", "160gb, 4gb, 4 cores", new DateOnly(2021, 8, 19)),
        new VirtualMachine("Windows10_8gb_16vCpu", "TweedejarsHoGent","WINDOWS_10", "200gb, 8gb, 16 cores",new DateOnly(2022, 1 ,2)),
        new VirtualMachine("KaliLinux_4gb_4vCpu", "Apple","KALI_LINUX", "100 gb , 4gb , 4 cores" ,new DateOnly(2022, 4, 30)),
        new VirtualMachine("KaliLinux_4gb_4vCpu", "DocentenHoGent","KALI_LINUX", "100gb, 4gb, 4 cores" ,new DateOnly(2022, 10, 15)),
        new VirtualMachine("KaliLinux_4gb_4vCpu", "HoGent","KALI_LINUX", "100gb, 4gb, 4 cores" ,new DateOnly(2021, 12, 12)),
    }.AsQueryable();*/

    protected override async Task OnInitializedAsync()
    {
        /*VirtualMachineRequest.GetIndex request = new();
        var response = await VirtualMachineService.GetIndexAsync(request);
        virtualMachines = response.VirtualMachines;
        _total = response.TotalAmount;*/
        //virtualMachines = response.VirtualMachines;
        ProjectenRequest.GetDetail request = new() { ProjectenId = ProjectId };
        var response = await ProjectService.GetDetailAsync(request);
        virtualmachinesOfProject = response.Projecten.VirtualMachines;
        virtualmachinesQuery = virtualmachinesOfProject.AsQueryable();
    }

    private void NavigateToDetail()
    {
        NavigationManager.NavigateTo($"virtualmachine/{vm.Id}");
    }

    private void OpenVirtualMachine()
    {
        var callBack = EventCallback.Factory.Create(this, NavigateToDetail);

    }
}
