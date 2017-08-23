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
using Profile = Paysafe.DirectDebit.Profile;
using BillingDetails = Paysafe.DirectDebit.BillingDetails;

namespace Tests.DirectDebit
/*
*Is not covered by tests:
* -Process a BACS purchase using a payment token
* -Process a SEPA purchase using a payment token
* -Process a BACS standalone credit using a payment token
*/

{
    class GivenAPaysafeDirectDebitApi
    {

        private DirectDebitService achDirectDebitService;
        private Purchases achPurchase;

        private DirectDebitService eftDirectDebitService;
        private Purchases eftPurchase;

        private Authorization auth;


        [SetUp]
        public void Init()
        {
            achDirectDebitService = SampleFactory.CreateSampleAchDirectDebitService();
            achPurchase = SampleFactory.CreateSampleAchPurchase();

            eftDirectDebitService = SampleFactory.CreateSampleEftDirectDebitService();
            eftPurchase = SampleFactory.CreateSampleEftPurchase();

            auth = SampleFactory.CreateSampleCustomAuthorization("noException");
        }

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

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_process_an_ach_purchase_using_a_token_Then_it_should_return_a_valid_response_sync()
        {
            var directDebitService = SampleFactory.CreateSampleAchDirectDebitService();
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
                                                                    .Ach()
                                                                        .PaymentToken(account.PaymentToken())
                                                                        .Done()
                                                                    .Build());

            Assert.AreEqual(response.Status(), "COMPLETED");
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_process_an_ach_purchase_using_a_token_Then_it_should_return_a_valid_response_async()
        {
            var directDebitService = SampleFactory.CreateSampleAchDirectDebitService();
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
                                                                               .Ach()
                                                                                   .PaymentToken(account.PaymentToken())
                                                                                   .Done()
                                                                               .Build());

            Assert.AreEqual(response.Status(), "COMPLETED");
        }

        // Cancel a purchase

        [Test]
        public void When_I_cancel_an_eft_purchase_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleEftDirectDebitService();

            var purchase = SampleFactory.CreateSampleEftPurchase();
            purchase = service.Submit(purchase);

            var response = service.Cancel(Purchases.Builder()
                                                   .Status("CANCELLED")
                                                   .Id(purchase.Id())
                                                   .Build());

            Assert.AreEqual(response.Status(), "CANCELLED");
        }

        [Test]
        public async Task When_I_cancel_an_eft_purchase_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleEftDirectDebitService();

            var purchase = SampleFactory.CreateSampleEftPurchase();
            purchase = await service.SubmitAsync(purchase);

            var response = await service.CancelAsync(Purchases.Builder()
                                                              .Status("CANCELLED")
                                                              .Id(purchase.Id())
                                                              .Build());

            Assert.AreEqual(response.Status(), "CANCELLED");
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_cancel_an_ach_purchase_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleAchDirectDebitService();

            var purchase = SampleFactory.CreateSampleAchPurchase();
            purchase = service.Submit(purchase);

            var response = service.Cancel(Purchases.Builder()
                .Status("CANCELLED")
                .Id(purchase.Id())
                .Build());

            Assert.AreEqual(response.Status(), "CANCELLED");
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_cancel_an_ach_purchase_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleAchDirectDebitService();

            var purchase = SampleFactory.CreateSampleAchPurchase();
            purchase = await service.SubmitAsync(purchase);

            var response = await service.CancelAsync(Purchases.Builder()
                .Status("CANCELLED")
                .Id(purchase.Id())
                .Build());

            Assert.AreEqual(response.Status(), "CANCELLED");
        }

        // Lookup a purchase

        [Test]
        public void When_I_lookup_an_eft_purchase_using_an_id_Then_it_should_return_a_valid_eft_purchase_sync()
        {
            var service = SampleFactory.CreateSampleEftDirectDebitService();

            var purchase = SampleFactory.CreateSampleEftPurchase();
            purchase = service.Submit(purchase);

            var returnedPurchase = service.Get(Purchases.Builder()
                                                        .Id(purchase.Id())
                                                        .Build());

            Assert.IsTrue(PurchasesAreEquivalent(purchase, returnedPurchase));
        }

        [Test]
        public async Task When_I_lookup_an_eft_purchase_using_an_id_Then_it_should_return_a_valid_eft_purchase_async()
        {
            var service = SampleFactory.CreateSampleEftDirectDebitService();

            var purchase = SampleFactory.CreateSampleEftPurchase();
            purchase = await service.SubmitAsync(purchase);

            var returnedPurchase = await service.GetAsync(Purchases.Builder()
                                                                   .Id(purchase.Id())
                                                                   .Build());

            Assert.IsTrue(PurchasesAreEquivalent(purchase, returnedPurchase));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_lookup_an_ach_purchase_using_an_id_Then_it_should_return_a_valid_ach_purchase_sync()
        {
            var service = SampleFactory.CreateSampleAchDirectDebitService();

            var purchase = SampleFactory.CreateSampleAchPurchase();
            purchase = service.Submit(purchase);

            var returnedPurchase = service.Get(Purchases.Builder()
                                                        .Id(purchase.Id())
                                                        .Build());

            Assert.IsTrue(PurchasesAreEquivalent(purchase, returnedPurchase));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_lookup_an_ach_purchase_using_an_id_Then_it_should_return_a_valid_ach_purchase_async()
        {
            var service = SampleFactory.CreateSampleAchDirectDebitService();

            var purchase = SampleFactory.CreateSampleAchPurchase();
            purchase = await service.SubmitAsync(purchase);

            var returnedPurchase = await service.GetAsync(Purchases.Builder()
                                                                   .Id(purchase.Id())
                                                                   .Build());

            Assert.IsTrue(PurchasesAreEquivalent(purchase, returnedPurchase));
        }

        [Test]
        public void When_I_lookup_an_eft_purchase_using_a_merchant_refnum_Then_it_should_return_a_valid_eft_purchase_sync()
        {
            var service = SampleFactory.CreateSampleEftDirectDebitService();

            var purchase = SampleFactory.CreateSampleEftPurchase();
            purchase = service.Submit(purchase);

            var returnedPurchase = service.GetPurchase(Purchases.Builder()
                .MerchantRefNum(purchase.MerchantRefNum())
                .Build());

            var result = returnedPurchase.GetResults();

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(PurchasesAreEquivalent(purchase, result.First()));
        }

        [Test]
        public async Task When_I_lookup_an_eft_purchase_using_a_merchant_refnum_Then_it_should_return_a_valid_eft_purchase_async()
        {
            var service = SampleFactory.CreateSampleEftDirectDebitService();

            var purchase = SampleFactory.CreateSampleEftPurchase();
            purchase = await service.SubmitAsync(purchase);

            var returnedPurchase = await service.GetPurchaseAsync(Purchases.Builder()
                                                                           .MerchantRefNum(purchase.MerchantRefNum())
                                                                           .Build());
            var result = returnedPurchase.GetResults();

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(PurchasesAreEquivalent(purchase, result.First()));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_lookup_an_ach_purchase_using_a_mercahnt_refnum_Then_it_should_return_a_valid_ach_purchase_sync()
        {
            var service = SampleFactory.CreateSampleAchDirectDebitService();

            var purchase = SampleFactory.CreateSampleAchPurchase();
            purchase = service.Submit(purchase);

            var returnedPurchase = service.GetPurchase(Purchases.Builder()
                .MerchantRefNum(purchase.MerchantRefNum())
                .Build());
            var result = returnedPurchase.GetResults();

            Assert.AreEqual(result.Count, 1);
            Assert.IsTrue(PurchasesAreEquivalent(purchase, result.First()));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_lookup_an_ach_purchase_using_a_mercahnt_refnum_Then_it_should_return_a_valid_ach_purchase_async()
        {
            var service = SampleFactory.CreateSampleAchDirectDebitService();

            var purchase = SampleFactory.CreateSampleAchPurchase();
            purchase = await service.SubmitAsync(purchase);

            var returnedPurchase = await service.GetPurchaseAsync(Purchases.Builder()
                .MerchantRefNum(purchase.MerchantRefNum())
                .Build());
            var result = returnedPurchase.GetResults();

            Assert.AreEqual(result.Count, 1);
            Assert.IsTrue(PurchasesAreEquivalent(purchase, result.First()));
        }

        /*
         * Direct Debit Standalone Credits
         */

        // Process a Standalone credit

        [Test]
        public void When_I_process_an_eft_standalone_credit_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleEftDirectDebitService();
            var standaloneCredit = SampleFactory.CreateSampleEftStandaloneCredits();

            var response = service.Submit(standaloneCredit);

            Assert.AreEqual(response.Status(), "COMPLETED");
        }

        [Test]
        public async Task When_I_process_an_eft_standalone_credit_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleEftDirectDebitService();
            var standaloneCredit = SampleFactory.CreateSampleEftStandaloneCredits();

            var response = await service.SubmitAsync(standaloneCredit);

            Assert.AreEqual(response.Status(), "COMPLETED");
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_process_an_ach_standalone_credit_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleAchDirectDebitService();
            var standaloneCredit = SampleFactory.CreateSampleAchStandaloneCredits();

            var response = service.Submit(standaloneCredit);

            Assert.AreEqual(response.Status(), "COMPLETED");
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_process_an_ach_standalone_credit_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleAchDirectDebitService();
            var standaloneCredit = SampleFactory.CreateSampleAchStandaloneCredits();

            var response = await service.SubmitAsync(standaloneCredit);

            Assert.AreEqual(response.Status(), "COMPLETED");
        }

        [Test]
        public void When_I_process_an_eft_standalone_using_a_payment_token_credit_Then_it_should_return_a_valid_response_sync()
        {
            var directDebitService = SampleFactory.CreateSampleEftDirectDebitService();
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();

            var profile = SampleFactory.CreateSampleProfile();
            profile = vaultService.Create(profile);

            var address = SampleFactory.CreateSampleAddress(profile);
            address = vaultService.Create(address);

            var account = SampleFactory.CreatSampleEftBankAccount(profile, address);
            account = vaultService.Create(account);

            var response = directDebitService.Submit(StandaloneCredits.Builder()
                                                                      .MerchantRefNum(account.MerchantRefNum())
                                                                      .Amount(10038)
                                                                      .Eft()
                                                                          .PaymentToken(account.PaymentToken())
                                                                          .Done()
                                                                      .Build());

            Assert.AreEqual(response.Status(), "COMPLETED");
        }

        [Test]
        public async Task When_I_process_an_eft_standalone_using_a_payment_token_credit_Then_it_should_return_a_valid_response_async()
        {
            var directDebitService = SampleFactory.CreateSampleEftDirectDebitService();
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();

            var profile = SampleFactory.CreateSampleProfile();
            profile = await vaultService.CreateAsync(profile);

            var address = SampleFactory.CreateSampleAddress(profile);
            address = await vaultService.CreateAsync(address);

            var account = SampleFactory.CreatSampleEftBankAccount(profile, address);
            account = await vaultService.CreateAsync(account);

            var response = await directDebitService.SubmitAsync(StandaloneCredits.Builder()
                                                                                 .MerchantRefNum(account.MerchantRefNum())
                                                                                 .Amount(10038)
                                                                                 .Eft()
                                                                                     .PaymentToken(account.PaymentToken())
                                                                                     .Done()
                                                                                 .Build());

            Assert.AreEqual(response.Status(), "COMPLETED");
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_process_an_ach_standalone_using_a_payment_token_credit_Then_it_should_return_a_valid_response_sync()
        {
            var directDebitService = SampleFactory.CreateSampleAchDirectDebitService();
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();

            var profile = SampleFactory.CreateSampleProfile();
            profile = vaultService.Create(profile);

            var address = SampleFactory.CreateSampleAddress(profile);
            address = vaultService.Create(address);

            var account = SampleFactory.CreatSampleAchBankAccount(profile, address);
            account = vaultService.Create(account);

            var response = directDebitService.Submit(StandaloneCredits.Builder()
                                                                      .MerchantRefNum(account.MerchantRefNum())
                                                                      .Amount(10038)
                                                                      .Ach()
                                                                          .PayMethod("WEB")
                                                                          .PaymentToken(account.PaymentToken())
                                                                          .Done()
                                                                     .Build());

            Assert.AreEqual(response.Status(), "COMPLETED");
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_process_an_ach_standalone_using_a_payment_token_credit_Then_it_should_return_a_valid_response_async()
        {
            var directDebitService = SampleFactory.CreateSampleAchDirectDebitService();
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();

            var profile = SampleFactory.CreateSampleProfile();
            profile = await vaultService.CreateAsync(profile);

            var address = SampleFactory.CreateSampleAddress(profile);
            address = await vaultService.CreateAsync(address);

            var account = SampleFactory.CreatSampleAchBankAccount(profile, address);
            account = await vaultService.CreateAsync(account);

            var response = await directDebitService.SubmitAsync(StandaloneCredits.Builder()
                                                                                 .MerchantRefNum(account.MerchantRefNum())
                                                                                 .Amount(10038)
                                                                                 .Ach()
                                                                                     .PayMethod("WEB")
                                                                                     .PaymentToken(account.PaymentToken())
                                                                                     .Done()
                                                                                 .Build());

            Assert.AreEqual(response.Status(), "COMPLETED");
        }


        // Cancel a standalone credit

        [Test]
        public void When_I_cancel_an_eft_standalone_credit_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleEftDirectDebitService();
            var standaloneCredit = SampleFactory.CreateSampleEftStandaloneCredits();
            standaloneCredit = service.Submit(standaloneCredit);

            var response = service.Cancel(StandaloneCredits.Builder()
                                                           .Status("CANCELLED")
                                                           .Id(standaloneCredit.Id())
                                                           .Build());

            Assert.AreEqual(response.Status(), "CANCELLED");
        }

        [Test]
        public async Task When_I_cancel_an_eft_standalone_credit_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleEftDirectDebitService();
            var standaloneCredit = SampleFactory.CreateSampleEftStandaloneCredits();
            standaloneCredit = await service.SubmitAsync(standaloneCredit);

            var response = await service.CancelAsync(StandaloneCredits.Builder()
                                                                      .Status("CANCELLED")
                                                                      .Id(standaloneCredit.Id())
                                                                      .Build());

            Assert.AreEqual(response.Status(), "CANCELLED");
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_cancel_an_ach_standalone_credit_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleAchDirectDebitService();
            var standaloneCredit = SampleFactory.CreateSampleAchStandaloneCredits();
            standaloneCredit = service.Submit(standaloneCredit);

            var response = service.Cancel(StandaloneCredits.Builder()
                .Status("CANCELLED")
                .Id(standaloneCredit.Id())
                .Build());

            Assert.AreEqual(response.Status(), "CANCELLED");
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_cancel_an_ach_standalone_credit_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleAchDirectDebitService();
            var standaloneCredit = SampleFactory.CreateSampleAchStandaloneCredits();
            standaloneCredit = await service.SubmitAsync(standaloneCredit);

            var response = await service.CancelAsync(StandaloneCredits.Builder()
                .Status("CANCELLED")
                .Id(standaloneCredit.Id())
                .Build());

            Assert.AreEqual(response.Status(), "CANCELLED");
        }

        // Lookup a standalone credit

        [Test]
        public void When_I_lookup_an_eft_standalone_credit_using_an_id_Then_it_should_return_a_valid_eft_standalone_credit_sync()
        {
            var service = SampleFactory.CreateSampleEftDirectDebitService();
            var standaloneCredit = SampleFactory.CreateSampleEftStandaloneCredits();
            standaloneCredit = service.Submit(standaloneCredit);

            var returnedStandaloneCredit = service.Get(StandaloneCredits.Builder()
                                                  .Id(standaloneCredit.Id())
                                                  .Build());

            Assert.IsTrue(StandaloneCrditsAreEquivalent(standaloneCredit, returnedStandaloneCredit));
        }

        [Test]
        public async Task When_I_lookup_an_eft_standalone_credit_using_an_id_Then_it_should_return_a_valid_eft_standalone_credit_async()
        {
            var service = SampleFactory.CreateSampleEftDirectDebitService();
            var standaloneCredit = SampleFactory.CreateSampleEftStandaloneCredits();
            standaloneCredit = await service.SubmitAsync(standaloneCredit);

            var returnedStandaloneCredit = await service.GetAsync(StandaloneCredits.Builder()
                                                        .Id(standaloneCredit.Id())
                                                        .Build());

            Assert.IsTrue(StandaloneCrditsAreEquivalent(standaloneCredit, returnedStandaloneCredit));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_lookup_an_ach_standalone_credit_using_an_id_Then_it_should_return_a_valid_ach_standalone_credit_sync()
        {
            var service = SampleFactory.CreateSampleAchDirectDebitService();
            var standaloneCredit = SampleFactory.CreateSampleAchStandaloneCredits();
            standaloneCredit = service.Submit(standaloneCredit);

            var returnedStandaloneCredit = service.Get(StandaloneCredits.Builder()
                                                  .Id(standaloneCredit.Id())
                                                  .Build());

            Assert.IsTrue(StandaloneCrditsAreEquivalent(standaloneCredit, returnedStandaloneCredit));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_lookup_an_ach_standalone_using_an_id_credit_Then_it_should_return_a_valid_ach_standalone_credit_async()
        {
            var service = SampleFactory.CreateSampleAchDirectDebitService();
            var standaloneCredit = SampleFactory.CreateSampleAchStandaloneCredits();
            standaloneCredit = await service.SubmitAsync(standaloneCredit);

            var returnedStandaloneCredit = await service.GetAsync(StandaloneCredits.Builder()
                                                        .Id(standaloneCredit.Id())
                                                        .Build());

            Assert.IsTrue(StandaloneCrditsAreEquivalent(standaloneCredit, returnedStandaloneCredit));
        }

        [Test]
        public void When_I_lookup_an_eft_standalone_credit_using_a_merchant_refnum_Then_it_should_return_a_valid_eft_standalone_credit_sync()
        {
            var service = SampleFactory.CreateSampleEftDirectDebitService();
            var standaloneCredit = SampleFactory.CreateSampleEftStandaloneCredits();
            standaloneCredit = service.Submit(standaloneCredit);

            var returnedStandaloneCredit = service.GetStandaloneCredits(StandaloneCredits.Builder()
                                                                                         .MerchantRefNum(standaloneCredit.MerchantRefNum())
                                                                                         .Build());

            var result = returnedStandaloneCredit.GetResults();

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(StandaloneCrditsAreEquivalent(standaloneCredit, result.First()));
        }

        [Test]
        public async Task When_I_lookup_an_eft_standalone_credit_using_a_merchant_refnum_Then_it_should_return_a_valid_eft_standalone_credit_async()
        {
            var service = SampleFactory.CreateSampleEftDirectDebitService();
            var standaloneCredit = SampleFactory.CreateSampleEftStandaloneCredits();
            standaloneCredit = await service.SubmitAsync(standaloneCredit);

            var returnedStandaloneCredit = await service.GetStandaloneCreditsAsync(StandaloneCredits.Builder()
                .MerchantRefNum(standaloneCredit.MerchantRefNum())
                .Build());

            var result = returnedStandaloneCredit.GetResults();

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(StandaloneCrditsAreEquivalent(standaloneCredit, result.First()));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_lookup_an_ach_standalone_credit_using_a_merchant_refnum_Then_it_should_return_a_valid_ach_standalone_credit_sync()
        {
            var service = SampleFactory.CreateSampleAchDirectDebitService();
            var standaloneCredit = SampleFactory.CreateSampleAchStandaloneCredits();
            standaloneCredit = service.Submit(standaloneCredit);

            var returnedStandaloneCredit = service.GetStandaloneCredits(StandaloneCredits.Builder()
                                                                                         .MerchantRefNum(standaloneCredit.MerchantRefNum())
                                                                                         .Build());

            var result = returnedStandaloneCredit.GetResults();

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(StandaloneCrditsAreEquivalent(standaloneCredit, result.First()));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_lookup_an_ach_standalone_using_a_merchant_refnum_credit_Then_it_should_return_a_valid_ach_standalone_credit_async()
        {
            var service = SampleFactory.CreateSampleAchDirectDebitService();
            var standaloneCredit = SampleFactory.CreateSampleAchStandaloneCredits();
            standaloneCredit = await service.SubmitAsync(standaloneCredit);

            var returnedStandaloneCredit = await service.GetStandaloneCreditsAsync(StandaloneCredits.Builder()
                                                                                                    .MerchantRefNum(standaloneCredit.MerchantRefNum())
                                                                                                    .Build());

            var result = returnedStandaloneCredit.GetResults();

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(StandaloneCrditsAreEquivalent(standaloneCredit, result.First()));
        }

        /*
         * Helpers
         */
        private bool PurchasesAreEquivalent(Purchases pur1, Purchases pur2)
        {
            if (!pur1.Id().Equals(pur2.Id())
                || !pur1.CustomerIp().Equals(pur2.CustomerIp())
                || !pur1.MerchantRefNum().Equals(pur2.MerchantRefNum())
                || !pur1.Status().Equals(pur2.Status())
                || !ProfilesAreEquivalent(pur1.Profile(), pur2.Profile())
                || !BillingDetailsAreEquivalent(pur1.BillingDetails(), pur2.BillingDetails()))
            {
                return false;
            }

            return true;
        }

        private bool ProfilesAreEquivalent(Profile profile1, Profile profile2)
        {
            if (!profile1.FirstName().Equals(profile2.FirstName())
                || !profile1.LastName().Equals(profile2.LastName())
                || !profile1.Email().Equals(profile2.Email()))
            {
                return false;
            }

            return true;
        }
        private bool BillingDetailsAreEquivalent(BillingDetails bil1, BillingDetails bil2)
        {
            if (!bil1.Street().Equals(bil2.Street())
                || !bil1.City().Equals(bil2.City())
                || !bil1.Country().Equals(bil2.Country())
                || !bil1.State().Equals(bil2.State())
                || !bil1.Zip().Equals(bil2.Zip())
                || !bil1.Phone().Equals(bil2.Phone()))
            {
                return false;
            }

            return true;
        }

        private bool StandaloneCrditsAreEquivalent(StandaloneCredits credit1, StandaloneCredits credit2)
        {
            if (!credit1.Id().Equals(credit2.Id())
                || !credit1.Status().Equals(credit2.Status())
                || !credit1.Amount().Equals(credit2.Amount())
                || !credit1.CustomerIp().Equals(credit2.CustomerIp())
                || !credit1.MerchantRefNum().Equals(credit2.MerchantRefNum())
                || !ProfilesAreEquivalent(credit1.Profile(), credit2.Profile())
                || !BillingDetailsAreEquivalent(credit1.BillingDetails(), credit2.BillingDetails()))
            {
                return false;
            }

            return true;
        }
    }
}
