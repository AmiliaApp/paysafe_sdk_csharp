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

namespace Paysafe.DirectDebit
{
    //Created by Manjiri.Bankar on 03.05.2016. This is DirectDebitService class.
    public class DirectDebitService
    {
         /// <summary>
        /// The api client, performs all http requests
        /// </summary>
        private PaysafeApiClient _client;

        /// <summary>
        /// The direct debit api base uri 
        /// </summary>
        private string _uri = "directdebit/v1/accounts/";

        /// <summary>
        /// Initialize the direct debit service with an client object
        /// </summary>
        /// <param name="client">PaysafeApiClient</param>
        public DirectDebitService(PaysafeApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Check if the service is available
        /// </summary>
        /// <returns>true if successful</returns>
        public Boolean Monitor()
        {
            Request request = new Request(uri: "directdebit/monitor");
            dynamic response = _client.ProcessRequest(request);

            return ("READY".Equals((string)(response[GlobalConstants.Status])));
        }

        public async Task<bool> MonitorAsync()
        {
            Request request = new Request(uri: "directdebit/monitor");
            dynamic response = await _client.ProcessRequestAsync(request);

            return ("READY".Equals((string)(response[GlobalConstants.Status])));
        }

        /// <summary>
        /// Create submit for Purchases
        /// </summary>
        /// <param name="submit">submit</param>
        /// <returns>Purchases</returns>
        public Purchases Submit(Purchases purchases)
        {
            var request = SubmitInternal(purchases);
            dynamic response = _client.ProcessRequest(request);

            return new Purchases(response);
        }

        public async Task<Purchases> SubmitAsync(Purchases purchases)
        {
            var request = SubmitInternal(purchases);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Purchases(response);
        }

        private Request SubmitInternal(Purchases purchases)
        {
            purchases.SetRequiredFields(new List<string> {
                GlobalConstants.MerchantRefNum,
                GlobalConstants.Amount,
            });
            purchases.CheckRequiredFields();
            purchases.SetOptionalFields(new List<string> {
                GlobalConstants.CustomerIp,
                GlobalConstants.DupCheck,
                GlobalConstants.Ach,
                GlobalConstants.Bacs,
                GlobalConstants.Eft,
                GlobalConstants.Sepa,
                GlobalConstants.BillingDetails,
                GlobalConstants.Profile
            });
            return new Request(
                method: RequestType.Post,
                uri: PrepareUri(_client.Account() + "/purchases"),
                body: purchases
            );
        }

        /// <summary>
        /// Create submit for Standalone Credits
        /// </summary>
        /// <param name="submit">submit</param>
        /// <returns>StandaloneCredits</returns>
        public StandaloneCredits Submit(StandaloneCredits standalonecredits)
        {
            var request = SubmitInternal(standalonecredits);
            dynamic response = _client.ProcessRequest(request);

            return new StandaloneCredits(response);
        }

        public async Task<StandaloneCredits> SubmitAsync(StandaloneCredits standalonecredits)
        {
            var request = SubmitInternal(standalonecredits);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new StandaloneCredits(response);
        }

        private Request SubmitInternal(StandaloneCredits standalonecredits)
        {
            standalonecredits.SetRequiredFields(new List<string>
            {
                GlobalConstants.MerchantRefNum,
                GlobalConstants.Amount,
            });
            standalonecredits.CheckRequiredFields();
            standalonecredits.SetOptionalFields(new List<string>
            {
                GlobalConstants.CustomerIp,
                GlobalConstants.DupCheck,
                GlobalConstants.Ach,
                GlobalConstants.Bacs,
                GlobalConstants.Eft,
                GlobalConstants.BillingDetails,
                GlobalConstants.Profile,
            });
            return new Request(
                method: RequestType.Post,
                uri: PrepareUri(_client.Account() + "/standalonecredits"),
                body: standalonecredits
            );
        }

        /// <summary>
        /// Create cancel for Purchases
        /// </summary>
        /// <param name="cancel">cancel</param>
        /// <returns>Purchases</returns>
        public Purchases Cancel(Purchases purchases)
        {
            var request = CancelInternal(purchases);
            dynamic response = _client.ProcessRequest(request);

            Purchases returnVal = new Purchases(response);
            returnVal.Id(purchases.Id());
            return returnVal;
        }

        public async Task<Purchases> CancelAsync(Purchases purchases)
        {
            var request = CancelInternal(purchases);
            dynamic response = await _client.ProcessRequestAsync(request);

            Purchases returnVal = new Purchases(response);
            returnVal.Id(purchases.Id());
            return returnVal;
        }

        private Request CancelInternal(Purchases purchases)
        {
            purchases.SetRequiredFields(new List<string> {
                GlobalConstants.Status,
                GlobalConstants.Id
            });
            purchases.CheckRequiredFields();
            purchases.SetOptionalFields(new List<string>{
                GlobalConstants.Ach,
                GlobalConstants.Bacs,
                GlobalConstants.Eft,
                GlobalConstants.Sepa,
            });
            return new Request(
                method: RequestType.Put,
                uri: PrepareUri(_client.Account() + "/purchases/" + purchases.Id()),
                body: purchases
            );
        }

        /// <summary>
        /// Create cancel for Standalone Credits
        /// </summary>
        /// <param name="cancel">cancel</param>
        /// <returns>StandaloneCredits</returns>
        public StandaloneCredits Cancel(StandaloneCredits standalonecredits)
        {
            var request = CancelInternal(standalonecredits);
            dynamic response = _client.ProcessRequest(request);

            StandaloneCredits returnVal = new StandaloneCredits(response);
            returnVal.Id(standalonecredits.Id());
            return returnVal;
        }

        public async Task<StandaloneCredits> CancelAsync(StandaloneCredits standalonecredits)
        {
            var request = CancelInternal(standalonecredits);
            dynamic response = await _client.ProcessRequestAsync(request);

            StandaloneCredits returnVal = new StandaloneCredits(response);
            returnVal.Id(standalonecredits.Id());
            return returnVal;
        }

        private Request CancelInternal(StandaloneCredits standalonecredits)
        {
            standalonecredits.SetRequiredFields(new List<string> {
                GlobalConstants.Status,
                GlobalConstants.Id
            });
            standalonecredits.CheckRequiredFields();
            standalonecredits.SetOptionalFields(new List<string>{
                GlobalConstants.Ach,
                GlobalConstants.Bacs,
                GlobalConstants.Eft,
            });

            return new Request(
                method: RequestType.Put,
                uri: PrepareUri(_client.Account() + "/standalonecredits/" + standalonecredits.Id()),
                body: standalonecredits
            );
        }

        /// <summary>
        /// Create get
        /// </summary>
        /// <param name="get">get</param>
        /// <returns>Purchases</returns>
        public Purchases Get(Purchases purchase)
        {
            var request = GetInternal(purchase);
            dynamic response = _client.ProcessRequest(request);

            return new Purchases(response);
        }

        public async Task<Purchases> GetAsync(Purchases purchase)
        {
            var request = GetInternal(purchase);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Purchases(response);
        }

        private Request GetInternal(Purchases purchase)
        {
            purchase.SetRequiredFields(new List<string> {
                GlobalConstants.Id,
            });
            purchase.CheckRequiredFields();
            purchase.SetOptionalFields(new List<string>{
                GlobalConstants.Ach,
                GlobalConstants.Bacs,
                GlobalConstants.Eft,
                GlobalConstants.Sepa,
            });

            return new Request(
                method: RequestType.Get,
                uri: PrepareUri(_client.Account() + "/purchases/" + purchase.Id()),
                body: purchase
            );
        }

        /// <summary>
        /// Get matching Purchases
        /// </summary>
        /// <param name="purchases"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Pagerator<Purchases> GetPurchase(Purchases purchases = null, Filter filter = null)
        {
            var request = GetPurchaseInternal(purchases, filter);
            dynamic response = _client.ProcessRequest(request);

            return new Pagerator<Purchases>(_client, typeof(Purchases), response);
        }

        public async Task<Pagerator<Purchases>> GetPurchaseAsync(Purchases purchases = null, Filter filter = null)
        {
            var request = GetPurchaseInternal(purchases, filter);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Pagerator<Purchases>(_client, typeof(Purchases), response);
        }

        private Request GetPurchaseInternal(Purchases purchases, Filter filter)
        {
            Dictionary<String, String> queryStr = new Dictionary<String, String>();
            if (purchases != null && !String.IsNullOrWhiteSpace(purchases.MerchantRefNum()))
            {
                queryStr.Add("merchantRefNum", purchases.MerchantRefNum());
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
                uri: PrepareUri(_client.Account() + "/purchases"),
                queryString: queryStr
            );
        }

        /// <summary>
        /// Create get
        /// </summary>
        /// <param name="get">get</param>
        /// <returns>StandaloneCredits</returns>
        public StandaloneCredits Get(StandaloneCredits standalonescredits)
        {
            var request = GetInternal(standalonescredits);
            dynamic response = _client.ProcessRequest(request);

            return new StandaloneCredits(response);
        }

        public async Task<StandaloneCredits> GetAsync(StandaloneCredits standalonescredits)
        {
            var request = GetInternal(standalonescredits);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new StandaloneCredits(response);
        }

        private Request GetInternal(StandaloneCredits standalonescredits)
        {
            standalonescredits.SetRequiredFields(new List<string> {
                GlobalConstants.Id,
            });
            standalonescredits.CheckRequiredFields();
            standalonescredits.SetOptionalFields(new List<string>{
                GlobalConstants.Ach,
                GlobalConstants.Bacs,
                GlobalConstants.Eft,
            });
            return new Request(
                method: RequestType.Get,
                uri: PrepareUri(_client.Account() + "/standalonecredits/" + standalonescredits.Id()),
                body: standalonescredits
            );
        }

        /// <summary>
        /// Get matching StandaloneCredits
        /// </summary>
        /// <param name="standalonescredits"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Pagerator<StandaloneCredits> GetStandaloneCredits(StandaloneCredits standalonescredits = null, Filter filter = null)
        {
            var request = GetStandaloneCreditsInternal(standalonescredits, filter);
            dynamic response = _client.ProcessRequest(request);

            return new Pagerator<StandaloneCredits>(_client, typeof(StandaloneCredits), response);
        }

        public async Task<Pagerator<StandaloneCredits>> GetStandaloneCreditsAsync(StandaloneCredits standalonescredits = null, Filter filter = null)
        {
            var request = GetStandaloneCreditsInternal(standalonescredits, filter);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Pagerator<StandaloneCredits>(_client, typeof(StandaloneCredits), response);
        }

        private Request GetStandaloneCreditsInternal(StandaloneCredits standalonescredits, Filter filter)
        {
            Dictionary<String, String> queryStr = new Dictionary<String, String>();
            if (standalonescredits != null && !String.IsNullOrWhiteSpace(standalonescredits.MerchantRefNum()))
            {
                queryStr.Add("merchantRefNum", standalonescredits.MerchantRefNum());
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
                uri: PrepareUri(_client.Account() + "/standalonecredits"),
                queryString: queryStr
            );
        }

        private string PrepareUri(string path)
        {
            return _uri + path;
        }
    }
}
