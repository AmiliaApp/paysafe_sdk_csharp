using System.Collections.Generic;

namespace Paysafe.Common
{
    /// <summary>
    /// Address Details Json Object Representation
    /// </summary>
    public abstract class AddressDetails: JsonObject
    {
        /// <summary>
        /// Initialize the BillingDetails object with some set of properties
        /// </summary>
        /// <param name="fieldTypes"></param>
        /// <param name="properties"></param>
        protected AddressDetails(Dictionary<string, object> fieldTypes , Dictionary<string, object> properties = null) 
            : base(fieldTypes, properties)
        {

        }

        /// <summary>
        /// This object is used to validate any properties set within the object
        /// </summary>
        protected static Dictionary<string, object> AddressFieldTypes = new Dictionary<string, object>
        {
            {GlobalConstants.Street, StringType},
            {GlobalConstants.Street2, StringType},
            {GlobalConstants.City, StringType},
            {GlobalConstants.State, StringType},
            {GlobalConstants.Country, StringType},
            {GlobalConstants.Zip, StringType},
            {GlobalConstants.Phone, StringType}
        };

        /// <summary>
        /// Get the street
        /// </summary>
        /// <returns>string</returns>
        public string Street()
        {
            return GetProperty(GlobalConstants.Street);
        }

        /// <summary>
        /// Set the street
        /// </summary>
        /// <returns>void</returns>
        public void Street(string data)
        {
            SetProperty(GlobalConstants.Street, data);
        }

        /// <summary>
        /// Get the street2
        /// </summary>
        /// <returns>string</returns>
        public string Street2()
        {
            return GetProperty(GlobalConstants.Street2);
        }

        /// <summary>
        /// Set the street2
        /// </summary>
        /// <returns>void</returns>
        public void Street2(string data)
        {
            SetProperty(GlobalConstants.Street2, data);
        }

        /// <summary>
        /// Get the city
        /// </summary>
        /// <returns>string</returns>
        public string City()
        {
            return GetProperty(GlobalConstants.City);
        }

        /// <summary>
        /// Set the city
        /// </summary>
        /// <returns>void</returns>
        public void City(string data)
        {
            SetProperty(GlobalConstants.City, data);
        }

        /// <summary>
        /// Get the state
        /// </summary>
        /// <returns>string</returns>
        public string State()
        {
            return GetProperty(GlobalConstants.State);
        }

        /// <summary>
        /// Set the state
        /// </summary>
        /// <returns>void</returns>
        public void State(string data)
        {
            SetProperty(GlobalConstants.State, data);
        }

        /// <summary>
        /// Get the country
        /// </summary>
        /// <returns>string</returns>
        public string Country()
        {
            return GetProperty(GlobalConstants.Country);
        }

        /// <summary>
        /// Set the country
        /// </summary>
        /// <returns>void</returns>
        public void Country(string data)
        {
            SetProperty(GlobalConstants.Country, data);
        }

        /// <summary>
        /// Get the zip
        /// </summary>
        /// <returns>string</returns>
        public string Zip()
        {
            return GetProperty(GlobalConstants.Zip);
        }

        /// <summary>
        /// Set the zip
        /// </summary>
        /// <returns>void</returns>
        public void Zip(string data)
        {
            SetProperty(GlobalConstants.Zip, data);
        }

        /// <summary>
        /// Get the phone
        /// </summary>
        /// <returns>string</returns>
        public string Phone()
        {
            return GetProperty(GlobalConstants.Phone);
        }

        /// <summary>
        /// Set the phone
        /// </summary>
        /// <returns>void</returns>
        public void Phone(string data)
        {
            SetProperty(GlobalConstants.Phone, data);
        }
    }
}
