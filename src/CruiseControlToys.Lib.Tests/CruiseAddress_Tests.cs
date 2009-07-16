using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace CruiseControlToys.Lib.Tests
{
	[TestFixture]
	public class CruiseAddress_Tests
	{
		[Test]
		public void can_set_valid_uri_and_return_valid()
		{
			var cruiseAddress = new CruiseAddress
			{
				Uri = new Uri("http://valid")
			};
			Assert.That(cruiseAddress.IsValid, Is.True);
		}

		[Test]
		public void can_set_uri_without_http_and_return_invalid()
		{
			var cruiseAddress = new CruiseAddress
			{
				Uri = new Uri("httx://not_valid")
			};
			Assert.That(cruiseAddress.IsValid, Is.False);
		}

		[Test]
		public void can_set_uri_to_emptystring_and_return_invalid()
		{
			var cruiseAddress = new CruiseAddress
			{
				Uri = null
			};
			Assert.That(cruiseAddress.IsValid, Is.False);
		}

        [Test]
        public void break_the_build() 
        {
            Assert.That(1, Is.EqualTo(2));
        }
	}
}

