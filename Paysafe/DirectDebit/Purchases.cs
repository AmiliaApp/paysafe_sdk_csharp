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

namespace Paysafe.DirectDebit
{
    //Created by Manjiri.Bankar on 03.05.2016. This is Purchases class.
    public class Purchases : JsonObject
    {
        /// <summary>
        /// Initialize the Purchases object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Purchases(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        /// <summary>
        /// Initialize an Purchases object with an id
        /// </summary>
        /// <param name="id"></param>
        public Purchases(String id)
            : base(_fieldTypes)
        {
            Id(id);
        }

        /// <summary>
        /// Gets the array key to access the array of purchase
        /// </summary>
        /// <returns>The key to be checked in the returning JSON</returns>
        public static string GetPageableArrayKey()
        {
            return "purchases";
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.Id, StringType},
            {GlobalConstants.MerchantRefNum,StringType },
            {GlobalConstants.Amount, IntType},
            {GlobalConstants.Ach, typeof(AchBankAccounts)},
            {GlobalConstants.Eft, typeof(EftBankAccounts)},
            {GlobalConstants.Bacs, typeof(BacsBankAccounts)},
            {GlobalConstants.Sepa, typeof(SepaBankAccounts)},
            {GlobalConstants.Profile,typeof(Profile)},
            {GlobalConstants.BillingDetails, typeof(BillingDetails)},
            {GlobalConstants.CustomerIp, StringType},
            {GlobalConstants.DupCheck, BoolType},
            {GlobalConstants.TxnTime, typeof(DateTime)},
            {GlobalConstants.CurrencyCode,StringType},
            {GlobalConstants.Error, typeof(OptError)},             
            {GlobalConstants.Status, DirectDebitConstants.EnumStatus},          
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
        /// Get the ach
        /// </summary>
        /// <returns>ACHBankAccount</returns>
        public AchBankAccounts Ach()
        {
            return GetProperty(GlobalConstants.Ach);
        }

        /// <summary>
        /// Set the ach
        /// </summary>
        /// <returns>void</returns>
        public void Ach(AchBankAccounts data)
        {
            SetProperty(GlobalConstants.Ach, data);
        }

        /// <summary>
        /// Get the eft
        /// </summary>
        /// <returns>EFTBankAccount</returns>
        public EftBankAccounts Eft()
        {
            return GetProperty(GlobalConstants.Eft);
        }

        /// <summary>
        /// Set the eft
        /// </summary>
        /// <returns>void</returns>
        public void Eft(EftBankAccounts data)
        {
            SetProperty(GlobalConstants.Eft, data);
        }

        /// <summary>
        /// Get the bacs
        /// </summary>
        /// <returns>BACSBankAccount</returns>
        public BacsBankAccounts Bacs()
        {
            return GetProperty(GlobalConstants.Bacs);
        }

        /// <summary>
        /// Set the bacs
        /// </summary>
        /// <returns>void</returns>
        public void Bacs(BacsBankAccounts data)
        {
            SetProperty(GlobalConstants.Bacs, data);
        }

        /// <summary>
        /// Get the sepa
        /// </summary>
        /// <returns>SEPABankAccount</returns>
        public SepaBankAccounts Sepa()
        {
            return GetProperty(GlobalConstants.Sepa);
        }

        /// <summary>
        /// Set the sepa
        /// </summary>
        /// <returns>void</returns>
        public void Sepa(SepaBankAccounts data)
        {
            SetProperty(GlobalConstants.Sepa, data);
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
        /// Get the billingDetails
        /// </summary>
        /// <returns>string</returns>
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
        public void DupCheck(string data)
        {
            SetProperty(GlobalConstants.DupCheck, data);
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
        public void Ip(string data)
        {
            SetProperty(GlobalConstants.CurrencyCode, data);
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
            SetProperty(GlobalConstants.Links, data);
        }

        public static PurchasesBuilder Builder()
        {
            return new PurchasesBuilder();
        }

        /// <summary>
        /// PurchasesBuilder will allow an authorization to be initialized.
        /// set all properties and subpropeties, then trigger .Build() to 
        /// get the generated Profile object
        /// </summary>
        public class PurchasesBuilder : BaseJsonBuilder<Purchases>
        {

            /// <summary>
            /// Set the id parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>PurchasesBuilder</returns>
            public PurchasesBuilder Id(string data)
            {
                Properties[GlobalConstants.Id] = data;
                return this;
            }

            /// <summary>
            /// Set the merchantRefNum parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>PurchasesBuilder</returns>
            public PurchasesBuilder MerchantRefNum(string data)
            {
                Properties[GlobalConstants.MerchantRefNum] = data;
                return this;
            }

            /// <summary>
            /// Set the amount parameter
            /// </summary>
            /// <param name=data>List<string></param>
            /// <returns>PurchasesBuilder</returns>
            public PurchasesBuilder Amount(int data)
            {
                Properties[GlobalConstants.Amount] = data;
                return this;
            }

            /// <summary>
            /// Build a ACHBankAccount within this authorization.
            /// </summary>
            /// <returns>ACHBankAccount.ACHAccountBuilder<ProfileBuilder></returns>
            public AchBankAccounts.AchAccountBuilder<PurchasesBuilder> Ach()
            {
                if (!Properties.ContainsKey(GlobalConstants.Ach))
                {
                    Properties[GlobalConstants.Ach] = new AchBankAccounts.AchAccountBuilder<PurchasesBuilder>(this);
                }
                return Properties[GlobalConstants.Ach] as AchBankAccounts.AchAccountBuilder<PurchasesBuilder>;
            }

            /// <summary>
            /// Build a BACSBankAccount within this authorization.
            /// </summary>
            /// <returns>BACSBankAccount.BACSBankAccountBuilder></returns>
            public BacsBankAccounts.BacsBankAccountBuilder<PurchasesBuilder> Bacs()
            {
                if (!Properties.ContainsKey(GlobalConstants.Bacs))
                {
                    Properties[GlobalConstants.Bacs] = new BacsBankAccounts.BacsBankAccountBuilder<PurchasesBuilder>(this);
                }
                return Properties[GlobalConstants.Bacs] as BacsBankAccounts.BacsBankAccountBuilder<PurchasesBuilder>;
            }

            /// <summary>
            /// Build a EFTBankAccount within this authorization.
            /// </summary>
            /// <returns>EFTBankAccount.EFTAccountBuilder</returns>
            public EftBankAccounts.EftAccountBuilder<PurchasesBuilder> Eft()
            {
                if (!Properties.ContainsKey(GlobalConstants.Eft))
                {
                    Properties[GlobalConstants.Eft] = new EftBankAccounts.EftAccountBuilder<PurchasesBuilder>(this);
                }
                return Properties[GlobalConstants.Eft] as EftBankAccounts.EftAccountBuilder<PurchasesBuilder>;
            }

            /// <summary>
            /// Build a SEPABankAccount within this authorization.
            /// </summary>
            /// <returns>SEPABankAccount.SEPAAccountBuilder</returns>
            public SepaBankAccounts.SepaAccountBuilder<PurchasesBuilder> Sepa()
            {
                if (!Properties.ContainsKey(GlobalConstants.Sepa))
                {
                    Properties[GlobalConstants.Sepa] = new SepaBankAccounts.SepaAccountBuilder<PurchasesBuilder>(this);
                }
                return Properties[GlobalConstants.Sepa] as SepaBankAccounts.SepaAccountBuilder<PurchasesBuilder>;
            }
            
            /// <summary>
            /// Build a profile within this authorization.
            /// </summary>
            /// <returns>profile.profileBuilder<ProfileBuilder></returns>
            public Profile.ProfileBuilder<PurchasesBuilder> Profile()
            {
                if (!Properties.ContainsKey(GlobalConstants.Profile))
                {
                    Properties[GlobalConstants.Profile] = new Profile.ProfileBuilder<PurchasesBuilder>(this);
                }
                return Properties[GlobalConstants.Profile] as Profile.ProfileBuilder<PurchasesBuilder>;
            }
           
            /// <summary>
            /// Build a billing details object within this authorization.
            /// </summary>
            /// <returns>BillingDetails.BillingDetailsBuilder<AuthorizationBuilder></returns>
            public BillingDetails.BillingDetailsBuilder<PurchasesBuilder> BillingDetails()
            {
                if (!Properties.ContainsKey(GlobalConstants.BillingDetails))
                {
                    Properties[GlobalConstants.BillingDetails] = new BillingDetails.BillingDetailsBuilder<PurchasesBuilder>(this);
                }
                return Properties[GlobalConstants.BillingDetails] as BillingDetails.BillingDetailsBuilder<PurchasesBuilder>;
            }

            /// <summary>
            /// Set the customerIp parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>PurchasesBuilder</returns>
            public PurchasesBuilder CustomerIp(string data)
            {
                Properties[GlobalConstants.CustomerIp] = data;
                return this;
            }

            /// <summary>
            /// Set the dupCheck parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>PurchasesBuilder</returns>
            public PurchasesBuilder DupCheck(bool data)
            {
                Properties[GlobalConstants.DupCheck] = data;
                return this;
            }

            /// <summary>
            /// Set the currencyCode parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>PurchasesBuilder</returns>
            public PurchasesBuilder CurrencyCode(string data)
            {
                Properties[GlobalConstants.CurrencyCode] = data;
                return this;
            }

            /// <summary>
            /// Set the status parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>PurchasesBuilder</returns>
            public PurchasesBuilder Status(string data)
            {
                Properties[GlobalConstants.Status] = data;
                return this;
            }           
        }
    }
        
}
