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
    public class PaysafeAuthentication : JsonObject
    {

        /// <summary>
        /// Initialize the BillingDetails object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public PaysafeAuthentication(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.Eci, IntType},
            {GlobalConstants.Cavv, StringType},
            {GlobalConstants.Xid, StringType},
            {GlobalConstants.ThreeDEnrollment, StringType},
            {GlobalConstants.ThreeDResult, StringType},
            {GlobalConstants.SignatureStatus, StringType}
        };

        /// <summary>
        /// Get the eci
        /// </summary>
        /// <returns>int</returns>
        public int Eci()
        {
            return GetProperty(GlobalConstants.Eci);
        }

        /// <summary>
        /// Set the eci
        /// </summary>
        /// <returns>void</returns>
        public void Eci(int data)
        {
            SetProperty(GlobalConstants.Eci, data);
        }

        /// <summary>
        /// Get the cavv
        /// </summary>
        /// <returns>string</returns>
        public string Cavv()
        {
            return GetProperty(GlobalConstants.Cavv);
        }

        /// <summary>
        /// Set the cavv
        /// </summary>
        /// <returns>void</returns>
        public void Cavv(string data)
        {
            SetProperty(GlobalConstants.Cavv, data);
        }

        /// <summary>
        /// Get the xid
        /// </summary>
        /// <returns>string</returns>
        public string Xid()
        {
            return GetProperty(GlobalConstants.Xid);
        }

        /// <summary>
        /// Set the xid
        /// </summary>
        /// <returns>void</returns>
        public void Xid(string data)
        {
            SetProperty(GlobalConstants.Xid, data);
        }

        /// <summary>
        /// Get the threeDEnrollment
        /// </summary>
        /// <returns>string</returns>
        public string ThreeDEnrollment()
        {
            return GetProperty(GlobalConstants.ThreeDEnrollment);
        }

        /// <summary>
        /// Set the threeDEnrollment
        /// </summary>
        /// <returns>void</returns>
        public void ThreeDEnrollment(string data)
        {
            SetProperty(GlobalConstants.ThreeDEnrollment, data);
        }

        /// <summary>
        /// Get the threeDResult
        /// </summary>
        /// <returns>string</returns>
        public string ThreeDResult()
        {
            return GetProperty(GlobalConstants.ThreeDResult);
        }

        /// <summary>
        /// Set the threeDResult
        /// </summary>
        /// <returns>void</returns>
        public void ThreeDResult(string data)
        {
            SetProperty(GlobalConstants.ThreeDResult, data);
        }

        /// <summary>
        /// Get the signatureStatus
        /// </summary>
        /// <returns>string</returns>
        public string SignatureStatus()
        {
            return GetProperty(GlobalConstants.SignatureStatus);
        }

        /// <summary>
        /// Set the signatureStatus
        /// </summary>
        /// <returns>void</returns>
        public void SignatureStatus(string data)
        {
            SetProperty(GlobalConstants.SignatureStatus, data);
        }


        /// <summary>
        /// AuthenticationBuilder<typeparam name="TBldr"></typeparam> will allow a Authentication to be initialized
        /// within another builder. Set properties and subpropeties, then trigger .Done() to 
        /// get back to the parent builder
        /// </summary>
        public class AuthenticationBuilder<TBldr> : NestedJsonBuilder<PaysafeAuthentication, TBldr>
            where TBldr : GenericJsonBuilder
        {
            /// <summary>
            /// Initialize the Authentication builder within the context of a parent builder
            /// </summary>
            /// <param name="parent">TBLDR</param>
            public AuthenticationBuilder(TBldr parent)
                : base(parent)
            {
                Parent = parent;
            }


            /// <summary>
            /// Set the eci
            /// </summary>
            /// <param name=data>int</param>
            /// <returns>AuthenticationBuilder<TBLDR></returns>
            public AuthenticationBuilder<TBldr> Eci(int data)
            {
                Properties[GlobalConstants.Eci] = data;
                return this;
            }

            /// <summary>
            /// Set the cavv
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthenticationBuilder<TBLDR></returns>
            public AuthenticationBuilder<TBldr> Cavv(string data)
            {
                Properties[GlobalConstants.Cavv] = data;
                return this;
            }

            /// <summary>
            /// Set the xid
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthenticationBuilder<TBLDR></returns>
            public AuthenticationBuilder<TBldr> Xid(string data)
            {
                Properties[GlobalConstants.Xid] = data;
                return this;
            }

            /// <summary>
            /// Set the threeDEnrollment
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthenticationBuilder<TBLDR></returns>
            public AuthenticationBuilder<TBldr> ThreeDEnrollment(string data)
            {
                Properties[GlobalConstants.ThreeDEnrollment] = data;
                return this;
            }

            /// <summary>
            /// Set the threeDResult
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthenticationBuilder<TBLDR></returns>
            public AuthenticationBuilder<TBldr> ThreeDResult(string data)
            {
                Properties[GlobalConstants.ThreeDResult] = data;
                return this;
            }

            /// <summary>
            /// Set the signatureStatus
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthenticationBuilder<TBLDR></returns>
            public AuthenticationBuilder<TBldr> SignatureStatus(string data)
            {
                Properties[GlobalConstants.SignatureStatus] = data;
                return this;
            }

        }
    }
}
