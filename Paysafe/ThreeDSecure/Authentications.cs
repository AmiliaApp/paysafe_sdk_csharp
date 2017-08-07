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

using Paysafe.Common;
using System;
using System.Collections.Generic;

namespace Paysafe.ThreeDSecure
{
    //Created by Tushar.Sukhiya on 03.05.2016. This is Authentications class.
    public class Authentications : JsonObject
    {
        /// <summary>
        /// Initialize the Authentications object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Authentications(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.Id, StringType},
            {GlobalConstants.MerchantRefNum, StringType},
            {GlobalConstants.PaResp, StringType},
            {GlobalConstants.CustomerIp, StringType},
            {GlobalConstants.TxnTime, typeof(DateTime)},
            {GlobalConstants.Error, typeof(Error)},
            {GlobalConstants.Status, ThreeDSecureConstants.EnumStatus},
            {GlobalConstants.ThreeDResult, ThreeDSecureConstants.EnumThreeDResult},
            {GlobalConstants.SignatureStatus, ThreeDSecureConstants.EnumSignatureStatus},
            {GlobalConstants.Eci, IntType},
            {GlobalConstants.Cavv, StringType},
            {GlobalConstants.Xid, StringType},
            {GlobalConstants.EnrollmentId, StringType},
            {GlobalConstants.Links, typeof(List<Link>)},
            {GlobalConstants.Enrollmentchecks, typeof(List<EnrollmentChecks>)}
        };

        /// <summary>
        /// Get the id
        /// </summary>
        /// <returns>String</returns>
        public string Id()
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
        /// Get the merchantRefNum
        /// </summary>
        /// <returns>String</returns>
        public string MerchantRefNum()
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
        /// Get the paRes
        /// </summary>
        /// <returns>String</returns>
        public string PaRes()
        {
            return GetProperty(GlobalConstants.PaResp);
        }

        /// <summary>
        /// Set the paRes
        /// </summary>
        /// <returns>void</returns>
        public void PaRes(String data)
        {
            SetProperty(GlobalConstants.PaResp, data);
        }

        /// <summary>
        /// Get the customerIp
        /// </summary>
        /// <returns>String</returns>
        public string CustomerIp()
        {
            return GetProperty(GlobalConstants.CustomerIp);
        }

        /// <summary>
        /// Set the customerIp
        /// </summary>
        /// <returns>void</returns>
        public void CustomerIp(String data)
        {
            SetProperty(GlobalConstants.CustomerIp, data);
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
        /// Get the error
        /// </summary>
        /// <returns>Error</returns>
        public Error Error()
        {
            return GetProperty(GlobalConstants.Error);
        }

        /// <summary>
        /// Set the error
        /// </summary>
        /// <returns>void</returns>
        public void Error(Error data)
        {
            SetProperty(GlobalConstants.Error, data);
        }

        /// <summary>
        /// Get the status
        /// </summary>
        /// <returns>String</returns>
        public string Status()
        {
            return GetProperty(GlobalConstants.Status);
        }

        /// <summary>
        /// Set the status
        /// </summary>
        /// <returns>String</returns>
        public void Status(String data)
        {
            SetProperty(GlobalConstants.Status, data);
        }

        /// <summary>
        /// Get the threeDResult
        /// </summary>
        /// <returns>String</returns>
        public string ThreeDResult()
        {
            return GetProperty(GlobalConstants.ThreeDResult);
        }

        /// <summary>
        /// Set the threeDResult
        /// </summary>
        /// <returns>String</returns>
        public void ThreeDResult(String data)
        {
            SetProperty(GlobalConstants.ThreeDResult, data);
        }

        /// <summary>
        /// Get the signatureStatus
        /// </summary>
        /// <returns>String</returns>
        public string SignatureStatus()
        {
            return GetProperty(GlobalConstants.SignatureStatus);
        }

        /// <summary>
        /// Set the signatureStatus
        /// </summary>
        /// <returns>String</returns>
        public void SignatureStatus(String data)
        {
            SetProperty(GlobalConstants.SignatureStatus, data);
        }
        
        /// <summary>
        /// Get the eci
        /// </summary>
        /// <returns>integer</returns>
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
        /// <returns>String</returns>
        public string Cavv()
        {
            return GetProperty(GlobalConstants.Cavv);
        }

        /// <summary>
        /// Set the cavv
        /// </summary>
        /// <returns>void</returns>
        public void Cavv(String data)
        {
            SetProperty(GlobalConstants.Cavv, data);
        }

        /// <summary>
        /// Get the xid
        /// </summary>
        /// <returns>String</returns>
        public string Xid()
        {
            return GetProperty(GlobalConstants.Xid);
        }

        /// <summary>
        /// Set the xid
        /// </summary>
        /// <returns>void</returns>
        public void Xid(String data)
        {
            SetProperty(GlobalConstants.Xid, data);
        }

        public static AuthenticationsBuilder Builder()
        {
            return new AuthenticationsBuilder();
        }

        /// <summary>
        /// Get the enrollmentId
        /// </summary>
        /// <returns>String</returns>
        public string EnrollmentId()
        {
            return GetProperty(GlobalConstants.EnrollmentId);
        }

        /// <summary>
        /// Set the enrollmentId
        /// </summary>
        /// <returns>void</returns>
        public void EnrollmentId(String data)
        {
            SetProperty(GlobalConstants.EnrollmentId, data);
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

        /// <summary>
        /// Get the enrollmentchecks
        /// </summary>
        /// <returns>EnrollmentChecks</returns>
        public List<EnrollmentChecks> Enrollmentchecks()
        {
            return GetProperty(GlobalConstants.Enrollmentchecks);
        }

        /// <summary>
        /// Set the enrollmentchecks
        /// </summary>
        /// <returns>void</returns>
        public void Enrollmentchecks(List<EnrollmentChecks> data)
        {
            SetProperty(GlobalConstants.Enrollmentchecks, data);
        }

        /// <summary>
        /// AuthenticationsBuilder  will allow an authentication to be initialized.
        /// set all properties and subpropeties, then trigger .Build() to 
        /// get the generated Authentications object
        /// </summary>
        public class AuthenticationsBuilder : BaseJsonBuilder<Authentications>
        {
            /// <summary>
            /// Set the id parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthenticationsBuilder</returns>
            public AuthenticationsBuilder Id(string data)
            {
                Properties[GlobalConstants.Id] = data;
                return this;
            }

            /// <summary>
            /// Set the merchantRefNum parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthenticationsBuilder</returns>
            public AuthenticationsBuilder MerchantRefNum(string data)
            {
                Properties[GlobalConstants.MerchantRefNum] = data;
                return this;
            }

            /// <summary>
            /// Set the paResp parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthenticationsBuilder</returns>
            public AuthenticationsBuilder PaResp(string data)
            {
                Properties[GlobalConstants.PaResp] = data;
                return this;
            }

            /// <summary>
            /// Set the customerIp parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthenticationsBuilder</returns>
            public AuthenticationsBuilder CustomerIp(string data)
            {
                Properties[GlobalConstants.CustomerIp] = data;
                return this;
            }

            /// <summary>
            /// Set the txnTime parameter
            /// </summary>
            /// <param name=data>DateTime</param>
            /// <returns>AuthenticationsBuilder</returns>
            public AuthenticationsBuilder TxnTime(DateTime data)
            {
                Properties[GlobalConstants.TxnTime] = data;
                return this;
            }

            /// <summary>
            /// Build a Error object within this Authentications.
            /// </summary>
            /// <returns>Error.ErrorBuilder<AuthenticationsBuilder></returns>
            public Error.ErrorBuilder<AuthenticationsBuilder> Error()
            {
                if (!Properties.ContainsKey(GlobalConstants.Error))
                {
                    Properties[GlobalConstants.Error] = new Error.ErrorBuilder<AuthenticationsBuilder>(this);
                }
                return Properties[GlobalConstants.Error] as Error.ErrorBuilder<AuthenticationsBuilder>;
            }

            /// <summary>
            /// Set the status parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthenticationsBuilder</returns>
            public AuthenticationsBuilder Status(string data)
            {
                Properties[GlobalConstants.Status] = data;
                return this;
            }

            /// <summary>
            /// Set the threeDResult parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthenticationsBuilder</returns>
            public AuthenticationsBuilder ThreeDResult(string data)
            {
                Properties[GlobalConstants.ThreeDResult] = data;
                return this;
            }

            /// <summary>
            /// Set the signatureStatus parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthenticationsBuilder</returns>
            public AuthenticationsBuilder SignatureStatus(string data)
            {
                Properties[GlobalConstants.SignatureStatus] = data;
                return this;
            }

            /// <summary>
            /// Set the eci parameter
            /// </summary>
            /// <param name=data>Integer</param>
            /// <returns>AuthenticationsBuilder</returns>
            public AuthenticationsBuilder Eci(int data)
            {
                Properties[GlobalConstants.Eci] = data;
                return this;
            }

            /// <summary>
            /// Set the cavv parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthenticationsBuilder</returns>
            public AuthenticationsBuilder Cavv(string data)
            {
                Properties[GlobalConstants.Cavv] = data;
                return this;
            }

            /// <summary>
            /// Set the xid parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthenticationsBuilder</returns>
            public AuthenticationsBuilder Xid(string data)
            {
                Properties[GlobalConstants.Xid] = data;
                return this;
            }

            /// <summary>
            /// Set the enrollmentId parameter
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AuthenticationsBuilder</returns>
            public AuthenticationsBuilder EnrollmentId(string data)
            {
                Properties[GlobalConstants.EnrollmentId] = data;
                return this;
            }
        }
    }
}
