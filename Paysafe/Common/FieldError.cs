﻿/*
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

using System.Collections.Generic;

namespace Paysafe.Common
{
    /// <summary>
    /// Used to get field error messages
    /// </summary>
    public class FieldError: JsonObject
    {
        /// <summary>
        /// Initialize the FieldError object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public FieldError(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
         {
             {GlobalConstants.Field, StringType},
             {GlobalConstants.Error, StringType}
         };

        /// <summary>
        /// Get the field
        /// </summary>
        /// <returns>string</returns>
        public string Field()
        {
            return GetProperty(GlobalConstants.Field);
        }

        /// <summary>
        /// Set the expiry field
        /// </summary>
        /// <param name=data>string</param>
        /// <returns>void</returns>
        public void Field(string data)
        {
            SetProperty(GlobalConstants.Field, data);
        }

        /// <summary>
        /// Get the expiry error
        /// </summary>
        /// <returns>string</returns>
        public string Error()
        {
            return GetProperty(GlobalConstants.Error);
        }

        /// <summary>
        /// Set the expiry error
        /// </summary>
        /// <param name=data>string</param>
        /// <returns>void</returns>
        public void Error(string data)
        {
            SetProperty(GlobalConstants.Error, data);
        }
    }
}
