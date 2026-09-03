using System;
using System.Threading;
using System.Threading.Tasks;
using AwesomeAssertions;
using Soenneker.Tests.Unit;

namespace Soenneker.Dictionaries.Singletons.Tests;

public sealed class SingletonDictionaryTests : UnitTest
{
    [Test]
    public async Task Keyed_initializes_once(CancellationToken cancellationToken)
    {
        int calls = 0;

        var dict = new SingletonDictionary<string>(key =>
        {
            Interlocked.Increment(ref calls);
            return new ValueTask<string>($"v-{key}");
        });

        string a = await dict.Get("k1", cancellationToken);
        string b = await dict.Get("k1", cancellationToken);

        a.Should().Be("v-k1");
        b.Should().Be("v-k1");
        calls.Should().Be(1);
    }

    [Test]
    public async Task Comparer_is_forwarded_to_keyed_dictionary(CancellationToken cancellationToken)
    {
        int calls = 0;

        var dict = new SingletonDictionary<string>(key =>
        {
            Interlocked.Increment(ref calls);
            return new ValueTask<string>(key);
        }, StringComparer.OrdinalIgnoreCase);

        string first = await dict.Get("billing", cancellationToken);
        string second = await dict.Get("BILLING", cancellationToken);

        first.Should().Be("billing");
        second.Should().Be("billing");
        calls.Should().Be(1);
    }

    [Test]
    public async Task T1_argFactory_only_runs_when_missing(CancellationToken cancellationToken)
    {
        int argFactoryCalls = 0;

        var dict = new SingletonDictionary<string, int>((key, arg) =>
            new ValueTask<string>($"{key}-{arg}"));

        string first = await dict.Get("k", () =>
        {
            Interlocked.Increment(ref argFactoryCalls);
            return 123;
        }, cancellationToken);

        string second = await dict.Get("k", () =>
        {
            Interlocked.Increment(ref argFactoryCalls);
            return 999;
        }, cancellationToken);

        first.Should().Be("k-123");
        second.Should().Be("k-123");
        argFactoryCalls.Should().Be(1);
    }

    [Test]
    public async Task T1T2_tuple_argFactory_only_runs_when_missing(CancellationToken cancellationToken)
    {
        int argFactoryCalls = 0;

        var dict = new SingletonDictionary<string, int, int>((key, a1, a2) =>
            new ValueTask<string>($"{key}-{a1}-{a2}"));

        string first = await dict.Get("k", () =>
        {
            Interlocked.Increment(ref argFactoryCalls);
            return (1, 2);
        }, cancellationToken);

        string second = await dict.Get("k", () =>
        {
            Interlocked.Increment(ref argFactoryCalls);
            return (9, 9);
        }, cancellationToken);

        first.Should().Be("k-1-2");
        second.Should().Be("k-1-2");
        argFactoryCalls.Should().Be(1);
    }

    [Test]
    public async Task TryGet_and_GetAll_work(CancellationToken cancellationToken)
    {
        var dict = new SingletonDictionary<string>(key => new ValueTask<string>($"v-{key}"));

        dict.TryGet("k", out _).Should().BeFalse();

        _ = await dict.Get("k", cancellationToken);

        dict.TryGet("k", out string? value).Should().BeTrue();
        value.Should().Be("v-k");

        var all = await dict.GetAll(cancellationToken);
        all.Should().HaveCount(1);
        all.Should().ContainKey("k").WhoseValue.Should().Be("v-k");
    }

    [Test]
    public async Task Clear_disposes_values(CancellationToken cancellationToken)
    {
        int disposed = 0;

        var dict = new SingletonDictionary<DisposableValue>(key =>
            new ValueTask<DisposableValue>(new DisposableValue(() => Interlocked.Increment(ref disposed))));

        _ = await dict.Get("a", cancellationToken);
        _ = await dict.Get("b", cancellationToken);

        await dict.Clear(cancellationToken);

        disposed.Should().Be(2);
        (await dict.GetKeys(cancellationToken)).Should().BeEmpty();
    }

    private sealed class DisposableValue : IDisposable
    {
        private readonly Action _onDispose;

        public DisposableValue(Action onDispose)
        {
            _onDispose = onDispose;
        }

        public void Dispose()
        {
            _onDispose();
        }
    }
}
