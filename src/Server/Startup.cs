using Persistence.Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services.Common;
using Services.VirtualMachines;
using Services;
using Shared.VirtualMachines;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Services.Users;
using Shared.Users;
using Shared.Projecten;
using Services.Projecten;
using Shared.FysiekeServers;
using Shared.VMContracts;
using Services.FysiekeServers;
using Services.VMContracts;
using Auth0Net.DependencyInjection.HttpClient;

namespace Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("DotNet"));
            services.AddDbContext<DotNetDbContext>(options =>
                options.UseSqlServer(builder.ConnectionString)
                    .EnableSensitiveDataLogging(Configuration.GetValue<bool>("Logging:EnableSqlParameterLogging")));

            services.AddControllersWithViews().AddFluentValidation(config =>
            {
                config.RegisterValidatorsFromAssemblyContaining<VirtualMachineDto.Mutate.Validator>();
                config.ImplicitlyValidateChildProperties = true;
            });
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = Configuration["Auth0:Authority"];
                options.Audience = Configuration["Auth0:ApiIdentifier"];
            });

            services.AddAuth0AuthenticationClient(config =>
            {
                config.Domain = Configuration["Auth0:Authority"];
                config.ClientId = Configuration["Auth0:ClientId"];
                config.ClientSecret = Configuration["Auth0:ClientSecret"];
            });

            services.AddAuth0ManagementClient().AddManagementAccessToken();

            services.AddRazorPages();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVirtualMachineService, VirtualMachineService>();
            services.AddScoped<IProjectenService, ProjectService>();
            services.AddScoped<IFysiekeServerService, FysiekeServerService>();
            services.AddScoped<IVMContractService, VMContractService>();
            services.AddScoped<IStorageService, BlobStorageService>();
            services.AddScoped<DotNetDataInitializer>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DotNetDbContext dbContext,
            DotNetDataInitializer dataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();

            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for virtualMachineion scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            dataInitializer.SeedData();

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
