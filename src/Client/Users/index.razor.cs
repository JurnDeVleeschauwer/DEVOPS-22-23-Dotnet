using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Shared.Users;

namespace Client.Users;

public partial class Index
{
    [Inject] public IUserService UserService { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    private List<UserDto.Index> Users { get; set; }

    protected override async Task OnInitializedAsync()
    {
        UserRequest.GetIndex request = new();

        var response = await UserService.GetIndexAsync(request);
        Users = response.Users;
    }
    private void NavToDetail(int id)
    {
        NavigationManager.NavigateTo($"User/{id}");
    }
    public void Toast()
    {

    }
}
