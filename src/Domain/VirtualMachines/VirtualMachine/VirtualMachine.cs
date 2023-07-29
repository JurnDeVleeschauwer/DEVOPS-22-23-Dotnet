using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Projecten;
using Domain.Server;
using Domain.VirtualMachines.BackUp;
using Domain.VirtualMachines.Contract;
using Domain.Statistics;
using System.Net;

namespace Domain.VirtualMachines.VirtualMachine
{
    public class VirtualMachine : Entity
    {

        private VMContract _vmContract;


        private string _name;
        private OperatingSystemEnum _operatingSystem;
        private VirtualMachineMode _mode;
        private FysiekeServer? _server;
        private Statistic _statistics;
        private string _why;


        public string Name { get { return _name; } set { _name = Guard.Against.NullOrEmpty(value, nameof(_name)); } }
        public OperatingSystemEnum OperatingSystem { get { return _operatingSystem; } set { _operatingSystem = Guard.Against.Null(value, nameof(_operatingSystem)); } }
        public VirtualMachineMode Mode { get { return _mode; } set { _mode = Guard.Against.Null(value, nameof(_mode)); } }
        public Hardware Hardware { get; set; }
        public Backup BackUp { get; set; }
        public VMConnection? Connection { get; set; }
        public VMContract Contract { get; set; }
        public FysiekeServer? FysiekeServer { get; set; }
        public Statistic Statistics { get; set; }

        public string Why { get { return _why; } set { _why = Guard.Against.NullOrEmpty(value, nameof(_why)); } }


        public VirtualMachine(string n, OperatingSystemEnum os, Hardware h, Backup b, string w)
        {
            Name = n;
            OperatingSystem = os;
            Hardware = h;
            BackUp = b;
            Mode = VirtualMachineMode.WAITING_APPROVEMENT;
            Why = w;
        }

        public VirtualMachine()
        {

        }

        public void AddConnection(string FQDN, IPAddress hostname, string username, string password)
        {
            Connection = new VMConnection(FQDN, hostname, username, password);
            Mode = VirtualMachineMode.READY;
        }



    }
}

