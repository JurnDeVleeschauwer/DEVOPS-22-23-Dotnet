using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Shared.Projecten;
using Shared.Users;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Users
{
    public class UserService : IUserService
    {
        private readonly ManagementApiClient _managementApiClient;
        private IProjectenService _projectService;
        public UserService(ManagementApiClient managementApiClient, IProjectenService projectService)
        {
            _projectService = projectService;
            _managementApiClient = managementApiClient;
        }


        public async Task<UserResponse.GetIndex> GetIndexAsync(UserRequest.GetIndex request)
        {
            UserResponse.GetIndex response = new();
            var users = await _managementApiClient.Users.GetAllAsync(new GetUsersRequest(), new PaginationInfo());
            response.Users = users.Select(x => new UserDto.Index
            {
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                FirstName = x.FirstName,
                Name = x.LastName,
                //HogentEmail = x.HogentEmail
            }).ToList();

            return response;
        }

        public async Task<UserResponse.Create> CreateAsync(UserRequest.Create request)
        {
            UserResponse.Create response = new();

            var auth0Request = new UserCreateRequest
            {
                Email = request.User.Email,
                PhoneNumber = request.User.PhoneNumber,
                FirstName = request.User.FirstName,
                LastName = request.User.Name,
                Password = request.User.Password,
                //HogentEmail = request.User.HogentEmail,
                Connection = "Username-Password-Authentication" // Name of the Database connection
            };

            var createdUser = await _managementApiClient.Users.CreateAsync(auth0Request);

            // Caching might be nice here
            var allRoles = await _managementApiClient.Roles.GetAllAsync(new GetRolesRequest());
            var adminRole = allRoles.First(x => x.Name == "Administrator");

            var assignRoleRequest = new AssignRolesRequest
            {
                Roles = new string[] { adminRole.Id }
            };
            await _managementApiClient.Users.AssignRolesAsync(createdUser?.UserId, assignRoleRequest);

            response.Auth0UserId = createdUser.UserId;

            return response;

        }

        public async Task<UserResponse.Detail> GetDetail(UserRequest.Detail request)
        {

            UserResponse.Detail response = new();
            var user = await _managementApiClient.Users.GetAsync(request.UserId.ToString());


            if (user is not null)
            {
                //response.User.Bedrijf = user.Bedrijf;
                //response.User.Course = user.Course;
                response.User.Email = user.Email;
                response.User.FirstName = user.FirstName;
                response.User.Name = user.LastName;
                response.User.PhoneNumber = user.PhoneNumber;
                //response.User.Role = user.Role;

                ProjectenRequest.GetIndexForUser request2 = new();
                request2.UserId = request.UserId;

                var response2 = await _projectService.GetIndexAsync(request2);

                response.User.Projects = response2.Projecten;
                return response;

            }
            return response;
        }

        public Task<UserResponse.AllAdminsIndex> GetAllAdminsIndex(UserRequest.AllAdminUsers request)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse.Edit> EditAsync(UserRequest.Edit request)
        {
            throw new NotImplementedException();
        }

        /*public async Task<UserResponse.Edit> EditAsync(UserRequest.Edit request)
        {
            UserResponse.Edit response = new();
            var users = await _managementApiClient.Users.UpdateAsync(request.UserId.ToString(), request.User);
            response.Id = users.Select(x => new UserDto.Mutate
            {
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                FirstName = x.FirstName,
                Name = x.LastName,
                //HogentEmail = x.HogentEmail
            }).ToList();

            return response;
        }*/ //TODO make work later
    }
}
