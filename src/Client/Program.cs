
using Append.Blazor.Sidepanel;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shared.VirtualMachines;
using Shared.Users;
using Client.Infrastructure;
using Shared.Projecten;
using Shared.FysiekeServers;
using Shared.VMContracts;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Client.VirtualMachines;
using Client.Servers;
using Client.Users;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Auth0", options.ProviderOptions);
                options.ProviderOptions.ResponseType = "code";
                options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]);
            }).AddAccountClaimsPrincipalFactory<ArrayClaimsPrincipalFactory<RemoteUserAccount>>();

            builder.Services.AddScoped<IVirtualMachineService, VirtualMachineService>();
            builder.Services.AddScoped<IUserService, UsersService>();
            builder.Services.AddScoped<IProjectenService, ProjectService>();
            builder.Services.AddScoped<IFysiekeServerService, FysiekeServerService>();
            builder.Services.AddScoped<IVMContractService, VMContractService>();
            builder.Services.AddSidepanel();
            builder.Services.AddHttpClient<StorageService>();
            //await builder.Build().RunAsync();

            //MOCKDATA
            //builder.Services.AddSingleton<IVirtualMachineService, FakeVirtualMachineService>();
            //builder.Services.AddSingleton<IUserService, FakeUserService>();
            //builder.Services.AddSingleton<IProjectenService, FakeProjectService>();
            //builder.Services.AddSingleton<IFysiekeServerService, FakeServerService>();
            //builder.Services.AddSingleton<IVMContractService, FakeVMContractService>();

            //AUTHENTICATION
            builder.Services.AddAuthorizationCore(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
                options.AddPolicy("BeheerOnly", policy => policy.RequireClaim(ClaimTypes.Role, "BeheerderZien"));
                options.AddPolicy("LoggedIn", policy => policy.RequireAuthenticatedUser());
                options.AddPolicy("Guest", policy => policy.RequireClaim(ClaimTypes.Name, "Guest"));

            });
            //builder.Services.AddSingleton<AuthenticationStateProvider, FakeAuthenticationProvider>();

            //Disble both to do login via Auth0
            //builder.Services.AddScoped<Shared.FakeAuthenticationProvider>();
            //builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<Shared.FakeAuthenticationProvider>());

            builder.Services.AddHttpClient("AuthenticatedServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            // .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            //builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
            //       .CreateClient("AuthenticatedServerAPI"));

            //builder.Services.AddHttpClient<PublicClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            /*builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Auth0", options.ProviderOptions);
                options.ProviderOptions.ResponseType = "code";
            });*/

            await builder.Build().RunAsync();

        }
    }
}
