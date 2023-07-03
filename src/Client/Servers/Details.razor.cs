using Microsoft.AspNetCore.Components;
using Shared.FysiekeServers;
using Shared.VirtualMachines;
using Smart.Blazor;
using System.Runtime.CompilerServices;
using UnlockedData.Chartist.Blazor;
using UnlockedData.Chartist.Blazor.Core.Data;

namespace Client.Servers;

public partial class Details
{
    [Parameter] public int Id { get; set; }

    [Inject] IFysiekeServerService Service { get; set; }
    private FysiekeServerDto.Detail server;
    private List<VirtualMachineDto.Rapportage> virtualMachinesServer = new();
    public Dictionary<int, bool> Collapsed { get; set; } = new Dictionary<int, bool>();
    public List<int> Loading { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        FysiekeServerRequest.GetDetail request = new FysiekeServerRequest.GetDetail();
        request.FysiekeServerId = Id;
        var response = await Service.GetDetailAsync(request);
        server = response.FysiekeServer;
        if (server.VirtualMachines != null)
        {
            virtualMachinesServer = server.VirtualMachines;
        }
    }

    public async void Toggle(int id)
    {

        if (!Collapsed.ContainsKey(id))
        {
            Collapsed.Add(id, true);
        }
        else
        {
            Collapsed[id] = !Collapsed[id];
        }

        StateHasChanged();
    }

}