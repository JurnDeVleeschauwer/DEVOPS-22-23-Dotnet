using Client.Extentions;
using Shared.Projecten;
using Shared.VMContracts;
using System.Net;
using System.Net.Http.Json;

namespace Client.VirtualMachines
{
    public class VMContractService : IVMContractService

    {
        private readonly IHttpClientFactory _IHttpClientFactory;
        private string endpoint = "api/VMContract";


        public VMContractService(/*HttpClient _httpClient,*/ IHttpClientFactory _IHttpClientFactory)
        {
            /*this._httpClient = _httpClient;*/
            this._IHttpClientFactory = _IHttpClientFactory;


        }

        public Task<VMContractResponse.Create> CreateAsync(VMContractRequest.Create request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(VMContractRequest.Delete request)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectenResponse.Edit> EditAsync(ProjectenRequest.Edit request)
        {
            throw new NotImplementedException();
        }

        public Task<VMContractResponse.Edit> EditAsync(VMContractRequest.Edit request)
        {
            throw new NotImplementedException();
        }
        public Task<VMContractResponse.GetDetail> GetDetailAsync(VMContractRequest.GetDetail request)
        {
            throw new NotImplementedException();
        }

        public Task<VMContractResponse.GetIndex> GetIndexAsync(VMContractRequest.GetIndex request)
        {
            throw new NotImplementedException();
        }
    }
}
