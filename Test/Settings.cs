using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Settings
    {
        private Settings()
        {
            Key = ConfigurationManager.AppSettings["paysafePaymentApiKey"];

            Secret = ConfigurationManager.AppSettings["paysafePaymentApiSecret"];

            MerchantdId = ConfigurationManager.AppSettings["paysafeMerchantId"];

            DirectDebitEftId = ConfigurationManager.AppSettings["paysafeDirectDebitMerchantEftId"];

            DirectDebitAchId = ConfigurationManager.AppSettings["paysafeDirectDebitMerchantAchId"];
        }
        public static Settings Instance => Nested.instance;
        public string Key { get; private set; }
        public string Secret { get; private set; }
        public string MerchantdId { get; private set; }
        public string DirectDebitEftId { get; private set; }
        public string DirectDebitAchId { get; private set; }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit

            internal static readonly Settings instance = new Settings();

            static Nested() { }
        };
    }
}
