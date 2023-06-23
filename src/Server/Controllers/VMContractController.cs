using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.VMContracts;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Authorize(Roles = "BeheerderBeheren")]
    [ApiController]
    [Route("api/[controller]")]
    public class VMContractController : ControllerBase
    {
        private readonly IVMContractService VMContractService;

        public VMContractController(IVMContractService VMContractService)
        {
            this.VMContractService = VMContractService;
        }


        [HttpGet]
        public Task<VMContractResponse.GetIndex> GetIndexAsync([FromQuery] VMContractRequest.GetIndex request)
        {
            return VMContractService.GetIndexAsync(request);
        }

        [HttpGet("{VMContractId}")]
        public Task<VMContractResponse.GetDetail> GetDetailAsync([FromRoute] VMContractRequest.GetDetail request)
        {
            return VMContractService.GetDetailAsync(request);
        }

        [HttpDelete("{VMContractId}")]
        public Task DeleteAsync([FromRoute] VMContractRequest.Delete request)
        {
            return VMContractService.DeleteAsync(request);
        }

        [HttpPost]
        public Task<VMContractResponse.Create> CreateAsync([FromBody] VMContractRequest.Create request)
        {
            return VMContractService.CreateAsync(request);
        }

        [HttpPut]
        public Task<VMContractResponse.Edit> EditAsync([FromBody] VMContractRequest.Edit request)
        {
            return VMContractService.EditAsync(request);
        }
    }
}