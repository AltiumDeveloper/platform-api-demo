using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;

namespace Altium.Client;

/// <summary>
/// Getting configured Altium clients.
/// </summary>
public static class AltiumClientFactory
{
    static readonly ConcurrentDictionary<string, AltiumClient> _clients = new();

    /// <summary>
    /// Altium access token, must be assigned.
    /// </summary>
    public static string? AccessToken { get; set; }

    /// <summary>
    /// Gets the specified client.
    /// </summary>
    public static AltiumClient GetClient(string endpoint)
    {
        if (string.IsNullOrEmpty(endpoint))
            throw new ArgumentNullException(nameof(endpoint));

        if (string.IsNullOrEmpty(AccessToken))
            throw new InvalidOperationException(nameof(AccessToken));

        var endpointUri = new Uri(endpoint);
        return _clients.GetOrAdd(endpointUri.AbsoluteUri, _ => CreateClient(endpointUri));
    }

    private static AltiumClient CreateClient(Uri endpoint)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection
            .AddAltiumClient()
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = endpoint;
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");
            });

        var services = serviceCollection.BuildServiceProvider();
        return services.GetRequiredService<AltiumClient>();
    }
}
