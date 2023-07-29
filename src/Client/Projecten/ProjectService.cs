using Client.Extentions;
using Shared.Projecten;
using System.Net;
using System.Net.Http.Json;

namespace Client.VirtualMachines
{
    public class ProjectService : IProjectenService
    {
        private readonly IHttpClientFactory _IHttpClientFactory;
        private string endpoint = "api/project";


        public ProjectService(/*HttpClient _httpClient,*/ IHttpClientFactory _IHttpClientFactory)
        {
            /*this._httpClient = _httpClient;*/
            this._IHttpClientFactory = _IHttpClientFactory;


        }

        public Task<ProjectenResponse.Create> AddVMAsync(ProjectenRequest.AddVM request)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectenResponse.Create> CreateAsync(ProjectenRequest.Create request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");


            var response = await HttpClient.PostAsJsonAsync(endpoint, request);
            return await response.Content.ReadFromJsonAsync<ProjectenResponse.Create>();


        }

        public Task DeleteAsync(ProjectenRequest.Delete request)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectenResponse.Edit> EditAsync(ProjectenRequest.Edit request)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectenResponse.GetIndex> GetAllIndexAsync(ProjectenRequest.GetIndex request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");

            var queryParameters = request.GetQueryString();
            var response = await HttpClient.GetFromJsonAsync<ProjectenResponse.GetIndex>($"{endpoint}?{queryParameters}");
            return response;
        }

        public async Task<ProjectenResponse.GetDetail> GetDetailAsync(ProjectenRequest.GetDetail request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");
            var queryParameters = request.GetQueryString();
            var response = await HttpClient.GetFromJsonAsync<ProjectenResponse.GetDetail>($"{endpoint}/Detail?{queryParameters}");
            return response;
        }

        public async Task<ProjectenResponse.GetIndex> GetIndexAsync(ProjectenRequest.GetIndexForUser request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");

            var queryParameters = request.GetQueryString();
            var response = await HttpClient.GetFromJsonAsync<ProjectenResponse.GetIndex>($"{endpoint}/User?{queryParameters}");
            return response;
        }

        public async Task RemoveUserFromProject(ProjectenRequest.RemoveUserFromProject request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");

            var queryParameters = request.GetQueryString();
            await HttpClient.DeleteAsync($"{endpoint}/Remove?{queryParameters}");

        }
        public async Task AddUserFromProject(ProjectenRequest.AddUserFromProject request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");

            await HttpClient.PutAsJsonAsync($"{endpoint}/Add", request);


        }
    }
}
