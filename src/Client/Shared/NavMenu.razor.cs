using Append.Blazor.Sidepanel;
using Microsoft.AspNetCore.Components;
using Shared.Projecten;
using Client.VirtualMachines.Components;
using Microsoft.AspNetCore.Components.Web;
using JetBrains.Annotations;
using System;
using Microsoft.AspNetCore.Components.Routing;


namespace Client.Shared
{
    public partial class Index
    {

        [Inject] NavigationManager Router { get; set; }

        public void NavigateToKlantDetails()
        {
            var id = UserId.GetUserIdAsync();
            Router.NavigateTo($"klant/{id}");
        }

    }
}