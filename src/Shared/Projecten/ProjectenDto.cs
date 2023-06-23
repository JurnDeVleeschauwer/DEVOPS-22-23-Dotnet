using FluentValidation;
using Domain.Users;
using Domain.VirtualMachines.VirtualMachine;

namespace Shared.Projecten
{
    public static class ProjectenDto
    {
        public class Index
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public User user { get; set; }


        }

        public class Detail : Index
        {
            public List<VirtualMachine> VirtualMachines { get; set; }
        }

        public class Mutate
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public User user { get; set; }
            public List<VirtualMachine> VirtualMachines { get; set; }

        }
    }
}
