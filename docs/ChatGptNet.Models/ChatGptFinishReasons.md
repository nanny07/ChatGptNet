# ChatGptFinishReasons class

Contains constants for all the possible chat completion finish reasons.

```csharp
public class ChatGptFinishReasons
```

## Public Members

| name | description |
| --- | --- |
| [ChatGptFinishReasons](ChatGptFinishReasons/ChatGptFinishReasons.md)() | The default constructor. |
| const [ContentFilter](ChatGptFinishReasons/ContentFilter.md) | Omitted content due to a flag from content filters. |
| const [FunctionCall](ChatGptFinishReasons/FunctionCall.md) | The model decided to call a function. |
| const [Length](ChatGptFinishReasons/Length.md) | Incomplete model output due to max_tokens parameter or token limit. |
| const [Stop](ChatGptFinishReasons/Stop.md) | API returned complete model output. |

## See Also

* namespace [ChatGptNet.Models](../ChatGptNet.md)
* [ChatGptFinishReasons.cs](https://github.com/marcominerva/ChatGptNet/tree/master/src/ChatGptNet/Models/ChatGptFinishReasons.cs)

<!-- DO NOT EDIT: generated by xmldocmd for ChatGptNet.dll -->