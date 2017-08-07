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

using System;
using System.Collections.Generic;
using Paysafe.Common;

namespace Paysafe.DirectDebit
{
    //Created by Manjiri.Bankar on 03.05.2016. This is Pagerator class.
    public class Pagerator<T> : AbstractPagerator<T>
    {
        public Pagerator(PaysafeApiClient apiClient, Type pagingClassType, Dictionary<string, object> data)
            : base(apiClient, pagingClassType)
        {
            ParseResponse(data);
        }

        protected sealed override void ParseResponse(Dictionary<string, dynamic> data)
        {
            if (!data.ContainsKey(ArrayKey) || !(data[ArrayKey] is List<dynamic>))
            {
                throw new PaysafeException("Missing array key from results");
            }
            foreach (dynamic obj in data[ArrayKey] as List<dynamic>)
            {
                Object[] args = { obj };
                dynamic result = Activator.CreateInstance(ClassType, args);
                Results.Add(result);
            }
            NextPage = null;

            if (data.ContainsKey("links")
                && data["links"] is List<dynamic>)
            {
                foreach (dynamic obj in (List<dynamic>)data["links"])
                {
                    Link tmpLink = new Link(obj);
                    if (tmpLink.Rel().Equals("next"))
                    {
                        NextPage = tmpLink.Href();
                        break;
                    }
                }
            }

            if (data.ContainsKey("links")
               && data["links"] is List<dynamic>)
            {
                foreach (dynamic obj in data["links"] as List<dynamic>)
                {
                    Link tmpLink = new Link(obj);
                    if (tmpLink.Rel().Equals("self"))
                    {                       
                       SelfPage = tmpLink.Href();
                        break;
                    }
                }
            }

            if (data.ContainsKey("links")
               && data["links"] is List<dynamic>)
            {
                foreach (dynamic obj in (List<dynamic>)data["links"])
                {
                    Link tmpLink = new Link(obj);
                    if (tmpLink.Rel().Equals("previous"))
                    {
                        PreviousPage = tmpLink.Href();
                        break;
                    }
                }
            }
        }
    }
}
