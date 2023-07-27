using Append.Blazor.Sidepanel;
using Microsoft.AspNetCore.Components;
using Shared.Projecten;
using Shared.Users;
using Client.Projecten.Components;

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
        private readonly ProjectFilter filter = new();

        private ProjectenDto.Detail _project;
        private List<UserDto.Detail> _users = new();

        private List<UserDto.Index> Users = new();


        protected override async Task OnInitializedAsync()
        {
            _users.Clear();
            UserRequest.GetIndex request1 = new();
            var response = await UserService.GetIndexAsync(request1);
            Users = response.Users;

            filter.OnProjectFilterChanged += FilterUsersAsync;
            filter.OnProjectFilterChanged += GetProjectWithUsersAndRemoveUsersOtOfChoicesWithAddUsers;
            GetProjectWithUsersAndRemoveUsersOtOfChoicesWithAddUsers();

        }

        public async void GetProjectWithUsersAndRemoveUsersOtOfChoicesWithAddUsers()
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
                foreach (var user2 in Users)
                {
                    if (user2.Id == response1.User.Id)
                    {
                        Users.Remove(user2);
                        break;
                    }
                }
            }
            StateHasChanged();

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
            StateHasChanged();
            //TODO not StateHasChanged working
        }

        private async void FilterUsersAsync()
        {
            _users.Clear();
            UserRequest.GetIndex request1 = new()
            {
                SearchTerm = filter.SearchTerm
            };
            var response = await UserService.GetIndexAsync(request1);
            Users = response.Users;
            StateHasChanged();
        }

        public void Dispose()
        {
            filter.OnProjectFilterChanged -= FilterUsersAsync;
            filter.OnProjectFilterChanged -= GetProjectWithUsersAndRemoveUsersOtOfChoicesWithAddUsers;
        }

    }
}