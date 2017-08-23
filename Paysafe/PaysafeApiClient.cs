/*
 * Copyright (c) 2014 Paysafe Payments
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
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using CardPaymentService = Paysafe.CardPayments.CardPaymentService;
using CustomerVaultService = Paysafe.CustomerVault.CustomerVaultService;
using DirectDebitService = Paysafe.DirectDebit.DirectDebitService;
using ThreeDSecureService = Paysafe.ThreeDSecure.ThreeDSecureService;
using Paysafe.Common;

[assembly: CLSCompliant(true)]

namespace Paysafe
{
    public class PaysafeApiClient
    {
        /// <summary>
        /// The api key id
        /// </summary>
        private String _apiKeyId;

        /// <summary>
        /// The api key passsword
        /// </summary>
        private String _apiKeyPassword;

        /// <summary>
        /// The api environment (test/live)
        /// </summary>
        private Environment _apiEnvironment;

        /// <summary>
        /// The merchant account (used only by the CardPayments api)
        /// </summary>
        private String _apiAccount;

        /// <summary>
        /// The api endpoint to which all requests should be sent
        /// </summary>
        private String _apiEndPoint;

        /// <summary>
        /// Initialize the api client.
        /// </summary>
        /// <param name="keyId">string</param>
        /// <param name="keyPassword">string</param>
        /// <param name="environment">Environment</param>
        /// <param name="account">string</param>
        public PaysafeApiClient(string keyId, string keyPassword, Environment environment, string account = "")
        {
            ApiKey(keyId);
            ApiPassword(keyPassword);
            Environment(environment);
            Account(account);
        }

        /// <summary>
        /// Sets the api key id
        /// </summary>
        /// <param name="newKeyId">string</param>
        protected void ApiKey(string newKeyId)
        {
            if (newKeyId == null)
            {
                throw new PaysafeException("You must specify an API Key");
            }
            _apiKeyId = newKeyId;
        }

        /// <summary>
        /// Sets the api key password
        /// </summary>
        /// <param name="newKeyPassword">string</param>
        protected void ApiPassword(string newKeyPassword)
        {
            if (newKeyPassword == null)
            {
                throw new PaysafeException("You must specify an API Password");
            }
            _apiKeyPassword = newKeyPassword;
        }

        /// <summary>
        /// Sets the environment, and api endpoint
        /// </summary>
        /// <param name="newEnvironment">Environment</param>
        protected void Environment(Environment newEnvironment)
        {
            _apiEnvironment = newEnvironment;

            if (_apiEnvironment == Paysafe.Environment.Test)
            {
                _apiEndPoint = "https://api.test.netbanx.com";
            }
            else
            {
                _apiEndPoint = "https://api.netbanx.com";
            }

        }

        /// <summary>
        /// Sets the merchant account number for use with the card payments api
        /// </summary>
        /// <param name="account">string</param>
        public void Account(string newAccount)
        {
            _apiAccount = newAccount;
        }

        /// <summary>
        /// Get the merchant account number
        /// </summary>
        /// <returns>string</returns>
        public String Account()
        {
            return _apiAccount;
        }

        /// <summary>
        /// Get an instance of the card payment service
        /// </summary>
        /// <returns>CardPaymentService</returns>
        public CardPaymentService cardPaymentService()
        {
            return new CardPaymentService(this);
        }

        /// <summary>
        /// Get an instance of the customer vault service
        /// </summary>
        /// <returns>CustomerVaultService</returns>
        public CustomerVaultService customerVaultService()
        {
            return new CustomerVaultService(this);
        }



        /// <summary>
        /// Get an instance of the Direct debit service
        /// </summary>
        /// <returns>DirectDebitService</returns>
        public DirectDebitService directDebitService()

        {
            return new DirectDebitService(this);
        }

        /// <summary>
        /// Get an instance of the ThreeDSecure service
        /// </summary>
        /// <returns>ThreeDSecureService</returns>
        public ThreeDSecureService threeDSecureService()
        {
            return new ThreeDSecureService(this);
        }

        /// <summary>
        /// Returns the base64 encoded authentication string for the http request headers
        /// </summary>
        /// <returns>string</returns>
        private string GetAuthString()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(_apiKeyId + ":" + _apiKeyPassword));
        }

        /// <summary>
        /// This method will perform a the http request synchronously, and return the json decoded result
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Dictionary<string,object></returns>
        public Dictionary<string, object> ProcessRequest(Request request)
        {
            HttpWebRequest conn = (HttpWebRequest) WebRequest.CreateHttp(request.BuildUrl(_apiEndPoint));
            conn.Headers["Authorization"] = "Basic " + GetAuthString();
            conn.ContentType = "application/json; charset=utf-8";

            conn.Method = request.Method();
            if (request.Method().Equals(RequestType.Post.ToString())
                || request.Method().Equals(RequestType.Put.ToString()))
            {
                string requestBody = request.Body();
                byte[] requestData = Encoding.UTF8.GetBytes(requestBody);

                var resultRequest = conn.BeginGetRequestStream(null, null);
                Stream postStream = conn.EndGetRequestStream(resultRequest);
                postStream.Write(requestData, 0, requestData.Length);
                postStream.Dispose();
            }

            try
            {
                var responseRequest = conn.BeginGetResponse(null, null);
                WebResponse responseObject = conn.EndGetResponse(responseRequest);

                StreamReader sr = new StreamReader(responseObject.GetResponseStream());
                return ParseResponse(sr.ReadToEnd());
            }
            catch (WebException ex)
            {
                HandlePaysafeExceptionSync(ex);
            }
            throw new PaysafeException("An unhandled error has occured.");
        }

        /// <summary>
        /// This method will perform a the http request asynchronously, and return the json decoded result
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Task<Dictionary<string,object>></returns>
        public async Task<Dictionary<string, object>> ProcessRequestAsync(Request request)
        {
            HttpWebRequest conn = WebRequest.CreateHttp(request.BuildUrl(_apiEndPoint));
            conn.Headers["Authorization"] = "Basic " + GetAuthString();
            conn.ContentType = "application/json; charset=utf-8";

            conn.Method = request.Method();
            if (request.Method().Equals(RequestType.Post.ToString())
                || request.Method().Equals(RequestType.Put.ToString()))
            {
                string requestBody = request.Body();
                byte[] requestData = Encoding.UTF8.GetBytes(requestBody);

                using (Stream postStream = await Task.Factory.FromAsync(
                    conn.BeginGetRequestStream(null, null),
                    asyncResult => conn.EndGetRequestStream(asyncResult)))
                {
                    postStream.Write(requestData, 0, requestData.Length);
                }
            }

            try
            {
                Task<WebResponse> responseRequest = Task.Factory.FromAsync(
                    conn.BeginGetResponse(null, null),
                    asyncResult => conn.EndGetResponse(asyncResult));

                return ParseResponse(await responseRequest);
            }
            catch (WebException ex)
            {
                await HandlePaysafeException(ex);
            }
            throw new PaysafeException("An unhandled error has occured.");
        }

        //Todo: Legacy code for synchronous method, to be removed
        public static Dictionary<string, object> ParseResponse(string response)
        {
            if (String.IsNullOrWhiteSpace(response))
            {
                return null;
            }
            return JsonHelper.Deserialize(response) as Dictionary<string, object>;
        }

        private static Dictionary<string, object> ParseResponse(WebResponse response)
        {
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader sr = new StreamReader(responseStream))
            {
                string strContent = sr.ReadToEnd();
                if (String.IsNullOrWhiteSpace(strContent))
                {
                    return null;
                }
                return JsonHelper.Deserialize(strContent) as Dictionary<string, object>;
            }
        }

        public async Task HandlePaysafeException(WebException ex)
        {
            var response = (HttpWebResponse) ex.Response;
            var statusCode = response.StatusCode;
            var sr = new StreamReader(response.GetResponseStream());
            var body = await sr.ReadToEndAsync();
            var innerException = ex.InnerException;

            string exceptionType = null;
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest: // 400
                    exceptionType = "InvalidRequestException";
                    break;
                case HttpStatusCode.Unauthorized: // 401
                    exceptionType = "InvalidCredentialsException";
                    break;
                case HttpStatusCode.PaymentRequired: //402
                    exceptionType = "RequestDeclinedException";
                    break;
                case HttpStatusCode.Forbidden: //403
                    exceptionType = "PermissionException";
                    break;
                case HttpStatusCode.NotFound: //404
                    exceptionType = "EntityNotFoundException";
                    break;
                case HttpStatusCode.Conflict: //409
                    exceptionType = "RequestConflictException";
                    break;
                case HttpStatusCode.NotAcceptable: //406
                case HttpStatusCode.UnsupportedMediaType: //415
                case HttpStatusCode.InternalServerError: //500
                case HttpStatusCode.NotImplemented: //501
                case HttpStatusCode.BadGateway: //502
                case HttpStatusCode.ServiceUnavailable: //503
                case HttpStatusCode.GatewayTimeout: //504
                case HttpStatusCode.HttpVersionNotSupported: //505
                    exceptionType = "ApiException";
                    break;
            }
            if (exceptionType != null)
            {
                String message = body;
                Dictionary<string, dynamic> rawResponse = ParseResponse(body);
                if (rawResponse.ContainsKey("error"))
                {
                    message = rawResponse["error"]["message"];
                }

                Object[] args = {message, innerException};
                PaysafeException paysafeException = Activator.CreateInstance
                    (Type.GetType("Paysafe.Common." + exceptionType), args) as PaysafeException;
                paysafeException.RawResponse(rawResponse);
                if (rawResponse.ContainsKey("error"))
                {
                    paysafeException.Code(int.Parse(rawResponse["error"]["code"]));
                }
                throw paysafeException;
            }
        }

        //Legacy code for synchronous method, to be removed
        public void HandlePaysafeExceptionSync(WebException ex)
        {
            var response = (HttpWebResponse) ex.Response;
            var statusCode = response.StatusCode;
            var sr = new StreamReader(response.GetResponseStream());
            var body = sr.ReadToEnd();
            var innerException = ex.InnerException;

            string exceptionType = null;
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest: // 400
                    exceptionType = "InvalidRequestException";
                    break;
                case HttpStatusCode.Unauthorized: // 401
                    exceptionType = "InvalidCredentialsException";
                    break;
                case HttpStatusCode.PaymentRequired: //402
                    exceptionType = "RequestDeclinedException";
                    break;
                case HttpStatusCode.Forbidden: //403
                    exceptionType = "PermissionException";
                    break;
                case HttpStatusCode.NotFound: //404
                    exceptionType = "EntityNotFoundException";
                    break;
                case HttpStatusCode.Conflict: //409
                    exceptionType = "RequestConflictException";
                    break;
                case HttpStatusCode.NotAcceptable: //406
                case HttpStatusCode.UnsupportedMediaType: //415
                case HttpStatusCode.InternalServerError: //500
                case HttpStatusCode.NotImplemented: //501
                case HttpStatusCode.BadGateway: //502
                case HttpStatusCode.ServiceUnavailable: //503
                case HttpStatusCode.GatewayTimeout: //504
                case HttpStatusCode.HttpVersionNotSupported: //505
                    exceptionType = "ApiException";
                    break;
            }
            if (exceptionType != null)
            {
                String message = body;
                Dictionary<string, dynamic> rawResponse = ParseResponse(body);
                if (rawResponse.ContainsKey("error"))
                {
                    message = rawResponse["error"]["message"];
                }

                Object[] args = {message, innerException};
                PaysafeException paysafeException = Activator.CreateInstance
                    (Type.GetType("Paysafe.Common." + exceptionType), args) as PaysafeException;
                paysafeException.RawResponse(rawResponse);
                if (rawResponse.ContainsKey("error"))
                {
                    paysafeException.Code(int.Parse(rawResponse["error"]["code"]));
                }
                throw paysafeException;
            }
        }



    }
}