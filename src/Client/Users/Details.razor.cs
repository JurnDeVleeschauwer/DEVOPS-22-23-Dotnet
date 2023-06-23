﻿using Microsoft.AspNetCore.Components;
using Shared.Users;

namespace Client.Users;

public partial class Details
{
    private UserDto.Mutate model = new();
    public bool Loading = false;
    public bool Edit = false;
    public bool Intern = false;
    private UserDto.Detail User;
    [Parameter] public int Id { get; set; }
    [Inject] public IUserService UserService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await GetUserAsync();
        ObjectToMutate();
    }

    private async Task GetUserAsync()
    {
        Loading = true;
        var request = new UserRequest.Detail();
        request.UserId = Id;
        var response = await UserService.GetDetail(request);
        User = response.User;
        if (User.Course is not null)
        {
            Intern = true;
        }
        Console.WriteLine(User.Projects.Count() == 0);
        Loading = false;
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
        model.PhoneNumber = User.PhoneNumber;
        if (User.Course is not null)
        {
            model.Course = User.Course;
        }
        else
        {
            model.Bedrijf = User.Bedrijf;
        }

    }
}
