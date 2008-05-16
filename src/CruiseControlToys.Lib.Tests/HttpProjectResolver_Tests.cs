using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Xml;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace CruiseControlToys.Lib.Tests
{

    [TestFixture]
    public class HttpProjectResolver_Tests
    {

        [Test]
        public void can_construct_dashboard_resolver_with_a_status_document()
        {
            string projectXml = @"<Projects>
                                <Project name='FooProject' category='' activity='Sleeping' lastBuildStatus='Success' lastBuildLabel='292' lastBuildTime='2007-11-16T15:03:46.358374-05:00' nextBuildTime='2007-11-16T15:31:00.2683768-05:00' webUrl='http://foo/ccnet'/>
                                <Project name='BarProject' category='' activity='Sleeping' lastBuildStatus='Failure' lastBuildLabel='8' lastBuildTime='2007-11-16T05:00:00.2127436-05:00' nextBuildTime='2007-11-17T05:00:00-05:00' webUrl='http://foo/ccnet'/>
                                <Project name='One_More_Project' category='' activity='Sleeping' lastBuildStatus='Failure' lastBuildLabel='39' lastBuildTime='2007-11-16T05:50:00.1105168-05:00' nextBuildTime='2007-11-17T05:50:00-05:00' webUrl='http://foo/ccnet'/>
                           </Projects>";

            XmlDocument statusDocument = new XmlDocument();
            statusDocument.LoadXml(projectXml);

            HttpProjectXmlResolver resolver = HttpProjectXmlResolver.FromProjectStatusDocument(statusDocument);

            Assert.That(resolver.ProjectStatusDocument, Is.EqualTo(statusDocument));
        }

        [Test]
        public void projects_parsed_have_accurate_names_when_resolved_for_multiple_projects()
        {
            string projectXml = @"<Projects>
                                <Project name='FooProject' category='' activity='Sleeping' lastBuildStatus='Success' lastBuildLabel='292' lastBuildTime='2007-11-16T15:03:46.358374-05:00' nextBuildTime='2007-11-16T15:31:00.2683768-05:00' webUrl='http://foo/ccnet'/>
                                <Project name='BarProject' category='' activity='Sleeping' lastBuildStatus='Failure' lastBuildLabel='8' lastBuildTime='2007-11-16T05:00:00.2127436-05:00' nextBuildTime='2007-11-17T05:00:00-05:00' webUrl='http://foo/ccnet'/>
                                <Project name='One_More_Project' category='' activity='Sleeping' lastBuildStatus='Failure' lastBuildLabel='39' lastBuildTime='2007-11-16T05:50:00.1105168-05:00' nextBuildTime='2007-11-17T05:50:00-05:00' webUrl='http://foo/ccnet'/>
                           </Projects>";

            XmlDocument statusDocument = new XmlDocument();
            statusDocument.LoadXml(projectXml);

            HttpProjectXmlResolver resolver = HttpProjectXmlResolver.FromProjectStatusDocument(statusDocument);
            IList<ProjectStatus> statuses = resolver.GetProjects();

            Assert.That(statuses.Count, Is.EqualTo(3));

            Assert.That(statuses[0].Name, Is.EqualTo("FooProject"));
            Assert.That(statuses[1].Name, Is.EqualTo("BarProject"));
            Assert.That(statuses[2].Name, Is.EqualTo("One_More_Project"));
        }

        [Test]
        public void build_status_is_success_if_sleeping_and_last_build_status_was_success()
        {
            string projectXml = @"  <Projects>
                                        <Project name='FooProject' category='' activity='Sleeping' lastBuildStatus='Success' lastBuildLabel='292' lastBuildTime='2007-11-16T15:03:46.358374-05:00' nextBuildTime='2007-11-16T15:31:00.2683768-05:00' webUrl='http://foo/ccnet'/>
                                    </Projects>";

            XmlDocument statusDocument = new XmlDocument();
            statusDocument.LoadXml(projectXml);

            HttpProjectXmlResolver resolver = HttpProjectXmlResolver.FromProjectStatusDocument(statusDocument);
            IList<ProjectStatus> statuses = resolver.GetProjects();

            Assert.That(statuses[0].CurrentBuildStatus, Is.EqualTo("Success"));
        }

        [Test]
        public void build_status_is_failure_if_sleeping_and_last_build_status_was_failure()
        {
            string projectXml = @"  <Projects>
                                        <Project name='FooProject' category='' activity='Sleeping' lastBuildStatus='Failure' lastBuildLabel='292' lastBuildTime='2007-11-16T15:03:46.358374-05:00' nextBuildTime='2007-11-16T15:31:00.2683768-05:00' webUrl='http://foo/ccnet'/>
                                    </Projects>";

            XmlDocument statusDocument = new XmlDocument();
            statusDocument.LoadXml(projectXml);

            HttpProjectXmlResolver resolver = HttpProjectXmlResolver.FromProjectStatusDocument(statusDocument);
            IList<ProjectStatus> statuses = resolver.GetProjects();

            Assert.That(statuses[0].CurrentBuildStatus, Is.EqualTo("Failure"));
        }

        [Test]
        public void build_status_is_building_if_building_and_last_build_status_was_success()
        {
            string projectXml = @"  <Projects>
                                        <Project name='FooProject' category='' activity='Building' lastBuildStatus='Success' lastBuildLabel='292' lastBuildTime='2007-11-16T15:03:46.358374-05:00' nextBuildTime='2007-11-16T15:31:00.2683768-05:00' webUrl='http://foo/ccnet'/>
                                    </Projects>";

            XmlDocument statusDocument = new XmlDocument();
            statusDocument.LoadXml(projectXml);

            HttpProjectXmlResolver resolver = HttpProjectXmlResolver.FromProjectStatusDocument(statusDocument);
            IList<ProjectStatus> statuses = resolver.GetProjects();

            Assert.That(statuses[0].CurrentBuildStatus, Is.EqualTo("Building"));            
        }

        [Test]
        public void build_status_is_building_if_building_and_last_build_status_was_failure()
        {
            string projectXml = @"  <Projects>
                                        <Project name='FooProject' category='' activity='Building' lastBuildStatus='Failure' lastBuildLabel='292' lastBuildTime='2007-11-16T15:03:46.358374-05:00' nextBuildTime='2007-11-16T15:31:00.2683768-05:00' webUrl='http://foo/ccnet'/>
                                    </Projects>";

            XmlDocument statusDocument = new XmlDocument();
            statusDocument.LoadXml(projectXml);

            HttpProjectXmlResolver resolver = HttpProjectXmlResolver.FromProjectStatusDocument(statusDocument);
            IList<ProjectStatus> statuses = resolver.GetProjects();

            Assert.That(statuses[0].CurrentBuildStatus, Is.EqualTo("Building"));                        
        }


    }
}
