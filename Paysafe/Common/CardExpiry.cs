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

namespace Paysafe.Common
{
    public class CardExpiry : JsonObject
    {
        /// <summary>
        /// Initialize the CardExpiry object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public CardExpiry(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static readonly Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.Month, IntType},
            {GlobalConstants.Year, IntType}
        };

        /// <summary>
        /// Get the month
        /// </summary>
        /// <returns>int</returns>
        public int Month()
        {
            return GetProperty(GlobalConstants.Month);
        }

        /// <summary>
        /// Set the month
        /// </summary>
        /// <returns>void</returns>
        public void Month(int data)
        {
            SetProperty(GlobalConstants.Month, data);
        }

        /// <summary>
        /// Get the year
        /// </summary>
        /// <returns>int</returns>
        public int Year()
        {
            return GetProperty(GlobalConstants.Year);
        }

        /// <summary>
        /// Set the year
        /// </summary>
        /// <returns>void</returns>
        public void Year(int data)
        {
            SetProperty(GlobalConstants.Year, data);
        }

        /// <summary>
        /// CardExpiryBuilder<typeparam name="TBldr"></typeparam> will allow a CardExpiry to be initialized
        /// within another builder. Set properties and subpropeties, then trigger .Done() to 
        /// get back to the parent builder
        /// </summary>
        public class CardExpiryBuilder<TBldr> : NestedJsonBuilder<CardExpiry, TBldr>
            where TBldr : GenericJsonBuilder
        {
            /// <summary>
            /// Initialize the CardExpiry builder within the context of a parent builder
            /// </summary>
            /// <param name="parent">TBLDR</param>
            public CardExpiryBuilder(TBldr parent)
                : base(parent)
            {
                Parent = parent;
            }

            /// <summary>
            /// Sets the month
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            public CardExpiryBuilder<TBldr> Month(int data)
            {
                Properties[GlobalConstants.Month] = data;
                return this;
            }

            /// <summary>
            /// Set the year
            /// </summary>
            /// <param name="data"></param>
            /// <returns></returns>
            public CardExpiryBuilder<TBldr> Year(int data)
            {
                Properties[GlobalConstants.Year] = data;
                return this;
            }
        }
    }
}
