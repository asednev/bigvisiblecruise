using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace BigVisibleCruise.Tests
{

    [TestFixture]
    public class BuildNameToHumancedNameConverter_IntegrationTests
    {
        [Test]
        public void name_with_mapping_is_detected()
        {
            // relies on the config file in the BigVisibleCruise project
            // if the config changes, this test might also

            string startingValue = "CCNet";
            IValueConverter converter = new BuildNameToHumanizedNameConverter();
            object convertedValue = converter.Convert(startingValue, null, null, null);

            Assert.That(convertedValue, Is.EqualTo("Cruise Control .Net Project"));
        }
    }
}
