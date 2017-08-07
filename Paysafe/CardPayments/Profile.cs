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

namespace Paysafe.CardPayments
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
             {GlobalConstants.FirstName, StringType},
             {GlobalConstants.LastName, StringType},
             {GlobalConstants.Email, EmailType}
         };


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
        /// ProfileBuilder<typeparam name="TBldr"></typeparam> will allow a Profile to be initialized
        /// within another builder. Set properties and subpropeties, then trigger .Done() to 
        /// get back to the parent builder
        /// </summary>
        public class ProfileBuilder<TBldr> : NestedJsonBuilder<Profile, TBldr>
            where TBldr : GenericJsonBuilder
        {
            /// <summary>
            /// Initialize the Profile builder within the context of a parent builder
            /// </summary>
            /// <param name="parent">TBLDR</param>
            public ProfileBuilder(TBldr parent)
                : base(parent)
            {
                Parent = parent;
            }

            /// <summary>
            /// Set the firstname
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder<TBLDR></returns>
            public ProfileBuilder<TBldr> FirstName(string data)
            {
                Properties[GlobalConstants.FirstName] = data;
                return this;
            }

            /// <summary>
            /// Set the lastname
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder<TBLDR></returns>
            public ProfileBuilder<TBldr> LastName(string data)
            {
                Properties[GlobalConstants.LastName] = data;
                return this;
            }

            /// <summary>
            /// Set the email
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>ProfileBuilder<TBLDR></returns>
            public ProfileBuilder<TBldr> Email(string data)
            {
                Properties[GlobalConstants.Email] = data;
                return this;
            }
        }
    }
}
