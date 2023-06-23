using System.Threading.Tasks;

namespace Shared.FysiekeServers
{
    public interface IFysiekeServerService
    {
        Task<FysiekeServerResponse.GetIndex> GetIndexAsync(FysiekeServerRequest.GetIndex request);
        Task<FysiekeServerResponse.GetDetail> GetDetailAsync(FysiekeServerRequest.GetDetail request);
        Task DeleteAsync(FysiekeServerRequest.Delete request);
        Task<FysiekeServerResponse.Create> CreateAsync(FysiekeServerRequest.Create request);
        Task<FysiekeServerResponse.Edit> EditAsync(FysiekeServerRequest.Edit request);

        Task<FysiekeServerResponse.Available> GetAvailableServersByHardWareAsync(FysiekeServerRequest.Order request); // when customer asks VM for certain date, it will check here if any server available for that day or not. (Can stream the VMs and map it on vm contracts. Then some simple logic to check what resources available for certain day:   _fysiekeServer.ResourcesAvailableAt(localDateVariable)

        Task<FysiekeServerResponse.Launched> DeployVirtualMachine(FysiekeServerRequest.Approve request); //when admin confirms a virtual machine this request is fired so the vm can get a vmconnection, server gets it's available hardware lowered by the hardware demanded by the VM

        Task<FysiekeServerResponse.Details> GetDetailsAsync(FysiekeServerRequest.Detail request); // admin can request all running VMs on a particular server

        Task<FysiekeServerResponse.ResourcesAvailable> GetAvailableHardWareOnDate(FysiekeServerRequest.Date date);
        Task<FysiekeServerResponse.GraphValues> GetGraphValueForServer(FysiekeServerRequest.GetIndex request);

    }
}
