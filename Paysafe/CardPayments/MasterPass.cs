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

using System.Collections.Generic;
using Paysafe.Common;

namespace Paysafe.CardPayments
{

    public class MasterPass : JsonObject
    {
        /// <summary>
        /// Initialize the MasterPass object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public MasterPass(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
         {
            {GlobalConstants.PayPassWalletIndicator, StringType},
            {GlobalConstants.AuthenticationMethod, StringType},
            {GlobalConstants.CardEnrollementMethod, StringType},
            {GlobalConstants.MasterCardAssignedId, StringType}
         };

        /// <summary>
        /// Get the payPassWalletIndicator
        /// </summary>
        /// <returns>string</returns>
        public string PayPassWalletIndicator()
        {
            return GetProperty(GlobalConstants.PayPassWalletIndicator);
        }

        /// <summary>
        /// Set the payPassWalletIndicator
        /// </summary>
        /// <returns>void</returns>
        public void PayPassWalletIndicator(string data)
        {
            SetProperty(GlobalConstants.PayPassWalletIndicator, data);
        }

        /// <summary>
        /// Get the authenticationMethod
        /// </summary>
        /// <returns>string</returns>
        public string AuthenticationMethod()
        {
            return GetProperty(GlobalConstants.AuthenticationMethod);
        }

        /// <summary>
        /// Set the authenticationMethod
        /// </summary>
        /// <returns>void</returns>
        public void AuthenticationMethod(string data)
        {
            SetProperty(GlobalConstants.AuthenticationMethod, data);
        }

        /// <summary>
        /// Get the cardEnrollementMethod
        /// </summary>
        /// <returns>string</returns>
        public string CardEnrollementMethod()
        {
            return GetProperty(GlobalConstants.CardEnrollementMethod);
        }

        /// <summary>
        /// Set the cardEnrollementMethod
        /// </summary>
        /// <returns>void</returns>
        public void CardEnrollementMethod(string data)
        {
            SetProperty(GlobalConstants.CardEnrollementMethod, data);
        }

        /// <summary>
        /// Get the masterCardAssignedId
        /// </summary>
        /// <returns>string</returns>
        public string MasterCardAssignedIdr()
        {
            return GetProperty(GlobalConstants.MasterCardAssignedId);
        }

        /// <summary>
        /// Set the masterCardAssignedId
        /// </summary>
        /// <returns>void</returns>
        public void MasterCardAssignedId(string data)
        {
            SetProperty(GlobalConstants.MasterCardAssignedId, data);
        }

    }
}
