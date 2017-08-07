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
    public class Card : JsonObject
    {
        /// <summary>
        /// Initialize the Card object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Card(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.Id, StringType},
            {GlobalConstants.NickName, StringType},
            {GlobalConstants.SingleUseToken, StringType},
            {GlobalConstants.Status, CustomerVaultConstants.EnumStatus},
            {GlobalConstants.MerchantRefNum, StringType},
            {GlobalConstants.HolderName, StringType},
            {GlobalConstants.CardNum, StringType},
            {GlobalConstants.CardBin, StringType},
            {GlobalConstants.LastDigits, StringType},
            {GlobalConstants.CardExpiry, typeof(CardExpiry)},
            {GlobalConstants.CardType, StringType},
            {GlobalConstants.BillingAddressId, StringType},
            {GlobalConstants.DefaultCardIndicator, BoolType},
            {GlobalConstants.PaymentToken, StringType},
            {GlobalConstants.Error, typeof(OptError)},
            {GlobalConstants.Links, typeof(List<Link>)},
            {GlobalConstants.ProfileId, StringType},
            {GlobalConstants.BillingAddress, typeof(BillingAddress)}
            
        };

        /// <summary>
        /// Get the id
        /// </summary>
        /// <returns>String</returns>
        public String Id()
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
        /// Get the singleUseToken
        /// </summary>
        /// <returns>String</returns>
        public String SingleUseToken()
        {
            return GetProperty(GlobalConstants.SingleUseToken);
        }

        /// <summary>
        /// Set the singleUseToken
        /// </summary>
        /// <returns>void</returns>
        public void SingleUseToken(String data)
        {
            SetProperty(GlobalConstants.SingleUseToken, data);
        }

        /// <summary>
        /// Get the nickName
        /// </summary>
        /// <returns>String</returns>
        public String NickName()
        {
            return GetProperty(GlobalConstants.NickName);
        }

        /// <summary>
        /// Set the nickName
        /// </summary>
        /// <returns>void</returns>
        public void NickName(String data)
        {
            SetProperty(GlobalConstants.NickName, data);
        }

        /// <summary>
        /// Get the status
        /// </summary>
        /// <returns>String</returns>
        public String Status()
        {
            return GetProperty(GlobalConstants.Status);
        }

        /// <summary>
        /// Set the status
        /// </summary>
        /// <returns>void</returns>
        public void Status(String data)
        {
            SetProperty(GlobalConstants.Status, data);
        }

        /// <summary>
        /// Get the merchantRefNum
        /// </summary>
        /// <returns>String</returns>
        public String MerchantRefNum()
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
        /// Get the holderName
        /// </summary>
        /// <returns>String</returns>
        public String HolderName()
        {
            return GetProperty(GlobalConstants.HolderName);
        }

        /// <summary>
        /// Set the holderName
        /// </summary>
        /// <returns>void</returns>
        public void HolderName(String data)
        {
            SetProperty(GlobalConstants.HolderName, data);
        }

        /// <summary>
        /// Get the cardNum
        /// </summary>
        /// <returns>String</returns>
        public String CardNum()
        {
            return GetProperty(GlobalConstants.CardNum);
        }

        /// <summary>
        /// Set the cardNum
        /// </summary>
        /// <returns>void</returns>
        public void CardNum(String data)
        {
            SetProperty(GlobalConstants.CardNum, data);
        }

        /// <summary>
        /// Get the cardBin
        /// </summary>
        /// <returns>String</returns>
        public String CardBin()
        {
            return GetProperty(GlobalConstants.CardBin);
        }

        /// <summary>
        /// Set the cardBin
        /// </summary>
        /// <returns>void</returns>
        public void CardBin(String data)
        {
            SetProperty(GlobalConstants.CardBin, data);
        }

        /// <summary>
        /// Get the lastDigits
        /// </summary>
        /// <returns>String</returns>
        public String LastDigits()
        {
            return GetProperty(GlobalConstants.LastDigits);
        }

        /// <summary>
        /// Set the lastDigits
        /// </summary>
        /// <returns>void</returns>
        public void LastDigits(String data)
        {
            SetProperty(GlobalConstants.LastDigits, data);
        }

        /// <summary>
        /// Get the cardExpiry
        /// </summary>
        /// <returns>CardExpiry</returns>
        public CardExpiry CardExpiry()
        {
            return GetProperty(GlobalConstants.CardExpiry);
        }

        /// <summary>
        /// Set the cardExpiry
        /// </summary>
        /// <returns>void</returns>
        public void CardExpiry(CardExpiry data)
        {
            SetProperty(GlobalConstants.CardExpiry, data);
        }

        /// <summary>
        /// Get the cardType
        /// </summary>
        /// <returns>String</returns>
        public String CardType()
        {
            return GetProperty(GlobalConstants.CardType);
        }

        /// <summary>
        /// Set the cardType
        /// </summary>
        /// <returns>void</returns>
        public void CardType(String data)
        {
            SetProperty(GlobalConstants.CardType, data);
        }
  
        /// <summary>
        /// Get the billingAddressId
        /// </summary>
        /// <returns>String</returns>
        public String BillingAddressId()
        {
            return GetProperty(GlobalConstants.BillingAddressId);
        }

        /// <summary>
        /// Set the billingAddressId
        /// </summary>
        /// <returns>void</returns>
        public void BillingAddressId(String data)
        {
            SetProperty(GlobalConstants.BillingAddressId, data);
        }
        
        /// <summary>
        /// Get the defaultCardIndicator
        /// </summary>
        /// <returns>bool</returns>
        public bool DefaultCardIndicator()
        {
            return GetProperty(GlobalConstants.DefaultCardIndicator);
        }

        /// <summary>
        /// Set the defaultCardIndicator
        /// </summary>
        /// <returns>void</returns>
        public void DefaultCardIndicator(bool data)
        {
            SetProperty(GlobalConstants.DefaultCardIndicator, data);
        }
        
        /// <summary>
        /// Get the paymentToken
        /// </summary>
        /// <returns>String</returns>
        public String PaymentToken()
        {
            return GetProperty(GlobalConstants.PaymentToken);
        }

        /// <summary>
        /// Set the paymentToken
        /// </summary>
        /// <returns>void</returns>
        public void PaymentToken(String data)
        {
            SetProperty(GlobalConstants.PaymentToken, data);
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

        /// <summary>
        /// Get the billingAddress
        /// </summary>
        /// <returns>List<Link></returns>
        public BillingAddress BillingAddress()
        {
            return GetProperty(GlobalConstants.BillingAddress);
        }

        /// <summary>
        /// Set the billingAddress
        /// </summary>
        /// <returns>void</returns>
        public void BillingAddress(BillingAddress data)
        {
            SetProperty(GlobalConstants.BillingAddress, data);
        }

        public static CardBuilder Builder()
        {
            return new CardBuilder();
        }

        /// <summary>
        /// CardBuilder will allow an authorization to be initialized.
        /// set all properties and subpropeties, then trigger .Build() to 
        /// get the generated Card object
        /// </summary>
        public class CardBuilder : BaseJsonBuilder<Card>
        {
            /// <summary>
            /// Set the id parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder</returns>
            public CardBuilder Id(string data)
            {
                Properties[GlobalConstants.Id] = data;
                return this;
            }

            /// <summary>
            /// Set the profileId parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder</returns>
            public CardBuilder ProfileId(string data)
            {
                Properties[GlobalConstants.ProfileId] = data;
                return this;
            }

            /// <summary>
            /// Set the cardNum parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder</returns>
            public CardBuilder CardNum(string data)
            {
                Properties[GlobalConstants.CardNum] = data;
                return this;
            }

            /// <summary>
            /// Build an cardExpiry object within this authorization.
            /// </summary>
            /// <returns>CardExpiry.CardExpiryBuilder<CardBuilder></returns>
            public CardExpiry.CardExpiryBuilder<CardBuilder> CardExpiry()
            {
                if (!Properties.ContainsKey(GlobalConstants.CardExpiry))
                {
                    Properties[GlobalConstants.CardExpiry] = new CardExpiry.CardExpiryBuilder<CardBuilder>(this);
                }
                return Properties[GlobalConstants.CardExpiry] as CardExpiry.CardExpiryBuilder<CardBuilder>;
            }

            /// <summary>
            /// Set the nickName parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder</returns>
            public CardBuilder NickName(string data)
            {
                Properties[GlobalConstants.NickName] = data;
                return this;
            }

            /// <summary>
            /// Set the merchantRefNum parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder</returns>
            public CardBuilder MerchantRefNum(string data)
            {
                Properties[GlobalConstants.MerchantRefNum] = data;
                return this;
            }

            /// <summary>
            /// Set the holderName parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder</returns>
            public CardBuilder HolderName(string data)
            {
                Properties[GlobalConstants.HolderName] = data;
                return this;
            }

            /// <summary>
            /// Set the billingAddressId parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder</returns>
            public CardBuilder BillingAddressId(string data)
            {
                Properties[GlobalConstants.BillingAddressId] = data;
                return this;
            }

            /// <summary>
            /// Build an cardExpiry object within this authorization.
            /// </summary>
            /// <returns>CardExpiry.CardExpiryBuilder<CardBuilder></returns>
            public BillingAddress.BillingAddressBuilder<CardBuilder> BillingAddress()
            {
                if (!Properties.ContainsKey(GlobalConstants.BillingAddress))
                {
                    Properties[GlobalConstants.BillingAddress] = new BillingAddress.BillingAddressBuilder<CardBuilder>(this);
                }
                return Properties[GlobalConstants.BillingAddress] as BillingAddress.BillingAddressBuilder<CardBuilder>;
            }
        }


        /// <summary>
        /// CardBuilder<typeparam name="TBldr"></typeparam> will allow an card to be initialized
        /// within another builder. Set properties and subpropeties, then trigger .Done() to 
        /// get back tot he parent builder
        /// </summary>
        public class CardBuilderSingelUse<TBldr> : NestedJsonBuilder<Card, TBldr>
            where TBldr : GenericJsonBuilder
        {
            /// <summary>
            /// Initialize the Card builder within the context of a parent builder
            /// </summary>
            /// <param name="parent">TBLDR</param>
            public CardBuilderSingelUse(TBldr parent)
                : base(parent)
            {
                Parent = parent;
            }

            /// <summary>
            /// Set the singelUseToken
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder<TBLDR></returns>

            public CardBuilderSingelUse<TBldr> SingleUseToken(String data)
            {
                Properties[GlobalConstants.SingleUseToken] = data;
                return this;
            }

            /// <summary>
            /// Set the id parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder</returns>
            public CardBuilderSingelUse<TBldr> Id(string data)
            {
                Properties[GlobalConstants.Id] = data;
                return this;
            }


            /// <summary>
            /// Set the cardNum parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder</returns>
            public CardBuilderSingelUse<TBldr> CardNum(string data)
            {
                Properties[GlobalConstants.CardNum] = data;
                return this;
            }

            /// <summary>
            /// Build an cardExpiry object within this authorization.
            /// </summary>
            /// <returns>CardExpiry.CardExpiryBuilder<CardBuilder></returns>
            public CardExpiry.CardExpiryBuilder<CardBuilderSingelUse<TBldr>> CardExpiry()
            {
                if (!Properties.ContainsKey(GlobalConstants.CardExpiry))
                {
                    Properties[GlobalConstants.CardExpiry] = new CardExpiry.CardExpiryBuilder<CardBuilderSingelUse<TBldr>>(this);
                }
                return Properties[GlobalConstants.CardExpiry] as CardExpiry.CardExpiryBuilder<CardBuilderSingelUse<TBldr>>;
            }

            /// <summary>
            /// Set the nickName parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder</returns>
            public CardBuilderSingelUse<TBldr> NickName(string data)
            {
                Properties[GlobalConstants.NickName] = data;
                return this;
            }

            /// <summary>
            /// Set the merchantRefNum parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder</returns>
            public CardBuilderSingelUse<TBldr> MerchantRefNum(string data)
            {
                Properties[GlobalConstants.MerchantRefNum] = data;
                return this;
            }

            /// <summary>
            /// Set the holderName parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder</returns>
            public CardBuilderSingelUse<TBldr> HolderName(string data)
            {
                Properties[GlobalConstants.HolderName] = data;
                return this;
            }

            /// <summary>
            /// Set the billingAddressId parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder</returns>
            public CardBuilderSingelUse<TBldr> BillingAddressId(string data)
            {
                Properties[GlobalConstants.BillingAddressId] = data;
                return this;
            }

            /// <summary>
            /// Build an cardExpiry object within this authorization.
            /// </summary>
            /// <returns>CardExpiry.CardExpiryBuilder<CardBuilder></returns>
            public BillingAddress.BillingAddressBuilder<CardBuilderSingelUse<TBldr>> BillingAddress()
            {
                if (!Properties.ContainsKey(GlobalConstants.BillingAddress))
                {
                    Properties[GlobalConstants.BillingAddress] = new BillingAddress.BillingAddressBuilder<CardBuilderSingelUse<TBldr>>(this);
                }
                return Properties[GlobalConstants.BillingAddress] as BillingAddress.BillingAddressBuilder<CardBuilderSingelUse<TBldr>>;
            }

        }


        ///// <summary>
        ///// CardBuilder<typeparam name="TBLDR"></typeparam> will allow an card to be initialized
        ///// within another builder. Set properties and subpropeties, then trigger .Done() to 
        ///// get back tot he parent builder
        ///// </summary>
        //public class CardBuilder1<TBLDR> : NestedJSONBuilder<Card, TBLDR>
        //    where TBLDR : GenericJSONBuilder
        //{
        //    /// <summary>
        //    /// Initialize the Card builder within the context of a parent builder
        //    /// </summary>
        //    /// <param name="parent">TBLDR</param>
        //    public CardBuilder1(TBLDR parent)
        //        : base(parent)
        //    {
        //        parent = parent;
        //    }


        //    /// <summary>
        //    /// Set the id parameter
        //    /// </summary>
        //    /// <param name=data>string</param>
        //    /// <returns>CardBuilder</returns>
        //    public CardBuilder1<TBLDR> id(string data)
        //    {
        //        properties[CustomerVaultConstants.id] = data;
        //        return this;
        //    }


        //    /// <summary>
        //    /// Set the cardNum parameter
        //    /// </summary>
        //    /// <param name=data>string</param>
        //    /// <returns>CardBuilder</returns>
        //    public CardBuilder1<TBLDR> cardNum(string data)
        //    {
        //        properties[CustomerVaultConstants.cardNum] = data;
        //        return this;
        //    }

        //    /// <summary>
        //    /// Build an cardExpiry object within this authorization.
        //    /// </summary>
        //    /// <returns>CardExpiry.CardExpiryBuilder<CardBuilder></returns>
        //    public CardExpiry.CardExpiryBuilder<CardBuilder1<TBLDR>> cardExpiry()
        //    {
        //        if (!properties.ContainsKey(CustomerVaultConstants.cardExpiry))
        //        {
        //            properties[CustomerVaultConstants.cardExpiry] = new CardExpiry.CardExpiryBuilder<CardBuilder1<TBLDR>>(this);
        //        }
        //        return properties[CustomerVaultConstants.cardExpiry] as CardExpiry.CardExpiryBuilder<CardBuilder1<TBLDR>>;
        //    }

        //    /// <summary>
        //    /// Set the nickName parameter
        //    /// </summary>
        //    /// <param name=data>string</param>
        //    /// <returns>CardBuilder</returns>
        //    public CardBuilder1<TBLDR> nickName(string data)
        //    {
        //        properties[CustomerVaultConstants.nickName] = data;
        //        return this;
        //    }

        //    /// <summary>
        //    /// Set the merchantRefNum parameter
        //    /// </summary>
        //    /// <param name=data>string</param>
        //    /// <returns>CardBuilder</returns>
        //    public CardBuilder1<TBLDR> merchantRefNum(string data)
        //    {
        //        properties[CustomerVaultConstants.merchantRefNum] = data;
        //        return this;
        //    }

        //    /// <summary>
        //    /// Set the holderName parameter
        //    /// </summary>
        //    /// <param name=data>string</param>
        //    /// <returns>CardBuilder</returns>
        //    public CardBuilder1<TBLDR> holderName(string data)
        //    {
        //        properties[CustomerVaultConstants.holderName] = data;
        //        return this;
        //    }

        //    /// <summary>
        //    /// Set the billingAddressId parameter
        //    /// </summary>
        //    /// <param name=data>string</param>
        //    /// <returns>CardBuilder</returns>
        //    public CardBuilder1<TBLDR> billingAddressId(string data)
        //    {
        //        properties[CustomerVaultConstants.billingAddressId] = data;
        //        return this;
        //    }

        //    /// <summary>
        //    /// Build an cardExpiry object within this authorization.
        //    /// </summary>
        //    /// <returns>CardExpiry.CardExpiryBuilder<CardBuilder></returns>
        //    public BillingAddress.BillingAddressBuilder<CardBuilder1<TBLDR>> billingAddress()
        //    {
        //        if (!properties.ContainsKey(CustomerVaultConstants.billingAddress))
        //        {
        //            properties[CustomerVaultConstants.billingAddress] = new BillingAddress.BillingAddressBuilder<CardBuilder1<TBLDR>>(this);
        //        }
        //        return properties[CustomerVaultConstants.billingAddress] as BillingAddress.BillingAddressBuilder<CardBuilder1<TBLDR>>;
        //    }
        //}


    }
}
