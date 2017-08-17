using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Tests;
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
        [SetUp]
        public void SetUp()
        {
        }

        /*
         * Authorize a Card Payment
         */

        [Test]
        public void When_I_process_a_complex_auth_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleComplexAuthorization();

            var response = service.Authorize(auth);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public async Task When_I_process_a_complex_auth_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleComplexAuthorization();

            var response =  await service.AuthorizeAsync(auth);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public void When_I_lookup_an_auth_using_an_auth_id_Then_it_should_return_a_valid_auth_sync()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = service.Authorize(auth);

            var returnedAuth = service.Get(new Authorization(auth.Id()));

            Assert.IsTrue(returnedAuth.Status() == "COMPLETED");
            Assert.IsTrue(AuthorizationsAreEquivalent(auth, returnedAuth));
        }

        [Test]
        public async Task When_I_lookup_an_auth_using_an_auth_id_Then_it_should_return_a_valid_auth_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = await service.AuthorizeAsync(auth);

            var returnedAuth = await service.GetAsync(new Authorization(auth.Id()));

            Assert.IsTrue(returnedAuth.Status() == "COMPLETED");
            Assert.IsTrue(AuthorizationsAreEquivalent(auth, returnedAuth));
        }

        [Test]
        public void When_I_lookup_an_auth_using_a_merchant_refNum_Then_it_should_return_a_valid_auth_sync()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = service.Authorize(auth);

            Pagerator<Authorization> auths = service.GetAuths(Authorization.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Build());

            var authList = auths.GetResults();
            Assert.IsTrue(authList.Count == 1);
            Assert.IsTrue(AuthorizationsAreEquivalent(auth, authList[0]));
        }

        [Test]
        public async Task When_I_lookup_an_auth_using_a_merchant_refNum_Then_it_should_return_a_valid_auth_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = service.Authorize(auth);

            Pagerator<Authorization> auths = await service.GetAuthsAsync(Authorization.Builder()
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
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleSettledAuthorization();

            var response = service.Authorize(auth);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public async Task When_I_process_a_valid_purchase_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleSettledAuthorization();

            var response = await service.AuthorizeAsync(auth);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public void When_I_void_an_auth_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = service.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(6666) // Amount voided == authorized amount
                .AuthorizationId(auth.Id())
                .Build();

            AuthorizationReversal response = service.ReverseAuth(authReversal);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public async Task When_I_void_an_auth_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = service.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(6666) //Amount voided == authorized amount
                .AuthorizationId(auth.Id())
                .Build();

            AuthorizationReversal response = await service.ReverseAuthAsync(authReversal);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public void When_I_partially_void_an_auth_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = service.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(111) //Amount voided < authorized amount
                .AuthorizationId(auth.Id())
                .Build();

            AuthorizationReversal response = service.ReverseAuth(authReversal);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public async Task When_I_partially_void_an_auth_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = service.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(111) //Amount voided < authorized amount
                .AuthorizationId(auth.Id())
                .Build();

            AuthorizationReversal response = await service.ReverseAuthAsync(authReversal);

            Assert.IsTrue(response.Status() == "COMPLETED");
        }

        [Test]
        public void When_I_void_a_settled_auth_Then_it_should_return_throw_RequestDeclinedException_sync()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleSettledAuthorization();

            auth = service.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(6666) //Amount voided == authorized amount
                .AuthorizationId(auth.Id())
                .Build();

            Assert.Throws<Paysafe.Common.RequestDeclinedException>(() => service.ReverseAuth(authReversal));
        }

        [Test]
        public void When_I_void_a_settled_auth_Then_it_should_return_throw_RequestDeclinedException_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleSettledAuthorization();

            auth = service.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(6666) //Amount voided == authorized amount
                .AuthorizationId(auth.Id())
                .Build();

            Assert.ThrowsAsync<Paysafe.Common.RequestDeclinedException>(async () => await service.ReverseAuthAsync(authReversal));
        }

        [Test]
        public void When_I_void_an_auth_with_an_amount_too_large_Then_it_should_return_throw_RequestDeclinedException_sync()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = service.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(1000000) //Amount voided > authorized amount
                .AuthorizationId(auth.Id())
                .Build();

            Assert.Throws<Paysafe.Common.RequestDeclinedException>(() => service.ReverseAuth(authReversal));
        }

        [Test]
        public void When_I_void_an_auth_with_an_amount_too_large_Then_it_should_return_throw_RequestDeclinedException_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = service.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(1000000) //Amount voided > authorized amount
                .AuthorizationId(auth.Id())
                .Build();

            Assert.ThrowsAsync<Paysafe.Common.RequestDeclinedException>(async () => await service.ReverseAuthAsync(authReversal));
        }

        [Test]
        public void When_I_lookup_a_reversal_using_a_reversal_id_Then_it_should_return_a_valid_reversal_sync()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = service.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(6666)
                .AuthorizationId(auth.Id())
                .Build();

            authReversal = service.ReverseAuth(authReversal);

            AuthorizationReversal returnedReversal = service.Get(new AuthorizationReversal(authReversal.Id()));

            Assert.IsTrue(returnedReversal.Status() == "COMPLETED");
            Assert.IsTrue(AuthorizationReversalsAreEquivalent(authReversal, returnedReversal));
        }

        [Test]
        public async Task When_I_lookup_a_reversal_using_a_reversal_id_Then_it_should_return_a_valid_reversal_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = await service.AuthorizeAsync(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(6666)
                .AuthorizationId(auth.Id())
                .Build();

            authReversal = await service.ReverseAuthAsync(authReversal);

            AuthorizationReversal returnedReversal = await service.GetAsync(new AuthorizationReversal(authReversal.Id()));

            Assert.IsTrue(returnedReversal.Status() == "COMPLETED");
            Assert.IsTrue(AuthorizationReversalsAreEquivalent(authReversal, returnedReversal));
        }

        [Test]
        public void When_I_lookup_a_reversal_using_a_merchant_refNum_Then_it_should_return_a_valid_reversal_sync()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = service.Authorize(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(6666)
                .AuthorizationId(auth.Id())
                .Build();

            authReversal = service.ReverseAuth(authReversal);

            Pagerator<AuthorizationReversal> authReversals = service.GetAuthReversals(AuthorizationReversal.Builder()
                .MerchantRefNum(authReversal.MerchantRefNum())
                .Build());


            var authRevList = authReversals.GetResults();
            Assert.IsTrue(authRevList.Count == 1);
            Assert.IsTrue(AuthorizationReversalsAreEquivalent(authReversal, authRevList[0]));
        }

        [Test]
        public async Task When_I_lookup_a_reversal_using_a_merchant_refNum_Then_it_should_return_a_valid_reversal_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = await service.AuthorizeAsync(auth);

            AuthorizationReversal authReversal = AuthorizationReversal.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .Amount(6666)
                .AuthorizationId(auth.Id())
                .Build();

            authReversal = await service.ReverseAuthAsync(authReversal);

            Pagerator<AuthorizationReversal> authReversals = await service.GetAuthReversalsAsync(AuthorizationReversal.Builder()
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
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = service.Authorize(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            Settlement response = service.Settlement(settle);

            Assert.IsTrue(response.Status() == "PENDING");
        }

        [Test]
        public async Task When_I_settle_an_auth_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = await service.AuthorizeAsync(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            Settlement response = await service.SettlementAsync(settle);

            Assert.IsTrue(response.Status() == "PENDING");
        }

        [Test]
        public void When_I_cancel_a_settlement_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = service.Authorize(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            settle = service.Settlement(settle);

            Settlement response = service.CancelSettlement(settle);

            Assert.IsTrue(response.Status() == "CANCELLED");
        }

        [Test]
        public async Task When_I_cancel_a_settlement_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = await service.AuthorizeAsync(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            settle = await service.SettlementAsync(settle);

            Settlement response = await service.CancelSettlementAsync(settle);

            Assert.IsTrue(response.Status() == "CANCELLED");
        }

        [Test]
        public void When_I_lookup_a_settlement_using_a_settlement_id_Then_it_should_return_a_valid_settlement_sync()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = service.Authorize(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            settle = service.Settlement(settle);

            var returnedSettle = service.Get(new Settlement(settle.Id()));

            Assert.IsTrue(SettlementsAreEquivalent(settle, returnedSettle));
        }

        [Test]
        public async Task When_I_lookup_a_settlement_using_a_settlement_id_Then_it_should_return_a_valid_settlement_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = await service.AuthorizeAsync(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            settle = await service.SettlementAsync(settle);

            var returnedSettle = await service.GetAsync(new Settlement(settle.Id()));

            Assert.IsTrue(SettlementsAreEquivalent(settle, returnedSettle));
        }

        [Test]
        public void When_I_lookup_a_settlement_using_a_merchant_refNum_Then_it_should_return_a_valid_settlement_sync()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = service.Authorize(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            settle = service.Settlement(settle);

            Pagerator<Settlement> settlements = service.GetSettlements(Settlement.Builder()
                .MerchantRefNum(settle.MerchantRefNum())
                .Build());

            var settleList = settlements.GetResults();
            Assert.IsTrue(settleList.Count == 1);
            Assert.IsTrue(SettlementsAreEquivalent(settle, settleList[0]));
        }

        [Test]
        public async Task When_I_lookup_a_settlement_using_a_merchant_refNum_Then_it_should_return_a_valid_settlement_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = await service.AuthorizeAsync(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            settle = await service.SettlementAsync(settle);

            Pagerator<Settlement> settlements = await service.GetSettlementsAsync(Settlement.Builder()
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
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = service.Authorize(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            settle = service.Settlement(settle);

            service.Refund(Refund.Builder()
                .MerchantRefNum(settle.MerchantRefNum())
                .SettlementId(settle.Id())
                .Build());

            Assert.Throws<Paysafe.Common.RequestDeclinedException>(() => service.Refund(Refund.Builder()
                                                                                .MerchantRefNum(settle.MerchantRefNum())
                                                                                .SettlementId(settle.Id())
                                                                                .Build()));
        }

        [Test]
        public async Task When_I_refund_a_pending_settlement_Then_it_should_throw_RequestDeclinedException_async()
        {
            var service = SampleFactory.CreateSampleCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            auth = await service.AuthorizeAsync(auth);

            Settlement settle = Settlement.Builder()
                .MerchantRefNum(auth.MerchantRefNum())
                .AuthorizationId(auth.Id())
                .Build();

            settle = await service.SettlementAsync(settle);

            Assert.ThrowsAsync<Paysafe.Common.RequestDeclinedException>(async () => await service.RefundAsync(Refund.Builder()
                .MerchantRefNum(settle.MerchantRefNum())
                .SettlementId(settle.Id())
                .Build()));
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
    }
}
