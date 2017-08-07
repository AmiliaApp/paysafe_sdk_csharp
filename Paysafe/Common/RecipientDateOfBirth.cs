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

    public class RecipientDateOfBirth : JsonObject
    {
        /// <summary>
        /// Initialize the DateOfBirth object with some set of properties
        /// </summary>
        /// <param name="properties">Dictionary<string, object></param>
        public RecipientDateOfBirth(Dictionary<string, object> properties = null)
            : base(_fieldTypes, properties)
        {
        }

        private new static Dictionary<string, object> _fieldTypes = new Dictionary<string, object>
         {
             {GlobalConstants.Day, IntType},
             {GlobalConstants.Month, IntType},
             {GlobalConstants.Year, IntType}
         };

        /// <summary>
        /// Get the day
        /// </summary>
        /// <returns>int</returns>
        public int Day()
        {
            return GetProperty(GlobalConstants.Day);
        }

        /// <summary>
        /// Set the day
        /// </summary>
        /// <returns>void</returns>
        public void Day(int data)
        {
            SetProperty(GlobalConstants.Day, data);
        }

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
    }
}
