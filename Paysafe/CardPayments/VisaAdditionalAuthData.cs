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
using Paysafe.Common;

namespace Paysafe.CardPayments
{
    public class VisaAdditionalAuthData : JsonObject
    {
        /// <summary>
        /// Initialize the VisaAdditionalAuthData object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public VisaAdditionalAuthData(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.RecipientDateOfBirth, typeof(RecipientDateOfBirth)},
            {GlobalConstants.RecipientZip, StringType},
            {GlobalConstants.RecipientLastName, StringType},
            {GlobalConstants.RecipientAccountNumber, StringType}
        };

        /// <summary>
        /// Get the recipientDateOfBirth
        /// </summary>
        /// <returns>string</returns>
        public string RecipientDateOfBirth()
        {
            return GetProperty(GlobalConstants.RecipientDateOfBirth);
        }

        /// <summary>
        /// Set the recipientDateOfBirth
        /// </summary>
        /// <returns>void</returns>
        public void RecipientDateOfBirth(string data)
        {
            SetProperty(GlobalConstants.RecipientDateOfBirth, data);
        }

        /// <summary>
        /// Get the recipientZip
        /// </summary>
        /// <returns>string</returns>
        public string RecipientZip()
        {
            return GetProperty(GlobalConstants.RecipientZip);
        }

        /// <summary>
        /// Set the recipientZip
        /// </summary>
        /// <returns>void</returns>
        public void RecipientZip(string data)
        {
            SetProperty(GlobalConstants.RecipientZip, data);
        }

        /// <summary>
        /// Get the recipientLastName
        /// </summary>
        /// <returns>string</returns>
        public string RecipientLastName()
        {
            return GetProperty(GlobalConstants.RecipientLastName);
        }

        /// <summary>
        /// Set the recipientLastName
        /// </summary>
        /// <returns>void</returns>
        public void RecipientLastName(string data)
        {
            SetProperty(GlobalConstants.RecipientLastName, data);
        }

        /// <summary>
        /// Get the recipientAccountNumber
        /// </summary>
        /// <returns>string</returns>
        public string RecipientAccountNumbere()
        {
            return GetProperty(GlobalConstants.RecipientAccountNumber);
        }

        /// <summary>
        /// Set the recipientAccountNumber
        /// </summary>
        /// <returns>void</returns>
        public void RecipientAccountNumber(string data)
        {
            SetProperty(GlobalConstants.RecipientAccountNumber, data);
        }
    }
}
