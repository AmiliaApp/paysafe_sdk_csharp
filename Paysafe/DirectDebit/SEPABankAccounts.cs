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

namespace Paysafe.DirectDebit
{
    //Created by Manjiri.Bankar on 03.05.2016. This is SEPABankAccounts class.
    public class SepaBankAccounts : JsonObject
    {
        /// <summary>
        /// Initialize the SEPABankAccounts object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public SepaBankAccounts(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.PaymentToken,StringType}, 
            {GlobalConstants.MandateReference,StringType}, 
            {GlobalConstants.AccountHolderName,StringType}, 
            {GlobalConstants.Iban,StringType}, 
            {GlobalConstants.LastDigits,StringType}, 
                                       
        };

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
        /// Get the mandateReference
        /// </summary>
        /// <returns>string</returns>
        public string MandateReference()
        {
            return GetProperty(GlobalConstants.MandateReference);
        }

        /// <summary>
        /// Set the mandateReference
        /// </summary>
        /// <returns>void</returns>
        public void MandateReference(string data)
        {
            SetProperty(GlobalConstants.MandateReference, data);
        }
        /// <summary>
        /// Get the accountHolderName
        /// </summary>
        /// <returns>string</returns>
        public string AccountHolderName()
        {
            return GetProperty(GlobalConstants.AccountHolderName);
        }

        /// <summary>
        /// Set the accountHolderName
        /// </summary>
        /// <returns>void</returns>
        public void AccountHolderName(string data)
        {
            SetProperty(GlobalConstants.AccountHolderName, data);
        }
        /// <summary>
        /// Get the iban
        /// </summary>
        /// <returns>string</returns>
        public string Iban()
        {
            return GetProperty(GlobalConstants.Iban);
        }

        /// <summary>
        /// Set the iban
        /// </summary>
        /// <returns>void</returns>
        public void Iban(string data)
        {
            SetProperty(GlobalConstants.Iban, data);
        }
        /// <summary>
        /// Get the lastDigits
        /// </summary>
        /// <returns>string</returns>
        public string LastDigits()
        {
            return GetProperty(GlobalConstants.LastDigits);
        }

        /// <summary>
        /// Set the lastDigits
        /// </summary>
        /// <returns>void</returns>
        public void LastDigits(string data)
        {
            SetProperty(GlobalConstants.LastDigits, data);
        }
       
        /// <summary>
        /// SEPAAccountBuilder will allow an account to be initialized.
        /// set all properties and subpropeties, then trigger .Build() to 
        /// get the generated SEPABankAccount object
        /// </summary>
        public class SepaAccountBuilder<TBldr> : NestedJsonBuilder<SepaBankAccounts, TBldr>
            where TBldr : GenericJsonBuilder
        {

           /// <summary>
            /// Initialize the SEPAAccountBuilder builder within the context of a parent builder
            /// </summary>
            /// <param name="parent">TBLDR</param>
            public SepaAccountBuilder(TBldr parent)
                : base(parent)
            {
                Parent = parent;
            }

            /// <summary>
            /// Set the paymentToken
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>SEPAAccountBuilder<TBLDR></returns>
            public SepaAccountBuilder<TBldr> PaymentToken(string data)
            {
                Properties[GlobalConstants.PaymentToken] = data;
                return this;
            }
            
            /// <summary>
            /// Set the mandateReference
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>SEPAAccountBuilder<TBLDR></returns>
            public SepaAccountBuilder<TBldr> MandateReference(string data)
            {
                Properties[GlobalConstants.MandateReference] = data;
                return this;
            }

            /// <summary>
            /// Set the accountHolderName
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>SEPAAccountBuilder<TBLDR></returns>
            public SepaAccountBuilder<TBldr> AccountHolderName(string data)
            {
                Properties[GlobalConstants.AccountHolderName] = data;
                return this;
            }
          
            /// <summary>
            /// Set the iban
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>SEPAAccountBuilder<TBLDR></returns>
            public SepaAccountBuilder<TBldr> Iban(string data)
            {
                Properties[GlobalConstants.Iban] = data;
                return this;
            }          

            /// <summary>
            /// Set the lastDigits
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>SEPAAccountBuilder<TBLDR></returns>
            public SepaAccountBuilder<TBldr> LastDigits(string data)
            {
                Properties[GlobalConstants.LastDigits] = data;
                return this;
            }

        }

    }
}
