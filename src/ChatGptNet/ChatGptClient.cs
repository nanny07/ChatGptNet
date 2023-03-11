﻿using System.Net.Http.Json;
using ChatGptNet.Exceptions;
using ChatGptNet.Models;
using Microsoft.Extensions.Caching.Memory;

namespace ChatGptNet;

internal class ChatGptClient : IChatGptClient
{
    private readonly HttpClient httpClient;
    private readonly IMemoryCache cache;
    private readonly ChatGptOptions options;

    public ChatGptClient(HttpClient httpClient, IMemoryCache cache, ChatGptOptions options)
    {
        this.httpClient = httpClient;
        this.cache = cache;
        this.options = options;
    }

    public async Task<ChatGptResponse> AskAsync(string conversationId, string message, string model, CancellationToken cancellationToken = default)
    {
        // Checks whether a list of the messages for the given conversationId already exists.
        if (!cache.TryGetValue<IList<ChatGptMessage>>(conversationId, out var messages))
        {
            messages = new List<ChatGptMessage>();
        }

        messages!.Add(new()
        {
            Role = ChatGptRoles.User,
            Content = message
        });

        var request = new ChatGptRequest
        {
            Model = model,
            Messages = messages.ToArray()
        };

        using var httpResponse = await httpClient.PostAsJsonAsync("chat/completions", request, cancellationToken);
        var response = await httpResponse.Content.ReadFromJsonAsync<ChatGptResponse>(cancellationToken: cancellationToken);

        if (!httpResponse.IsSuccessStatusCode && options.ThrowExceptionsOnError)
        {
            throw new ChatGptException(response!.Error!, httpResponse.StatusCode);
        }

        // Adds the response message to the conversation cache.
        if (response!.Choices?.Any() ?? false)
        {
            messages.Add(response!.Choices[0].Message);
        }

        // If the maximum number of messages has been reached, deleted the oldest ones.
        if (messages.Count > options.MessageLimit)
        {
            messages = messages.TakeLast(options.MessageLimit).ToList();
        }

        cache.Set(conversationId, messages, options.MessageExpiration);

        response.ConversationId = conversationId;
        return response;
    }
}
