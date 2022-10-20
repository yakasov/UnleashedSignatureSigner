# UnleashedSignatureSigner
Generates api-auth-signature method signature for Unleashed API.

## How to use

First entry is your API key (not ID - this should be your value for your api-auth-id header).

Following entries will be the query for the URL eg `https://api.unleashedsoftware.com/Customers?CustomerCode=123` -> the query is `CustomerCode=123`. The resulting signature is your value for your api-auth-signature header.
