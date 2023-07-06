using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Users;
using System.Threading.Tasks;

namespace Server.Controllers
{
    //[Authorize(Roles = "BeheerderBeheren")]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet, AllowAnonymous]
        public Task<UserResponse.GetIndex> GetIndexAsync([FromQuery] UserRequest.GetIndex request)
        {
            return userService.GetIndexAsync(request);
        }

        [HttpGet("{UserId}"), AllowAnonymous]
        public Task<UserResponse.Detail> GetDetailAsync([FromRoute] UserRequest.Detail request)
        {
            return userService.GetDetail(request);
        }

        [HttpPost]
        public Task<UserResponse.Create> CreateAsync([FromBody] UserRequest.Create request)
        {
            return userService.CreateAsync(request);
        }
    }
}