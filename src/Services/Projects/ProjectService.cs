using Shared.Projecten;
using System.Linq;
using Persistence.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Projecten;
using System;
using Domain.Common;
using Domain.Users;
using Shared.Users;
using Domain.VirtualMachines.VirtualMachine;

namespace Services.Projecten
{
    public class ProjectService : IProjectenService
    {
        public ProjectService(DotNetDbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _projecten = dbContext.Projecten;
            _userService = userService;
        }

        private readonly DotNetDbContext _dbContext;
        private readonly DbSet<Project> _projecten;

        private IUserService _userService;

        private IQueryable<Project> GetProjectById(int id) => _projecten
                .AsNoTracking()
                .Where(p => p.Id == id);

        private IQueryable<Project> GetProjectByUserId(String id) => _projecten
                .AsNoTracking()
                .Where(p => p.User.UserId.Equals(id));

        public async Task<ProjectenResponse.Create> CreateAsync(ProjectenRequest.Create request)
        {
            ProjectenResponse.Create response = new();
            UserRequest.DetailInternalDatabase request1 = new();
            request1.UserId = request.Project.UserId;
            var response1 = await _userService.GetDetailFromIntenalDatabase(request1);

            var project = _projecten.Add(new Project(
                request.Project.Name,
                new User() { Id = response1.User.Id, UserId = response1.User.UserId }
            ));
            await _dbContext.SaveChangesAsync();
            response.ProjectenId = project.Entity.Id;
            return response;
        }

        public async Task DeleteAsync(ProjectenRequest.Delete request)
        {
            _projecten.RemoveIf(p => p.Id == request.ProjectenId);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<ProjectenResponse.Create> AddVMAsync(ProjectenRequest.AddVM request)
        {
            ProjectenResponse.Create response = new();

            var project = await GetProjectById(request.ProjectenId).SingleOrDefaultAsync();

            project.VirtualMachines.Add(request.VirtualMachine);

            _dbContext.Entry(project).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            response.ProjectenId = project.Id;
            return response;
        }

        public async Task<ProjectenResponse.Edit> EditAsync(ProjectenRequest.Edit request)
        {
            ProjectenResponse.Edit response = new();
            var project = await GetProjectById(request.ProjectenId).SingleOrDefaultAsync();

            if (project is not null)
            {
                var model = request.Projecten;

                // You could use a Project.Edit method here.
                project.Name = model.Name;
                project.User = model.user;
                project.VirtualMachines = model.VirtualMachines;


                _dbContext.Entry(project).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                response.ProjectenId = project.Id;
            }

            return response;
        }


        public async Task<ProjectenResponse.GetDetail> GetDetailAsync(ProjectenRequest.GetDetail request)
        {
            ProjectenResponse.GetDetail response = new();
            var query = _projecten.AsQueryable().AsNoTracking();

            query = query.Where(x => x.Id == request.ProjectenId);

            /*if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                query = query.Where(x => x.Name.Contains(request.SearchTerm));*/

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                query = query.Where(e => e.VirtualMachines.Any(x => x.Name == request.SearchTerm));


            if (request.Mode is not null)
                query = query.Where(e => e.VirtualMachines.Any(x => x.Mode == request.Mode));


            response.Project = await query.Select(x => new ProjectenDto.Detail
            {
                Id = x.Id,
                Name = x.Name,
                user = x.User,
                VirtualMachines = x.VirtualMachines,
                Users = x.Users

            })
                .SingleOrDefaultAsync();
            return response;
        }

        public async Task<ProjectenResponse.GetIndex> GetAllIndexAsync(ProjectenRequest.GetIndex request)
        {
            ProjectenResponse.GetIndex response = new();
            var query = _projecten.AsQueryable().AsNoTracking();

            /*if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                query = query.Where(x => x.Name.Contains(request.SearchTerm));

            response.Total = query.Count();*/

            query.OrderBy(x => x.Name);
            response.Projecten = await query.Select(x => new ProjectenDto.Index
            {
                Id = x.Id,
                Name = x.Name,
                user = x.User,
            }).ToListAsync();
            return response;
        }

        public async Task<ProjectenResponse.GetIndex> GetIndexAsync(ProjectenRequest.GetIndexForUser request)
        {
            ProjectenResponse.GetIndex response = new();
            response.Projecten = await GetProjectByUserId(request.UserId)
                .Select(x => new ProjectenDto.Index
                {
                    Id = x.Id,
                    Name = x.Name,
                    user = x.User,

                })
                .ToListAsync();
            response.Total = response.Projecten.Count();
            return response;
        }
    }
}
