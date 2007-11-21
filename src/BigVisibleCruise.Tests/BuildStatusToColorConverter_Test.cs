﻿using System;
using System.Windows.Data;
using System.Windows.Media;
using NUnit.Framework;

namespace BigVisibleCruise.Tests
{
    [TestFixture]
    public class BuildStatusToColorConverter_Test
    {

        [Test]
        public void a_build_status_of_success_is_green()
        {
            string startingValue = "Success";
            IValueConverter converter = new BuildStatusToColorConverter();
            object convertedValue = converter.Convert(startingValue, null, null, null);
            Assert.That(Color.Equals(convertedValue.ToString(), Colors.Green.ToString()));
        }

        [Test]
        public void a_build_status_of_building_is_yellow()
        {
            string startingValue = "Building";
            IValueConverter converter = new BuildStatusToColorConverter();
            object convertedValue = converter.Convert(startingValue, null, null, null);
            Assert.That(Color.Equals(convertedValue.ToString(), Colors.Yellow.ToString()));
        }

        [Test]
        public void a_build_status_of_failure_is_red()
        {
            string startingValue = "Failure";
            IValueConverter converter = new BuildStatusToColorConverter();
            object convertedValue = converter.Convert(startingValue, null, null, null);
            Assert.That(Color.Equals(convertedValue.ToString(), Colors.Red.ToString()));
        }

        [Test]
        public void a_build_status_of_exception_is_red()
        {
            string startingValue = "Failure";
            IValueConverter converter = new BuildStatusToColorConverter();
            object convertedValue = converter.Convert(startingValue, null, null, null);
            Assert.That(Color.Equals(convertedValue.ToString(), Colors.Red.ToString()));
        }

        [Test]
        public void a_build_status_of_unknown_is_white()
        {
            string startingValue = "Unknown";
            IValueConverter converter = new BuildStatusToColorConverter();
            object convertedValue = converter.Convert(startingValue, null, null, null);
            Assert.That(Color.Equals(convertedValue.ToString(), Colors.White.ToString()));
        }

        [Test]
        public void any_other_color_that_we_havent_considered_will_be_white()
        {
            string startingValue = "foo";
            IValueConverter converter = new BuildStatusToColorConverter();
            object convertedValue = converter.Convert(startingValue, null, null, null);
            Assert.That(Color.Equals(convertedValue.ToString(), Colors.White.ToString()));
        }
    }
}