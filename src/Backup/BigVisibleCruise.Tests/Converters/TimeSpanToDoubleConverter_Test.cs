using System;
using System.Windows.Data;
using BigVisibleCruise.Converters;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace BigVisibleCruise.Tests.Converters
{
	[TestFixture]
	public class TimeSpanToDoubleConverter_Test
	{
		[Test]
		public void a_double_of_15_seconds_converts_back_to_a_timespan_of_15_seconds()
		{
			IValueConverter converter = new TimeSpanToDoubleConverter();
			object convertedBackValue = converter.ConvertBack(15d, null, null, null);
			Assert.That(convertedBackValue, Is.EqualTo(TimeSpan.FromSeconds(15)));
		}

		[Test]
		public void a_timespan_of_15_seconds_converts_to_a_double_of_15()
		{
			IValueConverter converter = new TimeSpanToDoubleConverter();
			object convertedValue = converter.Convert(TimeSpan.FromSeconds(15), null, null, null);
			Assert.That(convertedValue, Is.EqualTo(15d));
		}
	}
}
