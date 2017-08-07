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
    //Created by Manjiri.Bankar on 03.05.2016. This is ACHBankAccounts class.
    public class AchBankAccounts : JsonObject
    {
        /// <summary>
        /// Initialize the ACHBankAccounts object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public AchBankAccounts(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.PaymentToken,StringType},            
            {GlobalConstants.PayMethod, DirectDebitConstants.EnumPaymentType},
            {GlobalConstants.PaymentDescriptor, StringType},
            {GlobalConstants.AccountHolderName, StringType},
            {GlobalConstants.AccountType, StringType},
            {GlobalConstants.AccountNumber, StringType},
            {GlobalConstants.RoutingNumber, StringType},
            {GlobalConstants.LastDigits, StringType}
        
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
        /// Get the payMethod
        /// </summary>
        /// <returns>string</returns>
        public string PayMethod()
        {
            return GetProperty(GlobalConstants.PayMethod);
        }

        /// <summary>
        /// Set the payMethod
        /// </summary>
        /// <returns>void</returns>
        public void PayMethod(string data)
        {
            SetProperty(GlobalConstants.PayMethod, data);
        }

        /// <summary>
        /// Get the paymentDescriptor
        /// </summary>
        /// <returns>string</returns>
        public string PaymentDescriptor()
        {
            return GetProperty(GlobalConstants.PaymentDescriptor);
        }

        /// <summary>
        /// Set the paymentDescriptor
        /// </summary>
        /// <returns>void</returns>
        public void PaymentDescriptor(string data)
        {
            SetProperty(GlobalConstants.PaymentDescriptor, data);
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
        /// Get the accountType
        /// </summary>
        /// <returns>string</returns>
        public string AccountType()
        {
            return GetProperty(GlobalConstants.AccountType);
        }

        /// <summary>
        /// Set the accountType
        /// </summary>
        /// <returns>void</returns>
        public void AccountType(string data)
        {
            SetProperty(GlobalConstants.AccountType, data);
        }

        /// <summary>
        /// Get the accountNumber
        /// </summary>
        /// <returns>string</returns>
        public string AccountNumber()
        {
            return GetProperty(GlobalConstants.AccountNumber);
        }

        /// <summary>
        /// Set the accountNumber
        /// </summary>
        /// <returns>void</returns>
        public void AccountNumber(string data)
        {
            SetProperty(GlobalConstants.AccountNumber, data);
        }
        /// <summary>
        /// Get the routingNumber
        /// </summary>
        /// <returns>string</returns>
        public string RoutingNumber()
        {
            return GetProperty(GlobalConstants.RoutingNumber);
        }

        /// <summary>
        /// Set the routingNumber
        /// </summary>
        /// <returns>void</returns>
        public void RoutingNumber(string data)
        {
            SetProperty(GlobalConstants.RoutingNumber, data);
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
        /// ACHAccountBuilder will allow an account to be initialized.
        /// set all properties and subpropeties, then trigger .Build() to 
        /// get the generated ACHAccoun object
        /// </summary>
        public class AchAccountBuilder<TBldr> : NestedJsonBuilder<AchBankAccounts, TBldr>
            where TBldr : GenericJsonBuilder
        {
            /// <summary>
            /// Initialize the ACHAccountBuilder builder within the context of a parent builder
            /// </summary>
            /// <param name="parent">TBLDR</param>
            public AchAccountBuilder(TBldr parent)
                : base(parent)
            {
                Parent = parent;
            }

            /// <summary>
            /// Set the paymentToken
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ACHAccountBuilder<TBLDR></returns>
            public AchAccountBuilder<TBldr> PaymentToken(string data)
            {
                Properties[GlobalConstants.PaymentToken] = data;
                return this;
            }

            /// <summary>
            /// Set the payMethod
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ACHAccountBuilder<TBLDR></returns>
            public AchAccountBuilder<TBldr> PayMethod(string data)
            {
                Properties[GlobalConstants.PayMethod] = data;
                return this;
            }
            /// <summary>
            /// Set the paymentDescriptor
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ACHAccountBuilder<TBLDR></returns>
            public AchAccountBuilder<TBldr> PaymentDescriptor(string data)
            {
                Properties[GlobalConstants.PaymentDescriptor] = data;
                return this;
            }
            /// <summary>
            /// Set the accountHolderName
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ACHAccountBuilder<TBLDR></returns>
            public AchAccountBuilder<TBldr> AccountHolderName(string data)
            {
                Properties[GlobalConstants.AccountHolderName] = data;
                return this;
            }
            /// <summary>
            /// Set the accountType
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ACHAccountBuilder<TBLDR></returns>
            public AchAccountBuilder<TBldr> AccountType(string data)
            {
                Properties[GlobalConstants.AccountType] = data;
                return this;
            }
            /// <summary>
            /// Set the accountNumber
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ACHAccountBuilder<TBLDR></returns>
            public AchAccountBuilder<TBldr> AccountNumber(string data)
            {
                Properties[GlobalConstants.AccountNumber] = data;
                return this;
            }
            /// <summary>
            /// Set the routingNumber
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ACHAccountBuilder<TBLDR></returns>
            public AchAccountBuilder<TBldr> RoutingNumber(string data)
            {
                Properties[GlobalConstants.RoutingNumber] = data;
                return this;
            }
            /// <summary>
            /// Set the lastDigits
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ACHAccountBuilder<TBLDR></returns>
            public AchAccountBuilder<TBldr> LastDigits(string data)
            {
                Properties[GlobalConstants.LastDigits] = data;
                return this;
            }
           
        }

    }
}
