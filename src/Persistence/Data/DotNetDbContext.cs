using Domain.VirtualMachines.VirtualMachine;
using Domain.Server;
using Domain.VirtualMachines.Contract;
using Microsoft.EntityFrameworkCore;
using Domain;
using Persistence.Data.Configuration;
using Domain.Common;
using Domain.Statistics;
using Domain.VirtualMachines.BackUp;
using Domain.Projecten;
using Domain.Users;

namespace Persistence.Data
{
    public class DotNetDbContext : DbContext
    {
        public DotNetDbContext(DbContextOptions<DotNetDbContext> options)
            : base(options)
        {
        }

        public DbSet<VirtualMachine> VirtualMachines { get; set; }

        public DbSet<FysiekeServer> FysiekeServers { get; set; }

        public DbSet<VMContract> VMContracts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projecten { get; set; }

        public DbSet<Statistic> Statistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            /*modelBuilder.Entity<VMConnection>();
            modelBuilder.Entity<Statistic>();
            modelBuilder.Entity<Backup>();
            modelBuilder.Entity<ContactDetails>();
            modelBuilder.Entity<Hardware>();*/



            modelBuilder.ApplyConfiguration(new ProjectEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VMContractEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FysiekeServerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VirtualMachineEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StatisticEntityTypeConfiguration());
        }
    }
}
