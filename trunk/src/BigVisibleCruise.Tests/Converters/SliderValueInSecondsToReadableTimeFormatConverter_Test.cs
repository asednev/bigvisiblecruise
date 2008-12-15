using System.Windows.Data;
using BigVisibleCruise.Converters;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace BigVisibleCruise.Tests.Converters
{
	[TestFixture]
	public class SliderValueInSecondsToReadableTimeFormatConverter_Test
	{
		[Test]
		public void a_double_representing_hours_will_convert_to_minute_display_after_conversion()
		{
			IValueConverter converter = new SliderValueInSecondsToReadableTimeFormatConverter();
			var convertedText = (string) converter.Convert((3615d), null, null, null);
			Assert.That(convertedText, Is.EqualTo("Every 60 minutes and 15 seconds"));
		}

		[Test]
		public void a_double_value_representing_minutes_shows_as_minutes_after_conversion()
		{
			IValueConverter converter = new SliderValueInSecondsToReadableTimeFormatConverter();
			var convertedText = (string) converter.Convert(60d, null, null, null);
			Assert.That(convertedText, Is.EqualTo("Every 1 minute"));
		}

		[Test]
		public void a_double_value_representing_minutes_shows_as_minutes_and_seconds_after_conversion()
		{
			IValueConverter converter = new SliderValueInSecondsToReadableTimeFormatConverter();
			var convertedText = (string) converter.Convert(75d, null, null, null);
			Assert.That(convertedText, Is.EqualTo("Every 1 minute and 15 seconds"));
		}

		[Test]
		public void a_double_value_representing_minutes_shows_as_minutes_with_plural_after_conversion()
		{
			IValueConverter converter = new SliderValueInSecondsToReadableTimeFormatConverter();
			var convertedText = (string) converter.Convert(315d, null, null, null);
			Assert.That(convertedText, Is.EqualTo("Every 5 minutes and 15 seconds"));
		}

		[Test]
		public void a_double_value_representing_seconds_only_shows_whole_seconds()
		{
			IValueConverter converter = new SliderValueInSecondsToReadableTimeFormatConverter();
			var convertedText = (string) converter.Convert(15.333333466666, null, null, null);
			Assert.That(convertedText, Is.EqualTo("Every 15 seconds"));
		}

		[Test]
		public void a_double_value_representing_seconds_shows_as_seconds_after_conversion()
		{
			IValueConverter converter = new SliderValueInSecondsToReadableTimeFormatConverter();
			var convertedText = (string) converter.Convert(15d, null, null, null);
			Assert.That(convertedText, Is.EqualTo("Every 15 seconds"));
		}
	}
}
