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

namespace Paysafe.Common
{
    public class Request
    {
        /// <summary>
        /// The uri to be accessed for this request
        /// </summary>
        private readonly String _uri;
        
        /// <summary>
        /// The type of request to be perfomed (GET/POST/DELETE/PUT)
        /// </summary>
        private readonly RequestType _requestMethod;

        /// <summary>
        /// The JSONObject to send as the request body
        /// </summary>
        private readonly JsonObject _requestBody;

        /// <summary>
        /// Any additional query string parameters to be sent
        /// </summary>
        private readonly Dictionary<String, String> _queryString;

        /// <summary>
        /// Allow the full url to be specified rather than the uri
        /// </summary>
        private readonly String _url;

        public Request(String uri = "", Dictionary<String, String> queryString = null, RequestType method = RequestType.Get, JsonObject body = null, String url = null)
        {
            _uri = uri;
            _requestMethod = method;
            _requestBody = body;
            _queryString = queryString;
            _url = url;
        }

        /// <summary>
        /// Build url for the Paysafe api client
        /// </summary>
        /// <param name="apiEndPoint">string</param>
        /// <returns>string</returns>
        public String BuildUrl(String apiEndPoint)
        {
            if(null == _url) {
                return apiEndPoint + '/' + _uri + BuildQueryString();
            }
            if (_url.IndexOf(apiEndPoint, StringComparison.CurrentCulture) != 0)
            {
                throw new PaysafeException("Unexpected endpoint in url: " + _url + " expected: " + apiEndPoint);
            }
            return _url;
        }

        /// <summary>
        /// Builds the query string if applicable
        /// </summary>
        /// <returns>string</returns>
        private String BuildQueryString()
        {
            String response = "";
            if(_queryString != null && _queryString.Count > 0) {
                if (_uri != null && _uri.IndexOf("?", StringComparison.CurrentCulture) >= 0)
                {
                    response += "&";
                } else {
                    response += "?";
                }
                foreach (KeyValuePair<String, String> entry in _queryString)
                {
                    if (response.Length > 1)
                    {
                        response += '&';
                    }
                    response += entry.Key + '=' + Uri.EscapeDataString(entry.Value);
                }
                
            }
            return response;
        }

        /// <summary>
        /// Get the type fo request to be performed
        /// </summary>
        /// <returns></returns>
        public string Method()
        {
            return _requestMethod.ToString();
        }

        /// <summary>
        /// returns the JSON encoded body object
        /// </summary>
        /// <returns></returns>
        public string Body()
        {
            return _requestBody?.ToString();
        }
    }
}
