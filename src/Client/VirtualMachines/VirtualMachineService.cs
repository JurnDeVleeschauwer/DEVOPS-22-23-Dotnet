using Client.Extentions;
using Shared.FysiekeServers;
using Shared.Projecten;
using Shared.VirtualMachines;
using System.Net.Http.Json;

namespace Client.VirtualMachines
{

    public class VirtualMachineService : IVirtualMachineService
    {

        /*private readonly HttpClient client;*/

        private readonly IHttpClientFactory _IHttpClientFactory;
        private const string endpoint = "api/virtualmachine";
        public VirtualMachineService(IHttpClientFactory _IHttpClientFactory)
        {
            this._IHttpClientFactory = _IHttpClientFactory;
        }

        public Task<VirtualMachineResponse.Create> CreateAsync(VirtualMachineRequest.Create request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(VirtualMachineRequest.Delete request)
        {
            throw new NotImplementedException();
        }

        public Task<VirtualMachineResponse.Edit> EditAsync(VirtualMachineRequest.Edit request)
        {
            throw new NotImplementedException();
        }

        public async Task<VirtualMachineResponse.GetDetail> GetDetailAsync(VirtualMachineRequest.GetDetail request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");


            var queryParameters = request.VirtualMachineId;
            var response = await HttpClient.GetFromJsonAsync<VirtualMachineResponse.GetDetail>($"{endpoint}/{queryParameters}");
            return response;
        }

        public async Task<ProjectenResponse.GetIndex> GetIndexAsync(ProjectenResponse.GetIndex request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");


            var queryParameters = request.GetQueryString();
            var response = await HttpClient.GetFromJsonAsync<ProjectenResponse.GetIndex>($"{endpoint}/{queryParameters}");
            return response;
        }
        public async Task<VirtualMachineResponse.Rapport> RapporteringAsync(VirtualMachineRequest.GetDetail request)
        {
            var HttpClient = _IHttpClientFactory.CreateClient("AuthenticatedServerAPI");


            var queryParameters = request.GetQueryString();
            var response = await HttpClient.GetFromJsonAsync<VirtualMachineResponse.Rapport>($"{endpoint}/{queryParameters}");
            return response;
        }

        public Task<VirtualMachineResponse.GetIndex> GetIndexAsync(VirtualMachineRequest.GetIndex request)
        {
            throw new NotImplementedException();
        }

        Task IVirtualMachineService.DeleteAsync(VirtualMachineRequest.Delete request)
        {
            throw new NotImplementedException();
        }

        public Task<VirtualMachineResponse.GetIndexWithHardware> GetVirtualmachine(FysiekeServerRequest.Date date)
        {
            throw new NotImplementedException();
        }
    }
}
