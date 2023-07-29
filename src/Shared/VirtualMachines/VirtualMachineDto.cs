using Domain.Common;
using Domain.VirtualMachines.Contract;
using Domain.VirtualMachines;
using FluentValidation;
using Domain.VirtualMachines.VirtualMachine;
using Domain.VirtualMachines.BackUp;
using Domain.Server;
using Domain.Statistics;
using Domain.Projecten;
using System.ComponentModel.DataAnnotations;

namespace Shared.VirtualMachines
{
    public static class VirtualMachineDto
    {
        public class Index
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public VirtualMachineMode Mode { get; set; }

        }
        public class Detail : Index
        {
            public Hardware Hardware { get; set; }
            public OperatingSystemEnum OperatingSystem { get; set; }
            public VMContract Contract { get; set; }
            public Backup BackUp { get; set; }
            public FysiekeServer? FysiekeServer { get; set; }
            public VMConnection? VMConnection { get; set; }
            public string Why { get; set; }
        }

        public class IndexHardWare : Index
        {
            public Hardware Hardware { get; set; }
        }

        public class Rapportage
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Statistic Statistics { get; set; }

        }
        public class Edit
        {
            public String Name { get; set; }
            public Backup Backup { get; set; }
        }
        public class Mutate
        {
            [Required(ErrorMessage = "Je moet een naam ingeven.")]
            [StringLength(50, ErrorMessage = "Naam is te lang")]
            public String Name { get; set; }
            public Hardware Hardware { get; set; }
            public OperatingSystemEnum OperatingSystem { get; set; }
            public Backup Backup { get; set; }
            //public Project Project { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }

            public class Validator : AbstractValidator<Mutate>
            {
                public Validator()
                {
                    RuleFor(x => x.Name).NotEmpty().Length(5, 50);
                    RuleFor(x => x.Hardware.Amount_vCPU).LessThan(50);
                    RuleFor(x => x.Hardware.Storage).NotEmpty();
                    RuleFor(x => x.Hardware.Memory).NotEmpty();
                    //RuleFor(x => x.Project).NotNull();
                    RuleFor(x => x.Start).NotEmpty();
                    RuleFor(x => x.End).NotEmpty();
                    RuleFor(x => x.Backup.Type).NotNull();

                }
            }


        }

        public class Create : Mutate
        {
            [Required(ErrorMessage = "Je moet een project selecteren.")]
            public int? ProjectId { get; set; }
            public int Id { get; set; }

            [Required(ErrorMessage = "Zeg waarom")]
            public string Why { get; set; }
            public class Validator : AbstractValidator<Create>
            {
                /*public Validator()
                {
                    RuleFor(x => x.Id).NotEmpty();
                    RuleFor(x => x.ProjectId).NotEmpty();
                }*/
            }
        }

        /*public class Mutate
        {
            public String Name { get; set; }
            public OperatingSystemEnum OperatingSystem { get; set; }
            public VirtualMachineMode Mode { get; set; }
            public int Memory { get; set; }
            public int Storage { get; set; }
            public int Amount_vCPU { get; set; }
            public VMContract _contract { get; set; }
            public VMConnection Connection { get; set; }
            public BackUpType Type { get; set; }
            public DateTime LastBackup { get; set; }


        }*/

    }
}
