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
    public class Address : AddressDetails
    {
        /// <summary>
        /// Initialize the Address object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Address(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>(AddressFieldTypes)
        {
            {GlobalConstants.Id, StringType},
            {GlobalConstants.NickName, StringType},
            {GlobalConstants.Status, CustomerVaultConstants.EnumStatus},
            {GlobalConstants.RecipientName, StringType},
            {GlobalConstants.DefaultShippingAddressIndicator, BoolType},
            {GlobalConstants.Error, typeof(OptError)},
            {GlobalConstants.Links, typeof(List<Link>)},
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
        /// Get the recipientName
        /// </summary>
        /// <returns>string</returns>
        public string RecipientName()
        {
            return GetProperty(GlobalConstants.RecipientName);
        }

        /// <summary>
        /// Set the recipientName
        /// </summary>
        /// <returns>void</returns>
        public void RecipientName(string data)
        {
            SetProperty(GlobalConstants.RecipientName, data);
        }

        /// <summary>
        /// Get the defaultShippingAddressIndicator
        /// </summary>
        /// <returns>bool</returns>
        public string DefaultShippingAddressIndicator()
        {
            return GetProperty(GlobalConstants.DefaultShippingAddressIndicator);
        }

        /// <summary>
        /// Set the defaultShippingAddressIndicator
        /// </summary>
        /// <returns>bool</returns>
        public void DefaultShippingAddressIndicator(bool data)
        {
            SetProperty(GlobalConstants.DefaultShippingAddressIndicator, data);
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
        /// Get the profileId
        /// </summary>
        /// <returns>string</returns>
        public string ProfileId()
        {
            return GetProperty(GlobalConstants.ProfileId);
        }

        /// <summary>
        /// Set the profileId
        /// </summary>
        /// <returns>void</returns>
        public void ProfileId(string data)
        {
            SetProperty(GlobalConstants.ProfileId, data);
        }

        public static AddressBuilder Builder()
        {
            return new AddressBuilder();
        }

        /// <summary>
        /// AddressBuilder will allow an authorization to be initialized.
        /// set all properties and subpropeties, then trigger .Build() to 
        /// get the generated Address object
        /// </summary>
        public class AddressBuilder : BaseJsonBuilder<Address>
        {
            /// <summary>
            /// Set the profileId parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AddressBuilder</returns>
            public AddressBuilder Id(string data)
            {
                Properties[GlobalConstants.Id] = data;
                return this;
            }

            /// <summary>
            /// Set the profileId parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AddressBuilder</returns>
            public AddressBuilder ProfileId(string data)
            {
                Properties[GlobalConstants.ProfileId] = data;
                return this;
            }

            /// <summary>
            /// Set the country parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AddressBuilder</returns>
            public AddressBuilder Country(string data)
            {
                Properties[GlobalConstants.Country] = data;
                return this;
            }

            /// <summary>
            /// Set the nickName parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AddressBuilder</returns>
            public AddressBuilder NickName(string data)
            {
                Properties[GlobalConstants.NickName] = data;
                return this;
            }

            /// <summary>
            /// Set the street parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AddressBuilder</returns>
            public AddressBuilder Street(string data)
            {
                Properties[GlobalConstants.Street] = data;
                return this;
            }

            /// <summary>
            /// Set the street2 parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AddressBuilder</returns>
            public AddressBuilder Street2(string data)
            {
                Properties[GlobalConstants.Street2] = data;
                return this;
            }

            /// <summary>
            /// Set the city parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AddressBuilder</returns>
            public AddressBuilder City(string data)
            {
                Properties[GlobalConstants.City] = data;
                return this;
            }

            /// <summary>
            /// Set the state parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AddressBuilder</returns>
            public AddressBuilder State(string data)
            {
                Properties[GlobalConstants.State] = data;
                return this;
            }

            /// <summary>
            /// Set the zip parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AddressBuilder</returns>
            public AddressBuilder Zip(string data)
            {
                Properties[GlobalConstants.Zip] = data;
                return this;
            }

            /// <summary>
            /// Set the recipientName parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AddressBuilder</returns>
            public AddressBuilder RecipientName(string data)
            {
                Properties[GlobalConstants.RecipientName] = data;
                return this;
            }

            /// <summary>
            /// Set the phone parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AddressBuilder</returns>
            public AddressBuilder Phone(string data)
            {
                Properties[GlobalConstants.Phone] = data;
                return this;
            }
        }
    }
}
