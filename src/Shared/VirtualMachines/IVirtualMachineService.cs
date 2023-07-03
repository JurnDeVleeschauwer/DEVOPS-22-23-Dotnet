using System.Threading.Tasks;
using Shared.FysiekeServers;

namespace Shared.VirtualMachines
{
    public interface IVirtualMachineService
    {
        Task<VirtualMachineResponse.GetIndex> GetIndexAsync(VirtualMachineRequest.GetIndex request);
        Task<VirtualMachineResponse.GetDetail> GetDetailAsync(VirtualMachineRequest.GetDetail request);
        Task DeleteAsync(VirtualMachineRequest.Delete request);
        Task<VirtualMachineResponse.Create> CreateAsync(VirtualMachineRequest.Create request);
        Task<VirtualMachineResponse.Edit> EditAsync(VirtualMachineRequest.Edit request);
        Task<VirtualMachineResponse.Rapport> RapporteringAsync(VirtualMachineRequest.GetDetail request);
        Task<VirtualMachineResponse.GetIndexWithHardware> GetVirtualmachine(FysiekeServerRequest.Date date);

    }
}
