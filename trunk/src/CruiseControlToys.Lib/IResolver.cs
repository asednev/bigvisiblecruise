using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CruiseControlToys.Lib
{
    public interface IResolver
    {
        ObservableCollection<ProjectStatus> GetProjects();
        ObservableCollection<ProjectStatus> GetProjectsByName(StringCollection projectNamesToInclude);
    }
}
