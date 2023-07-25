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

        [Parameter] public int ProjectId { get; set; }

        private ProjectenDto.Detail _project;
        private List<UserDto.Detail> _users = new();


        protected override async Task OnInitializedAsync()
        {

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
            }

        }

        public void AddUserToProject(int id)
        {

        }

        public void RemoveUserToProject(int id)
        {

        }

    }
}