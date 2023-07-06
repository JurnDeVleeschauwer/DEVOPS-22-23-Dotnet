using Shared.VirtualMachines;
using System.Linq;
using Persistence.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.VirtualMachines.VirtualMachine;
using System;
using Domain.Common;
using Domain.VirtualMachines.BackUp;
using Shared.FysiekeServers;
using Shared.Projecten;
using Services.Projecten;

namespace Services.VirtualMachines
{
    public class VirtualMachineService : IVirtualMachineService
    {

        public VirtualMachineService(DotNetDbContext dbContext, IProjectenService projectService)
        {
            _projectService = projectService;
            _dbContext = dbContext;
            _virtualMachines = dbContext.VirtualMachines;
        }

        private readonly DotNetDbContext _dbContext;
        private readonly DbSet<VirtualMachine> _virtualMachines;

        private IProjectenService _projectService;


        private IQueryable<VirtualMachine> GetVirtualMachineById(int id) => _virtualMachines
                .AsNoTracking()
                .Where(p => p.Id == id);
        private IQueryable<VirtualMachine> GetVirtualMachineByDate(FysiekeServerRequest.Date date) => _virtualMachines.AsNoTracking().Where(p => p.Contract.StartDate <= date.FromDate && p.Contract.EndDate >= date.ToDate);


        public async Task<VirtualMachineResponse.Create> CreateAsync(VirtualMachineRequest.Create request)
        {
            VirtualMachineResponse.Create response = new();
            var virtualMachine = _virtualMachines.Add(new VirtualMachine(
                request.VirtualMachine.Name,
                request.VirtualMachine.OperatingSystem,
                new Hardware(request.VirtualMachine.Hardware.Memory, request.VirtualMachine.Hardware.Storage, request.VirtualMachine.Hardware.Amount_vCPU),
                new Backup(request.VirtualMachine.Backup.Type, request.VirtualMachine.Backup.LastBackup)
            ));

            await _dbContext.SaveChangesAsync();

            response.VirtualMachineId = virtualMachine.Entity.Id;

            ProjectenRequest.AddVM request2 = new();
            request2.VirtualMachine = (await GetVirtualMachineById(response.VirtualMachineId).ToListAsync<VirtualMachine>()).First();
            System.Console.WriteLine(request2.VirtualMachine.ToString());
            request2.ProjectenId = request.VirtualMachine.ProjectId;

            await _projectService.AddVMAsync(request2);


            return response;
        }

        public async Task DeleteAsync(VirtualMachineRequest.Delete request)
        {
            _virtualMachines.RemoveIf(p => p.Id == request.VirtualMachineId);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<VirtualMachineResponse.Edit> EditAsync(VirtualMachineRequest.Edit request)
        {
            VirtualMachineResponse.Edit response = new();
            var virtualMachine = await GetVirtualMachineById(request.VirtualMachineId).SingleOrDefaultAsync();

            if (virtualMachine is not null)
            {
                var model = request.VirtualMachine;

                // You could use a VirtualMachine.Edit method here.
                virtualMachine.Name = model.Name;
                virtualMachine.BackUp = model.Backup;


                _dbContext.Entry(virtualMachine).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                response.VirtualMachineId = virtualMachine.Id;
            }

            return response;
        }


        public async Task<VirtualMachineResponse.GetDetail> GetDetailAsync(VirtualMachineRequest.GetDetail request)
        {
            VirtualMachineResponse.GetDetail response = new();
            response.VirtualMachine = await GetVirtualMachineById(request.VirtualMachineId)
                .Select(x => new VirtualMachineDto.Detail
                {
                    Id = x.Id,
                    Name = x.Name,
                    OperatingSystem = x.OperatingSystem,
                    Mode = x.Mode,
                    Hardware = x.Hardware,
                    VMConnection = x.Connection,
                    BackUp = x.BackUp,
                })
                .SingleOrDefaultAsync();
            return response;
        }

        public async Task<VirtualMachineResponse.GetIndex> GetIndexAsync(VirtualMachineRequest.GetIndex request)
        {
            VirtualMachineResponse.GetIndex response = new();
            var query = _virtualMachines.AsQueryable().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                query = query.Where(x => x.Name.Contains(request.SearchTerm));


            response.TotalAmount = query.Count();

            query.OrderBy(x => x.Name);
            response.VirtualMachines = await query.Select(x => new VirtualMachineDto.Index
            {
                Id = x.Id,
                Name = x.Name,
                Mode = x.Mode,
            }).ToListAsync();
            return response;
        }

        public async Task<VirtualMachineResponse.Rapport> RapporteringAsync(VirtualMachineRequest.GetDetail request)
        {

            VirtualMachineResponse.Rapport response = new();
            response.VirtualMachine = await GetVirtualMachineById(request.VirtualMachineId)
                .Select(x => new VirtualMachineDto.Rapportage
                {
                    Id = x.Id,
                    Name = x.Name,
                    Statistics = x.Statistics
                })
                .SingleOrDefaultAsync();
            return response;
        }

        Task IVirtualMachineService.DeleteAsync(VirtualMachineRequest.Delete request)
        {
            throw new NotImplementedException();
        }

        public async Task<VirtualMachineResponse.GetIndexWithHardware> GetVirtualmachine(FysiekeServerRequest.Date date)
        {
            VirtualMachineResponse.GetIndexWithHardware response = new();
            response.VirtualMachines = await GetVirtualMachineByDate(date)
                .Select(x => new VirtualMachineDto.IndexHardWare
                {
                    Id = x.Id,
                    Name = x.Name,
                    Hardware = x.Hardware
                })
                .ToListAsync();
            return response;
        }
    }
}