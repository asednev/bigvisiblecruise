using System.Windows.Data;
using BigVisibleCruise.Converters;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace BigVisibleCruise.Tests.Converters
{
	[TestFixture]
	public class BooleanToBooleanConverter_Test
	{
		[Test]
		public void a_function_that_provides_a_false_returns_a_false_by_default()
		{
			IValueConverter converter = new BooleanToBooleanConverter();
			Assert.That(converter.Convert(false, null, null, null), Is.False);
		}

		[Test]
		public void a_function_that_provides_a_true_returns_a_false_when_parameter_value_is_false()
		{
			IValueConverter converter = new BooleanToBooleanConverter();
			Assert.That(converter.Convert(true, null, "false", null), Is.False);
		}

		[Test]
		public void a_function_that_provides_a_true_returns_a_true_by_default()
		{
			IValueConverter converter = new BooleanToBooleanConverter();
			Assert.That(converter.Convert(true, null, null, null), Is.True);
		}

		[Test]
		public void convertback_should_return_null_when_false()
		{
			IValueConverter converter = new BooleanToBooleanConverter();
			Assert.That(converter.ConvertBack(false, null, null, null), Is.Null);
		}

		[Test]
		public void convertback_should_return_null_when_true()
		{
			IValueConverter converter = new BooleanToBooleanConverter();
			Assert.That(converter.ConvertBack(true, null, null, null), Is.Null);
		}
	}
}
