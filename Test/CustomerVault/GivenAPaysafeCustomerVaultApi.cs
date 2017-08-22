using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Paysafe;
using Paysafe.CardPayments;
using Paysafe.CustomerVault;
using Profile = Paysafe.CustomerVault.Profile;
using Card = Paysafe.CustomerVault.Card;
using BillingAddress = Paysafe.CustomerVault.BillingAddress;

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

        /*
         * Customer profiles
         */

        [Test]
        public void When_I_create_a_profile_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();

            var response = service.Create(profile);

            Assert.IsTrue(response.Status() == "ACTIVE");
        }

        [Test]
        public async Task When_I_create_a_profile_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();

            var response = await service.CreateAsync(profile);

            Assert.IsTrue(response.Status() == "ACTIVE");
        }

        [Test]
        public void When_I_lookup_a_profile_using_a_profile_id_Then_it_should_return_a_valid_profile_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();

            profile = service.Create(profile);

            var returnedProfile = service.Get(Profile.Builder()
                                                     .Id(profile.Id())
                                                     .Build());

            Assert.IsTrue(ProfilesAreEquivalent(profile, returnedProfile));
        }

        [Test]
        public async Task When_I_lookup_a_profile_using_a_profile_id_Then_it_should_return_a_valid_profile_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();

            profile = await service.CreateAsync(profile);

            var returnedProfile = await service.GetAsync(Profile.Builder()
                                                                .Id(profile.Id())
                                                                .Build());

            Assert.IsTrue(ProfilesAreEquivalent(profile, returnedProfile));
        }

        [Test]
        public void When_I_update_a_profile_Then_the_profile_should_be_updated_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            var newFirstName = "Toto";

            profile = service.Create(profile);
            profile.FirstName(newFirstName);

            var updatedProfile = service.Update(profile);

            Assert.AreEqual(updatedProfile.FirstName(), newFirstName);
        }

        [Test]
        public async Task When_I_update_a_profile_Then_the_profile_should_be_updated_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            var newFirstName = "Toto";

            profile = await service.CreateAsync(profile);
            profile.FirstName(newFirstName);

            var updatedProfile = await service.UpdateAsync(profile);

            Assert.AreEqual(updatedProfile.FirstName(), newFirstName);
        }

        [Test]
        public void When_I_delete_a_profile_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();

            profile = service.Create(profile);

            bool response = service.Delete(profile);

            Assert.IsTrue(response);
        }

        [Test]
        public async Task When_I_delete_a_profile_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();

            profile = await service.CreateAsync(profile);

            bool response = await service.DeleteAsync(profile);

            Assert.IsTrue(response);
        }

        [Test]
        public void When_I_delete_a_profile_Then_it_should_be_deleted_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();

            profile = service.Create(profile);

            service.Delete(profile);

            Assert.Throws<Paysafe.Common.EntityNotFoundException>(() => service.Get(Profile.Builder()
                                                                                           .Id(profile.Id())
                                                                                           .Build()));
        }

        [Test]
        public async Task When_I_delete_a_profile_Then_it_should_be_deleted_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();

            profile = await service.CreateAsync(profile);

            await service.DeleteAsync(profile);

            Assert.ThrowsAsync<Paysafe.Common.EntityNotFoundException>(async () => await service.GetAsync(Profile.Builder()
                                                                                                                 .Id(profile.Id())
                                                                                                                 .Build()));
        }

        /*
         * Profile addresses
         */

        [Test]
        public void When_I_create_an_address_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var address = SampleFactory.CreateSampleAddress(profile);

            var response = service.Create(address);

            Assert.IsTrue(response.Status() == "ACTIVE");
        }

        [Test]
        public async Task When_I_create_an_address_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var address = SampleFactory.CreateSampleAddress(profile);

            var response = await service.CreateAsync(address);

            Assert.IsTrue(response.Status() == "ACTIVE");
        }

        [Test]
        public void When_I_lookup_an_address_Then_it_should_return_a_valid_address_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = service.Create(address);

            var returnedAddress = service.Get(Address.Builder()
                                                     .Id(address.Id())
                                                     .ProfileId(profile.Id())
                                                     .Build());

            Assert.IsTrue(AddressesAreEquivalent(address, returnedAddress));
        }

        [Test]
        public async Task When_I_lookup_an_address_Then_it_should_return_a_valid_address_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = await service.CreateAsync(address);

            var returnedAddress = await service.GetAsync(Address.Builder()
                                                                .Id(address.Id())
                                                                .ProfileId(profile.Id())
                                                                .Build());

            Assert.IsTrue(AddressesAreEquivalent(address, returnedAddress));
        }

        [Test]
        public void When_I_update_an_address_Then_the_address_should_be_updated_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = service.Create(address);
            var newNickname = "New home";

            address.NickName(newNickname);

            var updatedAddress = service.Update(address);

            Assert.AreEqual(updatedAddress.NickName(), newNickname);
        }

        [Test]
        public async Task When_I_update_an_address_Then_the_address_should_be_updated_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = await service.CreateAsync(address);
            var newNickname = "New home";

            address.NickName(newNickname);

            var updatedAddress = await service.UpdateAsync(address);

            Assert.AreEqual(updatedAddress.NickName(), newNickname);
        }

        [Test]
        public void When_I_delete_an_address_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = service.Create(address);

            bool response = service.Delete(address);

            Assert.IsTrue(response);
        }

        [Test]
        public async Task When_I_delete_an_address_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = await service.CreateAsync(address);

            bool response = await service.DeleteAsync(address);

            Assert.IsTrue(response);
        }

        [Test]
        public void When_I_delete_an_address_Then_it_should_be_deleted_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = service.Create(address);

            service.Delete(address);

            Assert.Throws<Paysafe.Common.EntityNotFoundException>(() => service.Get(Address.Builder()
                                                                                           .Id(address.Id())
                                                                                           .ProfileId(profile.Id())
                                                                                           .Build()));
        }

        [Test]
        public async Task When_I_delete_an_address_Then_it_should_be_deleted_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = await service.CreateAsync(address);

            await service.DeleteAsync(address);

            Assert.ThrowsAsync<Paysafe.Common.EntityNotFoundException>(async () => await service.GetAsync(Address.Builder()
                                                                                                                 .Id(address.Id())
                                                                                                                 .ProfileId(profile.Id())
                                                                                                                 .Build()));
        }

        /*
        * Profile cards
        */

        [Test]
        public void When_I_create_a_card_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var card = SampleFactory.CreateSampleCard(profile);

            var response = service.Create(card);

            Assert.IsTrue(response.Status() == "ACTIVE");
        }

        [Test]
        public async Task When_I_create_a_card_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var card = SampleFactory.CreateSampleCard(profile);

            var response = await service.CreateAsync(card);

            Assert.IsTrue(response.Status() == "ACTIVE");
        }

        [Test]
        public void When_I_lookup_a_card_Then_it_should_return_a_valid_card_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var card = SampleFactory.CreateSampleCard(profile);
            card = service.Create(card);

            var returnedCard = service.Get(Card.Builder()
                                               .Id(card.Id())
                                               .ProfileId(profile.Id())
                                               .Build());

            Assert.IsTrue(CardsAreEquivalent(card, returnedCard));
        }

        [Test]
        public async Task When_I_lookup_a_card_Then_it_should_return_a_valid_card_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var card = SampleFactory.CreateSampleCard(profile);
            card = await service.CreateAsync(card);

            var returnedCard = await service.GetAsync(Card.Builder()
                                                          .Id(card.Id())
                                                          .ProfileId(profile.Id())
                                                          .Build());

            Assert.IsTrue(CardsAreEquivalent(card, returnedCard));
        }

        [Test]
        public void When_I_update_a_card_Then_the_address_should_be_updated_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var card = SampleFactory.CreateSampleCard(profile);
            card = service.Create(card);
            var newNickname = "New card name";

            card.NickName(newNickname);

            var updatedCard = service.Update(card);

            Assert.AreEqual(updatedCard.NickName(), newNickname);
        }

        [Test]
        public async Task When_I_update_a_card_Then_the_address_should_be_updated_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var card = SampleFactory.CreateSampleCard(profile);
            card = await service.CreateAsync(card);
            var newNickname = "New card name";

            card.NickName(newNickname);

            var updatedCard = await service.UpdateAsync(card);

            Assert.AreEqual(updatedCard.NickName(), newNickname);
        }

        [Test]
        public void When_I_delete_a_card_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var card = SampleFactory.CreateSampleCard(profile);
            card = service.Create(card);

            bool response = service.Delete(card);

            Assert.IsTrue(response);
        }

        [Test]
        public async Task When_I_delete_a_card_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var card = SampleFactory.CreateSampleCard(profile);
            card = await service.CreateAsync(card);

            bool response = await service.DeleteAsync(card);

            Assert.IsTrue(response);
        }

        [Test]
        public void When_I_delete_a_card_Then_it_should_be_deleted_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var card = SampleFactory.CreateSampleCard(profile);
            card = service.Create(card);

            service.Delete(card);

            Assert.Throws<Paysafe.Common.EntityNotFoundException>(() => service.Get(Card.Builder()
                                                                                        .Id(card.Id())
                                                                                        .ProfileId(profile.Id())
                                                                                        .Build()));
        }

        [Test]
        public async Task When_I_delete_a_card_Then_it_should_be_deleted_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var card = SampleFactory.CreateSampleCard(profile);
            card = await service.CreateAsync(card);

            await service.DeleteAsync(card);

            Assert.ThrowsAsync<Paysafe.Common.EntityNotFoundException>(async () => await service.GetAsync(Card.Builder()
                                                                                                         .Id(card.Id())
                                                                                                         .ProfileId(profile.Id())
                                                                                                         .Build()));
        }

        /*
         * Profile bank accounts
         */


        // Managing ACH bank accounts
        [Test]
        public void When_I_create_an_AHC_bank_account_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = service.Create(address);
            AchBankAccounts account = SampleFactory.CreatSampleAchBankAccount(profile, address);

            account = service.Create(account);

            Assert.IsTrue(account.Status() == "ACTIVE");

            service.Delete(account);
        }

        [Test]
        public async Task When_I_create_an_AHC_bank_account_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = await service.CreateAsync(address);
            AchBankAccounts account = SampleFactory.CreatSampleAchBankAccount(profile, address);

            account = await service.CreateAsync(account);

            Assert.IsTrue(account.Status() == "ACTIVE");

            await service.DeleteAsync(account);
        }

        [Test]
        public void When_I_lookup_an_AHC_bank_account_Then_it_should_return_a_valid_AHC_bank_account_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = service.Create(address);
            AchBankAccounts account = SampleFactory.CreatSampleAchBankAccount(profile, address);

            account = service.Create(account);

            var returnedAccount = service.Get(AchBankAccounts.Builder()
                .Id(account.Id())
                .ProfileId(profile.Id())
                .Build());
            
            Assert.IsTrue(AchBankAccountsAreEquivalent(account, returnedAccount));

            service.Delete(account);
        }

        [Test]
        public async Task When_I_lookup_an_AHC_bank_account_Then_it_should_return_a_valid_AHC_bank_account_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = await service.CreateAsync(address);
            AchBankAccounts account = SampleFactory.CreatSampleAchBankAccount(profile, address);
            account = await service.CreateAsync(account);

            var returnedAccount = await service.GetAsync(AchBankAccounts.Builder()
                                                                        .Id(account.Id())
                                                                        .ProfileId(profile.Id())
                                                                        .Build());

            Assert.IsTrue(AchBankAccountsAreEquivalent(account, returnedAccount));

            await service.DeleteAsync(account);
        }

        [Test]
        public void When_I_update_an_AHC_bank_account_Then_it_should_be_updated_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = service.Create(address);
            AchBankAccounts account = SampleFactory.CreatSampleAchBankAccount(profile, address);
            account = service.Create(account);

            var newAccountHolderName = "Foo";

            account.AccountHolderName(newAccountHolderName);

            service.Update(account);

            var returnedAccount = service.Get(AchBankAccounts.Builder()
                                                             .Id(account.Id())
                                                             .ProfileId(profile.Id())
                                                             .Build());

            Assert.AreEqual(returnedAccount.AccountHolderName(), newAccountHolderName);

            service.Delete(account);
        }

        [Test]
        public async Task When_I_update_an_AHC_bank_account_Then_it_should_be_updated_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = await service.CreateAsync(address);
            AchBankAccounts account = SampleFactory.CreatSampleAchBankAccount(profile, address);
            account = await service.CreateAsync(account);

            var newAccountHolderName = "Foo";

            account.AccountHolderName(newAccountHolderName);

            await service.UpdateAsync(account);

            var returnedAccount = await service.GetAsync(AchBankAccounts.Builder()
                                                                        .Id(account.Id())
                                                                        .ProfileId(profile.Id())
                                                                        .Build());

            Assert.AreEqual(returnedAccount.AccountHolderName(), newAccountHolderName);

            await service.DeleteAsync(account);
        }

        [Test]
        public void When_I_delete_an_AHC_bank_account_Then_it_should_be_deleted_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = service.Create(address);
            AchBankAccounts account = SampleFactory.CreatSampleAchBankAccount(profile, address);
            account = service.Create(account);

            Assert.IsTrue(service.Delete(account));
            Assert.Throws<Paysafe.Common.EntityNotFoundException>(() => service.Get(AchBankAccounts.Builder()
                                                                               .Id(account.Id())
                                                                               .ProfileId(profile.Id())
                                                                               .Build()));
        }

        [Test]
        public async Task When_I_delete_an_AHC_bank_account_Then_it_should_be_deleted_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = await service.CreateAsync(address);
            AchBankAccounts account = SampleFactory.CreatSampleAchBankAccount(profile, address);
            account = await service.CreateAsync(account);

            Assert.IsTrue(await service.DeleteAsync(account));
            Assert.ThrowsAsync<Paysafe.Common.EntityNotFoundException>(async () => await service.GetAsync(AchBankAccounts.Builder()
                                                                                                                         .Id(account.Id())
                                                                                                                         .ProfileId(profile.Id())
                                                                                                                         .Build()));
        }

        // Managing EFT bank accounts
        [Test]
        public void When_I_create_an_EFT_bank_account_Then_it_should_return_a_valid_response_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = service.Create(address);
            EftBankAccounts account = SampleFactory.CreatSampleEftBankAccount(profile, address);

            account = service.Create(account);

            Assert.IsTrue(account.Status() == "ACTIVE");

            service.Delete(account);
        }

        [Test]
        public async Task When_I_create_an_EFT_bank_account_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = await service.CreateAsync(address);
            EftBankAccounts account = SampleFactory.CreatSampleEftBankAccount(profile, address);

            account = await service.CreateAsync(account);

            Assert.IsTrue(account.Status() == "ACTIVE");

            await service.DeleteAsync(account);
        }

        [Test]
        public void When_I_lookup_an_EFT_bank_account_Then_it_should_return_a_valid_EFT_bank_account_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = service.Create(address);
            EftBankAccounts account = SampleFactory.CreatSampleEftBankAccount(profile, address);
            account = service.Create(account);

            var returnedAccount = service.Get(EftBankAccounts.Builder()
                                                             .Id(account.Id())
                                                             .ProfileId(profile.Id())
                                                             .BillingAddressId(address.Id())
                                                             .Build());

            Assert.IsTrue(EftBankAccountsAreEquivalent(account, returnedAccount));

            service.Delete(account);
        }

        [Test]
        public async Task When_I_lookup_an_EFT_bank_account_Then_it_should_return_a_valid_EFT_bank_account_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = await service.CreateAsync(address);
            EftBankAccounts account = SampleFactory.CreatSampleEftBankAccount(profile, address);
            account = await service.CreateAsync(account);

            var returnedAccount = await service.GetAsync(EftBankAccounts.Builder()
                                                                        .Id(account.Id())
                                                                        .ProfileId(profile.Id())
                                                                        .BillingAddressId(address.Id())
                                                                        .Build());

            Assert.IsTrue(EftBankAccountsAreEquivalent(account, returnedAccount));

            await service.DeleteAsync(account);
        }

        [Test]
        public void When_I_update_an_EFT_bank_account_Then_it_should_be_updated_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = service.Create(address);
            EftBankAccounts account = SampleFactory.CreatSampleEftBankAccount(profile, address);
            account = service.Create(account);

            var newAccountHolderName = "Foo";

            account.AccountHolderName(newAccountHolderName);

            service.Update(account);

            var returnedAccount = service.Get(EftBankAccounts.Builder()
                                                             .Id(account.Id())
                                                             .ProfileId(profile.Id())
                                                             .BillingAddressId(address.Id())
                                                             .Build());

            Assert.AreEqual(returnedAccount.AccountHolderName(), newAccountHolderName);

            service.Delete(account);
        }

        [Test]
        public async Task When_I_update_an_EFT_bank_account_Then_it_should_be_updated_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = await service.CreateAsync(address);
            EftBankAccounts account = SampleFactory.CreatSampleEftBankAccount(profile, address);
            account = await service.CreateAsync(account);

            var newAccountHolderName = "Foo";

            account.AccountHolderName(newAccountHolderName);

            await service.UpdateAsync(account);

            var returnedAccount = await service.GetAsync(EftBankAccounts.Builder()
                                                                        .Id(account.Id())
                                                                        .ProfileId(profile.Id())
                                                                        .BillingAddressId(address.Id())
                                                                        .Build());

            Assert.AreEqual(returnedAccount.AccountHolderName(), newAccountHolderName);

            await service.DeleteAsync(account);
        }

        [Test]
        public void When_I_delete_an_EFT_bank_account_Then_it_should_be_deleted_sync()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = service.Create(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = service.Create(address);
            EftBankAccounts account = SampleFactory.CreatSampleEftBankAccount(profile, address);
            account = service.Create(account);

            Assert.IsTrue(service.Delete(account));
            Assert.Throws<Paysafe.Common.EntityNotFoundException>(() => service.Get(EftBankAccounts.Builder()
                .Id(account.Id())
                .ProfileId(profile.Id())
                .BillingAddressId(address.Id())
                .Build()));
        }

        [Test]
        public async Task When_I_delete_an_EFT_bank_account_Then_it_should_be_deleted_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            profile = await service.CreateAsync(profile);
            var address = SampleFactory.CreateSampleAddress(profile);
            address = await service.CreateAsync(address);
            EftBankAccounts account = SampleFactory.CreatSampleEftBankAccount(profile, address);
            account = await service.CreateAsync(account);

            Assert.IsTrue(await service.DeleteAsync(account));
            Assert.ThrowsAsync<Paysafe.Common.EntityNotFoundException>(async () => await service.GetAsync(EftBankAccounts.Builder()
                .Id(account.Id())
                .ProfileId(profile.Id())
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

            Assert.AreEqual(response.Status(), "COMPLETED");
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

            Assert.AreEqual(response.Status(), "COMPLETED");
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

            Assert.AreEqual(response.Status(), "COMPLETED");
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

            Assert.AreEqual(response.Status(), "COMPLETED");
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
