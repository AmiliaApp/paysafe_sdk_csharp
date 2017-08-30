using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Paysafe.CardPayments;
using Paysafe.CustomerVault;
using Profile = Paysafe.CustomerVault.Profile;
using Card = Paysafe.CustomerVault.Card;

namespace Tests.CustomerVault
{

    /*
    *Is not covered by tests:
    * -Creating a profile using a single use token -> CustomerVaultService.Create(Profile.Builder()[...].Card().SingleUseToken())
    * -Managing BACS bank accounts:
    *  -Create a BACS bank account
    *  -Lookup a BACS bank account
    *  -Update a BACS bank account
    *  -Delete a BACS bank account
    * -Managing SEPA bank accounts:
    *  -Create a SEPA bank account
    *  -Lookup a SEPA bank account
    *  -Update a SEPA bank account
    *  -Delete a SEPA bank account
    * -Mandates:
    *  -Create BACS, SEPA mandates
    *  -Lookup a mandate
    *  -Update a mandate
    *  -Delete a mandate
    */
    class GivenAPaysafeCustomerVaultApi
    {
        private CustomerVaultService _service;
        private Profile _profile;


        [SetUp]
        public void Init()
        {
            _service = SampleFactory.CreateSampleCustomerVaultService();
            _profile = SampleFactory.CreateSampleProfile();
        }

      /*
       * Monitor
       */

        [Test]
        public void Card_payment_api_Should_be_up_sync()
        {
            bool status = _service.Monitor();
            Assert.That(status, Is.True);
        }

        [Test]
        public async Task Card_payment_api_Should_be_up_async()
        {
            bool status = await _service.MonitorAsync();
            Assert.That(status, Is.True);
        }

        /*
         * Customer profiles
         */

        [Test]
        public void When_I_create_a_profile_Then_it_should_return_a_valid_response_sync()
        {
            var response = _service.Create(_profile);

            Assert.That(response.Status(), Is.EqualTo("ACTIVE"));
        }

        [Test]
        public async Task When_I_create_a_profile_Then_it_should_return_a_valid_response_async()
        {
            var response = await _service.CreateAsync(_profile);

            Assert.That(response.Status(), Is.EqualTo("ACTIVE"));
        }

        [Test]
        public void When_I_lookup_a_profile_using_a_profile_id_Then_it_should_return_a_valid_profile_sync()
        {
            _profile = _service.Create(_profile);

            var returnedProfile = _service.Get(Profile.Builder()
                                                     .Id(_profile.Id())
                                                     .Build());

            Assert.That(ProfilesAreEquivalent(_profile, returnedProfile));
        }

        [Test]
        public async Task When_I_lookup_a_profile_using_a_profile_id_Then_it_should_return_a_valid_profile_async()
        {
            _profile = await _service.CreateAsync(_profile);

            var returnedProfile = await _service.GetAsync(Profile.Builder()
                                                                .Id(_profile.Id())
                                                                .Build());

            Assert.That(ProfilesAreEquivalent(_profile, returnedProfile));
        }

        [Test]
        public void When_I_update_a_profile_Then_the_profile_should_be_updated_sync()
        {
            var newFirstName = "Toto";

            _profile = _service.Create(_profile);
            _profile.FirstName(newFirstName);

            var updatedProfile = _service.Update(_profile);

            Assert.That(updatedProfile.FirstName(), Is.EqualTo(newFirstName));
        }

        [Test]
        public async Task When_I_update_a_profile_Then_the_profile_should_be_updated_async()
        {
            var newFirstName = "Toto";

            _profile = await _service.CreateAsync(_profile);
            _profile.FirstName(newFirstName);

            var updatedProfile = await _service.UpdateAsync(_profile);

            Assert.AreEqual(updatedProfile.FirstName(), newFirstName);
        }

        [Test]
        public void When_I_delete_a_profile_Then_it_should_return_a_valid_response_sync()
        {
            _profile = _service.Create(_profile);

            bool response = _service.Delete(_profile);

            Assert.That(response, Is.True);
        }

        [Test]
        public async Task When_I_delete_a_profile_Then_it_should_return_a_valid_response_async()
        {
            _profile = await _service.CreateAsync(_profile);

            bool response = await _service.DeleteAsync(_profile);

            Assert.That(response, Is.True);
        }

        [Test]
        public void When_I_delete_a_profile_Then_it_should_be_deleted_sync()
        {
            _profile = _service.Create(_profile);

            _service.Delete(_profile);

            Assert.Throws<Paysafe.Common.EntityNotFoundException>(() => _service.Get(Profile.Builder()
                                                                                           .Id(_profile.Id())
                                                                                           .Build()));
        }

        [Test]
        public async Task When_I_delete_a_profile_Then_it_should_be_deleted_async()
        {
            _profile = await _service.CreateAsync(_profile);

            await _service.DeleteAsync(_profile);

            Assert.ThrowsAsync<Paysafe.Common.EntityNotFoundException>(async () => await _service.GetAsync(Profile.Builder()
                                                                                                                 .Id(_profile.Id())
                                                                                                                 .Build()));
        }

        /*
         * Profile addresses
         */

        [Test]
        public void When_I_create_an_address_Then_it_should_return_a_valid_response_sync()
        {
            _profile = _service.Create(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);

            var response = _service.Create(address);

            Assert.That(response.Status(), Is.EqualTo("ACTIVE"));
        }

        [Test]
        public async Task When_I_create_an_address_Then_it_should_return_a_valid_response_async()
        {
            _profile = await _service.CreateAsync(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);

            var response = await _service.CreateAsync(address);

            Assert.That(response.Status(), Is.EqualTo("ACTIVE"));
        }

        [Test]
        public void When_I_lookup_an_address_Then_it_should_return_a_valid_address_sync()
        {
            _profile = _service.Create(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);
            address = _service.Create(address);

            var returnedAddress = _service.Get(Address.Builder()
                                                     .Id(address.Id())
                                                     .ProfileId(_profile.Id())
                                                     .Build());

            Assert.That(AddressesAreEquivalent(address, returnedAddress));
        }

        [Test]
        public async Task When_I_lookup_an_address_Then_it_should_return_a_valid_address_async()
        {
            _profile = await _service.CreateAsync(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);
            address = await _service.CreateAsync(address);

            var returnedAddress = await _service.GetAsync(Address.Builder()
                                                                .Id(address.Id())
                                                                .ProfileId(_profile.Id())
                                                                .Build());

            Assert.That(AddressesAreEquivalent(address, returnedAddress));
        }

        [Test]
        public void When_I_update_an_address_Then_the_address_should_be_updated_sync()
        {
            _profile = _service.Create(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);
            address = _service.Create(address);
            var newNickname = "New home";

            address.NickName(newNickname);

            var updatedAddress = _service.Update(address);

            Assert.That(updatedAddress.NickName(), Is.EqualTo(newNickname));
        }

        [Test]
        public async Task When_I_update_an_address_Then_the_address_should_be_updated_async()
        {
            _profile = await _service.CreateAsync(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);
            address = await _service.CreateAsync(address);
            var newNickname = "New home";

            address.NickName(newNickname);

            var updatedAddress = await _service.UpdateAsync(address);

            Assert.That(updatedAddress.NickName(), Is.EqualTo(newNickname));
        }

        [Test]
        public void When_I_delete_an_address_Then_it_should_return_a_valid_response_sync()
        {
            _profile = _service.Create(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);
            address = _service.Create(address);

            bool response = _service.Delete(address);

            Assert.That(response, Is.True);
        }

        [Test]
        public async Task When_I_delete_an_address_Then_it_should_return_a_valid_response_async()
        {
            _profile = await _service.CreateAsync(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);
            address = await _service.CreateAsync(address);

            bool response = await _service.DeleteAsync(address);

            Assert.That(response, Is.True);
        }

        [Test]
        public void When_I_delete_an_address_Then_it_should_be_deleted_sync()
        {
            _profile = _service.Create(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);
            address = _service.Create(address);

            _service.Delete(address);

            Assert.Throws<Paysafe.Common.EntityNotFoundException>(() => _service.Get(Address.Builder()
                                                                                           .Id(address.Id())
                                                                                           .ProfileId(_profile.Id())
                                                                                           .Build()));
        }

        [Test]
        public async Task When_I_delete_an_address_Then_it_should_be_deleted_async()
        {
            _profile = await _service.CreateAsync(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);
            address = await _service.CreateAsync(address);

            await _service.DeleteAsync(address);

            Assert.ThrowsAsync<Paysafe.Common.EntityNotFoundException>(async () => await _service.GetAsync(Address.Builder()
                                                                                                                 .Id(address.Id())
                                                                                                                 .ProfileId(_profile.Id())
                                                                                                                 .Build()));
        }

       /*
        * Profile cards
        */

        [Test]
        public void When_I_create_a_card_Then_it_should_return_a_valid_response_sync()
        {
            _profile = _service.Create(_profile);
            var card = SampleFactory.CreateSampleCard(_profile);

            var response = _service.Create(card);

            Assert.That(response.Status(), Is.EqualTo("ACTIVE"));
        }

        [Test]
        public async Task When_I_create_a_card_Then_it_should_return_a_valid_response_async()
        {
            _profile = await _service.CreateAsync(_profile);
            var card = SampleFactory.CreateSampleCard(_profile);

            var response = await _service.CreateAsync(card);

            Assert.That(response.Status(), Is.EqualTo("ACTIVE"));
        }

        [Test]
        public void When_I_lookup_a_card_Then_it_should_return_a_valid_card_sync()
        {
            _profile = _service.Create(_profile);
            var card = SampleFactory.CreateSampleCard(_profile);
            card = _service.Create(card);

            var returnedCard = _service.Get(Card.Builder()
                                               .Id(card.Id())
                                               .ProfileId(_profile.Id())
                                               .Build());

            Assert.That(CardsAreEquivalent(card, returnedCard));
        }

        [Test]
        public async Task When_I_lookup_a_card_Then_it_should_return_a_valid_card_async()
        {
            _profile = await _service.CreateAsync(_profile);
            var card = SampleFactory.CreateSampleCard(_profile);
            card = await _service.CreateAsync(card);

            var returnedCard = await _service.GetAsync(Card.Builder()
                                                          .Id(card.Id())
                                                          .ProfileId(_profile.Id())
                                                          .Build());

            Assert.That(CardsAreEquivalent(card, returnedCard));
        }

        [Test]
        public void When_I_update_a_card_Then_the_address_should_be_updated_sync()
        {
            _profile = _service.Create(_profile);
            var card = SampleFactory.CreateSampleCard(_profile);
            card = _service.Create(card);
            var newNickname = "New card name";

            card.NickName(newNickname);

            var updatedCard = _service.Update(card);

            Assert.That(updatedCard.NickName(), Is.EqualTo(newNickname));
        }

        [Test]
        public async Task When_I_update_a_card_Then_the_address_should_be_updated_async()
        {
            _profile = await _service.CreateAsync(_profile);

            var card = SampleFactory.CreateSampleCard(_profile);
            card = await _service.CreateAsync(card);

            var newNickname = "New card name";

            card.NickName(newNickname);

            var updatedCard = await _service.UpdateAsync(card);

            Assert.That(updatedCard.NickName(), Is.EqualTo(newNickname));
        }

        [Test]
        public void When_I_delete_a_card_Then_it_should_return_a_valid_response_sync()
        {
            _profile = _service.Create(_profile);

            var card = SampleFactory.CreateSampleCard(_profile);
            card = _service.Create(card);

            bool response = _service.Delete(card);

            Assert.That(response, Is.True);
        }

        [Test]
        public async Task When_I_delete_a_card_Then_it_should_return_a_valid_response_async()
        {
            _profile = await _service.CreateAsync(_profile);

            var card = SampleFactory.CreateSampleCard(_profile);
            card = await _service.CreateAsync(card);

            bool response = await _service.DeleteAsync(card);

            Assert.That(response, Is.True);
        }

        [Test]
        public void When_I_delete_a_card_Then_it_should_be_deleted_sync()
        {
            _profile = _service.Create(_profile);

            var card = SampleFactory.CreateSampleCard(_profile);
            card = _service.Create(card);

            _service.Delete(card);

            Assert.Throws<Paysafe.Common.EntityNotFoundException>(() => _service.Get(Card.Builder()
                                                                                        .Id(card.Id())
                                                                                        .ProfileId(_profile.Id())
                                                                                        .Build()));
        }

        [Test]
        public async Task When_I_delete_a_card_Then_it_should_be_deleted_async()
        {
            _profile = await _service.CreateAsync(_profile);

            var card = SampleFactory.CreateSampleCard(_profile);
            card = await _service.CreateAsync(card);

            await _service.DeleteAsync(card);

            Assert.ThrowsAsync<Paysafe.Common.EntityNotFoundException>(async () => await _service.GetAsync(Card.Builder()
                                                                                                         .Id(card.Id())
                                                                                                         .ProfileId(_profile.Id())
                                                                                                         .Build()));
        }

        /*
         * Profile bank accounts
         */

        // Managing ACH bank accounts
        [Test]
        public void When_I_create_an_AHC_bank_account_Then_it_should_return_a_valid_response_sync()
        {
            _profile = _service.Create(_profile);

            var address = SampleFactory.CreateSampleAddress(_profile);
            address = _service.Create(address);

            AchBankAccounts account = SampleFactory.CreatSampleAchBankAccount(_profile, address);

            account = _service.Create(account);

            Assert.That(account.Status(), Is.EqualTo("ACTIVE"));

            _service.Delete(account);
        }

        [Test]
        public async Task When_I_create_an_AHC_bank_account_Then_it_should_return_a_valid_response_async()
        {
            _profile = await _service.CreateAsync(_profile);

            var address = SampleFactory.CreateSampleAddress(_profile);
            address = await _service.CreateAsync(address);

            AchBankAccounts account = SampleFactory.CreatSampleAchBankAccount(_profile, address);

            account = await _service.CreateAsync(account);

            Assert.That(account.Status(), Is.EqualTo("ACTIVE"));

            await _service.DeleteAsync(account);
        }

        [Test]
        public void When_I_lookup_an_AHC_bank_account_Then_it_should_return_a_valid_AHC_bank_account_sync()
        {
            _profile = _service.Create(_profile);

            var address = SampleFactory.CreateSampleAddress(_profile);
            address = _service.Create(address);

            AchBankAccounts account = SampleFactory.CreatSampleAchBankAccount(_profile, address);

            account = _service.Create(account);

            var returnedAccount = _service.Get(AchBankAccounts.Builder()
                .Id(account.Id())
                .ProfileId(_profile.Id())
                .Build());
            
            Assert.That(AchBankAccountsAreEquivalent(account, returnedAccount));

            _service.Delete(account);
        }

        [Test]
        public async Task When_I_lookup_an_AHC_bank_account_Then_it_should_return_a_valid_AHC_bank_account_async()
        {
            _profile = await _service.CreateAsync(_profile);

            var address = SampleFactory.CreateSampleAddress(_profile);
            address = await _service.CreateAsync(address);

            AchBankAccounts account = SampleFactory.CreatSampleAchBankAccount(_profile, address);
            account = await _service.CreateAsync(account);

            var returnedAccount = await _service.GetAsync(AchBankAccounts.Builder()
                                                                        .Id(account.Id())
                                                                        .ProfileId(_profile.Id())
                                                                        .Build());

            Assert.That(AchBankAccountsAreEquivalent(account, returnedAccount));

            await _service.DeleteAsync(account);
        }

        [Test]
        public void When_I_update_an_AHC_bank_account_Then_it_should_be_updated_sync()
        {
            _profile = _service.Create(_profile);

            var address = SampleFactory.CreateSampleAddress(_profile);
            address = _service.Create(address);

            AchBankAccounts account = SampleFactory.CreatSampleAchBankAccount(_profile, address);
            account = _service.Create(account);

            var newAccountHolderName = "Foo";

            account.AccountHolderName(newAccountHolderName);

            _service.Update(account);

            var returnedAccount = _service.Get(AchBankAccounts.Builder()
                                                             .Id(account.Id())
                                                             .ProfileId(_profile.Id())
                                                             .Build());

            Assert.That(returnedAccount.AccountHolderName(), Is.EqualTo(newAccountHolderName));

            _service.Delete(account);
        }

        [Test]
        public async Task When_I_update_an_AHC_bank_account_Then_it_should_be_updated_async()
        {
            _profile = await _service.CreateAsync(_profile);

            var address = SampleFactory.CreateSampleAddress(_profile);
            address = await _service.CreateAsync(address);

            AchBankAccounts account = SampleFactory.CreatSampleAchBankAccount(_profile, address);
            account = await _service.CreateAsync(account);

            var newAccountHolderName = "Foo";

            account.AccountHolderName(newAccountHolderName);

            await _service.UpdateAsync(account);

            var returnedAccount = await _service.GetAsync(AchBankAccounts.Builder()
                                                                        .Id(account.Id())
                                                                        .ProfileId(_profile.Id())
                                                                        .Build());

            Assert.That(returnedAccount.AccountHolderName(), Is.EqualTo(newAccountHolderName));

            await _service.DeleteAsync(account);
        }

        [Test]
        public void When_I_delete_an_AHC_bank_account_Then_it_should_be_deleted_sync()
        {
            _profile = _service.Create(_profile);

            var address = SampleFactory.CreateSampleAddress(_profile);
            address = _service.Create(address);

            AchBankAccounts account = SampleFactory.CreatSampleAchBankAccount(_profile, address);
            account = _service.Create(account);

            var response = _service.Delete(account);

            Assert.That(response, Is.True);
            Assert.Throws<Paysafe.Common.EntityNotFoundException>(() => _service.Get(AchBankAccounts.Builder()
                                                                               .Id(account.Id())
                                                                               .ProfileId(_profile.Id())
                                                                               .Build()));
        }

        [Test]
        public async Task When_I_delete_an_AHC_bank_account_Then_it_should_be_deleted_async()
        {
            _profile = await _service.CreateAsync(_profile);

            var address = SampleFactory.CreateSampleAddress(_profile);
            address = await _service.CreateAsync(address);

            AchBankAccounts account = SampleFactory.CreatSampleAchBankAccount(_profile, address);
            account = await _service.CreateAsync(account);

            var response = await _service.DeleteAsync(account);

            Assert.That(response, Is.True);
            Assert.ThrowsAsync<Paysafe.Common.EntityNotFoundException>(async () => await _service.GetAsync(AchBankAccounts.Builder()
                                                                                                                         .Id(account.Id())
                                                                                                                         .ProfileId(_profile.Id())
                                                                                                                         .Build()));
        }

        // Managing EFT bank accounts
        [Test]
        public void When_I_create_an_EFT_bank_account_Then_it_should_return_a_valid_response_sync()
        {
            _profile = _service.Create(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);
            address = _service.Create(address);
            EftBankAccounts account = SampleFactory.CreatSampleEftBankAccount(_profile, address);

            account = _service.Create(account);

            Assert.That(account.Status(), Is.EqualTo("ACTIVE"));

            _service.Delete(account);
        }

        [Test]
        public async Task When_I_create_an_EFT_bank_account_Then_it_should_return_a_valid_response_async()
        {
            _profile = await _service.CreateAsync(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);
            address = await _service.CreateAsync(address);
            EftBankAccounts account = SampleFactory.CreatSampleEftBankAccount(_profile, address);

            account = await _service.CreateAsync(account);

            Assert.That(account.Status(), Is.EqualTo("ACTIVE"));

            await _service.DeleteAsync(account);
        }

        //Failed once on parsing
        [Test]
        public void When_I_lookup_an_EFT_bank_account_Then_it_should_return_a_valid_EFT_bank_account_sync()
        {
            _profile = _service.Create(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);
            address = _service.Create(address);
            EftBankAccounts account = SampleFactory.CreatSampleEftBankAccount(_profile, address);
            account = _service.Create(account);

            var returnedAccount = _service.Get(EftBankAccounts.Builder()
                                                             .Id(account.Id())
                                                             .ProfileId(_profile.Id())
                                                             .BillingAddressId(address.Id())
                                                             .Build());

            Assert.That(EftBankAccountsAreEquivalent(account, returnedAccount));

            _service.Delete(account);
        }

        [Test]
        public async Task When_I_lookup_an_EFT_bank_account_Then_it_should_return_a_valid_EFT_bank_account_async()
        {
            _profile = await _service.CreateAsync(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);
            address = await _service.CreateAsync(address);
            EftBankAccounts account = SampleFactory.CreatSampleEftBankAccount(_profile, address);
            account = await _service.CreateAsync(account);

            var returnedAccount = await _service.GetAsync(EftBankAccounts.Builder()
                                                                        .Id(account.Id())
                                                                        .ProfileId(_profile.Id())
                                                                        .BillingAddressId(address.Id())
                                                                        .Build());

            Assert.That(EftBankAccountsAreEquivalent(account, returnedAccount));

            await _service.DeleteAsync(account);
        }

        [Test]
        public void When_I_update_an_EFT_bank_account_Then_it_should_be_updated_sync()
        {
            _profile = _service.Create(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);
            address = _service.Create(address);
            EftBankAccounts account = SampleFactory.CreatSampleEftBankAccount(_profile, address);
            account = _service.Create(account);

            var newAccountHolderName = "Foo";

            account.AccountHolderName(newAccountHolderName);

            _service.Update(account);

            var returnedAccount = _service.Get(EftBankAccounts.Builder()
                                                             .Id(account.Id())
                                                             .ProfileId(_profile.Id())
                                                             .BillingAddressId(address.Id())
                                                             .Build());

            Assert.That(returnedAccount.AccountHolderName(), Is.EqualTo(newAccountHolderName));

            _service.Delete(account);
        }

        [Test]
        public async Task When_I_update_an_EFT_bank_account_Then_it_should_be_updated_async()
        {
            _profile = await _service.CreateAsync(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);
            address = await _service.CreateAsync(address);
            EftBankAccounts account = SampleFactory.CreatSampleEftBankAccount(_profile, address);
            account = await _service.CreateAsync(account);

            var newAccountHolderName = "Foo";

            account.AccountHolderName(newAccountHolderName);

            await _service.UpdateAsync(account);

            var returnedAccount = await _service.GetAsync(EftBankAccounts.Builder()
                                                                        .Id(account.Id())
                                                                        .ProfileId(_profile.Id())
                                                                        .BillingAddressId(address.Id())
                                                                        .Build());

            Assert.That(returnedAccount.AccountHolderName(), Is.EqualTo(newAccountHolderName));

            await _service.DeleteAsync(account);
        }

        [Test]
        public void When_I_delete_an_EFT_bank_account_Then_it_should_be_deleted_sync()
        {
            _profile = _service.Create(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);
            address = _service.Create(address);
            EftBankAccounts account = SampleFactory.CreatSampleEftBankAccount(_profile, address);
            account = _service.Create(account);

            var response = _service.Delete(account);

            Assert.That(response, Is.True);
            Assert.Throws<Paysafe.Common.EntityNotFoundException>(() => _service.Get(EftBankAccounts.Builder()
                .Id(account.Id())
                .ProfileId(_profile.Id())
                .BillingAddressId(address.Id())
                .Build()));
        }

        [Test]
        public async Task When_I_delete_an_EFT_bank_account_Then_it_should_be_deleted_async()
        {
            _profile = await _service.CreateAsync(_profile);
            var address = SampleFactory.CreateSampleAddress(_profile);
            address = await _service.CreateAsync(address);
            EftBankAccounts account = SampleFactory.CreatSampleEftBankAccount(_profile, address);
            account = await _service.CreateAsync(account);

            var response = await _service.DeleteAsync(account);

            Assert.That(response, Is.True);
            Assert.ThrowsAsync<Paysafe.Common.EntityNotFoundException>(async () => await _service.GetAsync(EftBankAccounts.Builder()
                .Id(account.Id())
                .ProfileId(_profile.Id())
                .BillingAddressId(address.Id())
                .Build()));
        }

        /*
         * Process a Payment Using a Payment Token
         */

        [Test]
        public void When_I_process_a_payment_using_a_payment_token_Then_it_should_return_a_valid_response_sync()
        {
            var cardService = SampleFactory.CreateSampleCardPaymentService();
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = vaultService.Create(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = vaultService.Create(address);
            var card = SampleFactory.CreateSampleCard(profile, address);
            card = vaultService.Create(card);

            var response = cardService.Authorize(Authorization.Builder()
                                                              .MerchantRefNum(Guid.NewGuid().ToString())
                                                              .Amount(555)
                                                              .SettleWithAuth(false)
                                                              .Card()
                                                                  .PaymentToken(card.PaymentToken())
                                                                  .Done()
                                                              .Build());

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public async Task When_I_process_a_payment_using_a_payment_token_Then_it_should_return_a_valid_response_async()
        {
            var cardService = SampleFactory.CreateSampleCardPaymentService();
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await vaultService.CreateAsync(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = await vaultService.CreateAsync(address);
            var card = SampleFactory.CreateSampleCard(profile, address);
            card = await vaultService.CreateAsync(card);

            var response = await cardService.AuthorizeAsync(Authorization.Builder()
                                                                         .MerchantRefNum(Guid.NewGuid().ToString())
                                                                         .Amount(555)
                                                                         .SettleWithAuth(false)
                                                                         .Card()
                                                                              .PaymentToken(card.PaymentToken())
                                                                              .Done()
                                                                         .Build());

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public void When_I_verify_a_card_using_a_payment_token_Then_it_should_return_a_valid_response_sync()
        {
            var cardService = SampleFactory.CreateSampleCardPaymentService();
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = vaultService.Create(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = vaultService.Create(address);
            var card = SampleFactory.CreateSampleCard(profile, address);
            card = vaultService.Create(card);

            var response = cardService.Verify(Verification.Builder()
                                                          .MerchantRefNum(Guid.NewGuid().ToString())
                                                          .Card()
                                                              .PaymentToken(card.PaymentToken())
                                                              .Done()
                                                          .Build());

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        [Test]
        public async Task When_I_verify_a_card_using_a_payment_token_Then_it_should_return_a_valid_response_async()
        {
            var cardService = SampleFactory.CreateSampleCardPaymentService();
            var vaultService = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await vaultService.CreateAsync(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = await vaultService.CreateAsync(address);
            var card = SampleFactory.CreateSampleCard(profile, address);
            card = await vaultService.CreateAsync(card);

            var response = await cardService.VerifyAsync(Verification.Builder()
                                                          .MerchantRefNum(Guid.NewGuid().ToString())
                                                          .Card()
                                                              .PaymentToken(card.PaymentToken())
                                                              .Done()
                                                          .Build());

            Assert.That(response.Status(), Is.EqualTo("COMPLETED"));
        }

        /*
        * Helpers
        */

        private bool ProfilesAreEquivalent(Profile profile1, Profile profile2)
        {
            if (!profile1.Id().Equals(profile2.Id())
                || !profile1.Phone().Equals(profile2.Phone())
                || !profile1.FirstName().Equals(profile2.FirstName())
                || !profile1.LastName().Equals(profile2.LastName())
                || !profile1.Email().Equals(profile2.Email()))
            {
                return false;
            }

            return true;
        }
        private bool AddressesAreEquivalent(Address add1, Address add2)
        {
            if (!add1.Id().Equals(add2.Id())
                || !add1.NickName().Equals(add2.NickName())
                || !add1.Street().Equals(add2.Street())
                || !add1.Street2().Equals(add2.Street2())
                || !add1.City().Equals(add2.City())
                || !add1.Country().Equals(add2.Country())
                || !add1.State().Equals(add2.State())
                || !add1.Zip().Equals(add2.Zip())
                || !add1.RecipientName().Equals(add2.RecipientName())
                || !add1.Phone().Equals(add2.Phone()))
            {
                return false;
            }

            return true;
        }

        private bool CardsAreEquivalent(Card card1, Card card2)
        {
            if (!card1.Id().Equals(card2.Id())
                || !card1.LastDigits().Equals(card2.LastDigits())
                || !card1.CardExpiry().Month().Equals(card2.CardExpiry().Month())
                || !card1.CardExpiry().Year().Equals(card2.CardExpiry().Year()))
            {
                return false;
            }

            return true;
        }

        private bool AchBankAccountsAreEquivalent(AchBankAccounts acc1, AchBankAccounts acc2)
        {
            if (!acc1.Id().Equals(acc2.Id())
                || !acc1.NickName().Equals(acc2.NickName())
                || !acc1.Status().Equals(acc2.Status())
                || !acc1.AccountHolderName().Equals(acc2.AccountHolderName())
                || !acc1.BillingAddressId().Equals(acc2.BillingAddressId())
                || !acc1.AccountType().Equals(acc2.AccountType())
                || !acc1.LastDigits().Equals(acc2.LastDigits())
                || !acc1.ProfileId().Equals(acc2.ProfileId()))
            {
                return false;
            }

            return true;
        }

        private bool EftBankAccountsAreEquivalent(EftBankAccounts acc1, EftBankAccounts acc2)
        {
            if (!acc1.Id().Equals(acc2.Id())
                || !acc1.NickName().Equals(acc2.NickName())
                || !acc1.Status().Equals(acc2.Status())
                || !acc1.AccountHolderName().Equals(acc2.AccountHolderName())
                || !acc1.BillingAddressId().Equals(acc2.BillingAddressId())
                || !acc1.LastDigits().Equals(acc2.LastDigits())
                || !acc1.ProfileId().Equals(acc2.ProfileId()))
            {
                return false;
            }

            return true;
        }
    }
}
