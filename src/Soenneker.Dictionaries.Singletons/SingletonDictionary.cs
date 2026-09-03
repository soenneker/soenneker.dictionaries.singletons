using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Dictionaries.SingletonKeys;
using Soenneker.Dictionaries.Singletons.Abstract;

namespace Soenneker.Dictionaries.Singletons;

/// <inheritdoc cref="ISingletonDictionary{TValue}"/>
public sealed class SingletonDictionary<TValue> : SingletonKeyDictionary<string, TValue>, ISingletonDictionary<TValue>
{
    public SingletonDictionary()
    {
    }

    public SingletonDictionary(IEqualityComparer<string>? comparer) : base(comparer)
    {
    }

    public SingletonDictionary(Func<string, ValueTask<TValue>> func) : base(func)
    {
    }

    public SingletonDictionary(Func<string, ValueTask<TValue>> func, IEqualityComparer<string>? comparer) : base(func, comparer)
    {
    }

    public SingletonDictionary(Func<string, CancellationToken, ValueTask<TValue>> func) : base(func)
    {
    }

    public SingletonDictionary(Func<string, CancellationToken, ValueTask<TValue>> func, IEqualityComparer<string>? comparer) : base(func, comparer)
    {
    }

    public SingletonDictionary(Func<ValueTask<TValue>> func) : base(func)
    {
    }

    public SingletonDictionary(Func<ValueTask<TValue>> func, IEqualityComparer<string>? comparer) : base(func, comparer)
    {
    }

    public SingletonDictionary(Func<string, TValue> func) : base(func)
    {
    }

    public SingletonDictionary(Func<string, TValue> func, IEqualityComparer<string>? comparer) : base(func, comparer)
    {
    }

    public SingletonDictionary(Func<string, CancellationToken, TValue> func) : base(func)
    {
    }

    public SingletonDictionary(Func<string, CancellationToken, TValue> func, IEqualityComparer<string>? comparer) : base(func, comparer)
    {
    }

    public SingletonDictionary(Func<TValue> func) : base(func)
    {
    }

    public SingletonDictionary(Func<TValue> func, IEqualityComparer<string>? comparer) : base(func, comparer)
    {
    }

    /// <summary>
    /// Fluent typed wrapper around <see cref="SingletonKeyDictionary{TKey,TValue}.Initialize{TState}"/>.
    /// </summary>
    /// <typeparam name="TState">Type of state passed to the callback.</typeparam>
    /// <param name="state">State value used by the variant.</param>
    /// <param name="factory">Factory used to create a value when one is needed.</param>
    /// <returns>The resulting singleton Dictionary.</returns>
    public new SingletonDictionary<TValue> Initialize<TState>(TState state, Func<TState, string, CancellationToken, ValueTask<TValue>> factory)
        where TState : notnull
    {
        base.Initialize(state, factory);
        return this;
    }
}
