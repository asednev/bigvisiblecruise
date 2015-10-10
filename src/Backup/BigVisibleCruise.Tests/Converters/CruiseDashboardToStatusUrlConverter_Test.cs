using System.Windows.Data;
using BigVisibleCruise.Converters;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace BigVisibleCruise.Tests.Converters
{
	[TestFixture]
	public class CruiseDashboardToStatusUrlConverter_Test
	{

        [Test]
		public void a_dashboard_url_with_a_trailing_slash_resolves_to_a_status_url_for_ccnet()
		{
            string userInputValue = "http://ccnetlive.thoughtworks.com/ccnet/";
			IValueConverter converter = new CruiseDashboardToStatusUrlConverter();
			object convertedValue = converter.ConvertBack(userInputValue, null, null, null);
			Assert.That(convertedValue, Is.EqualTo("http://ccnetlive.thoughtworks.com/ccnet/XmlStatusReport.aspx"));
		}

		[Test]
		public void a_dashboard_url_without_a_trailing_slash_resolves_to_a_status_url_for_ccnet()
		{
            string userInputValue = "http://ccnetlive.thoughtworks.com/ccnet";
			IValueConverter converter = new CruiseDashboardToStatusUrlConverter();
			object convertedValue = converter.ConvertBack(userInputValue, null, null, null);
			Assert.That(convertedValue, Is.EqualTo("http://ccnetlive.thoughtworks.com/ccnet/XmlStatusReport.aspx"));
		}

		[Test]
		public void a_dashboard_url_without_http_will_have_it_automagically_created()
		{
            string userInputValue = "ccnetlive.thoughtworks.com/ccnet/";
			IValueConverter converter = new CruiseDashboardToStatusUrlConverter();
			object convertedValue = converter.ConvertBack(userInputValue, null, null, null);
			Assert.That(convertedValue, Is.EqualTo("http://ccnetlive.thoughtworks.com/ccnet/XmlStatusReport.aspx"));
		}

		[Test]
		public void a_status_url_for_ccnet_resolves_to_a_dashboard_url_for_display()
		{
			const string configurationValue = "http://ccnetlive.thoughtworks.com/ccnet/XmlStatusReport.aspx";
			IValueConverter converter = new CruiseDashboardToStatusUrlConverter();
			object convertedValue = converter.Convert(configurationValue, null, null, null);
			Assert.That(convertedValue, Is.EqualTo("http://ccnetlive.thoughtworks.com/ccnet"));
		}
	}









}
