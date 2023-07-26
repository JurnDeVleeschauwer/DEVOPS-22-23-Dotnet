using System.Threading.Tasks;

namespace Shared.Users
{
    public interface IUserService
    {
        Task<UserResponse.GetIndex> GetIndexAsync(UserRequest.GetIndex request);
        Task<UserResponse.Create> CreateAsync(UserRequest.Create request);
        Task<UserResponse.Detail> GetDetail(UserRequest.Detail request);
        Task<UserResponse.AllAdminsIndex> GetAllAdminsIndex(UserRequest.AllAdminUsers request);
        Task<UserResponse.Edit> EditAsync(UserRequest.Edit request);
        Task<UserResponse.DetailInternalDatabase> GetDetailFromIntenalDatabase(UserRequest.DetailInternalDatabase request);


    }
}

