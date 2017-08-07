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
using Paysafe.Common;

namespace Paysafe.CustomerVault
{
    //Created by Manjiri.Bankar on 03.05.2016. This is Mandates class.
    public class Mandates : JsonObject
    {
        /// <summary>
        /// Initialize the Mandates object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Mandates(Dictionary<string, object> properties = null) 
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.Id,StringType},            
            {GlobalConstants.Reference, StringType},
            {GlobalConstants.BankAccountId, StringType},
            {GlobalConstants.Status, CustomerVaultConstants.EnumStatus},
            {GlobalConstants.StatusChangeDate,typeof(DateTime)},
            {GlobalConstants.StatusReasonCode, StringType},
            {GlobalConstants.StatusReason, StringType},            
            {GlobalConstants.PaymentToken,StringType},            
            {GlobalConstants.ProfileId, StringType}
        };

        /// <summary>
        /// Get the id
        /// </summary>
        /// <returns>string</returns>
        public string Id()
        {
            return GetProperty(GlobalConstants.Id);
        }

        /// <summary>
        /// Set the id
        /// </summary>
        /// <returns>void</returns>
        public void Id(string data)
        {
            SetProperty(GlobalConstants.Id, data);
        }

        /// <summary>
        /// Get the reference
        /// </summary>
        /// <returns>reference</returns>
        public string Reference()
        {
            return GetProperty(GlobalConstants.Reference);
        }

        /// <summary>
        /// Set the reference
        /// </summary>
        /// <returns>void</returns>
        public void Reference(string data)
        {
            SetProperty(GlobalConstants.Reference, data);
        }

        /// <summary>
        /// Get the bankAccountId
        /// </summary>
        /// <returns>string</returns>
        public string BankAccountId()
        {
            return GetProperty(GlobalConstants.BankAccountId);
        }

        /// <summary>
        /// Set the bankAccountId
        /// </summary>
        /// <returns>void</returns>
        public void BankAccountId(string data)
        {
            SetProperty(GlobalConstants.BankAccountId, data);
        }

        /// <summary>
        /// Get the status
        /// </summary>
        /// <returns>string</returns>
        public string Status()
        {
            return GetProperty(GlobalConstants.Status);
        }

        /// <summary>
        /// Set the status
        /// </summary>
        /// <returns>void</returns>
        public void Status(string data)
        {
            SetProperty(GlobalConstants.Status, data);
        }

        /// <summary>
        /// Get the statusChangeDate
        /// </summary>
        /// <returns>string</returns>
        public DateTime StatusChangeDate()
        {
            return GetProperty(GlobalConstants.StatusChangeDate);
        }

        /// <summary>
        /// Set the statusChangeDate
        /// </summary>
        /// <returns>void</returns>
        public void StatusChangeDate(DateTime data)
        {
            SetProperty(GlobalConstants.StatusChangeDate, data);
        }

        /// <summary>
        /// Get the statusReasonCode
        /// </summary>
        /// <returns>string</returns>
        public string StatusReasonCode()
        {
            return GetProperty(GlobalConstants.StatusReasonCode);
        }

        /// <summary>
        /// Set the statusReasonCode
        /// </summary>
        /// <returns>void</returns>
        public void StatusReasonCode(string data)
        {
            SetProperty(GlobalConstants.StatusReasonCode, data);
        }

        /// <summary>
        /// Get the statusReason
        /// </summary>
        /// <returns>string</returns>
        public string StatusReason()
        {
            return GetProperty(GlobalConstants.StatusReason);
        }

        /// <summary>
        /// Set the statusReason
        /// </summary>
        /// <returns>void</returns>
        public void StatusReason(string data)
        {
            SetProperty(GlobalConstants.StatusReason, data);
        }

        /// <summary>
        /// Get the paymentToken
        /// </summary>
        /// <returns>string</returns>
        public string PaymentToken()
        {
            return GetProperty(GlobalConstants.PaymentToken);
        }

        /// <summary>
        /// Set the paymentToken
        /// </summary>
        /// <returns>void</returns>
        public void PaymentToken(string data)
        {
            SetProperty(GlobalConstants.PaymentToken, data);
        }               

        /// <summary>
        /// Get the profileId
        /// </summary>
        /// <returns>String</returns>
        public String ProfileId()
        {
            return GetProperty(GlobalConstants.ProfileId);
        }

        /// <summary>
        /// Set the profileId
        /// </summary>
        /// <returns>void</returns>
        public void ProfileId(String data)
        {
            SetProperty(GlobalConstants.ProfileId, data);
        }
       
        public static MandatesBuilder Builder()
        {
            return new MandatesBuilder();
        }

        /// <summary>
        /// Mandates will allow an authorization to be initialized.
        /// set all properties and subpropeties, then trigger .Build() to 
        /// get the generated Profile object
        /// </summary>
        public class MandatesBuilder : BaseJsonBuilder<Mandates>
        {

            /// <summary>
            /// Set the id parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>MandatesBuilder</returns>
            public MandatesBuilder Id(string data)
            {
                Properties[GlobalConstants.Id] = data;
                return this;
            }

            /// <summary>
            /// Set the reference parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>MandatesBuilder</returns>
            public MandatesBuilder Reference(string data)
            {
                Properties[GlobalConstants.Reference] = data;
                return this;
            }

            /// <summary>
            /// Set the bankAccountId parameter
            /// </summary>
            /// <param name=data>List<string></param>
            /// <returns>MandatesBuilder</returns>
            public MandatesBuilder BankAccountId(string data)
            {
                Properties[GlobalConstants.BankAccountId] = data;
                return this;
            }

            /// <summary>
            /// Set the status parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>MandatesBuilder</returns>
            public MandatesBuilder Status(string data)
            {
                Properties[GlobalConstants.Status] = data;
                return this;
            }

            /// <summary>
            /// Set the statusReason parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>MandatesBuilder</returns>
            public MandatesBuilder StatusReason(string data)
            {
                Properties[GlobalConstants.StatusReason] = data;
                return this;
            }

            /// <summary>
            /// Set the statusChangeDate parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>MandatesBuilder</returns>
            public MandatesBuilder StatusChangeDate(DateTime data)
            {
                Properties[GlobalConstants.StatusChangeDate] = data;
                return this;
            }

            /// <summary>
            /// Set the statusReasonCode parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>MandatesBuilder</returns>
            public MandatesBuilder StatusReasonCode(string data)
            {
                Properties[GlobalConstants.StatusReasonCode] = data;
                return this;
            }

            /// <summary>
            /// Set the paymentToken parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>MandatesBuilder</returns>
            public MandatesBuilder PaymentToken(string data)
            {
                Properties[GlobalConstants.PaymentToken] = data;
                return this;
            }


            /// <summary>
            /// Set the profileId parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>MandatesBuilder</returns>
            public MandatesBuilder ProfileId(string data)
            {
                Properties[GlobalConstants.ProfileId] = data;
                return this;
            }
        }
                 
    }
}
