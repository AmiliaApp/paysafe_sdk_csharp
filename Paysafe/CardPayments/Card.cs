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

        /// <summary>
        /// This object is used to validate any properties set within the object
        /// </summary>
        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.PaymentToken, StringType},
            {GlobalConstants.CardNum, StringType},
            {GlobalConstants.Type, StringType},
            {GlobalConstants.LastDigits, StringType},
            {GlobalConstants.CardExpiry, typeof(CardExpiry)},
            {GlobalConstants.Cvv, StringType},
            {GlobalConstants.Track1, StringType},
            {GlobalConstants.Track2, StringType},
        };

        /// <summary>
        /// Get the payment token
        /// </summary>
        /// <returns>string</returns>
        public string PaymentToken()
        {
            return GetProperty(GlobalConstants.PaymentToken);
        }

        /// <summary>
        /// Set the payment token
        /// </summary>
        /// <param name=data>string</param>
        public void PaymentToken(string data)
        {
            SetProperty(GlobalConstants.PaymentToken, data);
        }

        /// <summary>
        /// Get the card number
        /// </summary>
        /// <returns>string</returns>
        public string CardNum()
        {
            return GetProperty(GlobalConstants.CardNum);
        }

        /// <summary>
        /// Set the card number
        /// </summary>
        /// <param name=data>string</param>
        public void CardNum(string data)
        {
            SetProperty(GlobalConstants.CardNum, data);
        }

        /// <summary>
        /// Get the card's type
        /// </summary>
        /// <returns>string</returns>
        public string Type()
        {
            return GetProperty(GlobalConstants.Type);
        }

        /// <summary>
        /// Set the card's type
        /// </summary>
        /// <param name=data>string</param>
        public void Type(string data)
        {
            SetProperty(GlobalConstants.Type, data);
        }

        /// <summary>
        /// Get the card's last digits
        /// </summary>
        /// <returns>string</returns>
        public string LastDigits()
        {
            return GetProperty(GlobalConstants.LastDigits);
        }

        /// <summary>
        /// Set the card's last digits
        /// </summary>
        /// <param name=data>string</param>
        public void LastDigits(string data)
        {
            SetProperty(GlobalConstants.LastDigits, data);
        }

        /// <summary>
        /// Get the card expiry
        /// </summary>
        /// <returns>CardExpiry</returns>
        public CardExpiry CardExpiry()
        {
            return GetProperty(GlobalConstants.CardExpiry);
        }

        /// <summary>
        /// Set the card expiry
        /// </summary>
        /// <param name=data>CardExpiry</param>
        public void CardExpiry(CardExpiry data)
        {
            SetProperty(GlobalConstants.CardExpiry, data);
        }

        /// <summary>
        /// Get the card cvv
        /// </summary>
        /// <returns>string</returns>
        public string Cvv()
        {
            return GetProperty(GlobalConstants.Cvv);
        }

        /// <summary>
        /// Set the card cvv
        /// </summary>
        /// <param name=data>string</param>
        public void Cvv(string data)
        {
            SetProperty(GlobalConstants.Cvv, data);
        }

        /// <summary>
        /// Get the track1 data
        /// </summary>
        /// <returns>string</returns>
        public string Track1()
        {
            return GetProperty(GlobalConstants.Track1);
        }

        /// <summary>
        /// Set the track1 data
        /// </summary>
        /// <param name=data>string</param>
        public void Track1(string data)
        {
            SetProperty(GlobalConstants.Track1, data);
        }

        /// <summary>
        /// Get the track2 data
        /// </summary>
        /// <returns>string</returns>
        public string Track2()
        {
            return GetProperty(GlobalConstants.Track1);
        }

        /// <summary>
        /// Set the track2 data
        /// </summary>
        /// <param name=data>string</param>
        public void Track2(string data)
        {
            SetProperty(GlobalConstants.Track2, data);
        }

        /// <summary>
        /// CardBuilder<typeparam name="TBldr"></typeparam> will allow an card to be initialized
        /// within another builder. Set properties and subpropeties, then trigger .Done() to 
        /// get back tot he parent builder
        /// </summary>
        public class CardBuilder<TBldr> : NestedJsonBuilder<Card, TBldr>
            where TBldr : GenericJsonBuilder
        {
            /// <summary>
            /// Initialize the Card builder within the context of a parent builder
            /// </summary>
            /// <param name="parent">TBLDR</param>
            public CardBuilder(TBldr parent)
                : base(parent)
            {
                Parent = parent;
            }

            /// <summary>
            /// Set the payment token
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder<TBLDR></returns>
            public CardBuilder<TBldr> PaymentToken(string data)
            {
                Properties[GlobalConstants.PaymentToken] = data;
                return this;
            }

            /// <summary>
            /// Set the card number
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder<TBLDR></returns>
            public CardBuilder<TBldr> CardNum(string data)
            {
                Properties[GlobalConstants.CardNum] = data;
                return this;
            }

            /// <summary>
            /// Set the card's type
            /// </summary>
            /// <param name=CardPaparam>string</param>
            /// <returns>CardBuilder<TBLDR></returns>
            public CardBuilder<TBldr> Type(string data)
            {
                Properties[GlobalConstants.Type] = data;
                return this;
            }

            /// <summary>
            /// Set the card's last digits
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder<TBLDR></returns>
            public CardBuilder<TBldr> LastDigits(string data)
            {
                Properties[GlobalConstants.LastDigits] = data;
                return this;
            }

            /// <summary>
            /// Build a card expiry within this card.
            /// </summary>
            /// <returns>CardExpiry.CardExpiryBuilder<CardBuilder<TBLDR>></returns>
            public CardExpiry.CardExpiryBuilder<CardBuilder<TBldr>> CardExpiry()
            {
                if (!Properties.ContainsKey(GlobalConstants.CardExpiry))
                {
                    Properties[GlobalConstants.CardExpiry] = new CardExpiry.CardExpiryBuilder<CardBuilder<TBldr>>(this);
                }
                return Properties[GlobalConstants.CardExpiry] as CardExpiry.CardExpiryBuilder<CardBuilder<TBldr>>;
            }

            /// <summary>
            /// Set the card cvv
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder<TBLDR></returns>
            public CardBuilder<TBldr> Cvv(string data)
            {
                Properties[GlobalConstants.Cvv] = data;
                return this;
            }

            /// <summary>
            /// Set the track1 data
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder<TBLDR></returns>
            public CardBuilder<TBldr> Track1(string data)
            {
                Properties[GlobalConstants.Track1] = data;
                return this;
            }

            /// <summary>
            /// Set the track2 data
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>CardBuilder<TBLDR></returns>
            public CardBuilder<TBldr> Track2(string data)
            {
                Properties[GlobalConstants.Track2] = data;
                return this;
            }
        }
    }
}
