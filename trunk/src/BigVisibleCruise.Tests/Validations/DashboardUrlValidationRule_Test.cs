using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using BigVisibleCruise.Validations;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace BigVisibleCruise.Tests.Validations
{

    [TestFixture]
    public class DashboardUrlValidationRule_Test
    {

        [Test]
        public void when_dashboard_url_is_empty_then_validation_fails()
        {
            ValidationRule rule = new DashboardUrlValidationRule();
            Assert.That(rule.Validate(string.Empty, null).IsValid, Is.False);
        }

        [Test]
        public void when_dashboard_url_is_not_a_valid_endpoint_then_validation_fails()
        {
            ValidationRule rule = new DashboardUrlValidationRule();
            Assert.That(rule.Validate("http://foo.com/bar", null).IsValid, Is.False);
        }

        [Test, Category("Integration")]
        public void when_dashboard_url_is_valid_endpoint_then_validation_passes()
        {
            ValidationRule rule = new DashboardUrlValidationRule();
            Assert.That(rule.Validate("http://ccnetlive.thoughtworks.com/ccnet", null).IsValid, Is.True);
        }

    }

}
