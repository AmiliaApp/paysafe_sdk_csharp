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
		
            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/auths"),
                body: auth
            );
            dynamic response = _client.ProcessRequest(request);

            return new Authorization(response);
        }

        public async Task<Authorization> AuthorizeAsync(Authorization auth)
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

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/auths"),
                body: auth
            );
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Authorization(response);
        }

        /// <summary>
        /// Cancel the Authorization
        /// </summary>
        /// <param name="auth">Authorization</param>
        /// <returns>Authorization</returns>
        public Authorization CancelHeldAuth(Authorization auth)
        {
            auth.SetRequiredFields(new List<string> {GlobalConstants.Id});
            auth.CheckRequiredFields();

            Authorization tmpAuth = new Authorization();
            tmpAuth.Status("CANCELLED");

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/auths/" + auth.Id()),
                body: tmpAuth
            );

            dynamic response = _client.ProcessRequest(request);

            return new Authorization(response);
        }

        public async Task<Authorization> CancelHeldAuthAsync(Authorization auth)
        {
            auth.SetRequiredFields(new List<string> { GlobalConstants.Id });
            auth.CheckRequiredFields();

            Authorization tmpAuth = new Authorization();
            tmpAuth.Status("CANCELLED");

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/auths/" + auth.Id()),
                body: tmpAuth
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Authorization(response);
        }

        /// <summary>
        /// Approve
        /// </summary>
        /// <param name="auth">Authorization</param>
        /// <returns>Authorization</returns>
        public Authorization ApproveHeldAuth(Authorization auth)
        {
            auth.SetRequiredFields(new List<string> {GlobalConstants.Id});

            auth.CheckRequiredFields();

            Authorization tmpAuth = new Authorization();
            tmpAuth.Status("COMPLETED");

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/auths/" + auth.Id()),
                body: tmpAuth
            );

            dynamic response = _client.ProcessRequest(request);

            return new Authorization(response);
        }

        public async Task<Authorization> ApproveHeldAuthAsync(Authorization auth)
        {
            auth.SetRequiredFields(new List<string> { GlobalConstants.Id });

            auth.CheckRequiredFields();

            Authorization tmpAuth = new Authorization();
            tmpAuth.Status("COMPLETED");

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/auths/" + auth.Id()),
                body: tmpAuth
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Authorization(response);
        }

        /// <summary>
        /// Reverse
        /// </summary>
        /// <param name="authReversal">AuthorizationReversal</param>
        /// <returns>AuthorizationReversal</returns>
        public AuthorizationReversal ReverseAuth(AuthorizationReversal authReversal)
        {
            authReversal.SetRequiredFields(new List<string> {GlobalConstants.AuthorizationId});
            authReversal.CheckRequiredFields();
            authReversal.SetRequiredFields(new List<string> {GlobalConstants.MerchantRefNum});
            authReversal.SetOptionalFields(new List<string> {
                GlobalConstants.Amount,
                GlobalConstants.DupCheck
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/auths/" + authReversal.AuthorizationId() + "/voidauths"),
                body: authReversal
            );

            dynamic response = _client.ProcessRequest(request);

            return new AuthorizationReversal(response);
        }

        public async Task<AuthorizationReversal> ReverseAuthAsync(AuthorizationReversal authReversal)
        {
            authReversal.SetRequiredFields(new List<string> { GlobalConstants.AuthorizationId });
            authReversal.CheckRequiredFields();
            authReversal.SetRequiredFields(new List<string> { GlobalConstants.MerchantRefNum });
            authReversal.SetOptionalFields(new List<string> {
                GlobalConstants.Amount,
                GlobalConstants.DupCheck
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/auths/" + authReversal.AuthorizationId() + "/voidauths"),
                body: authReversal
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new AuthorizationReversal(response);
        }

        /// <summary>
        /// Settlement
        /// </summary>
        /// <param name="settlement">Settlement</param>
        /// <returns>Settlement</returns>
        public Settlement Settlement(Settlement settle)
        {
            settle.SetRequiredFields(new List<string> { GlobalConstants.AuthorizationId });
            settle.CheckRequiredFields();
            settle.SetRequiredFields(new List<string> { GlobalConstants.MerchantRefNum });
            settle.SetOptionalFields(new List<string> {
                GlobalConstants.Amount,
                GlobalConstants.DupCheck
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/auths/" + settle.AuthorizationId() + "/settlements"),
                body: settle
            );

            dynamic response = _client.ProcessRequest(request);

            return new Settlement(response);
        }

        public async Task<Settlement> SettlementAsync(Settlement settle)
        {
            settle.SetRequiredFields(new List<string> { GlobalConstants.AuthorizationId });
            settle.CheckRequiredFields();
            settle.SetRequiredFields(new List<string> { GlobalConstants.MerchantRefNum });
            settle.SetOptionalFields(new List<string> {
                GlobalConstants.Amount,
                GlobalConstants.DupCheck
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/auths/" + settle.AuthorizationId() + "/settlements"),
                body: settle
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Settlement(response);
        }

        /// <summary>
        /// Cancel Settlement
        /// </summary>
        /// <param name="settlement">Settlement</param>
        /// <returns>Settlement</returns>
        public Settlement CancelSettlement(Settlement settle)
        {
            settle.SetRequiredFields(new List<string> { GlobalConstants.Id });
            settle.CheckRequiredFields();

            Settlement tmpSettlement = new Settlement();
            tmpSettlement.Status("CANCELLED");

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/settlements/" + settle.Id()),
                body: tmpSettlement
            );

            dynamic response = _client.ProcessRequest(request);

            return new Settlement(response);
        }

        public async Task<Settlement> CancelSettlementAsync(Settlement settle)
        {
            settle.SetRequiredFields(new List<string> { GlobalConstants.Id });
            settle.CheckRequiredFields();

            Settlement tmpSettlement = new Settlement();
            tmpSettlement.Status("CANCELLED");

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/settlements/" + settle.Id()),
                body: tmpSettlement
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Settlement(response);
        }

        /// <summary>
        /// Refund
        /// </summary>
        /// <param name="refund">Refund</param>
        /// <returns>Refund</returns>
        public Refund Refund(Refund newRefund)
        {
            newRefund.SetRequiredFields(new List<string> { GlobalConstants.SettlementId });
            newRefund.CheckRequiredFields();
            newRefund.SetRequiredFields(new List<string> { GlobalConstants.MerchantRefNum });
            newRefund.SetOptionalFields(new List<string> {
                GlobalConstants.Amount,
                GlobalConstants.DupCheck
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/settlements/" + newRefund.SettlementId() + "/refunds"),
                body: newRefund
            );

            dynamic response = _client.ProcessRequest(request);

            return new Refund(response);
        }

        public async Task<Refund> RefundAsync(Refund newRefund)
        {
            newRefund.SetRequiredFields(new List<string> { GlobalConstants.SettlementId });
            newRefund.CheckRequiredFields();
            newRefund.SetRequiredFields(new List<string> { GlobalConstants.MerchantRefNum });
            newRefund.SetOptionalFields(new List<string> {
                GlobalConstants.Amount,
                GlobalConstants.DupCheck
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/settlements/" + newRefund.SettlementId() + "/refunds"),
                body: newRefund
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Refund(response);
        }

        /// <summary>
        /// Cancel Refund
        /// </summary>
        /// <param name="refund">Refund</param>
        /// <returns>Refund</returns>
        public Refund CancelRefund(Refund refund)
        {
            refund.SetRequiredFields(new List<string> { GlobalConstants.Id });
            refund.CheckRequiredFields();

            Refund tmpRefund = new Refund();
            tmpRefund.Status("CANCELLED");

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/refunds/" + refund.Id()),
                body: tmpRefund
            );

            dynamic response = _client.ProcessRequest(request);

            return new Refund(response);
        }

        public async Task<Refund> CancelRefundAsync(Refund refund)
        {
            refund.SetRequiredFields(new List<string> { GlobalConstants.Id });
            refund.CheckRequiredFields();

            Refund tmpRefund = new Refund();
            tmpRefund.Status("CANCELLED");

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/refunds/" + refund.Id()),
                body: tmpRefund
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Refund(response);
        }

        /// <summary>
        /// Verify
        /// </summary>
        /// <param name="verify">Verification</param>
        /// <returns>Verificationd</returns>
        public Verification Verify(Verification verification)
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

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/verifications"),
                body: verification
            );

            dynamic response = _client.ProcessRequest(request);

            return new Verification(response);
        }

        public async Task<Verification> VerifyAsync(Verification verification)
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

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/verifications"),
                body: verification
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Verification(response);
        }

        /// <summary>
        /// Get the authorization
        /// </summary>
        /// <param name="auth">Authorization</param>
        /// <returns>Authorization</returns>
        public Authorization Get(Authorization auth)
        {
            auth.SetRequiredFields(new List<string> { GlobalConstants.Id });
            auth.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/auths/" + auth.Id())
            );

            dynamic response = _client.ProcessRequest(request);

            return new Authorization(response);
        }

        public async Task<Authorization> GetAsync(Authorization auth)
        {
            auth.SetRequiredFields(new List<string> { GlobalConstants.Id });
            auth.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/auths/" + auth.Id())
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Authorization(response);
        }

        /// <summary>
        /// Get the AuthorizationReversal
        /// </summary>
        /// <param name="authReversal">AuthorizationReversal</param>
        /// <returns>AuthorizationReversal</returns>
        public AuthorizationReversal Get(AuthorizationReversal authReversal)
        {
            authReversal.SetRequiredFields(new List<string> { GlobalConstants.Id });
            authReversal.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/voidauths/" + authReversal.Id())
            );

            dynamic response = _client.ProcessRequest(request);

            return new AuthorizationReversal(response);
        }

        public async Task<AuthorizationReversal> GetAsync(AuthorizationReversal authReversal)
        {
            authReversal.SetRequiredFields(new List<string> { GlobalConstants.Id });
            authReversal.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/voidauths/" + authReversal.Id())
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new AuthorizationReversal(response);
        }

        /// <summary>
        /// Get the Settlement
        /// </summary>
        /// <param name="settlement">Settlement</param>
        /// <returns>Settlement</returns>
        public Settlement Get(Settlement settlement)
        {
            settlement.SetRequiredFields(new List<string> { GlobalConstants.Id });
            settlement.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/settlements/" + settlement.Id())
            );

            dynamic response = _client.ProcessRequest(request);

            return new Settlement(response);
        }

        public async Task<Settlement> GetAsync(Settlement settlement)
        {
            settlement.SetRequiredFields(new List<string> { GlobalConstants.Id });
            settlement.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/settlements/" + settlement.Id())
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Settlement(response);
        }

        /// <summary>
        /// Get the Refund
        /// </summary>
        /// <param name="refund">Refund</param>
        /// <returns>Refund</returns>
        public Refund Get(Refund refund)
        {
            refund.SetRequiredFields(new List<string> { GlobalConstants.Id });
            refund.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/refunds/" + refund.Id())
            );

            dynamic response = _client.ProcessRequest(request);

            return new Refund(response);
        }

        public async Task<Refund> GetAsync(Refund refund)
        {
            refund.SetRequiredFields(new List<string> { GlobalConstants.Id });
            refund.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/refunds/" + refund.Id())
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Refund(response);
        }

        /// <summary>
        /// Get the verification
        /// </summary>
        /// <param name="verification">Verification</param>
        /// <returns>Verification</returns>
        public Verification Get(Verification verify)
        {
            verify.SetRequiredFields(new List<string> { GlobalConstants.Id });
            verify.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/verifications/" + verify.Id())
            );

            dynamic response = _client.ProcessRequest(request);

            return new Verification(response);
        }

        public async Task<Verification> GetAsync(Verification verify)
        {
            verify.SetRequiredFields(new List<string> { GlobalConstants.Id });
            verify.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/verifications/" + verify.Id())
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Verification(response);
        }

        /// <summary>
        /// Get matching authorizations
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Pagerator<Authorization> GetAuths(Authorization auth = null, Filter filter = null)
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

            Request request = new Request(
                    method: RequestType.Get,
                    uri: PrepareUri("/auths"),
                    queryString: queryStr
            );

            dynamic response = _client.ProcessRequest(request);

            return new Pagerator<Authorization>(_client, typeof(Authorization), response);
        }

        public async Task<Pagerator<Authorization>> GetAuthsAsync(Authorization auth = null, Filter filter = null)
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

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/auths"),
                queryString: queryStr
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Pagerator<Authorization>(_client, typeof(Authorization), response);
        }

        /// <summary>
        /// Get matching authorization reversals
        /// </summary>
        /// <param name="authReversal"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Pagerator<AuthorizationReversal> GetAuthReversals(AuthorizationReversal authReversal = null, Filter filter = null)
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

            Request request = new Request(
                    method: RequestType.Get,
                    uri: PrepareUri("/voidauths"),
                    queryString: queryStr
            );

            dynamic response = _client.ProcessRequest(request);

            return new Pagerator<AuthorizationReversal>(_client, typeof(AuthorizationReversal), response);
        }

        public async Task<Pagerator<AuthorizationReversal>> GetAuthReversalsAsync(AuthorizationReversal authReversal = null, Filter filter = null)
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

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/voidauths"),
                queryString: queryStr
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Pagerator<AuthorizationReversal>(_client, typeof(AuthorizationReversal), response);
        }

        /// <summary>
        /// Get matching settlements
        /// </summary>
        /// <param name="settlement"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Pagerator<Settlement> GetSettlements(Settlement settlement = null, Filter filter = null)
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

            Request request = new Request(
                    method: RequestType.Get,
                    uri: PrepareUri("/settlements"),
                    queryString: queryStr
            );

            dynamic response = _client.ProcessRequest(request);

            return new Pagerator<Settlement>(_client, typeof(Settlement), response);
        }

        public async Task<Pagerator<Settlement>> GetSettlementsAsync(Settlement settlement = null, Filter filter = null)
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

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/settlements"),
                queryString: queryStr
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Pagerator<Settlement>(_client, typeof(Settlement), response);
        }

        /// <summary>
        /// Get matching refunds
        /// </summary>
        /// <param name="refund"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Pagerator<Refund> GetRefunds(Refund refund = null, Filter filter = null)
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

            Request request = new Request(
                    method: RequestType.Get,
                    uri: PrepareUri("/refunds"),
                    queryString: queryStr
            );

            dynamic response = _client.ProcessRequest(request);

            return new Pagerator<Refund>(_client, typeof(Refund), response);
        }

        public async Task<Pagerator<Refund>> GetRefundsAsync(Refund refund = null, Filter filter = null)
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

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/refunds"),
                queryString: queryStr
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Pagerator<Refund>(_client, typeof(Refund), response);
        }

        /// <summary>
        /// Get matching verifications
        /// </summary>
        /// <param name="verify"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Pagerator<Verification> GetVerifications(Verification verify = null, Filter filter = null)
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

            Request request = new Request(
                    method: RequestType.Get,
                    uri: PrepareUri("/verifications"),
                    queryString: queryStr
            );

            dynamic response = _client.ProcessRequest(request);

            return new Pagerator<Verification>(_client, typeof(Verification), response);
        }

        public async Task<Pagerator<Verification>> GetVerificationsAsync(Verification verify = null, Filter filter = null)
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

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/verifications"),
                queryString: queryStr
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Pagerator<Verification>(_client, typeof(Verification), response);
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
