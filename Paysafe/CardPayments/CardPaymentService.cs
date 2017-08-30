/*
 * Copyright (c) 2014 Optimal Payments
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
 * associated documentation files (the "Software"), to deal in the Software without restriction,
 * including without limitation the rights to use, copy, modify, merge, publish, distribute,
 * sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
 * NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
 * DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Paysafe.Common;

namespace Paysafe.CardPayments
{
    public class CardPaymentService
    {

        /// <summary>
        /// The api client, performs all http requests
        /// </summary>
        private PaysafeApiClient _client;

        /// <summary>
        /// The card payments api base uri 
        /// </summary>
        private string _uri = "cardpayments/v1";

        /// <summary>
        /// Initialize the card payments service with an client object
        /// </summary>
        /// <param name="client">PaysafeApiClient</param>
        public CardPaymentService(PaysafeApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Check if the service is available
        /// </summary>
        /// <returns>true if successful</returns>
        public Boolean Monitor() {
            Request request = new Request(uri:"cardpayments/monitor");
            dynamic response = _client.ProcessRequest(request);

            return ("READY".Equals((string)(response[GlobalConstants.Status])));
        }

        public async Task<bool> MonitorAsync()
        {
            Request request = new Request(uri: "cardpayments/monitor");
            dynamic response = await _client.ProcessRequestAsync(request);

            return ("READY".Equals((string)(response[GlobalConstants.Status])));
        }

        /// <summary>
        /// Authorize
        /// </summary>
        /// <param name="auth">Authorization</param>
        /// <returns>Authorization</returns>
        public Authorization Authorize(Authorization auth)
        {
            var request = AuthorizeInternal(auth);
            dynamic response = _client.ProcessRequest(request);

            return new Authorization(response);
        }

        public async Task<Authorization> AuthorizeAsync(Authorization auth)
        {
            var request = AuthorizeInternal(auth);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Authorization(response);
        }

        private Request AuthorizeInternal(Authorization auth)
        {
            auth.SetRequiredFields(new List<string> {
                GlobalConstants.MerchantRefNum,
                GlobalConstants.Amount,
                GlobalConstants.Card
            });
            auth.SetOptionalFields(new List<string> {
                GlobalConstants.SettleWithAuth,
                GlobalConstants.CustomerIp,
                GlobalConstants.DupCheck,
                GlobalConstants.Description,
                GlobalConstants.Authentication,
                GlobalConstants.BillingDetails,
                GlobalConstants.ShippingDetails,
                GlobalConstants.Recurring,
                GlobalConstants.MerchantDescriptor,
                GlobalConstants.AccordD
            });

            return new Request(
                method: RequestType.Post,
                uri: PrepareUri("/auths"),
                body: auth
            );
        }

        /// <summary>
        /// Cancel the Authorization
        /// </summary>
        /// <param name="auth">Authorization</param>
        /// <returns>Authorization</returns>
        public Authorization CancelHeldAuth(Authorization auth)
        {
            var request = CancelHeldAuthInternal(auth);
            dynamic response = _client.ProcessRequest(request);

            return new Authorization(response);
        }

        public async Task<Authorization> CancelHeldAuthAsync(Authorization auth)
        {
            var request = CancelHeldAuthInternal(auth);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Authorization(response);
        }

        private Request CancelHeldAuthInternal(Authorization auth)
        {
            auth.SetRequiredFields(new List<string>
            {
                GlobalConstants.Id
            });
            auth.CheckRequiredFields();

            Authorization tmpAuth = new Authorization();
            tmpAuth.Status("CANCELLED");

            return new Request(
                method: RequestType.Put,
                uri: PrepareUri("/auths/" + auth.Id()),
                body: tmpAuth
            );
        }

        /// <summary>
        /// Approve
        /// </summary>
        /// <param name="auth">Authorization</param>
        /// <returns>Authorization</returns>
        public Authorization ApproveHeldAuth(Authorization auth)
        {
            var request = ApproveHeldAuthInternal(auth);
            dynamic response = _client.ProcessRequest(request);

            return new Authorization(response);
        }

        public async Task<Authorization> ApproveHeldAuthAsync(Authorization auth)
        {
            var request = ApproveHeldAuthInternal(auth);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Authorization(response);
        }

        private Request ApproveHeldAuthInternal(Authorization auth)
        {
            auth.SetRequiredFields(new List<string> { GlobalConstants.Id });

            auth.CheckRequiredFields();

            Authorization tmpAuth = new Authorization();
            tmpAuth.Status("COMPLETED");

            return new Request(
                method: RequestType.Put,
                uri: PrepareUri("/auths/" + auth.Id()),
                body: tmpAuth
            );
        }

        /// <summary>
        /// Reverse
        /// </summary>
        /// <param name="authReversal">AuthorizationReversal</param>
        /// <returns>AuthorizationReversal</returns>
        public AuthorizationReversal ReverseAuth(AuthorizationReversal authReversal)
        {
            var request = ReverseAuthInternal(authReversal);
            dynamic response = _client.ProcessRequest(request);

            return new AuthorizationReversal(response);
        }

        public async Task<AuthorizationReversal> ReverseAuthAsync(AuthorizationReversal authReversal)
        {
            var request = ReverseAuthInternal(authReversal);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new AuthorizationReversal(response);
        }

        private Request ReverseAuthInternal(AuthorizationReversal authReversal)
        {
            authReversal.SetRequiredFields(new List<string> { GlobalConstants.AuthorizationId });
            authReversal.CheckRequiredFields();
            authReversal.SetRequiredFields(new List<string> { GlobalConstants.MerchantRefNum });
            authReversal.SetOptionalFields(new List<string> {
                GlobalConstants.Amount,
                GlobalConstants.DupCheck
            });

            return new Request(
                method: RequestType.Post,
                uri: PrepareUri("/auths/" + authReversal.AuthorizationId() + "/voidauths"),
                body: authReversal
            );
        }

        /// <summary>
        /// Settlement
        /// </summary>
        /// <param name="settlement">Settlement</param>
        /// <returns>Settlement</returns>
        public Settlement Settlement(Settlement settle)
        {
            var request = SettlementInternal(settle);
            dynamic response = _client.ProcessRequest(request);

            return new Settlement(response);
        }

        public async Task<Settlement> SettlementAsync(Settlement settle)
        {
            var request = SettlementInternal(settle);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Settlement(response);
        }

        private Request SettlementInternal(Settlement settle)
        {
            settle.SetRequiredFields(new List<string> { GlobalConstants.AuthorizationId });
            settle.CheckRequiredFields();
            settle.SetRequiredFields(new List<string> { GlobalConstants.MerchantRefNum });
            settle.SetOptionalFields(new List<string> {
                GlobalConstants.Amount,
                GlobalConstants.DupCheck
            });

            return new Request(
                method: RequestType.Post,
                uri: PrepareUri("/auths/" + settle.AuthorizationId() + "/settlements"),
                body: settle
            );
        }

        /// <summary>
        /// Cancel Settlement
        /// </summary>
        /// <param name="settlement">Settlement</param>
        /// <returns>Settlement</returns>
        public Settlement CancelSettlement(Settlement settle)
        {
            var request = CancelSettlementInternal(settle);
            dynamic response = _client.ProcessRequest(request);

            return new Settlement(response);
        }

        public async Task<Settlement> CancelSettlementAsync(Settlement settle)
        {
            var request = CancelSettlementInternal(settle);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Settlement(response);
        }

        private Request CancelSettlementInternal(Settlement settle)
        {
            settle.SetRequiredFields(new List<string> { GlobalConstants.Id });
            settle.CheckRequiredFields();

            Settlement tmpSettlement = new Settlement();
            tmpSettlement.Status("CANCELLED");

            return new Request(
                method: RequestType.Put,
                uri: PrepareUri("/settlements/" + settle.Id()),
                body: tmpSettlement
            );
        }

        /// <summary>
        /// Refund
        /// </summary>
        /// <param name="refund">Refund</param>
        /// <returns>Refund</returns>
        public Refund Refund(Refund newRefund)
        {
            var request = RefundInternal(newRefund);
            dynamic response = _client.ProcessRequest(request);

            return new Refund(response);
        }

        public async Task<Refund> RefundAsync(Refund newRefund)
        {
            var request = RefundInternal(newRefund);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Refund(response);
        }

        private Request RefundInternal(Refund newRefund)
        {
            newRefund.SetRequiredFields(new List<string> { GlobalConstants.SettlementId });
            newRefund.CheckRequiredFields();
            newRefund.SetRequiredFields(new List<string> { GlobalConstants.MerchantRefNum });
            newRefund.SetOptionalFields(new List<string> {
                GlobalConstants.Amount,
                GlobalConstants.DupCheck
            });

            return new Request(
                method: RequestType.Post,
                uri: PrepareUri("/settlements/" + newRefund.SettlementId() + "/refunds"),
                body: newRefund
            );
        }

        /// <summary>
        /// Cancel Refund
        /// </summary>
        /// <param name="refund">Refund</param>
        /// <returns>Refund</returns>
        public Refund CancelRefund(Refund refund)
        {
            var request = CancelRefundInternal(refund);
            dynamic response = _client.ProcessRequest(request);

            return new Refund(response);
        }

        public async Task<Refund> CancelRefundAsync(Refund refund)
        {
            var request = CancelRefundInternal(refund);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Refund(response);
        }

        private Request CancelRefundInternal(Refund refund)
        {
            refund.SetRequiredFields(new List<string> { GlobalConstants.Id });
            refund.CheckRequiredFields();

            Refund tmpRefund = new Refund();
            tmpRefund.Status("CANCELLED");

            return new Request(
                method: RequestType.Put,
                uri: PrepareUri("/refunds/" + refund.Id()),
                body: tmpRefund
            );
        }

        /// <summary>
        /// Verify
        /// </summary>
        /// <param name="verify">Verification</param>
        /// <returns>Verificationd</returns>
        public Verification Verify(Verification verification)
        {
            var request = VerifyInternal(verification);
            dynamic response = _client.ProcessRequest(request);

            return new Verification(response);
        }

        public async Task<Verification> VerifyAsync(Verification verification)
        {
            var request = VerifyInternal(verification);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Verification(response);
        }

        private Request VerifyInternal(Verification verification)
        {
            verification.SetRequiredFields(new List<string> {
                GlobalConstants.MerchantRefNum,
                GlobalConstants.Card
            });

            verification.SetOptionalFields(new List<string> {
                GlobalConstants.Profile,
                GlobalConstants.CustomerIp,
                GlobalConstants.DupCheck,
                GlobalConstants.Description,
                GlobalConstants.BillingDetails
            });

            return new Request(
                method: RequestType.Post,
                uri: PrepareUri("/verifications"),
                body: verification
            );
        }

        /// <summary>
        /// Get the authorization
        /// </summary>
        /// <param name="auth">Authorization</param>
        /// <returns>Authorization</returns>
        public Authorization Get(Authorization auth)
        {
            var request = GetInternal(auth);
            dynamic response = _client.ProcessRequest(request);

            return new Authorization(response);
        }

        public async Task<Authorization> GetAsync(Authorization auth)
        {
            var request = GetInternal(auth);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Authorization(response);
        }

        private Request GetInternal(Authorization auth)
        {
            auth.SetRequiredFields(new List<string> { GlobalConstants.Id });
            auth.CheckRequiredFields();

            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/auths/" + auth.Id())
            );
        }

        /// <summary>
        /// Get the AuthorizationReversal
        /// </summary>
        /// <param name="authReversal">AuthorizationReversal</param>
        /// <returns>AuthorizationReversal</returns>
        public AuthorizationReversal Get(AuthorizationReversal authReversal)
        {
            var request = GetInternal(authReversal);
            dynamic response = _client.ProcessRequest(request);

            return new AuthorizationReversal(response);
        }

        public async Task<AuthorizationReversal> GetAsync(AuthorizationReversal authReversal)
        {
            var request = GetInternal(authReversal);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new AuthorizationReversal(response);
        }

        private Request GetInternal(AuthorizationReversal authReversal)
        {
            authReversal.SetRequiredFields(new List<string> { GlobalConstants.Id });
            authReversal.CheckRequiredFields();

            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/voidauths/" + authReversal.Id())
            );
        }

        /// <summary>
        /// Get the Settlement
        /// </summary>
        /// <param name="settlement">Settlement</param>
        /// <returns>Settlement</returns>
        public Settlement Get(Settlement settlement)
        {
            var request = GetInternal(settlement);
            dynamic response = _client.ProcessRequest(request);

            return new Settlement(response);
        }

        public async Task<Settlement> GetAsync(Settlement settlement)
        {
            var request = GetInternal(settlement);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Settlement(response);
        }

        private Request GetInternal(Settlement settlement)
        {
            settlement.SetRequiredFields(new List<string> { GlobalConstants.Id });
            settlement.CheckRequiredFields();

            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/settlements/" + settlement.Id())
            );
        }

        /// <summary>
        /// Get the Refund
        /// </summary>
        /// <param name="refund">Refund</param>
        /// <returns>Refund</returns>
        public Refund Get(Refund refund)
        {
            var request = GetInternal(refund);
            dynamic response = _client.ProcessRequest(request);

            return new Refund(response);
        }

        public async Task<Refund> GetAsync(Refund refund)
        {
            var request = GetInternal(refund);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Refund(response);
        }

        private Request GetInternal(Refund refund)
        {
            refund.SetRequiredFields(new List<string> { GlobalConstants.Id });
            refund.CheckRequiredFields();

            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/refunds/" + refund.Id())
            );
        }

        /// <summary>
        /// Get the verification
        /// </summary>
        /// <param name="verification">Verification</param>
        /// <returns>Verification</returns>
        public Verification Get(Verification verify)
        {
            var request = GetInternal(verify);
            dynamic response = _client.ProcessRequest(request);

            return new Verification(response);
        }

        public async Task<Verification> GetAsync(Verification verify)
        {
            var request = GetInternal(verify);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Verification(response);
        }

        private Request GetInternal(Verification verify)
        {
            verify.SetRequiredFields(new List<string> { GlobalConstants.Id });
            verify.CheckRequiredFields();

            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/verifications/" + verify.Id())
            );
        }

        /// <summary>
        /// Get matching authorizations
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Pagerator<Authorization> GetAuths(Authorization auth = null, Filter filter = null)
        {
            var request = GetAuthsInternal(auth, filter);
            dynamic response = _client.ProcessRequest(request);

            return new Pagerator<Authorization>(_client, typeof(Authorization), response);
        }

        public async Task<Pagerator<Authorization>> GetAuthsAsync(Authorization auth = null, Filter filter = null)
        {
            var request = GetAuthsInternal(auth, filter);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Pagerator<Authorization>(_client, typeof(Authorization), response);
        }

        private Request GetAuthsInternal(Authorization auth = null, Filter filter = null)
        {
            Dictionary<String, String> queryStr = new Dictionary<String, String>();
            if (auth != null && !String.IsNullOrWhiteSpace(auth.MerchantRefNum()))
            {
                queryStr.Add("merchantRefNum", auth.MerchantRefNum());
            }
            if (filter != null)
            {
                if (filter.Limit != null)
                {
                    queryStr.Add("limit", filter.Limit.ToString());
                }
                if (filter.Offset != null)
                {
                    queryStr.Add("offset", filter.Offset.ToString());
                }
                if (!String.IsNullOrWhiteSpace(filter.StartDate))
                {
                    queryStr.Add("startDate", filter.StartDate);
                }
                if (!String.IsNullOrWhiteSpace(filter.EndDate))
                {
                    queryStr.Add("endDate", filter.EndDate);
                }
            }

            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/auths"),
                queryString: queryStr
            );
        }

        /// <summary>
        /// Get matching authorization reversals
        /// </summary>
        /// <param name="authReversal"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Pagerator<AuthorizationReversal> GetAuthReversals(AuthorizationReversal authReversal = null, Filter filter = null)
        {
            var request = GetAuthReversalsInternal(authReversal, filter);
            dynamic response = _client.ProcessRequest(request);

            return new Pagerator<AuthorizationReversal>(_client, typeof(AuthorizationReversal), response);
        }

        public async Task<Pagerator<AuthorizationReversal>> GetAuthReversalsAsync(AuthorizationReversal authReversal = null, Filter filter = null)
        {
            var request = GetAuthReversalsInternal(authReversal, filter);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Pagerator<AuthorizationReversal>(_client, typeof(AuthorizationReversal), response);
        }

        private Request GetAuthReversalsInternal(AuthorizationReversal authReversal = null, Filter filter = null)
        {
            Dictionary<String, String> queryStr = new Dictionary<String, String>();
            if (authReversal != null && !String.IsNullOrWhiteSpace(authReversal.MerchantRefNum()))
            {
                queryStr.Add("merchantRefNum", authReversal.MerchantRefNum());
            }
            if (filter != null)
            {
                if (filter.Limit != null)
                {
                    queryStr.Add("limit", filter.Limit.ToString());
                }
                if (filter.Offset != null)
                {
                    queryStr.Add("offset", filter.Offset.ToString());
                }
                if (!String.IsNullOrWhiteSpace(filter.StartDate))
                {
                    queryStr.Add("startDate", filter.StartDate);
                }
                if (!String.IsNullOrWhiteSpace(filter.EndDate))
                {
                    queryStr.Add("endDate", filter.EndDate);
                }
            }

            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/voidauths"),
                queryString: queryStr
            );
        }

        /// <summary>
        /// Get matching settlements
        /// </summary>
        /// <param name="settlement"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Pagerator<Settlement> GetSettlements(Settlement settlement = null, Filter filter = null)
        {
            var request = GetSettlementsInternal(settlement, filter);
            dynamic response = _client.ProcessRequest(request);

            return new Pagerator<Settlement>(_client, typeof(Settlement), response);
        }

        public async Task<Pagerator<Settlement>> GetSettlementsAsync(Settlement settlement = null, Filter filter = null)
        {
            var request = GetSettlementsInternal(settlement, filter);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Pagerator<Settlement>(_client, typeof(Settlement), response);
        }

        private Request GetSettlementsInternal(Settlement settlement = null, Filter filter = null)
        {
            Dictionary<String, String> queryStr = new Dictionary<String, String>();
            if (settlement != null && !String.IsNullOrWhiteSpace(settlement.MerchantRefNum()))
            {
                queryStr.Add("merchantRefNum", settlement.MerchantRefNum());
            }
            if (filter != null)
            {
                if (filter.Limit != null)
                {
                    queryStr.Add("limit", filter.Limit.ToString());
                }
                if (filter.Offset != null)
                {
                    queryStr.Add("offset", filter.Offset.ToString());
                }
                if (!String.IsNullOrWhiteSpace(filter.StartDate))
                {
                    queryStr.Add("startDate", filter.StartDate);
                }
                if (!String.IsNullOrWhiteSpace(filter.EndDate))
                {
                    queryStr.Add("endDate", filter.EndDate);
                }
            }

            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/settlements"),
                queryString: queryStr
            );
        }

        /// <summary>
        /// Get matching refunds
        /// </summary>
        /// <param name="refund"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Pagerator<Refund> GetRefunds(Refund refund = null, Filter filter = null)
        {
            var request = GetRefundsInternal(refund, filter);
            dynamic response = _client.ProcessRequest(request);

            return new Pagerator<Refund>(_client, typeof(Refund), response);
        }

        public async Task<Pagerator<Refund>> GetRefundsAsync(Refund refund = null, Filter filter = null)
        {
            var request = GetRefundsInternal(refund, filter);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Pagerator<Refund>(_client, typeof(Refund), response);
        }

        private Request GetRefundsInternal(Refund refund = null, Filter filter = null)
        {
            Dictionary<String, String> queryStr = new Dictionary<String, String>();
            if (refund != null && !String.IsNullOrWhiteSpace(refund.MerchantRefNum()))
            {
                queryStr.Add("merchantRefNum", refund.MerchantRefNum());
            }
            if (filter != null)
            {
                if (filter.Limit != null)
                {
                    queryStr.Add("limit", filter.Limit.ToString());
                }
                if (filter.Offset != null)
                {
                    queryStr.Add("offset", filter.Offset.ToString());
                }
                if (!String.IsNullOrWhiteSpace(filter.StartDate))
                {
                    queryStr.Add("startDate", filter.StartDate);
                }
                if (!String.IsNullOrWhiteSpace(filter.EndDate))
                {
                    queryStr.Add("endDate", filter.EndDate);
                }
            }

            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/refunds"),
                queryString: queryStr
            );
        }

        /// <summary>
        /// Get matching verifications
        /// </summary>
        /// <param name="verify"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Pagerator<Verification> GetVerifications(Verification verify = null, Filter filter = null)
        {
            var request = GetVerificationsInternal(verify, filter);
            dynamic response = _client.ProcessRequest(request);

            return new Pagerator<Verification>(_client, typeof(Verification), response);
        }

        public async Task<Pagerator<Verification>> GetVerificationsAsync(Verification verify = null, Filter filter = null)
        {
            var request = GetVerificationsInternal(verify,filter);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Pagerator<Verification>(_client, typeof(Verification), response);
        }

        private Request GetVerificationsInternal(Verification verify = null, Filter filter = null)
        {
            Dictionary<String, String> queryStr = new Dictionary<String, String>();
            if (verify != null && !String.IsNullOrWhiteSpace(verify.MerchantRefNum()))
            {
                queryStr.Add("merchantRefNum", verify.MerchantRefNum());
            }
            if (filter != null)
            {
                if (filter.Limit != null)
                {
                    queryStr.Add("limit", filter.Limit.ToString());
                }
                if (filter.Offset != null)
                {
                    queryStr.Add("offset", filter.Offset.ToString());
                }
                if (!String.IsNullOrWhiteSpace(filter.StartDate))
                {
                    queryStr.Add("startDate", filter.StartDate);
                }
                if (!String.IsNullOrWhiteSpace(filter.EndDate))
                {
                    queryStr.Add("endDate", filter.EndDate);
                }
            }

            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/verifications"),
                queryString: queryStr
            );
        }

        private string PrepareUri(string path)
        {
            if (String.IsNullOrWhiteSpace(_client.Account()))
            {
                throw new PaysafeException("Missing or invalid account");
            }
            return _uri + "/accounts/" + _client.Account() + path;
        }
    }
}
