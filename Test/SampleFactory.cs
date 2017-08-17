﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Paysafe;
using Paysafe.CardPayments;
using Paysafe.CustomerVault;
using Authorization = Paysafe.CardPayments.Authorization;
using Profile = Paysafe.CustomerVault.Profile;
using Card = Paysafe.CustomerVault.Card;
using Environment = Paysafe.Environment;

namespace Tests
{
    class SampleFactory
    {
        private static readonly Dictionary<string, int> ExceptionType
            = new Dictionary<string, int>()
            {
                {"noException", 6666},
                {"requestDeclined", 4},
                {"apiException", 6}
            };

        private static readonly Dictionary<Type, Func<string, object>> Funcs;
        static SampleFactory()
        {
            Funcs = new Dictionary<Type, Func<string, object>>
            {
                {typeof (Authorization), CreateSampleCustomAuthorization},
            };
        }

        public static Authorization CreateSampleCustomAuthorization(string type)
        {
            return Authorization.Builder()
                .MerchantRefNum(Guid.NewGuid().ToString())
                .Amount(ExceptionType[type])
                .Card()
                    .CardNum("4111111111111111")
                    .Cvv("123")
                        .CardExpiry()
                        .Month(06)
                        .Year(DateTime.Now.AddYears(1).Year)
                        .Done()
                    .Done()
                .BillingDetails()
                    .Zip("M5H 2N2")
                    .Done()
                .Build();
        }

        public static Authorization CreateSampleIncompleteAuthorization()
        {
            return Authorization.Builder()
                .MerchantRefNum(Guid.NewGuid().ToString())
                .Amount(6666)
                .Card()
                    .CardNum("4111111111111111")
                    .Cvv("123")
                        .CardExpiry()
                        .Month(06)
                        .Year(DateTime.Now.AddYears(1).Year)
                        .Done()
                    .Done()
                //.BillingDetails()
                //    .Zip("M5H 2N2")
                //    .Done()
                .Build();
        }

        public static Authorization CreateSampleComplexAuthorization()
        {
            return Authorization.Builder()
                .MerchantRefNum(Guid.NewGuid().ToString())
                .Amount(6666)
                .Card()
                    .CardNum("4111111111111111")
                    .Cvv("123")
                    .CardExpiry()
                        .Month(06)
                        .Year(DateTime.Now.AddYears(1).Year)
                        .Done()
                    .Done()
                .Authentication()
                    .Eci(5)
                    .Cavv("AAABCIEjYgAAAAAAlCNiENiWiV+=")
                    .Xid("OU9rcTRCY1VJTFlDWTFESXFtTHU=")
                    .ThreeDEnrollment("Y")
                    .ThreeDResult("Y")
                    .SignatureStatus("Y")
                    .Done()
                 .BillingDetails()
                    .Street("100 Queen Street West")
                    .City("Toronto")
                    .State("ON")
                    .Country("CA")
                    .Zip("M5H 2N2")
                    .Done()
                 .ShippingDetails()
                    .Carrier("UPS")
                    .ShipMethod("N")
                    .Street("100 Queen Street West")
                    .City("Toronto")
                    .State("ON")
                    .Country("CA")
                    .Zip("M5H 2N2")
                    .Done()
                 .CustomerIp("204.91.0.12")
                 .Description("I like turtles.")
                .Build();
        }

        public static Authorization CreateSampleSettledAuthorization()
        {
            return Authorization.Builder()
                .MerchantRefNum(Guid.NewGuid().ToString())
                .Amount(6666)
                .SettleWithAuth(true)
                .Card()
                    .CardNum("4111111111111111")
                    .Cvv("123")
                        .CardExpiry()
                        .Month(06)
                        .Year(DateTime.Now.AddYears(1).Year)
                        .Done()
                    .Done()
                .BillingDetails()
                    .Zip("M5H 2N2")
                    .Done()
                .Build();
        }

        public static PaysafeApiClient CreateSamplePaysafeApiClient()
        {
            return new PaysafeApiClient(Settings.Instance.Key,
                                        Settings.Instance.Secret, 
                                        Environment.Test, 
                                        Settings.Instance.MerchantdId);
        }

        public static PaysafeApiClient CreateSampleInvalidPaysafeApiClient()
        {
            return new PaysafeApiClient("Invalid_key",
                                        Settings.Instance.Secret,
                                        Environment.Test,
                                        Settings.Instance.MerchantdId);
        }


        public static CardPaymentService CreateSampleCardPaymentService()
        {
            var client = CreateSamplePaysafeApiClient();
            return new CardPaymentService(client);
        }

        public static CardPaymentService CreateSampleInvalidCardPaymentService()
        {
            var client = CreateSampleInvalidPaysafeApiClient();
            return new CardPaymentService(client);
        }

        public static Verification CreateSampleVerification()
        {
            return Verification.Builder()
                .MerchantRefNum(Guid.NewGuid().ToString())
                .Card()
                    .CardNum("4111111111111111")
                    .CardExpiry()
                        .Month(DateTime.Now.Month)
                        .Year(DateTime.Now.Year)
                        .Done()
                    .Cvv("123")
                    .Done()
                .Profile()
                    .FirstName("Joe")
                    .LastName("Smith")
                    .Email("Joe.Smith@canada.com")
                    .Done()
                .BillingDetails()
                    .Street("100 Queen Street West")
                    .City("Toronto")
                    .State("ON")
                    .Country("CA")
                    .Zip("M5H2N2")
                    .Done()
                .CustomerIp("204.91.0.12")
                .Description("This is a test transaction")
                .Build();
        }

        public static CustomerVaultService CreateSampleCustomerVaultService()
        {
            return new CustomerVaultService(CreateSamplePaysafeApiClient());
        }

        public static Profile CreateSampleProfile()
        {
            return Profile.Builder()
                .MerchantCustomerId(Guid.NewGuid().ToString())
                .Locale("en_US")
                .FirstName("John")
                .LastName("Smith")
                .Email("john.smith@example.com")
                .Phone("713-444-5555")
                .Build();
        }

        public static Address CreateSampleAddress(Profile profile)
        {
            return Address.Builder()
                .ProfileId(profile.Id())
                .NickName("home")
                .Street("100 Queen Street West")
                .Street2("Unit 201")
                .City("Toronto")
                .Country("CA")
                .State("ON")
                .Zip("M5H 2N2")
                .RecipientName("Jane Doe")
                .Phone("647-788-3901")
                .Build();
        }

        public static Card CreateSampleCard(Profile profile)
        {
            return Card.Builder()
                .ProfileId(profile.Id())
                .CardNum("4111111111111111")
                .CardExpiry()
                    .Month(DateTime.Now.Month)
                    .Year(DateTime.Now.AddYears(1).Year)
                    .Done()
                .BillingAddress()
                    .Street("100 Queen Street West")
                    .City("Toronto")
                    .State("ON")
                    .Country("CA")
                    .Zip("M5H2N2")
                    .Done()
                .Build();
        }
    }
}