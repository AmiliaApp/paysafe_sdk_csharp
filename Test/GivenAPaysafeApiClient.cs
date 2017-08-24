using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tests;
using NUnit.Framework;
using Paysafe;
using Paysafe.CardPayments;
using Authorization = Paysafe.CardPayments.Authorization;
using Card = Paysafe.CustomerVault.Card;

namespace Tests
{
    [TestFixture]
    public class GivenAPaysafeApiClient
    {
        private CardPaymentService _cardPaymentService;

        [SetUp]
        public void SetUp()
        {
            _cardPaymentService = SampleFactory.CreateSampleCardPaymentService();
        }

        /*
         * Exceptions
         */

        //400
        [Test]
        public void When_a_card_without_billing_details_is_used_Then_it_should_throw_InvalidRequestException_synchronous()
        {
            var auth = SampleFactory.CreateSampleIncompleteAuthorization();

            Assert.Throws<Paysafe.Common.InvalidRequestException>(() => _cardPaymentService.Authorize(auth));
        }

        [Test]
        public void When_a_card_without_billing_details_is_used_Then_it_should_throw_InvalidRequestException_asynchronous()
        {
            var auth = SampleFactory.CreateSampleIncompleteAuthorization();

            Assert.ThrowsAsync<Paysafe.Common.InvalidRequestException>(async () => await _cardPaymentService.AuthorizeAsync(auth));
        }

        [Test]
        public void When_I_send_an_auth_with_negative_amount_Then_it_should_throw_InvalidRequestException_synchronous()
        {
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");
            auth.Amount(-1);

            Assert.Throws<Paysafe.Common.InvalidRequestException>(() => _cardPaymentService.Authorize(auth));
        }

        [Test]
        public void When_I_send_an_auth_with_negative_amount_Then_it_should_throw_InvalidRequestException_asynchronous()
        {
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");
            auth.Amount(-1);

            Assert.ThrowsAsync<Paysafe.Common.InvalidRequestException>(async () => await _cardPaymentService.AuthorizeAsync(auth));
        }

        //401
        [Test]
        public void When_I_use_a_client_with_invalid_creds_Then_it_should_throw_InvalidCredentialsException_synchronous()
        {
            var invalidCardPaymentService = SampleFactory.CreateSampleInvalidCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            Assert.Throws<Paysafe.Common.InvalidCredentialsException>(() => invalidCardPaymentService.Authorize(auth));
        }

        [Test]
        public void When_I_use_a_client_with_invalid_creds_Then_it_should_throw_InvalidCredentialsException_asynchronous()
        {
            var invalidCardPaymentService = SampleFactory.CreateSampleInvalidCardPaymentService();
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            Assert.ThrowsAsync<Paysafe.Common.InvalidCredentialsException>(async () => await invalidCardPaymentService.AuthorizeAsync(auth));
        }

        //402
        [Test]
        public void When_a_request_is_declined_Then_it_should_throw_RequestDeclinedException_synchronous()
        {
            var auth = SampleFactory.CreateSampleCustomAuthorization("requestDeclined");

            Assert.Throws<Paysafe.Common.RequestDeclinedException>(() => _cardPaymentService.Authorize(auth));
        }

        [Test]
        public void When_a_request_is_declined_Then_it_should_throw_RequestDeclinedException__asynchronous()
        {
            var auth = SampleFactory.CreateSampleCustomAuthorization("requestDeclined");

            Assert.ThrowsAsync<Paysafe.Common.RequestDeclinedException>(async () => await _cardPaymentService.AuthorizeAsync(auth));
        }

        //404
        [Test]
        public void When_I_get_an_auth_with_invalid_id_Then_it_should_throw_EntityNotFoundException_synchronous()
        {
            Assert.Throws<Paysafe.Common.EntityNotFoundException>(() => _cardPaymentService.Get(new Authorization("Invalid_id")));
        }

        [Test]
        public void When_I_get_an_auth_with_invalid_id_Then_it_should_throw_EntityNotFoundException_asynchronous()
        {
            Assert.ThrowsAsync<Paysafe.Common.EntityNotFoundException> (async () => await _cardPaymentService.GetAsync(new Authorization("Invalid_id")));
        }

        //409
        [Test]
        public void When_I_send_an_auth_more_than_once_Then_it_should_throw_RequestConflictException_synchronous()
        {
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            _cardPaymentService.Authorize(auth);
            Assert.Throws<Paysafe.Common.RequestConflictException>(() => _cardPaymentService.Authorize(auth));
        }

        [Test]
        public async Task When_I_send_an_auth_more_than_once_Then_it_should_throw_RequestConflictException_asynchronous()
        {
            var auth = SampleFactory.CreateSampleCustomAuthorization("noException");

            await _cardPaymentService.AuthorizeAsync(auth);
            Assert.ThrowsAsync<Paysafe.Common.RequestConflictException>(async () => await _cardPaymentService.AuthorizeAsync(auth));
        }

        //500 (API Exception)
        [Test]
        public void When_an_internal_error_occurs_Then_it_should_throw_ApiException_synchronous()
        {
            var auth = SampleFactory.CreateSampleCustomAuthorization("apiException");

            Assert.Throws<Paysafe.Common.ApiException>(() => _cardPaymentService.Authorize(auth));
        }

        [Test]
        public void When_an_internal_error_occurs_Then_it_should_throw_ApiException_asynchronous()
        {
            var auth = SampleFactory.CreateSampleCustomAuthorization("apiException");

            Assert.ThrowsAsync<Paysafe.Common.ApiException>(async () => await _cardPaymentService.AuthorizeAsync(auth));
        }
    }
}
