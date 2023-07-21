using System;

namespace Client.Shared
{
    public class VirtualMachineFilter
    {
        public event Action OnVirtualMachineFilterChanged;
        /*private int page;
        private int amount = 25;*/
        private string searchTerm;
        /*private string category;
        private decimal? minimumPrice;
        private decimal? maximumPrice;*/

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

        /*public string Category
        {
            get => category;
            set
            {
                category = value;
                NotifyStateChanged();
            }
        }

        public decimal? MinimumPrice
        {
            get => minimumPrice;
            set
            {
                minimumPrice = value;
                NotifyStateChanged();
            }
        }

        public decimal? MaximumPrice
        {
            get => maximumPrice;
            set
            {
                maximumPrice = value;
                NotifyStateChanged();
            }
        }

        public int Amount
        {
            get => amount;
            set
            {
                amount = value;
                NotifyStateChanged();
            }
        }

        public int Page
        {
            get => page;
            set
            {
                page = value;
                NotifyStateChanged();
            }
        }*/

    }
}
