[![](https://img.shields.io/nuget/v/soenneker.dictionaries.singletons.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dictionaries.singletons/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dictionaries.singletons/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.dictionaries.singletons/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.dictionaries.singletons.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dictionaries.singletons/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dictionaries.singletons/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.dictionaries.singletons/actions/workflows/codeql.yml)

# Soenneker.Dictionaries.Singletons

String-key convenience types for `Soenneker.Dictionaries.SingletonKeys`, used to create and own one cached value per name.

## Installation

```bash
dotnet add package Soenneker.Dictionaries.Singletons
```

## Usage

```csharp
using Soenneker.Dictionaries.Singletons;

await using var clients = new SingletonDictionary<ApiClient>(
    async (name, cancellationToken) =>
        await ApiClient.Connect(name, cancellationToken));

ApiClient billing = await clients.Get("billing", cancellationToken);
ApiClient sameBilling = await clients.Get("billing", cancellationToken);
```

Concurrent callers for one missing string key share a single factory execution. A successful value remains cached until removal, clear, or dictionary disposal. Factory failures are not cached.

Pass an `IEqualityComparer<string>` when names require non-default comparison:

```csharp
var clients = new SingletonDictionary<ApiClient>(
    name => CreateClient(name),
    StringComparer.OrdinalIgnoreCase);
```

## Creation arguments

Use `SingletonDictionary<TValue, T1>` or `SingletonDictionary<TValue, T1, T2>` when creation needs call-site arguments:

```csharp
var clients = new SingletonDictionary<ApiClient, Uri, string>(
    (name, endpoint, apiKey, cancellationToken) =>
        ApiClient.Connect(endpoint, apiKey, cancellationToken));

ApiClient client = await clients.Get(
    "billing",
    billingEndpoint,
    billingApiKey,
    cancellationToken);
```

Arguments are used only when the key is first created. Later calls for `"billing"` return the cached instance even if different arguments are supplied.

## Removal and ownership

```csharp
bool removed = await clients.Remove("billing", cancellationToken);
bool evicted = await clients.Evict("reporting", cancellationToken);
```

`Remove` is a fast remove-and-dispose operation for an already cached value. `Evict` also coordinates with a factory currently creating that key. `TryRemove(key, out value)` removes without disposal and transfers ownership to the caller.

The dictionary owns cached values. Clear and disposal prefer `IAsyncDisposable` over `IDisposable`, and disposal waits for factories already in progress. Synchronous APIs are available but can block on asynchronous creation or cleanup.

For non-string keys or custom key types, use `Soenneker.Dictionaries.SingletonKeys` directly.
