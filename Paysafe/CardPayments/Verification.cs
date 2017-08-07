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
    public class Verification : JsonObject
    {
        /// <summary>
        /// Initialize the Verification object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Verification(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        /// <summary>
        /// Initialize a verification object with an id
        /// </summary>
        /// <param name="id"></param>
        public Verification(String id)
            : base(_fieldTypes)
        {
            Id(id);
        }

        /// <summary>
        /// Gets the array key to access the array of verifications
        /// </summary>
        /// <returns>The key to be checked in the returning JSON</returns>
        public static string GetPageableArrayKey()
        {
            return "verifications";
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.Id, StringType},
            {GlobalConstants.MerchantRefNum, StringType},
            {GlobalConstants.ChildAccountNum, StringType},
            {GlobalConstants.Card, typeof(Card)},
            {GlobalConstants.AuthCode, StringType},
            {GlobalConstants.Profile, typeof(Profile)},
            {GlobalConstants.BillingDetails, typeof(BillingDetails)},
            {GlobalConstants.CustomerIp, StringType},
            {GlobalConstants.DupCheck, BoolType},
            {GlobalConstants.MerchantDescriptor, typeof(MerchantDescriptor)},
            {GlobalConstants.Description, StringType},
            {GlobalConstants.TxnTime, typeof(DateTime)},
            {GlobalConstants.CurrencyCode, StringType},
            {GlobalConstants.AvsResponse, CardPaymentsConstants.EnumAvsResponse},
            {GlobalConstants.CvvVerification, CardPaymentsConstants.EnumCvvVerification},
            {GlobalConstants.Status, CardPaymentsConstants.EnumStatus},
            {GlobalConstants.RiskReasonCode, typeof(List<int>)},
            {GlobalConstants.AcquirerResponse, typeof(AcquirerResponse)},
            {GlobalConstants.Error, typeof(OptError)},
            {GlobalConstants.Links, typeof(List<Link>)}
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
        /// <turns>void</returns>
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
        /// Get the profile
        /// </summary>
        /// <returns>Profile</returns>
        public Profile Profile()
        {
            return GetProperty(GlobalConstants.Profile);

        }

        /// <summary>
        /// Set the profile
        /// </summary>
        /// <returns>void</returns>
        public void Profile(Profile data)
        {
            SetProperty(GlobalConstants.Profile, data);
        }

        /// <summary>
        /// Get the billing details
        /// </summary>
        /// <returns>BillingDetails</returns>
        public BillingDetails BillingDetails()
        {
            return GetProperty(GlobalConstants.BillingDetails);
        }

        /// <summary>
        /// Set the billingDetails
        /// </summary>
        /// <returns>void</returns>
        public void BillingDetails(BillingDetails data)
        {
            SetProperty(GlobalConstants.BillingDetails, data);
        }

        /// <summary>
        /// Get the customerIp
        /// </summary>
        /// <returns>string</returns>
        public string CustomerIp()
        {
            return GetProperty(GlobalConstants.CustomerIp);
        }

        /// <summary>
        /// Set the customerIp
        /// </summary>
        /// <returns>void</returns>
        public void CustomerIp(string data)
        {
            SetProperty(GlobalConstants.CustomerIp, data);
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
        /// Get the merchantDescriptor
        /// </summary>
        /// <returns>MerchantDescriptor</returns>
        public MerchantDescriptor MerchantDescriptor()
        {
            return GetProperty(GlobalConstants.MerchantDescriptor);
        }

        /// <summary>
        /// Set the merchantDescriptor
        /// </summary>
        /// <returns>void</returns>
        public void MerchantDescriptor(MerchantDescriptor data)
        {
            SetProperty(GlobalConstants.MerchantDescriptor, data);
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
        /// Get the currencyCode
        /// </summary>
        /// <returns>string</returns>
        public string CurrencyCode()
        {
            return GetProperty(GlobalConstants.CurrencyCode);
        }

        /// <summary>
        /// Set the currencyCode
        /// </summary>
        /// <returns>void</returns>
        public void CurrencyCode(string data)
        {
            SetProperty(GlobalConstants.CurrencyCode, data);
        }

        /// <summary>
        /// Get the avsResponse
        /// </summary>
        /// <returns>string</returns>
        public string AvsResponse()
        {
            return GetProperty(GlobalConstants.AvsResponse);
        }

        /// <summary>
        /// Set the avsResponse
        /// </summary>
        /// <returns>void</returns>
        public void AvsResponse(string data)
        {
            SetProperty(GlobalConstants.AvsResponse, data);
        }

        /// <summary>
        /// Get the cvvVerification
        /// </summary>
        /// <returns>string</returns>
        public string CvvVerification()
        {
            return GetProperty(GlobalConstants.CvvVerification);
        }

        /// <summary>
        /// Set the cvvVerification
        /// </summary>
        /// <returns>void</returns>
        public void CvvVerification(string data)
        {
            SetProperty(GlobalConstants.CvvVerification, data);
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
        /// Get a new VerificationBuilder
        /// </summary>
        /// <returns>VerificationBuilder</returns>
        public static VerificationBuilder Builder()
        {
            return new VerificationBuilder();
        }

        /// <summary>
        /// VerificationBuilder will allow an Verification to be initialized.
        /// set all properties and subpropeties, then trigger .Build() to 
        /// get the generated Verification object
        /// </summary>
        public class VerificationBuilder : BaseJsonBuilder<Verification>
        {
            /// <summary>
            /// Set the id
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>VerificationBuilder</returns>
            public VerificationBuilder Id(string data)
            {
                Properties[GlobalConstants.Id] = data;
                return this;
            }

            /// <summary>
            /// Set the merchantRefNum
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>VerificationBuilder</returns>
            public VerificationBuilder MerchantRefNum(string data)
            {
                Properties[GlobalConstants.MerchantRefNum] = data;
                return this;
            }

            /// <summary>
            /// Build a card object within this Verification.
            /// </summary>
            /// <returns>Profile.profileBuilder<VerificationBuilder></returns>
            public Card.CardBuilder<VerificationBuilder> Card()
            {
                if (!Properties.ContainsKey(GlobalConstants.Card))
                {
                    Properties[GlobalConstants.Card] = new Card.CardBuilder<VerificationBuilder>(this);
                }
                return Properties[GlobalConstants.Card] as Card.CardBuilder<VerificationBuilder>;
            }

            /// <summary>
            /// Set the dupCheck
            /// </summary>
            /// <param name=data>bool</param>
            /// <returns>VerificationBuilder</returns>
            public VerificationBuilder DupCheck(bool data)
            {
                Properties[GlobalConstants.DupCheck] = data;
                return this;
            }

            /// <summary>
            /// Build a profile object within this Verification.
            /// </summary>
            /// <returns>Profile.profileBuilder<VerificationBuilder></returns>
            public Profile.ProfileBuilder<VerificationBuilder> Profile()
            {
                if (!Properties.ContainsKey(GlobalConstants.Profile))
                {
                    Properties[GlobalConstants.Profile] = new Profile.ProfileBuilder<VerificationBuilder>(this);
                }
                return Properties[GlobalConstants.Profile] as Profile.ProfileBuilder<VerificationBuilder>;
            }

            /// <summary>
            /// Build a billing details object within this Verification.
            /// </summary>
            /// <returns>BillingDetails.BillingDetailsBuilder<VerificationBuilder></returns>
            public BillingDetails.BillingDetailsBuilder<VerificationBuilder> BillingDetails()
            {
                if (!Properties.ContainsKey(GlobalConstants.BillingDetails))
                {
                    Properties[GlobalConstants.BillingDetails] = new BillingDetails.BillingDetailsBuilder<VerificationBuilder>(this);
                }
                return Properties[GlobalConstants.BillingDetails] as BillingDetails.BillingDetailsBuilder<VerificationBuilder>;
            }

            /// <summary>
            /// Set the customerIp
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>VerificationBuilder</returns>
            public VerificationBuilder CustomerIp(string data)
            {
                Properties[GlobalConstants.CustomerIp] = data;
                return this;
            }

            /// <summary>
            /// Build a merchant descriptor object within this Verification.
            /// </summary>
            /// <returns>MerchantDescriptor.MerchantDescriptorBuilder<VerificationBuilder></returns>
            public MerchantDescriptor.MerchantDescriptorBuilder<VerificationBuilder> MerchantDescriptor()
            {
                if (!Properties.ContainsKey(GlobalConstants.MerchantDescriptor))
                {
                    Properties[GlobalConstants.MerchantDescriptor] = new MerchantDescriptor.MerchantDescriptorBuilder<VerificationBuilder>(this);
                }
                return Properties[GlobalConstants.MerchantDescriptor] as MerchantDescriptor.MerchantDescriptorBuilder<VerificationBuilder>;
            }

            /// <summary>
            /// Set the description
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>VerificationBuilder</returns>
            public VerificationBuilder Description(string data)
            {
                Properties[GlobalConstants.Description] = data;
                return this;
            }

        }
    }
}
