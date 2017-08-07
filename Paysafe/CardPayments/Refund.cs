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

namespace Paysafe.CardPayments
{

    public class Refund : JsonObject
    {
        /// <summary>
        /// Initialize the Refund object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Refund(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        /// <summary>
        /// Initialize a refund object with an id
        /// </summary>
        /// <param name="id"></param>
        public Refund(String id)
            : base(_fieldTypes)
        {
            Id(id);
        }

        /// <summary>
        /// Gets the array key to access the array of refunds
        /// </summary>
        /// <returns>The key to be checked in the returning JSON</returns>
        public static string GetPageableArrayKey()
        {
            return "refunds";
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.Id, StringType},
            {GlobalConstants.MerchantRefNum, StringType},
            {GlobalConstants.Amount, IntType},
            {GlobalConstants.ChildAccountNum, StringType},
            {GlobalConstants.DupCheck, BoolType},
            {GlobalConstants.TxnTime, typeof(DateTime)},
            {GlobalConstants.Status, CardPaymentsConstants.EnumStatus},
            {GlobalConstants.RiskReasonCode, typeof(List<int>)},
            {GlobalConstants.AcquirerResponse, typeof(AcquirerResponse)},
            {GlobalConstants.Error, typeof(OptError)},
            {GlobalConstants.Links, typeof(List<Link>)},
            {GlobalConstants.SettlementId, StringType}
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
        /// Get the merchantRefNum
        /// </summary>
        /// <returns>string</returns>
        public string MerchantRefNum()
        {
            return GetProperty(GlobalConstants.MerchantRefNum);
        }

        /// <summary>
        /// Set the merchantRefNum
        /// </summary>
        /// <returns>void</returns>
        public void MerchantRefNum(string data)
        {
            SetProperty(GlobalConstants.MerchantRefNum, data);
        }

        /// <summary>
        /// Get the amount
        /// </summary>
        /// <returns>int</returns>
        public int Amount()
        {
            return GetProperty(GlobalConstants.Amount);
        }

        /// <summary>
        /// Set the amount
        /// </summary>
        /// <returns>void</returns>
        public void Amount(int data)
        {
            SetProperty(GlobalConstants.Amount, data);
        }

        /// <summary>
        /// Get the childAccountNum
        /// </summary>
        /// <returns>string</returns>
        public string ChildAccountNum()
        {
            return GetProperty(GlobalConstants.ChildAccountNum);
        }

        /// <summary>
        /// Set the childAccountNum
        /// </summary>
        /// <returns>void</returns>
        public void ChildAccountNum(string data)
        {
            SetProperty(GlobalConstants.ChildAccountNum, data);
        }

        /// <summary>
        /// Get the dupCheck
        /// </summary>
        /// <returns>bool</returns>
        public bool DupCheck()
        {
            return GetProperty(GlobalConstants.DupCheck);
        }

        /// <summary>
        /// Set the dupCheck
        /// </summary>
        /// <returns>void</returns>
        public void DupCheck(bool data)
        {
            SetProperty(GlobalConstants.DupCheck, data);
        }

        /// <summary>
        /// Get the txnTime
        /// </summary>
        /// <returns>System.DateTime</returns>
        public DateTime TxnTime()
        {
            return GetProperty(GlobalConstants.TxnTime);
        }

        /// <summary>
        /// Set the txnTime
        /// </summary>
        /// <returns>void</returns>
        public void TxnTime(DateTime data)
        {
            SetProperty(GlobalConstants.TxnTime, data);
        }

        /// <summary>
        /// Get the status
        /// </summary>
        /// <returns>String</returns>
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
        /// Get the riskReasonCode
        /// </summary>
        /// <returns>List<int></returns>
        public List<int> RiskReasonCode()
        {
            return GetProperty(GlobalConstants.RiskReasonCode);
        }

        /// <summary>
        /// Set the riskReasonCode
        /// </summary>
        /// <returns>void</returns>
        public void RiskReasonCode(List<int> data)
        {
            SetProperty(GlobalConstants.RiskReasonCode, data);
        }

        /// <summary>
        /// Get the acquireResponse
        /// </summary>
        /// <returns>AcquirerResponse</returns>
        public AcquirerResponse AcquireResponse()
        {
            return GetProperty(GlobalConstants.AcquirerResponse);
        }

        /// <summary>
        /// Set the acquireResponse
        /// </summary>
        /// <returns>void</returns>
        public void AcquireResponse(AcquirerResponse data)
        {
            SetProperty(GlobalConstants.AcquirerResponse, data);
        }

        /// <summary>
        /// Get the error
        /// </summary>
        /// <returns>OptError</returns>
        public OptError Error()
        {
            return GetProperty(GlobalConstants.Error);
        }

        /// <summary>
        /// Set the error
        /// </summary>
        /// <returns>void</returns>
        public void Error(OptError data)
        {
            SetProperty(GlobalConstants.Error, data);
        }

        /// <summary>
        /// Get the links
        /// </summary>
        /// <returns>List<Link></returns>
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

        /// <summary>
        /// Get the settlementId
        /// </summary>
        /// <returns>string</returns>
        public string SettlementId()
        {
            return GetProperty(GlobalConstants.SettlementId);
        }

        /// <summary>
        /// Set the settlementId
        /// </summary>
        /// <returns>void</returns>
        public void SettlementId(string data)
        {
            SetProperty(GlobalConstants.SettlementId, data);
        }

        /// <summary>
        /// Get a new RefundBuilder
        /// </summary>
        /// <returns>RefundBuilder</returns>
        public static RefundBuilder Builder()
        {
            return new RefundBuilder();
        }

        /// <summary>
        /// RefundBuilder will allow an Refund to be initialized.
        /// set all properties and subpropeties, then trigger .Build() to 
        /// get the generated Authorization object
        /// </summary>
        public class RefundBuilder : BaseJsonBuilder<Refund>
        {
            /// <summary>
            /// Set the id
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>RefundBuilder</returns>
            public RefundBuilder Id(string data)
            {
                Properties[GlobalConstants.Id] = data;
                return this;
            }

            /// <summary>
            /// Set the merchantRefNum
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>RefundBuilder</returns>
            public RefundBuilder MerchantRefNum(string data)
            {
                Properties[GlobalConstants.MerchantRefNum] = data;
                return this;
            }

            /// <summary>
            /// Set the amount
            /// </summary>
            /// <param name=data>int</param>
            /// <returns>RefundBuilder</returns>
            public RefundBuilder Amount(int data)
            {
                Properties[GlobalConstants.Amount] = data;
                return this;
            }

            /// <summary>
            /// Set the dupCheck
            /// </summary>
            /// <param name=data>bool</param>
            /// <returns>RefundBuilder</returns>
            public RefundBuilder DupCheck(bool data)
            {
                Properties[GlobalConstants.DupCheck] = data;
                return this;
            }

            /// <summary>
            /// Set the settlementId
            /// </summary>
            /// <param name=data>bool</param>
            /// <returns>RefundBuilder</returns>
            public RefundBuilder SettlementId(String data)
            {
                Properties[GlobalConstants.SettlementId] = data;
                return this;
            }
        }
    }
}
