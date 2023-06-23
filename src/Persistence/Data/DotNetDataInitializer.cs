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
            var userA = new User("lastname A", "firstname A", "024561278", "firstnameA.lastnameA@mail.local", "passwordA1!", Role.Admin, "bedrijfsnaam A", Type.Intern, Course.AGRO_EN_BIOTECHNOLOGIE);
            _dbContext.Users.AddRange(userA);
            _dbContext.SaveChanges();
            var fysiekeServerA = new FysiekeServer("fysiekeServerA", new Hardware(5, 5, 5), "ServerAddressA");
            fysiekeServerA.HardWareAvailable = new Hardware(4, 4, 4);
            _dbContext.FysiekeServers.AddRange(fysiekeServerA);
            _dbContext.SaveChanges();
            // var Projecten = new ProjectFaker().Generate(1);
            // var VirtualMachines = new VirtualMachineFaker().Generate(2);
            var virtualMachines1 = new List<VirtualMachine>();
            virtualMachines1.Add(new VirtualMachine("1", OperatingSystemEnum.FEDORA_35, new Hardware(5, 5, 5), new Backup(BackUpType.DAILY, System.DateTime.Now)));
            virtualMachines1.Add(new VirtualMachine("1", OperatingSystemEnum.FEDORA_35, new Hardware(5, 5, 5), new Backup(BackUpType.DAILY, System.DateTime.Now)));
            virtualMachines1.Add(new VirtualMachine("1", OperatingSystemEnum.FEDORA_35, new Hardware(5, 5, 5), new Backup(BackUpType.DAILY, System.DateTime.Now)));
            var project1 = new Project("gegherg");
            project1.VirtualMachines = virtualMachines1;
            userA.Id = 1;
            project1.User = userA;
            _dbContext.Projecten.AddRange(project1);
            _dbContext.SaveChanges();
            var VMContractA = new VMContract(1, 1, System.DateTime.Now, System.DateTime.Now);
            _dbContext.VMContracts.AddRange(VMContractA);
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
