using Microsoft.AspNetCore.Components;
using Shared.FysiekeServers;

namespace Client.Servers;

public partial class Index
{
    [Inject] public IFysiekeServerService FysiekeServerService { get; set; }
    [Inject] public NavigationManager Router { get; set; }
    private List<FysiekeServerDto.Index> Servers { get; set; }

    protected override async Task OnInitializedAsync()
    {
        FysiekeServerRequest.GetIndex request = new();

        var response = await FysiekeServerService.GetIndexAsync(request);
        Servers = response.FysiekeServers;
    }

    public void RedirectToDetailsPage(int id)
    {
        Router.NavigateTo($"servers/{id}");

    }
}
