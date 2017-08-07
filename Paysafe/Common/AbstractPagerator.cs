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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//Modified by Manjiri.Bankar on 02.08.2016. This is Pagerator class.
namespace Paysafe.Common
{
    public abstract class AbstractPagerator<T> : IEnumerable
    {

        /// <summary>
        /// The result set so far retrieved
        /// </summary>
        protected List<T> Results = new List<T>();

        /// <summary>
        /// The key in the returned array to be added to the resutl set
        /// </summary>
        protected string ArrayKey;

        /// <summary>
        /// The type to instantiate
        /// </summary>
        protected Type ClassType;

        /// <summary>
        /// The url to the next page, if we haven't yet retrieved all results
        /// </summary>
        protected String NextPage = null;

        /// <summary>
        /// The url to the self page
        /// </summary>
        protected String SelfPage = null;

        /// <summary>
        /// The url to the previous page
        /// </summary>
        protected String PreviousPage = null;

        /// <summary>
        /// The client
        /// </summary>
        protected PaysafeApiClient Client;


        /// <summary>
        /// Get arrays by page
        /// </summary>
        /// <param name="apiClient"></param>
        /// <param name="pagingClassType"></param>
        protected AbstractPagerator(PaysafeApiClient apiClient, Type pagingClassType)
        {
            ArrayKey = pagingClassType.GetMethod("getPageableArrayKey").Invoke(null, null) as string;

            Client = apiClient;
            ClassType = pagingClassType;
        }

        /// <summary>
        /// Get the current set of elements
        /// </summary>
        /// <returns>List<T></returns>
        public List<T> GetResults()
        {
            return Results;
        }

        /// <summary>
        /// Used by PageratorEnumerator to get result
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected T Get(int index)
        {
            return Results.ElementAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Implemented to extended IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return new PageratorEnumerator(ClassType, this);
        }


        /// <summary>
        /// To parse the response
        /// </summary>
        /// <param name="data"></param>
        protected abstract void ParseResponse(Dictionary<string, object> data);

        /// <summary>
        /// Enumerator
        /// </summary>
        public class PageratorEnumerator : IEnumerator
        {
            readonly AbstractPagerator<T> _parent;

            private int _position = -1;

            /// <summary>
            /// Pagerator Enumerator
            /// </summary>
            /// <param name="classType"></param>
            /// <param name="parent"></param>
            public PageratorEnumerator(Type classType, AbstractPagerator<T> parent)
            {
                _parent = parent;
            }

            bool IEnumerator.MoveNext()
            {
                _position++;
                if (_parent.Results.Count >= _position && !String.IsNullOrWhiteSpace(_parent.NextPage))
                {
                    Request request = new Request(url: _parent.NextPage);
                    _parent.ParseResponse(_parent.Client.ProcessRequest(request));
                }
                return _position < _parent.Results.Count;
            }

            void IEnumerator.Reset()
            {
                _position = -1;
            }

            object IEnumerator.Current => Current;

            /// <summary>
            /// Current Element
            /// </summary>
            public T Current => _parent.Get(_position);
        }
    }
}
