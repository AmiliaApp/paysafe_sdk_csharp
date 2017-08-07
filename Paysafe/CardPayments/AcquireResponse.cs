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

    public class AcquirerResponse : JsonObject
    {
        /// <summary>
        /// Initialize the AcquirerResponse object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public AcquirerResponse(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
         {
             {GlobalConstants.Code, StringType},
             {GlobalConstants.ResponseCode, StringType},
             {GlobalConstants.AvsCode, StringType},
             {GlobalConstants.BalanceResponse, StringType},
             {GlobalConstants.BatchNumber, StringType},
             {GlobalConstants.EffectiveDate, StringType},
             {GlobalConstants.FinancingType, StringType},
             {GlobalConstants.GracePeriod, StringType},
             {GlobalConstants.Plan, StringType},
             {GlobalConstants.SeqNumber, StringType},
             {GlobalConstants.Term, StringType},
             {GlobalConstants.TerminalId, StringType},
             {GlobalConstants.ResponseId, StringType},
             {GlobalConstants.RequestId, StringType},
             {GlobalConstants.Description, StringType},
             {GlobalConstants.AuthCode, StringType},
             {GlobalConstants.TxnDateTime, StringType},
             {GlobalConstants.ReferenceNbr, StringType},
             {GlobalConstants.ResponseReasonCode, StringType},
             {GlobalConstants.Cvv2Result, StringType},
             {GlobalConstants.Mid, StringType}
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
        /// Set the  code
        /// </summary>
        /// <returns>void</returns>
        public void Code(string data)
        {
            SetProperty(GlobalConstants.Code, data);
        }

        /// <summary>
        /// Get the responseCode
        /// </summary>
        /// <returns>string</returns>
        public string ResponseCode()
        {
            return GetProperty(GlobalConstants.ResponseCode);
        }

        /// <summary>
        /// Set the responseCode
        /// </summary>
        /// <returns>void</returns>
        public void ResponseCode(string data)
        {
            SetProperty(GlobalConstants.ResponseCode, data);
        }

        /// <summary>
        /// Get the avsCode
        /// </summary>
        /// <returns>string</returns>
        public string AvsCode()
        {
            return GetProperty(GlobalConstants.AvsCode);
        }

        /// <summary>
        /// Set the avsCode
        /// </summary>
        /// <returns>void</returns>
        public void AvsCode(string data)
        {
            SetProperty(GlobalConstants.AvsCode, data);
        }

        /// <summary>
        /// Get the balanceResponse
        /// </summary>
        /// <returns>string</returns>
        public string BalanceResponse()
        {
            return GetProperty(GlobalConstants.BalanceResponse);
        }

        /// <summary>
        /// Set the balanceResponse
        /// </summary>
        /// <returns>void</returns>
        public void BalanceResponse(string data)
        {
            SetProperty(GlobalConstants.BalanceResponse, data);
        }

        /// <summary>
        /// Get the batchNumber
        /// </summary>
        /// <returns>string</returns>
        public string BatchNumber()
        {
            return GetProperty(GlobalConstants.BatchNumber);
        }

        /// <summary>
        /// Set the batchNumber
        /// </summary>
        /// <returns>void</returns>
        public void BatchNumber(string data)
        {
            SetProperty(GlobalConstants.BatchNumber, data);
        }

        /// <summary>
        /// Get the effectiveDate
        /// </summary>
        /// <returns>string</returns>
        public string EffectiveDate()
        {
            return GetProperty(GlobalConstants.EffectiveDate);
        }

        /// <summary>
        /// Set the effectiveDate
        /// </summary>
        /// <returns>void</returns>
        public void EffectiveDate(string data)
        {
            SetProperty(GlobalConstants.EffectiveDate, data);
        }

        /// <summary>
        /// Get the financingType
        /// </summary>
        /// <returns>string</returns>
        public string FinancingType()
        {
            return GetProperty(GlobalConstants.FinancingType);
        }

        /// <summary>
        /// Set the financingType
        /// </summary>
        /// <returns>void</returns>
        public void FinancingType(string data)
        {
            SetProperty(GlobalConstants.FinancingType, data);
        }

        /// <summary>
        /// Get the gracePeriod
        /// </summary>
        /// <returns>int</returns>
        public int GracePeriod()
        {
            return GetProperty(GlobalConstants.GracePeriod);
        }

        /// <summary>
        /// Set the gracePeriod
        /// </summary>
        /// <returns>void</returns>
        public void GracePeriod(int data)
        {
            SetProperty(GlobalConstants.GracePeriod, data);
        }

        /// <summary>
        /// Get the plan
        /// </summary>
        /// <returns>string</returns>
        public string Plan()
        {
            return GetProperty(GlobalConstants.Plan);
        }

        /// <summary>
        /// Set the plan
        /// </summary>
        /// <returns>void</returns>
        public void Plan(string data)
        {
            SetProperty(GlobalConstants.Plan, data);
        }

        /// <summary>
        /// Get the seqNumber
        /// </summary>
        /// <returns>string</returns>
        public string SeqNumber()
        {
            return GetProperty(GlobalConstants.SeqNumber);
        }

        /// <summary>
        /// Set the seqNumber
        /// </summary>
        /// <returns>void</returns>
        public void SeqNumber(string data)
        {
            SetProperty(GlobalConstants.SeqNumber, data);
        }

        /// <summary>
        /// Get the term
        /// </summary>
        /// <returns>string</returns>
        public string Term()
        {
            return GetProperty(GlobalConstants.Term);
        }

        /// <summary>
        /// Set the term
        /// </summary>
        /// <returns>void</returns>
        public void Term(int data)
        {
            SetProperty(GlobalConstants.Term, data);
        }

        /// <summary>
        /// Get the terminalId
        /// </summary>
        /// <returns>string</returns>
        public string TerminalId()
        {
            return GetProperty(GlobalConstants.TerminalId);
        }

        /// <summary>
        /// Set the terminalId
        /// </summary>
        /// <returns>void</returns>
        public void TerminalId(int data)
        {
            SetProperty(GlobalConstants.TerminalId, data);
        }

        /// <summary>
        /// Get the requestId
        /// </summary>
        /// <returns>string</returns>
        public string RequestId()
        {
            return GetProperty(GlobalConstants.RequestId);
        }

        /// <summary>
        /// Set the requestId
        /// </summary>
        /// <returns>void</returns>
        public void RequestId(int data)
        {
            SetProperty(GlobalConstants.RequestId, data);
        }

        /// <summary>
        /// Get the responseId
        /// </summary>
        /// <returns>string</returns>
        public string ResponseId()
        {
            return GetProperty(GlobalConstants.ResponseId);
        }

        /// <summary>
        /// Set the responseId
        /// </summary>
        /// <returns>void</returns>
        public void ResponseId(int data)
        {
            SetProperty(GlobalConstants.TerminalId, data);
        }

        /// <summary>
        /// Get the description
        /// </summary>
        /// <returns>string</returns>
        public string Description()
        {
            return GetProperty(GlobalConstants.Description);
        }

        /// <summary>
        /// Set the description
        /// </summary>
        /// <returns>void</returns>
        public void Description(string data)
        {
            SetProperty(GlobalConstants.Description, data);
        }

        /// <summary>
        /// Get the authCode
        /// </summary>
        /// <returns>string</returns>
        public string AuthCode()
        {
            return GetProperty(GlobalConstants.AuthCode);
        }

        /// <summary>
        /// Set the authCode
        /// </summary>
        /// <returns>void</returns>
        public void AuthCode(string data)
        {
            SetProperty(GlobalConstants.AuthCode, data);
        }

        /// <summary>
        /// Get the txnDateTime
        /// </summary>
        /// <returns>string</returns>
        public string TxnDateTime()
        {
            return GetProperty(GlobalConstants.TxnDateTime);
        }

        /// <summary>
        /// Set the txnDateTime
        /// </summary>
        /// <returns>void</returns>
        public void TxnDateTime(string data)
        {
            SetProperty(GlobalConstants.TxnDateTime, data);
        }

        /// <summary>
        /// Get the referenceNbr
        /// </summary>
        /// <returns>string</returns>
        public string ReferenceNbr()
        {
            return GetProperty(GlobalConstants.ReferenceNbr);
        }

        /// <summary>
        /// Set the referenceNbr
        /// </summary>
        /// <returns>void</returns>
        public void ReferenceNbr(string data)
        {
            SetProperty(GlobalConstants.ReferenceNbr, data);
        }

        /// <summary>
        /// Get the responseReasonCode
        /// </summary>
        /// <returns>string</returns>
        public string ResponseReasonCode()
        {
            return GetProperty(GlobalConstants.ResponseReasonCode);
        }

        /// <summary>
        /// Set the responseReasonCode
        /// </summary>
        /// <returns>void</returns>
        public void ResponseReasonCode(string data)
        {
            SetProperty(GlobalConstants.ResponseReasonCode, data);
        }

        /// <summary>
        /// Get the cvv2Result
        /// </summary>
        /// <returns>string</returns>
        public string Cvv2Result()
        {
            return GetProperty(GlobalConstants.Cvv2Result);
        }

        /// <summary>
        /// Set the cvv2Result
        /// </summary>
        /// <returns>void</returns>
        public void Cvv2Result(string data)
        {
            SetProperty(GlobalConstants.Cvv2Result, data);
        }

        /// <summary>
        /// Get the mid
        /// </summary>
        /// <returns>string</returns>
        public string Mid()
        {
            return GetProperty(GlobalConstants.Mid);
        }

        /// <summary>
        /// Set the mid
        /// </summary>
        /// <returns>void</returns>
        public void Mid(string data)
        {
            SetProperty(GlobalConstants.Mid, data);
        }

    }
}
