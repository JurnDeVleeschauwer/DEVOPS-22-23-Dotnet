using Append.Blazor.Sidepanel;
using Microsoft.AspNetCore.Components;
using Shared.Projecten;
using Client.VirtualMachines.Components;
using Microsoft.AspNetCore.Components.Web;
using JetBrains.Annotations;
using System;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Users;

namespace Client.Projecten
{
    public partial class ProjectUserManagement
    {
        [Inject] public IProjectenService ProjectService { get; set; }
        [Inject] public IUserService UserService { get; set; }
        [Inject] NavigationManager Router { get; set; }
        [Inject] ISidepanelService Sidepanel { get; set; }

        private SidepanelComponent sidepanel;
        [Parameter] public int ProjectId { get; set; }

        private ProjectenDto.Detail _project;
        private List<UserDto.Detail> _users = new();

        private List<UserDto.Index> Users = new();


        protected override async Task OnInitializedAsync()
        {
            GetUsersAsync();
            ProjectenRequest.GetDetail request = new();
            request.ProjectenId = ProjectId;

            var response = await ProjectService.GetDetailAsync(request);
            _project = response.Project;

            foreach (var user in _project.Users)
            {
                UserRequest.Detail request1 = new();
                request1.UserId = user.UserId;
                var response1 = await UserService.GetDetail(request1);
                _users.Add(response1.User);
                foreach (var user2 in Users)
                {
                    if (user2.Id == response1.User.Id)
                    {
                        Users.Remove(user2);
                        break;
                    }
                }
            }

        }

        public async Task AddUserToProject(String UserId)
        {
            ProjectenRequest.AddUserFromProject request = new();
            request.ProjectenId = ProjectId;
            request.UserId = UserId;
            await ProjectService.AddUserFromProject(request);
            StateHasChanged();
        }

        public async Task RemoveUserToProject(String UserId)
        {
            ProjectenRequest.RemoveUserFromProject request = new();
            request.ProjectenId = ProjectId;
            request.UserId = UserId;
            await ProjectService.RemoveUserFromProject(request);
            _users.Clear();
            StateHasChanged();
            //TODO not StateHasChanged working
        }

        /*private void OpenChooseForm()
        {
            var callback = EventCallback.Factory.Create(this, GetProductAsync);

            var parameters = new Dictionary<string, object>();
            foreach (var user in Users)
            {
                { nameof(Index.Id), user.Id },
                { nameof(Index.User),callback  }
            }
            Sidepanel.Open<Index>("Product", "Wijzigen", parameters);
        }*/

        private async Task GetUsersAsync()
        {
            UserRequest.GetIndex request1 = new();
            var response = await UserService.GetIndexAsync(request1);
            Users = response.Users;
        }

    }
}