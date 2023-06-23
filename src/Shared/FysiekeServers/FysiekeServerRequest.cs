using Domain.Common;
using Shared.VirtualMachines;

namespace Shared.FysiekeServers
{
    public static class FysiekeServerRequest
    {
        public class GetIndex
        {

        }

        public class GetDetail
        {
            public int FysiekeServerId { get; set; }
        }

        public class Delete
        {
            public int FysiekeServerId { get; set; }
        }

        public class Create
        {
            public FysiekeServerDto.Mutate FysiekeServer { get; set; }
        }

        public class Edit
        {
            public int FysiekeServerId { get; set; }
            public FysiekeServerDto.Mutate FysiekeServer { get; set; }
        }

        public class Order
        {
            public DateTime StartDay { get; set; }
            public DateTime EndDate { get; set; }
            public Hardware HardwareNeeded { get; set; }

        }
        public class Approve
        {
            public VirtualMachineDto.Detail VirtualMachine { get; set; }  // virtual machine contains the server
        }
        public class Detail
        {
            public int ServerId { get; set; }
        }
        public class Date
        {
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
        }

    }
}
