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

namespace Paysafe.CustomerVault
{
    public class Profile : JsonObject
    {
        /// <summary>
        /// Initialize the Profile object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Profile(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.Id, StringType},
            {GlobalConstants.Status, CustomerVaultConstants.EnumStatus},
            {GlobalConstants.MerchantCustomerId, StringType},
            {GlobalConstants.Locale,  GlobalConstants.EnumLocale},
            {GlobalConstants.FirstName, StringType},
            {GlobalConstants.MiddleName, StringType},
            {GlobalConstants.LastName, StringType},
            {GlobalConstants.DateOfBirth, typeof(DateOfBirth)},
            {GlobalConstants.Ip, StringType},
            {GlobalConstants.Gender, GlobalConstants.EnumGender},
            {GlobalConstants.Nationality, StringType},
            {GlobalConstants.Email, EmailType},
            {GlobalConstants.Phone, StringType},
            {GlobalConstants.CellPhone, StringType},
            {GlobalConstants.PaymentToken, StringType},
            {GlobalConstants.Addresses, typeof(List<Address>)},
            {GlobalConstants.Cards, typeof(List<Card>)},
            {GlobalConstants.Error, typeof(OptError)},
            {GlobalConstants.Links, typeof(List<Link>)},
            {GlobalConstants.Card, typeof(Card)},
            {GlobalConstants.AchBankAccounts, typeof(List<AchBankAccounts>)},
            {GlobalConstants.BacsBankAccounts, typeof(List<BacsBankAccounts>)},
            {GlobalConstants.SepaBankAccounts, typeof(List<SepaBankAccounts>)},
            {GlobalConstants.EftBankAccounts, typeof(List<EftBankAccounts>)}
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
        /// Get the merchantCustomerId
        /// </summary>
        /// <returns>string</returns>
        public string MerchantCustomerId()
        {
            return GetProperty(GlobalConstants.MerchantCustomerId);
        }

        /// <summary>
        /// Set the merchantCustomerId
        /// </summary>
        /// <returns>void</returns>
        public void MerchantCustomerId(string data)
        {
            SetProperty(GlobalConstants.MerchantCustomerId, data);
        }

        /// <summary>
        /// Get the locale
        /// </summary>
        /// <returns>string</returns>
        public string Locale()
        {
            return GetProperty(GlobalConstants.Locale);
        }

        /// <summary>
        /// Set the locale
        /// </summary>
        /// <returns>void</returns>
        public void Locale(string data)
        {
            SetProperty(GlobalConstants.Locale, data);
        }

        /// <summary>
        /// Get the firstName
        /// </summary>
        /// <returns>string</returns>
        public string FirstName()
        {
            return GetProperty(GlobalConstants.FirstName);
        }

        /// <summary>
        /// Set the firstName
        /// </summary>
        /// <returns>void</returns>
        public void FirstName(string data)
        {
            SetProperty(GlobalConstants.FirstName, data);
        }

        /// <summary>
        /// Get the lastName
        /// </summary>
        /// <returns>string</returns>
        public string LastName()
        {
            return GetProperty(GlobalConstants.LastName);
        }

        /// <summary>
        /// Set the lastName
        /// </summary>
        /// <returns>void</returns>
        public void LastName(string data)
        {
            SetProperty(GlobalConstants.LastName, data);
        }

        /// <summary>
        /// Get the dateOfBirth
        /// </summary>
        /// <returns>DateOfBirth</returns>
        public DateOfBirth DateOfBirth()
        {
            return GetProperty(GlobalConstants.DateOfBirth);
        }

        /// <summary>
        /// Set the dateOfBirth
        /// </summary>
        /// <returns>void</returns>
        public void DateOfBirth(DateOfBirth data)
        {
            SetProperty(GlobalConstants.DateOfBirth, data);
        }

        /// <summary>
        /// Get the ip
        /// </summary>
        /// <returns>string</returns>
        public string Ip()
        {
            return GetProperty(GlobalConstants.Ip);
        }

        /// <summary>
        /// Set the ip
        /// </summary>
        /// <returns>void</returns>
        public void Ip(string data)
        {
            SetProperty(GlobalConstants.Ip, data);
        }

        /// <summary>
        /// Get the gender
        /// </summary>
        /// <returns>string</returns>
        public string Gender()
        {
            return GetProperty(GlobalConstants.Gender);
        }

        /// <summary>
        /// Set the gender
        /// </summary>
        /// <returns>void</returns>
        public void Gender(string data)
        {
            SetProperty(GlobalConstants.Gender, data);
        }

        /// <summary>
        /// Get the nationality
        /// </summary>
        /// <returns>string</returns>
        public string Nationality()
        {
            return GetProperty(GlobalConstants.Nationality);
        }

        /// <summary>
        /// Set the nationality
        /// </summary>
        /// <returns>void</returns>
        public void Nationality(string data)
        {
            SetProperty(GlobalConstants.Nationality, data);
        }

        /// <summary>
        /// Get the email
        /// </summary>
        /// <returns>string</returns>
        public string Email()
        {
            return GetProperty(GlobalConstants.Email);
        }

        /// <summary>
        /// Set the email
        /// </summary>
        /// <returns>void</returns>
        public void Email(string data)
        {
            SetProperty(GlobalConstants.Email, data);
        }

        /// <summary>
        /// Get the phone
        /// </summary>
        /// <returns>string</returns>
        public string Phone()
        {
            return GetProperty(GlobalConstants.Phone);
        }

        /// <summary>
        /// Set the phone
        /// </summary>
        /// <returns>void</returns>
        public void Phone(string data)
        {
            SetProperty(GlobalConstants.Phone, data);
        }

        /// <summary>
        /// Get the cellPhone
        /// </summary>
        /// <returns>string</returns>
        public string CellPhone()
        {
            return GetProperty(GlobalConstants.CellPhone);
        }

        /// <summary>
        /// Set the cellPhone
        /// </summary>
        /// <returns>string</returns>
        public void CellPhone(string data)
        {
            SetProperty(GlobalConstants.CellPhone, data);
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
        /// Get the addresses
        /// </summary>
        /// <returns>List<Address></returns>
        public List<Address> Addresses()
        {
            return GetProperty(GlobalConstants.Addresses);
        }

        /// <summary>
        /// Set the addresses
        /// </summary>
        /// <returns>void</returns>
        public void Addresses(List<Address> data)
        {
            SetProperty(GlobalConstants.Addresses, data);
        }

        /// <summary>
        /// Get the cards
        /// </summary>
        /// <returns>List<Card></returns>
        public List<Card> Cards()
        {
            return GetProperty(GlobalConstants.Cards);
        }

        /// <summary>
        /// Set the cards
        /// </summary>
        /// <returns>void</returns>
        public void Cards(List<Card> data)
        {
            SetProperty(GlobalConstants.Cards, data);
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
        /// <returns>List<Paysafe.Common.Link></returns>
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
        /// Get the achBankAccounts
        /// </summary>
        /// <returns>List<Address></returns>
        public List<AchBankAccounts> AchBankAccounts()
        {
            return GetProperty(GlobalConstants.AchBankAccounts);
        }

        /// <summary>
        /// Set the achBankAccounts
        /// </summary>
        /// <returns>void</returns>
        public void AchBankAccounts(List<AchBankAccounts> data)
        {
            SetProperty(GlobalConstants.AchBankAccounts, data);
        }

        /// <summary>
        /// Get the bacsBankAccounts
        /// </summary>
        /// <returns>List<Address></returns>
        public List<BacsBankAccounts> BacsBankAccounts()
        {
            return GetProperty(GlobalConstants.BacsBankAccounts);
        }

        /// <summary>
        /// Set the bacsBankAccounts
        /// </summary>
        /// <returns>void</returns>
        public void BacsBankAccounts(List<BacsBankAccounts> data)
        {
            SetProperty(GlobalConstants.BacsBankAccounts, data);
        }
        /// <summary>
        /// Get the sepaBankAccounts
        /// </summary>
        /// <returns>List<Address></returns>
        public List<SepaBankAccounts> SepaBankAccounts()
        {
            return GetProperty(GlobalConstants.SepaBankAccounts);
        }

        /// <summary>
        /// Set the sepaBankAccounts
        /// </summary>
        /// <returns>void</returns>
        public void SepaBankAccounts(List<SepaBankAccounts> data)
        {
            SetProperty(GlobalConstants.SepaBankAccounts, data);
        }
        /// <summary>
        /// Get the eftBankAccounts
        /// </summary>
        /// <returns>List<Address></returns>
        public List<EftBankAccounts> EftBankAccounts()
        {
            return GetProperty(GlobalConstants.EftBankAccounts);
        }

        /// <summary>
        /// Set the eftBankAccounts
        /// </summary>
        /// <returns>void</returns>
        public void EftBankAccounts(List<EftBankAccounts> data)
        {
            SetProperty(GlobalConstants.EftBankAccounts, data);
        }

        public static ProfileBuilder Builder()
        {
            return new ProfileBuilder();
        }

        /// <summary>
        /// ProfileBuilder will allow an authorization to be initialized.
        /// set all properties and subpropeties, then trigger .Build() to 
        /// get the generated Profile object
        /// </summary>
        public class ProfileBuilder : BaseJsonBuilder<Profile>
        {

            /// <summary>
            /// Set the id parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder</returns>
            public ProfileBuilder Id(string data)
            {
                Properties[GlobalConstants.Id] = data;
                return this;
            }

            /// <summary>
            /// Set the merchantCustomerId parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder</returns>
            public ProfileBuilder MerchantCustomerId(string data)
            {
                Properties[GlobalConstants.MerchantCustomerId] = data;
                return this;
            }

            /// <summary>
            /// Set the locale parameter
            /// </summary>
            /// <param name=data>List<string></param>
            /// <returns>ProfileBuilder</returns>
            public ProfileBuilder Locale(string data)
            {
                Properties[GlobalConstants.Locale] = data;
                return this;
            }

            /// <summary>
            /// Set the firstName parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder</returns>
            public ProfileBuilder FirstName(string data)
            {
                Properties[GlobalConstants.FirstName] = data;
                return this;
            }

            /// <summary>
            /// Set the middleName parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder</returns>
            public ProfileBuilder MiddleName(string data)
            {
                Properties[GlobalConstants.MiddleName] = data;
                return this;
            }

            /// <summary>
            /// Set the lastName parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder</returns>
            public ProfileBuilder LastName(string data)
            {
                Properties[GlobalConstants.LastName] = data;
                return this;
            }

            /// <summary>
            /// Build a dateOfBirth within this authorization.
            /// </summary>
            /// <returns>DateOfBirth.DateOfBirthBuilder<ProfileBuilder></returns>
            public DateOfBirth.DateOfBirthBuilder<ProfileBuilder> DateOfBirth()
            {
                if (!Properties.ContainsKey(GlobalConstants.DateOfBirth))
                {
                    Properties[GlobalConstants.DateOfBirth] = new DateOfBirth.DateOfBirthBuilder<ProfileBuilder>(this);
                }
                return Properties[GlobalConstants.DateOfBirth] as DateOfBirth.DateOfBirthBuilder<ProfileBuilder>;
            }

            /// <summary>
            /// Set the ip parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder</returns>
            public ProfileBuilder Ip(string data)
            {
                Properties[GlobalConstants.Ip] = data;
                return this;
            }

            /// <summary>
            /// Set the gender parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder</returns>
            public ProfileBuilder Gender(string data)
            {
                Properties[GlobalConstants.Gender] = data;
                return this;
            }

            /// <summary>
            /// Set the nationality parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder</returns>
            public ProfileBuilder Nationality(string data)
            {
                Properties[GlobalConstants.Nationality] = data;
                return this;
            }

            /// <summary>
            /// Set the email parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder</returns>
            public ProfileBuilder Email(string data)
            {
                Properties[GlobalConstants.Email] = data;
                return this;
            }

            /// <summary>
            /// Set the phone parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder</returns>
            public ProfileBuilder Phone(string data)
            {
                Properties[GlobalConstants.Phone] = data;
                return this;
            }

            /// <summary>
            /// Set the cellPhone parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder</returns>
            public ProfileBuilder CellPhone(string data)
            {
                Properties[GlobalConstants.CellPhone] = data;
                return this;
            }

            /// <summary>
            /// Build a card object within this Profile.
            /// </summary>
            /// <returns>Profile.profileBuilder<VerificationBuilder></returns>
            public Card.CardBuilderSingelUse<ProfileBuilder> Card()
            {
                if (!Properties.ContainsKey(GlobalConstants.Card))
                {
                    Properties[GlobalConstants.Card] = new Card.CardBuilderSingelUse<ProfileBuilder>(this);
                }
                return Properties[GlobalConstants.Card] as Card.CardBuilderSingelUse<ProfileBuilder>;
            }

        }
    }
}
