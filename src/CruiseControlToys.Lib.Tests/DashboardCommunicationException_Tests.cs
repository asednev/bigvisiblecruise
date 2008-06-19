using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace CruiseControlToys.Lib.Tests
{

    [TestFixture]
    public class DashboardCommunicationException_Tests
    {

        [Test]
        public void check_that_the_uri_is_accessible_when_the_dashboard_exception_is_thrown() 
        {
            DashboardCommunicationException exception = new DashboardCommunicationException(new Uri("http://www.foo.com"), null);
            Assert.That(exception.Uri, Is.EqualTo(new Uri("http://www.foo.com")));
        }

    }

}
