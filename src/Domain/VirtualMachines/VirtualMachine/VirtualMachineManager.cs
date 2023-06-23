using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Projecten;
using Domain.Server;
using Domain.Users;

namespace Domain.VirtualMachines.VirtualMachine;
//Deze klasse mag weg, maar is nog nice om op terug te kijken bij het imlpementeren van de echte service
// BV project moet vm verwijderen,  Server moet vm verwijderen, Hierna pas de VM (ook voor wrs geen foreign key constraint error en zulke shit te krijgen)


/*
public class VirtualMachineManager
{
    private IList<FysiekeServer> _fysiekeServers = new List<FysiekeServer>();
    private IList<Project> _projecten = new List<Project>();
    private IList<VirtualMachine> _allVms = new List<VirtualMachine>();
    //for testing
    public VirtualMachineManager()
    {
    }
    public Project GetProject(int id)
    {
        return _projecten.First(e => e.Id == id);
    }
    public FysiekeServer GetServer(int id)
    {
        return _fysiekeServers.First(e => e.Id == id);
    }
    public VirtualMachine CreateVM(string name, Project project, OperatingSystemEnum os, Hardware hw, Backup b, User k, DateTime start, DateTime end)
    {
        FysiekeServer server = _fysiekeServers.First(e => e.VCPUsAvailable > hw.Amount_vCPU && e.StorageAvailable > hw.Storage && e.MemoryAvailable > hw.Memory);
        if (server == null)
        {
            throw new ArgumentException("None of the servers have the available resources available.");
        }
        _fysiekeServers.Remove(server);
        VirtualMachine vm = new VirtualMachine(name, os, hw, b);
        vm.Contract = new VMContract(k.Id, vm.Id, start, end);
        server.AddToServer(vm);
        Project proj = GetProject(project.Id);
        if (proj == null)
        {
            proj = new Project(project.Name, k);
        }
        else
        {
            _projecten.Remove(proj);
        }
        proj.AddVirtualMachine(vm);
        _projecten.Add(proj);
        _fysiekeServers.Add(server);
        _allVms.Add(vm);
        return vm;
    }
    public bool DeleteVM(int id)
    {
        VirtualMachine? vm = _allVms.FirstOrDefault(e => e.Id == id, null);
        if (vm == null) return false;
        Project p = GetProject(vm.Project.Id);
        FysiekeServer? f = _fysiekeServers.First(e => e.GetVirtualMachineById(id) != null);
        // if f == null  -> de aanvraag werd niet goegekeurd door beheerder dus had nog geen server, wel een project
        if (f != null)
        {
            _fysiekeServers.Remove(f);
            f.RemoveFromServer(vm);
            _fysiekeServers.Add(f);
        }
        _projecten.Remove(p);
        p.RemoveVirtualMachine(vm);
        _projecten.Add(p);
        return true;
    }
}
}
    public void EditVM(int id, Hardware hw, BackUpType type, User k, VMConnection connection)
    {
        VirtualMachine vm = _vms.First(x => x.Id == id);
        if (vm != null)
        {
            //Deletes vm out of the list of VMS
            DeleteVM(id);
            vm.Hardware = hw;
            vm.BackUp.Type = type;
            vm.Project = k.Project;
            vm.Connection = connection;
            //Adds it again after changing it
            _vms.Append(vm);
        }
    }
    */
