using Append.Blazor.Sidepanel;
using Microsoft.AspNetCore.Components;
using Shared.Projecten;
using Client.VirtualMachines.Components;
using Microsoft.AspNetCore.Components.Web;
using JetBrains.Annotations;
using System;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Projecten
{
    public partial class Index
    {
        [Inject] public IProjectenService ProjectService { get; set; }
        [Inject] public ISidepanelService Sidepanel { get; set; }

        [Parameter] public String UserId { get; set; }

        [Inject] NavigationManager Router { get; set; }

        private List<ProjectenDto.Index> _projects;

        private Dictionary<int, ProjectenDto.Detail> _details = new Dictionary<int, ProjectenDto.Detail>();
        [Inject] public AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }

        protected override async Task OnInitializedAsync()
        {

            ProjectenRequest.GetIndexForUser request = new();

            var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
            var user = authstate.User;
            var identity = user.Identities.First();
            if (identity != null)
            {
                request.UserId = identity.Claims.Where(claim => "sub".Equals(claim.Type)).First().Value;
            }


            var response = await ProjectService.GetIndexAsync(request);
            _projects = response.Projecten;

        }


        public async Task GetVirtualMachines(int id)
        {
            ProjectenRequest.GetDetail request = new();

            request.ProjectenId = id;

            var response = await ProjectService.GetDetailAsync(request);
            ProjectenDto.Detail resp = new ProjectenDto.Detail()
            {
                Id = response.Projecten.Id,
                user = response.Projecten.user,
                Name = response.Projecten.Name,
                VirtualMachines = response.Projecten.VirtualMachines
            };


            _details.Add(id, resp);


        }
        public void NavigateToVMDetails(int id)
        {
            Router.NavigateTo("virtualmachine/" + id);
        }

        public void NavigateToCreateProject()
        {
            Router.NavigateTo("projecten/add");
        }

    }
}