using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.LineChart;
using ChartJs.Blazor.Util;
using Domain.Common;
using Microsoft.AspNetCore.Components;
using System.Drawing;
using ChartJs.Blazor;
using Shared.FysiekeServers;

namespace Client.Servers
{
    public partial class Beschikbaarheid
    {
        [Inject] public IFysiekeServerService FysiekeServerService { get; set; }

        private List<FysiekeServerDto.Beschikbaarheid> Servers { get; set; }
        private Dictionary<DateTime, Hardware> _data = new();

        private FysiekeServerRequest.Date request = new();
        private DateTime DateStart { get; set; } = DateTime.Now;
        private DateTime DateEnd { get; set; } = DateTime.Now;


        protected override async Task OnInitializedAsync()
        {
            request.FromDate = DateTime.Now;//TODO error when going ??
            request.ToDate = DateTime.Now; //TODO error when setting to the future
            await base.OnInitializedAsync();
            await GetAvailableResources();

        }

        private async Task GetAvailableResources()
        {
            request.FromDate = DateStart.Date;
            request.ToDate = DateEnd.Date;
            loading = true;
            var response = await FysiekeServerService.GetAvailableHardWareOnDate(request);
            Servers = response.Servers;
            loading = false;
        }

        private async Task GetAvailableResourcesTotal()
        {
            loading = true;
            var response = await FysiekeServerService.GetGraphValueForServer(new FysiekeServerRequest.GetIndex());
            _data = response.GraphData;
            loading = false;
        }
    }
}



