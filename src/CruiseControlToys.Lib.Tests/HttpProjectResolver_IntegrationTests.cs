
using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace CruiseControlToys.Lib.Tests
{

    [TestFixture]
    public class HttpProjectResolver_IntegrationTests
    {

        [Test]
        public void can_construct_dashboard_resolver_with_a_uri()
        {
            Uri aWellKnownUri = new Uri("http://ccnetlive.thoughtworks.com/ccnet/XmlStatusReport.aspx");
            Assert.That(HttpProjectXmlResolver.FromUri(aWellKnownUri), Is.Not.Null);
        }

        [Test]
        public void can_get_projects_from_a_uri()
        {
            Uri aWellKnownUri = new Uri("http://ccnetlive.thoughtworks.com/ccnet/XmlStatusReport.aspx");
            IResolver dashboarResolver = HttpProjectXmlResolver.FromUri(aWellKnownUri);
            Assert.That(dashboarResolver.GetProjects().Count, Is.EqualTo(8));
        }

        [Test]
        [ExpectedException(
            ExceptionType = typeof(DashboardCommunicationException),
            ExpectedMessage = "Unable to contact http://a.b.c.d.e.foo/ccnet/xmlstatusreport.aspx")]
        public void a_connectivity_exception_will_be_thrown_if_the_uri_isnt_resolveable()
        {
            Uri anUnresolveableUri = new Uri("http://a.b.c.d.e.foo/ccnet/xmlstatusreport.aspx");
            IResolver dashboardResolver = HttpProjectXmlResolver.FromUri(anUnresolveableUri);
            dashboardResolver.GetProjects();
        }
    }

}
