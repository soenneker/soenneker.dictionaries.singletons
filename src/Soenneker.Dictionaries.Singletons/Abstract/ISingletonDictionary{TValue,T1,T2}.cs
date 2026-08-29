using Soenneker.Dictionaries.SingletonKeys.Abstract;

namespace Soenneker.Dictionaries.Singletons.Abstract;

/// <summary>
/// Specializes singleton-key dictionary operations for string keys.
/// </summary>
public interface ISingletonDictionary<TValue, T1, T2> : ISingletonKeyDictionary<string, TValue, T1, T2>;


