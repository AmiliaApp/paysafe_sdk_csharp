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
    //Created by Manjiri.Bankar on 03.05.2016. This is ShippingDetails class.
    public class ShippingDetails : AddressDetails
    {
        /// <summary>
        /// Initialize the ShippingDetails object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public ShippingDetails(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>(AddressFieldTypes)
        {
            {GlobalConstants.RecipientName, StringType},
            {GlobalConstants.Carrier, GlobalConstants.EnumCarrier},
            {GlobalConstants.ShipMethod, GlobalConstants.EnumShipMethod}
        };

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
        /// Get the carrier
        /// </summary>
        /// <returns>List</returns>
        public List<string> Carrier()
        {
            return GetProperty(GlobalConstants.Carrier);
        }

        /// <summary>
        /// Set the carrier
        /// </summary>
        /// <returns>void</returns>
        public void Carrier(string data)
        {
            SetProperty(GlobalConstants.Carrier, data);
        }

        /// <summary>
        /// Get the shipMethod
        /// </summary>
        /// <returns>string</returns>
        public string ShipMethod()
        {
            return GetProperty(GlobalConstants.ShipMethod);
        }

        /// <summary>
        /// Set the shipMethod
        /// </summary>
        /// <returns>void</returns>
        public void ShipMethod(string data)
        {
            SetProperty(GlobalConstants.ShipMethod, data);
        }

        /// <summary>
        /// ShippingDetailsBuilder<typeparam name="TBldr"></typeparam> will allow a ShippingDetails to be initialized
        /// within another builder. Set properties and subpropeties, then trigger .Done() to 
        /// get back to the parent builder
        /// </summary>
        public class ShippingDetailsBuilder<TBldr> : NestedJsonBuilder<ShippingDetails, TBldr>
            where TBldr : GenericJsonBuilder
        {
            /// <summary>
            /// Initialize the ShippingDetails builder within the context of a parent builder
            /// </summary>
            /// <param name="parent">TBLDR</param>
            public ShippingDetailsBuilder(TBldr parent)
                : base(parent)
            {
                Parent = parent;
            }

            /// <summary>
            /// Set the recipientName
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ShippingDetailsBuilder<TBLDR></returns>
            public ShippingDetailsBuilder<TBldr> RecipientName(string data)
            {
                Properties[GlobalConstants.RecipientName] = data;
                return this;
            }

            /// <summary>
            /// Set the street
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ShippingDetailsBuilder<TBLDR></returns>
            public ShippingDetailsBuilder<TBldr> Street(string data)
            {
                Properties[GlobalConstants.Street] = data;
                return this;
            }

            /// <summary>
            /// Set the street2
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ShippingDetailsBuilder<TBLDR></returns>
            public ShippingDetailsBuilder<TBldr> Street2(string data)
            {
                Properties[GlobalConstants.Street2] = data;
                return this;
            }

            /// <summary>
            /// Set the city
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ShippingDetailsBuilder<TBLDR></returns>
            public ShippingDetailsBuilder<TBldr> City(string data)
            {
                Properties[GlobalConstants.City] = data;
                return this;
            }

            /// <summary>
            /// Set the state
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ShippingDetailsBuilder<TBLDR></returns>
            public ShippingDetailsBuilder<TBldr> State(string data)
            {
                Properties[GlobalConstants.State] = data;
                return this;
            }

            /// <summary>
            /// Set the country
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ShippingDetailsBuilder<TBLDR></returns>
            public ShippingDetailsBuilder<TBldr> Country(string data)
            {
                Properties[GlobalConstants.Country] = data;
                return this;
            }

            /// <summary>
            /// Set the zip
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ShippingDetailsBuilder<TBLDR></returns>
            public ShippingDetailsBuilder<TBldr> Zip(string data)
            {
                Properties[GlobalConstants.Zip] = data;
                return this;
            }

            /// <summary>
            /// Set the phone
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ShippingDetailsBuilder<TBLDR></returns>
            public ShippingDetailsBuilder<TBldr> Phone(string data)
            {
                Properties[GlobalConstants.Phone] = data;
                return this;
            }

            /// <summary>
            /// Set the carrier
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ShippingDetailsBuilder<TBLDR></returns>
            public ShippingDetailsBuilder<TBldr> Carrier(string data)
            {
                Properties[GlobalConstants.Carrier] = data;
                return this;
            }

            /// <summary>
            /// Set the shipMethod
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ShippingDetailsBuilder<TBLDR></returns>
            public ShippingDetailsBuilder<TBldr> ShipMethod(string data)
            {
                Properties[GlobalConstants.ShipMethod] = data;
                return this;
            }
        }
    }
}
