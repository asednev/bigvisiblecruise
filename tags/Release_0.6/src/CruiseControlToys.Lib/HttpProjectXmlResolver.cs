﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Xml;
using System.Collections.Specialized;

namespace CruiseControlToys.Lib
{

    public class HttpProjectXmlResolver : IResolver
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

        private HttpProjectXmlResolver()
        {

        }

        public static HttpProjectXmlResolver FromUri(Uri location) 
        {            
            HttpProjectXmlResolver httpProjectXmlResolver = new HttpProjectXmlResolver();
            httpProjectXmlResolver.Uri = location;
            return httpProjectXmlResolver;
        }

        public static HttpProjectXmlResolver FromProjectStatusDocument(XmlDocument projectStatusDocument)
        {
            HttpProjectXmlResolver httpProjectXmlResolver = new HttpProjectXmlResolver();
            httpProjectXmlResolver.ProjectStatusDocument = projectStatusDocument;
            return httpProjectXmlResolver;
        }

        public IList<ProjectStatus> GetProjects() 
        {
            RefreshProjectStatusDocumentIfThereIsAnHttpUri();

            XmlNodeList projectList = this.ProjectStatusDocument.SelectNodes("/Projects/Project");
            IList<ProjectStatus> list = new List<ProjectStatus>();

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

        public IList<ProjectStatus> GetProjectsByName(StringCollection projectNamesToInclude)
        {

            IList<ProjectStatus> list = GetProjects();
            IList<ProjectStatus> filteredList = new List<ProjectStatus>();

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
                string content = GetRemoteContent();
                XmlDocument statusDocument = new XmlDocument();
                statusDocument.LoadXml(content);
                this.ProjectStatusDocument = statusDocument;
            }
        }

        private string GetRemoteContent()
        {
            try
            {
                WebClient cruiseClient = new WebClient();
                return cruiseClient.DownloadString(this.Uri.ToString());
            }
            catch (WebException webException)
            {
                throw new DashboardCommunicationException(this.Uri, webException);
            }
        }
    }


}