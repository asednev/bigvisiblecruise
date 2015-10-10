using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace CruiseControlToys.Lib
{
    public class HttpProjectXmlResolver : IResolver
    {
        private readonly List<CruiseAddress> _cruiseAddress = new List<CruiseAddress>();
        private IWebClient _webClient = new CruiseWebClient();
        private Regex _explicitInclude = new Regex(".*");
	    private readonly string _user = string.Empty;
	    private readonly string _password = string.Empty;

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
		    _cruiseAddress.Add(new CruiseAddress {Uri = uri});
	    }
		public HttpProjectXmlResolver(IEnumerable<Uri> uriList, string user, string password)
		{
			_user = user;
			_password = password;

			foreach (var uri in uriList)
			{
				_cruiseAddress.Add(new CruiseAddress { Uri = uri });
			}
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

	        projectStatusList = projectStatusList.OrderBy(x => x.Name).ToList();

			return projectStatusList;
        }

        private XmlDocument FetchProjectStatusXml()
        {
            if (!_cruiseAddress.TrueForAll(x => x.IsValid)) throw new DashboardCommunicationException(_cruiseAddress.First(x => !x.IsValid).Uri);

	        XElement statusDocument = null;

	        try
	        {
		        foreach (var cruiseAddress in _cruiseAddress)
		        {
			        string content = GetRemoteContent(cruiseAddress.Uri);

			        var currentDocument = XElement.Parse(content);
			        if (statusDocument == null)
			        {
				        statusDocument = currentDocument;
			        }
			        else
			        {
				        var projectsNode = statusDocument;

						if (projectsNode != null)
				        foreach (var projectNode in currentDocument.Descendants("Project"))
				        {
							projectsNode.Add(projectNode);
						}

					}

		        }
	        }
	        catch (Exception)
	        {
				//suppress exceptions
	        }
	        var xmlDocument = new XmlDocument();

	        if (statusDocument != null)
	        {
		        xmlDocument.LoadXml(statusDocument.ToString());
	        }

	        return xmlDocument;
        }

        private string GetRemoteContent(Uri uri)
        {
            try
            {
                return _webClient.DownloadString(uri.ToString(), _user, _password);
            }
            catch (WebException webException)
            {
                throw new DashboardCommunicationException(uri, webException);
            }
        }
    }
}