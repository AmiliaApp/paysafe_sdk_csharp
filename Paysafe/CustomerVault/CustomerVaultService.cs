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
using System.Text;
using System.Threading.Tasks;
using Paysafe.Common;

namespace Paysafe.CustomerVault
{
    public class CustomerVaultService
    {

        /// <summary>
        /// The api client, performs all http requests
        /// </summary>
        private readonly PaysafeApiClient _client;

        /// <summary>
        /// The card payments api base uri 
        /// </summary>
        private string _uri = "customervault/v1";

        /// <summary>
        /// Initialize the card payments service with an client object
        /// </summary>
        /// <param name="client">PaysafeApiClient</param>
        public CustomerVaultService(PaysafeApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Check if the service is available
        /// </summary>
        /// <returns>true if successful</returns>
        public Boolean Monitor()
        {
            Request request = new Request(uri: "customervault/monitor");
            dynamic response = _client.ProcessRequest(request);

            return ("READY".Equals((string)(response[GlobalConstants.Status])));
        }

        public async Task<bool> MonitorAsync()
        {
            Request request = new Request(uri: "customervault/monitor");
            dynamic response = await _client.ProcessRequestAsync(request);

            return ("READY".Equals((string)(response[GlobalConstants.Status])));
        }

        /// <summary>
        /// Create profile
        /// </summary>
        /// <param name="profile">Profile</param>
        /// <returns>Profile</returns>
        public Profile Create(Profile profile)
        {
            profile.SetRequiredFields(new List<string> {
                GlobalConstants.MerchantCustomerId,
                GlobalConstants.Locale
            });
            profile.SetOptionalFields(new List<string> {
                GlobalConstants.FirstName,
                GlobalConstants.MiddleName,
                GlobalConstants.LastName,
                GlobalConstants.DateOfBirth,
                GlobalConstants.Ip,
                GlobalConstants.Gender,
                GlobalConstants.Nationality,
                GlobalConstants.Email,
                GlobalConstants.Phone,
                GlobalConstants.CellPhone,
                GlobalConstants.Card
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles"),
                body: profile
            );
            dynamic response = _client.ProcessRequest(request);

            return new Profile(response);
        }

        public async Task<Profile> CreateAsync(Profile profile)
        {
            profile.SetRequiredFields(new List<string> {
                GlobalConstants.MerchantCustomerId,
                GlobalConstants.Locale
            });
            profile.SetOptionalFields(new List<string> {
                GlobalConstants.FirstName,
                GlobalConstants.MiddleName,
                GlobalConstants.LastName,
                GlobalConstants.DateOfBirth,
                GlobalConstants.Ip,
                GlobalConstants.Gender,
                GlobalConstants.Nationality,
                GlobalConstants.Email,
                GlobalConstants.Phone,
                GlobalConstants.CellPhone,
                GlobalConstants.Card
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles"),
                body: profile
            );
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Profile(response);
        }

        /// <summary>
        /// create address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Address</returns>
        public Address Create(Address address)
        {
            address.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            address.CheckRequiredFields();
            address.SetRequiredFields(new List<string> { GlobalConstants.Country });
            address.SetOptionalFields(new List<string> {
                GlobalConstants.NickName,
                GlobalConstants.Street,
                GlobalConstants.Street2,
                GlobalConstants.City,
                GlobalConstants.State,
                GlobalConstants.Zip,
                GlobalConstants.RecipientName,
                GlobalConstants.Phone
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + address.ProfileId() + "/addresses"),
                body: address
            );

            dynamic response = _client.ProcessRequest(request);

            Address returnVal = new Address(response);
            returnVal.ProfileId(address.ProfileId());
            return returnVal;
        }

        public async Task<Address> CreateAsync(Address address)
        {
            address.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            address.CheckRequiredFields();
            address.SetRequiredFields(new List<string> { GlobalConstants.Country });
            address.SetOptionalFields(new List<string> {
                GlobalConstants.NickName,
                GlobalConstants.Street,
                GlobalConstants.Street2,
                GlobalConstants.City,
                GlobalConstants.State,
                GlobalConstants.Zip,
                GlobalConstants.RecipientName,
                GlobalConstants.Phone
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + address.ProfileId() + "/addresses"),
                body: address
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            Address returnVal = new Address(response);
            returnVal.ProfileId(address.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// Create card 
        /// </summary>
        /// <param name="card">Card</param>
        /// <returns>Card</returns>
        public Card Create(Card card)
        {
            card.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            card.CheckRequiredFields();
            card.SetRequiredFields(new List<string> { 
                GlobalConstants.CardNum,
                GlobalConstants.CardExpiry
            });
            card.SetOptionalFields(new List<string> {
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum,
                GlobalConstants.HolderName,
                GlobalConstants.BillingAddressId
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + card.ProfileId() + "/cards"),
                body: card
            );

            dynamic response = _client.ProcessRequest(request);

            Card returnVal = new Card(response);
            returnVal.ProfileId(card.ProfileId());
            return returnVal;
        }

        public async Task<Card> CreateAsync(Card card)
        {
            card.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            card.CheckRequiredFields();
            card.SetRequiredFields(new List<string> {
                GlobalConstants.CardNum,
                GlobalConstants.CardExpiry
            });
            card.SetOptionalFields(new List<string> {
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum,
                GlobalConstants.HolderName,
                GlobalConstants.BillingAddressId
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + card.ProfileId() + "/cards"),
                body: card
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            Card returnVal = new Card(response);
            returnVal.ProfileId(card.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// Create ACHBankAccount
        /// </summary>
        /// <param name="ACHBankAccount">ACHBankAccount</param>
        /// <returns>ACHBankAccount</returns>
        public AchBankAccounts Create(AchBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            account.CheckRequiredFields();
            account.SetRequiredFields(new List<string> {
                GlobalConstants.AccountHolderName,
                GlobalConstants.AccountNumber,
                GlobalConstants.RoutingNumber,
                GlobalConstants.BillingAddressId,
                GlobalConstants.AccountType,                  
            });
            account.CheckRequiredFields();
            account.SetOptionalFields(new List<string> {
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum
            });
            
            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/achbankaccounts"),
                body: account
            );
            dynamic response = _client.ProcessRequest(request);

            AchBankAccounts returnVal = new AchBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;          
        }

        public async Task<AchBankAccounts> CreateAsync(AchBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            account.CheckRequiredFields();
            account.SetRequiredFields(new List<string> {
                GlobalConstants.AccountHolderName,
                GlobalConstants.AccountNumber,
                GlobalConstants.RoutingNumber,
                GlobalConstants.BillingAddressId,
                GlobalConstants.AccountType,
            });
            account.CheckRequiredFields();
            account.SetOptionalFields(new List<string> {
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/achbankaccounts"),
                body: account
            );
            dynamic response = await _client.ProcessRequestAsync(request);

            AchBankAccounts returnVal = new AchBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// Create BACSBankAccount
        /// </summary>
        /// <param name="BACSBankAccount">BACSBankAccount</param>
        /// <returns>BACSBankAccount</returns>
        public BacsBankAccounts Create(BacsBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            account.CheckRequiredFields();
            account.SetRequiredFields(new List<string> {               
                GlobalConstants.AccountNumber,
                GlobalConstants.SortCode,
                 GlobalConstants.AccountHolderName,
                GlobalConstants.BillingAddressId,                             
            });
            account.CheckRequiredFields();
            account.SetOptionalFields(new List<string> {
                GlobalConstants.Mandates,
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum,                
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/bacsbankaccounts"),
                body: account
            );
            dynamic response = _client.ProcessRequest(request);

            BacsBankAccounts returnVal = new BacsBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<BacsBankAccounts> CreateAsync(BacsBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            account.CheckRequiredFields();
            account.SetRequiredFields(new List<string> {
                GlobalConstants.AccountNumber,
                GlobalConstants.SortCode,
                GlobalConstants.AccountHolderName,
                GlobalConstants.BillingAddressId,
            });
            account.CheckRequiredFields();
            account.SetOptionalFields(new List<string> {
                GlobalConstants.Mandates,
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum,
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/bacsbankaccounts"),
                body: account
            );
            dynamic response = await _client.ProcessRequestAsync(request);

            BacsBankAccounts returnVal = new BacsBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// Create EFTBankAccount
        /// </summary>
        /// <param name="EFTBankAccount">EFTBankAccount</param>
        /// <returns>EFTBankAccount</returns>
        public EftBankAccounts Create(EftBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            account.CheckRequiredFields();
            account.SetRequiredFields(new List<string> {               
                GlobalConstants.AccountNumber,
                GlobalConstants.TransitNumber,
                GlobalConstants.InstitutionId,
                 GlobalConstants.AccountHolderName,
                GlobalConstants.BillingAddressId,                             
            });
            account.CheckRequiredFields();
            account.SetOptionalFields(new List<string> {                
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum,                
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/eftbankaccounts"),
                body: account
            );
            dynamic response = _client.ProcessRequest(request);

            EftBankAccounts returnVal = new EftBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<EftBankAccounts> CreateAsync(EftBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            account.CheckRequiredFields();
            account.SetRequiredFields(new List<string> {
                GlobalConstants.AccountNumber,
                GlobalConstants.TransitNumber,
                GlobalConstants.InstitutionId,
                GlobalConstants.AccountHolderName,
                GlobalConstants.BillingAddressId,
            });
            account.CheckRequiredFields();
            account.SetOptionalFields(new List<string> {
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum,
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/eftbankaccounts"),
                body: account
            );
            dynamic response = await _client.ProcessRequestAsync(request);

            EftBankAccounts returnVal = new EftBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }


        /// <summary>
        /// Create SEPABankAccount
        /// </summary>
        /// <param name="SEPABankAccount">SEPABankAccount</param>
        /// <returns>SEPABankAccount</returns>
        public SepaBankAccounts Create(SepaBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            account.CheckRequiredFields();
            account.SetRequiredFields(new List<string> {               
                GlobalConstants.Iban,
                GlobalConstants.Bic,           
                 GlobalConstants.AccountHolderName,
                GlobalConstants.BillingAddressId,                             
            });
            account.CheckRequiredFields();
            account.SetOptionalFields(new List<string> {                
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum,  
                GlobalConstants.Mandates
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/sepabankaccounts"),
                body: account
            );
            dynamic response = _client.ProcessRequest(request);

            SepaBankAccounts returnVal = new SepaBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<SepaBankAccounts> CreateAsync(SepaBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            account.CheckRequiredFields();
            account.SetRequiredFields(new List<string> {
                GlobalConstants.Iban,
                GlobalConstants.Bic,
                GlobalConstants.AccountHolderName,
                GlobalConstants.BillingAddressId,
            });
            account.CheckRequiredFields();
            account.SetOptionalFields(new List<string> {
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum,
                GlobalConstants.Mandates
            });

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/sepabankaccounts"),
                body: account
            );
            dynamic response = await _client.ProcessRequestAsync(request);

            SepaBankAccounts returnVal = new SepaBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// Create Mandates
        /// </summary>
        /// <param name="Mandates">Mandates</param>
        /// <returns>Mandates</returns>
        public Mandates Create(Mandates account, string accountName)
        {
            account.SetRequiredFields(new List<string> { 
                GlobalConstants.Reference,
                GlobalConstants.ProfileId,
                GlobalConstants.BankAccountId
            });
          
            account.CheckRequiredFields();

            if (accountName.Equals("SEPA"))
                accountName = "/sepabankaccounts/";
            else
                accountName = "/bacsbankaccounts/";

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + account.ProfileId() + accountName + account.BankAccountId() + "/mandates"),
                body: account
            );
            dynamic response = _client.ProcessRequest(request);

            Mandates returnVal = new Mandates(response);            
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<Mandates> CreateAsync(Mandates account, string accountName)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.Reference,
                GlobalConstants.ProfileId,
                GlobalConstants.BankAccountId
            });

            account.CheckRequiredFields();

            if (accountName.Equals("SEPA"))
                accountName = "/sepabankaccounts/";
            else
                accountName = "/bacsbankaccounts/";

            Request request = new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + account.ProfileId() + accountName + account.BankAccountId() + "/mandates"),
                body: account
            );
            dynamic response = await _client.ProcessRequestAsync(request);

            Mandates returnVal = new Mandates(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// update Profile  
        /// </summary>
        /// <param name="profile">Profile</param>
        /// <returns>Profile</returns>
        public Profile Update(Profile profile)
        {
            profile.SetRequiredFields(new List<string> { GlobalConstants.Id });
            profile.CheckRequiredFields();
            profile.SetRequiredFields(new List<string> {
                GlobalConstants.MerchantCustomerId,
                GlobalConstants.Locale
            });
            profile.SetOptionalFields(new List<string> {
                GlobalConstants.FirstName,
                GlobalConstants.MiddleName,
                GlobalConstants.LastName,
                GlobalConstants.DateOfBirth,
                GlobalConstants.Ip,
                GlobalConstants.Gender,
                GlobalConstants.Nationality,
                GlobalConstants.Email,
                GlobalConstants.Phone,
                GlobalConstants.CellPhone
            });

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + profile.Id()),
                body: profile
            );

            dynamic response = _client.ProcessRequest(request);

            return new Profile(response);
        }

        public async Task<Profile> UpdateAsync(Profile profile)
        {
            profile.SetRequiredFields(new List<string> { GlobalConstants.Id });
            profile.CheckRequiredFields();
            profile.SetRequiredFields(new List<string> {
                GlobalConstants.MerchantCustomerId,
                GlobalConstants.Locale
            });
            profile.SetOptionalFields(new List<string> {
                GlobalConstants.FirstName,
                GlobalConstants.MiddleName,
                GlobalConstants.LastName,
                GlobalConstants.DateOfBirth,
                GlobalConstants.Ip,
                GlobalConstants.Gender,
                GlobalConstants.Nationality,
                GlobalConstants.Email,
                GlobalConstants.Phone,
                GlobalConstants.CellPhone
            });

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + profile.Id()),
                body: profile
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Profile(response);
        }

        /// <summary>
        /// Update address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Address</returns>
        public Address Update(Address address)
        {
            address.SetRequiredFields(new List<string> { 
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            address.CheckRequiredFields();
            address.SetRequiredFields(new List<string> { GlobalConstants.Country });
            address.SetOptionalFields(new List<string> {
                GlobalConstants.NickName,
                GlobalConstants.Street,
                GlobalConstants.Street2,
                GlobalConstants.City,
                GlobalConstants.State,
                GlobalConstants.Zip,
                GlobalConstants.RecipientName,
                GlobalConstants.Phone
            });

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + address.ProfileId() + "/addresses/" + address.Id()),
                body: address
            );

            dynamic response = _client.ProcessRequest(request);

            Address returnVal = new Address(response);
            returnVal.ProfileId(address.ProfileId());
            return returnVal;
        }

        public async Task<Address> UpdateAsync(Address address)
        {
            address.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            address.CheckRequiredFields();
            address.SetRequiredFields(new List<string> { GlobalConstants.Country });
            address.SetOptionalFields(new List<string> {
                GlobalConstants.NickName,
                GlobalConstants.Street,
                GlobalConstants.Street2,
                GlobalConstants.City,
                GlobalConstants.State,
                GlobalConstants.Zip,
                GlobalConstants.RecipientName,
                GlobalConstants.Phone
            });

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + address.ProfileId() + "/addresses/" + address.Id()),
                body: address
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            Address returnVal = new Address(response);
            returnVal.ProfileId(address.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// Update card 
        /// </summary>
        /// <param name="card">Card</param>
        /// <returns>Card</returns>
        public Card Update(Card card)
        {
            card.SetRequiredFields(new List<string> { 
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            card.CheckRequiredFields();
            card.SetRequiredFields(new List<string> {});
            card.SetOptionalFields(new List<string> {
                GlobalConstants.CardExpiry,
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum,
                GlobalConstants.HolderName,
                GlobalConstants.BillingAddressId
            });

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + card.ProfileId() + "/cards/" + card.Id()),
                body: card
            );

            dynamic response = _client.ProcessRequest(request);

            Card returnVal = new Card(response);
            returnVal.ProfileId(card.ProfileId());
            return returnVal;
        }

        public async Task<Card> UpdateAsync(Card card)
        {
            card.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            card.CheckRequiredFields();
            card.SetRequiredFields(new List<string> { });
            card.SetOptionalFields(new List<string> {
                GlobalConstants.CardExpiry,
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum,
                GlobalConstants.HolderName,
                GlobalConstants.BillingAddressId
            });

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + card.ProfileId() + "/cards/" + card.Id()),
                body: card
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            Card returnVal = new Card(response);
            returnVal.ProfileId(card.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// update ACHBankAccount
        /// </summary>
        /// <param name="ACHBankAccount">ACHBankAccount</param>
        /// <returns>ACHBankAccount</returns>
        public AchBankAccounts Update(AchBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            account.CheckRequiredFields();
            account.SetRequiredFields(new List<string> {
                GlobalConstants.AccountHolderName,                
                GlobalConstants.RoutingNumber,
                GlobalConstants.BillingAddressId,
                GlobalConstants.AccountType,                  
            });
            account.CheckRequiredFields();
            account.SetOptionalFields(new List<string> {
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum,
                GlobalConstants.AccountNumber
            });
         
            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/achbankaccounts/" + account.Id()),
                body: account
            );
            dynamic response = _client.ProcessRequest(request);

            AchBankAccounts returnVal = new AchBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;           
        }

        public async Task<AchBankAccounts> UpdateAsync(AchBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            account.CheckRequiredFields();
            account.SetRequiredFields(new List<string> {
                GlobalConstants.AccountHolderName,
                GlobalConstants.RoutingNumber,
                GlobalConstants.BillingAddressId,
                GlobalConstants.AccountType,
            });
            account.CheckRequiredFields();
            account.SetOptionalFields(new List<string> {
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum,
                GlobalConstants.AccountNumber
            });

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/achbankaccounts/" + account.Id()),
                body: account
            );
            dynamic response = await _client.ProcessRequestAsync(request);

            AchBankAccounts returnVal = new AchBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// update BACSBankAccount
        /// </summary>
        /// <param name="BACSBankAccount">BACSBankAccount</param>
        /// <returns>BACSBankAccount</returns>
        public BacsBankAccounts Update(BacsBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            account.CheckRequiredFields();
            account.SetOptionalFields(new List<string> {
            GlobalConstants.NickName,
            GlobalConstants.MerchantRefNum,  
            GlobalConstants.AccountNumber,
            GlobalConstants.AccountHolderName,               
            GlobalConstants.SortCode,
            GlobalConstants.BillingAddressId,   
            });
            
            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/bacsbankaccounts/" + account.Id()),
                body: account
            );
            dynamic response = _client.ProcessRequest(request);

            BacsBankAccounts returnVal = new BacsBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<BacsBankAccounts> UpdateAsync(BacsBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            account.CheckRequiredFields();
            account.SetOptionalFields(new List<string> {
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum,
                GlobalConstants.AccountNumber,
                GlobalConstants.AccountHolderName,
                GlobalConstants.SortCode,
                GlobalConstants.BillingAddressId,
            });

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/bacsbankaccounts/" + account.Id()),
                body: account
            );
            dynamic response = await _client.ProcessRequestAsync(request);

            BacsBankAccounts returnVal = new BacsBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// update EFTBankAccount
        /// </summary>
        /// <param name="EFTBankAccount">EFTBankAccount</param>
        /// <returns>EFTBankAccount</returns>
        public EftBankAccounts Update(EftBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            account.CheckRequiredFields();
            account.SetRequiredFields(new List<string> {
                 GlobalConstants.TransitNumber,
                GlobalConstants.InstitutionId,
                GlobalConstants.AccountHolderName,               
                GlobalConstants.BillingAddressId                                
            });
            account.CheckRequiredFields();
            account.SetOptionalFields(new List<string> {
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum, 
                GlobalConstants.AccountNumber
            });

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/eftbankaccounts/" + account.Id()),
                body: account
            );
            dynamic response = _client.ProcessRequest(request);

            EftBankAccounts returnVal = new EftBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<EftBankAccounts> UpdateAsync(EftBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            account.CheckRequiredFields();
            account.SetRequiredFields(new List<string> {
                GlobalConstants.TransitNumber,
                GlobalConstants.InstitutionId,
                GlobalConstants.AccountHolderName,
                GlobalConstants.BillingAddressId
            });
            account.CheckRequiredFields();
            account.SetOptionalFields(new List<string> {
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum,
                GlobalConstants.AccountNumber
            });

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/eftbankaccounts/" + account.Id()),
                body: account
            );
            dynamic response = await _client.ProcessRequestAsync(request);

            EftBankAccounts returnVal = new EftBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// update SEPABankAccount
        /// </summary>
        /// <param name="SEPABankAccount">SEPABankAccount</param>
        /// <returns>SEPABankAccount</returns>
        public SepaBankAccounts Update(SepaBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            account.CheckRequiredFields();
            account.SetOptionalFields(new List<string> {
            GlobalConstants.NickName,
            GlobalConstants.MerchantRefNum,  
            GlobalConstants.AccountHolderName,
            GlobalConstants.Iban,
            GlobalConstants.Bic,
            GlobalConstants.BillingAddressId,  
            });

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/sepabankaccounts/" + account.Id()),
                body: account
            );
            dynamic response = _client.ProcessRequest(request);

            SepaBankAccounts returnVal = new SepaBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<SepaBankAccounts> UpdateAsync(SepaBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.ProfileId });
            account.CheckRequiredFields();
            account.SetOptionalFields(new List<string> {
                GlobalConstants.NickName,
                GlobalConstants.MerchantRefNum,
                GlobalConstants.AccountHolderName,
                GlobalConstants.Iban,
                GlobalConstants.Bic,
                GlobalConstants.BillingAddressId,
            });

            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/sepabankaccounts/" + account.Id()),
                body: account
            );
            dynamic response = await _client.ProcessRequestAsync(request);

            SepaBankAccounts returnVal = new SepaBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// update Mandates
        /// </summary>
        /// <param name="Mandates">Mandates</param>
        /// <returns>Mandates</returns>
        public Mandates Update(Mandates account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.Status });
            account.CheckRequiredFields();            
            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/mandates/" + account.Id()),
                body: account
            );
            dynamic response = _client.ProcessRequest(request);

            Mandates returnVal = new Mandates(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<Mandates> UpdateAsync(Mandates account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.Status });
            account.CheckRequiredFields();
            Request request = new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/mandates/" + account.Id()),
                body: account
            );
            dynamic response = await _client.ProcessRequestAsync(request);

            Mandates returnVal = new Mandates(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// delete profile
        /// </summary>
        /// <param name="profile">Profile</param>
        /// <returns>bool</returns>
        public bool Delete(Profile profile)
        {
            profile.SetRequiredFields(new List<string> { GlobalConstants.Id });
            profile.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + profile.Id())
            );

            _client.ProcessRequest(request);

            return true;
        }

        public async Task<bool> DeleteAsync(Profile profile)
        {
            profile.SetRequiredFields(new List<string> { GlobalConstants.Id });
            profile.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + profile.Id())
            );

            await _client.ProcessRequestAsync(request);

            return true;
        }

        /// <summary>
        ///Delete address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>bool</returns>
        public bool Delete(Address address)
        {
            address.SetRequiredFields(new List<string> { 
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            address.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + address.ProfileId() + "/addresses/" + address.Id())
            );

            _client.ProcessRequest(request);
            return true;
        }

        public async Task<bool> DeleteAsync(Address address)
        {
            address.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            address.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + address.ProfileId() + "/addresses/" + address.Id())
            );

            await _client.ProcessRequestAsync(request);
            return true;
        }

        /// <summary>
        /// Delete card 
        /// </summary>
        /// <param name="card">Card</param>
        /// <returns>bool</returns>
        public bool Delete(Card card)
        {
            card.SetRequiredFields(new List<string> { 
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            card.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + card.ProfileId() + "/cards/" + card.Id()),
                body: card
            );

            _client.ProcessRequest(request);

            return true;
        }

        public async Task<bool> DeleteAsync(Card card)
        {
            card.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            card.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + card.ProfileId() + "/cards/" + card.Id()),
                body: card
            );

            await _client.ProcessRequestAsync(request);

            return true;
        }

        /// <summary>
        ///Delete ACHBankAccount 
        /// </summary>
        /// <param name="ACHBankAccount">ACHBankAccount</param>
        /// <returns>bool</returns>
        public bool Delete(AchBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { 
               GlobalConstants.ProfileId,
               GlobalConstants.Id              
            });
            account.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/achbankaccounts/" + account.Id())
            );

            _client.ProcessRequest(request);
            return true;
        }

        public async Task<bool> DeleteAsync(AchBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/achbankaccounts/" + account.Id())
            );

            await _client.ProcessRequestAsync(request);
            return true;
        }

        /// <summary>
        ///Delete BACSBankAccount 
        /// </summary>
        /// <param name="BACSBankAccount">BACSBankAccount</param>
        /// <returns>bool</returns>
        public bool Delete(BacsBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { 
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/bacsbankaccounts/" + account.Id())
            );

            _client.ProcessRequest(request);
            return true;
        }

        public async Task<bool> DeleteAsync(BacsBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/bacsbankaccounts/" + account.Id())
            );

            await _client.ProcessRequestAsync(request);
            return true;
        }

        /// <summary>
        ///Delete EFTBankAccount 
        /// </summary>
        /// <param name="EFTBankAccount">EFTBankAccount</param>
        /// <returns>bool</returns>
        public bool Delete(EftBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { 
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/eftbankaccounts/" + account.Id())
            );

            _client.ProcessRequest(request);
            return true;
        }

        public async Task<bool> DeleteAsync(EftBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/eftbankaccounts/" + account.Id())
            );

            await _client.ProcessRequestAsync(request);
            return true;
        }


        /// <summary>
        ///Delete SEPABankAccount 
        /// </summary>
        /// <param name="SEPABankAccount">SEPABankAccount</param>
        /// <returns>bool</returns>
        public bool Delete(SepaBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { 
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/sepabankaccounts/" + account.Id())
            );

            _client.ProcessRequest(request);
            return true;
        }

        public async Task<bool> DeleteAsync(SepaBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/sepabankaccounts/" + account.Id())
            );

            await _client.ProcessRequestAsync(request);
            return true;
        }

        /// <summary>
        ///Delete Mandates 
        /// </summary>
        /// <param name="Mandates">Mandates</param>
        /// <returns>bool</returns>
        public bool Delete(Mandates account)
        {
            account.SetRequiredFields(new List<string> { 
                GlobalConstants.ProfileId,
                GlobalConstants.Id,
                GlobalConstants.BankAccountId
            });           
            Request request = new Request(
                method: RequestType.Delete,
                 uri: PrepareUri("/profiles/" + account.ProfileId() + "/mandates/" + account.Id())
            );

            _client.ProcessRequest(request);
            return true;
        }

        public async Task<bool> DeleteAsync(Mandates account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id,
                GlobalConstants.BankAccountId
            });
            Request request = new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/mandates/" + account.Id())
            );

            await _client.ProcessRequestAsync(request);
            return true;
        }

        /// <summary>
        /// get profile with subcomponents
        /// </summary>
        /// <param name="profile">Profile</param>
        /// <returns>Profile</returns>
        public Profile Get(Profile profile, bool includeAddresses = false, bool includeCards = false, bool includeAchBankAccounts = false,
            bool includeBacsBankAccounts = false, bool includeEftBankAccounts = false, bool includeSepaBankAccounts = false)
        {
            profile.SetRequiredFields(new List<string> { GlobalConstants.Id });
            profile.CheckRequiredFields();

            Dictionary<string, string> queryStr = new Dictionary<string, string>();                       
            StringBuilder toInclude = new StringBuilder();
            if (includeAddresses)
            {                                            
                toInclude.Append("addresses");
            }
            if (includeCards)
            {
                if (toInclude.Length > 0)
                {
                    toInclude.Append(",");
                }
                toInclude.Append("cards");
            }
            if (includeAchBankAccounts)
            {
                if (toInclude.Length > 0)
                {
                    toInclude.Append(",");
                }
                toInclude.Append("achbankaccounts");
            }
            if (includeBacsBankAccounts)
            {
                if (toInclude.Length > 0)
                {
                    toInclude.Append(",");
                }
                toInclude.Append("bacsbankaccounts");
            }
            if (includeEftBankAccounts)
            {
                if (toInclude.Length > 0)
                {
                    toInclude.Append(",");
                }
                toInclude.Append("eftbankaccounts");
            }
            if (includeSepaBankAccounts)
            {
                if (toInclude.Length > 0)
                {
                    toInclude.Append(",");
                }
                toInclude.Append("sepabankaccounts");
            }

            queryStr.Add("fields", toInclude.ToString());                                          
            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + profile.Id()),
                queryString: queryStr
            );

            dynamic response = _client.ProcessRequest(request);

            return new Profile(response);
        }

        public async Task<Profile> GetAsync(Profile profile, bool includeAddresses = false, bool includeCards = false, bool includeAchBankAccounts = false,
            bool includeBacsBankAccounts = false, bool includeEftBankAccounts = false, bool includeSepaBankAccounts = false)
        {
            profile.SetRequiredFields(new List<string> { GlobalConstants.Id });
            profile.CheckRequiredFields();

            Dictionary<string, string> queryStr = new Dictionary<string, string>();
            StringBuilder toInclude = new StringBuilder();
            if (includeAddresses)
            {
                toInclude.Append("addresses");
            }
            if (includeCards)
            {
                if (toInclude.Length > 0)
                {
                    toInclude.Append(",");
                }
                toInclude.Append("cards");
            }
            if (includeAchBankAccounts)
            {
                if (toInclude.Length > 0)
                {
                    toInclude.Append(",");
                }
                toInclude.Append("achbankaccounts");
            }
            if (includeBacsBankAccounts)
            {
                if (toInclude.Length > 0)
                {
                    toInclude.Append(",");
                }
                toInclude.Append("bacsbankaccounts");
            }
            if (includeEftBankAccounts)
            {
                if (toInclude.Length > 0)
                {
                    toInclude.Append(",");
                }
                toInclude.Append("eftbankaccounts");
            }
            if (includeSepaBankAccounts)
            {
                if (toInclude.Length > 0)
                {
                    toInclude.Append(",");
                }
                toInclude.Append("sepabankaccounts");
            }

            queryStr.Add("fields", toInclude.ToString());
            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + profile.Id()),
                queryString: queryStr
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            return new Profile(response);
        }

        /// <summary>
        /// Get address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Address</returns>
        public Address Get(Address address)
        {
            address.SetRequiredFields(new List<string> { 
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            address.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + address.ProfileId() + "/addresses/" + address.Id()),
                body: address
            );

            dynamic response = _client.ProcessRequest(request);

            Address returnVal = new Address(response);
            returnVal.ProfileId(address.ProfileId());
            return returnVal;
        }

        public async Task<Address> GetAsync(Address address)
        {
            address.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            address.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + address.ProfileId() + "/addresses/" + address.Id()),
                body: address
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            Address returnVal = new Address(response);
            returnVal.ProfileId(address.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// Get card 
        /// </summary>
        /// <param name="card">Card</param>
        /// <returns>Card</returns>
        public Card Get(Card card)
        {
            card.SetRequiredFields(new List<string> { 
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            card.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + card.ProfileId() + "/cards/" + card.Id())
            );

            dynamic response = _client.ProcessRequest(request);

            Card returnVal = new Card(response);
            returnVal.ProfileId(card.ProfileId());
            return returnVal;
        }

        public async Task<Card> GetAsync(Card card)
        {
            card.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            card.CheckRequiredFields();

            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + card.ProfileId() + "/cards/" + card.Id())
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            Card returnVal = new Card(response);
            returnVal.ProfileId(card.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// Get ACHBankAccount 
        /// </summary>
        /// <param name="ACHBankAccount">ACHBankAccount</param>
        /// <returns>ACHBankAccount</returns>
        public AchBankAccounts Get(AchBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { 
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();           
            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/achbankaccounts/" + account.Id())
            );

            dynamic response = _client.ProcessRequest(request);

            AchBankAccounts returnVal = new AchBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<AchBankAccounts> GetAsync(AchBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();
            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/achbankaccounts/" + account.Id())
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            AchBankAccounts returnVal = new AchBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// Get BACSBankAccount 
        /// </summary>
        /// <param name="BACSBankAccount">BACSBankAccount</param>
        /// <returns>BACSBankAccount</returns>
        public BacsBankAccounts Get(BacsBankAccounts account)
        {
            account.SetRequiredFields(new List<string> { 
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();
            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/bacsbankaccounts/" + account.Id())
            );

            dynamic response = _client.ProcessRequest(request);

            BacsBankAccounts returnVal = new BacsBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<BacsBankAccounts> GetAsync(BacsBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();
            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/bacsbankaccounts/" + account.Id())
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            BacsBankAccounts returnVal = new BacsBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// Get EFTBankAccount 
        /// </summary>
        /// <param name="EFTBankAccount">EFTBankAccount</param>
        /// <returns>EFTBankAccount</returns>
        public EftBankAccounts Get(EftBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {                 
                GlobalConstants.BillingAddressId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();
            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/eftbankaccounts/" + account.Id())
            );

            dynamic response = _client.ProcessRequest(request);

            EftBankAccounts returnVal = new EftBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<EftBankAccounts> GetAsync(EftBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.BillingAddressId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();
            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/eftbankaccounts/" + account.Id())
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            EftBankAccounts returnVal = new EftBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// Get SEPABankAccount 
        /// </summary>
        /// <param name="SEPABankAccount">SEPABankAccount</param>
        /// <returns>SEPABankAccount</returns>
        public SepaBankAccounts Get(SepaBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {                 
                GlobalConstants.BillingAddressId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();
            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/sepabankaccounts/" + account.Id())
            );

            dynamic response = _client.ProcessRequest(request);

            SepaBankAccounts returnVal = new SepaBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<SepaBankAccounts> GetAsync(SepaBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.BillingAddressId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();
            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/sepabankaccounts/" + account.Id())
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            SepaBankAccounts returnVal = new SepaBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        /// <summary>
        /// Get Mandates 
        /// </summary>
        /// <param name="Mandates">Mandates</param>
        /// <returns>Mandates</returns>
        public Mandates Get(Mandates account)
        {
            account.SetRequiredFields(new List<string> {                               
                GlobalConstants.Id,
                GlobalConstants.ProfileId
            });            
            account.CheckRequiredFields();            
            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/mandates/" + account.Id())
            );

            dynamic response = _client.ProcessRequest(request);

            Mandates returnVal = new Mandates(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<Mandates> GetAsync(Mandates account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.Id,
                GlobalConstants.ProfileId
            });
            account.CheckRequiredFields();
            Request request = new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/mandates/" + account.Id())
            );

            dynamic response = await _client.ProcessRequestAsync(request);

            Mandates returnVal = new Mandates(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        private string PrepareUri(string path)
        {
            return _uri + path;
        }
    }
}
