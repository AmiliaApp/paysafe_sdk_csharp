using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Paysafe;
using Paysafe.CardPayments;
using Authorization = Paysafe.CardPayments.Authorization;
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
            Authorization auth = Authorization.Builder()
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
            return auth;
        }

        public static Authorization CreateSampleIncompleteAuthorization()
        {
            Authorization auth = Authorization.Builder()
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
            return auth;
        }

        public static Authorization CreateSampleComplexAuthorization()
        {
            Authorization auth = Authorization.Builder()
                .MerchantRefNum(Guid.NewGuid().ToString())
                .Amount(6666)
                .Card()
                    .CardNum("4111111111111111")
                    .Cvv("123")
                    .CardExpiry()
                        .Month(06)
                        .Year(2020)
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
            return auth;
        }

        public static Authorization CreateSampleSettledAuthorization()
        {
            Authorization auth = Authorization.Builder()
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
            return auth;
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

    }
}
