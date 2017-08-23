using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Paysafe;
using Paysafe.CardPayments;
using Authorization = Paysafe.CardPayments.Authorization;

namespace Tests.CardPayments

/*
 *Is not covered by tests:
 * -Approve a held authorization -> CardPaymentService.approveHeldAuth(Auth) (& async version)
 * -Cancel a held authorization -> CardPaymentService.cancelHeldAuth(Auth) (& async version)
 * -Refund a processed settlement -> CardPaymentService.Refund(Refund) (& async version)
 * -Look up a refund using a refund ID -> CardPaymentService.Get(new Refund(refund.id())) (& async version)
 * -Look up a refund using a merchant reference number ->CardPaymentService.GetRefunds(Refund.Builder().merchantRefNum(string).Build()) (& async)
 */
{
    [TestFixture]
    class GivenAPaysafeCardPaymentApi
    {
        private CardPaymentService cardService;
        private Authorization auth;

        [SetUp]
        public void Init()
        {
            cardService = SampleFactory.CreateSampleCardPaymentService();
            auth = SampleFactory.CreateSampleCustomAuthorization("noException");
        }

        /*
         * Authorize a Card Payment
         */

        [Test]
        public void When_I_send_a_valid_auth_Then_the_transaction_should_complete_synchronous()
        {
            var response = cardService.Authorize(auth);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public async Task When_I_send_a_valid_auth_Then_the_transaction_should_complete_asynchronous()
        {
            var response = await cardService.AuthorizeAsync(auth);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public void When_I_process_a_complex_auth_Then_it_should_return_a_valid_response_sync()
        {
            var complexAuth = SampleFactory.CreateSampleComplexAuthorization();

            var response = cardService.Authorize(complexAuth);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public async Task When_I_process_a_complex_auth_Then_it_should_return_a_valid_response_async()
        {
            var complexAuth = SampleFactory.CreateSampleComplexAuthorization();

            var response =  await cardService.AuthorizeAsync(complexAuth);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public void When_I_lookup_an_auth_using_an_auth_id_Then_it_should_return_a_valid_auth_sync()
        {
            auth = cardService.Authorize(auth);

            var returnedAuth = cardService.Get(new Authorization(auth.Id()));

            Assert.IsTrue(returnedAuth.Status() == "COMPLETED");
            Assert.IsTrue(AuthorizationsAreEquivalent(auth, returnedAuth));
        }

        [Test]
        public async Task When_I_lookup_an_auth_using_an_auth_id_Then_it_should_return_a_valid_auth_async()
        {
            auth = await cardService.AuthorizeAsync(auth);

            var returnedAuth = await cardService.GetAsync(new Authorization(auth.Id()));

            Assert.IsTrue(returnedAuth.Status() == "COMPLETED");
            Assert.IsTrue(AuthorizationsAreEquivalent(auth, returnedAuth));
        }

        [Test]
        public void When_I_lookup_an_auth_using_a_merchant_refNum_Then_it_should_return_a_valid_auth_sync()
        {
            auth = cardService.Authorize(auth);

            Pagerator<Authorization> auths = cardService.GetAuths(Authorization.Builder()
                                                                                .MerchantRefNum(auth.MerchantRefNum())
                                                                                .Build());

            var authList = auths.GetResults();
            Assert.IsTrue(authList.Count == 1);
            Assert.IsTrue(AuthorizationsAreEquivalent(auth, authList[0]));
        }

        [Test]
        public async Task When_I_lookup_an_auth_using_a_merchant_refNum_Then_it_should_return_a_valid_auth_async()
        {
            auth = cardService.Authorize(auth);

            Pagerator<Authorization> auths = await cardService.GetAuthsAsync(Authorization.Builder()
                                                                                          .MerchantRefNum(auth.MerchantRefNum())
                                                                                          .Build());

            var authList = auths.GetResults();
            Assert.IsTrue(authList.Count == 1);
            Assert.IsTrue(AuthorizationsAreEquivalent(auth, authList[0]));
        }

        /*
         * Process a Card Purchase
         */
        [Test]
        public void When_I_process_a_valid_purchase_Then_it_should_return_a_valid_response_sync()
        {
            var settledAuth = SampleFactory.CreateSampleSettledAuthorization();

            var response = cardService.Authorize(settledAuth);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public async Task When_I_process_a_valid_purchase_Then_it_should_return_a_valid_response_async()
        {
            var settledAuth = SampleFactory.CreateSampleSettledAuthorization();

            var response = await cardService.AuthorizeAsync(settledAuth);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public void When_I_void_an_auth_Then_it_should_return_a_valid_response_sync()
        {
            auth = cardService.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(6666) // Amount voided == authorized amount
                .AuthorizationId(auth.Id())
                .Build();

            AuthorizationReversal response = cardService.ReverseAuth(authReversal);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public async Task When_I_void_an_auth_Then_it_should_return_a_valid_response_async()
        {
            auth = cardService.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(6666) //Amount voided == authorized amount
                .AuthorizationId(auth.Id())
                .Build();

            AuthorizationReversal response = await cardService.ReverseAuthAsync(authReversal);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public void When_I_partially_void_an_auth_Then_it_should_return_a_valid_response_sync()
        {
            auth = cardService.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(111) //Amount voided < authorized amount
                .AuthorizationId(auth.Id())
                .Build();

            AuthorizationReversal response = cardService.ReverseAuth(authReversal);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public async Task When_I_partially_void_an_auth_Then_it_should_return_a_valid_response_async()
        {
            auth = cardService.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(111) //Amount voided < authorized amount
                .AuthorizationId(auth.Id())
                .Build();

            AuthorizationReversal response = await cardService.ReverseAuthAsync(authReversal);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public void When_I_void_a_settled_auth_Then_it_should_return_throw_RequestDeclinedException_sync()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var settledAuth = SampleFactory.CreateSampleSettledAuthorization();

            settledAuth = service.Authorize(settledAuth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(6666) //Amount voided == authorized amount
                .AuthorizationId(settledAuth.Id())
                .Build();

            Assert.Throws<Paysafe.Common.RequestDeclinedException>(() => service.ReverseAuth(authReversal));
        }

        [Test]
        public void When_I_void_a_settled_auth_Then_it_should_return_throw_RequestDeclinedException_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var settledAuth = SampleFactory.CreateSampleSettledAuthorization();

            settledAuth = service.Authorize(settledAuth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(settledAuth.MerchantRefNum())
                .Amount(6666) //Amount voided == authorized amount
                .AuthorizationId(settledAuth.Id())
                .Build();

            Assert.ThrowsAsync<Paysafe.Common.RequestDeclinedException>(async () => await service.ReverseAuthAsync(authReversal));
        }

        [Test]
        public void When_I_void_an_auth_with_an_amount_too_large_Then_it_should_return_throw_RequestDeclinedException_sync()
        {
            auth = cardService.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(1000000) //Amount voided > authorized amount
                .AuthorizationId(auth.Id())
                .Build();

            Assert.Throws<Paysafe.Common.RequestDeclinedException>(() => cardService.ReverseAuth(authReversal));
        }

        [Test]
        public void When_I_void_an_auth_with_an_amount_too_large_Then_it_should_return_throw_RequestDeclinedException_async()
        {
            auth = cardService.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(1000000) //Amount voided > authorized amount
                .AuthorizationId(auth.Id())
                .Build();

            Assert.ThrowsAsync<Paysafe.Common.RequestDeclinedException>(async () => await cardService.ReverseAuthAsync(authReversal));
        }

        [Test]
        public void When_I_lookup_a_reversal_using_a_reversal_id_Then_it_should_return_a_valid_reversal_sync()
        {
            auth = cardService.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(6666)
                .AuthorizationId(auth.Id())
                .Build();

            authReversal = cardService.ReverseAuth(authReversal);

            AuthorizationReversal returnedReversal = cardService.Get(new AuthorizationReversal(authReversal.Id()));

            Assert.IsTrue(returnedReversal.Status() == "COMPLETED");
            Assert.IsTrue(AuthorizationReversalsAreEquivalent(authReversal, returnedReversal));
        }

        [Test]
        public async Task When_I_lookup_a_reversal_using_a_reversal_id_Then_it_should_return_a_valid_reversal_async()
        {
            auth = await cardService.AuthorizeAsync(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(6666)
                .AuthorizationId(auth.Id())
                .Build();

            authReversal = await cardService.ReverseAuthAsync(authReversal);

            AuthorizationReversal returnedReversal = await cardService.GetAsync(new AuthorizationReversal(authReversal.Id()));

            Assert.IsTrue(returnedReversal.Status() == "COMPLETED");
            Assert.IsTrue(AuthorizationReversalsAreEquivalent(authReversal, returnedReversal));
        }

        [Test]
        public void When_I_lookup_a_reversal_using_a_merchant_refNum_Then_it_should_return_a_valid_reversal_sync()
        {
            auth = cardService.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(6666)
                .AuthorizationId(auth.Id())
                .Build();

            authReversal = cardService.ReverseAuth(authReversal);

            Pagerator<AuthorizationReversal> authReversals = cardService.GetAuthReversals(AuthorizationReversal.Builder()
                .MerchantRefNum(authReversal.MerchantRefNum())
                .Build());


            var authRevList = authReversals.GetResults();
            Assert.IsTrue(authRevList.Count == 1);
            Assert.IsTrue(AuthorizationReversalsAreEquivalent(authReversal, authRevList[0]));
        }

        [Test]
        public async Task When_I_lookup_a_reversal_using_a_merchant_refNum_Then_it_should_return_a_valid_reversal_async()
        {
            auth = await cardService.AuthorizeAsync(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(6666)
                .AuthorizationId(auth.Id())
                .Build();

            authReversal = await cardService.ReverseAuthAsync(authReversal);

            Pagerator<AuthorizationReversal> authReversals = await cardService.GetAuthReversalsAsync(AuthorizationReversal.Builder()
                .MerchantRefNum(authReversal.MerchantRefNum())
                .Build());


            var authRevList = authReversals.GetResults();
            Assert.IsTrue(authRevList.Count == 1);
            Assert.IsTrue(AuthorizationReversalsAreEquivalent(authReversal, authRevList[0]));
        }

        /*
         * Settle a card authorization
         */

        [Test]
        public void When_I_settle_an_auth_Then_it_should_return_a_valid_response_sync()
        {
            auth = cardService.Authorize(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            Settlement response = cardService.Settlement(settle);

            Assert.IsTrue(response.Status() == "PENDING");
        }

        [Test]
        public async Task When_I_settle_an_auth_Then_it_should_return_a_valid_response_async()
        {
            auth = await cardService.AuthorizeAsync(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            Settlement response = await cardService.SettlementAsync(settle);

            Assert.IsTrue(response.Status() == "PENDING");
        }

        [Test]
        public void When_I_cancel_a_settlement_Then_it_should_return_a_valid_response_sync()
        {
            auth = cardService.Authorize(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            settle = cardService.Settlement(settle);

            Settlement response = cardService.CancelSettlement(settle);

            Assert.IsTrue(response.Status() == "CANCELLED");
        }

        // Failed once
        [Test]
        public async Task When_I_cancel_a_settlement_Then_it_should_return_a_valid_response_async()
        {
            auth = await cardService.AuthorizeAsync(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            settle = await cardService.SettlementAsync(settle);

            Settlement response = await cardService.CancelSettlementAsync(settle);

            Assert.IsTrue(response.Status() == "CANCELLED");
        }

        [Test]
        public void When_I_lookup_a_settlement_using_a_settlement_id_Then_it_should_return_a_valid_settlement_sync()
        {
            auth = cardService.Authorize(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            settle = cardService.Settlement(settle);

            var returnedSettle = cardService.Get(new Settlement(settle.Id()));

            Assert.IsTrue(SettlementsAreEquivalent(settle, returnedSettle));
        }

        [Test]
        public async Task When_I_lookup_a_settlement_using_a_settlement_id_Then_it_should_return_a_valid_settlement_async()
        {
            auth = await cardService.AuthorizeAsync(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            settle = await cardService.SettlementAsync(settle);

            var returnedSettle = await cardService.GetAsync(new Settlement(settle.Id()));

            Assert.IsTrue(SettlementsAreEquivalent(settle, returnedSettle));
        }

        [Test]
        public void When_I_lookup_a_settlement_using_a_merchant_refNum_Then_it_should_return_a_valid_settlement_sync()
        {
            auth = cardService.Authorize(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            settle = cardService.Settlement(settle);

            Pagerator<Settlement> settlements = cardService.GetSettlements(Settlement.Builder()
                .MerchantRefNum(settle.MerchantRefNum())
                .Build());

            var settleList = settlements.GetResults();
            Assert.IsTrue(settleList.Count == 1);
            Assert.IsTrue(SettlementsAreEquivalent(settle, settleList[0]));
        }

        [Test]
        public async Task When_I_lookup_a_settlement_using_a_merchant_refNum_Then_it_should_return_a_valid_settlement_async()
        {
            auth = await cardService.AuthorizeAsync(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            settle = await cardService.SettlementAsync(settle);

            Pagerator<Settlement> settlements = await cardService.GetSettlementsAsync(Settlement.Builder()
                .MerchantRefNum(settle.MerchantRefNum())
                .Build());

            var settleList = settlements.GetResults();
            Assert.IsTrue(settleList.Count == 1);
            Assert.IsTrue(SettlementsAreEquivalent(settle, settleList[0]));
        }

        /*
         * Process a card refund
         */
        [Test]
        public void When_I_refund_a_pending_settlement_Then_it_should_throw_RequestDeclinedException_sync()
        {
            auth = cardService.Authorize(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            settle = cardService.Settlement(settle);

            Assert.Throws<Paysafe.Common.RequestDeclinedException>(() => cardService.Refund(Refund.Builder()
                                                                                .MerchantRefNum(settle.MerchantRefNum())
                                                                                .SettlementId(settle.Id())
                                                                                .Build()));
        }

        [Test]
        public async Task When_I_refund_a_pending_settlement_Then_it_should_throw_RequestDeclinedException_async()
        {
            auth = await cardService.AuthorizeAsync(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            settle = await cardService.SettlementAsync(settle);

            Assert.ThrowsAsync<Paysafe.Common.RequestDeclinedException>(async () => await cardService.RefundAsync(Refund.Builder()
                                                                                                 .MerchantRefNum(settle.MerchantRefNum())
                                                                                                 .SettlementId(settle.Id())
                                                                                                 .Build()));
        }

        /*
         * Verify a Card Payment
         */

        [Test]
        public void When_I_verify_a_card_payment_Then_it_should_return_a_valid_response_sync()
        {
            var ver = SampleFactory.CreateSampleVerification();

            var response = cardService.Verify(ver);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public async Task When_I_verify_a_card_payment_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var ver = SampleFactory.CreateSampleVerification();

            var response = await service.VerifyAsync(ver);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public void When_I_lookup_a_verification_using_a_verification_id_Then_it_should_return_a_valid_verification_sync()
        {
            var ver = SampleFactory.CreateSampleVerification();

            ver = cardService.Verify(ver);

            var returnedVer = cardService.Get(new Verification(ver.Id()));

            Assert.IsTrue(VerificationsAreEquivalent(ver, returnedVer));
        }

        [Test]
        public async Task When_I_lookup_a_verification_using_a_verification_id_Then_it_should_return_a_valid_verification_async()
        {
            var ver = SampleFactory.CreateSampleVerification();

            ver = cardService.Verify(ver);

            var returnedVer = await cardService.GetAsync(new Verification(ver.Id()));

            Assert.IsTrue(VerificationsAreEquivalent(ver, returnedVer));
        }

        [Test]
        public void When_I_lookup_a_verification_using_a_merchant_refNum_Then_it_should_return_a_valid_verification_sync()
        {
            var ver = SampleFactory.CreateSampleVerification();

            ver = cardService.Verify(ver);

            Pagerator<Verification> verifications = cardService.GetVerifications(Verification.Builder()
                .MerchantRefNum(ver.MerchantRefNum())
                .Build());

            var verList = verifications.GetResults();
            Assert.IsTrue(verList.Count == 1);
            Assert.IsTrue(VerificationsAreEquivalent(ver, verList[0]));
        }

        [Test]
        public async Task When_I_lookup_a_verification_using_a_merchant_refNum_Then_it_should_return_a_valid_verification_async()
        {
            var ver = SampleFactory.CreateSampleVerification();

            ver = await cardService.VerifyAsync(ver);

            Pagerator<Verification> verifications = await cardService.GetVerificationsAsync(Verification.Builder()
                .MerchantRefNum(ver.MerchantRefNum())
                .Build());

            var verList = verifications.GetResults();
            Assert.IsTrue(verList.Count == 1);
            Assert.IsTrue(VerificationsAreEquivalent(ver, verList[0]));
        }

        /*
        * Helpers
        */

        private bool AuthorizationsAreEquivalent(Authorization auth1, Authorization auth2)
        {
            if (!auth1.Id().Equals(auth2.Id())
                || !auth1.Card().LastDigits().Equals(auth2.Card().LastDigits())
                || !auth1.TxnTime().Equals(auth2.TxnTime())
                || !auth1.AuthCode().Equals(auth2.AuthCode())
                || !auth1.Amount().Equals(auth2.Amount())
                || !auth1.CurrencyCode().Equals(auth2.CurrencyCode())
                || !auth1.Status().Equals(auth2.Status()))
            {
                return false;
            }

            return true;
        }

        private bool AuthorizationReversalsAreEquivalent(AuthorizationReversal rev1, AuthorizationReversal rev2)
        {
            if (!rev1.Id().Equals(rev2.Id())
                || !rev1.MerchantRefNum().Equals(rev2.MerchantRefNum())
                || !rev1.TxnTime().Equals(rev2.TxnTime())
                || !rev1.Amount().Equals(rev2.Amount())
                || !rev1.Status().Equals(rev2.Status()))
            {
                return false;
            }

            return true;
        }

        private bool SettlementsAreEquivalent(Settlement settle1, Settlement settle2)
        {
            if (!settle1.Id().Equals(settle2.Id())
                || !settle1.TxnTime().Equals(settle2.TxnTime())
                || !settle1.Amount().Equals(settle2.Amount())
                || !settle1.Status().Equals(settle2.Status())
                || !settle1.MerchantRefNum().Equals(settle2.MerchantRefNum()))
            {
                return false;
            }

            return true;
        }

        private bool VerificationsAreEquivalent(Verification ver1, Verification ver2)
        {
            if (!ver1.Id().Equals(ver2.Id())
                || !ver1.Card().LastDigits().Equals(ver2.Card().LastDigits())
                || !ver1.TxnTime().Equals(ver2.TxnTime())
                || !ver1.AuthCode().Equals(ver2.AuthCode())
                || !ver1.CustomerIp().Equals(ver2.CustomerIp())
                || !ver1.Description().Equals(ver2.Description())
                || !ver1.MerchantRefNum().Equals(ver2.MerchantRefNum())
                || !ver1.CurrencyCode().Equals(ver2.CurrencyCode())
                || !ver1.Status().Equals(ver2.Status()))
            {
                return false;
            }

            return true;
        }
    }
}
