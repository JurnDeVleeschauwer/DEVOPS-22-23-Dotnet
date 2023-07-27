using System;


namespace Client.Projecten.Components
{
    public class ProjectFilter
    {
        public event Action OnProjectFilterChanged;

        private string searchTerm = "";

        private void NotifyStateChanged() => OnProjectFilterChanged.Invoke();

        public string SearchTerm
        {
            get => searchTerm;
            set
            {
                searchTerm = value;
                NotifyStateChanged();
            }
        }
    }
}
