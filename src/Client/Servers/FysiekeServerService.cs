using Azure.Core;
using Client.Extentions;
using Client.Infrastructure;
using Domain.Server;
using Shared.FysiekeServers;
using Shared.VirtualMachines;
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;

namespace Client.Servers
{
    public class FysiekeServerService : IFysiekeServerService
    {
        /*private readonly HttpClient _httpClient;*/

        private readonly IHttpClientFactory _IHttpClientFactory;

        private const string endpoint = "api/fysiekeserver";

        public FysiekeServerService(/*HttpClient _httpClient,*/ IHttpClientFactory _IHttpClientFactory)
        {
            /*this._httpClient = _httpClient;*/
            this._IHttpClientFactory = _IHttpClientFactory;


        }

        public async Task<FysiekeServerResponse.GetIndex> GetIndexAsync(FysiekeServerRequest.GetIndex request)
        {
            //var queryParameters = request.GetQueryString();
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");

            var response = await HttpClient.GetFromJsonAsync<FysiekeServerResponse.GetIndex>($"{endpoint}");
            return response;


        }

        public Task DeleteAsync(FysiekeServerRequest.Delete request)
        {
            throw new NotImplementedException();
        }

        public Task<FysiekeServerResponse.Create> CreateAsync(FysiekeServerRequest.Create request)
        {
            throw new NotImplementedException();
        }

        public Task<FysiekeServerResponse.Edit> EditAsync(FysiekeServerRequest.Edit request)
        {
            throw new NotImplementedException();
        }

        public Task<FysiekeServerResponse.Available> GetAvailableServersByHardWareAsync(FysiekeServerRequest.Order request)
        {
            throw new NotImplementedException();
        }


        public async Task<FysiekeServerResponse.GetDetail> GetDetailAsync(FysiekeServerRequest.GetDetail request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");

            var queryParam = request.FysiekeServerId;
            var response = await HttpClient.GetFromJsonAsync<FysiekeServerResponse.GetDetail>($"{endpoint}/{queryParam}");
            return response;
        }


        public async Task<FysiekeServerResponse.ResourcesAvailable> GetAvailableHardWareOnDate(FysiekeServerRequest.Date request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");

            //request.FromDate.GetQueryString()+ "&" + request.ToDate.GetQueryString(); doesn't work get default value at the other side
            var queryParameters = request.GetQueryString();
            return await HttpClient.GetFromJsonAsync<FysiekeServerResponse.ResourcesAvailable>($"{endpoint}/Resource?{queryParameters}");

        }

        public async Task<FysiekeServerResponse.GraphValues> GetGraphValueForServer(FysiekeServerRequest.Date request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");

            var queryParameters = request.GetQueryString();
            return await HttpClient.GetFromJsonAsync<FysiekeServerResponse.GraphValues>($"{endpoint}/Graph?{queryParameters}");

        }

    }
}
