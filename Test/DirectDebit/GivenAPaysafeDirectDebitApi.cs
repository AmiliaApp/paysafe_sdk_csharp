using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Paysafe.DirectDebit;
using Profile = Paysafe.DirectDebit.Profile;
using BillingDetails = Paysafe.DirectDebit.BillingDetails;

namespace Tests.DirectDebit
/*
* Is not covered by tests:
* -Process a BACS purchase using a payment token
* -Process a SEPA purchase using a payment token
* -Process a BACS standalone credit using a payment token
*/

{
    class GivenAPaysafeDirectDebitApi
    {

        private DirectDebitService _achDirectDebitService;
        private Purchases _achPurchase;

        private DirectDebitService _eftDirectDebitService;
        private Purchases _eftPurchase;

        private StandaloneCredits _standaloneCredit;

        [SetUp]
        public void Init()
        {
            _achDirectDebitService = SampleFactory.CreateSampleAchDirectDebitService();
            _achPurchase = SampleFactory.CreateSampleAchPurchase();

            _eftDirectDebitService = SampleFactory.CreateSampleEftDirectDebitService();
            _eftPurchase = SampleFactory.CreateSampleEftPurchase();

            _standaloneCredit = SampleFactory.CreateSampleEftStandaloneCredits();
        }

        /*
        * Monitor
        */

        [Test]
        public void Eft_card_payment_api_Should_be_up_sync()
        {
            bool status = _eftDirectDebitService.Monitor();
            Assert.That(status, Is.True);
        }

        [Test]
        public async Task Eft_card_payment_api_Should_be_up_async()
        {
            bool status = await _eftDirectDebitService.MonitorAsync();
            Assert.That(status, Is.True);
        }

        [Test]
        public void Ach_card_payment_api_Should_be_up_sync()
        {
            bool status = _achDirectDebitService.Monitor();
            Assert.That(status, Is.True);
        }

        [Test]
        public async Task Ach_card_payment_api_Should_be_up_async()
        {
            bool status = await _achDirectDebitService.MonitorAsync();
            Assert.That(status, Is.True);
        }

        /*
         * Direct Debit Purchases
         */

        // Process a purchase
        [Test]
        public void When_I_process_an_eft_purchase_Then_it_should_return_a_valid_response_sync()
        {
            Purchases response = _eftDirectDebitService.Submit(_eftPurchase);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public async Task When_I_process_an_eft_purchase_Then_it_should_return_a_valid_response_async()
        {
            Purchases response = await _eftDirectDebitService.SubmitAsync(_eftPurchase);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_process_an_ach_purchase_Then_it_should_return_a_valid_response_sync()
        {
            Purchases response = _achDirectDebitService.Submit(_achPurchase);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_process_an_ach_purchase_Then_it_should_return_a_valid_response_async()
        {
            Purchases response = await _achDirectDebitService.SubmitAsync(_achPurchase);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public void When_I_process_an_eft_purchase_using_a_token_Then_it_should_return_a_valid_response_sync()
        {
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();

            var profile = SampleFactory.CreateSampleProfile();
            profile = vaultService.Create(profile);

            var address = SampleFactory.CreateSampleAddress(profile);
            address = vaultService.Create(address);

            var account = SampleFactory.CreatSampleEftBankAccount(profile, address);
            account = vaultService.Create(account);

            Purchases response = _eftDirectDebitService.Submit(Purchases.Builder()
                                                                    .MerchantRefNum(System.Guid.NewGuid().ToString())
                                                                    .Amount(10038)
                                                                    .Eft()
                                                                        .PaymentToken(account.PaymentToken())
                                                                        .Done()
                                                                    .Build());

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public async Task When_I_process_an_eft_purchase_using_a_token_Then_it_should_return_a_valid_response_async()
        {
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();

            var profile = SampleFactory.CreateSampleProfile();
            profile = await vaultService.CreateAsync(profile);

            var address = SampleFactory.CreateSampleAddress(profile);
            address = await vaultService.CreateAsync(address);

            var account = SampleFactory.CreatSampleEftBankAccount(profile, address);
            account = await vaultService.CreateAsync(account);

            Purchases response = await _eftDirectDebitService.SubmitAsync(Purchases.Builder()
                                                                               .MerchantRefNum(System.Guid.NewGuid().ToString())
                                                                               .Amount(10038)
                                                                               .Eft()
                                                                                   .PaymentToken(account.PaymentToken())
                                                                                   .Done()
                                                                               .Build());

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_process_an_ach_purchase_using_a_token_Then_it_should_return_a_valid_response_sync()
        {
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();

            var profile = SampleFactory.CreateSampleProfile();
            profile = vaultService.Create(profile);

            var address = SampleFactory.CreateSampleAddress(profile);
            address = vaultService.Create(address);

            var account = SampleFactory.CreatSampleEftBankAccount(profile, address);
            account = vaultService.Create(account);

            Purchases response = _achDirectDebitService.Submit(Purchases.Builder()
                                                                    .MerchantRefNum(System.Guid.NewGuid().ToString())
                                                                    .Amount(10038)
                                                                    .Ach()
                                                                        .PaymentToken(account.PaymentToken())
                                                                        .Done()
                                                                    .Build());

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_process_an_ach_purchase_using_a_token_Then_it_should_return_a_valid_response_async()
        {
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();

            var profile = SampleFactory.CreateSampleProfile();
            profile = await vaultService.CreateAsync(profile);

            var address = SampleFactory.CreateSampleAddress(profile);
            address = await vaultService.CreateAsync(address);

            var account = SampleFactory.CreatSampleEftBankAccount(profile, address);
            account = await vaultService.CreateAsync(account);

            Purchases response = await _achDirectDebitService.SubmitAsync(Purchases.Builder()
                                                                               .MerchantRefNum(System.Guid.NewGuid().ToString())
                                                                               .Amount(10038)
                                                                               .Ach()
                                                                                   .PaymentToken(account.PaymentToken())
                                                                                   .Done()
                                                                               .Build());

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        // Cancel a purchase

        [Test]
        public void When_I_cancel_an_eft_purchase_Then_it_should_return_a_valid_response_sync()
        {
            _eftPurchase = _eftDirectDebitService.Submit(_eftPurchase);

            var response = _eftDirectDebitService.Cancel(Purchases.Builder()
                                                   .Status("CANCELLED")
                                                   .Id(_eftPurchase.Id())
                                                   .Build());

            Assert.That(response.Status(), Is.EqualTo("CANCELLED"));
        }

        [Test]
        public async Task When_I_cancel_an_eft_purchase_Then_it_should_return_a_valid_response_async()
        {
            _eftPurchase = await _eftDirectDebitService.SubmitAsync(_eftPurchase);

            var response = await _eftDirectDebitService.CancelAsync(Purchases.Builder()
                                                              .Status("CANCELLED")
                                                              .Id(_eftPurchase.Id())
                                                              .Build());

            Assert.That(response.Status(), Is.EqualTo("CANCELLED"));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_cancel_an_ach_purchase_Then_it_should_return_a_valid_response_sync()
        {
            _achPurchase = _achDirectDebitService.Submit(_achPurchase);

            var response = _achDirectDebitService.Cancel(Purchases.Builder()
                .Status("CANCELLED")
                .Id(_achPurchase.Id())
                .Build());

            Assert.That(response.Status(), Is.EqualTo("CANCELLED"));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_cancel_an_ach_purchase_Then_it_should_return_a_valid_response_async()
        {
            _achPurchase = await _achDirectDebitService.SubmitAsync(_achPurchase);

            var response = await _achDirectDebitService.CancelAsync(Purchases.Builder()
                .Status("CANCELLED")
                .Id(_achPurchase.Id())
                .Build());

            Assert.That(response.Status(), Is.EqualTo("CANCELLED"));
        }

        // Lookup a purchase

        [Test]
        public void When_I_lookup_an_eft_purchase_using_an_id_Then_it_should_return_a_valid_eft_purchase_sync()
        {
            _eftPurchase = _eftDirectDebitService.Submit(_eftPurchase);

            var returnedPurchase = _eftDirectDebitService.Get(Purchases.Builder()
                                                        .Id(_eftPurchase.Id())
                                                        .Build());

            Assert.That(PurchasesAreEquivalent(_eftPurchase, returnedPurchase));
        }

        [Test]
        public async Task When_I_lookup_an_eft_purchase_using_an_id_Then_it_should_return_a_valid_eft_purchase_async()
        {
            _eftPurchase = await _eftDirectDebitService.SubmitAsync(_eftPurchase);

            var returnedPurchase = await _eftDirectDebitService.GetAsync(Purchases.Builder()
                                                                   .Id(_eftPurchase.Id())
                                                                   .Build());

            Assert.That(PurchasesAreEquivalent(_eftPurchase, returnedPurchase));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_lookup_an_ach_purchase_using_an_id_Then_it_should_return_a_valid_ach_purchase_sync()
        {
           _achPurchase = _achDirectDebitService.Submit(_achPurchase);

            var returnedPurchase = _achDirectDebitService.Get(Purchases.Builder()
                                                        .Id(_achPurchase.Id())
                                                        .Build());

            Assert.That(PurchasesAreEquivalent(_achPurchase, returnedPurchase));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_lookup_an_ach_purchase_using_an_id_Then_it_should_return_a_valid_ach_purchase_async()
        {
            _achPurchase = await _achDirectDebitService.SubmitAsync(_achPurchase);

            var returnedPurchase = await _achDirectDebitService.GetAsync(Purchases.Builder()
                                                                   .Id(_achPurchase.Id())
                                                                   .Build());

            Assert.That(PurchasesAreEquivalent(_achPurchase, returnedPurchase));
        }

        // Fail: Sometimes returns empty results
        [Test]
        public void When_I_lookup_an_eft_purchase_using_a_merchant_refnum_Then_it_should_return_a_valid_eft_purchase_sync()
        {
            _eftPurchase = _eftDirectDebitService.Submit(_eftPurchase);

            var returnedPurchase = _eftDirectDebitService.GetPurchase(Purchases.Builder()
                .MerchantRefNum(_eftPurchase.MerchantRefNum())
                .Build());

            var result = returnedPurchase.GetResults();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(PurchasesAreEquivalent(_eftPurchase, result.First()));
        }

        // Fail: Sometimes returns empty results
        [Test]
        public async Task When_I_lookup_an_eft_purchase_using_a_merchant_refnum_Then_it_should_return_a_valid_eft_purchase_async()
        {
            _eftPurchase = await _eftDirectDebitService.SubmitAsync(_eftPurchase);

            var returnedPurchase = await _eftDirectDebitService.GetPurchaseAsync(Purchases.Builder()
                                                                                          .MerchantRefNum(_eftPurchase.MerchantRefNum())
                                                                                          .Build());
            var result = returnedPurchase.GetResults();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(PurchasesAreEquivalent(_eftPurchase, result.First()));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_lookup_an_ach_purchase_using_a_mercahnt_refnum_Then_it_should_return_a_valid_ach_purchase_sync()
        {
            _achPurchase = _achDirectDebitService.Submit(_achPurchase);

            var returnedPurchase = _achDirectDebitService.GetPurchase(Purchases.Builder()
                .MerchantRefNum(_achPurchase.MerchantRefNum())
                .Build());
            var result = returnedPurchase.GetResults();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(PurchasesAreEquivalent(_achPurchase, result.First()));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_lookup_an_ach_purchase_using_a_mercahnt_refnum_Then_it_should_return_a_valid_ach_purchase_async()
        {
            _achPurchase = await _achDirectDebitService.SubmitAsync(_achPurchase);

            var returnedPurchase = await _achDirectDebitService.GetPurchaseAsync(Purchases.Builder()
                .MerchantRefNum(_achPurchase.MerchantRefNum())
                .Build());
            var result = returnedPurchase.GetResults();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(PurchasesAreEquivalent(_achPurchase, result.First()));
        }

        /*
         * Direct Debit Standalone Credits
         */

        // Process a Standalone credit

        [Test]
        public void When_I_process_an_eft_standalone_credit_Then_it_should_return_a_valid_response_sync()
        {
            var response = _eftDirectDebitService.Submit(_standaloneCredit);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public async Task When_I_process_an_eft_standalone_credit_Then_it_should_return_a_valid_response_async()
        {
            var response = await _eftDirectDebitService.SubmitAsync(_standaloneCredit);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_process_an_ach_standalone_credit_Then_it_should_return_a_valid_response_sync()
        {
            var response = _achDirectDebitService.Submit(_standaloneCredit);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_process_an_ach_standalone_credit_Then_it_should_return_a_valid_response_async()
        {
            var response = await _achDirectDebitService.SubmitAsync(_standaloneCredit);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public void When_I_process_an_eft_standalone_using_a_payment_token_credit_Then_it_should_return_a_valid_response_sync()
        {
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();

            var profile = SampleFactory.CreateSampleProfile();
            profile = vaultService.Create(profile);

            var address = SampleFactory.CreateSampleAddress(profile);
            address = vaultService.Create(address);

            var account = SampleFactory.CreatSampleEftBankAccount(profile, address);
            account = vaultService.Create(account);

            var response = _eftDirectDebitService.Submit(StandaloneCredits.Builder()
                                                                      .MerchantRefNum(account.MerchantRefNum())
                                                                      .Amount(10038)
                                                                      .Eft()
                                                                          .PaymentToken(account.PaymentToken())
                                                                          .Done()
                                                                      .Build());

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public async Task When_I_process_an_eft_standalone_using_a_payment_token_credit_Then_it_should_return_a_valid_response_async()
        {
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();

            var profile = SampleFactory.CreateSampleProfile();
            profile = await vaultService.CreateAsync(profile);

            var address = SampleFactory.CreateSampleAddress(profile);
            address = await vaultService.CreateAsync(address);

            var account = SampleFactory.CreatSampleEftBankAccount(profile, address);
            account = await vaultService.CreateAsync(account);

            var response = await _eftDirectDebitService.SubmitAsync(StandaloneCredits.Builder()
                                                                                 .MerchantRefNum(account.MerchantRefNum())
                                                                                 .Amount(10038)
                                                                                 .Eft()
                                                                                     .PaymentToken(account.PaymentToken())
                                                                                     .Done()
                                                                                 .Build());

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_process_an_ach_standalone_using_a_payment_token_credit_Then_it_should_return_a_valid_response_sync()
        {
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();

            var profile = SampleFactory.CreateSampleProfile();
            profile = vaultService.Create(profile);

            var address = SampleFactory.CreateSampleAddress(profile);
            address = vaultService.Create(address);

            var account = SampleFactory.CreatSampleAchBankAccount(profile, address);
            account = vaultService.Create(account);

            var response = _achDirectDebitService.Submit(StandaloneCredits.Builder()
                                                                      .MerchantRefNum(account.MerchantRefNum())
                                                                      .Amount(10038)
                                                                      .Ach()
                                                                          .PayMethod("WEB")
                                                                          .PaymentToken(account.PaymentToken())
                                                                          .Done()
                                                                     .Build());

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_process_an_ach_standalone_using_a_payment_token_credit_Then_it_should_return_a_valid_response_async()
        {
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();

            var profile = SampleFactory.CreateSampleProfile();
            profile = await vaultService.CreateAsync(profile);

            var address = SampleFactory.CreateSampleAddress(profile);
            address = await vaultService.CreateAsync(address);

            var account = SampleFactory.CreatSampleAchBankAccount(profile, address);
            account = await vaultService.CreateAsync(account);

            var response = await _achDirectDebitService.SubmitAsync(StandaloneCredits.Builder()
                                                                                 .MerchantRefNum(account.MerchantRefNum())
                                                                                 .Amount(10038)
                                                                                 .Ach()
                                                                                     .PayMethod("WEB")
                                                                                     .PaymentToken(account.PaymentToken())
                                                                                     .Done()
                                                                                 .Build());

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }


        // Cancel a standalone credit

        [Test]
        public void When_I_cancel_an_eft_standalone_credit_Then_it_should_return_a_valid_response_sync()
        {
            _standaloneCredit = _eftDirectDebitService.Submit(_standaloneCredit);

            var response = _eftDirectDebitService.Cancel(StandaloneCredits.Builder()
                                                           .Status("CANCELLED")
                                                           .Id(_standaloneCredit.Id())
                                                           .Build());

            Assert.That(response.Status(), Is.EqualTo("CANCELLED"));
        }

        [Test]
        public async Task When_I_cancel_an_eft_standalone_credit_Then_it_should_return_a_valid_response_async()
        {
            _standaloneCredit = await _eftDirectDebitService.SubmitAsync(_standaloneCredit);

            var response = await _eftDirectDebitService.CancelAsync(StandaloneCredits.Builder()
                                                                      .Status("CANCELLED")
                                                                      .Id(_standaloneCredit.Id())
                                                                      .Build());

            Assert.That(response.Status(), Is.EqualTo("CANCELLED"));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_cancel_an_ach_standalone_credit_Then_it_should_return_a_valid_response_sync()
        {
            _standaloneCredit = _achDirectDebitService.Submit(_standaloneCredit);

            var response = _achDirectDebitService.Cancel(StandaloneCredits.Builder()
                .Status("CANCELLED")
                .Id(_standaloneCredit.Id())
                .Build());

            Assert.That(response.Status(), Is.EqualTo("CANCELLED"));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_cancel_an_ach_standalone_credit_Then_it_should_return_a_valid_response_async()
        {
            _standaloneCredit = await _achDirectDebitService.SubmitAsync(_standaloneCredit);

            var response = await _achDirectDebitService.CancelAsync(StandaloneCredits.Builder()
                .Status("CANCELLED")
                .Id(_standaloneCredit.Id())
                .Build());

            Assert.That(response.Status(), Is.EqualTo("CANCELLED"));
        }

        // Lookup a standalone credit

        [Test]
        public void When_I_lookup_an_eft_standalone_credit_using_an_id_Then_it_should_return_a_valid_eft_standalone_credit_sync()
        {
            _standaloneCredit = _eftDirectDebitService.Submit(_standaloneCredit);

            var returnedStandaloneCredit = _eftDirectDebitService.Get(StandaloneCredits.Builder()
                                                  .Id(_standaloneCredit.Id())
                                                  .Build());

            Assert.That(StandaloneCrditsAreEquivalent(_standaloneCredit, returnedStandaloneCredit));
        }

        [Test]
        public async Task When_I_lookup_an_eft_standalone_credit_using_an_id_Then_it_should_return_a_valid_eft_standalone_credit_async()
        {
            _standaloneCredit = await _eftDirectDebitService.SubmitAsync(_standaloneCredit);

            var returnedStandaloneCredit = await _eftDirectDebitService.GetAsync(StandaloneCredits.Builder()
                                                        .Id(_standaloneCredit.Id())
                                                        .Build());

            Assert.That(StandaloneCrditsAreEquivalent(_standaloneCredit, returnedStandaloneCredit));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_lookup_an_ach_standalone_credit_using_an_id_Then_it_should_return_a_valid_ach_standalone_credit_sync()
        {
            _standaloneCredit = _achDirectDebitService.Submit(_standaloneCredit);

            var returnedStandaloneCredit = _achDirectDebitService.Get(StandaloneCredits.Builder()
                                                  .Id(_standaloneCredit.Id())
                                                  .Build());

            Assert.That(StandaloneCrditsAreEquivalent(_standaloneCredit, returnedStandaloneCredit));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_lookup_an_ach_standalone_using_an_id_credit_Then_it_should_return_a_valid_ach_standalone_credit_async()
        {
            _standaloneCredit = await _achDirectDebitService.SubmitAsync(_standaloneCredit);

            var returnedStandaloneCredit = await _achDirectDebitService.GetAsync(StandaloneCredits.Builder()
                                                        .Id(_standaloneCredit.Id())
                                                        .Build());

            Assert.That(StandaloneCrditsAreEquivalent(_standaloneCredit, returnedStandaloneCredit));
        }

        // Fail: Sometimes returns empty results
        [Test]
        public void When_I_lookup_an_eft_standalone_credit_using_a_merchant_refnum_Then_it_should_return_a_valid_eft_standalone_credit_sync()
        {
            _standaloneCredit = _eftDirectDebitService.Submit(_standaloneCredit);

            var returnedStandaloneCredit = _eftDirectDebitService.GetStandaloneCredits(StandaloneCredits.Builder()
                                                                                         .MerchantRefNum(_standaloneCredit.MerchantRefNum())
                                                                                         .Build());

            var result = returnedStandaloneCredit.GetResults();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(StandaloneCrditsAreEquivalent(_standaloneCredit, result.First()));
        }

        // Fail: Sometimes returns empty results
        [Test]
        public async Task When_I_lookup_an_eft_standalone_credit_using_a_merchant_refnum_Then_it_should_return_a_valid_eft_standalone_credit_async()
        {
            _standaloneCredit = await _eftDirectDebitService.SubmitAsync(_standaloneCredit);

            var returnedStandaloneCredit = await _eftDirectDebitService.GetStandaloneCreditsAsync(StandaloneCredits.Builder()
                .MerchantRefNum(_standaloneCredit.MerchantRefNum())
                .Build());

            var result = returnedStandaloneCredit.GetResults();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(StandaloneCrditsAreEquivalent(_standaloneCredit, result.First()));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public void When_I_lookup_an_ach_standalone_credit_using_a_merchant_refnum_Then_it_should_return_a_valid_ach_standalone_credit_sync()
        {
            _standaloneCredit = _achDirectDebitService.Submit(_standaloneCredit);

            var returnedStandaloneCredit = _achDirectDebitService.GetStandaloneCredits(StandaloneCredits.Builder()
                                                                                         .MerchantRefNum(_standaloneCredit.MerchantRefNum())
                                                                                         .Build());

            var result = returnedStandaloneCredit.GetResults();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(StandaloneCrditsAreEquivalent(_standaloneCredit, result.First()));
        }

        [Test]
        [Ignore("Currently causing internal server error")]
        public async Task When_I_lookup_an_ach_standalone_using_a_merchant_refnum_credit_Then_it_should_return_a_valid_ach_standalone_credit_async()
        {
            _standaloneCredit = await _achDirectDebitService.SubmitAsync(_standaloneCredit);

            var returnedStandaloneCredit = await _achDirectDebitService.GetStandaloneCreditsAsync(StandaloneCredits.Builder()
                                                                                                    .MerchantRefNum(_standaloneCredit.MerchantRefNum())
                                                                                                    .Build());

            var result = returnedStandaloneCredit.GetResults();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(StandaloneCrditsAreEquivalent(_standaloneCredit, result.First()));
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
