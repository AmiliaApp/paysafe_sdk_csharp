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
            var request = CreateInternal(profile);
            dynamic response = _client.ProcessRequest(request);

            return new Profile(response);
        }

        public async Task<Profile> CreateAsync(Profile profile)
        {
            var request = CreateInternal(profile);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Profile(response);
        }

        private Request CreateInternal(Profile profile)
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

            return new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles"),
                body: profile
            );
        }

        /// <summary>
        /// create address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Address</returns>
        public Address Create(Address address)
        {
            var request = CreateInternal(address);
            dynamic response = _client.ProcessRequest(request);

            Address returnVal = new Address(response);
            returnVal.ProfileId(address.ProfileId());
            return returnVal;
        }

        public async Task<Address> CreateAsync(Address address)
        {
            var request = CreateInternal(address);
            dynamic response = await _client.ProcessRequestAsync(request);

            Address returnVal = new Address(response);
            returnVal.ProfileId(address.ProfileId());
            return returnVal;
        }

        private Request CreateInternal(Address address)
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

            return new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + address.ProfileId() + "/addresses"),
                body: address
            );
        }

        /// <summary>
        /// Create card 
        /// </summary>
        /// <param name="card">Card</param>
        /// <returns>Card</returns>
        public Card Create(Card card)
        {
            var request = CreateInternal(card);
            dynamic response = _client.ProcessRequest(request);

            Card returnVal = new Card(response);
            returnVal.ProfileId(card.ProfileId());
            return returnVal;
        }

        public async Task<Card> CreateAsync(Card card)
        {
            var request = CreateInternal(card);
            dynamic response = await _client.ProcessRequestAsync(request);

            Card returnVal = new Card(response);
            returnVal.ProfileId(card.ProfileId());
            return returnVal;
        }

        private Request CreateInternal(Card card)
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

            return new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + card.ProfileId() + "/cards"),
                body: card
            );
        }

        /// <summary>
        /// Create ACHBankAccount
        /// </summary>
        /// <param name="ACHBankAccount">ACHBankAccount</param>
        /// <returns>ACHBankAccount</returns>
        public AchBankAccounts Create(AchBankAccounts account)
        {
            var request = CreateInternal(account);
            dynamic response = _client.ProcessRequest(request);

            AchBankAccounts returnVal = new AchBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;          
        }

        public async Task<AchBankAccounts> CreateAsync(AchBankAccounts account)
        {
            var request = CreateInternal(account);
            dynamic response = await _client.ProcessRequestAsync(request);

            AchBankAccounts returnVal = new AchBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        private Request CreateInternal(AchBankAccounts account)
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

            return new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/achbankaccounts"),
                body: account
            );
        }

        /// <summary>
        /// Create BACSBankAccount
        /// </summary>
        /// <param name="BACSBankAccount">BACSBankAccount</param>
        /// <returns>BACSBankAccount</returns>
        public BacsBankAccounts Create(BacsBankAccounts account)
        {
            var request = CreateInternal(account);
            dynamic response = _client.ProcessRequest(request);

            BacsBankAccounts returnVal = new BacsBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<BacsBankAccounts> CreateAsync(BacsBankAccounts account)
        {
            var request = CreateInternal(account);
            dynamic response = await _client.ProcessRequestAsync(request);

            BacsBankAccounts returnVal = new BacsBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        private Request CreateInternal(BacsBankAccounts account)
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

            return new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/bacsbankaccounts"),
                body: account
            );
        }

        /// <summary>
        /// Create EFTBankAccount
        /// </summary>
        /// <param name="EFTBankAccount">EFTBankAccount</param>
        /// <returns>EFTBankAccount</returns>
        public EftBankAccounts Create(EftBankAccounts account)
        {
            var request = CreateInternal(account);
            dynamic response = _client.ProcessRequest(request);

            EftBankAccounts returnVal = new EftBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<EftBankAccounts> CreateAsync(EftBankAccounts account)
        {
            var request = CreateInternal(account);
            dynamic response = await _client.ProcessRequestAsync(request);

            EftBankAccounts returnVal = new EftBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        private Request CreateInternal(EftBankAccounts account)
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

            return new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/eftbankaccounts"),
                body: account
            );
        }

        /// <summary>
        /// Create SEPABankAccount
        /// </summary>
        /// <param name="SEPABankAccount">SEPABankAccount</param>
        /// <returns>SEPABankAccount</returns>
        public SepaBankAccounts Create(SepaBankAccounts account)
        {
            var request = CreateInternal(account);
            dynamic response = _client.ProcessRequest(request);

            SepaBankAccounts returnVal = new SepaBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<SepaBankAccounts> CreateAsync(SepaBankAccounts account)
        {
            var request = CreateInternal(account);
            dynamic response = await _client.ProcessRequestAsync(request);

            SepaBankAccounts returnVal = new SepaBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        private Request CreateInternal(SepaBankAccounts account)
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

            return new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/sepabankaccounts"),
                body: account
            );
        }

        /// <summary>
        /// Create Mandates
        /// </summary>
        /// <param name="Mandates">Mandates</param>
        /// <returns>Mandates</returns>
        public Mandates Create(Mandates account, string accountName)
        {
            var request = CreateInternal(account, accountName);
            dynamic response = _client.ProcessRequest(request);

            Mandates returnVal = new Mandates(response);            
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<Mandates> CreateAsync(Mandates account, string accountName)
        {
            var request = CreateInternal(account, accountName);
            dynamic response = await _client.ProcessRequestAsync(request);

            Mandates returnVal = new Mandates(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        private Request CreateInternal(Mandates account, string accountName)
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

            return new Request(
                method: RequestType.Post,
                uri: PrepareUri("/profiles/" + account.ProfileId() + accountName + account.BankAccountId() + "/mandates"),
                body: account
            );
        }

        /// <summary>
        /// update Profile  
        /// </summary>
        /// <param name="profile">Profile</param>
        /// <returns>Profile</returns>
        public Profile Update(Profile profile)
        {
            var request = UpdateInternal(profile);
            dynamic response = _client.ProcessRequest(request);

            return new Profile(response);
        }

        public async Task<Profile> UpdateAsync(Profile profile)
        {
            var request = UpdateInternal(profile);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Profile(response);
        }

        private Request UpdateInternal(Profile profile)
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

            return new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + profile.Id()),
                body: profile
            );
        }

        /// <summary>
        /// Update address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Address</returns>
        public Address Update(Address address)
        {
            var request = UpdateInternal(address);
            dynamic response = _client.ProcessRequest(request);

            Address returnVal = new Address(response);
            returnVal.ProfileId(address.ProfileId());
            return returnVal;
        }

        public async Task<Address> UpdateAsync(Address address)
        {
            var request = UpdateInternal(address);
            dynamic response = await _client.ProcessRequestAsync(request);

            Address returnVal = new Address(response);
            returnVal.ProfileId(address.ProfileId());
            return returnVal;
        }

        private Request UpdateInternal(Address address)
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

            return new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + address.ProfileId() + "/addresses/" + address.Id()),
                body: address
            );
        }

        /// <summary>
        /// Update card 
        /// </summary>
        /// <param name="card">Card</param>
        /// <returns>Card</returns>
        public Card Update(Card card)
        {
            var request = UpdateInternal(card);
            dynamic response = _client.ProcessRequest(request);

            Card returnVal = new Card(response);
            returnVal.ProfileId(card.ProfileId());
            return returnVal;
        }

        public async Task<Card> UpdateAsync(Card card)
        {
            var request = UpdateInternal(card);
            dynamic response = await _client.ProcessRequestAsync(request);

            Card returnVal = new Card(response);
            returnVal.ProfileId(card.ProfileId());
            return returnVal;
        }

        private Request UpdateInternal(Card card)
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

            return new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + card.ProfileId() + "/cards/" + card.Id()),
                body: card
            );
        }

        /// <summary>
        /// update ACHBankAccount
        /// </summary>
        /// <param name="ACHBankAccount">ACHBankAccount</param>
        /// <returns>ACHBankAccount</returns>
        public AchBankAccounts Update(AchBankAccounts account)
        {
            var request = UpdateInternal(account);
            dynamic response = _client.ProcessRequest(request);

            AchBankAccounts returnVal = new AchBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;           
        }

        public async Task<AchBankAccounts> UpdateAsync(AchBankAccounts account)
        {
            var request = UpdateInternal(account);
            dynamic response = await _client.ProcessRequestAsync(request);

            AchBankAccounts returnVal = new AchBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        private Request UpdateInternal(AchBankAccounts account)
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

            return new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/achbankaccounts/" + account.Id()),
                body: account
            );
        }

        /// <summary>
        /// update BACSBankAccount
        /// </summary>
        /// <param name="BACSBankAccount">BACSBankAccount</param>
        /// <returns>BACSBankAccount</returns>
        public BacsBankAccounts Update(BacsBankAccounts account)
        {
            var request = UpdateInternal(account);
            dynamic response = _client.ProcessRequest(request);

            BacsBankAccounts returnVal = new BacsBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<BacsBankAccounts> UpdateAsync(BacsBankAccounts account)
        {
            var request = UpdateInternal(account);
            dynamic response = await _client.ProcessRequestAsync(request);

            BacsBankAccounts returnVal = new BacsBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        private Request UpdateInternal(BacsBankAccounts account)
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

            return new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/bacsbankaccounts/" + account.Id()),
                body: account
            );
        }

        /// <summary>
        /// update EFTBankAccount
        /// </summary>
        /// <param name="EFTBankAccount">EFTBankAccount</param>
        /// <returns>EFTBankAccount</returns>
        public EftBankAccounts Update(EftBankAccounts account)
        {
            var request = UpdateInternal(account);
            dynamic response = _client.ProcessRequest(request);

            EftBankAccounts returnVal = new EftBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<EftBankAccounts> UpdateAsync(EftBankAccounts account)
        {
            var request = UpdateInternal(account);
            dynamic response = await _client.ProcessRequestAsync(request);

            EftBankAccounts returnVal = new EftBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        private Request UpdateInternal(EftBankAccounts account)
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

            return new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/eftbankaccounts/" + account.Id()),
                body: account
            );
        }

        /// <summary>
        /// update SEPABankAccount
        /// </summary>
        /// <param name="SEPABankAccount">SEPABankAccount</param>
        /// <returns>SEPABankAccount</returns>
        public SepaBankAccounts Update(SepaBankAccounts account)
        {
            var request = UpdateInternal(account);
            dynamic response = _client.ProcessRequest(request);

            SepaBankAccounts returnVal = new SepaBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<SepaBankAccounts> UpdateAsync(SepaBankAccounts account)
        {
            var request = UpdateInternal(account);
            dynamic response = await _client.ProcessRequestAsync(request);

            SepaBankAccounts returnVal = new SepaBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        private Request UpdateInternal(SepaBankAccounts account)
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

            return new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/sepabankaccounts/" + account.Id()),
                body: account
            );
        }

        /// <summary>
        /// update Mandates
        /// </summary>
        /// <param name="Mandates">Mandates</param>
        /// <returns>Mandates</returns>
        public Mandates Update(Mandates account)
        {
            var request = UpdateInternal(account);
            dynamic response = _client.ProcessRequest(request);

            Mandates returnVal = new Mandates(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<Mandates> UpdateAsync(Mandates account)
        {
            var request = UpdateInternal(account);
            dynamic response = await _client.ProcessRequestAsync(request);

            Mandates returnVal = new Mandates(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        private Request UpdateInternal(Mandates account)
        {
            account.SetRequiredFields(new List<string> { GlobalConstants.Status });
            account.CheckRequiredFields();
            return new Request(
                method: RequestType.Put,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/mandates/" + account.Id()),
                body: account
            );
        }

        /// <summary>
        /// delete profile
        /// </summary>
        /// <param name="profile">Profile</param>
        /// <returns>bool</returns>
        public bool Delete(Profile profile)
        {
            var request = DeleteInternal(profile);
            _client.ProcessRequest(request);

            return true;
        }

        public async Task<bool> DeleteAsync(Profile profile)
        {
            var request = DeleteInternal(profile);
            await _client.ProcessRequestAsync(request);

            return true;
        }

        private Request DeleteInternal(Profile profile)
        {
            profile.SetRequiredFields(new List<string> { GlobalConstants.Id });
            profile.CheckRequiredFields();

            return new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + profile.Id())
            );
        }

        /// <summary>
        ///Delete address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>bool</returns>
        public bool Delete(Address address)
        {
            var request = DeleteInternal(address);
            _client.ProcessRequest(request);
            return true;
        }

        public async Task<bool> DeleteAsync(Address address)
        {
            var request = DeleteInternal(address);
            await _client.ProcessRequestAsync(request);
            return true;
        }

        private Request DeleteInternal(Address address)
        {
            address.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            address.CheckRequiredFields();

            return new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + address.ProfileId() + "/addresses/" + address.Id())
            );
        }

        /// <summary>
        /// Delete card 
        /// </summary>
        /// <param name="card">Card</param>
        /// <returns>bool</returns>
        public bool Delete(Card card)
        {
            var request = DeleteInternal(card);
            _client.ProcessRequest(request);

            return true;
        }

        public async Task<bool> DeleteAsync(Card card)
        {
            var request = DeleteInternal(card);
            await _client.ProcessRequestAsync(request);

            return true;
        }

        private Request DeleteInternal(Card card)
        {
            card.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            card.CheckRequiredFields();

            return new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + card.ProfileId() + "/cards/" + card.Id()),
                body: card
            );
        }

        /// <summary>
        ///Delete ACHBankAccount 
        /// </summary>
        /// <param name="ACHBankAccount">ACHBankAccount</param>
        /// <returns>bool</returns>
        public bool Delete(AchBankAccounts account)
        {
            var request = DeleteInternal(account);
            _client.ProcessRequest(request);
            return true;
        }

        public async Task<bool> DeleteAsync(AchBankAccounts account)
        {
            var request = DeleteInternal(account);
            await _client.ProcessRequestAsync(request);
            return true;
        }

        private Request DeleteInternal(AchBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();

            return new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/achbankaccounts/" + account.Id())
            );
        }

        /// <summary>
        ///Delete BACSBankAccount 
        /// </summary>
        /// <param name="BACSBankAccount">BACSBankAccount</param>
        /// <returns>bool</returns>
        public bool Delete(BacsBankAccounts account)
        {
            var request = DeleteInternal(account);
            _client.ProcessRequest(request);
            return true;
        }

        public async Task<bool> DeleteAsync(BacsBankAccounts account)
        {
            var request = DeleteInternal(account);
            await _client.ProcessRequestAsync(request);
            return true;
        }

        private Request DeleteInternal(BacsBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();

            return new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/bacsbankaccounts/" + account.Id())
            );
        }

        /// <summary>
        ///Delete EFTBankAccount 
        /// </summary>
        /// <param name="EFTBankAccount">EFTBankAccount</param>
        /// <returns>bool</returns>
        public bool Delete(EftBankAccounts account)
        {
            var request = DeleteInternal(account);
            _client.ProcessRequest(request);
            return true;
        }

        public async Task<bool> DeleteAsync(EftBankAccounts account)
        {
            var request = DeleteInternal(account);
            await _client.ProcessRequestAsync(request);
            return true;
        }

        private Request DeleteInternal(EftBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();

            return new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/eftbankaccounts/" + account.Id())
            );
        }

        /// <summary>
        ///Delete SEPABankAccount 
        /// </summary>
        /// <param name="SEPABankAccount">SEPABankAccount</param>
        /// <returns>bool</returns>
        public bool Delete(SepaBankAccounts account)
        {
            var request = DeleteInternal(account);
            _client.ProcessRequest(request);
            return true;
        }

        public async Task<bool> DeleteAsync(SepaBankAccounts account)
        {
            var request = DeleteInternal(account);
            await _client.ProcessRequestAsync(request);
            return true;
        }

        private Request DeleteInternal(SepaBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();

            return new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/sepabankaccounts/" + account.Id())
            );
        }

        /// <summary>
        ///Delete Mandates 
        /// </summary>
        /// <param name="Mandates">Mandates</param>
        /// <returns>bool</returns>
        public bool Delete(Mandates account)
        {
            var request = DeleteInternal(account);
            _client.ProcessRequest(request);
            return true;
        }

        public async Task<bool> DeleteAsync(Mandates account)
        {
            var request = DeleteInternal(account);
            await _client.ProcessRequestAsync(request);
            return true;
        }

        private Request DeleteInternal(Mandates account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id,
                GlobalConstants.BankAccountId
            });
            return new Request(
                method: RequestType.Delete,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/mandates/" + account.Id())
            );

        }

        /// <summary>
        /// get profile with subcomponents
        /// </summary>
        /// <param name="profile">Profile</param>
        /// <returns>Profile</returns>
        public Profile Get(Profile profile, 
                           bool includeAddresses = false, 
                           bool includeCards = false, 
                           bool includeAchBankAccounts = false,
                           bool includeBacsBankAccounts = false, 
                           bool includeEftBankAccounts = false, 
                           bool includeSepaBankAccounts = false)
        {
            var request = GetInternal(profile, 
                                      includeAddresses, 
                                      includeCards, 
                                      includeAchBankAccounts,
                                      includeBacsBankAccounts, 
                                      includeEftBankAccounts, 
                                      includeSepaBankAccounts);
            dynamic response = _client.ProcessRequest(request);

            return new Profile(response);
        }

        public async Task<Profile> GetAsync(Profile profile,
                                            bool includeAddresses = false,
                                            bool includeCards = false,
                                            bool includeAchBankAccounts = false,
                                            bool includeBacsBankAccounts = false,
                                            bool includeEftBankAccounts = false,
                                            bool includeSepaBankAccounts = false)
        {
            var request = GetInternal(profile,
                                      includeAddresses,
                                      includeCards,
                                      includeAchBankAccounts,
                                      includeBacsBankAccounts,
                                      includeEftBankAccounts,
                                      includeSepaBankAccounts);
            dynamic response = await _client.ProcessRequestAsync(request);

            return new Profile(response);
        }

        private Request GetInternal(Profile profile,
                                    bool includeAddresses = false,
                                    bool includeCards = false,
                                    bool includeAchBankAccounts = false,
                                    bool includeBacsBankAccounts = false,
                                    bool includeEftBankAccounts = false,
                                    bool includeSepaBankAccounts = false)
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
            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + profile.Id()),
                queryString: queryStr
            );
        }

        /// <summary>
        /// Get address 
        /// </summary>
        /// <param name="address">Address</param>
        /// <returns>Address</returns>
        public Address Get(Address address)
        {
            var request = GetInternal(address);
            dynamic response = _client.ProcessRequest(request);

            Address returnVal = new Address(response);
            returnVal.ProfileId(address.ProfileId());
            return returnVal;
        }

        public async Task<Address> GetAsync(Address address)
        {
            var request = GetInternal(address);
            dynamic response = await _client.ProcessRequestAsync(request);

            Address returnVal = new Address(response);
            returnVal.ProfileId(address.ProfileId());
            return returnVal;
        }

        private Request GetInternal(Address address)
        {
            address.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            address.CheckRequiredFields();

            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + address.ProfileId() + "/addresses/" + address.Id()),
                body: address
            );
        }

        /// <summary>
        /// Get card 
        /// </summary>
        /// <param name="card">Card</param>
        /// <returns>Card</returns>
        public Card Get(Card card)
        {
            var request = GetInternal(card);
            dynamic response = _client.ProcessRequest(request);

            Card returnVal = new Card(response);
            returnVal.ProfileId(card.ProfileId());
            return returnVal;
        }

        public async Task<Card> GetAsync(Card card)
        {
            var request = GetInternal(card);
            dynamic response = await _client.ProcessRequestAsync(request);

            Card returnVal = new Card(response);
            returnVal.ProfileId(card.ProfileId());
            return returnVal;
        }

        private Request GetInternal(Card card)
        {
            card.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            card.CheckRequiredFields();

            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + card.ProfileId() + "/cards/" + card.Id())
            );
        }

        /// <summary>
        /// Get ACHBankAccount 
        /// </summary>
        /// <param name="ACHBankAccount">ACHBankAccount</param>
        /// <returns>ACHBankAccount</returns>
        public AchBankAccounts Get(AchBankAccounts account)
        {
            var request = GetInternal(account);
            dynamic response = _client.ProcessRequest(request);

            AchBankAccounts returnVal = new AchBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<AchBankAccounts> GetAsync(AchBankAccounts account)
        {
            var request = GetInternal(account);
            dynamic response = await _client.ProcessRequestAsync(request);

            AchBankAccounts returnVal = new AchBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        private Request GetInternal(AchBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();
            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/achbankaccounts/" + account.Id())
            );
        }

        /// <summary>
        /// Get BACSBankAccount 
        /// </summary>
        /// <param name="BACSBankAccount">BACSBankAccount</param>
        /// <returns>BACSBankAccount</returns>
        public BacsBankAccounts Get(BacsBankAccounts account)
        {
            var request = GetInternal(account);
            dynamic response = _client.ProcessRequest(request);

            BacsBankAccounts returnVal = new BacsBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<BacsBankAccounts> GetAsync(BacsBankAccounts account)
        {
            var request = GetInternal(account);
            dynamic response = await _client.ProcessRequestAsync(request);

            BacsBankAccounts returnVal = new BacsBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        private Request GetInternal(BacsBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.ProfileId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();
            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/bacsbankaccounts/" + account.Id())
            );
        }

        /// <summary>
        /// Get EFTBankAccount 
        /// </summary>
        /// <param name="EFTBankAccount">EFTBankAccount</param>
        /// <returns>EFTBankAccount</returns>
        public EftBankAccounts Get(EftBankAccounts account)
        {
            var request = GetInternal(account);
            dynamic response = _client.ProcessRequest(request);

            EftBankAccounts returnVal = new EftBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<EftBankAccounts> GetAsync(EftBankAccounts account)
        {
            var request = GetInternal(account);
            dynamic response = await _client.ProcessRequestAsync(request);

            EftBankAccounts returnVal = new EftBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        private Request GetInternal(EftBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.BillingAddressId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();
            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/eftbankaccounts/" + account.Id())
            );
        }

        /// <summary>
        /// Get SEPABankAccount 
        /// </summary>
        /// <param name="SEPABankAccount">SEPABankAccount</param>
        /// <returns>SEPABankAccount</returns>
        public SepaBankAccounts Get(SepaBankAccounts account)
        {
            var request = GetInternal(account);
            dynamic response = _client.ProcessRequest(request);

            SepaBankAccounts returnVal = new SepaBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<SepaBankAccounts> GetAsync(SepaBankAccounts account)
        {
            var request = GetInternal(account);
            dynamic response = await _client.ProcessRequestAsync(request);

            SepaBankAccounts returnVal = new SepaBankAccounts(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        private Request GetInternal(SepaBankAccounts account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.BillingAddressId,
                GlobalConstants.Id
            });
            account.CheckRequiredFields();
            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/sepabankaccounts/" + account.Id())
            );
        }

        /// <summary>
        /// Get Mandates 
        /// </summary>
        /// <param name="Mandates">Mandates</param>
        /// <returns>Mandates</returns>
        public Mandates Get(Mandates account)
        {
            var request = GetInternal(account);
            dynamic response = _client.ProcessRequest(request);

            Mandates returnVal = new Mandates(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        public async Task<Mandates> GetAsync(Mandates account)
        {
            var request = GetInternal(account);
            dynamic response = await _client.ProcessRequestAsync(request);

            Mandates returnVal = new Mandates(response);
            returnVal.ProfileId(account.ProfileId());
            return returnVal;
        }

        private Request GetInternal(Mandates account)
        {
            account.SetRequiredFields(new List<string> {
                GlobalConstants.Id,
                GlobalConstants.ProfileId
            });
            account.CheckRequiredFields();
            return new Request(
                method: RequestType.Get,
                uri: PrepareUri("/profiles/" + account.ProfileId() + "/mandates/" + account.Id())
            );
        }

        private string PrepareUri(string path)
        {
            return _uri + path;
        }
    }
}
