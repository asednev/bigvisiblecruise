using System.Windows.Data;
using BigVisibleCruise.Converters;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace BigVisibleCruise.Tests.Converters
{
    [TestFixture]
    public class BuildNameToHumanizedNameConverter_Test
    {
        
        [Test]
        public void name_with_underscores_has_them_removed()
        {
            string startingValue = "foo_bar_yo";
            IValueConverter converter = new BuildNameToHumanizedNameConverter();
            object convertedValue = converter.Convert(startingValue, null, null, null);

            Assert.That(convertedValue, Is.EqualTo("foo bar yo"));
        }

        [Test]
        public void name_without_underscores_is_returned_as_is()
        {
            string startingValue = "foo Bar yo";
            IValueConverter converter = new BuildNameToHumanizedNameConverter();
            object convertedValue = converter.Convert(startingValue, null, null, null);

            Assert.That(convertedValue, Is.EqualTo(startingValue));
        }
    }
}