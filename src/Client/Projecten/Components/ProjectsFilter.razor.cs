using Client.Shared;
using Microsoft.AspNetCore.Components;
using Domain.VirtualMachines.VirtualMachine;

namespace Client.Projecten.Components
{
    public partial class ProjectsFilter
    {
        [Parameter] public ProjectFilter Filter { get; set; }
    }
}
