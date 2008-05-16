using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CruiseControlToys.Lib
{
    public interface IResolver
    {
        IList<ProjectStatus> GetProjects();
    }
}
