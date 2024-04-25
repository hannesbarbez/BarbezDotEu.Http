<a name='assembly'></a>
# BarbezDotEu.Http
Generic features related to HTTP and HTTPS. Contains extensions to HttpContent, and cloning an HttpRequestMessage via the HttpRequestMessageCloner.

## Contents

- [EdgeMockingRequestHeaderCollection](#T-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection 'BarbezDotEu.Http.EdgeMockingRequestHeaderCollection')
  - [#ctor(referrer,host)](#M-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-#ctor-System-String,System-String- 'BarbezDotEu.Http.EdgeMockingRequestHeaderCollection.#ctor(System.String,System.String)')
  - [UserAgent](#F-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-UserAgent 'BarbezDotEu.Http.EdgeMockingRequestHeaderCollection.UserAgent')
  - [AcceptHeaders](#P-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-AcceptHeaders 'BarbezDotEu.Http.EdgeMockingRequestHeaderCollection.AcceptHeaders')
  - [AcceptLanguage](#P-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-AcceptLanguage 'BarbezDotEu.Http.EdgeMockingRequestHeaderCollection.AcceptLanguage')
  - [CacheControl](#P-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-CacheControl 'BarbezDotEu.Http.EdgeMockingRequestHeaderCollection.CacheControl')
  - [Connection](#P-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-Connection 'BarbezDotEu.Http.EdgeMockingRequestHeaderCollection.Connection')
  - [Host](#P-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-Host 'BarbezDotEu.Http.EdgeMockingRequestHeaderCollection.Host')
  - [Others](#P-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-Others 'BarbezDotEu.Http.EdgeMockingRequestHeaderCollection.Others')
  - [Pragma](#P-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-Pragma 'BarbezDotEu.Http.EdgeMockingRequestHeaderCollection.Pragma')
  - [Referrer](#P-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-Referrer 'BarbezDotEu.Http.EdgeMockingRequestHeaderCollection.Referrer')
  - [DetermineAndSetHost(host)](#M-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-DetermineAndSetHost-System-String- 'BarbezDotEu.Http.EdgeMockingRequestHeaderCollection.DetermineAndSetHost(System.String)')
  - [Prep(httpRequestMessage)](#M-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-Prep-System-Net-Http-HttpRequestMessage- 'BarbezDotEu.Http.EdgeMockingRequestHeaderCollection.Prep(System.Net.Http.HttpRequestMessage)')
- [HttpRequestMessageCloner](#T-BarbezDotEu-Http-HttpRequestMessageCloner 'BarbezDotEu.Http.HttpRequestMessageCloner')
  - [Clone()](#M-BarbezDotEu-Http-HttpRequestMessageCloner-Clone-System-Net-Http-HttpRequestMessage- 'BarbezDotEu.Http.HttpRequestMessageCloner.Clone(System.Net.Http.HttpRequestMessage)')
  - [Clone()](#M-BarbezDotEu-Http-HttpRequestMessageCloner-Clone-System-Net-Http-HttpContent- 'BarbezDotEu.Http.HttpRequestMessageCloner.Clone(System.Net.Http.HttpContent)')
- [HttpUriExtensions](#T-BarbezDotEu-Http-HttpUriExtensions 'BarbezDotEu.Http.HttpUriExtensions')
  - [GetAsHttpUri(uri)](#M-BarbezDotEu-Http-HttpUriExtensions-GetAsHttpUri-System-String- 'BarbezDotEu.Http.HttpUriExtensions.GetAsHttpUri(System.String)')

<a name='T-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection'></a>
## EdgeMockingRequestHeaderCollection `type`

##### Namespace

BarbezDotEu.Http

##### Summary

Mocks headers that would've been sent typically by Microsoft Edge during the first half of 2021.

<a name='M-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-#ctor-System-String,System-String-'></a>
### #ctor(referrer,host) `constructor`

##### Summary

Constructs a new [EdgeMockingRequestHeaderCollection](#T-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection 'BarbezDotEu.Http.EdgeMockingRequestHeaderCollection').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| referrer | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The referrer to set. |
| host | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The value to set for the host header. Defaults to the domain of the referrer, if none provided. |

<a name='F-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-UserAgent'></a>
### UserAgent `constants`

##### Summary

Gets an Edge style user agent header.

<a name='P-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-AcceptHeaders'></a>
### AcceptHeaders `property`

##### Summary

Gets Edge style accept headers.

<a name='P-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-AcceptLanguage'></a>
### AcceptLanguage `property`

##### Summary

Gets an Edge style accept header.

<a name='P-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-CacheControl'></a>
### CacheControl `property`

##### Summary

Gets an Edge style cache-control header.

<a name='P-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-Connection'></a>
### Connection `property`

##### Summary

Gets an Edge style connection header.

<a name='P-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-Host'></a>
### Host `property`

##### Summary

Gets the hostname.

<a name='P-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-Others'></a>
### Others `property`

##### Summary

Gets a collection of non-standard headers, including:
- Edge style do-not-track header;
- Edge style sec-fetch-site header;
- Edge style sec-fetch-mode header;
- Edge style sec-fetch-dest header.

<a name='P-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-Pragma'></a>
### Pragma `property`

##### Summary

Gets an Edge style pragma header.

<a name='P-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-Referrer'></a>
### Referrer `property`

##### Summary

Gets an Edge style referrer header.

<a name='M-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-DetermineAndSetHost-System-String-'></a>
### DetermineAndSetHost(host) `method`

##### Summary

Determines and sets the value of the host header. Defaults to the domain of the referrer, if no meaningful host name is provided.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| host | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-BarbezDotEu-Http-EdgeMockingRequestHeaderCollection-Prep-System-Net-Http-HttpRequestMessage-'></a>
### Prep(httpRequestMessage) `method`

##### Summary

Prepares a given [HttpRequestMessage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage') with headers sent typically by Microsoft Edge during the first half of 2021.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| httpRequestMessage | [System.Net.Http.HttpRequestMessage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage') | The [HttpRequestMessage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage') to adjust. |

<a name='T-BarbezDotEu-Http-HttpRequestMessageCloner'></a>
## HttpRequestMessageCloner `type`

##### Namespace

BarbezDotEu.Http

##### Summary

Helper class for cloning [HttpRequestMessage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage')s.

<a name='M-BarbezDotEu-Http-HttpRequestMessageCloner-Clone-System-Net-Http-HttpRequestMessage-'></a>
### Clone() `method`

##### Summary

Clones a given [HttpRequestMessage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpRequestMessage 'System.Net.Http.HttpRequestMessage').

##### Parameters

This method has no parameters.

##### Remarks

Using this method helps avoiding a "The request message was already sent.
Cannot send the same request message multiple times." InvalidOperationException.

<a name='M-BarbezDotEu-Http-HttpRequestMessageCloner-Clone-System-Net-Http-HttpContent-'></a>
### Clone() `method`

##### Summary

Clones given [HttpContent](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Net.Http.HttpContent 'System.Net.Http.HttpContent').

##### Parameters

This method has no parameters.

<a name='T-BarbezDotEu-Http-HttpUriExtensions'></a>
## HttpUriExtensions `type`

##### Namespace

BarbezDotEu.Http

##### Summary

Misc. extensions pertaining to HTTP and URI

<a name='M-BarbezDotEu-Http-HttpUriExtensions-GetAsHttpUri-System-String-'></a>
### GetAsHttpUri(uri) `method`

##### Summary

Gets a string representing an HTTP URI and returns it as an actual HTTP [Uri](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Uri 'System.Uri').

##### Returns

An HTTP [Uri](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Uri 'System.Uri').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| uri | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The implicit HTTP URI. |
