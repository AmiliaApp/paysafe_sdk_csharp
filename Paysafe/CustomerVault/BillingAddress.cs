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
    public class BillingAddress : AddressDetails
    {

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>(AddressFieldTypes);

        public BillingAddress(Dictionary<string, object> properties)
            : base(_fieldTypes, properties)
        {
        }


        /// <summary>
        /// BillingAddressBuilder<typeparam name="TBldr"></typeparam> will allow a BillingAddress to be initialized
        /// within another builder. Set properties and subpropeties, then trigger .Done() to 
        /// get back to the parent builder
        /// </summary>
        public class BillingAddressBuilder<TBldr> : NestedJsonBuilder<BillingAddress, TBldr>
            where TBldr : GenericJsonBuilder
        {
            /// <summary>
            /// Initialize the BillingDetails builder within the context of a parent builder
            /// </summary>
            /// <param name="parent">TBLDR</param>
            public BillingAddressBuilder(TBldr parent)
                : base(parent)
            {
                Parent = parent;
            }

            /// <summary>
            /// Set the nickName
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>BillingAddressBuilder<TBLDR></returns>
            public BillingAddressBuilder<TBldr> NickName(string data)
            {
                Properties[GlobalConstants.NickName] = data;
                return this;
            }

            /// <summary>
            /// Set the street
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>BillingAddressBuilder<TBLDR></returns>
            public BillingAddressBuilder<TBldr> Street(string data)
            {
                Properties[GlobalConstants.Street] = data;
                return this;
            }

            /// <summary>
            /// Set the street2
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>BillingAddressBuilder<TBLDR></returns>
            public BillingAddressBuilder<TBldr> Street2(string data)
            {
                Properties[GlobalConstants.Street2] = data;
                return this;
            }

            /// <summary>
            /// Set the city
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>BillingAddressBuilder<TBLDR></returns>
            public BillingAddressBuilder<TBldr> City(string data)
            {
                Properties[GlobalConstants.City] = data;
                return this;
            }

            /// <summary>
            /// Set the state
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>BillingAddressBuilder<TBLDR></returns>
            public BillingAddressBuilder<TBldr> State(string data)
            {
                Properties[GlobalConstants.State] = data;
                return this;
            }

            /// <summary>
            /// Set the country
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>BillingAddressBuilder<TBLDR></returns>
            public BillingAddressBuilder<TBldr> Country(string data)
            {
                Properties[GlobalConstants.Country] = data;
                return this;
            }

            /// <summary>
            /// Set the zip
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>BillingAddressBuilder<TBLDR></returns>
            public BillingAddressBuilder<TBldr> Zip(string data)
            {
                Properties[GlobalConstants.Zip] = data;
                return this;
            }

            /// <summary>
            /// Set the phone
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>BillingAddressBuilder<TBLDR></returns>
            public BillingAddressBuilder<TBldr> Phone(string data)
            {
                Properties[GlobalConstants.Phone] = data;
                return this;
            }
        }
    }
}
