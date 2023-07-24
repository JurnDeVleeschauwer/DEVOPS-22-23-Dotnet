using Domain.Users;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Users;

namespace Client.Users;

public partial class Details
{
    private UserDto.Mutate model = new();
    public bool Loading = false;
    public bool Edit = false;
    public bool Intern = false;
    private UserDto.Detail User;
    [Parameter] public String UserId { get; set; }
    [Inject] public IUserService UserService { get; set; }
    [Inject] public AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }


    protected override async Task OnInitializedAsync()
    {
        if(UserId == "-1")
        {
            var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
            var user = authstate.User;
            var identity = user.Identities.First();
            if (identity != null)
            {
                UserId =  identity.Claims.Where(claim => "sub".Equals(claim.Type)).First().Value;
            }

        }
        
        await GetUserAsync();
        ObjectToMutate();

    }

    private async Task GetUserAsync()
    {
        Loading = true;
        var request = new UserRequest.Detail();
        request.UserId = UserId;
        var response = await UserService.GetDetail(request);
        if (response.User != null)
        {
            User = response.User;
            Loading = false;
        }

        /*if (User.Course is not null)
        {
            Intern = true;
        }*/
        //Console.WriteLine(User.Projects.Count() == 0);

    }
    public void Toggle()
    {
        Edit = !Edit;
    }

    /*    private async void CheckboxChanged()
        {
            if (!Edit)
            {

                GetUserAsync();
                Console.WriteLine(Loading);
                Loading = false;
            }

        }*/

    private async void EditUser()
    {
        //var claims = context.User.Claims;
        UserRequest.Edit request = new()
        {
            UserId = User.Id,
            User = model
        };
        await UserService.EditAsync(request);

        var response = await UserService.GetDetail(new UserRequest.Detail() { UserId = User.Id });
        User = response.User;
    }

    public void ObjectToMutate()
    {
        model.FirstName = User.FirstName;
        model.Name = User.Name;
        model.Email = User.Email;
        model.user_metadata = new();
        //model.PhoneNumber = User.PhoneNumber;
        if (User.user_metadata.Course is not null)
        {
            model.user_metadata.Course = (Course)User.user_metadata.Course;
        }
        else
        {
            model.user_metadata.Bedrijf = User.user_metadata.Bedrijf;
        }

    }
}
