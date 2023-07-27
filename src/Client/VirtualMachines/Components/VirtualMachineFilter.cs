using System;
using Domain.VirtualMachines.VirtualMachine;

namespace Client.VirtualMachines.Components
{
    public class VirtualMachineFilter
    {
        public event Action OnVirtualMachineFilterChanged;
        private string searchTerm = "";
        private VirtualMachineMode? mode = null;

        private void NotifyStateChanged() => OnVirtualMachineFilterChanged.Invoke();

        public string SearchTerm
        {
            get => searchTerm;
            set
            {
                searchTerm = value;
                NotifyStateChanged();
            }
        }

        public VirtualMachineMode? Mode
        {
            get => mode;
            set
            {
                mode = value;
                NotifyStateChanged();
            }
        }
    }
}
