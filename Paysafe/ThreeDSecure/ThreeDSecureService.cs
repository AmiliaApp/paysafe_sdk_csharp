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
using System.Text;
using System.Threading.Tasks;
using Paysafe.Common;

namespace Paysafe.ThreeDSecure
{
    //Created by Tushar.Sukhiya on 03.05.2016. This is ThreeDSecureService class
    public class ThreeDSecureService
    {
        /// <summary>
        /// The api client, performs all http requests
        /// </summary>
        private readonly PaysafeApiClient _client;

        /// <summary>
        /// The ThreeDSecure api base uri 
        /// </summary>
        private string _uri = "threedsecure/v1";

        /// <summary>
        /// Initialize the ThreeDSecure service with an client object
        /// </summary>
        /// <param name="client">PaysafeApiClient</param>
        public ThreeDSecureService(PaysafeApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Check if the service is available
        /// </summary>
        /// <returns>true if successful</returns>
        public Boolean Monitor()
        {
            Request request = new Request(uri: "threedsecure/monitor");
            dynamic response = _client.ProcessRequest(request);

            return ("READY".Equals((string)(response[GlobalConstants.Status])));
        }

        public async Task<bool> MonitorAsync()
        {
            Request request = new Request(uri: "threedsecure/monitor");
            dynamic response = await _client.ProcessRequestAsync(request);

            return ("READY".Equals((string)(response[GlobalConstants.Status])));
        }

        /// <summary>
        /// Submit an enrollment lookup request
        /// </summary>
        /// <param name="enrollmentChecks"></param>
        /// <returns>EnrollmentChecks</returns>
        public EnrollmentChecks Submit(EnrollmentChecks enrollmentChecks)
        {
            var request = SubmitInternal(enrollmentChecks);
            dynamic response = _client.ProcessRequest(request);

            return new EnrollmentChecks(response);
        }

        public async Task<EnrollmentChecks> SubmitAsync(EnrollmentChecks enrollmentChecks)
        {
            var request = SubmitInternal(enrollmentChecks);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new EnrollmentChecks(response);
        }

        private Request SubmitInternal(EnrollmentChecks enrollmentChecks)
        {
            enrollmentChecks.SetRequiredFields(new List<string> {
                GlobalConstants.MerchantRefNum,
                GlobalConstants.Amount,
                GlobalConstants.Currency,
                GlobalConstants.Card,
                GlobalConstants.CustomerIp,
                GlobalConstants.UserAgent,
                GlobalConstants.AcceptHeader,
                GlobalConstants.MerchantUrl
            });

            enrollmentChecks.CheckRequiredFields();

            return new Request(
                method: RequestType.Post,
                uri: PrepareUri("/accounts/" + _client.Account() + "/enrollmentchecks"),
                body: enrollmentChecks
            );
        }

        /// <summary>
        /// Get the Enrollment Lookup
        /// </summary>
        /// <param name="auth">EnrollmentLookups</param>
        /// <returns>EnrollmentLookups</returns>
        public EnrollmentChecks Get(EnrollmentChecks enrollmentChecks)
        {
            var request = GetInternal(enrollmentChecks);
            dynamic response = _client.ProcessRequest(request);

            return new EnrollmentChecks(response);
        }

        public async Task<EnrollmentChecks> GetAsync(EnrollmentChecks enrollmentChecks)
        {
            var request = GetInternal(enrollmentChecks);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new EnrollmentChecks(response);
        }

        private Request GetInternal(EnrollmentChecks enrollmentChecks)
        {
            enrollmentChecks.SetRequiredFields(new List<string> { GlobalConstants.Id });
            enrollmentChecks.CheckRequiredFields();

            return new Request(
                uri: PrepareUri("/accounts/" + _client.Account() + "/enrollmentchecks/" + enrollmentChecks.Id())
            );
        }

        /// <summary>
        /// Submit an authentications request
        /// </summary>
        /// <param name="Authentications">Authentications</param>
        /// <returns>Authentications</returns>
        public Authentications Submit(Authentications authentications)
        {
            var request = SubmitInternal(authentications);
            dynamic response = _client.ProcessRequest(request);

            return new Authentications(response);
        }

        public async Task<Authentications> SubmitAsync(Authentications authentications)
        {
            var request = SubmitInternal(authentications);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Authentications(response);
        }

        private Request SubmitInternal(Authentications authentications)
        {
            authentications.SetRequiredFields(new List<string> {
                GlobalConstants.MerchantRefNum,
                GlobalConstants.PaResp,
            });

            authentications.CheckRequiredFields();
            return new Request(
                method: RequestType.Post,
                uri: PrepareUri("/accounts/" + _client.Account() + "/enrollmentchecks/" + authentications.EnrollmentId() + "/authentications"),
                body: authentications
            );
        }

        /// <summary>
        /// Get an authentication usind id
        /// </summary>
        /// <param name="auth">Authentications</param>
        /// <returns>Authentications</returns>
        public Authentications Get(Authentications authentications, bool includeEnrollment = false)
        {
            var request = GetInternal(authentications, includeEnrollment);
            dynamic response = _client.ProcessRequest(request);

            return new Authentications(response);
        }

        public async Task<Authentications> GetAsync(Authentications authentications, bool includeEnrollment = false)
        {
            var request = GetInternal(authentications, includeEnrollment);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Authentications(response);
        }

        private Request GetInternal(Authentications authentications, bool includeEnrollment)
        {
            authentications.SetRequiredFields(new List<string> { GlobalConstants.Id });
            authentications.CheckRequiredFields();

            Dictionary<string, string> queryStr = new Dictionary<string, string>();
            StringBuilder toInclude = new StringBuilder();

            if (includeEnrollment)
            {
                toInclude.Append("enrollmentchecks");
            }
            queryStr.Add("fields", toInclude.ToString());

            return new Request(
                uri: PrepareUri("/accounts/" + _client.Account() + "/authentications/" + authentications.Id()),
                queryString: queryStr
            );
        }

        private string PrepareUri(string path)
        {
            return _uri + path;
        }
    }
}
