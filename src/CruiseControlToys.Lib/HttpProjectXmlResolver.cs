using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;

namespace CruiseControlToys.Lib
{
    public class HttpProjectXmlResolver : IResolver
    {
        private readonly CruiseAddress _cruiseAddress = new CruiseAddress();
        private IWebClient _webClient = new CruiseWebClient();
        private Regex _explicitInclude = new Regex(".+");

        public IWebClient WebClient
        {
            set { _webClient = value; }
        }

        public Regex ExplicitInclude 
        {
            set { _explicitInclude = value; }
        }

        public HttpProjectXmlResolver(Uri uri)
        {
            _cruiseAddress.Uri = uri;
        }

        public IList<ProjectStatus> GetProjectStatusList()
        {
            var xml = FetchProjectStatusXml();
            return CreateProjectStatusListFromXml(xml);
        }

        private IList<ProjectStatus> CreateProjectStatusListFromXml(XmlNode rootNode)
        {
            XmlNodeList projectNodeList = rootNode.SelectNodes("/Projects/Project");
            IList<ProjectStatus> projectStatusList = new List<ProjectStatus>();

            foreach (XmlNode projectNode in projectNodeList)
            {
                string name = projectNode.SelectSingleNode("./@name").Value;

                if (!(_explicitInclude.Match(name).Success))
                {
                    continue;
                }

                string activity = projectNode.SelectSingleNode("./@activity").Value;
                string lastBuildStatus = projectNode.SelectSingleNode("./@lastBuildStatus").Value;
                string currentBuildStatus = (activity == "Building") ? "Building" : lastBuildStatus;
                DateTime lastBuildTime = DateTime.Parse(projectNode.SelectSingleNode("./@lastBuildTime").Value);
                projectStatusList.Add(new ProjectStatus(name, currentBuildStatus, lastBuildTime));
            }

            return projectStatusList;
        }

        private XmlDocument FetchProjectStatusXml()
        {
            if (!_cruiseAddress.IsValid) throw new DashboardCommunicationException(_cruiseAddress.Uri);
            string content = GetRemoteContent();
            var statusDocument = new XmlDocument();
            statusDocument.LoadXml(content);
            return statusDocument;
        }

        private string GetRemoteContent()
        {
            try
            {
                return _webClient.DownloadString(_cruiseAddress.Uri.ToString());
            }
            catch (WebException webException)
            {
                throw new DashboardCommunicationException(_cruiseAddress.Uri, webException);
            }
        }
    }
}