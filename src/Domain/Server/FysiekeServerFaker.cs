using Bogus;
using Domain.Common;
using Domain.VirtualMachines.VirtualMachine;
using System;
using System.Linq;

namespace Domain.Server
{
    public class FysiekeServerFaker : Faker<FysiekeServer>
    {
        public FysiekeServerFaker()
        {
            int id = 1;

            Hardware hw = null;


            CustomInstantiator(e => {
                hw = GenerateRandomHardware();
                return new FysiekeServer("Server " + id, hw, e.Internet.DomainName() + "." + "hogent.be");
                });
       
            RuleFor(e => e.Id, _ => id++);
            RuleFor(e => e.VirtualMachines, _ => VirtualMachineFaker.Instance.Generate(12));
            RuleFor(e => e.HardWareAvailable, _ => new Hardware( hw.Memory - new Random().Next(1, hw.Memory), hw.Storage -  new Random().Next(1, hw.Storage), hw.Amount_vCPU - new Random().Next(1, hw.Amount_vCPU)));
            
        }


        public static Hardware GenerateRandomHardware()
        {
            int[] _memoryOptions = { 312_000, 388_000, 420_000, 512_000};
            int[] _storageOptions = { 10_000_000, 20_000_000, 30_000_000 };
            int[] _cpus = { 300,400 };


            return new Hardware(_memoryOptions[new Random().Next(0, _memoryOptions.Count())], _storageOptions[new Random().Next(0, _storageOptions.Count())], _cpus[new Random().Next(0, _cpus.Count())]);
        }
    }
}
