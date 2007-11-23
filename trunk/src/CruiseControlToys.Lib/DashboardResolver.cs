using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Xml;
using System.Collections.Specialized;

namespace CruiseControlToys.Lib
{

    public class DashboardResolver : IResolver
    {
        private XmlDocument _projectStatusDocument;
        private Uri _uri;

        public XmlDocument ProjectStatusDocument
        {
            get
            {
                return _projectStatusDocument;
            }
            set
            {
                _projectStatusDocument = value;
            }
        }

        public Uri Uri
        {
            get { return _uri; }
            set { _uri = value; }
        }

        private DashboardResolver()
        {

        }

        public static DashboardResolver FromUri(Uri location) 
        {            
            DashboardResolver dashboardResolver = new DashboardResolver();
            dashboardResolver.Uri = location;
            return dashboardResolver;
        }

        public static DashboardResolver FromProjectStatusDocument(XmlDocument projectStatusDocument)
        {
            DashboardResolver dashboardResolver = new DashboardResolver();
            dashboardResolver.ProjectStatusDocument = projectStatusDocument;
            return dashboardResolver;
        }

        public ObservableCollection<ProjectStatus> GetProjects() 
        {
            RefreshProjectStatusDocumentIfThereIsAnHttpUri();

            XmlNodeList projectList = this.ProjectStatusDocument.SelectNodes("/Projects/Project");
            ObservableCollection<ProjectStatus> list = new ObservableCollection<ProjectStatus>();

            foreach (XmlNode project in projectList)
            {
                string name = project.SelectSingleNode("./@name").Value;
                string activity = project.SelectSingleNode("./@activity").Value;
                string lastBuildStatus = project.SelectSingleNode("./@lastBuildStatus").Value;
                string currentBuildStatus = (activity == "Building") ? "Building" : lastBuildStatus;
                list.Add(new ProjectStatus(name, currentBuildStatus));
            }

            return list; 
        }

        public ObservableCollection<ProjectStatus> GetProjectsByName(StringCollection projectNamesToInclude)
        {

            ObservableCollection<ProjectStatus> list = GetProjects();
            ObservableCollection<ProjectStatus> filteredList = new ObservableCollection<ProjectStatus>();

            foreach (ProjectStatus status in list)
            {
                if (projectNamesToInclude.Contains(status.Name))
                {
                    filteredList.Add(status);
                }
            }

            return filteredList;             
        }

        private void RefreshProjectStatusDocumentIfThereIsAnHttpUri()
        {
            if (this.Uri != null && this.Uri.Scheme.StartsWith("http"))
            {
                WebClient cruiseClient = new WebClient();
                string content = cruiseClient.DownloadString(this.Uri.ToString());
                XmlDocument statusDocument = new XmlDocument();
                statusDocument.LoadXml(content);
                this.ProjectStatusDocument = statusDocument;
            }
        }

    }

}
