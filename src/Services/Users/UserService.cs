using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Shared.Users;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Users
{
    public class UserService : IUserService
    {
        private readonly ManagementApiClient _managementApiClient;

        public UserService(ManagementApiClient managementApiClient)
        {
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

        public Task<UserResponse.Detail> GetDetail(UserRequest.Detail request)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse.AllAdminsIndex> GetAllAdminsIndex(UserRequest.AllAdminUsers request)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse.Edit> EditAsync(UserRequest.Edit request)
        {
            throw new NotImplementedException();
        }
    }
}
