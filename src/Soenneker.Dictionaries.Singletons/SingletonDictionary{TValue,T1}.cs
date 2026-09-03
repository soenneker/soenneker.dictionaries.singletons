using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Dictionaries.SingletonKeys;
using Soenneker.Dictionaries.Singletons.Abstract;

namespace Soenneker.Dictionaries.Singletons;

/// <inheritdoc cref="ISingletonDictionary{TValue, T1}"/>
public sealed class SingletonDictionary<TValue, T1> : SingletonKeyDictionary<string, TValue, T1>, ISingletonDictionary<TValue, T1>
{
    public SingletonDictionary()
    {
    }

    public SingletonDictionary(IEqualityComparer<string>? comparer) : base(comparer)
    {
    }

    public SingletonDictionary(Func<string, T1, ValueTask<TValue>> func) : base(func)
    {
    }

    public SingletonDictionary(Func<string, T1, ValueTask<TValue>> func, IEqualityComparer<string>? comparer) : base(func, comparer)
    {
    }

    public SingletonDictionary(Func<string, T1, CancellationToken, ValueTask<TValue>> func) : base(func)
    {
    }

    public SingletonDictionary(Func<string, T1, CancellationToken, ValueTask<TValue>> func, IEqualityComparer<string>? comparer) : base(func, comparer)
    {
    }

    public SingletonDictionary(Func<T1, ValueTask<TValue>> func) : base(func)
    {
    }

    public SingletonDictionary(Func<T1, ValueTask<TValue>> func, IEqualityComparer<string>? comparer) : base(func, comparer)
    {
    }

    public SingletonDictionary(Func<string, T1, TValue> func) : base(func)
    {
    }

    public SingletonDictionary(Func<string, T1, TValue> func, IEqualityComparer<string>? comparer) : base(func, comparer)
    {
    }

    public SingletonDictionary(Func<string, T1, CancellationToken, TValue> func) : base(func)
    {
    }

    public SingletonDictionary(Func<string, T1, CancellationToken, TValue> func, IEqualityComparer<string>? comparer) : base(func, comparer)
    {
    }

    public SingletonDictionary(Func<T1, TValue> func) : base(func)
    {
    }

    public SingletonDictionary(Func<T1, TValue> func, IEqualityComparer<string>? comparer) : base(func, comparer)
    {
    }
}
