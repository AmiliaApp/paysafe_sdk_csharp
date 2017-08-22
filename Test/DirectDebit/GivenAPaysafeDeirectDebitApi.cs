using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Paysafe;
using Paysafe.CardPayments;
using Paysafe.CustomerVault;

namespace Tests.DirectDebit
{
    class GivenAPaysafeDeirectDebitApi
    {
        /*
         * Direct Debit Purchases
         */

        // Process a purchase
        [Test]
        public void When_I_create_a_profile_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();

            var response = service.Create(profile);

            Assert.IsTrue(response.Status() == "ACTIVE");
        }

        [Test]
        public async Task When_I_create_a_profile_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();

            var response = await service.CreateAsync(profile);

            Assert.IsTrue(response.Status() == "ACTIVE");
        }
    }
}
