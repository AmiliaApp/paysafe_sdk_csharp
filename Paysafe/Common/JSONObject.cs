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
using Newtonsoft.Json;

namespace Paysafe.Common
{
    /// <summary>
    /// This is the base class for all objects within the sdk.
    /// It is used to allow generic assignment of fields and properties.
    /// </summary>
    public abstract class JsonObject
    {
        /// <summary>
        /// fieldTypes must be passed into the constructor in order to allow generic validation
        /// </summary>
        protected Dictionary<string, object> FieldTypes;

        /// <summary>
        /// this dictionary will store all set properties within the final object
        /// </summary>
        private readonly Dictionary<string, object> _properties = new Dictionary<string,object>();

        /// <summary>
        /// optionalFields will be used by the api client to determine which of the set fields
        /// should be sent to the api
        /// </summary>
        private List<string> _optionalFields;

        /// <summary>
        /// requiredFields will be used by the api client to determine which of the fields must
        /// be set before sending a request to the api
        /// </summary>
        private List<string> _requiredFields;

        /// <summary>
        /// String
        /// </summary>
        public static Type StringType = typeof(string);

        /// <summary>
        /// Int
        /// </summary>
        public static Type IntType = typeof(int);

        /// <summary>
        /// Boolean
        /// </summary>
        public static Type BoolType = typeof(bool);

        /// <summary>
        /// Url
        /// </summary>
        public static Type UrlType = typeof(Url);

        /// <summary>
        /// Email
        /// </summary>
        public static Type EmailType = typeof(Email);

        /// <summary>
        /// Float
        /// </summary>
        public static Type FloatType = typeof(float);

        /// <summary>
        /// The object will be json serialized using only the optional and required properties
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(JsonSerialize());
        }

        /// <summary>
        /// This method will serialize only the required or optional properties within this
        /// and any nested JSONObjects. or if no required/optional properties are set, then
        /// all properties will be returned
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> JsonSerialize()
        {
            CheckRequiredFields();
            Dictionary<string, object> toJson;
            if ((null == _optionalFields || 0 == _optionalFields.Count) && 
                (null == _requiredFields || 0 == _requiredFields.Count))
            {
                toJson = _properties;
            }
            else
            {
                toJson = new Dictionary<string, object>();
                if (_requiredFields != null)
                {
                    foreach (string key in _requiredFields)
                    {
                        if (_properties.ContainsKey(key))
                        {
                            toJson.Add(key, _properties[key]);
                        }
                    }
                }
                if (_optionalFields != null)
                {
                    foreach (string key in _optionalFields)
                    {
                        if (_properties.ContainsKey(key))
                        {
                            toJson.Add(key, _properties[key]);
                        }
                    }
                }
            }
            return FilterJson(toJson) as Dictionary<string, object>;
        }

        /// <summary>
        /// Throws an exception if any required fields have not been set
        /// </summary>
        public void CheckRequiredFields()
        {
            if (_requiredFields != null)
            {
                List<string> missingFields = new List<string>();
                foreach (string key in _requiredFields)
                {
                    if (!_properties.ContainsKey(key))
                    {
                        missingFields.Add(key);
                    }
                }
                if (missingFields.Count > 0)
                {
                    throw new PaysafeException("Missing required properties: " + string.Join(", ", missingFields));
                }
            }
        }

        private dynamic FilterJson(dynamic result)
        {
            if (result is Dictionary<string, object>)
            {
                Dictionary<string, object> @return = new Dictionary<string, object>();
                foreach (string key in ((Dictionary<string, object>)result).Keys)
                {
                    @return[key] = FilterJson(result[key]);
                }
                return @return;
            }
            else if (((object)result).GetType().IsGenericType
                && ((object)result).GetType().GetGenericTypeDefinition() == typeof(List<>))
            {
                return FilterList(result);
            }
            else if (result is JsonObject)
            {
                return ((JsonObject)result).JsonSerialize();
            }
            return result;
        }

        private List<object> FilterList<T>(List<T> list)
        {
            List<object> retList = new List<object>();
            foreach (T item in list)
            {
                retList.Add(FilterJson(item));
            }
            return retList;
        }

        /// <summary>
        /// Set the optional fields to be consumed by the api client
        /// </summary>
        /// <param name="fields"></param>
        /// <exception cref="PaysafeException"></exception>
        public void SetOptionalFields(List<string> fields)
        {
            List<string> invalidKeys = new List<string>();
            foreach (string key in fields)
            {
                if (!FieldTypes.ContainsKey(key))
                {
                    invalidKeys.Add(key);
                }
            }
            if (invalidKeys.Count > 0)
            {
                throw new PaysafeException("Invalid optional fields. Unknown fields: " + string.Join(", ", invalidKeys));
            }
            _optionalFields = fields;
        }

        /// <summary>
        /// Set the required fields to be consumed by the api client
        /// </summary>
        /// <param name="fields"></param>
        /// <exception cref="PaysafeException"></exception>
        public void SetRequiredFields(List<string> fields)
        {
            List<string> invalidKeys = new List<string>();
            foreach (string key in fields)
            {
                if (!FieldTypes.ContainsKey(key))
                {
                    invalidKeys.Add(key);
                }
            }
            if (invalidKeys.Count > 0)
            {
                throw new PaysafeException("Invalid required fields. Unknown fields: " + string.Join(", ", invalidKeys));
            }
            _requiredFields = fields;
        }


        /// <summary>
        /// Initialize the Object, setting the internetal properties from parameters based on the types
        /// </summary>
        /// <param name="types"></param>
        /// <param name="parameters"></param>
        protected JsonObject(Dictionary<string, object> types, Dictionary<string, object> parameters = null)
        {
            FieldTypes = types;
            if (!ReferenceEquals(parameters, null))
            {
                foreach (string key in parameters.Keys)
                {
                    var tmp = GetFieldInfo(key);
                    if (!ReferenceEquals(tmp, null))
                    {
                        KeyValuePair<string, object> info = (KeyValuePair<string, object>)tmp;
                        SetProperty(info.Key, parameters[key]);
                    }
                }
            }
        }

        /// <summary>
        /// Set the property name with value cast based on the fieldTypes dictionary
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="value">dynamic</param>
        protected void SetProperty(string name, dynamic value) {
            var tmp = GetFieldInfo(name);
            if (ReferenceEquals(tmp, null))
            {
                throw new PaysafeException("Invalid property " + name + " for class " + GetType());
            }
            KeyValuePair<string, object> info = (KeyValuePair<string, object>)tmp;

            if (ReferenceEquals(value, null))
            {
                _properties.Remove(info.Key);
            }
            else
            {
                _properties[info.Key] = Cast(info.Key, value, info.Value);
            }
            
        }

        /// <summary>
        /// Get the pproperty name fromt he properties dictionary
        /// </summary>
        /// <param name="name">string</param>
        /// <returns></returns>
        protected dynamic GetProperty(string name)
        {
            var tmp = GetFieldInfo(name);
            if (ReferenceEquals(tmp, null))
            {
                throw new PaysafeException("Invalid property " + name + " for class " + GetType());
            }
            KeyValuePair<string, object> info = (KeyValuePair<string, object>)tmp;
            if (_properties.ContainsKey(info.Key))
            {
                return _properties[info.Key];
            }
            return null;
        }

        /// <summary>
        /// Checks if a specfic property has been set
        /// </summary>
        /// <param name="name">string</param>
        /// <returns></returns>
        public bool HasProperty(string name)
        {
            var tmp = GetFieldInfo(name);
            if (null == tmp)
            {
                return false;
            }
            KeyValuePair<string, object> info = (KeyValuePair<string, object>)tmp;
            return _properties.ContainsKey(info.Key);
        }

        /// <summary>
        /// Get the validation rules for a given field
        /// </summary>
        /// <param name="name">string</param>
        /// <returns>KeyValuePair<string, string> or null</returns>
        private dynamic GetFieldInfo(string name)
        {
            if (null == FieldTypes)
            {
                throw new PaysafeException("field types must be initialized");
            }
            if (FieldTypes.ContainsKey(name))
            {
                return new KeyValuePair<string, object>(name, FieldTypes[name]);
            }
            name = name.ToLower();
            foreach (string key in FieldTypes.Keys)
            {
                if (key.ToLower() == name)
                {
                    return new KeyValuePair<string, object>(key, FieldTypes[key]);
                }
            }
            return null;
        }

        /// <summary>
        /// Casts property value to type validation
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="value">dynamic</param>
        /// <param name="validation">string</param>
        /// <returns></returns>
        public dynamic Cast(string name, dynamic value, dynamic validation)
        {
            string valueString = null;
            if (value is string)
            {
                valueString = (string)value;
            }
            if (validation is List<string>)
            {
                List<string> validationList = (List<string>)validation;
                if (null == valueString  || !validationList.Contains(valueString))
                {
                    throw new PaysafeException("Invalid value for property " + name + " for class " + GetType().ToString() + ". Expected one of: " + string.Join(", ", validationList) + ".");
                }
                return value;
            }
            else if (validation is Type)
            {
                Type validationType = validation as Type;
                if (validationType == StringType)
                {
                    if (null == valueString)
                    {
                        throw new PaysafeException("Invalid value for property " + name + " for class " + GetType().ToString() + ". String expected.");
                    }
                    return value;
                }
                else if (validationType == EmailType)
                {
                    if (null == valueString|| valueString.IndexOf("@", StringComparison.CurrentCulture) <= 0)
                    {
                        throw new PaysafeException("Invalid value for property " + name + " for class " + GetType().ToString() + ". Email expected.");
                    }
                    return value;
                }
                else if (validationType == UrlType)
                {
                    Uri uriResult;
                    if (null == valueString || (Uri.TryCreate(valueString, UriKind.Absolute, out uriResult) && null == uriResult))
                    {
                        throw new PaysafeException("Invalid value for property " + name + " for class " + GetType().ToString() + ". URL expected.");
                    }
                    return value;
                }
                else if (validationType == IntType)
                {
                    try
                    {
                        return Convert.ToInt32(value);
                    }
                    catch (Exception)
                    {
                        //format exception or overflow exception
                        throw new PaysafeException("Invalid value for property " + name + " for class " + GetType().ToString() + ". Integer expected.");
                    }
                }
                else if (validationType == FloatType)
                {
                    decimal decVal;
                    if (value is decimal)
                    {
                        decVal = ((decimal)value);
                    }
                    else if (valueString != null || !decimal.TryParse(((string)value), out decVal))
                    {
                        throw new PaysafeException("Invalid value for property " + name + " for class " + GetType().ToString() + ". Decimal expected.");
                    }
                    return decVal;
                }
                else if (validationType == BoolType)
                {
                    bool boolVal;
                    if (value is bool)
                    {
                        boolVal = ((bool)value);
                    }
                    else if (null == valueString || !bool.TryParse(valueString, out boolVal))
                    {
                        throw new PaysafeException("Invalid value for property " + name + " for class " + GetType().ToString() + ". Boolean expected.");
                    }
                    return boolVal;
                }
                else if (validationType.IsGenericType && 
                    validationType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    Type subType = validationType.GetGenericArguments()[0];
                    if (!(value is System.Collections.IList))
                    {
                        throw new PaysafeException("Invalid value for property " + name + " for class " + GetType().ToString() + ". List expected.");
                    }
                    Type T = null;
                    for (int i = 0; i < ((System.Collections.IList)value).Count; i++)
                    {
                        value[i] = Cast(name, value[i], subType);
                        T = ((object)((System.Collections.IList)value)[i]).GetType();
                    }
                    if (T != null && value is List<object>)
                    {
                        //convert list of subtype object to a list of the required subtype
                        dynamic newList = typeof(List<>)
                            .MakeGenericType(T)
                            .GetConstructor(new Type[] { })
                            .Invoke(new object[] { });
                        for (int i = 0; i < ((List<dynamic>)value).Count; i++)
                        {
                            newList.Add(value[i]);
                        }
                        return newList;
                    }
                    return value;
                }
                else
                {
                    Type valueType = value.GetType();
                    if ((value is Dictionary<string, object>))
                    {
                        object[] args = { value };
                        return Activator.CreateInstance(validationType, args);
                    }
                    else if (valueType == validationType)
                    {
                        return value;
                    }
                    else if (valueType.GetMethod("Build") != null && valueType.IsSubclassOf(typeof(GenericJsonBuilder)))
                    {
                        dynamic returnValue = value.Build();
                        if (returnValue.GetType() as Type == validationType)
                        {
                            return returnValue;
                        }
                    }
                    throw new PaysafeException("Invalid value for property " + name + " for class " + GetType().ToString());
                }
            }
            throw new PaysafeException("Invalid validation rule for property " + name + " for class " + GetType().ToString());
        }
    }
}
