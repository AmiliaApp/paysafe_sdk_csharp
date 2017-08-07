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
    public class OptError: JsonObject
    {
        /// <summary>
        /// Initialize the Error object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public OptError(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
         {
             {GlobalConstants.Code, StringType},
             {GlobalConstants.Message, StringType},
             {GlobalConstants.Details, typeof(List<string>)},
             {GlobalConstants.FieldErrors, typeof(List<FieldError>)},
             {GlobalConstants.Links, typeof(List<Link>)}
         };

        /// <summary>
        /// Get the code
        /// </summary>
        /// <returns>string</returns>
        public string Code()
        {
            return GetProperty(GlobalConstants.Code);
        }

        /// <summary>
        /// Set the code
        /// </summary>
        /// <returns>void</returns>
        public void Code(string data)
        {
            SetProperty(GlobalConstants.Code, data);
        }

        /// <summary>
        /// Get the message
        /// </summary>
        /// <returns>string</returns>
        public string Message()
        {
            return GetProperty(GlobalConstants.Message);
        }

        /// <summary>
        /// Set the message
        /// </summary>
        /// <returns>void</returns>
        public void Message(string data)
        {
            SetProperty(GlobalConstants.Message, data);
        }

        /// <summary>
        /// Get the details
        /// </summary>
        /// <returns>Array</returns>
        public List<string> Details()
        {
            return GetProperty(GlobalConstants.Details);
        }

        /// <summary>
        /// Set the details
        /// </summary>
        /// <returns>Array of strings</returns>
        public void Details(List<string> data)
        {
            SetProperty(GlobalConstants.Details, data);
        }

        /// <summary>
        /// Get the fieldErrors
        /// </summary>
        /// <returns>array of strings</returns>
        public List<FieldError> FieldErrors()
        {
            return GetProperty(GlobalConstants.FieldErrors);
        }

        /// <summary>
        /// Set the fieldErrors
        /// </summary>
        /// <returns>void</returns>
        public void FieldErrors(Array data)
        {
            SetProperty(GlobalConstants.FieldErrors, data);
        }

        /// <summary>
        /// Get the links
        /// </summary>
        /// <returns>Array of Paysafe.Common.Link</returns>
        public List<Link> Links()
        {
            return GetProperty(GlobalConstants.Links);
        }

        /// <summary>
        /// Set the links
        /// </summary>
        /// <returns>void</returns>
        public void Links(List<Link> data)
        {
            SetProperty(GlobalConstants.Links, data);
        }
    }
}
