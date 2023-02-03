<a name='assembly'></a>
# BarbezDotEu.Http

## Contents

- [HttpRequestMessageCloner](#T-BarbezDotEu-Http-HttpRequestMessageCloner 'BarbezDotEu.Http.HttpRequestMessageCloner')
  - [Clone()](#M-BarbezDotEu-Http-HttpRequestMessageCloner-Clone-System-Net-Http-HttpRequestMessage- 'BarbezDotEu.Http.HttpRequestMessageCloner.Clone(System.Net.Http.HttpRequestMessage)')
  - [Clone()](#M-BarbezDotEu-Http-HttpRequestMessageCloner-Clone-System-Net-Http-HttpContent- 'BarbezDotEu.Http.HttpRequestMessageCloner.Clone(System.Net.Http.HttpContent)')
- [HttpUriExtensions](#T-BarbezDotEu-Http-HttpUriExtensions 'BarbezDotEu.Http.HttpUriExtensions')
  - [GetAsHttpUri(uri)](#M-BarbezDotEu-Http-HttpUriExtensions-GetAsHttpUri-System-String- 'BarbezDotEu.Http.HttpUriExtensions.GetAsHttpUri(System.String)')

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
