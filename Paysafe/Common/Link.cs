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
    public class Link: JsonObject
    {
        /// <summary>
        /// Initialize the Link object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public Link(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
         {
             {GlobalConstants.Rel, StringType},
             {GlobalConstants.Href, UrlType}
         };


        /// <summary>
        /// Get the rel
        /// </summary>
        /// <returns>string</returns>
        public string Rel()
        {
            return GetProperty(GlobalConstants.Rel);
        }

        /// <summary>
        /// Set the rel
        /// </summary>
        /// <returns>void</returns>
        public void Rel(string data)
        {
            SetProperty(GlobalConstants.Rel, data);
        }

        /// <summary>
        /// Get the href
        /// </summary>
        /// <returns>string</returns>
        public string Href() => GetProperty(GlobalConstants.Href);

        /// <summary>
        /// Set the href
        /// </summary>
        /// <returns>void</returns>
        public void Href(string data)
        {
            SetProperty(GlobalConstants.Href, data);
        }

    }
}
