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
    //Created by Manjiri.Bankar on 03.05.2016. This is EFTBankAccounts class.
    public class EftBankAccounts : JsonObject
    {
        /// <summary>
        /// Initialize the EFTBankAccounts object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public EftBankAccounts(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.Id,StringType},            
            {GlobalConstants.NickName, StringType},
            {GlobalConstants.MerchantRefNum, StringType},
            {GlobalConstants.Status, CustomerVaultConstants.EnumStatus},
            {GlobalConstants.StatusReason, StringType},
            {GlobalConstants.AccountNumber, StringType},
            {GlobalConstants.AccountHolderName, StringType},
            {GlobalConstants.TransitNumber, StringType}, 
            {GlobalConstants.InstitutionId, StringType},
            {GlobalConstants.LastDigits, StringType},
            {GlobalConstants.BillingAddressId, StringType},
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
        /// Get the nickName
        /// </summary>
        /// <returns>string</returns>
        public string NickName()
        {
            return GetProperty(GlobalConstants.NickName);
        }

        /// <summary>
        /// Set the nickName
        /// </summary>
        /// <returns>void</returns>
        public void NickName(string data)
        {
            SetProperty(GlobalConstants.NickName, data);
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
        /// Get the transitNumber
        /// </summary>
        /// <returns>string</returns>
        public string TransitNumber()
        {
            return GetProperty(GlobalConstants.SortCode);
        }

        /// <summary>
        /// Set the transitNumber
        /// </summary>
        /// <returns>void</returns>
        public void TransitNumber(string data)
        {
            SetProperty(GlobalConstants.SortCode, data);
        }

        /// <summary>
        /// Get the institutionId
        /// </summary>
        /// <returns>string</returns>
        public string InstitutionId()
        {
            return GetProperty(GlobalConstants.SortCode);
        }

        /// <summary>
        /// Set the institutionId
        /// </summary>
        /// <returns>void</returns>
        public void InstitutionId(string data)
        {
            SetProperty(GlobalConstants.SortCode, data);
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
        /// Get the billingAddressId
        /// </summary>
        /// <returns>string</returns>
        public string BillingAddressId()
        {
            return GetProperty(GlobalConstants.BillingAddressId);
        }

        /// <summary>
        /// Set the billingAddressId
        /// </summary>
        /// <returns>void</returns>
        public void BillingAddressId(string data)
        {
            SetProperty(GlobalConstants.BillingAddressId, data);
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

        public static EftAccountBuilder Builder()
        {
            return new EftAccountBuilder();
        }

        /// <summary>
        /// EFTAccountBuilder will allow an account to be initialized.
        /// set all properties and subpropeties, then trigger .Build() to 
        /// get the generated EFTAccount object
        /// </summary>
        public class EftAccountBuilder : BaseJsonBuilder<EftBankAccounts>
        {
            /// <summary>
            /// Set the id parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EFTAccountBuilder</returns>
            public EftAccountBuilder Id(string data)
            {
                Properties[GlobalConstants.Id] = data;
                return this;
            }

            /// <summary>
            /// Set the nickName parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EFTAccountBuilder</returns>
            public EftAccountBuilder NickName(string data)
            {
                Properties[GlobalConstants.NickName] = data;
                return this;
            }

            /// <summary>
            /// Set the merchantRefNum parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EFTAccountBuilder</returns>
            public EftAccountBuilder MerchantRefNum(string data)
            {
                Properties[GlobalConstants.MerchantRefNum] = data;
                return this;
            }

            /// <summary>
            /// Set the status parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EFTAccountBuilder</returns>
            public EftAccountBuilder Status(string data)
            {
                Properties[GlobalConstants.Status] = data;
                return this;
            }

            /// <summary>
            /// Set the statusReason parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EFTAccountBuilder</returns>
            public EftAccountBuilder StatusReason(string data)
            {
                Properties[GlobalConstants.StatusReason] = data;
                return this;
            }

            /// <summary>
            /// Set the accountNumber parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EFTAccountBuilder</returns>
            public EftAccountBuilder AccountNumber(string data)
            {
                Properties[GlobalConstants.AccountNumber] = data;
                return this;
            }

            /// <summary>
            /// Set the accountHolderName parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EFTAccountBuilder</returns>
            public EftAccountBuilder AccountHolderName(string data)
            {
                Properties[GlobalConstants.AccountHolderName] = data;
                return this;
            }

            /// <summary>
            /// Set the transitNumber parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EFTAccountBuilder</returns>
            public EftAccountBuilder TransitNumber(string data)
            {
                Properties[GlobalConstants.TransitNumber] = data;
                return this;
            }

            /// <summary>
            /// Set the institutionId parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EFTAccountBuilder</returns>
            public EftAccountBuilder InstitutionId(string data)
            {
                Properties[GlobalConstants.InstitutionId] = data;
                return this;
            }           

            /// <summary>
            /// Set the lastDigits parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EFTAccountBuilder</returns>
            public EftAccountBuilder LastDigits(string data)
            {
                Properties[GlobalConstants.LastDigits] = data;
                return this;
            }

            /// <summary>
            /// Set the billingAddressId parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EFTAccountBuilder</returns>
            public EftAccountBuilder BillingAddressId(string data)
            {
                Properties[GlobalConstants.BillingAddressId] = data;
                return this;
            }

            /// <summary>
            /// Set the paymentToken parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EFTAccountBuilder</returns>
            public EftAccountBuilder PaymentToken(string data)
            {
                Properties[GlobalConstants.PaymentToken] = data;
                return this;
            }
           

            /// <summary>
            /// Set the profileId parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>EFTAccountBuilder</returns>
            public EftAccountBuilder ProfileId(string data)
            {
                Properties[GlobalConstants.ProfileId] = data;
                return this;
            }
        }   
    }
}
