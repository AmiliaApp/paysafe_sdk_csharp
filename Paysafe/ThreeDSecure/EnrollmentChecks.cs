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

namespace Paysafe.ThreeDSecure
{
    //Created by Tushar.Sukhiya on 03.05.2016. This is EnrollmentChecks class.
    public class EnrollmentChecks: JsonObject
    {
        /// <summary>
        /// Initialize the EnrollmentLookups object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public EnrollmentChecks(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.Id, StringType},
            {GlobalConstants.MerchantRefNum, StringType},
            {GlobalConstants.Amount, IntType},
            {GlobalConstants.Currency,  StringType},
            {GlobalConstants.Card, typeof(Card)},
            {GlobalConstants.CustomerIp, StringType},
            {GlobalConstants.UserAgent, StringType},
            {GlobalConstants.AcceptHeader, StringType},
            {GlobalConstants.MerchantUrl, StringType},
            {GlobalConstants.TxnTime, typeof(DateTime)},
            {GlobalConstants.Error, typeof(Error)},
            {GlobalConstants.Status, ThreeDSecureConstants.EnumStatus},
            {GlobalConstants.AcsUrl, StringType},
            {GlobalConstants.PaReq, StringType},
            {GlobalConstants.Eci, IntType},
            {GlobalConstants.ThreeDEnrollment, ThreeDSecureConstants.EnumThreeDEnrollment},
            {GlobalConstants.Links, typeof(List<Link>)}
        };

        /// <summary>
        /// Get the id
        /// </summary>
        /// <returns>String</returns>
        public string Id()
        {
            return GetProperty(GlobalConstants.Id);
        }

        /// <summary>
        /// Set the id
        /// </summary>
        /// <returns>void</returns>
        public void Id(String data)
        {
            SetProperty(GlobalConstants.Id, data);
        }

        /// <summary>
        /// Get the merchantRefNum
        /// </summary>
        /// <returns>String</returns>
        public string MerchantRefNum()
        {
            return GetProperty(GlobalConstants.MerchantRefNum);
        }

        /// <summary>
        /// Set the merchantRefNum
        /// </summary>
        /// <returns>void</returns>
        public void MerchantRefNum(String data)
        {
            SetProperty(GlobalConstants.MerchantRefNum, data);
        }

        /// <summary>
        /// Get the amount
        /// </summary>
        /// <returns>Integer</returns>
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
        /// Get the currency
        /// </summary>
        /// <returns>String</returns>
        public string Currency()
        {
            return GetProperty(GlobalConstants.Currency);
        }

        /// <summary>
        /// Set the currency
        /// </summary>
        /// <returns>void</returns>
        public void Currency(String data)
        {
            SetProperty(GlobalConstants.Currency, data);
        }

        /// <summary>
        /// Get the card
        /// </summary>
        /// <returns>Card</returns>
        public Card Card()
        {
            return GetProperty(GlobalConstants.Card);
        }

        /// <summary>
        /// Set the card
        /// </summary>
        /// <returns>void</returns>
        public void Card(Card data)
        {
            SetProperty(GlobalConstants.Card, data);
        }

        /// <summary>
        /// Get the customerIp
        /// </summary>
        /// <returns>String</returns>
        public string CustomerIp()
        {
            return GetProperty(GlobalConstants.CustomerIp);
        }

        /// <summary>
        /// Set the customerIp
        /// </summary>
        /// <returns>void</returns>
        public void CustomerIp(String data)
        {
            SetProperty(GlobalConstants.CustomerIp, data);
        }

        /// <summary>
        /// Get the userAgent
        /// </summary>
        /// <returns>String</returns>
        public string UserAgent()
        {
            return GetProperty(GlobalConstants.UserAgent);
        }

        /// <summary>
        /// Set the userAgent
        /// </summary>
        /// <returns>void</returns>
        public void UserAgent(String data)
        {
            SetProperty(GlobalConstants.UserAgent, data);
        }

        /// <summary>
        /// Get the acceptHeader
        /// </summary>
        /// <returns>String</returns>
        public string AcceptHeader()
        {
            return GetProperty(GlobalConstants.AcceptHeader);
        }

        /// <summary>
        /// Set the acceptHeader
        /// </summary>
        /// <returns>void</returns>
        public void AcceptHeader(String data)
        {
            SetProperty(GlobalConstants.AcceptHeader, data);
        }

        /// <summary>
        /// Get the merchantUrl
        /// </summary>
        /// <returns>String</returns>
        public string MerchantUrl()
        {
            return GetProperty(GlobalConstants.MerchantUrl);
        }

        /// <summary>
        /// Set the merchantUrl
        /// </summary>
        /// <returns>void</returns>
        public void MerchantUrl(String data)
        {
            SetProperty(GlobalConstants.MerchantUrl, data);
        }

        /// <summary>
        /// Get the txnTime
        /// </summary>
        /// <returns>DateTime</returns>
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
        /// Get the error
        /// </summary>
        /// <returns>Error</returns>
        public Error Error()
        {
            return GetProperty(GlobalConstants.Error);
        }

        /// <summary>
        /// Set the error
        /// </summary>
        /// <returns>void</returns>
        public void Error(Error data)
        {
            SetProperty(GlobalConstants.Error, data);
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
        /// <returns>String</returns>
        public void Status(String data)
        {
            SetProperty(GlobalConstants.Status, data);
        }

        /// <summary>
        /// Get the acsURL
        /// </summary>
        /// <returns>String</returns>
        public string AcsUrl()
        {
            return GetProperty(GlobalConstants.AcsUrl);
        }

        /// <summary>
        /// Set the acsURL
        /// </summary>
        /// <returns>String</returns>
        public void AcsUrl(String data)
        {
            SetProperty(GlobalConstants.AcsUrl, data);
        }

        /// <summary>
        /// Get the paReq
        /// </summary>
        /// <returns>String</returns>
        public string PaReq()
        {
            return GetProperty(GlobalConstants.PaReq);
        }

        /// <summary>
        /// Set the paReq
        /// </summary>
        /// <returns>String</returns>
        public void PaReq(String data)
        {
            SetProperty(GlobalConstants.PaReq, data);
        }

        /// <summary>
        /// Get the eci
        /// </summary>
        /// <returns>Integer</returns>
        public int Eci()
        {
            return GetProperty(GlobalConstants.Eci);
        }

        /// <summary>
        /// Set the eci
        /// </summary>
        /// <returns>void</returns>
        public void Eci(int data)
        {
            SetProperty(GlobalConstants.Eci, data);
        }

        /// <summary>
        /// Get the threeDEnrollment
        /// </summary>
        /// <returns>String</returns>
        public string ThreeDEnrollment()
        {
            return GetProperty(GlobalConstants.ThreeDEnrollment);
        }

        /// <summary>
        /// Set the threeDEnrollment
        /// </summary>
        /// <returns>String</returns>
        public void ThreeDEnrollment(String data)
        {
            SetProperty(GlobalConstants.ThreeDEnrollment, data);
        }

        /// <summary>
        /// Get the Links
        /// </summary>
        /// <returns>Link</returns>
        public List<Link> Links()
        {
            return GetProperty(GlobalConstants.Links);
        }

        /// <summary>
        /// Set the Links
        /// </summary>
        /// <returns>void</returns>
        public void Links(List<Link> data)
        {
            SetProperty(GlobalConstants.Error, data);
        }

        public static EnrollmentChecksBuilder Builder()
        {
            return new EnrollmentChecksBuilder();
        }

        /// <summary>
        /// EnrollmentChecksBuilder  will allow an authorization to be initialized.
        /// set all properties and subpropeties, then trigger .Build() to 
        /// get the generated EnrollmentLookups object
        /// </summary>
        public class EnrollmentChecksBuilder : BaseJsonBuilder<EnrollmentChecks>
        {
            /// <summary>
            /// Set the id parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EnrollmentChecksBuilder</returns>
            public EnrollmentChecksBuilder Id(string data)
            {
                Properties[GlobalConstants.Id] = data;
                return this;
            }

            /// <summary>
            /// Set the merchantRefNum parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EnrollmentChecksBuilder</returns>
            public EnrollmentChecksBuilder MerchantRefNum(string data)
            {
                Properties[GlobalConstants.MerchantRefNum] = data;
                return this;
            }

            /// <summary>
            /// Set the amount parameter
            /// </summary>
            /// <param name=data>Integer<string></param>
            /// <returns>EnrollmentChecksBuilder</returns>
            public EnrollmentChecksBuilder Amount(int data)
            {
                Properties[GlobalConstants.Amount] = data;
                return this;
            }

            /// <summary>
            /// Set the currency parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EnrollmentChecksBuilder</returns>
            public EnrollmentChecksBuilder Currency(string data)
            {
                Properties[GlobalConstants.Currency] = data;
                return this;
            }

            /// <summary>
            /// Build a card within this EnrollmentLookups.
            /// </summary>
            /// <returns>Card.CardBuilder<EnrollmentLookupsBuilder></returns>
            public Card.CardBuilder<EnrollmentChecksBuilder> Card()
            {
                if (!Properties.ContainsKey(GlobalConstants.Card))
                {
                    Properties[GlobalConstants.Card] = new Card.CardBuilder<EnrollmentChecksBuilder>(this);
                }
                return Properties[GlobalConstants.Card] as Card.CardBuilder<EnrollmentChecksBuilder>;
            }

            /// <summary>
            /// Set the customerIp parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EnrollmentChecksBuilder</returns>
            public EnrollmentChecksBuilder CustomerIp(string data)
            {
                Properties[GlobalConstants.CustomerIp] = data;
                return this;
            }

            /// <summary>
            /// Set the userAgent parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EnrollmentChecksBuilder</returns>
            public EnrollmentChecksBuilder UserAgent(string data)
            {
                Properties[GlobalConstants.UserAgent] = data;
                return this;
            }

            /// <summary>
            /// Set the acceptHeader parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EnrollmentChecksBuilder</returns>
            public EnrollmentChecksBuilder AcceptHeader(string data)
            {
                Properties[GlobalConstants.AcceptHeader] = data;
                return this;
            }

            /// <summary>
            /// Set the merchantUrl parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EnrollmentChecksBuilder</returns>
            public EnrollmentChecksBuilder MerchantUrl(string data)
            {
                Properties[GlobalConstants.MerchantUrl] = data;
                return this;
            }

            /// <summary>
            /// Set the txnTime parameter
            /// </summary>
            /// <param name=data>DateTime</param>
            /// <returns>EnrollmentChecksBuilder</returns>
            public EnrollmentChecksBuilder TxnTime(DateTime data)
            {
                Properties[GlobalConstants.TxnTime] = data;
                return this;
            }

            /// <summary>
            /// Build a Error object within this EnrollmentChecksBuilder.
            /// </summary>
            /// <returns>Error.ErrorBuilder<EnrollmentLookupsBuilder></returns>
            public Error.ErrorBuilder<EnrollmentChecksBuilder> Error()
            {
                if (!Properties.ContainsKey(GlobalConstants.Error))
                {
                    Properties[GlobalConstants.Error] = new Error.ErrorBuilder<EnrollmentChecksBuilder>(this);
                }
                return Properties[GlobalConstants.Error] as Error.ErrorBuilder<EnrollmentChecksBuilder>;
            }

            /// <summary>
            /// Set the status parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EnrollmentChecksBuilder</returns>
            public EnrollmentChecksBuilder Status(string data)
            {
                Properties[GlobalConstants.Status] = data;
                return this;
            }

            /// <summary>
            /// Set the acsURL parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EnrollmentChecksBuilder</returns>
            public EnrollmentChecksBuilder AcsUrl(string data)
            {
                Properties[GlobalConstants.AcsUrl] = data;
                return this;
            }

            /// <summary>
            /// Set the paReq parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EnrollmentChecksBuilder</returns>
            public EnrollmentChecksBuilder PaReq(string data)
            {
                Properties[GlobalConstants.PaReq] = data;
                return this;
            }

            /// <summary>
            /// Set the eci parameter
            /// </summary>
            /// <param name=data>Integer</param>
            /// <returns>EnrollmentChecksBuilder</returns>
            public EnrollmentChecksBuilder Eci(int data)
            {
                Properties[GlobalConstants.Eci] = data;
                return this;
            }

            /// <summary>
            /// Set the threeDEnrollment parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EnrollmentChecksBuilder</returns>
            public EnrollmentChecksBuilder ThreeDEnrollment(string data)
            {
                Properties[GlobalConstants.ThreeDEnrollment] = data;
                return this;
            }
        }
    }
}
