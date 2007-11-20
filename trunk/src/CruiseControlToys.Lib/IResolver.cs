using System.Collections.ObjectModel;

namespace CruiseControlToys.Lib
{
    public interface IResolver
    {
        ObservableCollection<ProjectStatus> GetProjects();
    }
}
