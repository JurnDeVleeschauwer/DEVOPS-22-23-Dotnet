using Client.Shared;
using Microsoft.AspNetCore.Components;
using Domain.VirtualMachines.VirtualMachine;

namespace Client.VirtualMachines.Components
{
    public partial class VirtualMachinesFilter
    {
        [Parameter] public VirtualMachineFilter Filter { get; set; }
    }
}
