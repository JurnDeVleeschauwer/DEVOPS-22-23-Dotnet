using Shared.Projecten;
using System.Linq;
using Persistence.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Projecten;
using System;
using Domain.Common;


namespace Services.Projecten
{
    public class ProjectService : IProjectenService
    {
        public ProjectService(DotNetDbContext dbContext)
        {
            _dbContext = dbContext;
            _projecten = dbContext.Projecten;
        }

        private readonly DotNetDbContext _dbContext;
        private readonly DbSet<Project> _projecten;


        private IQueryable<Project> GetProjectById(int id) => _projecten
                .AsNoTracking()
                .Where(p => p.Id == id);

        private IQueryable<Project> GetProjectByUserId(int id) => _projecten
                .AsNoTracking()
                .Where(p => p.User.Id == id);

        public async Task<ProjectenResponse.Create> CreateAsync(ProjectenRequest.Create request)
        {
            ProjectenResponse.Create response = new();
            var project = _projecten.Add(new Project(
                request.Projecten.Name
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
            response.Projecten = await GetProjectById(request.ProjectenId)
                .Select(x => new ProjectenDto.Detail
                {
                    Id = x.Id,
                    Name = x.Name,
                    user = x.User,
                    VirtualMachines = x.VirtualMachines

                })
                .SingleOrDefaultAsync();
            return response;
        }

        public async Task<ProjectenResponse.GetIndex> GetAllIndexAsync(ProjectenRequest.GetIndex request)
        {
            ProjectenResponse.GetIndex response = new();
            var query = _projecten.AsQueryable().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                query = query.Where(x => x.Name.Contains(request.SearchTerm));


            /*if (request.OnlyActiveProjects)
                query = query.Where(x => x.IsEnabled);*/

            response.Total = query.Count();

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
            return response;
        }
    }
}
