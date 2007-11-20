using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CruiseControlToys.Lib
{
    public class AggregateResolver : IResolver
    {
        private IList<IResolver> _itemsToResolve;

        IList<IResolver> ItemsToResolve
        {
            get
            {
                return _itemsToResolve;
            }
            set
            {
                _itemsToResolve = value;
            }
        }

        public AggregateResolver(IList<IResolver> itemsToResolve) 
        {
            this.ItemsToResolve = itemsToResolve;
        }

        public ObservableCollection<ProjectStatus> GetProjects()
        {
            ObservableCollection<ProjectStatus> allProjects = new ObservableCollection<ProjectStatus>();
            foreach (IResolver resolver in this.ItemsToResolve) 
            {
                ObservableCollection<ProjectStatus> projects = resolver.GetProjects();
                if (projects != null) 
                {
                    foreach (ProjectStatus projectStatus in projects) 
                    {
                        allProjects.Add(projectStatus);
                    }
                }
            }
            return allProjects;
        }

    }
}
