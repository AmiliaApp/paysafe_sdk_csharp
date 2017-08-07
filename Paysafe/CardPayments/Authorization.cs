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
    public class Authorization : JsonObject
    {

        /// <summary>
        /// Gets the array key to access the array of authorizations
        /// </summary>
        /// <returns>The key to be checked in the returning JSON</returns>
        public static string GetPageableArrayKey()
        {
            return "auths";
        }

        /// <summary>
        /// Initialize the Authorization object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Authorization(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        /// <summary>
        /// Initialize an authorization object with an id
        /// </summary>
        /// <param name="id"></param>
        public Authorization(String id)
            : base(_fieldTypes)
        {
            Id(id);
        }

        /// <summary>
        /// This object is used to validate any properties set within the object
        /// </summary>
        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.Id, StringType},
            {GlobalConstants.MerchantRefNum, StringType},
            {GlobalConstants.Amount, IntType},
            {GlobalConstants.SettleWithAuth, BoolType},
            {GlobalConstants.AvailableToSettle, IntType},
            {GlobalConstants.ChildAccountNum, StringType},
            {GlobalConstants.Card, typeof(Card)},
            {GlobalConstants.Authentication, typeof(PaysafeAuthentication)},
            {GlobalConstants.AuthCode, StringType},
            {GlobalConstants.Profile, typeof(Profile)},
            {GlobalConstants.BillingDetails, typeof(BillingDetails)},
            {GlobalConstants.ShippingDetails, typeof(ShippingDetails)},
            {GlobalConstants.Recurring, CardPaymentsConstants.EnumRecurring},
            {GlobalConstants.CustomerIp, StringType},
            {GlobalConstants.DupCheck, BoolType},
            {GlobalConstants.Keywords, typeof(List<string>)},
            {GlobalConstants.MerchantDescriptor, typeof(MerchantDescriptor)},
            {GlobalConstants.AccordD, typeof(AccordD)},
            {GlobalConstants.Description, StringType},
            {GlobalConstants.MasterPass, typeof(MasterPass)},
            {GlobalConstants.TxnTime, typeof(DateTime)},
            {GlobalConstants.CurrencyCode, StringType},
            {GlobalConstants.AvsResponse, CardPaymentsConstants.EnumAvsResponse},
            {GlobalConstants.CvvVerification, CardPaymentsConstants.EnumCvvVerification},
            {GlobalConstants.Status, CardPaymentsConstants.EnumStatus},
            {GlobalConstants.RiskReasonCode, typeof(List<int>)},
            {GlobalConstants.AcquirerResponse, typeof(AcquirerResponse)},
            {GlobalConstants.VisaAdditionalAuthData, typeof(VisaAdditionalAuthData)},
            {GlobalConstants.Settlements, typeof(List<Settlement>)},
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
        /// Get the settleWithAuth
        /// </summary>
        /// <returns>bool</returns>
        public bool SettleWithAuth()
        {
            return GetProperty(GlobalConstants.SettleWithAuth);
        }

        /// <summary>
        /// Set the settleWithAuth
        /// </summary>
        /// <returns>void</returns>
        public void SettleWithAuth(bool data)
        {
            SetProperty(GlobalConstants.SettleWithAuth, data);
        }

        /// <summary>
        /// Get the availableToSettle
        /// </summary>
        /// <returns>int</returns>
        public int AvailableToSettle()
        {
            return GetProperty(GlobalConstants.AvailableToSettle);
        }

        /// <summary>
        /// Set the availableToSettle
        /// </summary>
        /// <returns>void</returns>
        public void AvailableToSettle(int data)
        {
            SetProperty(GlobalConstants.AvailableToSettle, data);
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
        /// Get the authentication
        /// </summary>
        /// <returns>Authentication</returns>
        public PaysafeAuthentication Authentication()
        {
            return GetProperty(GlobalConstants.Authentication);
        }

        /// <summary>
        /// Set the authentication
        /// </summary>
        /// <returns>void</returns>
        public void Authentication(PaysafeAuthentication data)
        {
            SetProperty(GlobalConstants.Authentication, data);
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
        /// Get the shipping details
        /// </summary>
        /// <returns>ShippingDetails</returns>
        public ShippingDetails ShippingDetails()
        {
            return GetProperty(GlobalConstants.ShippingDetails);
        }

        /// <summary>
        /// Set the shippingDetails
        /// </summary>
        /// <returns>void</returns>
        public void ShippingDetails(ShippingDetails data)
        {
            SetProperty(GlobalConstants.ShippingDetails, data);
        }

        /// <summary>
        /// Get the recurring
        /// </summary>
        /// <returns>string</returns>
        public string Recurring()
        {
            return GetProperty(GlobalConstants.Recurring);
        }

        /// <summary>
        /// Set the recurring
        /// </summary>
        /// <returns>void</returns>
        public void Recurring(string data)
        {
            SetProperty(GlobalConstants.Recurring, data);
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
        /// Get the keywords
        /// </summary>
        /// <returns>List<string></returns>
        public List<string> Keywords()
        {
            return GetProperty(GlobalConstants.Keywords);
        }

        /// <summary>
        /// Set the keywords
        /// </summary>
        /// <returns>void</returns>
        public void Keywords(List<string> data)
        {
            SetProperty(GlobalConstants.Keywords, data);
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
        /// Get the accordD
        /// </summary>
        /// <returns>AccordD</returns>
        public AccordD AccordD()
        {
            return GetProperty(GlobalConstants.AccordD);
        }

        /// <summary>
        /// Set the accordD
        /// </summary>
        /// <returns>void</returns>
        public void AccordD(AccordD data)
        {
            SetProperty(GlobalConstants.AccordD, data);
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
        /// Get the masterPass
        /// </summary>
        /// <returns>MasterPass</returns>
        public MasterPass MasterPass()
        {
            return GetProperty(GlobalConstants.MasterPass);
        }

        /// <summary>
        /// Set the masterPass
        /// </summary>
        /// <returns>void</returns>
        public void MasterPass(MasterPass data)
        {
            SetProperty(GlobalConstants.MasterPass, data);
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
        /// Get the visaAdditionalAuthData
        /// </summary>
        /// <returns>VisaAdditionalAuthData</returns>
        public VisaAdditionalAuthData VisaAdditionalAuthData()
        {
            return GetProperty(GlobalConstants.VisaAdditionalAuthData);
        }

        /// <summary>
        /// Set the visaAdditionalAuthData
        /// </summary>
        /// <returns>void</returns>
        public void VisaAdditionalAuthData(VisaAdditionalAuthData data)
        {
            SetProperty(GlobalConstants.VisaAdditionalAuthData, data);
        }

        /// <summary>
        /// Get the settlements
        /// </summary>
        /// <returns>List<Settlement></returns>
        public List<Settlement> Settlements()
        {
            return GetProperty(GlobalConstants.Settlements);
        }

        /// <summary>
        /// Set the settlements
        /// </summary>
        /// <returns>void</returns>
        public void Settlements(List<Settlement> data)
        {
            SetProperty(GlobalConstants.Settlements, data);
        }

        /// <summary>
        /// Get the error
        /// </summary>
        /// <returns>Error</returns>
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
        /// Get a new AuthorizationBuilder
        /// </summary>
        /// <returns>AuthorizationBuilder</returns>
        public static AuthorizationBuilder Builder()
        {
            return new AuthorizationBuilder();
        }

        /// <summary>
        /// AuthorizationBuilder will allow an authorization to be initialized.
        /// set all properties and subpropeties, then trigger .Build() to 
        /// get the generated Authorization object
        /// </summary>
        public class AuthorizationBuilder : BaseJsonBuilder<Authorization>
        {
            /// <summary>
            /// Set the id
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthorizationBuilder</returns>
            public AuthorizationBuilder Id(string data)
            {
                Properties[GlobalConstants.Id] = data;
                return this;
            }

            /// <summary>
            /// Set the merchantRefNum parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthorizationBuilder</returns>
            public AuthorizationBuilder MerchantRefNum(string data)
            {
                Properties[GlobalConstants.MerchantRefNum] = data;
                return this;
            }

            /// <summary>
            /// Set the amount parameter
            /// </summary>
            /// <param name=data>int</param>
            /// <returns>AuthorizationBuilder</returns>
            public AuthorizationBuilder Amount(int data)
            {
                Properties[GlobalConstants.Amount] = data;
                return this;
            }
            
            /// <summary>
            /// Build a card within this authorization.
            /// </summary>
            /// <returns>Card.CardBuilder<AuthorizationBuilder></returns>
            public Card.CardBuilder<AuthorizationBuilder> Card()
            {
                if (!Properties.ContainsKey(GlobalConstants.Card))
                {
                    Properties[GlobalConstants.Card] = new Card.CardBuilder<AuthorizationBuilder>(this);
                }
                return Properties[GlobalConstants.Card] as Card.CardBuilder<AuthorizationBuilder>;
            }

            /// <summary>
            /// Set the settleWithAuth property
            /// </summary>
            /// <param name=data>bool</param>
            /// <returns>AuthorizationBuilder</returns>
            public AuthorizationBuilder SettleWithAuth(bool data)
            {
                Properties[GlobalConstants.SettleWithAuth] = data;
                return this;
            }

            /// <summary>
            /// Set the customerIp parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthorizationBuilder</returns>
            public AuthorizationBuilder CustomerIp(string data)
            {
                Properties[GlobalConstants.CustomerIp] = data;
                return this;
            }

            /// <summary>
            /// Set the dupCheck parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthorizationBuilder</returns>
            public AuthorizationBuilder DupCheck(bool data)
            {
                Properties[GlobalConstants.DupCheck] = data;
                return this;
            }

            /// <summary>
            /// Set the description
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthorizationBuilder</returns>
            public AuthorizationBuilder Description(string data)
            {
                Properties[GlobalConstants.Description] = data;
                return this;
            }

            /// <summary>
            /// Build a authentication within this authorization.
            /// </summary>
            /// <returns>PaysafeAuthentication.AuthenticationBuilder<AuthorizationBuilder></returns>
            public PaysafeAuthentication.AuthenticationBuilder<AuthorizationBuilder> Authentication()
            {
                if (!Properties.ContainsKey(GlobalConstants.Authentication))
                {
                    Properties[GlobalConstants.Authentication] = new PaysafeAuthentication.AuthenticationBuilder<AuthorizationBuilder>(this);
                }
                return Properties[GlobalConstants.Authentication] as PaysafeAuthentication.AuthenticationBuilder<AuthorizationBuilder>;
            }

            /// <summary>
            /// Build a billing details object within this authorization.
            /// </summary>
            /// <returns>BillingDetails.BillingDetailsBuilder<AuthorizationBuilder></returns>
            public BillingDetails.BillingDetailsBuilder<AuthorizationBuilder> BillingDetails()
            {
                if (!Properties.ContainsKey(GlobalConstants.BillingDetails))
                {
                    Properties[GlobalConstants.BillingDetails] = new BillingDetails.BillingDetailsBuilder<AuthorizationBuilder>(this);
                }
                return Properties[GlobalConstants.BillingDetails] as BillingDetails.BillingDetailsBuilder<AuthorizationBuilder>;
            }

            /// <summary>
            /// Build a shipping details object within this authorization.
            /// </summary>
            /// <returns>ShippingDetails.ShippingDetailsBuilder<AuthorizationBuilder></returns>
            public ShippingDetails.ShippingDetailsBuilder<AuthorizationBuilder> ShippingDetails()
            {
                if (!Properties.ContainsKey(GlobalConstants.ShippingDetails))
                {
                    Properties[GlobalConstants.ShippingDetails] = new ShippingDetails.ShippingDetailsBuilder<AuthorizationBuilder>(this);
                }
                return Properties[GlobalConstants.ShippingDetails] as ShippingDetails.ShippingDetailsBuilder<AuthorizationBuilder>;
            }

            /// <summary>
            /// Set the recurring parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthorizationBuilder</returns>
            public AuthorizationBuilder Recurring(string data)
            {
                Properties[GlobalConstants.Recurring] = data;
                return this;

            }

            /// <summary>
            /// Build a merchant descriptor object within this authorization.
            /// </summary>
            /// <returns>MerchantDescriptor.MerchantDescriptorBuilder<AuthorizationBuilder></returns>
            public MerchantDescriptor.MerchantDescriptorBuilder<AuthorizationBuilder> MerchantDescriptor()
            {
                if (!Properties.ContainsKey(GlobalConstants.MerchantDescriptor))
                {
                    Properties[GlobalConstants.MerchantDescriptor] = new MerchantDescriptor.MerchantDescriptorBuilder<AuthorizationBuilder>(this);
                }
                return Properties[GlobalConstants.MerchantDescriptor] as MerchantDescriptor.MerchantDescriptorBuilder<AuthorizationBuilder>;
            }

            /// <summary>
            /// Build an accordD object within this authorization.
            /// </summary>
            /// <returns>AccordD.AccordDBuilder<AuthorizationBuilder></returns>
            public AccordD.AccordDBuilder<AuthorizationBuilder> AccordD()
            {
                if (!Properties.ContainsKey(GlobalConstants.AccordD))
                {
                    Properties[GlobalConstants.AccordD] = new AccordD.AccordDBuilder<AuthorizationBuilder>(this);
                }
                return Properties[GlobalConstants.AccordD] as AccordD.AccordDBuilder<AuthorizationBuilder>;
            }
        }
    }
}
