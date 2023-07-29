using Domain.Projecten;
using Shared.Projecten;
using Shared.VirtualMachines;
using Domain.Users;
using Domain.VirtualMachines.VirtualMachine;

namespace Services.Projects
{
    public class FakeProjectService //: IProjectenService
    {
        /*private List<Project> _projects = new();

        public FakeProjectService()
        {
            _projects = ProjectFaker.Instance.Generate(15);


        }

        public Task AddUserFromProject(ProjectenRequest.AddUserFromProject request)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectenResponse.Create> AddVMAsync(ProjectenRequest.AddVM request)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectenResponse.Create> CreateAsync(ProjectenRequest.Create request)
        {
            throw new NotImplementedException();
            /*await Task.Delay(100);

            ProjectenResponse.Create response = new();

            var project = request.Projecten;
            var customer = request.Projecten.user;

            int id = _projects.Max(x => x.Id) + 1;

            Project p = new Project(project.Name) { Id = id, User = customer };
            _projects.Add(p);



            response.ProjectenId = id;

            return response;
        }

        public async Task DeleteAsync(ProjectenRequest.Delete request)
        {
            await Task.Delay(100);

            var proj = _projects.SingleOrDefault(x => x.Id == request.ProjectenId);
            _projects.Remove(proj);
        }

        public async Task<ProjectenResponse.Edit> EditAsync(ProjectenRequest.Edit request)
        {
            await Task.Delay(100);
            ProjectenResponse.Edit response = new();

            var proj = _projects.SingleOrDefault(x => x.Id == request.ProjectenId);

            if (proj == null)
            {
                response.ProjectenId = -1;
                return response;
            }


            proj.Name = request.Projecten.Name;
            proj.User = request.Projecten.user;

            response.ProjectenId = proj.Id;
            return response;


        }

        public Task<ProjectenResponse.GetIndex> GetAllIndexAsync(ProjectenRequest.GetIndex request)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectenResponse.GetDetail> GetDetailAsync(ProjectenRequest.GetDetail request)
        {
            await Task.Delay(1000);
            ProjectenResponse.GetDetail response = new();

            Project project = _projects.Single(e => e.Id == request.ProjectenId);
            List<VirtualMachine> vms = new();
            project.VirtualMachines.ForEach(e => vms.Add(new VirtualMachine { Id = e.Id, Mode = e.Mode, Name = e.Name }));

            response.Project = new ProjectenDto.Detail() { Id = project.Id, user = project.User, VirtualMachines = vms };



            return response;
        }


        public async Task<ProjectenResponse.GetIndex> GetIndexAsync(ProjectenRequest.GetIndex request)
        {

            await Task.Delay(100);

            ProjectenResponse.GetIndex response = new();
            List<Project> projects;

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                projects = _projects.FindAll(e => e.Name.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) /*|| e.User.Name.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                projects = _projects;
            }

            response.Total = projects.Count();
            response.Projecten = projects.Select(x => new ProjectenDto.Index
            {
                Id = x.Id,
                Name = x.Name,
                user = x.User

            }).ToList();

            return response;
        }

        public Task<ProjectenResponse.GetIndex> GetIndexAsync(ProjectenRequest.GetIndexForUser request)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUserFromProject(ProjectenRequest.RemoveUserFromProject request)
        {
            throw new NotImplementedException();
        }*/
    }
}

