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

using System.Collections.Generic;

namespace Paysafe.Common
{
    /// <summary>
    /// GlobalConstants class contains all strings that are sent and returned from the netbanx api
    /// </summary>
    public class GlobalConstants
    {
        //////////// REQUEST PARAMETER STRINGS ////////////
        public static readonly string AccordD = "accordD";
        public static readonly string AcquirerResponse = "acquirerResponse";
        public static readonly string AddendumData = "addendumData";
        public static readonly string Addresses = "addresses";
        public static readonly string Amount = "amount";
        public static readonly string AncillaryFees = "ancillaryFees";
        public static readonly string AssociatedTransactions = "associatedTransactions";
        public static readonly string AuthCode = "authCode";
        public static readonly string Authentication = "authentication";
        public static readonly string AuthenticationMethod = "authenticationMethod";
        public static readonly string AuthorizationId = "authorizationId";
        public static readonly string AuthType = "authType";
        public static readonly string AvailableToRefund = "availableToRefund";
        public static readonly string AvailableToSettle = "availableToSettle";
        public static readonly string AvsCode = "avsCode";
        public static readonly string AvsResponse = "avsResponse";
        public static readonly string BalanceResponse = "balanceResponse";
        public static readonly string BatchNumber = "batchNumber";
        public static readonly string BillingAddressId = "billingAddressId";
        public static readonly string BillingDetails = "billingDetails";
        public static readonly string Brand = "brand";
        public static readonly string Callback = "callback";
        public static readonly string Card = "card";
        public static readonly string CardBin = "cardBin";
        public static readonly string CardEnrollementMethod = "cardEnrollementMethod";
        public static readonly string CardExpiry = "cardExpiry";
        public static readonly string CardNum = "cardNum";
        public static readonly string Cards = "cards";
        public static readonly string CardType = "cardType";
        public static readonly string Carrier = "carrier";
        public static readonly string Cavv = "cavv";
        public static readonly string CellPhone = "cellPhone";
        public static readonly string ChildAccountNum = "childAccountNum";
        public static readonly string City = "city";
        public static readonly string Code = "code";
        public static readonly string ConfirmationNumber = "confirmationNumber";
        public static readonly string Country = "country";
        public static readonly string CurrencyCode = "currencyCode";
        public static readonly string CustomerIp = "customerIp";
        public static readonly string CustomerNotificationEmail = "customerNotificationEmail";
        public static readonly string CvdVerification = "cvdVerification";
        public static readonly string Cvv = "cvv";
        public static readonly string Cvv2Result = "cvv2Result";
        public static readonly string CvvVerification = "cvvVerification";
        public static readonly string DateOfBirth = "dateOfBirth";
        public static readonly string DateTime = "dateTime";
        public static readonly string Day = "day";
        public static readonly string DefaultCardIndicator = "defaultCardIndicator";
        public static readonly string DefaultShippingAddressIndicator = "defaultShippingAddressIndicator";
        public static readonly string Delimiter = "delimiter";
        public static readonly string Description = "description";
        public static readonly string Details = "details";
        public static readonly string DueDate = "dueDate";
        public static readonly string DupCheck = "dupCheck";
        public static readonly string DynamicDescriptor = "dynamicDescriptor";
        public static readonly string Eci = "eci";
        public static readonly string EffectiveDate = "effectiveDate";
        public static readonly string Email = "email";
        public static readonly string Error = "error";
        public static readonly string ErrorCode = "errorCode";
        public static readonly string ErrorMessage = "errorMessage";
        public static readonly string Expiry = "expiry";
        public static readonly string ExtendedOptions = "extendedOptions";
        public static readonly string Field = "field";
        public static readonly string FieldErrors = "fieldErrors";
        public static readonly string FinancingType = "financingType";
        public static readonly string FirstName = "firstName";
        public static readonly string Format = "format";
        public static readonly string Gender = "gender";
        public static readonly string GracePeriod = "gracePeriod";
        public static readonly string HolderName = "holderName";
        public static readonly string HouseNumberVerification = "houseNumberVerification";
        public static readonly string Href = "href";
        public static readonly string Id = "id";
        public static readonly string Ip = "ip";
        public static readonly string Key = "key";
        public static readonly string Keywords = "keywords";
        public static readonly string LastDigits = "lastDigits";
        public static readonly string LastName = "lastName";
        public static readonly string LastUpdate = "lastUpdate";
        public static readonly string Link = "link";
        public static readonly string Links = "links";
        public static readonly string Locale = "locale";
        public static readonly string MasterCardAssignedId = "masterCardAssignedId";
        public static readonly string MasterPass = "masterPass";
        public static readonly string MerchantCustomerId = "merchantCustomerId";
        public static readonly string MerchantDescriptor = "merchantDescriptor";
        public static readonly string MerchantNotificationEmail = "merchantNotificationEmail";
        public static readonly string MerchantRefNum = "merchantRefNum";
        public static readonly string Message = "message";
        public static readonly string Mid = "mid";
        public static readonly string MiddleName = "middleName";
        public static readonly string Mode = "mode";
        public static readonly string Month = "month";
        public static readonly string Nationality = "nationality";
        public static readonly string NickName = "nickName";
        public static readonly string OrderId = "orderId";
        public static readonly string OriginalMerchantRefNum = "originalMerchantRefNum";
        public static readonly string PaymentMethod = "paymentMethod";
        public static readonly string PaymentToken = "paymentToken";
        public static readonly string PaymentType = "paymentType";
        public static readonly string PayPassWalletIndicator = "payPassWalletIndicator";
        public static readonly string Phone = "phone";
        public static readonly string Plan = "plan";
        public static readonly string Profile = "profile";
        public static readonly string ProfileId = "profileId";
        public static readonly string Quantity = "quantity";
        public static readonly string RecipientAccountNumber = "recipientAccountNumber";
        public static readonly string RecipientDateOfBirth = "recipientDateOfBirth";
        public static readonly string RecipientLastName = "recipientLastName";
        public static readonly string RecipientName = "recipientName";
        public static readonly string RecipientZip = "recipientZip";
        public static readonly string Recurring = "recurring";
        public static readonly string Redirect = "redirect";
        public static readonly string Reference = "reference";
        public static readonly string ReferenceNbr = "referenceNbr";
        public static readonly string Refunded = "refunded";
        public static readonly string Rel = "rel";
        public static readonly string RequestId = "requestId";
        public static readonly string ResponseCode = "responseCode";
        public static readonly string ResponseId = "responseId";
        public static readonly string ResponseReasonCode = "responseReasonCode";
        public static readonly string Retries = "retries";
        public static readonly string ReturnKeys = "returnKeys";
        public static readonly string Reversed = "reversed";
        public static readonly string RiskReasonCode = "riskReasonCode";
        public static readonly string SeqNumber = "seqNumber";
        public static readonly string Settled = "settled";
        public static readonly string SettlementId = "settlementId";
        public static readonly string Settlements = "settlements";
        public static readonly string SettleWithAuth = "settleWithAuth";
        public static readonly string ShipMethod = "shipMethod";
        public static readonly string ShippingDetails = "shippingDetails";
        public static readonly string ShoppingCart = "shoppingCart";
        public static readonly string SignatureStatus = "signatureStatus";
        public static readonly string Sku = "sku";
        public static readonly string State = "state";
        public static readonly string Status = "status";
        public static readonly string Street = "street";
        public static readonly string Street2 = "street2";
        public static readonly string Synchronous = "synchronous";
        public static readonly string Term = "term";
        public static readonly string TerminalId = "terminalId";
        public static readonly string ThreeDEnrollment = "threeDEnrollment";
        public static readonly string ThreeDEnrolment = "threeDEnrolment";
        public static readonly string ThreeDResult = "threeDResult";
        public static readonly string TotalAmount = "totalAmount";
        public static readonly string Track1 = "track1";
        public static readonly string Track2 = "track2";
        public static readonly string Transaction = "transaction";
        public static readonly string TxnDateTime = "txnDateTime";
        public static readonly string TxnTime = "txnTime";
        public static readonly string Type = "type";
        public static readonly string Uri = "uri";
        public static readonly string UseAsShippingAddress = "useAsShippingAddress";
        public static readonly string Value = "value";
        public static readonly string VisaAdditionalAuthData = "visaAdditionalAuthData";
        public static readonly string Xid = "xid";
        public static readonly string Year = "year";
        public static readonly string Zip = "zip";
        public static readonly string ZipVerification = "zipVerification";
        public static readonly string AccountNumber = "accountNumber";
        public static readonly string AccountHolderName = "accountHolderName";
        public static readonly string RoutingNumber = "routingNumber";
        public static readonly string AccountType = "accountType"; 
        public static readonly string SortCode = "sortCode";
        public static readonly string Mandates = "mandates";
        public static readonly string MandateReference = "mandateReference";
        public static readonly string Ach = "ach";
        public static readonly string Sepa = "sepa";
        public static readonly string Bacs = "bacs";
        public static readonly string Eft = "eft";
        public static readonly string PayMethod = "payMethod";
        public static readonly string Web = "WEB";
        public static readonly string Tel = "TEL";
        public static readonly string Ppd = "PPD";
        public static readonly string Ccd = "CCD";
        public static readonly string PaymentDescriptor = "paymentDescriptor";
        public static readonly string Iban = "iban";
        public static readonly string Bic = "bic";
        public static readonly string TransitNumber = "transitNumber";
        public static readonly string InstitutionId = "institutionId";
        public static readonly string BankAccountId = "bankAccountId";
        public static readonly string AccountTypeChecking = "CHECKING";
        public static readonly string AccountTypeLoan = "LOAN";
        public static readonly string AccountTypeSavings = "SAVINGS";

        ///

        public static readonly string AchBankAccounts = "achBankAccounts";
        public static readonly string BacsBankAccounts = "bacsBankAccounts";
        public static readonly string SepaBankAccounts = "sepaBankAccounts";
        public static readonly string EftBankAccounts = "eftBankAccounts";
        public static readonly string BillingAddress = "billingAddress";
        public static readonly string Enrollmentchecks = "enrollmentchecks";

        //////////// RESPONSE VALIDATON STRINGS ////////////
        public static readonly string AuthTypeAuth = "auth";
        public static readonly string AuthTypePurchase = "purchase";
        public static readonly string AuthTypeRefund = "refund";
        public static readonly string AuthTypeSettlement = "settlement";
        public static readonly string CarrierAnpost = "APS";
        public static readonly string CarrierApc = "APC";
        public static readonly string CarrierCanadaPost = "CAD";
        public static readonly string CarrierCityLink = "CLK";
        public static readonly string CarrierDhl = "DHL";
        public static readonly string CarrierEms = "EMS";
        public static readonly string CarrierFedEx = "FEX";
        public static readonly string CarrierNexWorldWide = "NEX";
        public static readonly string CarrierOther = "OTHER";
        public static readonly string CarrierRoyalMail = "RML";
        public static readonly string CarrierUps = "UPS";
        public static readonly string CarrierUsps = "USPS";
        public static readonly string FinancingDeferredPayment = "DEFERRED_PAYMENT";
        public static readonly string FinancingEqualPayment = "EQUAL_PAYMENT";
        public static readonly string FormatForm = "form-urlencoded";
        public static readonly string FormatGet = "get";
        public static readonly string FormatJson = "json";
        public static readonly string FormatXml = "xml";
        public static readonly string GenderFemale = "F";
        public static readonly string GenderMale = "M";
        public static readonly string LocaleEnGb = "en_GB";
        public static readonly string LocaleEnUs = "en_US";
        public static readonly string LocaleFrCa = "fr_CA";
        public static readonly string RelCancelUrl = "cancel_url";
        public static readonly string RelOnDecline = "on_decline";
        public static readonly string RelOnError = "on_error";
        public static readonly string RelOnHold = "on_hold";
        public static readonly string RelOnSuccess = "on_success";
        public static readonly string RelOnTimeout = "on_timeout";
        public static readonly string RelResendCallback = "resend_callback";
        public static readonly string RelReturnUrl = "return_url";
        public static readonly string RelSelf = "self";
        public static readonly string ShipMethodLowestCost = "C";
        public static readonly string ShipMethodNextDay = "N";
        public static readonly string ShipMethodOther = "O";
        public static readonly string ShipMethodTwoDay = "T";
        public static readonly string StatusActive = "ACTIVE";        
        public static readonly string StatusInvalid = "INVALID";
        public static readonly string StatusInactive = "INACTIVE";
        public static readonly string StatusDeclined = "DECLINED";
        public static readonly string StatusBatched = "BATCHED";
        public static readonly string StatusRejected = "REJECTED";
        public static readonly string StatusDisputed = "DISPUTED";
        public static readonly string StatusReason = "REASON";
        public static readonly string StatusChangeDate = "statusChangeDate";
        public static readonly string StatusReasonCode = "statusReasonCode";
        public static readonly string StatusCancelled = "CANCELLED";
        public static readonly string StatusCompleted = "COMPLETED";
        public static readonly string StatusFailed = "FAILED";
        public static readonly string StatusInitial = "INITIAL";
        public static readonly string StatusPending = "PENDING";
        public static readonly string StatusProcessing = "PROCESSING";
        public static readonly string StatusReceived = "RECEIVED";
        public static readonly string RecurringInitial = "INITIAL";
        public static readonly string RecurringRecurring = "RECURRING";
        public static readonly string ValidationHeld = "HELD";
        public static readonly string ValidationMatch = "MATCH";
        public static readonly string ValidationMatchAddressOnly = "MATCH_ADDRESS_ONLY";
        public static readonly string ValidationMatchZipOnly = "MATCH_ZIP_ONLY";
        public static readonly string ValidationNoMatch = "NO_MATCH";
        public static readonly string ValidationNotProcessed = "NOT_PROCESSED";
        public static readonly string ValidationUnknown = "UNKNOWN";
        public static readonly string SingleUseToken = "singleUseToken";
        public static readonly string Currency = "currency";
        public static readonly string UserAgent = "userAgent";
        public static readonly string AcceptHeader = "acceptHeader";
        public static readonly string MerchantUrl = "merchantUrl";
        public static readonly string AcsUrl = "acsURL";
        public static readonly string PaReq = "paReq";
        public static readonly string ThreeDEnrolled = "Y";
        public static readonly string ThreeDNotEnrolled = "N";
        public static readonly string ThreeDEnrollmentUnavailable = "U";
        public static readonly string PaResp = "paRes";
        public static readonly string Authenticated = "Y";
        public static readonly string AuthenticationAttempted = "A";
        public static readonly string AuthenticationFailed = "N";
        public static readonly string AuthenticationUnavailable = "U";
        public static readonly string AuthenticationError = "E";
        public static readonly string SignatureSatisfied = "Y";
        public static readonly string SignatureNotSatisfied = "N";
        public static readonly string EnrollmentId = "enrollmentId";
        
        public static readonly string Am = "AM";
        public static readonly string Dc = "DC";
        public static readonly string Di = "DI";
        public static readonly string Jc = "JC";
        public static readonly string Mc = "MC";
        public static readonly string Md = "MD";
        public static readonly string Sf = "SF";
        public static readonly string So = "SO";
        public static readonly string Vi = "VI";
        public static readonly string Vd = "VD";
        public static readonly string Ve = "VE";
        
        /// <summary>
        /// Carriers
        /// </summary>
        public static readonly List<string> EnumCarrier = new List<string>{
            CarrierApc,
            CarrierAnpost,
            CarrierCanadaPost,
            CarrierDhl,
            CarrierFedEx,
            CarrierRoyalMail,
            CarrierUps,
            CarrierUsps,
            CarrierCityLink,
            CarrierEms,
            CarrierNexWorldWide,
            CarrierOther
        };


        /// <summary>
        /// Genders
        /// </summary>
        public static readonly List<string> EnumGender = new List<string>() {
            GenderMale,
            GenderFemale
        };

        /// <summary>
        /// Locales
        /// </summary>
        public static readonly List<string> EnumLocale = new List<string>() {
            LocaleEnUs,
            LocaleFrCa,
            LocaleEnGb
        };

        /// <summary>
        /// Shipping Methods
        /// </summary>
        public static readonly List<string> EnumShipMethod = new List<string>() {
            ShipMethodNextDay,
            ShipMethodTwoDay,
            ShipMethodLowestCost,
            ShipMethodOther
        };
    }
}
