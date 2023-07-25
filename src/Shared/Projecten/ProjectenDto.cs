using FluentValidation;
using Domain.Users;
using Domain.VirtualMachines.VirtualMachine;
using System.ComponentModel.DataAnnotations;

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
            public List<User> Users { get; set; }
        }

        public class Mutate
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public User user { get; set; }
            public List<VirtualMachine> VirtualMachines { get; set; }

        }

        public class Create
        {
            [Required(ErrorMessage = "Je moet een naam ingeven.")]
            public String Name { get; set; }
            public String UserId { get; set; }
        }
    }
}
