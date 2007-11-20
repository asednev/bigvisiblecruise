
using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace CruiseControlToys.Lib.Tests
{

    [TestFixture]
    public class DashboardResolver_IntegrationTests
    {

        [Test]
        public void can_construct_dashboard_resolver_with_a_uri()
        {
            Uri aWellKnownUri = new Uri("http://ccnetlive.thoughtworks.com/ccnet/XmlStatusReport.aspx");
            Assert.That(DashboardResolver.FromUri(aWellKnownUri), Is.Not.Null);
        }

        [Test]
        public void can_get_projects_from_a_uri()
        {
            Uri aWellKnownUri = new Uri("http://ccnetlive.thoughtworks.com/ccnet/XmlStatusReport.aspx");
            IResolver dashboarResolver = DashboardResolver.FromUri(aWellKnownUri);
            Assert.That(dashboarResolver.GetProjects().Count, Is.EqualTo(8));
        }
    }

}
