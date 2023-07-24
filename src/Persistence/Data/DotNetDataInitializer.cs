using System.Collections.Generic;
using Domain.Common;
using Domain.Projecten;
using Domain.Server;
using Domain.Statistics;
using Domain.Users;
using Domain.VirtualMachines;
using Domain.VirtualMachines.BackUp;
using Domain.VirtualMachines.Contract;
using Domain.VirtualMachines.VirtualMachine;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Persistence.Data
{
    public class DotNetDataInitializer
    {
        private readonly DotNetDbContext _dbContext;


        public DotNetDataInitializer(DotNetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                SeedVirtualMachines();
            }
        }

        private void SeedVirtualMachines()
        {
            var statisticA = new Statistic(System.DateTime.Now, System.DateTime.Now, new Hardware(5, 5, 5));
            _dbContext.Statistics.AddRange(statisticA);
            _dbContext.SaveChanges();
            User userA = new();
            userA.UserId = "auth0|6390964a894d42544f733938";
            _dbContext.Users.AddRange(userA);
            _dbContext.SaveChanges();
            var fysiekeServerA = new FysiekeServer("fysiekeServerA", new Hardware(5, 5, 5), "ServerAddressA");
            fysiekeServerA.HardWareAvailable = new Hardware(4, 4, 4);
            fysiekeServerA.VirtualMachines.Add(new VirtualMachine("first", OperatingSystemEnum.FEDORA_35, new Hardware(5, 5, 5), new Backup(BackUpType.DAILY, System.DateTime.Now)));
            _dbContext.FysiekeServers.AddRange(fysiekeServerA);
            _dbContext.SaveChanges();
            // var Projecten = new ProjectFaker().Generate(1);
            // var VirtualMachines = new VirtualMachineFaker().Generate(2);
            var virtualMachines1 = new List<VirtualMachine>();
            virtualMachines1.Add(new VirtualMachine("first", OperatingSystemEnum.FEDORA_35, new Hardware(5, 5, 5), new Backup(BackUpType.DAILY, System.DateTime.Now)));
            virtualMachines1.Add(new VirtualMachine("second", OperatingSystemEnum.FEDORA_35, new Hardware(5, 5, 5), new Backup(BackUpType.DAILY, System.DateTime.Now)));
            virtualMachines1.Add(new VirtualMachine("thirth", OperatingSystemEnum.FEDORA_35, new Hardware(5, 5, 5), new Backup(BackUpType.DAILY, System.DateTime.Now)));
            var project1 = new Project("gegherg");
            project1.VirtualMachines = virtualMachines1;
            project1.User = userA;
            _dbContext.Projecten.AddRange(project1);
            _dbContext.SaveChanges();
            var VMContractA = new VMContract("auth0|6390964a894d42544f733938", 2, System.DateTime.Now, System.DateTime.Now.AddDays(5));
            var VMContractB = new VMContract("auth0|6390964a894d42544f733938", 3, System.DateTime.Now, System.DateTime.Now.AddDays(5));
            var VMContractC = new VMContract("auth0|6390964a894d42544f733938", 4, System.DateTime.Now, System.DateTime.Now.AddDays(5));
            _dbContext.VMContracts.AddRange(VMContractA);
            _dbContext.VMContracts.AddRange(VMContractB);
            _dbContext.VMContracts.AddRange(VMContractC);
            //_dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT VMContracts ON;");
            //_dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Users ON;");
            //_dbContext.Entry(virtualMachines).State = EntityState.Detached;
            //_dbContext.SaveChanges();
            //_dbContext.VirtualMachines.AsNoTracking();
            //_dbContext.VirtualMachines.AddRange(virtualMachines1);
            //_dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT VMContracts OFF;");
            //_dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Users OFF;");
            _dbContext.SaveChanges();
        }
    }
}
