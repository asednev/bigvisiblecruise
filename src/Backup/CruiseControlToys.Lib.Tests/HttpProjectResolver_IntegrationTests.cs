using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace CruiseControlToys.Lib.Tests
{
	[TestFixture]
	public class HttpProjectResolver_IntegrationTests
	{
		[Test]
		[ExpectedException(
			ExceptionType = typeof (DashboardCommunicationException),
			ExpectedMessage = "Unable to contact http://a.b.c.d.e.foo/ccnet/xmlstatusreport.aspx")]
		public void a_connectivity_exception_will_be_thrown_if_the_uri_isnt_resolveable()
		{
			var anUnresolveableUri = new Uri("http://a.b.c.d.e.foo/ccnet/xmlstatusreport.aspx");
			IResolver dashboardResolver = new HttpProjectXmlResolver(anUnresolveableUri);
			dashboardResolver.GetProjectStatusList();
		}

		[Test]
		public void can_construct_dashboard_resolver_with_a_uri()
		{
			var aWellKnownUri = new Uri("http://ccnetlive.thoughtworks.com/ccnet/XmlStatusReport.aspx");
			Assert.That(new HttpProjectXmlResolver(aWellKnownUri), Is.Not.Null);
		}

		[Test]
		public void can_get_projects_from_a_uri()
		{
			var aWellKnownUri = new Uri("http://ccnetlive.thoughtworks.com/ccnet/XmlStatusReport.aspx");
			IResolver dashboarResolver = new HttpProjectXmlResolver(aWellKnownUri);
			Assert.That(dashboarResolver.GetProjectStatusList().Count, Is.EqualTo(6));
		}
	}
}
