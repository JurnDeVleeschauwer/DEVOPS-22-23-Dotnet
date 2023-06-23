using Shared.VirtualMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.VMContracts
{
    public interface IVMContractService
    {
        Task<VMContractResponse.GetIndex> GetIndexAsync(VMContractRequest.GetIndex request);
        Task<VMContractResponse.GetDetail> GetDetailAsync(VMContractRequest.GetDetail request); //returns all info about specific vm duration + customer
        Task <VMContractResponse.Delete> DeleteAsync(VMContractRequest.Delete request);
        Task<VMContractResponse.Create> CreateAsync(VMContractRequest.Create request);
        Task<VMContractResponse.Edit> EditAsync(VMContractRequest.Edit request);

        //Task<VMContractResponse.Index> GetFromDate(VMContractRequest.GetByDate request); // returns all contracts from a certain date until nullable enddate 

        
        /*
      Als er een VM gecreërt word, krijgt deze automatisch een contract mee. Maar nog geen connectie.
    Een VMContract is een entity klasse, dus eenmaal de VM die gecreërd word opgeslaan wordt in de database, houd de database context hier rekening mee, en zal hij dus ook een vmcontract toevoegen aan de database? Zoja, dan is deze methode niet nodig. Zoniet, dan is deze wel nodig

        Task<VMContractResponse.Create> CreateAsync(VMContractRequest.Create request);


        Als bij het opslaan van een VM in de databank gekeken wordt naar de vmcontract en deze ook update in zijn respectievelijke db dan is deze methode ook niet nodig.
        

        Task<VMContractResponse.Edit> EditAsync(VirtualMachineRequest.Edit request);

        */

    }
}
