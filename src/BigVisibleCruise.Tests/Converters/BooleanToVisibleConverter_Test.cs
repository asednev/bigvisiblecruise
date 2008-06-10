using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Data;
using BigVisibleCruise.Converters;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace BigVisibleCruise.Tests.Converters
{

    [TestFixture]
    public class BooleanToVisibleConverter_Test
    {

        [Test]
        public void false_results_in_collapsed()
        {
            IValueConverter converter = new BooleanToVisibleConverter();
            Assert.That(converter.Convert(false, null, null, null), Is.EqualTo(Visibility.Collapsed));
        }

        [Test]
        public void true_results_in_visible()
        {
            IValueConverter converter = new BooleanToVisibleConverter();
            Assert.That(converter.Convert(true, null, null, null), Is.EqualTo(Visibility.Visible));
        }

        [Test]
        public void false_results_in_visible_when_parameter_is_specified()
        {
            IValueConverter converter = new BooleanToVisibleConverter();
            Assert.That(converter.Convert(true, null, "false", null), Is.EqualTo(Visibility.Collapsed));
        }

        [Test]
        public void convertback_should_return_null_when_true()
        {
            IValueConverter converter = new BooleanToBooleanConverter();
            Assert.That(converter.ConvertBack(true, null, null, null), Is.Null);
        }

        [Test]
        public void convertback_should_return_null_when_false()
        {
            IValueConverter converter = new BooleanToBooleanConverter();
            Assert.That(converter.ConvertBack(false, null, null, null), Is.Null);
        }
    }

}
