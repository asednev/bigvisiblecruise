using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using BigVisibleCruise.Converters;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace BigVisibleCruise.Tests.Converters
{
    [TestFixture]
    public class LastBuildDateToDeviceIndependentUnitsConverter_Test
    {

        [Test]
        public void timespan_minutes_convert_to_min_diu_when_under_min()
        {
            IValueConverter converter = new LastBuildDateToDeviceIndependentUnitsConverter();
            double diu = (double)converter.Convert(DateTime.Now.AddMinutes(-9), null, null, null);
            Assert.That(diu, Is.EqualTo(10d));
        }

        [Test]
        public void timespan_minutes_convert_to_increasing_diu_when_in_valid_range()
        {
            IValueConverter converter = new LastBuildDateToDeviceIndependentUnitsConverter();
            double first_diu = (double) converter.Convert(DateTime.Now.AddMinutes(-11), null, null, null);
            double second_diu = (double)converter.Convert(DateTime.Now.AddMinutes(-12), null, null, null);
            Assert.That(first_diu, Is.LessThan(second_diu));
        }

        [Test]
        public void timespan_minutes_convert_to_max_diu_when_over_max()
        {
            IValueConverter converter = new LastBuildDateToDeviceIndependentUnitsConverter();
            double diu = (double)converter.Convert(DateTime.Now.AddMinutes(-101), null, null, null);
            Assert.That(diu, Is.EqualTo(100d));
        }

    }
}
