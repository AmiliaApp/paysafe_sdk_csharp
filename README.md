# Paysafe Payments C# SDK

## Installation
___

Building this SDK requires Microsoft Visual Studio 2015 Professional to be installed.
Supported target .net46 for now

## Usage

___

Find it with nuget with PaysafeSDK

## Test suite
___

### Code coverage
Every test is devided between the synchronous method causing an API call and its asynchronous counterpart.

#### Covered by tests

##### Exceptions
- InvalidRequestException (400)
- InvalidCredentialsException (401)
- RequestDeclinedException (402)
- EntityNotFoundException (404)
- RequestConflictException (409)
- ApiException (500)

##### CardPaymentService
- Service monitor
- Managing authorizations
- Card purchase processing
- Managing voiding of authorizations
- Managing settling of card authorizations
- Managing verification of card payments
##### CustomerVaultService
- Service monitor
- Managing customer profiles
- Managing profile addresses
- Managing customer cards
- Managing ACH bank accounts
- Managing EFT bank accounts
- Processing payments using a payment token
- Refund of *pending* authorization error

##### DirectDebitService

###### EFT
- Service monitor
- Managing purchases
- Processing standalone credits
###### ACH
- Service monitor
- Managing purchases
- Processing standalone credits
#### Not covered by tests

##### Exceptions

##### CardPaymentService
- Approving held auhtorizations
- Cancelling held authorizations
- Managing refunds

##### CustomerVaultService
- Managing BACS bank accounts
- Managing SEPA bank accounts
- Managing mandates

##### DirectDebitService

##### SEPA
- Service monitor
- Managing purchases
- Processing standalone credits
##### BACS
- Service monitor
- Managing purchases
- Processing standalone credits
##### ThreeDSecureService
- No test coverage

### Known issues

##### DirectDebitService
```
var returnedPurchase = _eftDirectDebitService.GetPurchase(Purchases.Builder()
    .MerchantRefNum(_eftPurchase.MerchantRefNum())
    .Build());
```

```
var returnedStandaloneCredit = _eftDirectDebitService.GetStandaloneCredits(StandaloneCredits.Builder()
    .MerchantRefNum(_standaloneCredit.MerchantRefNum())
    .Build());
```
and their Async equivalents sometimes result empty values, for minutes at a time.

### Possible ameliorations
#### AbstractPagerator
```
AbstractPagerator.MoveNext()
```
has not been made async dues to the difficulty of async method that implements IEnumerator.