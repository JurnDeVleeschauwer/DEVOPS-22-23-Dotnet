using Client.Extentions;
using Shared.Projecten;
using Shared.Users;
using System.Net.Http.Json;

namespace Client.Users
{
    public class UsersService : IUserService
    {

        private readonly IHttpClientFactory _IHttpClientFactory;
        private const string endpoint = "api/User";
        public UsersService(IHttpClientFactory _IHttpClientFactory)
        {
            this._IHttpClientFactory = _IHttpClientFactory;
        }


        public async Task<UserResponse.AllAdminsIndex> GetAllAdminsIndex(UserRequest.AllAdminUsers request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");

            var queryParam = request.GetQueryString();
            var response = await HttpClient.GetFromJsonAsync<UserResponse.AllAdminsIndex>($"{endpoint}?{queryParam}");
            return response;
        }

        public async Task<UserResponse.GetIndex> GetIndexAsync(UserRequest.GetIndex request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");

            var queryParam = request.GetQueryString();
            var response = await HttpClient.GetFromJsonAsync<UserResponse.GetIndex>($"{endpoint}?{queryParam}");
            return response;
        }

        public async Task<UserResponse.Create> CreateAsync(UserRequest.Create request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");

            var response = await HttpClient.PostAsJsonAsync(endpoint, request);
            Console.WriteLine(response);
            return await response.Content.ReadFromJsonAsync<UserResponse.Create>();
        }

        public async Task<UserResponse.Detail> GetDetail(UserRequest.Detail request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");

            var queryParam = request.UserId;
            var response = await HttpClient.GetFromJsonAsync<UserResponse.Detail>($"{endpoint}/{queryParam}");
            return response;
        }

        public async Task<UserResponse.Edit> EditAsync(UserRequest.Edit request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");

            var queryParam = request.GetQueryString();
            var response = await HttpClient.GetFromJsonAsync<UserResponse.Edit>($"{endpoint}?{queryParam}");
            return response;
        }
    }
}
