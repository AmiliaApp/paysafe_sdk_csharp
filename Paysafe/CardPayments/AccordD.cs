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
    public class AccordD : JsonObject
    {
        /// <summary>
        /// Initialize the AccordD object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public AccordD(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static readonly Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.FinancingType, CardPaymentsConstants.EnumFinancingType},
            {GlobalConstants.Plan, StringType},
            {GlobalConstants.GracePeriod, IntType},
            {GlobalConstants.Term, IntType}
        };

        /// <summary>
        /// Get the financingType
        /// </summary>
        /// <returns>string</returns>
        public string FinancingType()
        {
            return GetProperty(GlobalConstants.FinancingType);
        }

        /// <summary>
        /// Set the financingType
        /// </summary>
        /// <returns>void</returns>
        public void FinancingType(string data)
        {
            SetProperty(GlobalConstants.FinancingType, data);
        }

        /// <summary>
        /// Get the plan
        /// </summary>
        /// <returns>string</returns>
        public string Plan()
        {
            return GetProperty(GlobalConstants.Plan);
        }

        /// <summary>
        /// Set the plan
        /// </summary>
        /// <returns>void</returns>
        public void Plan(string data)
        {
            SetProperty(GlobalConstants.Plan, data);
        }

        /// <summary>
        /// Get the gracePeriod
        /// </summary>
        /// <returns>int</returns>
        public int GracePeriod()
        {
            return GetProperty(GlobalConstants.GracePeriod);
        }

        /// <summary>
        /// Set the gracePeriod
        /// </summary>
        /// <returns>void</returns>
        public void GracePeriod(int data)
        {
            SetProperty(GlobalConstants.GracePeriod, data);
        }

        /// <summary>
        /// Get the term
        /// </summary>
        /// <returns>int</returns>
        public int Term()
        {
            return GetProperty(GlobalConstants.Term);
        }

        /// <summary>
        /// Set the term
        /// </summary>
        /// <returns>void</returns>
        public void Term(int data)
        {
            SetProperty(GlobalConstants.Term, data);
        }

        /// <summary>
        /// AccordDBuilder<typeparam name="TBldr"></typeparam> will allow a AccordD to be initialized
        /// within another builder. Set properties and subpropeties, then trigger .Done() to 
        /// get back to the parent builder
        /// </summary>
        public class AccordDBuilder<TBldr> : NestedJsonBuilder<AccordD, TBldr>
            where TBldr : GenericJsonBuilder
        {
            /// <summary>
            /// Initialize the AccordD builder within the context of a parent builder
            /// </summary>
            /// <param name="parent">TBLDR</param>
            public AccordDBuilder(TBldr parent)
                : base(parent)
            {
                Parent = parent;
            }

            /// <summary>
            /// Set the financingType
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AccordDBuilder<TBLDR></returns>
            public AccordDBuilder<TBldr> FinancingType(string data)
            {
                Properties[GlobalConstants.FinancingType] = data;
                return this;
            }

            /// <summary>
            /// Set the plan
            /// </summary>
            /// <param name=data>string</param>
            /// <returns>AccordDBuilder<TBLDR></returns>
            public AccordDBuilder<TBldr> Plan(string data)
            {
                Properties[GlobalConstants.Plan] = data;
                return this;
            }

            /// <summary>
            /// Set the gracePeriod
            /// </summary>
            /// <param name=data>int</param>
            /// <returns>AccordDBuilder<TBLDR></returns>
            public AccordDBuilder<TBldr> GracePeriod(int data)
            {
                Properties[GlobalConstants.GracePeriod] = data;
                return this;
            }

            /// <summary>
            /// Set the term
            /// </summary>
            /// <param name=data>int</param>
            /// <returns>AccordDBuilder<TBLDR></returns>
            public AccordDBuilder<TBldr> Term(int data)
            {
                Properties[GlobalConstants.Term] = data;
                return this;
            }
        }
    }
}
