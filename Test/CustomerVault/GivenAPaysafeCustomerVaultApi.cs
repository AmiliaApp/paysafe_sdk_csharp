using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Paysafe;
using Paysafe.CardPayments;
using Profile = Paysafe.CustomerVault.Profile;
using Card = Paysafe.CustomerVault.Card;

namespace Tests.CustomerVault
{

 /*
 *Is not covered by tests:
 * -Creating a profile using a single use token -> CustomerVaultService.Create(Profile.Builder()[...].Card().SingleUseToken())
 */
    class GivenAPaysafeCustomerVaultApi
    {

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
        public void When_I_update_a_profile_Then_it_should_return_a_valid_response_sync()
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
        public async Task When_I_update_a_profile_Then_it_should_return_a_valid_response_async()
        {
            var service = SampleFactory.CreateSampleCustomerVaultService();
            var profile = SampleFactory.CreateSampleProfile();
            var newFirstName = "Toto";

            profile = await service.CreateAsync(profile);
            profile.FirstName(newFirstName);

            var updatedProfile = await service.UpdateAsync(profile);

            Assert.AreEqual(updatedProfile.FirstName(), newFirstName);
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
    }
}
