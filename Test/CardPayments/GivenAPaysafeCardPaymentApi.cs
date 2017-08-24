using System;
using System.Linq;
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
        private CardPaymentService _cardService;
        private Authorization _auth;

        [SetUp]
        public void Init()
        {
            _cardService = SampleFactory.CreateSampleCardPaymentService();
            _auth = SampleFactory.CreateSampleCustomAuthorization("noException");
        }

        /*
         * Monitor
         */

        [Test]
        public void Card_payment_api_Should_be_up_sync()
        {
            bool status = _cardService.Monitor();
            Assert.That(status, Is.True);
        }

        [Test]
        public async Task Card_payment_api_Should_be_up_async()
        {
            bool status = await _cardService.MonitorAsync();
            Assert.That(status, Is.True);
        }

        /*
         * Authorize a Card Payment
         */

        [Test]
        public void When_I_send_a_valid_auth_Then_the_transaction_should_complete_synchronous()
        {
            var response = _cardService.Authorize(_auth);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public async Task When_I_send_a_valid_auth_Then_the_transaction_should_complete_asynchronous()
        {
            var response = await _cardService.AuthorizeAsync(_auth);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public void When_I_process_a_complex_auth_Then_it_should_return_a_valid_response_sync()
        {
            var complexAuth = SampleFactory.CreateSampleComplexAuthorization();

            var response = _cardService.Authorize(complexAuth);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public async Task When_I_process_a_complex_auth_Then_it_should_return_a_valid_response_async()
        {
            var complexAuth = SampleFactory.CreateSampleComplexAuthorization();

            var response =  await _cardService.AuthorizeAsync(complexAuth);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public void When_I_lookup_an_auth_using_an_auth_id_Then_it_should_return_a_valid_auth_sync()
        {
            _auth = _cardService.Authorize(_auth);

            var returnedAuth = _cardService.Get(new Authorization(_auth.Id()));

            Assert.That(returnedAuth.Status(), Is.EqualTo("COMPLETED"));
            Assert.That(AuthorizationsAreEquivalent(_auth, returnedAuth), Is.True);
        }

        [Test]
        public async Task When_I_lookup_an_auth_using_an_auth_id_Then_it_should_return_a_valid_auth_async()
        {
            _auth = await _cardService.AuthorizeAsync(_auth);

            var returnedAuth = await _cardService.GetAsync(new Authorization(_auth.Id()));

            Assert.That(returnedAuth.Status(), Is.EqualTo("COMPLETED"));
            Assert.That(AuthorizationsAreEquivalent(_auth, returnedAuth), Is.True);
        }

        [Test]
        public void When_I_lookup_an_auth_using_a_merchant_refNum_Then_it_should_return_a_valid_auth_sync()
        {
            _auth = _cardService.Authorize(_auth);

            Pagerator<Authorization> auths = _cardService.GetAuths(Authorization.Builder()
                                                                                .MerchantRefNum(_auth.MerchantRefNum())
                                                                                .Build());

            var authList = auths.GetResults();

            Assert.That(authList.Count, Is.EqualTo(1));
            Assert.That( AuthorizationsAreEquivalent(authList.First(), _auth));
        }

        [Test]
        public async Task When_I_lookup_an_auth_using_a_merchant_refNum_Then_it_should_return_a_valid_auth_async()
        {
            _auth = _cardService.Authorize(_auth);

            Pagerator<Authorization> auths = await _cardService.GetAuthsAsync(Authorization.Builder()
                                                                                          .MerchantRefNum(_auth.MerchantRefNum())
                                                                                          .Build());

            var authList = auths.GetResults();

            Assert.That(authList.Count, Is.EqualTo(1));
            Assert.That(AuthorizationsAreEquivalent(authList.First(), _auth));
        }

        /*
         * Process a Card Purchase
         */
        [Test]
        public void When_I_process_a_valid_purchase_Then_it_should_return_a_valid_response_sync()
        {
            var settledAuth = SampleFactory.CreateSampleSettledAuthorization();

            var response = _cardService.Authorize(settledAuth);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public async Task When_I_process_a_valid_purchase_Then_it_should_return_a_valid_response_async()
        {
            var settledAuth = SampleFactory.CreateSampleSettledAuthorization();

            var response = await _cardService.AuthorizeAsync(settledAuth);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public void When_I_void_an_auth_Then_it_should_return_a_valid_response_sync()
        {
            _auth = _cardService.Authorize(_auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .Amount(6666) // Amount voided == authorized amount
                .AuthorizationId(_auth.Id())
                .Build();

            AuthorizationReversal response = _cardService.ReverseAuth(authReversal);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public async Task When_I_void_an_auth_Then_it_should_return_a_valid_response_async()
        {
            _auth = _cardService.Authorize(_auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .Amount(6666) //Amount voided == authorized amount
                .AuthorizationId(_auth.Id())
                .Build();

            AuthorizationReversal response = await _cardService.ReverseAuthAsync(authReversal);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public void When_I_partially_void_an_auth_Then_it_should_return_a_valid_response_sync()
        {
            _auth = _cardService.Authorize(_auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .Amount(111) //Amount voided < authorized amount
                .AuthorizationId(_auth.Id())
                .Build();

            AuthorizationReversal response = _cardService.ReverseAuth(authReversal);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public async Task When_I_partially_void_an_auth_Then_it_should_return_a_valid_response_async()
        {
            _auth = _cardService.Authorize(_auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .Amount(111) //Amount voided < authorized amount
                .AuthorizationId(_auth.Id())
                .Build();

            AuthorizationReversal response = await _cardService.ReverseAuthAsync(authReversal);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public void When_I_void_a_settled_auth_Then_it_should_return_throw_RequestDeclinedException_sync()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var settledAuth = SampleFactory.CreateSampleSettledAuthorization();

            settledAuth = service.Authorize(settledAuth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
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
            _auth = _cardService.Authorize(_auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .Amount(1000000) //Amount voided > authorized amount
                .AuthorizationId(_auth.Id())
                .Build();

            Assert.Throws<Paysafe.Common.RequestDeclinedException>(() => _cardService.ReverseAuth(authReversal));
        }

        [Test]
        public void When_I_void_an_auth_with_an_amount_too_large_Then_it_should_return_throw_RequestDeclinedException_async()
        {
            _auth = _cardService.Authorize(_auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .Amount(1000000) //Amount voided > authorized amount
                .AuthorizationId(_auth.Id())
                .Build();

            Assert.ThrowsAsync<Paysafe.Common.RequestDeclinedException>(async () => await _cardService.ReverseAuthAsync(authReversal));
        }

        [Test]
        public void When_I_lookup_a_reversal_using_a_reversal_id_Then_it_should_return_a_valid_reversal_sync()
        {
            _auth = _cardService.Authorize(_auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .Amount(6666)
                .AuthorizationId(_auth.Id())
                .Build();

            authReversal = _cardService.ReverseAuth(authReversal);

            AuthorizationReversal returnedReversal = _cardService.Get(new AuthorizationReversal(authReversal.Id()));

            Assert.That(returnedReversal.Status(), Is.EqualTo("COMPLETED"));
            Assert.That(AuthorizationReversalsAreEquivalent(authReversal, returnedReversal));
        }

        [Test]
        public async Task When_I_lookup_a_reversal_using_a_reversal_id_Then_it_should_return_a_valid_reversal_async()
        {
            _auth = await _cardService.AuthorizeAsync(_auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .Amount(6666)
                .AuthorizationId(_auth.Id())
                .Build();

            authReversal = await _cardService.ReverseAuthAsync(authReversal);

            AuthorizationReversal returnedReversal = await _cardService.GetAsync(new AuthorizationReversal(authReversal.Id()));

            Assert.That(returnedReversal.Status(), Is.EqualTo("COMPLETED"));

            Assert.That(AuthorizationReversalsAreEquivalent(authReversal, returnedReversal));
        }

        [Test]
        public void When_I_lookup_a_reversal_using_a_merchant_refNum_Then_it_should_return_a_valid_reversal_sync()
        {
            _auth = _cardService.Authorize(_auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .Amount(6666)
                .AuthorizationId(_auth.Id())
                .Build();

            authReversal = _cardService.ReverseAuth(authReversal);

            Pagerator<AuthorizationReversal> authReversals = _cardService.GetAuthReversals(AuthorizationReversal.Builder()
                .MerchantRefNum(authReversal.MerchantRefNum())
                .Build());


            var authRevList = authReversals.GetResults();
            Assert.That(authRevList.Count, Is.EqualTo(1));
            Assert.That(AuthorizationReversalsAreEquivalent(authReversal, authRevList.First()));
        }

        [Test]
        public async Task When_I_lookup_a_reversal_using_a_merchant_refNum_Then_it_should_return_a_valid_reversal_async()
        {
            _auth = await _cardService.AuthorizeAsync(_auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .Amount(6666)
                .AuthorizationId(_auth.Id())
                .Build();

            authReversal = await _cardService.ReverseAuthAsync(authReversal);

            Pagerator<AuthorizationReversal> authReversals = await _cardService.GetAuthReversalsAsync(AuthorizationReversal.Builder()
                .MerchantRefNum(authReversal.MerchantRefNum())
                .Build());


            var authRevList = authReversals.GetResults();
            Assert.That(authRevList.Count, Is.EqualTo(1));
            Assert.That(AuthorizationReversalsAreEquivalent(authReversal, authRevList[0]));
        }

        /*
         * Settle a card authorization
         */

        [Test]
        public void When_I_settle_an_auth_Then_it_should_return_a_valid_response_sync()
        {
            _auth = _cardService.Authorize(_auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .AuthorizationId(_auth.Id())
                .Build();

            Settlement response = _cardService.Settlement(settle);

            Assert.That(response.Status(), Is.EqualTo("PENDING"));
        }

        [Test]
        public async Task When_I_settle_an_auth_Then_it_should_return_a_valid_response_async()
        {
            _auth = await _cardService.AuthorizeAsync(_auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .AuthorizationId(_auth.Id())
                .Build();

            Settlement response = await _cardService.SettlementAsync(settle);

            Assert.That(response.Status(), Is.EqualTo("PENDING"));
        }

        [Test]
        public void When_I_cancel_a_settlement_Then_it_should_return_a_valid_response_sync()
        {
            _auth = _cardService.Authorize(_auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .AuthorizationId(_auth.Id())
                .Build();

            settle = _cardService.Settlement(settle);

            Settlement response = _cardService.CancelSettlement(settle);

            Assert.That(response.Status(), Is.EqualTo("CANCELLED"));
        }

        // Failed once
        [Test]
        public async Task When_I_cancel_a_settlement_Then_it_should_return_a_valid_response_async()
        {
            _auth = await _cardService.AuthorizeAsync(_auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .AuthorizationId(_auth.Id())
                .Build();

            settle = await _cardService.SettlementAsync(settle);

            Settlement response = await _cardService.CancelSettlementAsync(settle);

            Assert.That(response.Status(), Is.EqualTo("CANCELLED"));
        }

        [Test]
        public void When_I_lookup_a_settlement_using_a_settlement_id_Then_it_should_return_a_valid_settlement_sync()
        {
            _auth = _cardService.Authorize(_auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .AuthorizationId(_auth.Id())
                .Build();

            settle = _cardService.Settlement(settle);

            var returnedSettle = _cardService.Get(new Settlement(settle.Id()));

            Assert.That(SettlementsAreEquivalent(settle, returnedSettle));
        }

        [Test]
        public async Task When_I_lookup_a_settlement_using_a_settlement_id_Then_it_should_return_a_valid_settlement_async()
        {
            _auth = await _cardService.AuthorizeAsync(_auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .AuthorizationId(_auth.Id())
                .Build();

            settle = await _cardService.SettlementAsync(settle);

            var returnedSettle = await _cardService.GetAsync(new Settlement(settle.Id()));

            Assert.That(SettlementsAreEquivalent(settle, returnedSettle));
        }

        [Test]
        public void When_I_lookup_a_settlement_using_a_merchant_refNum_Then_it_should_return_a_valid_settlement_sync()
        {
            _auth = _cardService.Authorize(_auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .AuthorizationId(_auth.Id())
                .Build();

            settle = _cardService.Settlement(settle);

            Pagerator<Settlement> settlements = _cardService.GetSettlements(Settlement.Builder()
                .MerchantRefNum(settle.MerchantRefNum())
                .Build());

            var settleList = settlements.GetResults();
            Assert.That(settleList.Count, Is.EqualTo(1));
            Assert.IsTrue(SettlementsAreEquivalent(settle, settleList[0]));
        }

        [Test]
        public async Task When_I_lookup_a_settlement_using_a_merchant_refNum_Then_it_should_return_a_valid_settlement_async()
        {
            _auth = await _cardService.AuthorizeAsync(_auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .AuthorizationId(_auth.Id())
                .Build();

            settle = await _cardService.SettlementAsync(settle);

            Pagerator<Settlement> settlements = await _cardService.GetSettlementsAsync(Settlement.Builder()
                .MerchantRefNum(settle.MerchantRefNum())
                .Build());

            var settleList = settlements.GetResults();
            Assert.That(settleList.Count, Is.EqualTo(1));
            Assert.That(SettlementsAreEquivalent(settle, settleList.First()));
        }

        /*
         * Process a card refund
         */

        [Test]
        public void When_I_refund_a_pending_settlement_Then_it_should_throw_RequestDeclinedException_sync()
        {
            _auth = _cardService.Authorize(_auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .AuthorizationId(_auth.Id())
                .Build();

            settle = _cardService.Settlement(settle);

            Assert.Throws<Paysafe.Common.RequestDeclinedException>(() => _cardService.Refund(Refund.Builder()
                                                                                .MerchantRefNum(settle.MerchantRefNum())
                                                                                .SettlementId(settle.Id())
                                                                                .Build()));
        }

        [Test]
        public async Task When_I_refund_a_pending_settlement_Then_it_should_throw_RequestDeclinedException_async()
        {
            _auth = await _cardService.AuthorizeAsync(_auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(_auth.MerchantRefNum())
                .AuthorizationId(_auth.Id())
                .Build();

            settle = await _cardService.SettlementAsync(settle);

            Assert.ThrowsAsync<Paysafe.Common.RequestDeclinedException>(async () => await _cardService.RefundAsync(Refund.Builder()
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

            var response = _cardService.Verify(ver);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public async Task When_I_verify_a_card_payment_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var ver = SampleFactory.CreateSampleVerification();

            var response = await service.VerifyAsync(ver);

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public void When_I_lookup_a_verification_using_a_verification_id_Then_it_should_return_a_valid_verification_sync()
        {
            var ver = SampleFactory.CreateSampleVerification();

            ver = _cardService.Verify(ver);

            var returnedVer = _cardService.Get(new Verification(ver.Id()));

            Assert.That(VerificationsAreEquivalent(ver, returnedVer));
        }

        [Test]
        public async Task When_I_lookup_a_verification_using_a_verification_id_Then_it_should_return_a_valid_verification_async()
        {
            var ver = SampleFactory.CreateSampleVerification();

            ver = _cardService.Verify(ver);

            var returnedVer = await _cardService.GetAsync(new Verification(ver.Id()));

            Assert.That(VerificationsAreEquivalent(ver, returnedVer));
        }

        [Test]
        public void When_I_lookup_a_verification_using_a_merchant_refNum_Then_it_should_return_a_valid_verification_sync()
        {
            var ver = SampleFactory.CreateSampleVerification();

            ver = _cardService.Verify(ver);

            Pagerator<Verification> verifications = _cardService.GetVerifications(Verification.Builder()
                .MerchantRefNum(ver.MerchantRefNum())
                .Build());

            var verList = verifications.GetResults();
            Assert.That(verList.Count, Is.EqualTo(1));
            Assert.That(VerificationsAreEquivalent(ver, verList.First()));
        }

        [Test]
        public async Task When_I_lookup_a_verification_using_a_merchant_refNum_Then_it_should_return_a_valid_verification_async()
        {
            var ver = SampleFactory.CreateSampleVerification();

            ver = await _cardService.VerifyAsync(ver);

            Pagerator<Verification> verifications = await _cardService.GetVerificationsAsync(Verification.Builder()
                .MerchantRefNum(ver.MerchantRefNum())
                .Build());

            var verList = verifications.GetResults();
            Assert.That(verList.Count, Is.EqualTo(1));
            Assert.That(VerificationsAreEquivalent(ver, verList.First()));
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
