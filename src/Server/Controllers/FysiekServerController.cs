using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.FysiekeServers;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Authorize(Roles = "BeheerderBeheren")]
    [ApiController]
    [Route("api/[controller]")]
    public class FysiekeServerController : ControllerBase
    {
        private readonly IFysiekeServerService fysiekeServerService;

        public FysiekeServerController(IFysiekeServerService fysiekeServerService)
        {
            this.fysiekeServerService = fysiekeServerService;
        }


        [HttpGet, AllowAnonymous]
        public Task<FysiekeServerResponse.GetIndex> GetIndexAsync([FromQuery] FysiekeServerRequest.GetIndex request)
        {
            return fysiekeServerService.GetIndexAsync(request);
        }

        [HttpGet("{FysiekeServerId}")]
        public Task<FysiekeServerResponse.GetDetail> GetDetailAsync([FromRoute] FysiekeServerRequest.GetDetail request)
        {
            return fysiekeServerService.GetDetailAsync(request);
        }

        [HttpDelete("{FysiekeServerId}")]
        public Task DeleteAsync([FromRoute] FysiekeServerRequest.Delete request)
        {
            return fysiekeServerService.DeleteAsync(request);
        }

        [HttpPost]
        public Task<FysiekeServerResponse.Create> CreateAsync([FromBody] FysiekeServerRequest.Create request)
        {
            return fysiekeServerService.CreateAsync(request);
        }

        [HttpPut]
        public Task<FysiekeServerResponse.Edit> EditAsync([FromBody] FysiekeServerRequest.Edit request)
        {
            return fysiekeServerService.EditAsync(request);
        }
    }
}