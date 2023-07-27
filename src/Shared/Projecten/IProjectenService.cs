using Shared.Projecten;
using System.Threading.Tasks;

namespace Shared.Projecten
{
    public interface IProjectenService
    {
        Task<ProjectenResponse.GetIndex> GetIndexAsync(ProjectenRequest.GetIndexForUser request);
        Task<ProjectenResponse.GetDetail> GetDetailAsync(ProjectenRequest.GetDetail request);
        Task DeleteAsync(ProjectenRequest.Delete request);
        Task<ProjectenResponse.Create> CreateAsync(ProjectenRequest.Create request);
        Task<ProjectenResponse.Edit> EditAsync(ProjectenRequest.Edit request);
        Task<ProjectenResponse.GetIndex> GetAllIndexAsync(ProjectenRequest.GetIndex request);
        Task<ProjectenResponse.Create> AddVMAsync(ProjectenRequest.AddVM request);
        Task RemoveUserFromProject(ProjectenRequest.RemoveUserFromProject request);
        Task AddUserFromProject(ProjectenRequest.AddUserFromProject request);

    }
}
