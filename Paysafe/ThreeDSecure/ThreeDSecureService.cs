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

        /// <summary>
        /// Submit an enrollment lookup request
        /// </summary>
        /// <param name="EnrollmentLookups">EnrollmentLookups</param>
        /// <returns>EnrollmentLookups</returns>
        public EnrollmentChecks Submit(EnrollmentChecks enrollmentChecks)
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

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/accounts/" + _client.Account() +"/enrollmentchecks"),
                body: enrollmentChecks
            );
            dynamic response = _client.ProcessRequest(request);

            return new EnrollmentChecks(response);
        }

        /// <summary>
        /// Get the Enrollment Lookup
        /// </summary>
        /// <param name="auth">EnrollmentLookups</param>
        /// <returns>EnrollmentLookups</returns>
        public EnrollmentChecks Get(EnrollmentChecks enrollmentChecks)
        {
            enrollmentChecks.SetRequiredFields(new List<string> { GlobalConstants.Id });
            enrollmentChecks.CheckRequiredFields();

            Request request = new Request(
                uri: PrepareUri("/accounts/" + _client.Account() + "/enrollmentchecks/" + enrollmentChecks.Id())
            );

            dynamic response = _client.ProcessRequest(request);

            return new EnrollmentChecks(response);
        }

        /// <summary>
        /// Submit an authentications request
        /// </summary>
        /// <param name="Authentications">Authentications</param>
        /// <returns>Authentications</returns>
        public Authentications Submit(Authentications authentications)
        {
            authentications.SetRequiredFields(new List<string> {
                GlobalConstants.MerchantRefNum,
                GlobalConstants.PaResp,
            });

            authentications.CheckRequiredFields();                     
            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/accounts/" + _client.Account() + "/enrollmentchecks/" + authentications.EnrollmentId() + "/authentications"),
                body: authentications
            );
            dynamic response = _client.ProcessRequest(request);

            return new Authentications(response);
        }

        /// <summary>
        /// Get an authentication usind id
        /// </summary>
        /// <param name="auth">Authentications</param>
        /// <returns>Authentications</returns>
        public Authentications Get(Authentications authentications, bool includeEnrollment = false)
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

            Request request = new Request(
                uri: PrepareUri("/accounts/" + _client.Account() + "/authentications/" + authentications.Id()),
                queryString : queryStr
            );

            dynamic response = _client.ProcessRequest(request);

            return new Authentications(response);
        }

        private string PrepareUri(string path)
        {
            return _uri + path;
        }
    }
}
