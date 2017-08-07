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

namespace Paysafe.Common
{
    /// <summary>
    /// Exceptions raised
    /// </summary>
    public class PaysafeException : Exception
    {
        /// <summary>
        /// </summary>
        public PaysafeException()
        {

        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        public PaysafeException(String message)
            : base(message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public PaysafeException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        private Dictionary<string, object> _rawResponse = new Dictionary<string, object>();
        private int _code = -1;

        /// <summary>
        /// Set the error data
        /// </summary>
        /// <param name="data"></param>
        public void RawResponse(Dictionary<string, object> data)
        {
            _rawResponse = data;
        }

        /// <summary>
        /// Get the Error data
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> RawResponse()
        {
            return _rawResponse;
        }

        /// <summary>
        /// Set the error code value
        /// </summary>
        /// <param name="data"></param>
        public void Code(int data)
        {
            _code = data;
        }

        /// <summary>
        /// Get the error code value
        /// </summary>
        /// <returns></returns>
        public int Code()
        {
            return _code;
        }
    }
}
