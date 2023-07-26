using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Shared.Projecten;
using Shared.Users;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Users
{
    public class UserService : IUserService
    {
        private readonly ManagementApiClient _managementApiClient;
        private readonly DotNetDbContext _dbContext;
        private readonly DbSet<Domain.Users.User> _users;
        public UserService(DotNetDbContext dbContext, ManagementApiClient managementApiClient)
        {
            _managementApiClient = managementApiClient;
            _dbContext = dbContext;
            _users = dbContext.Users;
        }

        private IQueryable<Domain.Users.User> GetUserById(String UserId) => _users
        .AsNoTracking()
        .Where(p => p.UserId == UserId);


        public async Task<UserResponse.GetIndex> GetIndexAsync(UserRequest.GetIndex request)
        {
            UserResponse.GetIndex response = new();
            var users = await _managementApiClient.Users.GetAllAsync(new GetUsersRequest(), new PaginationInfo());
            response.Users = users.Select(x => new UserDto.Index
            {
                Email = x.Email,
                //PhoneNumber = x.PhoneNumber,
                FirstName = x.FirstName,
                Name = x.LastName,
                //HogentEmail = x.HogentEmail
                Id = x.UserId
            }).ToList();

            return response;
        }

        public async Task<UserResponse.Create> CreateAsync(UserRequest.Create request)
        {
            UserResponse.Create response = new();

            var auth0Request = new UserCreateRequest
            {
                Email = request.User.Email,
                //PhoneNumber = request.User.PhoneNumber,
                FirstName = request.User.FirstName,
                LastName = request.User.Name,
                Password = request.User.Password,
                //UserMetadata.HogentEmail = request.User.HogentEmail,
                //HogentEmail = request.User.HogentEmail,
                UserMetadata = request.User.user_metadata,
                Connection = "Username-Password-Authentication" // Name of the Database connection

            };

            var createdUser = await _managementApiClient.Users.CreateAsync(auth0Request);

            // Caching might be nice here
            var allRoles = await _managementApiClient.Roles.GetAllAsync(new GetRolesRequest());
            var adminRole = allRoles.First(x => x.Name == "Admin");

            var assignRoleRequest = new AssignRolesRequest
            {
                Roles = new string[] { adminRole.Id }
            };
            await _managementApiClient.Users.AssignRolesAsync(createdUser?.UserId, assignRoleRequest);

            response.Auth0UserId = createdUser.UserId;
            _users.Add(new Domain.Users.User() { UserId = response.Auth0UserId });
            await _dbContext.SaveChangesAsync();

            return response;

        }

        public async Task<UserResponse.Detail> GetDetail(UserRequest.Detail request)
        {

            UserResponse.Detail response = new();
            response.User = new();
            response.User.user_metadata = new();
            var user = await _managementApiClient.Users.GetAsync(request.UserId.ToString());


            if (user is not null)
            {
                response.User.user_metadata.Intern = user.UserMetadata.Intern;
                if (!response.User.user_metadata.Intern)
                {
                    response.User.user_metadata.Bedrijf = user.UserMetadata.Bedrijf;
                }
                else
                {
                    response.User.user_metadata.Course = user.UserMetadata.Course;
                }
                response.User.Email = user.Email;
                response.User.FirstName = user.FirstName;
                response.User.Name = user.LastName;
                //response.User.PhoneNumber = user.PhoneNumber;
                //response.User.Role = user.Role;

                return response;

            }
            return response;
        }

        public Task<UserResponse.AllAdminsIndex> GetAllAdminsIndex(UserRequest.AllAdminUsers request)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse.Edit> EditAsync(UserRequest.Edit request)
        {   //TODO
            /*UserUpdateRequest
            UserResponse.Edit response = new();
            response.User = new();
            response.User.user_metadata = new();
            var user = await _managementApiClient.Users.UpdateAsync(request.UserId, );

            return response;*/
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

        public async Task<UserResponse.DetailInternalDatabase> GetDetailFromIntenalDatabase(UserRequest.DetailInternalDatabase request)
        {

            UserResponse.DetailInternalDatabase response = new();
            response.User = await GetUserById(request.UserId).Select(x => new UserDto.DetailInternalDatabase
            {
                Id = x.Id,
                UserId = x.UserId
            }).SingleOrDefaultAsync();

            return response;
        }
    }
}
