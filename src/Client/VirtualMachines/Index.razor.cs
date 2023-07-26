using Append.Blazor.Sidepanel;
using Microsoft.AspNetCore.Components;
using Shared.Projecten;
using Client.VirtualMachines.Components;
using Microsoft.AspNetCore.Components.Web;
using JetBrains.Annotations;
using System;
using Microsoft.AspNetCore.Components.Routing;

namespace Client.VirtualMachines
{
    public partial class Index
    {
        [Inject] public IProjectenService ProjectService { get; set; }
        [Inject] public ISidepanelService Sidepanel { get; set; }

        [Inject] NavigationManager Router { get; set; }
        private readonly VirtualMachineFilter filter = new();

        private List<ProjectenDto.Index> _projects;
        private int totalFilteredAmount;

        private Dictionary<int, ProjectenDto.Detail> _details = new Dictionary<int, ProjectenDto.Detail>();

        protected override async Task OnInitializedAsync()
        {
            filter.OnVirtualMachineFilterChanged += FilterProjectsAsync;
            ProjectenRequest.GetIndex request = new();

            var response = await ProjectService.GetAllIndexAsync(request);
            _projects = response.Projecten;

        }


        public async Task GetVirtualMachines(int id)
        {
            ProjectenRequest.GetDetail request = new()
            {
                SearchTerm = filter.SearchTerm,
                Mode = filter.Mode,
                ProjectenId = id
            };


            var response = await ProjectService.GetDetailAsync(request);
            ProjectenDto.Detail resp = new ProjectenDto.Detail()
            {
                Id = response.Project.Id,
                user = response.Project.user,
                Name = response.Project.Name,
                VirtualMachines = response.Project.VirtualMachines
            };


            _details.Add(id, resp);


        }
        private async void FilterProjectsAsync()
        {
            _details.Clear();
            ProjectenRequest.GetIndex request = new()
            {
                SearchTerm = filter.SearchTerm,
                Mode = filter.Mode
            };
            var response = await ProjectService.GetAllIndexAsync(request);
            _projects = response.Projecten;
            totalFilteredAmount = response.Total;
            foreach (var item in _projects)
            {
                GetVirtualMachines(item.Id);
            }
            StateHasChanged();
        }
        public void NavigateToVMDetails(int id)
        {
            Router.NavigateTo("virtualmachine/" + id);
        }

        public void Dispose()
        {
            filter.OnVirtualMachineFilterChanged -= FilterProjectsAsync;
        }

    }
}