using Domain.Common;
using Domain.VirtualMachines.VirtualMachine;
using FluentValidation;
using Shared.VirtualMachines;

namespace Shared.FysiekeServers
{
    public static class FysiekeServerDto
    {
        public class Index
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public String ServerAddress { get; set; }
            public Hardware Hardware { get; set; }
            public Hardware HardWareAvailable { get; set; }

        }

        public class Detail : Index
        {
            //public List<VirtualMachineDto.Rapportage> VirtualMachines { get; set; }
            public List<VirtualMachine> VirtualMachines { get; set; }
        }

        public class Beschikbaarheid
        {
            public int Id { get; set; }
            public Hardware AvailableHardware { get; set; }
        }

        public class Mutate
        {
            public String Name { get; set; }
            public String ServerAddress { get; set; }
            public int Memory { get; set; }
            public int Storage { get; set; }
            public int Amount_vCPU { get; set; }
            public int MemoryAvailable { get; set; }
            public int StorageAvailable { get; set; }
            public int VCPUsAvailable { get; set; }
        }




    }
}
