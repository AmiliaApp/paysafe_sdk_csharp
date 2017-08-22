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
using Paysafe.DirectDebit;

namespace Tests.DirectDebit
{
    class GivenAPaysafeDirectDebitApi
    {
        /*
         * Direct Debit Purchases
         */

        // Process a purchase
        [Test]
        public void When_I_process_an_eft_purchase_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleEftDirectDebitService();

            var purchase = SampleFactory.CreateSampleEftPurchase();

            Purchases response = service.Submit(purchase);

            Assert.AreEqual(response.Status(), "COMPLETED");
        }

        [Test]
        public async Task When_I_process_an_eft_purchase_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleEftDirectDebitService();

            var purchase = SampleFactory.CreateSampleEftPurchase();

            Purchases response = await service.SubmitAsync(purchase);

            Assert.AreEqual(response.Status(), "COMPLETED");
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_process_an_ach_purchase_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleAchDirectDebitService();

            var purchase = SampleFactory.CreateSampleAchPurchase();

            Purchases response = service.Submit(purchase);

            Assert.AreEqual(response.Status(), "COMPLETED");
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_process_an_ach_purchase_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleAchDirectDebitService();

            var purchase = SampleFactory.CreateSampleAchPurchase();

            Purchases response = await service.SubmitAsync(purchase);

            Assert.AreEqual(response.Status(), "COMPLETED");
        }

        [Test]
        public void When_I_process_an_eft_purchase_using_a_token_Then_it_should_return_a_valid_response_sync()
        {
            var directDebitService = SampleFactory.CreateSampleEftDirectDebitService();
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();

            var profile = SampleFactory.CreateSampleProfile();
            profile = vaultService.Create(profile);

            var address = SampleFactory.CreateSampleAddress(profile);
            address = vaultService.Create(address);

            var account = SampleFactory.CreatSampleEftBankAccount(profile, address);
            account = vaultService.Create(account);

            Purchases response = directDebitService.Submit(Purchases.Builder()
                                                                    .MerchantRefNum(System.Guid.NewGuid().ToString())
                                                                    .Amount(10038)
                                                                    .Eft()
                                                                        .PaymentToken(account.PaymentToken())
                                                                        .Done()
                                                                    .Build());

            Assert.AreEqual(response.Status(), "COMPLETED");
        }

        [Test]
        public async Task When_I_process_an_eft_purchase_using_a_token_Then_it_should_return_a_valid_response_async()
        {
            var directDebitService = SampleFactory.CreateSampleEftDirectDebitService();
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();

            var profile = SampleFactory.CreateSampleProfile();
            profile = await vaultService.CreateAsync(profile);

            var address = SampleFactory.CreateSampleAddress(profile);
            address = await vaultService.CreateAsync(address);

            var account = SampleFactory.CreatSampleEftBankAccount(profile, address);
            account = await vaultService.CreateAsync(account);

            Purchases response = await directDebitService.SubmitAsync(Purchases.Builder()
                                                                               .MerchantRefNum(System.Guid.NewGuid().ToString())
                                                                               .Amount(10038)
                                                                               .Eft()
                                                                                   .PaymentToken(account.PaymentToken())
                                                                                   .Done()
                                                                               .Build());

            Assert.AreEqual(response.Status(), "COMPLETED");
        }
    }
}
