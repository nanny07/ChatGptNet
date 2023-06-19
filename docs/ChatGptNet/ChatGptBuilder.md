# ChatGptBuilder class

Represents the default builder for configuring ChatGPT.

```csharp
public class ChatGptBuilder : IChatGptBuilder
```

## Public Members

| name | description |
| --- | --- |
| [HttpClientBuilder](ChatGptBuilder/HttpClientBuilder.md) { get; } | Gets the IHttpClientBuilder used to configure the HttpClient used by ChatGPT. |
| [Services](ChatGptBuilder/Services.md) { get; } | Gets the IServiceCollection where ChatGPT services are registered. |

## See Also

* interface [IChatGptBuilder](./IChatGptBuilder.md)
* namespace [ChatGptNet](../ChatGptNet.md)
* [ChatGptBuilder.cs](https://github.com/marcominerva/ChatGptNet/tree/master/src/ChatGptNet/ChatGptBuilder.cs)

<!-- DO NOT EDIT: generated by xmldocmd for ChatGptNet.dll -->