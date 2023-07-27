using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Projecten;
using System.Threading.Tasks;

namespace Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectenService projectenService;

        public ProjectController(IProjectenService projectenService)
        {
            this.projectenService = projectenService;
        }

        //[Authorize(Roles = "Klant")]
        [HttpGet("User"), AllowAnonymous]
        public Task<ProjectenResponse.GetIndex> GetIndexAsync([FromQuery] ProjectenRequest.GetIndexForUser request)
        {
            return projectenService.GetIndexAsync(request);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet, AllowAnonymous]
        public Task<ProjectenResponse.GetIndex> GetAllIndexAsync([FromQuery] ProjectenRequest.GetIndex request)
        {
            return projectenService.GetAllIndexAsync(request);
        }

        //[Authorize(Roles = "Klant")]
        [HttpGet("Detail"), AllowAnonymous]
        public Task<ProjectenResponse.GetDetail> GetDetailAsync([FromQuery] ProjectenRequest.GetDetail request)
        {
            return projectenService.GetDetailAsync(request);
        }

        [Authorize(Roles = "BeheerderBeheren")]
        [HttpDelete("{ProjectenId}")]
        public Task DeleteAsync([FromRoute] ProjectenRequest.Delete request)
        {
            return projectenService.DeleteAsync(request);
        }

        //[Authorize(Roles = "BeheerderBeheren")]
        [HttpPost, AllowAnonymous]
        public Task<ProjectenResponse.Create> CreateAsync([FromBody] ProjectenRequest.Create request)
        {
            return projectenService.CreateAsync(request);
        }

        [Authorize(Roles = "BeheerderBeheren")]
        [HttpPut]
        public Task<ProjectenResponse.Edit> EditAsync([FromBody] ProjectenRequest.Edit request)
        {
            return projectenService.EditAsync(request);
        }

        [HttpDelete("Remove"), AllowAnonymous]
        public Task RemoveUserFromProject([FromQuery] ProjectenRequest.RemoveUserFromProject request)
        {
            return projectenService.RemoveUserFromProject(request);
        }

        [HttpDelete("Add"), AllowAnonymous]
        public Task AddUserFromProject([FromQuery] ProjectenRequest.AddUserFromProject request)
        {
            return projectenService.AddUserFromProject(request);
        }
}
}